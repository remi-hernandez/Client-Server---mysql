Imports System.Net
Imports System.Net.Sockets

Public Class SocketServeur

    Public _form As MainForm
    Public Event ClientAccepteOrDeco(ByVal sender As Object, ByVal e As EventArgs) 'Evenement au moment de la connexion ou Deco d'un client
    Public Event ClientMessage(ByVal sender As Object, ByVal Msg As String, ByVal e As EventArgs) 'Evenement au moment de la reception d'un message d'un client
    Private veilleur = New System.Threading.Thread(AddressOf Veille) 'Premier thread qui servira à veiller puis accepter les clients

    Private socketServeur As New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp) 'l'Objet Socket du serveur
    Public myIEP As New IPEndPoint(IPAddress.Parse("127.0.0.1"), "10000")
    Private rBuf() As Byte = New Byte(1024) {}

    Enum Etats
        Running
        Close
    End Enum

    Private _nombreClients As Integer
    ReadOnly Property nombreClients() As String
        Get
            nombreClients = _nombreClients
        End Get
    End Property

    Private _etatServeur As Etats
    ReadOnly Property etatServeur() As Etats
        Get
            etatServeur = _etatServeur
        End Get
    End Property

    Sub New()
        _nombreClients = 0
    End Sub

    Public Sub MiseAZeroIdListBox()
        Dim i As Integer

        i = 0
        While i < 16
            G_IdListBox(i) = 0
            i = i + 1
        End While
    End Sub

    Sub RunServeur() 'Notre méthode de lancement du serveur
        Try
            'On ouvre l'écoute sur le port 10000, IP 127.0.0.1 (voir myIEP)
            socketServeur.Bind(myIEP)
            socketServeur.Listen(1)
            _etatServeur = Etats.Running
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        veilleur.IsBackground = True
        veilleur.Start() 'On lance le veilleur, c'est lui qui acceptera les connexions
    End Sub

    Sub StopServeur()
        'Arret du serveur
        veilleur.Abort()
        socketServeur.Close()
        _etatServeur = Etats.Close
    End Sub

    'Fonction asynchrone (Thread) permettant de connecter un client
    Private Sub ConnectionAcceptCallback(ByVal asyncResult As IAsyncResult)
        Dim struct As New StructDataThread
        Dim socketClient As Socket
        Dim thServer As New ThServer(_form, "setId")
        Dim myEventsArgs As New MyEventArgs

        socketClient = socketServeur.EndAccept(asyncResult)
        struct.thServer = thServer
        struct.SocketClient = socketClient
        _nombreClients += 1
        myEventsArgs.MyArgs = "+"
        RaiseEvent ClientAccepteOrDeco(socketClient, myEventsArgs) 'On raise l'évenement "ClientAccepteOrDeco", dans le formulaire voir le traitement associé
        socketClient.BeginReceive(rBuf, 0, rBuf.Length, SocketFlags.None, AddressOf ReceptionDoneeClient, struct) 'toujours en asynchrone, la fonction "ReceptionDoneeClient" traitera la réception des données
    End Sub

    Private Sub ReceptionDoneeClient(ByVal asyncResult As IAsyncResult)
        'Dim socketClient As Socket = CType(asyncResult.AsyncState, Socket)
        Dim struct As StructDataThread = CType(asyncResult.AsyncState, StructDataThread)
        Try
            Dim Read As Integer = struct.SocketClient.EndReceive(asyncResult)
            struct.thServer.getSetForm = _form
            If Read > 0 Then

                '' Test

                ' _form.Invoke(Sub() _form.ListBoxError.Items.Add("THIS IS THE ID" + thServer.getIdListBox().ToString()))
                Dim msg = System.Text.Encoding.Default.GetString(rBuf, 0, Read)
                '
                ' _form.Invoke(Sub() _form.ListBoxError.Items.Add("DEBUG [recptdataclient]"))
                ' MessageBox.Show("Rouble")
                '

                struct.thServer.Parser.Parse(msg)
                MessageBox.Show(struct.thServer.Parser.getSetMsgReturn)
                struct.thServer.PrintText(msg)
                MessageBox.Show("tentative de print sur interface")
                '' Test

                RaiseEvent ClientMessage(struct.SocketClient, msg, EventArgs.Empty) 'On raise l'évenement "ClientMessage", pour permettre à l'interface d'afficher les messages

                MessageBox.Show("CLIENT MESSAGE ")
                '/// ICI, TRAITEMENT PARTICULIER EN FONCTION DES DONNEES (appel à la bdd par exemple) ///
                ' RaiseEvent ClientMessage(socketClient, System.Text.Encoding.Default.GetString(rBuf, 0, Read), EventArgs.Empty) 'On raise l'évenement "ClientMessage", pour permettre à l'interface d'afficher les messages

                struct.SocketClient.BeginReceive(rBuf, 0, rBuf.Length, SocketFlags.None, AddressOf ReceptionDoneeClient, struct) 'On rappel en asynchrone la même fonction (elle-même), de cette façon via des threads, nous sommes toujours à l'écoute de potentiels envois des clients
                MessageBox.Show("Begin Receive")
                'SocketClient.BeginReceive(rBuf, 0, rBuf.Length, SocketFlags.None, AddressOf ReceptionDoneeClient, SocketClient) 'On rappel en asynchrone la même fonction (elle-même), de cette façon via des threads, nous sommes toujours à l'écoute de potentiels envois des clients
            ElseIf Read = 0 Then
                _nombreClients -= 1
                Dim myEventsArgs As New MyEventArgs
                myEventsArgs.MyArgs = "-"
                RaiseEvent ClientAccepteOrDeco(struct.SocketClient, myEventsArgs) 'On raise l'évenement "ClientAccepteOrDeco", dans le formulaire voir le traitement associé
            End If
        Catch ex As ObjectDisposedException
            MessageBox.Show("Client déconnecté !")
        Catch ex As SocketException
            MessageBox.Show("SocketException")
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub Veille()
        'On boucle tant que l'état du serveur est "running"
        While (Me.etatServeur = Etats.Running)
            Dim listListen As New ArrayList()
            Dim struct As New StructDataThread

            listListen.Add(socketServeur)
            Socket.Select(listListen, Nothing, Nothing, 1000) 'Cette fonction traite la liste "listListen", s'il reste un socket dans la liste, c'est qu'un client cherche à se connecter
            For i = 0 To listListen.Count - 1
                If listListen.Contains(socketServeur) Then
                    socketServeur.BeginAccept(AddressOf ConnectionAcceptCallback, socketServeur) 'Acception du client de façon Asynchrone, c'est donc un Thread qui traite cela via la fonction "ConnectionAcceptCallback"
                    'Dim socketClient = socketServeur.Accept() 'Pour exemple, la méthode Accepte() aurait accepté le client, mais de facon synchrone, donc la fonction aurait figé l'interface jusqu'à la connexion du client
                End If
            Next
        End While
    End Sub

    Private Sub ReceptionDonneeClient()
        Throw New NotImplementedException
    End Sub

    Public Sub CheckThServerId(ByVal CpfSiteCaisse As String)
        Dim cpt As Integer

        cpt = 0
        ' While (G_TabIdThServer[cpt] != CpfSiteCaisse )
        'End While


    End Sub

End Class

Public Class MyEventArgs
    Inherits EventArgs
    Public Property MyArgs As String
End Class