Module Chrono
    Private currentTimer As Integer 'durée chronomètrée courante
    WithEvents timer As Timer 'timer associé au chronomètre
    WithEvents pauseBtn As Button 'bouton pause associé au paramètre
    Private timeLimit As Integer 'durée limite de chronometrage

    ''' <summary>
    ''' démarre le chronomètre
    ''' </summary>
    ''' <param name="t">timer du chronometre</param>
    ''' <param name="btnPause">bouton pause du chroomètre</param>
    ''' <param name="limit">durée limite du chronometre</param>
    Public Sub startChrono(ByRef t As Timer, ByRef btnPause As Button,
                           ByRef limit As Integer)
        resetChrono()
        timer = t
        pauseBtn = btnPause
        timeLimit = limit
        timer.Enabled = True
    End Sub

    ''' <summary>
    ''' réinitialise le chronomètre
    ''' </summary>
    Public Sub resetChrono()
        currentTimer = 0
    End Sub

    ''' <summary>
    ''' augmente la durée chronomètrée
    ''' </summary>
    Public Sub increaseChrono() Handles timer.Tick
        If currentTimer < timeLimit Then
            currentTimer += 1
        ElseIf currentTimer = timeLimit Then
            timer.Enabled = False
            pauseBtn.Enabled = False
        End If
    End Sub

    ''' <summary>
    ''' retourne la durée chronométrée en secondes
    ''' </summary>
    ''' <returns>durée chronométrée en seconde</returns>
    Public Function getCurrentTime() As Integer
        Return (currentTimer)
    End Function

    ''' <summary>
    ''' met en pause le chronomètre
    ''' </summary>
    Public Sub pauseChrono() Handles pauseBtn.Click
        If timer.Enabled = True Then
            timer.Enabled = False
            FormJeu.blockOrUnlockMoveBtn(False)
        Else
            timer.Enabled = True
            FormJeu.blockOrUnlockMoveBtn(True)
        End If
    End Sub

    ''' <summary>
    ''' reprend le chronométrage
    ''' </summary>
    Public Sub continueChrono()
        timer.Enabled = True
    End Sub



    ''' <summary>
    ''' retourne si oui ou non le chronomètre est activé
    ''' </summary>
    ''' <returns>true si le chronomètre est activé. False sinon</returns>
    Public Function isEnable() As Boolean
        Return (timer.Enabled)
    End Function
End Module
