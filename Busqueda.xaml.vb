Imports System.Data.SqlClient

Public Class Busqueda

    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader
    Private results As String

    Private Sub Inicio_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        Dim Persona As New LAFCDPersona
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
        'MessageBox.Show(results)
        'Set the DataGrid's DataContext to be a filled DataTable




        dtPersona.DataContext = Persona.ListarPersonas(1).Tables("Persona")


        'Close the reader and the database connection.
        myReader.Close()
        myConn.Close()

    End Sub

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)

    End Sub
End Class
