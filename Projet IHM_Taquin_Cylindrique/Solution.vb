Module Solution
    Dim indiceCourant As Integer 'indice du mouvement courant dans la liste des mouvements menant à la victoire
    Dim listMouvForWin As List(Of Mouvements.Mouvement) 'liste des mouvements amenant à la résolution du taquin
    Dim nbDeCoupsPourGagner As Integer 'nombre de coups minimal necessaire pour gagnger
    Dim DernierBoutonPresse As BoutonPresse
    ''' <summary>
    ''' définit la nature du dernière bouton de solution pressé
    ''' </summary>
    Public Enum BoutonPresse
        AVANCER
        RECULER
    End Enum

    ''' <summary>
    ''' prend en charge l'affichage de la solution du taquin
    ''' </summary>
    Public Sub showSolution()
        indiceCourant = 0
        listMouvForWin = getSolution()
        afficherBouttons()
        addHandleButtons()
        nbDeCoupsPourGagner = listMouvForWin.Count
        MsgBox("La résolution va commencer. Observez bien. La liste des mouvements fait " & listMouvForWin.Count)
    End Sub

    ''' <summary>
    ''' retourne la liste des mouvements nécessaires à la victoire
    ''' </summary>
    ''' <returns>liste des mouvements nécessaires à la victoire</returns>
    Private Function getSolution() As List(Of Mouvements.Mouvement)
        ecrit_fichier()
        appelle_taquin_exe()
        Return (decrypter())
    End Function

    ''' <summary>
    ''' écrit dans un fichier la disposition actuelle du taquin
    ''' </summary>
    Private Sub ecrit_fichier()
        Dim utf8WithoutBom As New System.Text.UTF8Encoding(False)
        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter("../../TxtSaisi.txt", False, utf8WithoutBom)
        file.WriteLine(Board.toString)
        file.Close()
    End Sub

    ''' <summary>
    ''' lit la réponse de l'algo de résolution de taquin cylindrique
    ''' </summary>
    ''' <returns>chaine de caractère correspondant à la solution renvoyée par l'algorithme</returns>
    Function lit_fichier() As String
        Return My.Computer.FileSystem.ReadAllText("../../TxtRepondu.txt")
    End Function

    ''' <summary>
    ''' procédure qui appelle taquin.exe afin de lui faire résoudre le taquin actuel et inscrire la solution dans un .txt
    ''' </summary>
    Private Sub appelle_taquin_exe()
        Dim commande As String =
            "taquin.exe < ../../TxtSaisi.txt > ../../TxtRepondu.txt"

        Dim p As New Process
        Dim psi As New ProcessStartInfo(
            "cmd.exe",
            "/c " & commande
        )
        p.StartInfo = psi
        p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        MsgBox("programme taquin.exe lancé. Début de la recherche de la solution... Veuillez patienter.")
        p.Start()
        p.WaitForExit()
        MsgBox("programme taquin.exe terminé")
    End Sub

    ''' <summary>
    ''' transforme la solution émise par l'algorithme de résolution de taquin en une liste d'énum "Mouvement" à effectuée pour gagner
    ''' </summary>
    ''' <returns>liste d'énum "Mouvement" à effectuée pour gagner</returns>
    Private Function decrypter() As List(Of Mouvement)
        Dim listMouvement As New List(Of Mouvements.Mouvement)
        Dim file As System.IO.StreamReader
        file = My.Computer.FileSystem.OpenTextFileReader("../../TxtRepondu.txt", System.Text.Encoding.UTF8)
        Debug.Assert(CheckLineAndCol(file.ReadLine)) 'vérifie que le nbC et nbL lus correspond à ceux du board
        For i = 0 To getNbL()
            Dim tmpStr As String = file.ReadLine()
        Next
        Dim str As String = file.ReadLine()
        While (True)
            If str Is Nothing Then
                Exit While
            End If
            listMouvement.Add(StrToEnum(str))
            For i = 1 To 4
                file.ReadLine()
            Next

            str = file.ReadLine()
        End While
        file.Close()
        Return (listMouvement)
    End Function

    ''' <summary>
    ''' affiche les boutons qui servent à avancer et reculer dans la résolution automatique du taquin
    ''' </summary>
    Private Sub afficherBouttons()
        FormJeu.BtnAvCoups.Visible = True
        FormJeu.BtnAvCoups.Enabled = True
        FormJeu.BtnRecCoups.Visible = True
        FormJeu.BtnRecCoups.Enabled = True
    End Sub

    ''' <summary>
    ''' ajoute aux boutons de résolution automatique du taquin les procédures se chargeant de leur fonctionnement
    ''' </summary>
    Private Sub addHandleButtons()
        AddHandler FormJeu.BtnAvCoups.Click, AddressOf AvancerCoups
        AddHandler FormJeu.BtnRecCoups.Click, AddressOf ReculerCoups
    End Sub

    ''' <summary>
    ''' joue le prochain coups necessaire à la résolution du taquin
    ''' </summary>
    Private Sub AvancerCoups()
        If (indiceCourant <= nbDeCoupsPourGagner - 1) Then
            DernierBoutonPresse = BoutonPresse.AVANCER
            jouerCoups(indiceCourant)
            indiceCourant += 1
        End If
    End Sub

    ''' <summary>
    ''' joue le coups précédent dans l'ordre de la liste des coups necessaires à la resolution du taquin
    ''' </summary>
    Private Sub ReculerCoups()
        If indiceCourant <> 0 Then
            DernierBoutonPresse = BoutonPresse.RECULER
            jouerCoups(indiceCourant - 1)
            indiceCourant -= 1
        End If
    End Sub

    ''' <summary>
    ''' joue un coup en fonction de l'indice courant dans la liste des mouvements à effectuer pour résoudre le taquin
    ''' </summary>
    ''' <param name="indice">indice courant du mouvement</param>
    Private Sub jouerCoups(ByVal indice As Integer)
        Dim spot As Spot
        If DernierBoutonPresse = BoutonPresse.AVANCER Then
            spot = ConvertMouvToSpot(listMouvForWin.ElementAt(indice))
        Else
            spot = ConvertMouvToSpot(InverserMouvement(listMouvForWin.ElementAt(indice)))
        End If
        spot.getButton.Enabled = True
        Shift(spot)
        spot.getButton.Enabled = False
        If (Board.IsOver()) Then
            DernierBoutonPresse = vbNull
            nbDeCoupsPourGagner = vbNull
            FormJeu.GameFinished(False)
        End If
    End Sub

    ''' <summary>
    ''' renvoit un mouvement inverse à celui reçu afin de permettre d'annuler un mouvement lors de la résolution automatique
    ''' </summary>
    ''' <param name="mouv">mouvement dont on cherche l'opposé</param>
    ''' <returns>mouvement oppposé au mouvement reçu</returns>
    Public Function InverserMouvement(ByVal mouv As Mouvement) As Mouvement
        Select Case (mouv)
            Case Mouvement.Nord
                Return (Mouvement.Sud)
            Case Mouvement.Sud
                Return Mouvement.Nord
            Case Mouvement.Ouest
                Return (Mouvement.Est)
        End Select
        Return (Mouvement.Ouest)
    End Function

    ''' <summary>
    ''' retourne l'emplacement représentant la case à bouger pour opérer le mouvement reçu en paramètre
    ''' </summary>
    ''' <param name="mouv">mouvement à convertir en emplacement</param>
    ''' <returns>emplacement de la case à déplacer</returns>
    Public Function ConvertMouvToSpot(ByVal mouv As Mouvement) As Spot
        Dim PrecedentVoidCoord() = getVoidCoord()
        Dim CoordBtn(1) As Integer
        Select Case mouv
            Case Mouvement.Nord
                CoordBtn(0) = (PrecedentVoidCoord(0) - 1)
                CoordBtn(1) = PrecedentVoidCoord(1)
            Case Mouvement.Est
                CoordBtn(0) = PrecedentVoidCoord(0)
                CoordBtn(1) = (PrecedentVoidCoord(1) + 1) Mod 4
            Case Mouvement.Ouest
                CoordBtn(0) = PrecedentVoidCoord(0)
                If (PrecedentVoidCoord(1) <> 0) Then
                    CoordBtn(1) = (PrecedentVoidCoord(1) - 1) Mod 4
                Else
                    CoordBtn(1) = 3
                End If
            Case Mouvement.Sud
                CoordBtn(0) = (PrecedentVoidCoord(0) + 1)
                CoordBtn(1) = PrecedentVoidCoord(1)
        End Select
        Return (findSpot(CoordBtn))
    End Function
End Module
