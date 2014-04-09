

##Serveur##

____

##
##	Résume Form1.vb
##

'démarrage du Serveur
If ButtonServeur.Text = "Lancer le Serveur" ': signifie que l'utilisateur lance le serveur en appuyant sur le boutton
	On initialise notre classe &SocketServeur
	On appelle Serveur.RunServeur() pour démarrer le serveur
	Ajout du texte pour informer de l'ip et du port sur lequel on écoute
	on ajoute la progressbar (pour montrer que le serveur tourne)
	Modification du texte du boutton -> "Arreter le serveur"
	Ajout du texte en bas de fenetre permettant de savoir l'ip et le port sur lequel le serveur écoute et le nombre de connexions clients
	et mise en place de deux events :
		AddHandler Serveur.ClientAccepteOrDeco, AddressOf MiseAJourBarreStatut 'Evénement appelé quand un client vient de se connecter
        AddHandler Serveur.ClientMessage, AddressOf MiseAJourMsgClient 'Evénement appelé quand un message est reçus par un client

'arret du Serveur
	Appel a la méthode d'arret : Serveur.StopServeur()
	ajout du message d'état du serveur : Arret Serveur
	modification de la barre pour montrer visuellement que le serveur s'arrete
	modification du texte du boutton : ButtonServeur.Text ="Lancer le Serveur"

'modifications supplémentaires de l'interface
	Ajout du texte en bas de fenetre permettant de connaitre l'ip et le port sur lequel le serveur et connecté et le nombre de connexions clients
	Ajout dans la zone texte d'une connexion ou d'une déconnexion d'un client avec son ip et son port

'mise a jour des messages client
	Création d'une socket permettant de recevoir le message
	on affiche le message du client précédé de son ip et de son port :
		Me.Invoke(Sub() Me.ListBox2.Items.Add("Message de " & SocketClient.RemoteEndPoint.ToString() & " : " & Msg))

	'pas sur
	est appellé dans un autre thread et invoke permet de faire des actions dans le thread principal
	
'Gestion réception différents messages
ConnectionAcceptCallback()'fonction permettant de connecter un client (thread) 
	ReceptionDoneeClient
		read > 0 
			RaiseEvent ClientMessage()
				MiseAJourMsgClient()
					Affiche les infos clients (&IndexClient, )
					Affiche le message
				

mettre un message comme quoi data send
serveur envoie la réponse
____

##
## 	Résumé traitement.vb
##

RunServeur() ': permet de lancer le serveur
Stopserveur() ': arrete le serveur

ConnectionAcceptCallBack(asyncResult As IAsincResult) ': Fonction asynchrine (thread) permettant de connecter un client 
	socketClient = socketServeur.EndAccept(asyncResult) ': accepte

ReceptionDoneeClient(asyncresult As IAsyncResult) ': permet de recevoir les donnees du client

RaiseEvent ClientMessage(socketClient, System.Text.Encoding.Default.GetString(rBuf, 0, Read), EventArgs.Empty) ': raise l'évenement "ClientMessage", pour permettre à l'interface d'afficher les messages
RaiseEvent ClientAccepteOrDeco(socketClient, myEventsArgs) ': Event gérant l'accept de connexion ou la déconnexion


veilleur ': celui qui accepte les connexions

Veille() ': Boucle tant que l'état du serveur est "running"
	Socket.Select(listListen, Nothing, Nothing, 1000) ': traite &listListen dans le cas ou il reste un socket
	socketServeur.BeginAccept(AddressOf ConnectionAcceptCallback, socketServeur) ': accepte le serveur sur un thread


listListen ': liste des sockets de clients qui cherchent a se connecter
myEventsArgs.MyArgs = "+" ou = "-" ': chaine pour connaitre les dernières déco ou co ?

Serveur.myIEP.Address() ': contient l'ip
Serveur.myIEP.Host() ': contient le port
_____

Le &veilleur tourne en boucle tant que le &serveur est "running", il vérifie toujours la &listListen afin de laccepter 
via un thread en utilisant la fonction &ConnectionAcceptCallback.
