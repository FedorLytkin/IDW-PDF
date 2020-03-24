Imports System
Imports System.IO
Imports System.Text
Public Class SaveAsPDF
    Public Shared ProgramID As String = "16"
    Public Shared ProgramVersion As String
    Public Shared ProgramVersionFlag As String = "2019"
    Public Shared AppVersNOTValidStrong As Boolean = False

    Public SelectPath As String
    Public find_Subfolder As Boolean
    Public save_report As Boolean
    Public sw As StreamWriter
    Public path, save_folder_path As String
    Public filename As String = "\IDW_PDF_report"
    Public invApp As Inventor.Application = Nothing
    Public Sub CadInicial()
        Try
            invApp = GetObject(, "Inventor.Application")
        Catch ex As Exception
        End Try

        ' If Inventor isn't running, start it.
        If invApp Is Nothing Then
            Try
                invApp = CreateObject("Inventor.Application")
                invApp.Visible = True
            Catch ex As Exception
                MsgBox("Inventor не работает и не может быть запущен.  Запустите Inventor повторите снова.")
                Exit Sub
            End Try
        End If
        ProgramVersion = invApp.SoftwareVersion.DisplayVersion
        AppVersNOTValidStrong = System.Text.RegularExpressions.Regex.IsMatch(ProgramVersion, ProgramVersionFlag)

    End Sub
    Private Sub СправкаToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles СправкаToolStripMenuItem.Click
        INFOrmation()
    End Sub

    Sub INFOrmation()
        Process.Start("http://www.evernote.com/l/AjImc9_PJllCx5VgATF5lcK77VUrjJjkKxs/")
    End Sub

    Private Sub ОПрограммеToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ОПрограммеToolStripMenuItem1.Click
        AboutBox1.ShowDialog()
    End Sub

    Private Sub ListBox1_DragEnter(sender As Object, e As DragEventArgs) Handles ListBox1.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.All
        End If
    End Sub

    Private Sub ListBox1_DragDrop(sender As Object, e As DragEventArgs) Handles ListBox1.DragDrop
        If This_Demo_App Then
            MsgBox("Функция не доступна для демо версии!" & vbCr & "Обратитесь к разработчику", MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim file, fileformat As String
        For Each file In e.Data.GetData(DataFormats.FileDrop)
            fileformat = file.Substring(file.LastIndexOf(".") + 1)
            If UCase(fileformat) = "IDW" Then ListBox1.Items.Add(file) 'Else MsgBox("В СПИСОК добавлять только в формате .IDW")
        Next
    End Sub

    Private Sub ВыбратьБланкToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ВыбратьБланкToolStripMenuItem.Click
        import_drawing()
    End Sub
    Sub import_drawing()
        Dim dir As String = ""
        Dim fb As New FolderBrowserDialogEx
        With fb
            .Description = "Выберите папку с чертежами"
            If .ShowDialog = System.Windows.Forms.DialogResult.OK Then
                SelectPath = .SelectedPath
            Else
                Exit Sub
            End If
        End With
        find_Subfolder = fOptions.get_regisrt_value("find_Subfolder", True)
        Dim drawings() As String
        If find_Subfolder = True Then
            drawings = System.IO.Directory.GetFiles(SelectPath, "*.idw", System.IO.SearchOption.AllDirectories)
        Else
            drawings = System.IO.Directory.GetFiles(SelectPath, "*.idw", IO.SearchOption.TopDirectoryOnly)
        End If
        For Each s1 As String In drawings
            ListBox1.Items.Add(s1)
        Next
    End Sub
    Private Sub ПеревестиБланкиToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ПеревестиБланкиToolStripMenuItem.Click
        'если сохраняем в другой папке
        If fOptions.get_regisrt_value("save_path_method", True) = False And save_folder_path Is Nothing Then
            select_save_folder_path()
            If save_folder_path IsNot Nothing Then PDF_export() Else Exit Sub
        Else
            PDF_export()
        End If
    End Sub
    Public Function AppVersNOTValidStrongMessage() As Boolean
        If Not AppVersNOTValidStrong Then MessageBox.Show($"Версия CAD-системы ({invApp.SoftwareVersion.ProductName} {ProgramVersion}) не совпадает с рекомендованной версией Inventor {ProgramVersionFlag}." & vbNewLine &
                                                          $"Обновите {System.Windows.Forms.Application.ProductName} до требуемой версии CAD системы либо установите версию Inventor{ProgramVersionFlag}",
                                                          System.Windows.Forms.Application.ProductName,
                                                          MessageBoxButtons.OK,
                                                          MessageBoxIcon.Error)
        Return AppVersNOTValidStrong
    End Function
    Sub PDF_export()
        ' Validate the input path.
        'If Not System.IO.Directory.Exists(SelectPath) Then
        '    MsgBox("You must specify a valid path.")
        '    Exit Sub
        'End If
        If ListBox1.Items.Count = 0 Then
            Exit Sub
        End If
        ' Connect to Inventor.
        If Not AppVersNOTValidStrongMessage() Then Return

        ProgressBar1.Visible = True
        ProgressBar1.Minimum = 1
        ProgressBar1.Maximum = ListBox1.Items.Count
        ProgressBar1.Value = 1
        ProgressBar1.Step = 1

        ' Get all of the drawing files in the directory and subdirectories.
        lstResults.Items.Clear()
        lstResults.Items.Add("Поиск файлов чертежей...")
        lstResults.Refresh()
        'Dim drawings() As String = System.IO.Directory.GetFiles(txtPath.Text, "*.idw", System.IO.SearchOption.AllDirectories)
        lstResults.Items.Clear()

        lstResults.Items.Add("=== Начало конвертации: всего " & ListBox1.Items.Count & " документов ===")
        Dim valid_Integer As Integer = 0
        For Each drawing As String In ListBox1.Items
            ' Skip any drawings in an "OldVersions" directory.
            If This_Demo_App And valid_Integer > 1 Then
                MsgBox("В демо версии доступна выгрузка 2 элементов из Списка!" & vbCr & "Обратитесь к разработчику программы", MessageBoxIcon.Error)
                Exit For
            End If
            If Not drawing.Contains("OldVersions") Then
                lstResults.Items.Add("Обработка: .\" & drawing.Substring(drawing.LastIndexOf("\") + 1))

                ' Make sure the list is scrolled so the bottom of the list can be seen.
                lstResults.TopIndex = lstResults.Items.Count - 1
                lstResults.Refresh()

                ' Open the drawing in Inventor
                Dim drawDoc As Inventor.DrawingDocument = Nothing
                Try
                    invApp.SilentOperation = True
                    drawDoc = invApp.Documents.Open(drawing)
                    invApp.SilentOperation = False
                Catch ex As Exception
                End Try

                If Not drawDoc Is Nothing Then
                    ' Save the PDF.

                    Dim file_name As String = System.IO.Path.ChangeExtension(drawing, "pdf")
                    If fOptions.get_regisrt_value("save_path_method", True) = False Then
                        file_name = save_folder_path & file_name.Substring(file_name.LastIndexOf("\"))
                    End If

                    If SaveAsPDF(drawDoc, file_name) Then
                        lstResults.Items(lstResults.Items.Count - 1) = "Успешно обработано: .\" & drawing.Substring(drawing.LastIndexOf("\") + 1)
                    Else
                        lstResults.Items(lstResults.Items.Count - 1) = "Ошибка при обработке: .\" & drawing.Substring(drawing.LastIndexOf("\") + 1)
                    End If
                Else
                    lstResults.Items(lstResults.Items.Count - 1) = "Ошибка при обработке: .\" & drawing.Substring(drawing.LastIndexOf("\") + 1)
                End If
                lstResults.TopIndex = lstResults.Items.Count - 1
                lstResults.Refresh()

                ' Close the drawing.
                If Not drawDoc Is Nothing Then
                    drawDoc.Close(True)
                End If
            End If
            ProgressBar1.PerformStep()
            valid_Integer += 1
        Next
        ProgressBar1.Visible = False
        lstResults.Items.Add("=== Конвертация завершена. ===")

        ' Make sure the list is scrolled so the bottom of the list can be seen.
        lstResults.TopIndex = lstResults.Items.Count - 1
        lstResults.Refresh()
    End Sub

    Sub PDF_export_ONE_DRAWING()
        ' Validate the input path.
        'If Not System.IO.Directory.Exists(SelectPath) Then
        '    MsgBox("You must specify a valid path.")
        '    Exit Sub
        'End If
        If ListBox1.Items.Count = 0 Then
            Exit Sub
        End If

        If This_Demo_App Then
            MsgBox("Функция не доступна для демо версии!" & vbCr & "Обратитесь к разработчику", MessageBoxIcon.Error)
            Exit Sub
        End If
        If Not AppVersNOTValidStrongMessage() Then Return

        ProgressBar1.Visible = True
        ProgressBar1.Minimum = 1
        ProgressBar1.Maximum = ListBox1.Items.Count
        ProgressBar1.Value = 1
        ProgressBar1.Step = 1

        ' Get all of the drawing files in the directory and subdirectories.
        lstResults.Items.Clear()
        lstResults.Items.Add("Поиск файлов чертежей...")
        lstResults.Refresh()
        'Dim drawings() As String = System.IO.Directory.GetFiles(txtPath.Text, "*.idw", System.IO.SearchOption.AllDirectories)
        lstResults.Items.Clear()

        lstResults.Items.Add("=== Начало конвертации: всего " & ListBox1.Items.Count & " документов ===")
        Dim drawing As String = ListBox1.SelectedItem
        ' Skip any drawings in an "OldVersions" directory.
        If Not drawing.Contains("OldVersions") Then
            lstResults.Items.Add("Обработка: .\" & drawing.Substring(drawing.LastIndexOf("\") + 1))

            ' Make sure the list is scrolled so the bottom of the list can be seen.
            lstResults.TopIndex = lstResults.Items.Count - 1
            lstResults.Refresh()

            ' Open the drawing in Inventor
            Dim drawDoc As Inventor.DrawingDocument = Nothing
            Try
                invApp.SilentOperation = True
                drawDoc = invApp.Documents.Open(drawing)
                invApp.SilentOperation = False
            Catch ex As Exception
            End Try

            If Not drawDoc Is Nothing Then
                ' Save the PDF.

                Dim file_name As String = System.IO.Path.ChangeExtension(drawing, "pdf")
                If fOptions.get_regisrt_value("save_path_method", True) = False Then
                    file_name = save_folder_path & file_name.Substring(file_name.LastIndexOf("\"))
                End If

                If SaveAsPDF(drawDoc, file_name) Then
                    lstResults.Items(lstResults.Items.Count - 1) = "Успешно обработано: .\" & drawing.Substring(drawing.LastIndexOf("\") + 1)
                Else
                    lstResults.Items(lstResults.Items.Count - 1) = "Ошибка при обработке: .\" & drawing.Substring(drawing.LastIndexOf("\") + 1)
                End If
            Else
                lstResults.Items(lstResults.Items.Count - 1) = "Ошибка при обработке: .\" & drawing.Substring(drawing.LastIndexOf("\") + 1)
            End If
            lstResults.TopIndex = lstResults.Items.Count - 1
            lstResults.Refresh()

            ' Close the drawing.
            If Not drawDoc Is Nothing Then
                drawDoc.Close(True)
            End If
        End If
        ProgressBar1.PerformStep()
        ProgressBar1.Visible = False
        lstResults.Items.Add("=== Конвертация завершена. ===")

        ' Make sure the list is scrolled so the bottom of the list can be seen.
        lstResults.TopIndex = lstResults.Items.Count - 1
        lstResults.Refresh()
    End Sub
    Private Function SaveAsPDF(ByVal DrawingDoc As Inventor.DrawingDocument, ByVal Filename As String) As Boolean
        Try
            Dim invApp As Inventor.Application = DrawingDoc.Parent

            ' Get the PDF translator Add-In.
            Dim PDFAddIn As Inventor.TranslatorAddIn
            PDFAddIn = invApp.ApplicationAddIns.ItemById("{0AC6FD96-2F4D-42CE-8BE0-8AEA580399E4}")

            Dim oContext As Inventor.TranslationContext
            oContext = invApp.TransientObjects.CreateTranslationContext
            oContext.Type = Inventor.IOMechanismEnum.kFileBrowseIOMechanism

            ' Create a NameValueMap object
            Dim oOptions As Inventor.NameValueMap
            oOptions = invApp.TransientObjects.CreateNameValueMap

            ' Create a DataMedium object
            Dim oDataMedium As Inventor.DataMedium
            oDataMedium = invApp.TransientObjects.CreateDataMedium

            ' Check whether the translator has 'SaveCopyAs' options
            If PDFAddIn.HasSaveCopyAsOptions(DrawingDoc, oContext, oOptions) Then
                ' Options for drawings...
                oOptions.Value("All_Color_AS_Black") = 0
                oOptions.Value("Sheet_Range") = Inventor.PrintRangeEnum.kPrintAllSheets

                'oOptions.Value("Remove_Line_Weights") = 0
                'oOptions.Value("Vector_Resolution") = 400
                'oOptions.Value("Custom_Begin_Sheet") = 2
                'oOptions.Value("Custom_End_Sheet") = 4
            End If

            'Set the destination file name
            oDataMedium.FileName = Filename

            'Publish document.
            Call PDFAddIn.SaveCopyAs(DrawingDoc, oContext, oOptions, oDataMedium)

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub НастройкиToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles НастройкиToolStripMenuItem.Click
        fOptions.ShowDialog()
    End Sub

    Private Sub ОткрытьОтчетToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If File.Exists(path) Then
            Process.Start(path)
        End If
    End Sub

    Public Sub Report_txt()
        path = System.Windows.Forms.Application.StartupPath & filename & ".txt"
        If Not File.Exists(path) Then
            sw = File.CreateText(path)
        End If
    End Sub
    Public Sub Write_Report_txt(text As String)
        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter(path, True)
        file.WriteLine(text)
        file.Close()
    End Sub

    Private Sub ОчиститьСписокToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ОчиститьСписокToolStripMenuItem.Click
        ListBox1.Items.Clear()
    End Sub

    Private Sub УдалитьЗаписьToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles УдалитьЗаписьToolStripMenuItem.Click
        If This_Demo_App Then
            MsgBox("Функция не доступна для демо версии!" & vbCr & "Обратитесь к разработчику", MessageBoxIcon.Error)
            Exit Sub
        End If

        ListBox1.Items.Remove(ListBox1.SelectedItem)
    End Sub

    Private Sub ОчиститьСписокToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ОчиститьСписокToolStripMenuItem1.Click
        ListBox1.Items.Clear()
    End Sub

    Private Sub УдалитьВыделенныеToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ListBox1.Items.Remove(ListBox1.SelectedItems)
    End Sub


    Private Sub ListBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles ListBox1.KeyDown
        If e.KeyCode = Keys.Delete Then
            ListBox1.Items.Remove(ListBox1.SelectedItem)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Dim str As String = "C:\Users\aidarhanov.n.VEZA-SPB\Cloud Maill\Параметризация\0012.063.03.02.000 CБ - Ротор\0012.063.03.02.000 CБ - Ротор\0012.063.03.02.000 СБ Ротор.idw"
        str = str.Substring(str.LastIndexOf("\") + 1)
    End Sub



    Private Sub ОткрытьЧертежToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ОткрытьЧертежToolStripMenuItem.Click
        open_drawind()
    End Sub
    Sub open_drawind()

        If Not AppVersNOTValidStrongMessage() Then Return

        Dim Drawing As String = ListBox1.SelectedItem
        ' Open the drawing in Inventor
        Dim drawDoc As Inventor.DrawingDocument = Nothing
        Try
            invApp.SilentOperation = True
            drawDoc = invApp.Documents.Open(Drawing)
            invApp.SilentOperation = False
        Catch ex As Exception
        End Try

    End Sub
    Private Sub ОткрытьPDFЧертежаToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ОткрытьPDFЧертежаToolStripMenuItem.Click
        Try
            Dim pdf_file As String = System.IO.Path.ChangeExtension(ListBox1.SelectedItem, "pdf")
            If fOptions.get_regisrt_value("save_path_method", True) = False Then
                pdf_file = save_folder_path & pdf_file.Substring(pdf_file.LastIndexOf("\"))
            End If
            If System.IO.File.Exists(pdf_file) Then
                Process.Start(pdf_file)
            Else
                MsgBox("Файла еще не существует.") 'Создать PDF?
                Exit Sub
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        If ListBox1.Items.Count = 0 Then
            ОткрытьPDFЧертежаToolStripMenuItem.Enabled = False
            ОткрытьЧертежToolStripMenuItem.Enabled = False
            КонвертироватьВыделенноеToolStripMenuItem.Enabled = False
            КонвертироватьВсеToolStripMenuItem.Enabled = False
            УдалитьЗаписьToolStripMenuItem.Enabled = False
            ОчиститьСписокToolStripMenuItem1.Enabled = False
        Else
            ОткрытьPDFЧертежаToolStripMenuItem.Enabled = True
            ОткрытьЧертежToolStripMenuItem.Enabled = True
            КонвертироватьВыделенноеToolStripMenuItem.Enabled = True
            КонвертироватьВсеToolStripMenuItem.Enabled = True
            УдалитьЗаписьToolStripMenuItem.Enabled = True
            ОчиститьСписокToolStripMenuItem1.Enabled = True
        End If
    End Sub

    Private Sub ДействиеToolStripMenuItem_DropDownOpened(sender As Object, e As EventArgs) Handles ДействиеToolStripMenuItem.DropDownOpened
        If fOptions.get_regisrt_value("save_path_method", True) Then
            УказатьПапкуХраненияToolStripMenuItem.Enabled = False
        Else
            УказатьПапкуХраненияToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub УказатьПапкуХраненияToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles УказатьПапкуХраненияToolStripMenuItem.Click
        select_save_folder_path()
    End Sub

    Private Sub КонвертироватьВсеToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles КонвертироватьВсеToolStripMenuItem.Click
        PDF_export()
    End Sub

    Private Sub ДоToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ДоToolStripMenuItem.Click
        import_drawing()
    End Sub

    Private Sub КонвертироватьВыделенноеToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles КонвертироватьВыделенноеToolStripMenuItem.Click
        'если сохраняем в другой папке
        If fOptions.get_regisrt_value("save_path_method", True) = False And save_folder_path Is Nothing Then
            select_save_folder_path()
            If save_folder_path IsNot Nothing Then PDF_export_ONE_DRAWING() Else Exit Sub
        Else
            PDF_export_ONE_DRAWING()
        End If
    End Sub

    Private Sub SaveAsPDF_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            CadInicial()
        Catch
        End Try
        DemoVers_StartWindows()
        Otp_Folder_Create()
        Dim mail As SendMailClass = New SendMailClass
    End Sub
    Private Sub DemoVers_StartWindows()
        Dim CryptoClass_ As CryptoClass = New CryptoClass()
        This_Demo_App = CryptoClass_.Form_LoadTrue(True)

        If This_Demo_App Then
            Me.Text = System.Windows.Forms.Application.ProductName & " v" + System.Windows.Forms.Application.ProductVersion & $" ({invApp.SoftwareVersion.ProductName} {ProgramVersionFlag})" & " !!!This DemoVersion!!!"
            КонвертироватьВыделенноеToolStripMenuItem.Enabled = False
            МенеджерЛицензииToolStripMenuItem.Visible = True
        Else
            Me.Text = System.Windows.Forms.Application.ProductName & " v" + System.Windows.Forms.Application.ProductVersion & $" ({invApp.SoftwareVersion.ProductName} {ProgramVersionFlag})"
            КонвертироватьВыделенноеToolStripMenuItem.Enabled = True
            МенеджерЛицензииToolStripMenuItem.Visible = False
        End If
    End Sub

    Private Sub МенеджерЛицензииToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles МенеджерЛицензииToolStripMenuItem.Click
        LicForm2.ShowDialog()
    End Sub

    Sub select_save_folder_path()
        Dim dir As String = ""
        'Dim fb As New FolderBrowserDialog
        'With fb
        '    .Description = "Укажите место хранения файлов"
        '    If .ShowDialog = System.Windows.Forms.DialogResult.OK Then
        '        save_folder_path = .SelectedPath
        '    Else
        '        Exit Sub
        '    End If
        'End With
        Dim fbEx As FolderBrowserDialogEx = New FolderBrowserDialogEx
        With fbEx
            .Description = "Укажите место хранения файлов"
            If .ShowDialog = System.Windows.Forms.DialogResult.OK Then
                save_folder_path = .SelectedPath
            Else
                Exit Sub
            End If
        End With
    End Sub
End Class
