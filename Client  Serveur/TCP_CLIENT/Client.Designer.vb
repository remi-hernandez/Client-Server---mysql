<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Client
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
        Me.BouttonConnexionDeconnexion = New System.Windows.Forms.Button()
        Me.TextBoxMontantAchat = New System.Windows.Forms.TextBox()
        Me.TextBoxPourcentRemise = New System.Windows.Forms.TextBox()
        Me.BouttonValiderOperation = New System.Windows.Forms.Button()
        Me.TextBoxMontantRetrait = New System.Windows.Forms.TextBox()
        Me.LabelInfos = New System.Windows.Forms.Label()
        Me.LabelValiderOperation = New System.Windows.Forms.Label()
        Me.ListBoxMsgServeur = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'BouttonConnexionDeconnexion
        '
        Me.BouttonConnexionDeconnexion.Location = New System.Drawing.Point(22, 22)
        Me.BouttonConnexionDeconnexion.Name = "BouttonConnexionDeconnexion"
        Me.BouttonConnexionDeconnexion.Size = New System.Drawing.Size(96, 23)
        Me.BouttonConnexionDeconnexion.TabIndex = 0
        Me.BouttonConnexionDeconnexion.Text = "Connexion"
        Me.BouttonConnexionDeconnexion.UseVisualStyleBackColor = True
        '
        'TextBoxMontantAchat
        '
        Me.TextBoxMontantAchat.Location = New System.Drawing.Point(129, 184)
        Me.TextBoxMontantAchat.Name = "TextBoxMontantAchat"
        Me.TextBoxMontantAchat.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxMontantAchat.TabIndex = 1
        Me.TextBoxMontantAchat.Text = "Montant achat"
        '
        'TextBoxPourcentRemise
        '
        Me.TextBoxPourcentRemise.Location = New System.Drawing.Point(273, 184)
        Me.TextBoxPourcentRemise.Name = "TextBoxPourcentRemise"
        Me.TextBoxPourcentRemise.Size = New System.Drawing.Size(112, 20)
        Me.TextBoxPourcentRemise.TabIndex = 2
        Me.TextBoxPourcentRemise.Text = "Pourcentage remise"
        '
        'BouttonValiderOperation
        '
        Me.BouttonValiderOperation.Location = New System.Drawing.Point(129, 266)
        Me.BouttonValiderOperation.Name = "BouttonValiderOperation"
        Me.BouttonValiderOperation.Size = New System.Drawing.Size(112, 23)
        Me.BouttonValiderOperation.TabIndex = 3
        Me.BouttonValiderOperation.Text = "Valider l'opération"
        Me.BouttonValiderOperation.UseVisualStyleBackColor = True
        '
        'TextBoxMontantRetrait
        '
        Me.TextBoxMontantRetrait.Location = New System.Drawing.Point(429, 184)
        Me.TextBoxMontantRetrait.Name = "TextBoxMontantRetrait"
        Me.TextBoxMontantRetrait.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxMontantRetrait.TabIndex = 4
        Me.TextBoxMontantRetrait.Text = "Montant retrait"
        '
        'LabelInfos
        '
        Me.LabelInfos.AutoSize = True
        Me.LabelInfos.Location = New System.Drawing.Point(168, 27)
        Me.LabelInfos.Name = "LabelInfos"
        Me.LabelInfos.Size = New System.Drawing.Size(314, 13)
        Me.LabelInfos.TabIndex = 5
        Me.LabelInfos.Text = "Veuillez vous connecter au serveur pour effectuer des opérations"
        '
        'LabelValiderOperation
        '
        Me.LabelValiderOperation.AutoSize = True
        Me.LabelValiderOperation.Location = New System.Drawing.Point(282, 271)
        Me.LabelValiderOperation.Name = "LabelValiderOperation"
        Me.LabelValiderOperation.Size = New System.Drawing.Size(163, 13)
        Me.LabelValiderOperation.TabIndex = 6
        Me.LabelValiderOperation.Text = "Operations transmises au serveur"
        '
        'ListBoxMsgServeur
        '
        Me.ListBoxMsgServeur.FormattingEnabled = True
        Me.ListBoxMsgServeur.Location = New System.Drawing.Point(129, 52)
        Me.ListBoxMsgServeur.Name = "ListBoxMsgServeur"
        Me.ListBoxMsgServeur.Size = New System.Drawing.Size(400, 108)
        Me.ListBoxMsgServeur.TabIndex = 7
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(624, 378)
        Me.Controls.Add(Me.ListBoxMsgServeur)
        Me.Controls.Add(Me.LabelValiderOperation)
        Me.Controls.Add(Me.LabelInfos)
        Me.Controls.Add(Me.TextBoxMontantRetrait)
        Me.Controls.Add(Me.BouttonValiderOperation)
        Me.Controls.Add(Me.TextBoxPourcentRemise)
        Me.Controls.Add(Me.TextBoxMontantAchat)
        Me.Controls.Add(Me.BouttonConnexionDeconnexion)
        Me.Name = "Form1"
        Me.Text = "Form_Client"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BouttonConnexionDeconnexion As System.Windows.Forms.Button
    Friend WithEvents TextBoxMontantAchat As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxPourcentRemise As System.Windows.Forms.TextBox
    Friend WithEvents BouttonValiderOperation As System.Windows.Forms.Button
    Friend WithEvents TextBoxMontantRetrait As System.Windows.Forms.TextBox
    Friend WithEvents LabelInfos As System.Windows.Forms.Label
    Friend WithEvents LabelValiderOperation As System.Windows.Forms.Label
    Friend WithEvents ListBoxMsgServeur As System.Windows.Forms.ListBox

End Class
