<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRecap
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
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.LabelName = New System.Windows.Forms.Label()
        Me.LabelMeilleurTemps = New System.Windows.Forms.Label()
        Me.BtnTriNom = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.BtnTriParTemps = New System.Windows.Forms.Button()
        Me.btnQuitter = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ListBox1
        '
        Me.ListBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox1.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 18
        Me.ListBox1.Location = New System.Drawing.Point(26, 63)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(191, 238)
        Me.ListBox1.TabIndex = 0
        '
        'ListBox2
        '
        Me.ListBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox2.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.ItemHeight = 18
        Me.ListBox2.Location = New System.Drawing.Point(239, 63)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(193, 238)
        Me.ListBox2.TabIndex = 1
        '
        'LabelName
        '
        Me.LabelName.AutoSize = True
        Me.LabelName.BackColor = System.Drawing.Color.Transparent
        Me.LabelName.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelName.ForeColor = System.Drawing.Color.Aqua
        Me.LabelName.Location = New System.Drawing.Point(100, 28)
        Me.LabelName.Name = "LabelName"
        Me.LabelName.Size = New System.Drawing.Size(49, 18)
        Me.LabelName.TabIndex = 2
        Me.LabelName.Text = "Noms"
        '
        'LabelMeilleurTemps
        '
        Me.LabelMeilleurTemps.AutoSize = True
        Me.LabelMeilleurTemps.BackColor = System.Drawing.Color.Transparent
        Me.LabelMeilleurTemps.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelMeilleurTemps.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(201, Byte), Integer), CType(CType(201, Byte), Integer))
        Me.LabelMeilleurTemps.Location = New System.Drawing.Point(271, 25)
        Me.LabelMeilleurTemps.Name = "LabelMeilleurTemps"
        Me.LabelMeilleurTemps.Size = New System.Drawing.Size(104, 18)
        Me.LabelMeilleurTemps.TabIndex = 3
        Me.LabelMeilleurTemps.Text = "Meilleur temps"
        '
        'BtnTriNom
        '
        Me.BtnTriNom.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTriNom.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.BtnTriNom.Location = New System.Drawing.Point(26, 322)
        Me.BtnTriNom.Name = "BtnTriNom"
        Me.BtnTriNom.Size = New System.Drawing.Size(191, 48)
        Me.BtnTriNom.TabIndex = 4
        Me.BtnTriNom.Text = "Trier par Noms"
        Me.BtnTriNom.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(644, 36)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(144, 26)
        Me.ComboBox1.TabIndex = 5
        '
        'BtnTriParTemps
        '
        Me.BtnTriParTemps.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTriParTemps.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.BtnTriParTemps.Location = New System.Drawing.Point(239, 323)
        Me.BtnTriParTemps.Name = "BtnTriParTemps"
        Me.BtnTriParTemps.Size = New System.Drawing.Size(193, 47)
        Me.BtnTriParTemps.TabIndex = 6
        Me.BtnTriParTemps.Text = "Trier par Meilleur temps"
        Me.BtnTriParTemps.UseVisualStyleBackColor = True
        '
        'btnQuitter
        '
        Me.btnQuitter.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnQuitter.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.btnQuitter.Location = New System.Drawing.Point(514, 327)
        Me.btnQuitter.Name = "btnQuitter"
        Me.btnQuitter.Size = New System.Drawing.Size(196, 38)
        Me.btnQuitter.TabIndex = 7
        Me.btnQuitter.Text = "Revenir au menu d'accueil"
        Me.btnQuitter.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Aqua
        Me.Label1.Location = New System.Drawing.Point(468, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(150, 18)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Rechercher un joueur"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Button1.Location = New System.Drawing.Point(514, 247)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(252, 45)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "+ d'infos sur le joueur sélectionné"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'FormRecap
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Projet_IHM_Taquin_Cylindrique.My.Resources.Resources.blueBlackBg1
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnQuitter)
        Me.Controls.Add(Me.BtnTriParTemps)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.BtnTriNom)
        Me.Controls.Add(Me.LabelMeilleurTemps)
        Me.Controls.Add(Me.LabelName)
        Me.Controls.Add(Me.ListBox2)
        Me.Controls.Add(Me.ListBox1)
        Me.Name = "FormRecap"
        Me.Text = "FormRecap"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents ListBox2 As ListBox
    Friend WithEvents LabelName As Label
    Friend WithEvents LabelMeilleurTemps As Label
    Friend WithEvents BtnTriNom As Button
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents BtnTriParTemps As Button
    Friend WithEvents btnQuitter As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
End Class
