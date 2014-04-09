Imports System.Net.Sockets

Module Gestion
    Public li() As String
    Public SocketClient As Socket

    'On reprend la trame exemple VB6
    Public codeconnect = "oxal"
    Public s_site = 12
    Public SP = "¤"   'trame
    Public SP1 = "|"  'enregistrement
    Public SP2 = "¦"  'champ
    Public SP3 = "§"  'champ
    Public FTR = Chr(253)

    Sub Initialisation()
        With Form1
            Dim MSG As String

            '.Invoke(Sub() .ListBox3.Items.Add("Connection Ititialisation"))
            'rechercher qui c'est avec le code d'acces
            '.Invoke(Sub() .ListBox3.Items.Add("Code d'accès" & li(1)))

            MSG = "12¤1¤Bingo" & FTR
            Try
                SocketClient.Send(System.Text.Encoding.Default.GetBytes(MSG)) 'l'envoi du message
                MessageBox.Show("message envoyé : " & MSG)
            Catch ex As SocketException
                MessageBox.Show("SocketException ligne : " & Erl())
            Catch ex As Exception
                MessageBox.Show("Exception ligne : " & " " & ex.Message)
            End Try
        End With
    End Sub
End Module
