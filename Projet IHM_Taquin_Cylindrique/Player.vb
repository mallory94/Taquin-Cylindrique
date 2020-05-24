Imports System.Text

Public Class Player
    Dim name As String 'nom du joueur
    Dim bestTime As Integer 'record personnel du joueur en secondes
    Dim nbGamePlayed As Integer 'nombre de parties jouées
    Dim totalPlayedTime As Integer 'temps total de jeu en secondes

    ''' <summary>
    ''' définit un joueur en fonction des caractéristiques reçues en paramètres
    ''' </summary>
    ''' <param name="name">nom du joueur</param>
    ''' <param name="time">temps joué</param>
    ''' <param name="hasWon">indicateur de victoire</param>
    Sub New(ByRef name As String, ByRef time As Integer, ByVal hasWon As Boolean)
        Me.New(name, time, 0, time)
        If hasWon = False Then
            Me.bestTime = Nothing
        Else
            Me.incNbGamePlayed()
        End If
    End Sub

    ''' <summary>
    ''' définit un joueur en fonction des caractéristiques reçues en paramètres
    ''' </summary>
    ''' <param name="name">nom du joueur</param>
    ''' <param name="time">record personnel du joueur en secondes</param>
    ''' <param name="nbGP">nombre de parties jouées</param>
    ''' <param name="totalPT">temps total de jeu en secondes</param>
    Sub New(ByRef name As String, ByVal time As Integer,
            ByVal nbGP As Integer, ByVal totalPT As Integer)
        Me.name = name
        bestTime = time
        nbGamePlayed = nbGP
        totalPlayedTime = totalPT
    End Sub

    ''' <summary>
    ''' met à jour le record d'un joueur si ce dernier a battu ce record
    ''' </summary>
    ''' <param name="time">temps effectué</param>
    Public Sub updateRecord(ByVal time As Integer)
        If (time < bestTime) Or (bestTime = 0) Then
            bestTime = time
        End If
    End Sub

    ''' <summary>
    ''' met à jour le temps total de jeu d'un joueur
    ''' </summary>
    ''' <param name="time">temps de jeu à rajouter</param>
    Public Sub updateTotalPlayTime(ByVal time As Integer)
        totalPlayedTime += time
    End Sub

    ''' <summary>
    ''' augmente de nom le nombre de partie jouée par le joueur
    ''' </summary>
    Public Sub incNbGamePlayed()
        nbGamePlayed += 1
    End Sub

    ''' <summary>
    ''' renvoit une chaine de caractère résumant les statistiques du joueur
    ''' </summary>
    ''' <returns>chaine de caractère contenant des infos sur le joueur</returns>
    Public Overrides Function toString() As String
        Return (name & "/" & bestTime.ToString & "/" & nbGamePlayed & "/" & totalPlayedTime)
    End Function

    ''' <summary>
    ''' retourne une chaine de caractère relativement détaillé donnant des infos sur le joueur
    ''' </summary>
    ''' <returns>chaine de caractère contenant des infos sur le joueur</returns>
    Public Function getInfo() As String
        Dim strInfo As New StringBuilder(" Nom : " & name & " Meilleur Temps : ")
        If bestTime <> 0 Then
            strInfo.Append(bestTime.ToString)
        Else
            strInfo.Append("Inconnu car aucune(s) partie(s) gagnée(s)")
        End If
        Return (strInfo.Append(Environment.NewLine & "Nombre de parties jouées : " & nbGamePlayed & Environment.NewLine & "Temps de jeu total : " & totalPlayedTime).ToString)
    End Function

    ''' <summary>
    ''' retourne le nom du joueur
    ''' </summary>
    ''' <returns>nom du joueur</returns>
    Public Function getName() As String
        Return (name)
    End Function

    ''' <summary>
    ''' retourne le record (en secondes) du joueur
    ''' </summary>
    ''' <returns>record (en secondes) du joueur</returns>
    Public Function getBestTime() As Integer
        Return (bestTime)
    End Function

End Class
