Imports System.Net
Imports System.Net.Sockets

Public Class Form1
    Dim IndexClient As Integer = 0
    Dim tabSocketClient(4) As Socket 'Définition d'un tableau pour contenir les différents sockets clients

    Private Sub Button_Click(sender As Object, e As EventArgs) Handles Button1.Click, Button2.Click, Button3.Click, Button4.Click

        Select Case sender.name
            Case "Button1"
                IndexClient = 1
            Case "Button2"
                IndexClient = 2
            Case "Button3"
                IndexClient = 3
            Case "Button4"
                IndexClient = 4
        End Select

        If IsNothing(tabSocketClient(IndexClient)) Then
            'Initialisation du socket s'il est null
            tabSocketClient(IndexClient) = New Socket(Sockets.AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
        End If

        'On reprend la trame exemple VB6
        Dim codeconnect = "oxal"
        Dim s_site = 12
        Dim s_caisse = 40 + IndexClient
        Dim s_nom = "Connection " & IndexClient
        Dim FTR = Chr(253)
        Dim SP = "¤"   'trame
        Dim SP1 = "|"  'enregistrement
        Dim SP2 = "¦"  'champ
        Dim SP3 = "§"  'champ
        Dim Msg As String = 0 & SP & s_site & SP & s_nom & SP & s_caisse & SP & codeconnect & SP & Dns.GetHostName() & SP & Application.ProductVersion.ToString() & SP & Process.GetCurrentProcess.ProcessName & " - " & IndexClient & FTR
        'Dim Msg As String = " chocolat " & SP + "fraise" & SP & FTR


        If Not tabSocketClient(IndexClient).Connected Then 'On est pas encore connecté
            Try
                tabSocketClient(IndexClient).Connect("127.0.0.1", 10000) 'Connexion sur l'ip 127.0.0.1, port 10000, pour l'exemple
                Me.Controls("Button" & IndexClient).Text = "Message " & IndexClient
                tabSocketClient(IndexClient).Send(System.Text.Encoding.Default.GetBytes(Msg)) 'l'envoi du message
            Catch ex As SocketException
                MessageBox.Show("SocketException")
            Catch ex As Exception
                MessageBox.Show("Exception")
            End Try
        ElseIf tabSocketClient(IndexClient).Connected Then 'On est déjà connecté
            tabSocketClient(IndexClient).Send(System.Text.Encoding.Default.GetBytes(Msg)) 'l'envoi du message
        End If

    End Sub

    Private Sub ButtonClose_Click(sender As Object, e As EventArgs) Handles Button5.Click, Button6.Click, Button7.Click, Button8.Click
        Select Case sender.name
            Case "Button5"
                IndexClient = 1
            Case "Button6"
                IndexClient = 2
            Case "Button7"
                IndexClient = 3
            Case "Button8"
                IndexClient = 4
        End Select

        Me.Controls("Button" & IndexClient).Text = "Connexion " & IndexClient

        Try
            'Simple déconnexion du client
            tabSocketClient(IndexClient).Close()
            tabSocketClient(IndexClient) = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
End Class
