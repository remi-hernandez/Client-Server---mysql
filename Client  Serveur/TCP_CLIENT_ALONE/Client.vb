Imports System.Net
Imports System.Net.Sockets
Imports System.Threading
Imports System.Runtime.Remoting.Messaging

Public Class Client

    Private rBuf() As Byte = New Byte(1024) {}
    Dim codeconnect = "oxal"
    Dim s_site = 12
    Dim s_caisse = 42
    Dim s_nom = "Connection " & s_caisse
    Dim FTR = Chr(253)
    Dim SP = "¤"   'trame
    Dim SP1 = "|"  'enregistrement
    Dim SP2 = "¦"  'champ
    Dim SP3 = "§"  'champ

    'Non utilisé pour le moment 
    Dim Msg As String = 0 & SP & s_site & SP & s_nom & SP & s_caisse & SP & codeconnect & SP & Dns.GetHostName() & SP & Application.ProductVersion.ToString() & SP & Process.GetCurrentProcess.ProcessName & " - " & "indexclient" & FTR
    Dim MsgConnexion As String = SP & "connexion" & SP & s_site & FTR
    Dim MsgDeconnexion As String = SP & "deconnexion" & SP & s_site & FTR
    Dim SocketClient As Socket

    ''Mise en place de la fenetre de départ : cacher les champs pour la transaction afin d'éviter que l'utilisateur les utilise avant la connexion
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ListBoxMsgServeur.Hide()
        TextBoxMontantAchat.Hide()
        TextBoxPourcentRemise.Hide()
        TextBoxMontantRetrait.Hide()
        BouttonValiderOperation.Hide()
        LabelValiderOperation.Hide()
    End Sub

    ''Fonction servant a la connexion :
    ''change le nom du boutton et instancie la Socket client pour se connecter au serveur
    ''si le client n'est pas connecté on se connecte via SocketClient et on envoie le message
    ''sinon on envoie juste le message
    ''si exception on remet l'interface en mode hors ligne
    ''On réaffiche les champs pour la transaction
    Private Sub Connexion()
        BouttonConnexionDeconnexion.Text = "Deconnexion"
        SocketClient = New Socket(Sockets.AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)

        If Not SocketClient.Connected Then
            Try
                SocketClient.Connect("127.0.0.1", 10000)
                SocketClient.Send(System.Text.Encoding.Default.GetBytes(MsgConnexion))
            Catch ex As SocketException
                MessageBox.Show("Impossible de se connecter au serveur")
                LabelInfos.Show()
                BouttonConnexionDeconnexion.Text = "Connexion"
            End Try
        ElseIf SocketClient.Connected Then
            SocketClient.Send(System.Text.Encoding.Default.GetBytes(Msg))
        End If
        LabelInfos.Hide()
        ListBoxMsgServeur.Show()
        TextBoxMontantAchat.Show()
        TextBoxPourcentRemise.Show()
        TextBoxMontantRetrait.Show()
        BouttonValiderOperation.Show()
    End Sub

    ''Fonction servant a la déconnexion
    ''Modification du texte du boutton de connexion
    ''Envoie du message de deconnexion au serveur et fermeture de la socket
    Private Sub Deconnexion()
        BouttonConnexionDeconnexion.Text = "Connexion"
        Try
            SocketClient.Send(System.Text.Encoding.Default.GetBytes(MsgDeconnexion))
            SocketClient.Close()
            LabelInfos.Show()
            LabelValiderOperation.Hide()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    ''Connexion ou deconnexion du client
    Private Sub BouttonConnexionDeconnexion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BouttonConnexionDeconnexion.Click
        If BouttonConnexionDeconnexion.Text = "Connexion" Then
            Connexion()
        Else
            Deconnexion()
        End If
    End Sub
    ''
    '' Partie thread juste pour la communication avec le serveur
    ''
    Delegate Function MyDelegate(ByRef SocketClient As Socket)

    'Réception du message du serveur puis affichage du message dans la ListBox en passant par le thread principal
    Private Function CommunicationServeur(ByRef SocketClient As Socket)
        Console.WriteLine("In CommunicationServeur")
        SocketClient.Receive(rBuf)
        Console.WriteLine(System.Text.Encoding.Unicode.GetString(rBuf))
        If InvokeRequired Then
            Dim tmp As String = "Message du serveur : " & SocketClient.RemoteEndPoint.ToString() & " " & System.Text.Encoding.Unicode.GetString(rBuf)
            Invoke(Sub() ListBoxMsgServeur.Items.Add(tmp))
        End If
        Return ("Success")
    End Function

    ''
    '' Partie thread
    ''
    'Envoie des données des champs au serveur via un message unique récupérant les valeurs des 3 champs lors de l'appuie sur valider operation
    Private Sub BouttonValiderOperation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BouttonValiderOperation.Click
        Dim MsgData As String = SP & "operation" & SP & TextBoxMontantAchat.Text & SP & TextBoxPourcentRemise.Text & SP & TextBoxMontantRetrait.Text & FTR
        If Not SocketClient.Connected Then
            MessageBox.Show("Veuillez vous connecter")
        Else
            Dim d As MyDelegate = AddressOf CommunicationServeur
            d.BeginInvoke(SocketClient, Nothing, Nothing)
            SocketClient.Send(System.Text.Encoding.Default.GetBytes(MsgData))
            LabelValiderOperation.Show()
        End If
    End Sub
End Class
