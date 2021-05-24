Imports System.IO

Class MainWindow

    Private Sub Button_Click_1(sender As Object, e As RoutedEventArgs)
        Dim C As Inicio
        C = New Inicio
        C.Show()

    End Sub

    Private Sub Button_Click_Buscar(sender As Object, e As RoutedEventArgs)
        Dim C As Busqueda
        C = New Busqueda
        C.Show()
    End Sub

    Private Sub Window_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        'Eliminamos archivos de la carpeta temporal para evitar dejar rezagos 
        Dim sourceDir As String = "c:\temp"


        Try
            Dim picList As String() = Directory.GetFiles(sourceDir, "*.*")

            For Each f As String In picList
                File.Delete(f)
            Next

        Catch dirNotFound As DirectoryNotFoundException
            Console.WriteLine(dirNotFound.Message)
        End Try

    End Sub

    Private Sub Window_Initialized(sender As Object, e As EventArgs)
        'Eliminamos archivos de la carpeta temporal para evitar dejar rezagos 
        Dim sourceDir As String = "c:\temp"


        Try
            Dim picList As String() = Directory.GetFiles(sourceDir, "*.*")

            For Each f As String In picList
                File.Delete(f)
            Next

        Catch dirNotFound As DirectoryNotFoundException
            Console.WriteLine(dirNotFound.Message)
        End Try
    End Sub
End Class
