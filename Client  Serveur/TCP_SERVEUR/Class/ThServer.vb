Public Class ThServer
    Public Bdd As New BDD
    Public Parser As New Parser
    Private _form As MainForm
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

    '' Constructeur

    Public Sub New(ByVal form As MainForm, ByVal flag As String)
        If flag = "setId" Then
            form.Invoke(Sub() form.ListBoxError.Items.Add("DEBUG [Constructor id]"))
            selectIdListBox()
        End If
        _form = form
    End Sub

    '' Methodes

    Public Sub pushError(ByVal errorValue As String)
        _error = errorValue
        Console.WriteLine(errorValue)
    End Sub

    Private Sub selectIdListBox()
        Dim i As New Integer
        Dim tmp As New Integer

        i = 0
        tmp = 1
        While i < 16 And tmp = 1
            tmp = G_IdListBox(i)
            i += 1
        End While
        _form.Invoke(Sub() _form.ListBoxError.Items.Add("DEBUG [wtf id] id : " + i.ToString()))
        If tmp = 0 And i < 16 Then
            _idListBox = i
            G_IdListBox(i - 1) = 1
            _error = "DEBUG [IdListBox] : " + _idListBox.ToString()
        End If
    End Sub

    Public Sub PrintText(ByVal str As String)
        Dim id As Integer = _idListBox
        'MessageBox.Show("id : " + id.ToString() + " string : " + str)
        Select Case id
            Case 1
                ' MainForm.ListBox1.Items.Add(str)
                _form.Invoke(Sub() _form.ListBox1.Items.Add(str))
            Case 2
                _form.Invoke(Sub() _form.ListBox2.Items.Add(str))
            Case 3
                _form.Invoke(Sub() _form.ListBox3.Items.Add(str))
            Case 4
                _form.Invoke(Sub() _form.ListBox4.Items.Add(str))
            Case 5
                _form.Invoke(Sub() _form.ListBox5.Items.Add(str))
            Case 6
                _form.Invoke(Sub() _form.ListBox6.Items.Add(str))
            Case 7
                _form.Invoke(Sub() _form.ListBox7.Items.Add(str))
            Case 8
                _form.Invoke(Sub() _form.ListBox8.Items.Add(str))
            Case 9
                _form.Invoke(Sub() _form.ListBox9.Items.Add(str))
            Case 10
                _form.Invoke(Sub() _form.ListBox10.Items.Add(str))
            Case 11
                _form.Invoke(Sub() _form.ListBox11.Items.Add(str))
            Case 12
                _form.Invoke(Sub() _form.ListBox12.Items.Add(str))
            Case 13
                _form.Invoke(Sub() _form.ListBox13.Items.Add(str))
            Case 14
                _form.Invoke(Sub() _form.ListBox14.Items.Add(str))
            Case 15
                _form.Invoke(Sub() _form.ListBox15.Items.Add(str))
            Case 16
                _form.Invoke(Sub() _form.ListBox16.Items.Add(str))
        End Select
    End Sub
End Class