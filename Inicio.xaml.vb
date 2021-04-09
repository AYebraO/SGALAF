Imports System.Data.SqlClient


Public Class Inicio
    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)

    End Sub
    Private Sub TextBox_TextChanged(sender As Object, e As TextChangedEventArgs)
        'cambio para subir a la rama
    End Sub

    Private Sub DataGrid_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)

    End Sub

    Private Sub btnGuardarPersona_Click(sender As Object, e As RoutedEventArgs) Handles btnGuardarPersona.Click


    End Sub

    Private Sub txtEdad_KeyUp(sender As Object, e As KeyEventArgs) Handles txtEdad.KeyUp
        If Not IsNumeric(txtEdad.Text) Then
            txtEdad.Clear()
        ElseIf txtEdad.Text > 100 Then
            txtEdad.Clear()
        End If
    End Sub


    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)



        Dim Msg, Style, Title, Ctxt, Response, MyString
        Msg = "Agregar nuevo caso,  Deseas Continuar?"    ' Define message.
        Style = vbYesNo     ' Define buttons.
        Title = "Confirmacion"    ' Define title.
        Ctxt = 1000    ' Define topic context. 
        ' Display message.
        Response = MessageBox.Show(Msg, Title, Style)

        If Response = vbYes Then    ' User chose Yes.
            MyString = "Yes"    ' Perform some action.
        Else    ' User chose No.
            MyString = "No"    ' Perform some action.
        End If
    End Sub

    Private Sub btnGuardarCaso_Click(sender As Object, e As RoutedEventArgs) Handles btnGuardarCaso.Click

    End Sub
End Class
