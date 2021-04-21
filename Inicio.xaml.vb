Imports System.Data.SqlClient
Imports System.Data
Imports System.Data.OleDb
Imports System.Media.SoundPlayer
Imports System.Collections.ObjectModel
Imports System.Diagnostics




Public Class Inicio


    'Create ADO.NET objects.
    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader
    Private results As String




    Private Sub Inicio_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        Dim Caso As New LAFCDCasos
        InitializeComponent()

        dtCasos.DataContext = Caso.ListarCasos.Tables("Casos")

    End Sub
    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)

    End Sub
    Private Sub TextBox_TextChanged(sender As Object, e As TextChangedEventArgs)
        'cambio para subir a la rama
    End Sub

    Private Sub DataGrid_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)

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
        Dim Caso As New LAFCDCasos
        Dim Nuevo As New EntidadCaso(0, txtNumeroCaso.Text, txtPropietario.Text, txtExpediente.Text, DateAndTime.Today, "System", DateAndTime.Today, "System")

        Caso.InsertarCaso(Nuevo)

        'Cargamos los casos
        dtCasos.DataContext = Caso.ListarCasos.Tables("Casos")


    End Sub

    Private Sub btnGuardarPersona_Click(sender As Object, e As RoutedEventArgs) Handles btnGuardarPersona.Click
        Dim Caso As New LAFCDCasos
        Dim Persona As New LAFCDPersona

        'Cargamos los casos
        dtCasos.DataContext = Caso.ListarCasos.Tables("Casos")
        dtPersona.DataContext = Persona.ListarPersonas(2).Tables("Persona")
    End Sub

    Private Sub dtCasos_MouseDoubleClick(sender As Object, e As MouseButtonEventArgs) Handles dtCasos.MouseDoubleClick
        Dim Msg, Style, Title, Ctxt, Response, MyString
        Msg = "Va a editar el registro,  Desea Continuar?"    ' Define message.
        Style = vbYesNo     ' Define buttons.
        Title = "Confirmacion"    ' Define title.
        Ctxt = 1000    ' Define topic context. 
        ' Display message.
        Response = MessageBox.Show(Msg, Title, Style)

        If Response = vbYes Then    ' User chose Yes.
            txtNumeroCaso.Text = dtCasos.SelectedItem.GetHashCode



        Else    ' User chose No.
            MyString = "No"    ' Perform some action.
        End If
    End Sub
End Class
