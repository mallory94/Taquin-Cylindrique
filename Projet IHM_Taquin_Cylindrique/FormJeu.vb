

Public Class FormJeu
    Dim sortedNbTab As New List(Of Integer)({1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15})
    Dim nbTab As New List(Of Integer)()
    Private Const iFirstItem As Integer = 0
    Private limitTime As Integer = 10
    Private GameReady As Boolean
    Private fiestaOn As Boolean

    Public Sub setFiesta(ByVal bool As Boolean)
        fiestaOn = bool
    End Sub

    ''' <summary>
    ''' démarre le mode fête
    ''' </summary>
    Private Sub StartFiesta()
        fiestaOn = True
        setEpilepticMod(True)
        setBananaMusic(True)
        setSkelGif(True)
    End Sub

    ''' <summary>
    ''' arrête le mode fiesta
    ''' </summary>
    Private Sub StopFiesta()
        setEpilepticMod(False)
        setBananaMusic(False)
        setSkelGif(False)
        fiestaOn = False
    End Sub


    ''' <summary>
    ''' active ou désactive les décorations avec les squelettes dansant en fonction du boolean reçu
    ''' </summary>
    ''' <param name="bool">définit si on doit désactiver ou activer les décorations</param>
    Private Sub setSkelGif(ByVal bool As Boolean)
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is PictureBox Then
                ctrl.Enabled = bool
                ctrl.Visible = bool
            End If
        Next
    End Sub

    ''' <summary>
    ''' active ou désactive la musique banana split en fonction du boolean reçu
    ''' </summary>
    ''' <param name="bool"></param>
    Private Sub setBananaMusic(ByVal bool As Boolean)
        If bool = True Then
            My.Computer.Audio.Play(Application.StartupPath & "\..\..\banana.wav", AudioPlayMode.BackgroundLoop)
        Else
            My.Computer.Audio.Stop()
        End If
    End Sub


    ''' <summary>
    ''' Affiche dans le temps 
    ''' </summary>
    Private Sub showTimeRemaining() Handles Timer2.Tick
        LabelTimeRemaining.Text = limitTime - getCurrentTime()

        If LabelTimeRemaining.Text = 0 And isEnable() Then
            GameFinished(False)
        End If
    End Sub

    ''' <summary>
    ''' active ou désactive le mode épileptique en fonction du boolean reçu
    ''' </summary>
    ''' <param name="enable"></param>
    Public Sub setEpilepticMod(ByRef enable As Boolean)
        If enable = True Then
            Timer1.Start()

        Else
            Timer1.Stop()
        End If
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub timerAction() Handles Timer1.Tick
        Dim rndo As New Random
        Dim rndColor As Integer
        For Each btn As Button In Panel1.Controls
            rndColor = CInt(Rnd() * 2147483647)
            btn.BackColor = Color.FromArgb(rndColor)
            btn.ForeColor = Color.FromArgb(CInt(2147483647 - rndColor))
        Next
        Me.BackColor = Color.FromArgb(255, rndo.Next(255), rndo.Next(255), rndo.Next(255))
    End Sub


    Private Sub RemplissageBanal()
        For Each btn As Button In Panel1.Controls
            If btn.TabIndex = 16 Then
                btn.Text = 15
                Continue For
            ElseIf btn.TabIndex = 15 Then
                btn.Visible = False
                btn.Text = 16
                Continue For
            End If
            btn.Text = btn.TabIndex
        Next
    End Sub

    Private Sub AddHandlers()
        For Each btn As Button In Panel1.Controls
            AddHandler btn.Click, AddressOf clickOnButton
        Next
    End Sub

    ''' <summary>
    ''' mélange le taquin
    ''' </summary>
    Private Sub Shuffle()
        Randomize()
        Dim listSpot As List(Of Spot)
        For i = 0 To 100
            Me.Show()
            ScanSpotMoveable()
            listSpot = getSpotMoveable()
            listSpot.ElementAt(Int(Rnd() * listSpot.Count)).getButton.PerformClick()
            ScanSpotMoveable()
        Next
    End Sub

    ''' <summary>
    ''' remplacer le bouton pressé par la case vide si jamais celui figure dans les cases bougeables
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub clickOnButton(sender As Object, e As EventArgs)
        Dim spot As Spot
        spot = findInMoveables(sender)
        If Not (spot Is Nothing) Then
            Shift(spot)
            If (IsOver() And (GameReady = True)) Then
                GameFinished(True)
            End If
        End If

    End Sub

    ''' <summary>
    ''' prépare le déroulement du jeu
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub FormJeu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        setParamWindow()
        LabelTimeRemaining.Text = limitTime
        GameReady = False
        RemplissageBanal()
        Board.init()
        AddHandlers()
        Shuffle()
        GameReady = True
        If fiestaOn = True Then
            StartFiesta()
        End If
    End Sub

    ''' <summary>
    ''' configure les paramètres de la fenetre
    ''' </summary>
    Private Sub setParamWindow()
        Me.FormBorderStyle = FormBorderStyle.None
        Me.ControlBox = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
    End Sub

    ''' <summary>
    ''' lance le chronometre lorsque le formulaire d'affiche
    ''' </summary>
    Private Sub FormJeu_Shown() Handles MyBase.VisibleChanged, MyBase.Shown
        If Me.Visible = True Then
            startChrono(Timer2, BtnPause, limitTime)
        End If
    End Sub


    ''' <summary>
    ''' prend en charge la fin de partie.
    ''' met à jour les données des joueurs si necessaire
    ''' </summary>
    ''' <param name="isWon">indique si la partie est gagnée ou perdue</param>
    Public Sub GameFinished(ByVal isWon As Boolean)
        Dim currentPlayer As Player = findCurrentPlayer()
        If isWon = True And IsOver() Then
            MsgBox("Vous avez gagné! Bravo!")
            If currentPlayer Is Nothing Then
                addPlayer(New Player(getCurrentPlayerName(), getCurrentTime(), True))
            Else
                currentPlayer.updateRecord(getCurrentTime())
            End If
        Else
            MsgBox("Vous avez perdu...")
            If currentPlayer Is Nothing Then
                addPlayer(New Player(FormulaireAccueil.ComboBox1.Text.Trim, getCurrentTime, False))
            Else
                currentPlayer.updateTotalPlayTime(getCurrentTime)
            End If
        End If
        currentPlayer = findCurrentPlayer()
        currentPlayer.incNbGamePlayed()
        FormulaireAccueil.FormAcceuilCBFill()
        If fiestaOn = True Then
            StopFiesta()
        End If
        Me.Close()
    End Sub

    ''' <summary>
    ''' lors d'un clique sur le bouton abandon, lance une boite de dialogue demandant si la personne souhaite réellement abandonner
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub BtnAbandon_Click(sender As Object, e As EventArgs) Handles BtnAbandon.Click
        invokeChoice("abandonner")
    End Sub

    ''' <summary>
    ''' retourne le joueur courant
    ''' </summary>
    ''' <returns>joueur courant</returns>
    Public Function findCurrentPlayer() As Player
        Return findPlayer(getCurrentPlayerName())
    End Function

    ''' <summary>
    ''' retourne le nom du joueur courant
    ''' </summary>
    ''' <returns>nom du joueur courant</returns>
    Public Function getCurrentPlayerName() As String
        Return (FormulaireAccueil.ComboBox1.Text.Trim())
    End Function

    ''' <summary>
    ''' ouvre le formulaire d'accueil et termine les processus taquin.exe lors de la fermeture du formulaire
    ''' </summary>
    Private Sub fermetureFormJeu() Handles Me.Closing
        FormulaireAccueil.Show()
        killT()
    End Sub


    ''' <summary>
    ''' termine les processus taquin.exe
    ''' </summary>
    Public Sub killT()
        For Each P As Process In System.Diagnostics.Process.GetProcessesByName("Taquin")
            P.Kill()
        Next
    End Sub

    ''' <summary>
    ''' définit la durée limite de résolution du taquin
    ''' </summary>
    ''' <param name="time"></param>
    Public Sub setLimitTime(ByVal time As Integer)
        limitTime = time
    End Sub

    ''' <summary>
    ''' appelle une boite de dialogue demandant au joueur si il souhaite vraiment voir la solution
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles BtnVoirSolution.Click
        invokeChoice("voir la solution")
    End Sub

    ''' <summary>
    ''' affiche une boite de dialogue dont le message varie suivant la string reçue en parametre.
    ''' </summary>
    ''' <param name="strVerb">action du joueur qu'on lui demande de confirmer </param>
    Private Sub invokeChoice(strVerb As String)
        If Chrono.isEnable() = True Then
            pauseChrono()
        End If
        Dim choice As Integer = MsgBox("Etes vous sûr de vouloir " & strVerb & "?" & Chr(10) & "Vous perdrez cette partie", MsgBoxStyle.YesNo +
                                       MsgBoxStyle.DefaultButton1 + MsgBoxStyle.Question, "Confirmation")
        If choice = MsgBoxResult.Yes Then
            Dim tmpBtnList As New List(Of Button)
            blockAllBtn(tmpBtnList)
            If (strVerb = "voir la solution") Then
                showSolution()
            ElseIf (strVerb = "abandonner") Then
                GameFinished(False)
            Else
                pauseChrono()
            End If
        End If
    End Sub

    ''' <summary>
    ''' bloque tous les boutons du formulaire et ajoute ceux-ci à la liste reçue en paramètre
    ''' </summary>
    ''' <param name="btnList">liste des boutons qui ont été bloqués</param>
    Public Sub blockAllBtn(ByRef btnList As List(Of Button))
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is Button Then
                ctrl.Enabled = False
                btnList.Add(ctrl)
            End If
        Next
    End Sub

    ''' <summary>
    ''' débloque ou bloque les boutons(cases) du taquin suivant le paramètre reçue
    ''' débloque si le boolean vaut true. Bloque sinon
    ''' </summary>
    ''' <param name="state">état que va prendre l'attribut "enabled" du bouton</param>
    Public Sub blockOrUnlockMoveBtn(ByVal state As Boolean)
        For Each btn As Button In Panel1.Controls
            btn.Enabled = state
        Next
    End Sub

    ''' <summary>
    ''' débloque tous les boutons de la liste reçue en paramètre
    ''' </summary>
    ''' <param name="btnList">liste dont il faut débloquer les boutons</param>
    Public Sub unlockAllBtn(ByRef btnList As List(Of Button))
        For Each btn In btnList
            btn.Enabled = True
        Next
    End Sub
End Class