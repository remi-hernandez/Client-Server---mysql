Public Class ThServer
    Public Parser As New Parser
    Private _form As MainForm
    Private _error As String
    Private _idListBox As Integer

    '' Getter - setter

    Public Property getSetForm As Form
        Get
            Return _form
        End Get
        Set(ByVal value As Form)
            _form = value
        End Set
    End Property

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
        _form = Form
    End Sub

    '' Méthodes

    Public Sub pushError(ByVal errorValue As String)
        _error = errorValue
        Console.WriteLine(errorValue)
    End Sub

    Public Sub deconnexion()
        G_IdListBox(_idListBox) = 0
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
        If tmp = 0 And i < 16 Then
            _idListBox = i
            G_IdListBox(i - 1) = 1
            _error = "DEBUG [IdListBox] : " + _idListBox.ToString()
        End If
    End Sub

    Public Sub PrintText(ByVal str As String)
        Dim id As Integer = _idListBox

        Select Case id
            Case 1
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

    Public Sub ChangeColor(ByVal color As String)
        Dim id As Integer = _idListBox
        Dim Col As System.Drawing.Color

        If color = "connection" Then
            Col = Drawing.Color.SeaShell
        ElseIf color = "introCarte" Then
            Col = Drawing.Color.PowderBlue
        ElseIf color = "Achat" Then
            Col = Drawing.Color.Khaki
        ElseIf color = "Retrait" Then
            Col = Drawing.Color.Tan
        ElseIf color = "demandeInfos" Then
            Col = Drawing.Color.SandyBrown
        ElseIf color = "RetraitCarte" Then
            Col = Drawing.Color.Gray
        End If

        Select Case id
            Case 1
                _form.Invoke(Sub() _form.ListBox1.BackColor = Col)
            Case 2
                _form.Invoke(Sub() _form.ListBox2.BackColor = Col)
            Case 3
                _form.Invoke(Sub() _form.ListBox3.BackColor = Col)
            Case 4
                _form.Invoke(Sub() _form.ListBox4.BackColor = Col)
            Case 5
                _form.Invoke(Sub() _form.ListBox5.BackColor = Col)
            Case 6
                _form.Invoke(Sub() _form.ListBox6.BackColor = Col)
            Case 7
                _form.Invoke(Sub() _form.ListBox7.BackColor = Col)
            Case 8
                _form.Invoke(Sub() _form.ListBox8.BackColor = Col)
            Case 9
                _form.Invoke(Sub() _form.ListBox9.BackColor = Col)
            Case 10
                _form.Invoke(Sub() _form.ListBox10.BackColor = Col)
            Case 11
                _form.Invoke(Sub() _form.ListBox11.BackColor = Col)
            Case 12
                _form.Invoke(Sub() _form.ListBox12.BackColor = Col)
            Case 13
                _form.Invoke(Sub() _form.ListBox13.BackColor = Col)
            Case 14
                _form.Invoke(Sub() _form.ListBox14.BackColor = Col)
            Case 15
                _form.Invoke(Sub() _form.ListBox15.BackColor = Col)
            Case 16
                _form.Invoke(Sub() _form.ListBox16.BackColor = Col)
        End Select
    End Sub
End Class