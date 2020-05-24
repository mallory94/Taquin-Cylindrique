Public Class Spot
    Private button As Button
    Shared ReadOnly voidButtonNumber As Integer = 16

    Sub New(ByRef btn As Button)
        button = btn
    End Sub

    ''' <summary>
    ''' le boutton du spot pour lequel est invoqué la méthode devient la case vide
    ''' </summary>
    ''' <param name="btn">bouton dont l'emplacement représente la case qui intervertir avec la case vide</param>
    Public Sub shiftInVoid(ByRef btn As Button)
        btn.Text = button.Text
        button.Text = voidButtonNumber
        btn.Visible = True
        button.Visible = False
    End Sub




    ''' <summary>
    ''' retourne la valeur contenue dans le bouton de l'emplacement
    ''' </summary>
    ''' <returns>valeur contenue dans le bouton</returns>
    Public Function value() As Integer
        Return Int(button.Text)
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="btn"></param>
    ''' <returns></returns>
    Public Function isEquals(ByRef btn As Button) As Boolean
        Return (button.Equals(btn))
    End Function

    ''' <summary>
    ''' retourne le bouton de l'emplacement
    ''' </summary>
    ''' <returns>bouton de l'emplacement</returns>
    Public Function getButton() As Button
        Return (button)
    End Function
End Class
