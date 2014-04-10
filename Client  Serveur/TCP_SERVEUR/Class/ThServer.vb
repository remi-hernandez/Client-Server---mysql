Public Class ThServer
    Public Bdd As New BDD
    Public Parser As New Parser
    Private _error As String
    Private _idListBox As Integer

    '' Getter - setter

    Public Property getSetError() As String
        Get
            Return _error
        End Get
        Set(ByVal value As String)
            _error = value
        End Set
    End Property

    Public Property getIdListBox() As Integer
        Get
            Return _idListBox
        End Get
        Set(ByVal value As Integer)

        End Set
    End Property

    '' Methodes

    Public Sub pushError(ByVal errorValue As String)
        _error = errorValue
        Console.WriteLine(errorValue)
    End Sub

    Public Sub selectIdListBox()
        Dim i As New Integer
        Dim tmp As New Integer

        i = 0
        tmp = 1
        While i < 16 And tmp = 1
            tmp = G_IdListBox(i)
            i += 1
        End While
        If tmp = 0 And i < 16 Then
            _idListBox = i
            G_IdListBox(i - 1) = 1
            _error = "DEBUG [IdListBox] : " + _idListBox.ToString()
        End If
    End Sub
End Class