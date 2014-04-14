
##Client##

##
## Travail actuel
##

Reprise du code existant afin de faire un client pour un utilisateur permettant une connexion et un envoie de data 
pour une transaction.

-> une seule socket

##
## Résumé Form1.vb
##


Private Sub Button_Click(sender As Object, e As EventArgs) Handles Button1.Click, Button2.Click, Button3.Click, Button4.Click ': Récupere l'event des bouttons connexion//message
Private Sub ButtonClose_Click(sender As Object, e As EventArgs) Handles Button5.Click, Button6.Click, Button7.Click, Button8.Click ': Récupere l'event des bouttons déconnexion

IsNothing(tabSocketClient(IndexClient)) ': true ou false si la socket est null afin de la set
	tabSocketClient(IndexClient) = New Socket(Sockets.AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp) ': Permet de set la valeur de la socket du client correspondant a l'index

tabSocketClient(IndexClient).Connected ': true ou false si le client est connecté
tabsocketClient(IndexClient).Connect("127.0.0.1", 10000) ': connecte sur l'ip port
tabSocketClient(IndexClient).Send(System.Text.Encoding.Default.GetBytes(Msg)) ': permet d'envoyer un message

	
Me.controls -> ?
	
tabSocketClient ': tableau comportant les socket des clients (4)
IndexClient = 1 || 2 || 3 || 4 
ex.Message : message pour une exception

Dim FTR = Chr(253) -> sert comme caractère de fin ?
____

Lors d'un appui sur un boutton connexion, ou message le client est identifié via le numéro du boutton sender.name
du boutton, a ce moment on set &IndexClient. 
Puis on vérifie si la socket du client est set ou non : IsNothing(tabSocketClient(IndexClient)), si non on la set : tabSocketClient(IndexClient) = New Socket(Sockets.AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
Ensuite on vérifie si le client est connecté en utilisant &tabSocketClient(IndexClient).Connected (pour déterminer s'il s'agit d'une connexion ou d'un message)
	si non : 
				On le connecte via tabSocketClient(IndexClient).Connect(ip, port)
				et on envoie le message : tabSocketClient(IndexClient).Send(System.Text.Encoding.Default.GetBytes(Msg))
	
	si oui : 
				On envoie directement le message : tabSocketClient(IndexClient).Send(System.Text.Encoding.Default.GetBytes(Msg))

Lors d'un appui sur déconnexion le client est identifié via le numéro du boutton &sender.name	
on set &IndexClient	
on close le socket pour déconnecter le client : &tabSocketClient(IndexClient).Close()