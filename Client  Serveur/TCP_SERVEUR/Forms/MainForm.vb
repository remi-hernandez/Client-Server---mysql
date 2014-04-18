Imports System.Net.Sockets

Public Class MainForm

    Dim Serveur As New SocketServeur

    Private Sub ButtonServeur_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonServeur.Click
        Me.ProgressBar1.Minimum = 0 : Me.ProgressBar1.Maximum = 20 : Me.ProgressBar1.Step = 1
        If ButtonServeur.Text = "Lancer le Serveur" Then
            ListBox1.BackColor = Drawing.Color.SeaShell
            Serveur = New SocketServeur()
            Serveur.RunServeur()
            Serveur.MiseAZeroIdListBox()
            Serveur._form = Me
            ListBoxDetails.Items.Add("Écoute sur " & Serveur.myIEP.Address.ToString() & ":" & Serveur.myIEP.Port.ToString())
            Me.ProgressBar1.Style = ProgressBarStyle.Marquee
            ButtonServeur.Text = "Arreter le Serveur"
            Me.LabelStatus.Text = "Statut du serveur : " + Serveur.etatServeur.ToString() + " | Nb connexion : " + Serveur.nombreClients

            AddHandler Serveur.ClientAccepteOrDeco, AddressOf MiseAJourBarreStatut
            AddHandler Serveur.ClientMessage, AddressOf MiseAJourMsgClient
        Else
            Serveur.StopServeur()
            ListBoxDetails.Items.Add("Arret Serveur")
            Me.ProgressBar1.Style = ProgressBarStyle.Blocks
            ButtonServeur.Text = "Lancer le Serveur"
            Me.LabelStatus.Text = "Statut du serveur : déconnecté"
        End If
    End Sub
    
    '' Sert a faire apparaitre des informations liés aux clients -> dans un thread
    Sub MiseAJourBarreStatut(ByVal sender As Object, ByVal e As MyEventArgs)
        Me.Invoke(Sub() Me.LabelStatus.Text = "Statut du serveur : " + Serveur.etatServeur.ToString() + " | Nb connexion : " + Serveur.nombreClients)
        Dim SocketClient As Socket = CType(sender, Socket)
        If e.MyArgs = "+" Then
            Me.Invoke(Sub() Me.ListBoxDetails.Items.Add("Client connecté : " & SocketClient.RemoteEndPoint.ToString()))
        Else
            Me.Invoke(Sub() Me.ListBoxDetails.Items.Add("Client déconnecté : " & SocketClient.RemoteEndPoint.ToString()))
        End If
    End Sub

    '' Thread
    '' Sert a afficher les messages du client précédé de son IP et du Port -> dans un thread
    '' Traitement de la rame à partir d'un thread différent
    '' Gérer les directions à prendre

    Sub MiseAJourMsgClient(ByVal sender As Object, ByVal Msg As String, ByVal e As EventArgs)
        Dim struct As StructDataThread = CType(sender, StructDataThread)
        Dim SocketClient As Socket = struct.SocketClient
        Dim LI() As String = Split(Msg, "¤")

        If LI(1) = "operation" Then
            Me.Invoke(Sub() Me.ListBoxError.Items.Add("Debug [Reply to client] : operation"))
            SocketClient.Send(System.Text.Encoding.Unicode.GetBytes("Datas received")) '' ## envoie d'un message au client
            Me.Invoke(Sub() Me.ListBoxDetails.Items.Add("Operation d'un client"))
            Console.WriteLine("Socket send message for operation")
        End If
        If LI(1) = "connexion" Then
            Console.WriteLine("Connexion client")
            Me.Invoke(Sub() Me.ListBoxDetails.Items.Add("Connexion d'un client"))
        End If
        If LI(1) = "deconnexion" Then
            Console.WriteLine("Déconnexion client")
            Me.Invoke(Sub() Me.ListBoxDetails.Items.Add("Deconnexion d'un client"))
        End If
    End Sub
End Class