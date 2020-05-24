Module Mouvements
    ''' <summary>
    ''' variable représentant un mouvement de la case vide dans la disposition du taquin
    ''' </summary>
    Public Enum Mouvement
        Nord
        Sud
        Est
        Ouest
    End Enum

    ''' <summary>
    ''' convertit une chaine de caractère reçue en paramètre au type énuméré qui lui correspond
    ''' </summary>
    ''' <param name="str">chaine de caractère à convertir</param>
    ''' <returns>mouvement issu de la conversion</returns>
    Public Function StrToEnum(ByRef str As String) As Mouvement
        Select Case (str)
            Case "NORD"
                Return (Mouvement.Nord)
            Case "SUD"
                Return (Mouvement.Sud)
            Case "EST"
                Return (Mouvement.Est)
        End Select
        Return (Mouvement.Ouest)
    End Function
End Module
