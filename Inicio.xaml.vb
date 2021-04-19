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

    'Defines the customer object
    Public Class Persona
        Public Property Nombre() As String
        Public Property Edad() As Int32
        Public Property Genero() As String
        Public Property Acento() As String
        Public Property ritmo() As String
    End Class


    Private Sub Inicio_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded

        myConn = New SqlConnection("Initial Catalog=dbLAF;" &
                                   "Data Source=192.168.234.8;Integrated Security=SSPI;")
        myCmd = myConn.CreateCommand
        myCmd.CommandText = "SELECT nombre, edad FROM Persona"

        'Open the connection.
        myConn.Open()

        myReader = myCmd.ExecuteReader()



        'Concatenate the query result into a string.
        Do While myReader.Read()
            results = results & myReader.GetString(0) & vbTab &
            myReader.GetInt32(1) & vbLf
        Loop
        'Display results.
        MessageBox.Show(results)

        'Close the reader and the database connection.
        myReader.Close()
        myConn.Close()

        ' dtPersona.SetBinding(Persona, "Persona")
    End Sub
    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)

    End Sub
    Private Sub TextBox_TextChanged(sender As Object, e As TextChangedEventArgs)
        'cambio para subir a la rama
    End Sub

    Private Sub DataGrid_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)

    End Sub

    Private Sub btnGuardarPersona_Click(sender As Object, e As RoutedEventArgs) Handles btnGuardarPersona.Click
        InitializeComponent()

        'GetData() creates a collection of Customer data from a database
        'Dim custdata As ObservableCollection(Of Persona) = GetData()

        'Bind the DataGrid to the customer data
        'dtPersona.DataContext = custdata


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

    'Private Sub Persona(sender As Object, e As AddingNewItemEventArgs)

    'End Sub

    Private Sub btnReproducirAudio_Click(sender As Object, e As RoutedEventArgs) Handles btnReproducirAudio.Click


    End Sub
End Class
