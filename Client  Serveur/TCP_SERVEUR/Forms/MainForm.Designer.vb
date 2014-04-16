<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ListBoxDetails = New System.Windows.Forms.ListBox()
        Me.LabelStatus = New System.Windows.Forms.Label()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.ButtonServeur = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.ListBox3 = New System.Windows.Forms.ListBox()
        Me.ListBox4 = New System.Windows.Forms.ListBox()
        Me.ListBox5 = New System.Windows.Forms.ListBox()
        Me.ListBox6 = New System.Windows.Forms.ListBox()
        Me.ListBox7 = New System.Windows.Forms.ListBox()
        Me.ListBox8 = New System.Windows.Forms.ListBox()
        Me.ListBox9 = New System.Windows.Forms.ListBox()
        Me.ListBox10 = New System.Windows.Forms.ListBox()
        Me.ListBox11 = New System.Windows.Forms.ListBox()
        Me.ListBox12 = New System.Windows.Forms.ListBox()
        Me.ListBox13 = New System.Windows.Forms.ListBox()
        Me.ListBox14 = New System.Windows.Forms.ListBox()
        Me.ListBox15 = New System.Windows.Forms.ListBox()
        Me.ListBox16 = New System.Windows.Forms.ListBox()
        Me.ListBoxError = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'ListBoxDetails
        '
        Me.ListBoxDetails.BackColor = System.Drawing.Color.LightGreen
        Me.ListBoxDetails.FormattingEnabled = True
        Me.ListBoxDetails.Location = New System.Drawing.Point(12, 58)
        Me.ListBoxDetails.Name = "ListBoxDetails"
        Me.ListBoxDetails.Size = New System.Drawing.Size(194, 576)
        Me.ListBoxDetails.TabIndex = 4
        '
        'LabelStatus
        '
        Me.LabelStatus.AutoSize = True
        Me.LabelStatus.Location = New System.Drawing.Point(12, 832)
        Me.LabelStatus.Name = "LabelStatus"
        Me.LabelStatus.Size = New System.Drawing.Size(154, 13)
        Me.LabelStatus.TabIndex = 6
        Me.LabelStatus.Text = "Statut du serveur : déconnecté"
        '
        'ListBox1
        '
        Me.ListBox1.BackColor = System.Drawing.SystemColors.Window
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(212, 58)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(299, 186)
        Me.ListBox1.TabIndex = 8
        '
        'ButtonServeur
        '
        Me.ButtonServeur.Location = New System.Drawing.Point(12, 21)
        Me.ButtonServeur.Name = "ButtonServeur"
        Me.ButtonServeur.Size = New System.Drawing.Size(131, 21)
        Me.ButtonServeur.TabIndex = 31
        Me.ButtonServeur.Text = "Lancer le Serveur"
        Me.ButtonServeur.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(164, 21)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(103, 21)
        Me.ProgressBar1.TabIndex = 32
        '
        'ListBox2
        '
        Me.ListBox2.BackColor = System.Drawing.SystemColors.Window
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.Location = New System.Drawing.Point(517, 58)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(299, 186)
        Me.ListBox2.TabIndex = 33
        '
        'ListBox3
        '
        Me.ListBox3.BackColor = System.Drawing.SystemColors.Window
        Me.ListBox3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ListBox3.FormattingEnabled = True
        Me.ListBox3.Location = New System.Drawing.Point(822, 58)
        Me.ListBox3.Name = "ListBox3"
        Me.ListBox3.Size = New System.Drawing.Size(299, 186)
        Me.ListBox3.TabIndex = 34
        '
        'ListBox4
        '
        Me.ListBox4.FormattingEnabled = True
        Me.ListBox4.Location = New System.Drawing.Point(1127, 58)
        Me.ListBox4.Name = "ListBox4"
        Me.ListBox4.Size = New System.Drawing.Size(299, 186)
        Me.ListBox4.TabIndex = 35
        '
        'ListBox5
        '
        Me.ListBox5.BackColor = System.Drawing.SystemColors.Window
        Me.ListBox5.FormattingEnabled = True
        Me.ListBox5.Location = New System.Drawing.Point(212, 250)
        Me.ListBox5.Name = "ListBox5"
        Me.ListBox5.Size = New System.Drawing.Size(299, 186)
        Me.ListBox5.TabIndex = 36
        '
        'ListBox6
        '
        Me.ListBox6.FormattingEnabled = True
        Me.ListBox6.Location = New System.Drawing.Point(517, 250)
        Me.ListBox6.Name = "ListBox6"
        Me.ListBox6.Size = New System.Drawing.Size(299, 186)
        Me.ListBox6.TabIndex = 37
        '
        'ListBox7
        '
        Me.ListBox7.FormattingEnabled = True
        Me.ListBox7.Location = New System.Drawing.Point(822, 250)
        Me.ListBox7.Name = "ListBox7"
        Me.ListBox7.Size = New System.Drawing.Size(299, 186)
        Me.ListBox7.TabIndex = 38
        '
        'ListBox8
        '
        Me.ListBox8.FormattingEnabled = True
        Me.ListBox8.Location = New System.Drawing.Point(1127, 250)
        Me.ListBox8.Name = "ListBox8"
        Me.ListBox8.Size = New System.Drawing.Size(299, 186)
        Me.ListBox8.TabIndex = 39
        '
        'ListBox9
        '
        Me.ListBox9.FormattingEnabled = True
        Me.ListBox9.Location = New System.Drawing.Point(212, 442)
        Me.ListBox9.Name = "ListBox9"
        Me.ListBox9.Size = New System.Drawing.Size(299, 186)
        Me.ListBox9.TabIndex = 40
        '
        'ListBox10
        '
        Me.ListBox10.FormattingEnabled = True
        Me.ListBox10.Location = New System.Drawing.Point(517, 442)
        Me.ListBox10.Name = "ListBox10"
        Me.ListBox10.Size = New System.Drawing.Size(299, 186)
        Me.ListBox10.TabIndex = 41
        '
        'ListBox11
        '
        Me.ListBox11.FormattingEnabled = True
        Me.ListBox11.Location = New System.Drawing.Point(822, 442)
        Me.ListBox11.Name = "ListBox11"
        Me.ListBox11.Size = New System.Drawing.Size(299, 186)
        Me.ListBox11.TabIndex = 42
        '
        'ListBox12
        '
        Me.ListBox12.FormattingEnabled = True
        Me.ListBox12.Location = New System.Drawing.Point(1127, 442)
        Me.ListBox12.Name = "ListBox12"
        Me.ListBox12.Size = New System.Drawing.Size(299, 186)
        Me.ListBox12.TabIndex = 43
        '
        'ListBox13
        '
        Me.ListBox13.FormattingEnabled = True
        Me.ListBox13.Location = New System.Drawing.Point(212, 634)
        Me.ListBox13.Name = "ListBox13"
        Me.ListBox13.Size = New System.Drawing.Size(299, 186)
        Me.ListBox13.TabIndex = 44
        '
        'ListBox14
        '
        Me.ListBox14.FormattingEnabled = True
        Me.ListBox14.Location = New System.Drawing.Point(517, 634)
        Me.ListBox14.Name = "ListBox14"
        Me.ListBox14.Size = New System.Drawing.Size(299, 186)
        Me.ListBox14.TabIndex = 45
        '
        'ListBox15
        '
        Me.ListBox15.FormattingEnabled = True
        Me.ListBox15.Location = New System.Drawing.Point(822, 634)
        Me.ListBox15.Name = "ListBox15"
        Me.ListBox15.Size = New System.Drawing.Size(299, 186)
        Me.ListBox15.TabIndex = 46
        '
        'ListBox16
        '
        Me.ListBox16.FormattingEnabled = True
        Me.ListBox16.Location = New System.Drawing.Point(1127, 634)
        Me.ListBox16.Name = "ListBox16"
        Me.ListBox16.Size = New System.Drawing.Size(299, 186)
        Me.ListBox16.TabIndex = 47
        '
        'ListBoxError
        '
        Me.ListBoxError.BackColor = System.Drawing.Color.Tomato
        Me.ListBoxError.FormattingEnabled = True
        Me.ListBoxError.Location = New System.Drawing.Point(12, 639)
        Me.ListBoxError.Name = "ListBoxError"
        Me.ListBoxError.Size = New System.Drawing.Size(194, 186)
        Me.ListBoxError.TabIndex = 48
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1444, 850)
        Me.Controls.Add(Me.ListBoxError)
        Me.Controls.Add(Me.ListBox16)
        Me.Controls.Add(Me.ListBox15)
        Me.Controls.Add(Me.ListBox14)
        Me.Controls.Add(Me.ListBox13)
        Me.Controls.Add(Me.ListBox12)
        Me.Controls.Add(Me.ListBox11)
        Me.Controls.Add(Me.ListBox10)
        Me.Controls.Add(Me.ListBox9)
        Me.Controls.Add(Me.ListBox8)
        Me.Controls.Add(Me.ListBox7)
        Me.Controls.Add(Me.ListBox6)
        Me.Controls.Add(Me.ListBox5)
        Me.Controls.Add(Me.ListBox4)
        Me.Controls.Add(Me.ListBox3)
        Me.Controls.Add(Me.ListBox2)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.ButtonServeur)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.LabelStatus)
        Me.Controls.Add(Me.ListBoxDetails)
        Me.Name = "MainForm"
        Me.Text = "Form2"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ListBoxDetails As System.Windows.Forms.ListBox
    Friend WithEvents LabelStatus As System.Windows.Forms.Label
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents ButtonServeur As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents ListBox2 As System.Windows.Forms.ListBox
    Friend WithEvents ListBox3 As System.Windows.Forms.ListBox
    Friend WithEvents ListBox4 As System.Windows.Forms.ListBox
    Friend WithEvents ListBox5 As System.Windows.Forms.ListBox
    Friend WithEvents ListBox6 As System.Windows.Forms.ListBox
    Friend WithEvents ListBox7 As System.Windows.Forms.ListBox
    Friend WithEvents ListBox8 As System.Windows.Forms.ListBox
    Friend WithEvents ListBox9 As System.Windows.Forms.ListBox
    Friend WithEvents ListBox10 As System.Windows.Forms.ListBox
    Friend WithEvents ListBox11 As System.Windows.Forms.ListBox
    Friend WithEvents ListBox12 As System.Windows.Forms.ListBox
    Friend WithEvents ListBox13 As System.Windows.Forms.ListBox
    Friend WithEvents ListBox14 As System.Windows.Forms.ListBox
    Friend WithEvents ListBox15 As System.Windows.Forms.ListBox
    Friend WithEvents ListBox16 As System.Windows.Forms.ListBox
    Friend WithEvents ListBoxError As System.Windows.Forms.ListBox
End Class
