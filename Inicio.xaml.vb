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
    Private Caso As New LAFCDCasos
    Private Persona As New LAFCDPersona


    Private Sub Inicio_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        InitializeComponent()
        'myConn = New SqlConnection("Initial Catalog=dbLAF;Data Source=192.168.234.8;Integrated Security=SSPI;")
        myConn = New SqlConnection("Database=dbLAF;Server=192.168.234.8;User Id=sa; Password=123; Trusted_Connection=False; MultipleActiveResultSets=true;")
        myCmd = myConn.CreateCommand
        myCmd.CommandText = "SELECT numero, Propietario FROM Caso"

        'Open the connection.
        myConn.Open()

        myReader = myCmd.ExecuteReader()





        'Concatenate the query result into a string.
        Do While myReader.Read()
            results = results & myReader.GetString(0) & vbTab &
            myReader.GetString(1) & vbLf
        Loop

        'Display results.
        MessageBox.Show(results)
        'Set the DataGrid's DataContext to be a filled DataTable
        dtCasos.DataContext = Caso.ListarCasos



        dtPersona.DataContext = Persona.ListarPersonas(2).Tables("Persona")


        'Close the reader and the database connection.
        myReader.Close()
        myConn.Close()


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

    End Sub


End Class
