Public Class FormulaireAccueil
    Private Sub FormulaireAccueil_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FormJeu.killT()
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        loadRecordings()
        FormAcceuilCBFill()
    End Sub

    ''' <summary>
    ''' ajoute un handle Mybase.VisibleChanged sur la sub "FormulaireAccueil_VisibleChange()"
    ''' </summary>
    Private Sub FormulaireAccueil_activated() Handles Me.Activated
        AddHandler MyBase.VisibleChanged, AddressOf FormulaireAccueil_VisibleChange
    End Sub

    ''' <summary>
    ''' si le formulaire est visible, sauvegarde les données des joueurs et remplie la combobox
    ''' </summary>
    Private Sub FormulaireAccueil_VisibleChange()
        If Me.Visible = True Then
            saveRecording()
            FormAcceuilCBFill()
        End If
    End Sub

    ''' <summary>
    ''' lance une nouvelle partie si le joueur a emprunté un pseudo autorisé. Sinon Informe le joueur des contraintes sur le choix des pseudos.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BtnNouvellePartie.Click
        Dim name As String = ComboBox1.Text
        If Not name.Trim.Equals("") And Not name.Contains("/") Then
            Me.Hide()
            FormJeu.LabelName.Text = """" & ComboBox1.Text.Trim & """"
            FormJeu.setLimitTime(modeDeJeu())
            FormJeu.Show()
        Else
            MsgBox("Votre pseudo ne doit pas contenir de """"/"""". Le vide n'est pas accepté.")
        End If
    End Sub

    ''' <summary>
    ''' vide la combobox puis la remplit avec les données chargés
    ''' </summary>
    Public Sub FormAcceuilCBFill()
        ComboBox1.Items.Clear()
        comboBoxFilling(ComboBox1)
    End Sub

    ''' <summary>
    ''' ferme le formulaire d'accueil
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' cache le formulaire d'accueil et affiche le formulaire qui récapitule les scores des joueurs
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        FormRecap.Show()
    End Sub

    ''' <summary>
    ''' initialise la valeur du label censé affiché la valeur de la track barre à la valeur de la trackbarre
    ''' </summary>
    Private Sub initTrackBar() Handles MyBase.Load
        LabelTrackBarValue.Text = TrackBarPerso.Value
    End Sub

    ''' <summary>
    ''' rend visible ou non les options de mode de jeu suivant le radiobutton coché
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub RadioButtonPerso_CheckedChanged(sender As RadioButton, e As EventArgs) Handles RadioButtonPerso.CheckedChanged
        If sender.Checked = True Then
            TrackBarPerso.Enabled = True
            TrackBarPerso.Visible = True
            LabelTrackBarValue.Visible = True
        Else
            TrackBarPerso.Enabled = False
            TrackBarPerso.Visible = False
            LabelTrackBarValue.Visible = False
        End If
    End Sub

    ''' <summary>
    ''' modifie l'affichage du label qui renseigne la valeur de la track bar utilisé pour définir un mode de jeu personnalisé 
    ''' </summary>
    ''' <param name="sender">track bar du mode personnalisé</param>
    ''' <param name="e">trackbar scroll event</param>
    Private Sub TrackBarPerso_Scroll(sender As Object, e As EventArgs) Handles TrackBarPerso.Scroll
        LabelTrackBarValue.Text = TrackBarPerso.Value
    End Sub

    ''' <summary>
    ''' coche le radioButton correspondant au mode 90 secondes lors du lancement de l'application
    ''' </summary>
    Private Sub initRadioButtons() Handles MyBase.Load
        RadioButton90.Checked = True
    End Sub

    ''' <summary>
    ''' récupère le nombre temps qui correspond au mode de jeu sélectionné dans l'accueil
    ''' </summary>
    ''' <returns>durée limite de résolution du taquin</returns>
    Private Function modeDeJeu() As Integer
        FormJeu.setFiesta(False)
        If RadioButton60.Checked Then
            Return (60)
        ElseIf RadioButton90.Checked Then
            Return (90)
        ElseIf RadioButton120.Checked Then
            Return (120)
        ElseIf RadioButtonFiesta.Checked Then
            MsgBox("Le port d'un casque audio est vivement conseillé")
            FormJeu.setFiesta(True)
            Return (60)
        Else
            Return (LabelTrackBarValue.Text)
        End If
    End Function


End Class
