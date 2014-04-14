Imports System.Net.Sockets

Public Class MainForm

    Dim Serveur As New SocketServeur

    Private Sub ButtonServeur_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonServeur.Click
        Me.ProgressBar1.Minimum = 0 : Me.ProgressBar1.Maximum = 20 : Me.ProgressBar1.Step = 1
        If ButtonServeur.Text = "Lancer le Serveur" Then
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

    'Sert a faire apparaitre des informations liés aux clients -> dans un thread
    Sub MiseAJourBarreStatut(ByVal sender As Object, ByVal e As MyEventArgs)
        Me.Invoke(Sub() Me.LabelStatus.Text = "Statut du serveur : " + Serveur.etatServeur.ToString() + " | Nb connexion : " + Serveur.nombreClients)
        Dim SocketClient As Socket = CType(sender, Socket)
        If e.MyArgs = "+" Then
            Me.Invoke(Sub() Me.ListBoxDetails.Items.Add("Client connecté : " & SocketClient.RemoteEndPoint.ToString()))
        Else
            Me.Invoke(Sub() Me.ListBoxDetails.Items.Add("Client déconnecté : " & SocketClient.RemoteEndPoint.ToString()))
        End If
    End Sub

    ''
    ''  ##Thread
    ''

    'Sert a afficher les messages du client précédé de son IP et du Port -> dans un thread
    Sub MiseAJourMsgClient(ByVal sender As Object, ByVal Msg As String, ByVal e As EventArgs)
        'Me.Invoke(Sub() Me.ListBoxDetails.Items.Add("Message de " & SocketClient.RemoteEndPoint.ToString() & " : " & Msg))
        'traitement de la rame à partir d'un thread différent
        Dim LI() As String = Split(Msg, "¤")
        'ajout pour permettre au serveur de répondre #CODE
        If LI(1) = "operation" Then
            SocketClient.Send(System.Text.Encoding.Unicode.GetBytes("Datas received"))
            Me.Invoke(Sub() Me.ListBoxDetails.Items.Add("Operation d'un client"))
            Console.WriteLine("Socket send message for operation")
        End If
        'afficher les champs
        'modifie les labels sur le thread principal
        ' Me.Invoke(Sub() Me.Label1.Text = LI(2))
        ' Me.Invoke(Sub() Me.Label2.Text = LI(3))
        ' Me.Invoke(Sub() Me.Label3.Text = LI(4))
        ' Me.Invoke(Sub() Me.Label4.Text = LI(5))
        ' Me.Invoke(Sub() Me.Label5.Text = LI(6))
        'gérer les directions à prendre
        If LI(1) = "connexion" Then
            Console.WriteLine("Connexion client")
            Me.Invoke(Sub() Me.ListBoxDetails.Items.Add("Connexion d'un client"))
        End If
        If LI(1) = "deconnexion" Then 'ajouter le -1 a une place de libre
            Console.WriteLine("Déconnexion client")
            Me.Invoke(Sub() Me.ListBoxDetails.Items.Add("Deconnexion d'un client"))
        End If
    End Sub

    ' Public Sub PrintText(ByVal str As String, ByVal id As Integer)
    '     Select Case id
    '         Case 1
    '             Me.Invoke(Sub() Me.ListBox1.Items.Add(str))
    '         Case 2
    '             Me.Invoke(Sub() Me.ListBox2.Items.Add(str))
    '         Case 3
    '             Me.Invoke(Sub() Me.ListBox3.Items.Add(str))
    '         Case 4
    '             Me.Invoke(Sub() Me.ListBox4.Items.Add(str))
    '         Case 5
    '             Me.Invoke(Sub() Me.ListBox5.Items.Add(str))
    '         Case 6
    '             Me.Invoke(Sub() Me.ListBox6.Items.Add(str))
    '         Case 7
    '             Me.Invoke(Sub() Me.ListBox7.Items.Add(str))
    '         Case 8
    '             Me.Invoke(Sub() Me.ListBox8.Items.Add(str))
    '         Case 9
    '             Me.Invoke(Sub() Me.ListBox9.Items.Add(str))
    '         Case 10
    '             Me.Invoke(Sub() Me.ListBox10.Items.Add(str))
    '         Case 11
    '             Me.Invoke(Sub() Me.ListBox11.Items.Add(str))
    '         Case 12
    '             Me.Invoke(Sub() Me.ListBox12.Items.Add(str))
    '         Case 13
    '             Me.Invoke(Sub() Me.ListBox13.Items.Add(str))
    '         Case 14
    '             Me.Invoke(Sub() Me.ListBox14.Items.Add(str))
    '         Case 15
    '             Me.Invoke(Sub() Me.ListBox15.Items.Add(str))
    '         Case 16
    '             Me.Invoke(Sub() Me.ListBox16.Items.Add(str))
    '     End Select
    ' End Sub
End Class