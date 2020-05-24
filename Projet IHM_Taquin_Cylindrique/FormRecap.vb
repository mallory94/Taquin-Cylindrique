Public Class FormRecap
    Private playerList As List(Of Player)
    Dim topIndex1 As String 'topIndex de la listBox1
    Dim topIndex2 As String 'topIndex de la listBox2

    ''' <summary>
    ''' trie dans l'ordre alphabétique la listeBox des joueurs enregistrés et synchronise la listeBox des temps sur celle des noms
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub BtnTriNom_Click(sender As Object, e As EventArgs) Handles BtnTriNom.Click
        Dim tmpBestTime As Integer
        If ListBox1.Sorted = False Then
            ListBox1.Sorted = True
            ListBox2.Items.Clear()
            For i = 0 To (ListBox1.Items.Count - 1)
                tmpBestTime = findPlayer(ListBox1.Items(i)).getBestTime()
                If tmpBestTime <> 0 Then
                    ListBox2.Items.Add(findPlayer(ListBox1.Items(i)).getBestTime())
                Else
                    ListBox2.Items.Add("Aucunes parties gagnées")
                End If
            Next
        End If
    End Sub

    ''' <summary>
    ''' charge les combobox quand le formulaire récapitulatif apparait
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub FormRecap_Visi(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        If Me.Visible = True Then
            loadListBoxesAndComboBox()
        End If
    End Sub

    ''' <summary>
    ''' charge les combobox avec les données des joueurs
    ''' </summary>
    Private Sub loadListBoxesAndComboBox()
        Dim tmpBestTime As Integer
        Dim tmpName As String

        ComboBox1.Items.Clear()
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        playerList = getPlayerList()
        For Each player As Player In playerList
            tmpName = player.getName()
            ListBox1.Items.Add(tmpName)
            ComboBox1.Items.Add(tmpName)
            tmpBestTime = player.getBestTime()
            If tmpBestTime <> 0 Then
                ListBox2.Items.Add(tmpBestTime)
            Else
                ListBox2.Items.Add("Aucunes parties gagnées")
            End If

        Next

        ComboBox1.Sorted = True
        topIndex1 = ListBox1.TopIndex
        topIndex2 = ListBox2.TopIndex

    End Sub

    ''' <summary>
    ''' trie les joueurs par temps
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub BtnTriParTemps_Click(sender As Object, e As EventArgs) Handles BtnTriParTemps.Click
        ListBox1.Sorted = False
        ListBox1.Items.Clear()
        Dim tmpPlayerList As New List(Of Player)
        Dim tmpListBox As New ListBox
        Dim tmpBestTime As Integer

        For Each player As Player In playerList
            tmpPlayerList.Add(player)
        Next
        For Each player As Player In playerList
            tmpBestTime = player.getBestTime
            If (tmpBestTime <> 0) Then
                tmpListBox.Items.Add(tmpBestTime)
            End If
        Next


        Dim items = (From item In tmpListBox.Items Order By Val(item) Select item).ToArray

        tmpListBox.Items.Clear()

        ListBox2.Items.Clear()
        ListBox2.Items.AddRange(items)

        For i = 0 To (ListBox2.Items.Count - 1)
            For Each player As Player In tmpPlayerList
                If ListBox2.Items(i) = player.getBestTime() Then
                    ListBox1.Items.Add(player.getName)
                    tmpPlayerList.Remove(player)
                    Exit For
                End If
            Next
        Next

        For Each player As Player In tmpPlayerList
            ListBox1.Items.Add(player.getName)
            ListBox2.Items.Add("Aucunes parties gagnées")
        Next
    End Sub

    ''' <summary>
    ''' lors d'un clique sur un item d'un listBox, selectionne l'item de l'autre listBox qui lui correspond
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ListBoxes_SelChanged(sender As Object, e As EventArgs) _
                    Handles ListBox1.SelectedIndexChanged, ListBox2.SelectedIndexChanged
        If sender Is ListBox1 Then
            ListBox2.SelectedIndex = ListBox1.SelectedIndex()
        Else
            ListBox1.SelectedIndex = ListBox2.SelectedIndex()
        End If
    End Sub



    'synchronise les deux listes
    'Private Sub ListBoxes_Scroll() Handles Timer1.Tick
    '    If ListBox1.TopIndex <> topIndex1 Then
    '        ListBox2.TopIndex = ListBox1.TopIndex
    '    ElseIf ListBox2.TopIndex <> topIndex2 Then
    '        ListBox1.TopIndex = ListBox2.TopIndex
    '    End If

    '    topIndex1 = ListBox1.TopIndex
    '    topIndex2 = ListBox2.TopIndex
    'End Sub

    ''' <summary>
    ''' mets le focus des listes sur le joueur rechercher à partir de la combobox
    ''' </summary>
    Private Sub SearchComboBox() Handles ComboBox1.SelectedIndexChanged
        Dim tmpName As String

        tmpName = ComboBox1.SelectedItem
        For i = 0 To ListBox1.Items.Count - 1
            If ListBox1.Items(i).Equals(tmpName) Then
                ListBox1.SelectedIndex = i
            End If
        Next
    End Sub


    ''' <summary>
    ''' procede au masquage du formulaire Recap et à la mise en évidence du formulaire d'accueil
    ''' </summary>
    Private Sub fermetureFormRecap() Handles MyBase.Closing
        FormulaireAccueil.Show()
        Me.Hide()
    End Sub

    ''' <summary>
    ''' Quitte le formulaire sur un clique du bouton "quitter"
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnQuitter_Click(sender As Object, e As EventArgs) Handles btnQuitter.Click
        fermetureFormRecap()
    End Sub

    ''' <summary>
    ''' invoque une msgBox qui résume les informations du joueur sélectionner dans les listBox
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ListBox1.SelectedIndex <> -1 Then
            For Each player As Player In playerList
                If player.getName = ListBox1.SelectedItem Then
                    MsgBox(player.getInfo())
                End If
            Next
        End If
    End Sub

    Private Sub FormRecap_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = FormBorderStyle.FixedSingle 'empeche de maximiser ou minimiser le formulaire
    End Sub
End Class