Public Class Parser
    Private _chain As String
    Private _msgReturn As String

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

    Public Sub Parse(ByVal chain As String)
        _chain = chain
        _msgReturn = "DEBUG [Parsing] : " & chain
        Console.WriteLine("DEBUG [Parsing] : " & chain)
    End Sub
End Class
