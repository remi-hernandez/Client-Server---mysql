Imports System.Net.Sockets

Module Thread
    ' 'Sert a afficher les messages du client précédé de son IP et du Port -> dans un thread
    ' Sub MiseAJourMsgClient(ByVal sender As Object, ByVal Msg As String, ByVal e As EventArgs)
    '     Dim thServer As New ThServer
    '     Dim SocketClient As Socket = CType(sender, Socket)
    '     MainForm.Invoke(Sub() MainForm.ListBoxDetails.Items.Add("Message de " & SocketClient.RemoteEndPoint.ToString() & " : " & Msg))
    '
    '     'traitement de la rame à partir d'un thread différent
    '     Dim LI() As String = Split(Msg, "¤")
    '
    '     'ajout pour permettre au serveur de répondre #CODE
    '     If LI(1) = "operation" Then
    '         SocketClient.Send(System.Text.Encoding.Unicode.GetBytes("Datas received"))
    '         MainForm.Invoke(Sub() MainForm.ListBoxDetails.Items.Add("Operation d'un client"))
    '         Console.WriteLine("Socket send message for operation")
    '     End If
    '
    '     'afficher les champs
    '     'modifie les labels sur le thread principal
    '     ' Me.Invoke(Sub() Me.Label1.Text = LI(2))
    '     ' Me.Invoke(Sub() Me.Label2.Text = LI(3))
    '     ' Me.Invoke(Sub() Me.Label3.Text = LI(4))
    '     ' Me.Invoke(Sub() Me.Label4.Text = LI(5))
    '     ' Me.Invoke(Sub() Me.Label5.Text = LI(6))
    '
    '     'gérer les directions à prendre
    '
    '     If LI(1) = "connexion" Then
    '         Console.WriteLine("Connexion client")
    '         MainForm.Invoke(Sub() MainForm.ListBoxDetails.Items.Add("Connexion d'un client"))
    '     End If
    '
    '     If LI(1) = "deconnexion" Then
    '         Console.WriteLine("Déconnexion client")
    '         MainForm.Invoke(Sub() MainForm.ListBoxDetails.Items.Add("Deconnexion d'un client"))
    '     End If
    ' End Sub
End Module
