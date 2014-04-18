Public Class Parser
    Private Bdd As New BDD
    Private _chain As String
    Private _chainLi As String()
    Private _msgReturn As String
    Private _sqlRequete As String

    '' Getter - Setter

    Public Property getSetChain() As String
        Get
            Return _chain
        End Get
        Set(ByVal value As String)
            _chain = value
        End Set
    End Property

    Public Property getSetMsgReturn() As String
        Get
            Return _msgReturn
        End Get
        Set(ByVal value As String)
            _msgReturn = value
        End Set
    End Property

    '' Méthodes

    Private Sub Connexion()

    End Sub

    Public Sub Parse(ByVal chain As String)
        Dim LI() As String = Split(chain, G_SP1)

        _chain = chain
        _chainLi = LI

        If LI(1) = "1" Then
            Connexion()
        End If
        _msgReturn = "DEBUG [Parsing] : " & chain
        Console.WriteLine("DEBUG [Parsing] : " & chain)
    End Sub
End Class
