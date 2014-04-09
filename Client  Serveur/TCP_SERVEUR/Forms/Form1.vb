Imports System.Net.Sockets

Public Class Form1

    Dim Serveur As SocketServeur
    Dim bdd As New BDD

    'Initialisation de la classe SocketServeur puis appel de la méthode RunServeur pour le lancer puis 
    'modification de la partie graphique pour montrer que l'interface ne se fige pas
    'Les AddHandler permettent d'affecter différentes fonctions lié aux événements de la classe :
    ' - Evénement appelé quand un client vient de se connecter 
    ' - Evénement appelé quand un message est reçus par un client
    'Partie arret du serveur
    Private Sub ButtonServeur_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonServeur.Click
        Me.ProgressBar1.Minimum = 0 : Me.ProgressBar1.Maximum = 20 : Me.ProgressBar1.Step = 1

        If ButtonServeur.Text = "Lancer le Serveur" Then
            bdd.Connexion()
            bdd.EnvoiRequetes("SELECT Prénom FROM `personne` LIMIT 0 , 30")

            Serveur = New SocketServeur()
            Serveur.RunServeur()
            ListBox1.Items.Add("Écoute sur " & Serveur.myIEP.Address.ToString() & ":" & Serveur.myIEP.Port.ToString())
            Me.ProgressBar1.Style = ProgressBarStyle.Marquee
            ButtonServeur.Text = "Arreter le Serveur"
            Me.ToolStripStatusLabel1.Text = "Statut du serveur : " + Serveur.etatServeur.ToString() + " | Nb connexion : " + Serveur.nombreClients

            AddHandler Serveur.ClientAccepteOrDeco, AddressOf MiseAJourBarreStatut
            AddHandler Serveur.ClientMessage, AddressOf MiseAJourMsgClient
        Else
            Serveur.StopServeur()
            ListBox1.Items.Add("Arret Serveur")
            Me.ProgressBar1.Style = ProgressBarStyle.Blocks
            ButtonServeur.Text = "Lancer le Serveur"
        End If
    End Sub

    'Sert a faire apparaitre des informations liés aux clients
    Sub MiseAJourBarreStatut(sender As Object, e As MyEventArgs)
        Me.ToolStripStatusLabel1.Text = "Statut du serveur : " + Serveur.etatServeur.ToString() + " | Nb connexion : " + Serveur.nombreClients
        Dim SocketClient As Socket = CType(sender, Socket)
        If e.MyArgs = "+" Then
            Me.Invoke(Sub() Me.ListBox1.Items.Add("Client connecté : " & SocketClient.RemoteEndPoint.ToString()))
        Else
            Me.Invoke(Sub() Me.ListBox1.Items.Add("Client déconnecté : " & SocketClient.RemoteEndPoint.ToString()))
        End If
    End Sub

    'Sert a afficher les messages du client précédé de son IP et du Port
    Sub MiseAJourMsgClient(sender As Object, Msg As String, e As EventArgs)
        Dim SocketClient As Socket = CType(sender, Socket)
        Me.Invoke(Sub() Me.ListBox2.Items.Add("Message de " & SocketClient.RemoteEndPoint.ToString() & " : " & Msg))

        'traitement de la rame à partir d'un thread différent
        Dim LI() As String = Split(Msg, "¤")

        'ajout pour permettre au serveur de répondre #CODE
        If LI(1) = "operation" Then
            SocketClient.Send(System.Text.Encoding.Unicode.GetBytes("Datas received"))
            Me.Invoke(Sub() Me.ListBox3.Items.Add("Operation d'un client"))
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
            Me.Invoke(Sub() Me.ListBox3.Items.Add("Connexion d'un client"))
        End If

        If LI(1) = "deconnexion" Then
            Console.WriteLine("Déconnexion client")
            Me.Invoke(Sub() Me.ListBox3.Items.Add("Deconnexion d'un client"))
        End If
    End Sub
End Class
