<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormulaireAccueil
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
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.BtnNouvellePartie = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Nom = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBox_Noms = New System.Windows.Forms.Label()
        Me.TrackBarPerso = New System.Windows.Forms.TrackBar()
        Me.PanelRadioButtons = New System.Windows.Forms.Panel()
        Me.RadioButtonFiesta = New System.Windows.Forms.RadioButton()
        Me.RadioButtonPerso = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.RadioButton120 = New System.Windows.Forms.RadioButton()
        Me.RadioButton90 = New System.Windows.Forms.RadioButton()
        Me.RadioButton60 = New System.Windows.Forms.RadioButton()
        Me.LabelTrackBarValue = New System.Windows.Forms.Label()
        CType(Me.TrackBarPerso, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelRadioButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'ComboBox1
        '
        Me.ComboBox1.BackColor = System.Drawing.SystemColors.InfoText
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.ForeColor = System.Drawing.Color.Lime
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(427, 77)
        Me.ComboBox1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(148, 26)
        Me.ComboBox1.TabIndex = 0
        '
        'BtnNouvellePartie
        '
        Me.BtnNouvellePartie.BackColor = System.Drawing.Color.Black
        Me.BtnNouvellePartie.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNouvellePartie.ForeColor = System.Drawing.Color.Lime
        Me.BtnNouvellePartie.Location = New System.Drawing.Point(80, 442)
        Me.BtnNouvellePartie.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.BtnNouvellePartie.Name = "BtnNouvellePartie"
        Me.BtnNouvellePartie.Size = New System.Drawing.Size(97, 42)
        Me.BtnNouvellePartie.TabIndex = 1
        Me.BtnNouvellePartie.Text = "Nouvelle Partie"
        Me.BtnNouvellePartie.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Black
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Lime
        Me.Button2.Location = New System.Drawing.Point(575, 442)
        Me.Button2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(87, 42)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Quitter le jeu"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Black
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.Lime
        Me.Button3.Location = New System.Drawing.Point(316, 442)
        Me.Button3.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(117, 42)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "Afficher les scores"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Nom
        '
        Me.Nom.AutoSize = True
        Me.Nom.Location = New System.Drawing.Point(140, 76)
        Me.Nom.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Nom.Name = "Nom"
        Me.Nom.Size = New System.Drawing.Size(0, 13)
        Me.Nom.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Lime
        Me.Label1.Location = New System.Drawing.Point(244, 17)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(401, 41)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Jeu du taquin cylindrique"
        '
        'ComboBox_Noms
        '
        Me.ComboBox_Noms.AutoSize = True
        Me.ComboBox_Noms.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ComboBox_Noms.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox_Noms.ForeColor = System.Drawing.Color.Lime
        Me.ComboBox_Noms.Location = New System.Drawing.Point(11, 77)
        Me.ComboBox_Noms.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.ComboBox_Noms.Name = "ComboBox_Noms"
        Me.ComboBox_Noms.Size = New System.Drawing.Size(390, 20)
        Me.ComboBox_Noms.TabIndex = 6
        Me.ComboBox_Noms.Text = "Entrer un nouveau nom ou choisissez un nom existant"
        '
        'TrackBarPerso
        '
        Me.TrackBarPerso.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.TrackBarPerso.Enabled = False
        Me.TrackBarPerso.Location = New System.Drawing.Point(459, 357)
        Me.TrackBarPerso.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.TrackBarPerso.Maximum = 300
        Me.TrackBarPerso.Minimum = 30
        Me.TrackBarPerso.Name = "TrackBarPerso"
        Me.TrackBarPerso.Size = New System.Drawing.Size(260, 45)
        Me.TrackBarPerso.SmallChange = 10
        Me.TrackBarPerso.TabIndex = 7
        Me.TrackBarPerso.Value = 30
        Me.TrackBarPerso.Visible = False
        '
        'PanelRadioButtons
        '
        Me.PanelRadioButtons.BackColor = System.Drawing.Color.Transparent
        Me.PanelRadioButtons.Controls.Add(Me.RadioButtonFiesta)
        Me.PanelRadioButtons.Controls.Add(Me.RadioButtonPerso)
        Me.PanelRadioButtons.Controls.Add(Me.Label2)
        Me.PanelRadioButtons.Controls.Add(Me.RadioButton120)
        Me.PanelRadioButtons.Controls.Add(Me.RadioButton90)
        Me.PanelRadioButtons.Controls.Add(Me.RadioButton60)
        Me.PanelRadioButtons.ForeColor = System.Drawing.Color.Lime
        Me.PanelRadioButtons.Location = New System.Drawing.Point(50, 342)
        Me.PanelRadioButtons.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.PanelRadioButtons.Name = "PanelRadioButtons"
        Me.PanelRadioButtons.Size = New System.Drawing.Size(405, 60)
        Me.PanelRadioButtons.TabIndex = 12
        '
        'RadioButtonFiesta
        '
        Me.RadioButtonFiesta.AutoSize = True
        Me.RadioButtonFiesta.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButtonFiesta.Location = New System.Drawing.Point(230, 24)
        Me.RadioButtonFiesta.Name = "RadioButtonFiesta"
        Me.RadioButtonFiesta.Size = New System.Drawing.Size(61, 22)
        Me.RadioButtonFiesta.TabIndex = 17
        Me.RadioButtonFiesta.TabStop = True
        Me.RadioButtonFiesta.Text = "fiesta"
        Me.RadioButtonFiesta.UseVisualStyleBackColor = True
        '
        'RadioButtonPerso
        '
        Me.RadioButtonPerso.AutoSize = True
        Me.RadioButtonPerso.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButtonPerso.Location = New System.Drawing.Point(302, 24)
        Me.RadioButtonPerso.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.RadioButtonPerso.Name = "RadioButtonPerso"
        Me.RadioButtonPerso.Size = New System.Drawing.Size(110, 22)
        Me.RadioButtonPerso.TabIndex = 16
        Me.RadioButtonPerso.TabStop = True
        Me.RadioButtonPerso.Text = "personnalisé"
        Me.RadioButtonPerso.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(105, 0)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(171, 18)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Différents modes de jeux"
        '
        'RadioButton120
        '
        Me.RadioButton120.AutoSize = True
        Me.RadioButton120.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton120.Location = New System.Drawing.Point(154, 24)
        Me.RadioButton120.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.RadioButton120.Name = "RadioButton120"
        Me.RadioButton120.Size = New System.Drawing.Size(78, 22)
        Me.RadioButton120.TabIndex = 15
        Me.RadioButton120.TabStop = True
        Me.RadioButton120.Text = "120 sec"
        Me.RadioButton120.UseVisualStyleBackColor = True
        '
        'RadioButton90
        '
        Me.RadioButton90.AutoSize = True
        Me.RadioButton90.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton90.Location = New System.Drawing.Point(82, 24)
        Me.RadioButton90.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.RadioButton90.Name = "RadioButton90"
        Me.RadioButton90.Size = New System.Drawing.Size(70, 22)
        Me.RadioButton90.TabIndex = 14
        Me.RadioButton90.TabStop = True
        Me.RadioButton90.Text = "90 sec"
        Me.RadioButton90.UseVisualStyleBackColor = True
        '
        'RadioButton60
        '
        Me.RadioButton60.AutoSize = True
        Me.RadioButton60.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton60.Location = New System.Drawing.Point(9, 24)
        Me.RadioButton60.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.RadioButton60.Name = "RadioButton60"
        Me.RadioButton60.Size = New System.Drawing.Size(70, 22)
        Me.RadioButton60.TabIndex = 13
        Me.RadioButton60.TabStop = True
        Me.RadioButton60.Text = "60 sec"
        Me.RadioButton60.UseVisualStyleBackColor = True
        '
        'LabelTrackBarValue
        '
        Me.LabelTrackBarValue.AutoSize = True
        Me.LabelTrackBarValue.BackColor = System.Drawing.Color.Transparent
        Me.LabelTrackBarValue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelTrackBarValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTrackBarValue.ForeColor = System.Drawing.Color.Lime
        Me.LabelTrackBarValue.Location = New System.Drawing.Point(575, 335)
        Me.LabelTrackBarValue.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelTrackBarValue.Name = "LabelTrackBarValue"
        Me.LabelTrackBarValue.Size = New System.Drawing.Size(68, 25)
        Me.LabelTrackBarValue.TabIndex = 13
        Me.LabelTrackBarValue.Text = "<valeur>"
        Me.LabelTrackBarValue.UseCompatibleTextRendering = True
        Me.LabelTrackBarValue.Visible = False
        '
        'FormulaireAccueil
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Projet_IHM_Taquin_Cylindrique.My.Resources.Resources.background_img
        Me.ClientSize = New System.Drawing.Size(757, 496)
        Me.Controls.Add(Me.LabelTrackBarValue)
        Me.Controls.Add(Me.TrackBarPerso)
        Me.Controls.Add(Me.ComboBox_Noms)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Nom)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.BtnNouvellePartie)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.PanelRadioButtons)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HelpButton = True
        Me.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormulaireAccueil"
        Me.ShowIcon = False
        Me.Text = "Formulaire d'accueil"
        CType(Me.TrackBarPerso, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelRadioButtons.ResumeLayout(False)
        Me.PanelRadioButtons.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents BtnNouvellePartie As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Nom As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents ComboBox_Noms As Label
    Friend WithEvents TrackBarPerso As TrackBar
    Friend WithEvents PanelRadioButtons As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents RadioButtonPerso As RadioButton
    Friend WithEvents RadioButton120 As RadioButton
    Friend WithEvents RadioButton90 As RadioButton
    Friend WithEvents RadioButton60 As RadioButton
    Friend WithEvents LabelTrackBarValue As Label
    Friend WithEvents RadioButtonFiesta As RadioButton
End Class
