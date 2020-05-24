Imports System.IO
Imports System.Text

Module ModuleSave
    Dim playerList As New List(Of Player)

    ''' <summary>
    ''' ajoute un joueur à la liste des joueurs chargés en mémoire temporaire
    ''' </summary>
    ''' <param name="player">nom du joueur</param>
    Public Sub addPlayer(ByRef player As Player)
        playerList.Add(player)
    End Sub

    ''' <summary>
    ''' renvoit le joueur de l'application qui porte le nom renseigné
    ''' </summary>
    ''' <param name="name">nom du joueur recherché</param>
    ''' <returns></returns>
    Public Function findPlayer(ByVal name As String) As Player
        For Each player As Player In playerList
            If (name = player.getName) Then
                Return player
            End If
        Next
        Return Nothing
    End Function

    ''' <summary>
    ''' rempli la combobox renseignée du nom des joueurs de l'application
    ''' </summary>
    ''' <param name="combobox"></param>
    Public Sub comboBoxFilling(ByRef combobox As ComboBox)
        For Each player As Player In playerList
            combobox.Items.Add(player.getName)
        Next
    End Sub

    ''' <summary>
    ''' charge tous les enregistrements concernant les joueurs de l'application en mémoire temporaire
    ''' </summary>
    Public Sub loadRecordings()
        Dim objStreamReader As StreamReader = New StreamReader("..\..\Save.txt")
        Dim strLine As String
        Dim strTab() As String
        While (Not objStreamReader.EndOfStream)
            strLine = objStreamReader.ReadLine
            strTab = strLine.Split("/")
            addPlayer(New Player(strTab(0), strTab(1), strTab(2), strTab(3)))
        End While
        objStreamReader.Close()
    End Sub

    ''' <summary>
    ''' sauvegarde tous les enregistrements concernant les joueurs de l'application en mémoire permanente
    ''' </summary>
    Public Sub saveRecording()
        Dim objStreamWriter As StreamWriter = New StreamWriter("..\..\Save.txt")

        For Each player As Player In playerList
            objStreamWriter.WriteLine(player.toString())
        Next
        objStreamWriter.Close()
    End Sub

    ''' <summary>
    ''' retourne la liste des joueurs de l'application
    ''' </summary>
    ''' <returns>liste des joueurs de l'application</returns>
    Public Function getPlayerList() As List(Of Player)
        Return (playerList)
    End Function

End Module
