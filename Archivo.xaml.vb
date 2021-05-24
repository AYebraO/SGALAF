Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Windows
Imports Microsoft.Win32

Public Class Archivo
    Public IdPersona As Integer
    Public NombrePersona As String
    Dim nombrearchivo As String
    Dim intArchivo As Integer
    'Public Sub New(idPersona As String)
    'Me.IdPersona = idPersona
    'End Sub

    Private Sub btnAbrirArchivo_Click(sender As Object, e As RoutedEventArgs) Handles btnAbrirArchivo.Click
        Dim AbrirArchivo As OpenFileDialog = New OpenFileDialog()
        AbrirArchivo.Multiselect = True
        AbrirArchivo.Filter = "Audio files (*.mp3)|*.mp3|All files (*.*)|*.*"
        AbrirArchivo.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        If (AbrirArchivo.ShowDialog() IsNot Nothing) Then
            lblArchivo.Content = AbrirArchivo.FileName
            nombrearchivo = AbrirArchivo.SafeFileName
            melAudio.Source = New Uri(AbrirArchivo.FileName)
        End If

    End Sub
    Private Sub Element_MediaOpened(ByVal sender As Object, ByVal args As RoutedEventArgs)
        slrProgreso.Maximum = melAudio.NaturalDuration.TimeSpan.TotalMilliseconds
    End Sub
    Private Sub Element_MediaEnded(ByVal sender As Object, ByVal args As RoutedEventArgs)
        melAudio.Stop()
    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        Dim Archivo As New LAFCDArchivo

        InitializeComponent()
        lblPersona.Content = NombrePersona
        dtArchivo.DataContext = Archivo.ListarArchivos(IdPersona).Tables("Archivo")

    End Sub

    Private Sub btnPlay_Click(sender As Object, e As RoutedEventArgs) Handles btnPlay.Click
        Dim data As Byte() = Nothing
        Dim path As String
        Dim idarchivo As Int32
        Dim archivo As New LAFCDArchivo
        Dim Conexion As New LAFConexion
        If lblArchivo.Content Is "" And Not dtArchivo.SelectedIndex = -1 Then
            Try

                idarchivo = dtArchivo.SelectedItem(0)
                Using cnn = Conexion.Conectar()
                    Dim cmd As SqlCommand = cnn.CreateCommand()
                    cmd.CommandText = "SELECT archivo from Archivo WHERE idArchivo=" + idarchivo.ToString
                    cnn.Open()

                    Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)

                    ' Leemos el registro.

                    dr.Read()
                    Dim bufferSize As Integer = Convert.ToInt32(dr.GetBytes(0, 0, Nothing, 0, 0))
                    data = New Byte(bufferSize - 1) {}
                    dr.GetBytes(0, 0, data, 0, bufferSize)

                    dr.Close()

                End Using
                path = "C:\temp\" + dtArchivo.SelectedItem(2).ToString
                If Not File.Exists(path) Then
                    WriteBinaryFile(path, data)
                End If

                melAudio.Source = New Uri(path)
            Catch ex As Exception
                MessageBox.Show(ex.Message)

            End Try
        End If


        melAudio.Play()

    End Sub

    Private Sub btnPause_Click(sender As Object, e As RoutedEventArgs) Handles btnPause.Click
        melAudio.Pause()
    End Sub

    Private Sub btnStop_Click(sender As Object, e As RoutedEventArgs) Handles btnStop.Click
        melAudio.Stop()
    End Sub

    Private Sub btnvolmas_Click(sender As Object, e As RoutedEventArgs) Handles btnvolmas.Click
        Dim x As Decimal
        If melAudio.Volume > 0 Then
            x = melAudio.Volume + 0.1
            melAudio.Volume = x
        End If

    End Sub

    Private Sub btnVolmenos_Click(sender As Object, e As RoutedEventArgs) Handles btnVolmenos.Click
        Dim x As Decimal
        If melAudio.Volume < 1 Then
            x = melAudio.Volume - 0.1
            melAudio.Volume = x
        End If
    End Sub

    Private Sub SeekToMediaPosition(ByVal sender As Object, ByVal args As RoutedPropertyChangedEventArgs(Of Double))
        Dim SliderValue As Integer = CType(slrProgreso.Value, Integer)

        Dim ts As New TimeSpan(0, 0, 0, 0, SliderValue)
        melAudio.Position = ts
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As RoutedEventArgs) Handles btnGuardar.Click

        Dim filename As String = lblArchivo.Content
        Dim Response As String
        Dim Archivo As New LAFCDArchivo

        If lblArchivo.Content IsNot "" Then
            Dim fs As Stream = File.OpenRead(filename)
            Dim br As New BinaryReader(fs)
            Dim bytes As Byte() = br.ReadBytes(fs.Length)

            Dim nuevoArchivo As New EntidadArchivo(0, IdPersona, nombrearchivo, 0, bytes _
            , DateAndTime.Today, "System", DateAndTime.Today, "System")

            Archivo.InsertarArchivo(nuevoArchivo)
            dtArchivo.DataContext = Archivo.ListarArchivos(IdPersona).Tables("Archivo")
        Else
            Response = MessageBox.Show("Debe ingresar un Nombre o una referencia para la persona", "Advertencia")
        End If

    End Sub

    Private Shared Sub WriteBinaryFile(ByVal fileName As String, ByVal data As Byte())

        ' Comprobación de los valores de los parámetros.
        '
        If (String.IsNullOrEmpty(fileName)) Then _
        Throw New ArgumentException("No se ha especificado el archivo de destino.", "fileName")

        If (data Is Nothing) Then _
            Throw New ArgumentException("Los datos no son válidos para crear un archivo.", "data")

        ' Crear el archivo. Se producirá una excepción si ya existe
        ' un archivo con el mismo nombre.
        Using fs As New IO.FileStream(fileName, IO.FileMode.CreateNew, IO.FileAccess.Write)

            ' Crea el escritor para la secuencia.
            Dim bw As New IO.BinaryWriter(fs)

            ' Escribir los datos en la secuencia.
            bw.Write(data)

        End Using

    End Sub

    Private Sub dtArchivo_MouseDoubleClick(sender As Object, e As MouseButtonEventArgs) Handles dtArchivo.MouseDoubleClick
        Dim Msg, Style, Title, Ctxt, Response, MyString

        Dim Palabra As New LAFCDPalabras
        Dim Archivo As New LAFCDArchivo
        If dtArchivo.SelectedItem IsNot Nothing Then

            Msg = "Va a Agregar palabras y textos al archivo Seleccionado,  esta seguro que Desea Continuar?"    ' Define message.
            Style = vbYesNo     ' Define buttons.
            Title = "Confirmacion"    ' Define title.
            Ctxt = 1000    ' Define topic context. 
            ' Display message.
            Response = MessageBox.Show(Msg, Title, Style)
            If Response = vbYes Then
                dtPalabras.Columns.Clear()


                lblArchivoOrigen.Content = dtArchivo.Columns(2).GetCellContent(dtArchivo.SelectedItem)
                lblIdArchivo.Content = dtArchivo.Columns(0).GetCellContent(dtArchivo.SelectedItem)
                intArchivo = CInt(lblIdArchivo.Content.Text)

                dtPalabras.DataContext = Palabra.ListarPalabras(intArchivo).Tables("Palabra")
                'ocultarColumnas()
                LimpiarControlesP()

            Else    ' User chose No.
                MyString = "No"    ' Perform some action.
            End If
        End If
        'dtArchivo.DataContext = Archivo.ListarArchivos.Tables("Archivos")
        'dtArchivo.SelectedItem = Nothing
        'ocultarColumnasC()
    End Sub

    Private Sub txtGuardarPalabra_Click(sender As Object, e As RoutedEventArgs) Handles txtGuardarPalabra.Click
        Dim Response As String
        Dim Caso As New LAFCDCasos
        Dim Palabra As New LAFCDPalabras
        If txtTextoPalabra.Text IsNot "" Then
            Dim nuevaPalabra As New EntidadPalabra(0, intArchivo, txtTextoPalabra.Text _
            , CDec(txtFormante1.Text.ToString), CDec(txtFormante2.Text.ToString), CDec(txtFormante3.Text.ToString) _
            , CDec(txtFormante4.Text.ToString), CDec(txtTono.Text.ToString) _
            , CDec(txtIntensidad.Text.ToString), CDec(txtPulsos.Text.ToString) _
            , DateAndTime.Today, "System", DateAndTime.Today, "System")
            Palabra.InsertarPalabra(nuevaPalabra)
            LimpiarControlesP()
        Else
            Response = MessageBox.Show("Debe ingresar una palabra o texto para el archivo ", "Advertencia")
        End If

        'Cargamos los casos y las personas
        dtPalabras.DataContext = Palabra.ListarPalabras(intArchivo).Tables("Palabra")
        LimpiarControlesP()

    End Sub

    Private Sub LimpiarControlesP()
        txtTextoPalabra.Text = ""
        txtFormante1.Text = ""
        txtFormante2.Text = ""
        txtFormante3.Text = ""
        txtFormante4.Text = ""
        txtTono.Text = ""
        txtIntensidad.Text = ""
        txtPulsos.Text = ""

    End Sub
End Class
