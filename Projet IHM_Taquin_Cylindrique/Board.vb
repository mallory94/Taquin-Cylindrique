Imports System.Text


Module Board
    Private Const nbL As Integer = 4 'line number
    Private Const nbC As Integer = 4 'column number
    Dim tabSpot(nbL - 1, nbC - 1) As Spot 'tableau d'emplacement représentant la disposition du taquin
    Dim voidCoord(1) As Integer 'coordonnées de la case vide
    Dim spotMoveable As List(Of Spot) 'emplacements des cases bougeables (contient la case vide)

    ''' <summary>
    ''' initialiser un tableau de Spot (emplacement) correspondant au jeu de taquin
    ''' </summary>
    Public Sub init()
        Dim tmpLine As Integer
        Dim tmpCol As Integer
        For Each btn As Button In FormJeu.Panel1.Controls
            findCoordByIndex(btn, tmpLine, tmpCol)
            tabSpot(tmpLine, tmpCol) = New Spot(btn)
            If (btn.Visible = False) Then
                setVoidCoord(tmpLine, tmpCol)
            End If
        Next
        ScanSpotMoveable()
    End Sub

    ''' <summary>
    ''' trouve les coordonnées du bouton renseigné et attribue aux variables reçues (x et y) les coordonnées de ce bouton.
    ''' </summary>
    ''' <param name="btn">bouton dont on cherche les coordonnées</param>
    ''' <param name="x">variable qui se verra attribuer la coordonnée x du bouton renseigné</param>
    ''' <param name="y">variable qui se verra attribuer la coordonnée y du bouton renseigné</param>
    Public Sub findCoordByIndex(ByRef btn As Button,
                                ByRef x As Integer, ByRef y As Integer)
        Select Case btn.TabIndex
            Case 1 To 4
                x = 0
            Case 5 To 8
                x = 1
            Case 9 To 12
                x = 2
            Case Else
                x = 3
        End Select
        y = (btn.TabIndex - 1) Mod 4
    End Sub

    ''' <summary>
    ''' utilise les données reçues (x et y) en tant que coordonnées et attribue (de façon théorique) ces coordonnées à la case vide 
    ''' </summary>
    ''' <param name="x">coordonnée qui va devenir la ligne théorique de la case vide</param>
    ''' <param name="y">coordonnée qui va devenir la colonne théorique de la case vide</param>
    Public Sub setVoidCoord(ByVal x As Integer, ByVal y As Integer)
        voidCoord(0) = x
        voidCoord(1) = y
    End Sub

    ''' <summary>
    ''' vérifie si l'emplacement reçu en paramètre correspond à une case bougeable.
    ''' </summary>
    ''' <param name="spot">emplacement sur lequel se porte la vérification</param>
    ''' <returns>renvoit true si l'emplacment correspond à une case bougeable. False sinon</returns>
    Public Function isDefinedAsMoveable(ByRef spot As Spot) As Boolean
        Return (spotMoveable.Contains(spot))
    End Function

    ''' <summary>
    ''' fait se déplacer la case vide dans l'emplacement renseigné en paramètre
    ''' </summary>
    ''' <param name="spot">emplacement destiné à devenir la case vide</param>
    Public Sub Shift(ByRef spot As Spot)
        Dim line As Integer
        Dim col As Integer

        spot.shiftInVoid(tabSpot(voidCoord(0), voidCoord(1)).getButton)
        findCoordByIndex(spot.getButton, line, col)
        setVoidCoord(line, col)
        ScanSpotMoveable()
    End Sub

    ''' <summary>
    ''' retourn l'emplacement vide parmi les cases étant sujettes à des déplacements
    ''' </summary>
    ''' <param name="btn"></param>
    ''' <returns></returns>
    Public Function findInMoveables(ByRef btn As Button) As Spot
        For Each spot As Spot In spotMoveable
            If (spot.isEquals(btn)) Then
                Return (spot)
            End If
        Next
        Return (Nothing)
    End Function

    ''' <summary>
    ''' définit les cases qui peuvent bouger si l'utilisateur clique dessus
    ''' </summary>
    Public Sub ScanSpotMoveable()
        Dim RangeX As Integer
        Dim RangeY As Integer
        Dim tmpSpotMoveable As New List(Of Spot)
        For line = 0 To (nbL - 1)
            For col = 0 To (nbC - 1)
                RangeX = (Math.Abs(voidCoord(1) - col)) Mod 3
                If (voidCoord(1) <> col And RangeX = 0) Then   'prend en compte le déplacement rotatif
                    RangeX = 1
                End If
                If (RangeX <= 1) Then
                    RangeY = Math.Abs(voidCoord(0) - line)
                    If (RangeY <= 1) Then
                        If (RangeX + RangeY) < 2 Then
                            tmpSpotMoveable.Add(tabSpot(line, col))
                        End If
                    End If

                End If
            Next
        Next
        spotMoveable = tmpSpotMoveable
    End Sub

    ''' <summary>
    ''' indique si la partie est terminée ou non suivant la disposition du taquin
    ''' </summary>
    ''' <returns>retourne true si la partie est terminée. false sinon</returns>
    Public Function IsOver() As Boolean
        Dim iterator As Integer = 1
        Dim tmpCol As Integer = -1 'retient la colonne où doivent s'alligner
        For i = 0 To 3
            If tabSpot(0, i).value = "1" Then
                tmpCol = i
                Exit For
            End If
        Next
        If tmpCol <> -1 Then
            For line = 0 To (nbL - 1)
                For counter = 0 To (nbL - 1)
                    If (tabSpot(line, (tmpCol + counter) Mod 4).value <> iterator) Then
                        Return False
                    End If
                    iterator = iterator + 1
                Next
            Next
            FormJeu.Timer2.Stop()
            Return True
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' renvoit une chaine de caractère représentant la disposition actuelle du taquin.
    ''' </summary>
    ''' <returns>chaine de caractère représentant la disposition actuelle du taquin</returns>
    Public Function toString() As String
        Dim strBuilder As New StringBuilder
        Dim tmpValue As Integer
        strBuilder.Append(nbL & " " & nbC & " ")
        For i_line = 0 To nbL - 1
            For i_col = 0 To nbC - 1
                tmpValue = tabSpot(i_line, i_col).value
                If tmpValue.Equals(16) Then
                    strBuilder.Append("#")
                Else
                    strBuilder.Append(tmpValue.ToString)
                End If
                strBuilder.Append(" ")
            Next
        Next
        Return (strBuilder.ToString)
    End Function


    ''' <summary>
    ''' vérifie que la chaine de caractère renseignée contient bien le nombre de ligne et de colonne du taquin.
    ''' </summary>
    ''' <param name="str">chaine de caractère contenant le nombre de ligne et nombre de colonne</param>
    ''' <returns>renvoit true si les caracteristiques renseignées dans la chaine de caractères correspondent bien, false dans le cas contraire </returns>
    Public Function CheckLineAndCol(ByRef str As String) As Boolean
        Dim strSplit() As String = str.Split(" ")
        Return (Val(strSplit(2)) = nbL And Val(strSplit(4)) = nbC)
    End Function

    ''' <summary>
    ''' retourne le nombre de ligne du taquin
    ''' </summary>
    ''' <returns>nombre de ligne du taquin</returns>
    Public Function getNbL() As Integer
        Return (nbL)
    End Function

    ''' <summary>
    ''' retourne le nombre de colonne du taquin
    ''' </summary>
    ''' <returns>nombre de colonne du taquin</returns>
    Public Function getNbC() As Integer
        Return (nbC)
    End Function

    ''' <summary>
    ''' retourne les coordonnées de la case vide
    ''' </summary>
    ''' <returns>Coordonnées de la case vide</returns>
    Public Function getVoidCoord() As Integer()
        Return (voidCoord)
    End Function

    ''' <summary>
    ''' retourne l'emplacement correspondant aux coordonnées reçues en paramètre
    ''' </summary>
    ''' <param name="Coord">coordonnées du spot à retourner</param>
    ''' <returns>spot coorespondant aux coordonnées</returns>
    Public Function findSpot(ByRef Coord As Integer()) As Spot
        Return (tabSpot(Coord(0), Coord(1)))
    End Function

    ''' <summary>
    ''' retourne la liste des emplacements des cases bougeables (contient la case vide)
    ''' </summary>
    ''' <returns>liste des emplacements des cases bougeables (contient la case vide)</returns>
    Public Function getSpotMoveable() As List(Of Spot)
        Return spotMoveable
    End Function
End Module
