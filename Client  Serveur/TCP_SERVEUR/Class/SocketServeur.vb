﻿Imports System.Net
Imports System.Net.Sockets

Public Class SocketServeur
  
    Public _form As MainForm
    Public Event ClientAccepteOrDeco(ByVal sender As Object, ByVal e As EventArgs)
    Public Event ClientMessage(ByVal sender As Object, ByVal Msg As String, ByVal e As EventArgs)
    Private veilleur = New System.Threading.Thread(AddressOf Veille)
    Private socketServeur As New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
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

    '' Méthode de lancement du serveur
    '' On ouvre l'écoute sur le port 10000, IP 127.0.0.1 (voir myIEP)
    '' On lance le veilleur, c'est lui qui acceptera les connexions
    Sub RunServeur()
        Try

            socketServeur.Bind(myIEP)
            socketServeur.Listen(1)
            _etatServeur = Etats.Running
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        veilleur.IsBackground = True
        veilleur.Start()
    End Sub

    '' Arret du serveur
    '' On ferme toutes les connections
    '' On change l'état du serveur
    Sub StopServeur()
        veilleur.Abort()
        socketServeur.Close()
        _etatServeur = Etats.Close
    End Sub

    '' C'est ici que l'on déclare la structure StructDataThread qui contiendra les données du client dans le thread
    '' Fonction asynchrone (Thread) permettant de connecter un client
    '' Toujours en asynchrone, la fonction "ReceptionDoneeClient" traitera la réception des données et on lui donne la structure
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
        RaiseEvent ClientAccepteOrDeco(socketClient, myEventsArgs)
        socketClient.BeginReceive(rBuf, 0, rBuf.Length, SocketFlags.None, AddressOf ReceptionDoneeClient, struct)
    End Sub

    '' On utilise une structure StructDataThread qui vas contenir un objet thserver pour avoir acces aux id a la classe pour la gestion de la BDD et tout ca
    '' On rappel en asynchrone la même fonction (elle-même), de cette façon via des threads, nous sommes toujours à l'écoute de potentiels envois des clients
    Private Sub ReceptionDoneeClient(ByVal asyncResult As IAsyncResult)
        Dim struct As StructDataThread = CType(asyncResult.AsyncState, StructDataThread)
        struct.thServer.getSetForm = _form
        Try
            Dim Read As Integer = struct.SocketClient.EndReceive(asyncResult)
            If Read > 0 Then
                Dim msg = System.Text.Encoding.Default.GetString(rBuf, 0, Read)
                struct.thServer.Parser.Parse(msg)
                struct.thServer.PrintText(msg)
                RaiseEvent ClientMessage(struct, msg, EventArgs.Empty)
                struct.SocketClient.BeginReceive(rBuf, 0, rBuf.Length, SocketFlags.None, AddressOf ReceptionDoneeClient, struct)
            ElseIf Read = 0 Then
                Dim myEventsArgs As New MyEventArgs
                _nombreClients -= 1
                myEventsArgs.MyArgs = "-"
                RaiseEvent ClientAccepteOrDeco(struct.SocketClient, myEventsArgs)
            End If
        Catch ex As ObjectDisposedException
            MessageBox.Show("Client déconnecté !")
        Catch ex As SocketException
            MessageBox.Show("SocketException")
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    '' On boucle tant que l'état du serveur est "running"
    '' select traite la liste "listListen", s'il reste un socket dans la liste, c'est qu'un client cherche à se connecter
    '' Acception du client de façon Asynchrone, c'est donc un Thread qui traite cela via la fonction "ConnectionAcceptCallback"
    Private Sub Veille()
        While (Me.etatServeur = Etats.Running)
            Dim listListen As New ArrayList()
            Dim struct As New StructDataThread

            listListen.Add(socketServeur)
            Socket.Select(listListen, Nothing, Nothing, 1000)
            For i = 0 To listListen.Count - 1
                If listListen.Contains(socketServeur) Then
                    socketServeur.BeginAccept(AddressOf ConnectionAcceptCallback, socketServeur)
                End If
            Next
        End While
    End Sub

    Private Sub ReceptionDonneeClient()
        Throw New NotImplementedException
    End Sub
End Class

Public Class MyEventArgs
    Inherits EventArgs
    Public Property MyArgs As String
End Class