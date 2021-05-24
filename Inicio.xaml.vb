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
    Private intCaso As Integer
    Private IntPersona As Integer

    Private Sub Inicio_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded

        Dim Caso As New LAFCDCasos

        InitializeComponent()

        dtCasos.DataContext = Caso.ListarCasos.Tables("Casos")
        ocultarColumnasC()


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
        ocultarColumnasC()
        'Dim Msg, Style, Title, Ctxt, Response, MyString
        'Msg = "Agregar nuevo caso,  Deseas Continuar?"    ' Define message.
        'Style = vbYesNo     ' Define buttons.
        'Title = "Confirmacion"    ' Define title.
        'Ctxt = 1000    ' Define topic context. 
        ' Display message.
        'Response = MessageBox.Show(Msg, Title, Style)

        ' If Response = vbYes Then    ' User chose Yes.
        'MyString = "Yes"    ' Perform some action.
        'Else    ' User chose No.
        ' MyString = "No"    ' Perform some action.
        ' End If
    End Sub

    Private Sub btnGuardarCaso_Click(sender As Object, e As RoutedEventArgs) Handles btnGuardarCaso.Click
        Dim Caso As New LAFCDCasos
        Dim Nuevo As New EntidadCaso(0, txtNumeroCaso.Text, cboPropietario.Text, txtExpediente.Text, DateAndTime.Today, "System", DateAndTime.Today, "System")

        If Not txtNumeroCaso.Text = "" And Not txtExpediente.Text = "" Then
            Caso.InsertarCaso(Nuevo)

            'Cargamos los casos
            dtCasos.DataContext = Caso.ListarCasos.Tables("Casos")
            ocultarColumnasC()
        Else
            MessageBox.Show("Los campos de Numero de caso y Expediente son obligatorios...", "Error")
        End If


    End Sub

    Private Sub btnGuardarPersona_Click(sender As Object, e As RoutedEventArgs) Handles btnGuardarPersona.Click
        Dim Response As String
        Dim Caso As New LAFCDCasos
        Dim Persona As New LAFCDPersona
        If txtNombre.Text IsNot "" Then
            Dim nuevaPersona As New EntidadPersona(0, intCaso, txtNombre.Text, cboGenero.Text _
            , txtEdad.Text, txtAcento.Text, txtRitmo.Text, txtPausas.Text, txtTono.Text _
            , txtMuletillas.Text, txtLenguaje.Text, txtEducacion.Text _
            , DateAndTime.Today, "System", DateAndTime.Today, "System")
            Persona.InsertarPersona(nuevaPersona)
            LimpiarControlesP()
        Else
            Response = MessageBox.Show("Debe ingresar minimo un Nombre o una referencia para la persona", "Advertencia")
        End If

        'Cargamos los casos y las personas
        dtCasos.DataContext = Caso.ListarCasos.Tables("Casos")
        dtCasos.Columns(0).Visibility = Visibility.Collapsed
        dtPersona.DataContext = Persona.ListarPersonas(intCaso).Tables("Persona")
        ocultarColumnas()
        LimpiarControlesP()
        ocultarColumnasC()
    End Sub

    Private Sub dtCasos_MouseDoubleClick(sender As Object, e As MouseButtonEventArgs) Handles dtCasos.MouseDoubleClick
        'Dim Msg, Style, Title, Ctxt, Response, MyString
        Dim Title
        Dim Persona As New LAFCDPersona
        Dim Caso As New LAFCDCasos
        If dtCasos.SelectedItem IsNot Nothing Then

            'Msg = "Va a Agregar personas al Caso Seleccionado,  esta seguro que Desea Continuar?"    ' Define message.
            'Style = vbYesNo     ' Define buttons.
            'Title = "Confirmacion"    ' Define title.
            'Ctxt = 1000    ' Define topic context. 
            ' Display message.
            'Response = MessageBox.Show(Msg, Title, Style)
            'If Response = vbYes Then
            dtPersona.Columns.Clear()

            'txtNumeroCaso.Text = dtCasos.SelectedItem.GetHashCode
            cvsPersona.IsEnabled = True
            Title = dtCasos.Columns(1).GetCellContent(dtCasos.SelectedItem)
            lblCaso.Content = Title.text 'dtCasos.Columns(2).GetCellContent(dtCasos.SelectedItem)
            lblIdCaso.Content = dtCasos.Columns(0).GetCellContent(dtCasos.SelectedItem)
            intCaso = CInt(lblIdCaso.Content.Text)


            dtPersona.DataContext = Persona.ListarPersonas(intCaso).Tables("Persona")
            ocultarColumnas()
            LimpiarControlesP()

            'Else    ' User chose No.
            '   MyString = "No"    ' Perform some action.
            'End If
        End If
        'dtCasos.DataContext = Caso.ListarCasos.Tables("Casos")
        'dtCasos.SelectedItem = Nothing
        'ocultarColumnasC()

    End Sub

    Private Sub LimpiarControlesP()
        txtNombre.Text = ""
        cboGenero.SelectedIndex = 0
        txtRitmo.Text = ""
        txtTono.Text = ""
        txtLenguaje.Text = ""
        txtEdad.Text = ""
        txtAcento.Text = ""
        txtPausas.Text = ""
        txtMuletillas.Text = ""
        txtEducacion.Text = ""

    End Sub

    Private Sub ocultarColumnas()

        'dtPersona.Columns(0).Visibility = Visibility.Hidden
        dtPersona.Columns(1).Visibility = Visibility.Hidden
        dtPersona.Columns(12).Visibility = Visibility.Hidden
        dtPersona.Columns(13).Visibility = Visibility.Hidden
        dtPersona.Columns(14).Visibility = Visibility.Hidden
        dtPersona.Columns(15).Visibility = Visibility.Hidden
    End Sub



    Private Sub ocultarColumnasC()
        If dtCasos.Items.Count > 0 Then
            'dtCasos.Columns(0).Visibility = 1
            dtCasos.Columns(4).Visibility = Visibility.Hidden
            dtCasos.Columns(5).Visibility = Visibility.Hidden
            dtCasos.Columns(6).Visibility = Visibility.Hidden
            dtCasos.Columns(7).Visibility = Visibility.Hidden
        End If

    End Sub

    Private Sub dtPersona_MouseDoubleClick(sender As Object, e As MouseButtonEventArgs) Handles dtPersona.MouseDoubleClick
        Dim persona As String

        persona = dtPersona.Columns(2).GetCellContent(dtPersona.SelectedItem).ToString
        IdPersona.Content = dtPersona.Columns(0).GetCellContent(dtPersona.SelectedItem)
        IntPersona = CInt(IdPersona.Content.Text)
        Dim C As Archivo = New Archivo()
        C.IdPersona = IntPersona
        C.NombrePersona = persona
        C.Show()
    End Sub
    Private Sub OnKeyDownHandler2(ByVal sender As Object, ByVal e As KeyEventArgs)

        If (e.Key = Key.F2) Then
            'Cargamos los valores sobre los controles de casos
            btnGuardarPersona.Visibility = Visibility.Hidden
            btnActualizarPersona.Visibility = Visibility.Visible
            btnCancelarPpl.Visibility = Visibility.Visible

            IdPersona.Content = dtPersona.SelectedItem(0)
            IntPersona = IdPersona.Content
            txtNombre.Text = dtPersona.SelectedItem(2)
            Dim index As Integer
            index = cboGenero.FindName(dtPersona.SelectedItem(3).ToString)

            If index Then
                cboGenero.SelectedIndex = index
            Else
                cboGenero.SelectedIndex = 0
            End If
            txtEdad.Text = dtPersona.SelectedItem(4)
            txtAcento.Text = dtPersona.SelectedItem(5)
            txtRitmo.Text = dtPersona.SelectedItem(6)
            txtPausas.Text = dtPersona.SelectedItem(7)
            txtTono.Text = dtPersona.SelectedItem(8)
            txtMuletillas.Text = dtPersona.SelectedItem(9)
            txtLenguaje.Text = dtPersona.SelectedItem(10)
            txtEducacion.Text = dtPersona.SelectedItem(11)

        End If
    End Sub
    Private Sub OnKeyDownHandler(ByVal sender As Object, ByVal e As KeyEventArgs)
        Dim IdCaso As Integer
        If (e.Key = Key.F2) Then
            'Cargamos los valores sobre los controles de casos
            btnGuardarCaso.Visibility = Visibility.Hidden
            btnActualizar.Visibility = Visibility.Visible
            btnCancelar.Visibility = Visibility.Visible

            IdCaso = dtCasos.SelectedItem(0)
            intCaso = IdCaso
            txtNumeroCaso.Text = dtCasos.SelectedItem(1)

            Dim index As Integer
            index = cboPropietario.FindName(dtCasos.SelectedItem(2).ToString)

            If index Then
                cboPropietario.SelectedIndex = index
            Else
                cboPropietario.SelectedIndex = 0
            End If
            txtExpediente.Text = dtCasos.SelectedItem(3)

        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As RoutedEventArgs) Handles btnCancelar.Click
        txtNumeroCaso.Text = ""
        txtExpediente.Text = ""
        btnGuardarCaso.Visibility = Visibility.Visible
        btnActualizar.Visibility = Visibility.Hidden
        btnCancelar.Visibility = Visibility.Hidden
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As RoutedEventArgs) Handles btnActualizar.Click
        Dim Caso As New LAFCDCasos
        Dim Nuevo As New EntidadCaso(intCaso, txtNumeroCaso.Text, cboPropietario.Text, txtExpediente.Text, DateAndTime.Today, "System", DateAndTime.Today, "Modificado")
        Dim msg, style, title, response As String

        msg = "Esta seguro de actualizar la informacion del Caso Seleccionado?"    ' Define message.
        style = vbYesNo     ' Define buttons.
        Title = "Confirmacion"    ' Define title.

        response = MessageBox.Show(Msg, Title, Style)
        If Response = vbYes Then
            Caso.ActualizarCaso(Nuevo)
        End If


        'Cargamos los casos
        dtCasos.DataContext = Caso.ListarCasos.Tables("Casos")
        ocultarColumnasC()
        txtNumeroCaso.Text = ""
        txtExpediente.Text = ""
        btnGuardarCaso.Visibility = Visibility.Visible
        btnActualizar.Visibility = Visibility.Hidden
        btnCancelar.Visibility = Visibility.Hidden

    End Sub

    Private Sub btnActualizarPersona_Click(sender As Object, e As RoutedEventArgs) Handles btnActualizarPersona.Click
        Dim Persona As New LAFCDPersona
        Dim Nuevo As New EntidadPersona(IntPersona, intCaso, txtNombre.Text, cboGenero.Text, txtEdad.Text, txtAcento.Text _
            , txtRitmo.Text, txtPausas.Text, txtTono.Text, txtMuletillas.Text, txtLenguaje.Text, txtEducacion.Text _
            , DateAndTime.Today, "System", DateAndTime.Today, "Modificado")
        Dim msg, style, title, response As String

        msg = "Esta seguro de actualizar la informacion de la Persona seleccionada?"    ' Define message.
        style = vbYesNo     ' Define buttons.
        title = "Confirmacion"    ' Define title.

        response = MessageBox.Show(msg, title, style)
        If response = vbYes Then
            Persona.ActualizarPersona(Nuevo)
        End If


        'Cargamos los casos
        dtPersona.DataContext = Persona.ListarPersonas(intCaso).Tables("Persona")
        ocultarColumnas()
        LimpiarControlesP()


    End Sub

    Private Sub btnCancelarPpl_Click(sender As Object, e As RoutedEventArgs) Handles btnCancelarPpl.Click
        LimpiarControlesP()
        btnGuardarPersona.Visibility = Visibility.Visible
        btnActualizarPersona.Visibility = Visibility.Hidden
        btnCancelarPpl.Visibility = Visibility.Hidden
    End Sub


End Class
