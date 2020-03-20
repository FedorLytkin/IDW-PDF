Imports System.IO
Module Pr_Options
    Public KeyFile_Puth As String = $"C:\Users\\Public\Documents\{Application.ProductName}\keyfile.dat"
    Public This_Demo_App As Boolean = 1 '0 - полная версия, 1 - демо версия
    Public Opt_Folder_Path As String = $"C:\Users\Public\Documents\{Application.ProductName}"
    Public Opt_File_Puth As String = Application.StartupPath & "\Pr_Option.ini"

    Public Fl_ReadMePath As String = Application.StartupPath & "\ReadMe.txt"
    Public Opt_Del_Char As String = "/"
    Public Opt_Comment_Char As String = "##"
    Public Opt_Color_Del_Char As String = ";"

    'Public logFileName As String = "\LogFile.txt"      'название лог-файла
    'Public logBOMFileName As String = "\LogBOMFile.txt"      'название лог-файла

    'Public Select_Foldef_OpName As String = "Select_Foldef"
    'Public Select_Foldef_Val As Integer = 4

    'Public Create_Unfold_OpName As String = "Create_Unfold"
    'Public Create_Unfold_Val As Integer

    'Public AddLog_OpName As String = "AddLog"
    'Public AddLog_Val As Integer
    'Public Add_SuppresCom_OpName As String = "Add_SuppresCom"
    'Public Add_SuppresCom_Val As Integer = 1
    'Public Add_BOM_Log_OpName = "Add_BOM_Log_OpName" ' "Записывать Log о структуре файла"
    'Public Add_BOM_Log_Val As Integer = 0

    'Public LngID_OpName = "LngID_OpName" ' "Выбор языка"
    'Public LngID_Val As Integer = 2
    Sub Otp_Folder_Create()
        If Directory.Exists(Opt_Folder_Path) = False Then
            'создаем папку с настройками в Общих документах
            Directory.CreateDirectory(Opt_Folder_Path)
            'копируем туда файлы настроек НАСТРОЙКИ ПРОГРАММЫ
            File.Copy(Opt_File_Puth, Opt_Folder_Path & "\" & Path.GetFileName(Opt_File_Puth))
            Opt_File_Puth = Opt_Folder_Path & "\" & Path.GetFileName(Opt_File_Puth)
        Else
            Opt_File_Puth = Opt_Folder_Path & "\" & Path.GetFileName(Opt_File_Puth)
        End If
    End Sub
    Sub Save_Parameters()
        Dim strFile As String = Opt_File_Puth
        File.Delete(strFile)
        Dim fileExists As Boolean = File.Exists(strFile)
        Using sw As New StreamWriter(File.Open(strFile, FileMode.OpenOrCreate), System.Text.Encoding.GetEncoding(1251))
            '0-Параметр;1-Значение
            'sw.WriteLine(Select_Foldef_OpName & Opt_Del_Char & Select_Foldef_Val)                   'опция выбора директории
            'sw.WriteLine(Create_Unfold_OpName & Opt_Del_Char & Create_Unfold_Val)                   'опция создания развертки
            'sw.WriteLine(AddLog_OpName & Opt_Del_Char & AddLog_Val)                                 'опция записи лога
            'sw.WriteLine(Add_SuppresCom_OpName & Opt_Del_Char & Add_SuppresCom_Val)                 'опция добавление Подавленных компонентов
            ''sw.WriteLine(Add_BOM_Log_OpName & Opt_Del_Char & Add_BOM_Log_Val)                      'Записывать Log о структуре файла
            'sw.WriteLine(LngID_OpName & Opt_Del_Char & LngID_Val)                                   'Выбор языка
        End Using
    End Sub
    Sub chekced_ParamChancge(Parname As String, par_val As Integer)
        Select Case Parname
            'Case AddLog_OpName
            '    AddLog_Val = CInt(par_val)
            'Case Create_Unfold_OpName
            '    Create_Unfold_Val = CInt(par_val)
            'Case Add_SuppresCom_OpName
            '    Add_SuppresCom_Val = CInt(par_val)
            'Case Add_BOM_Log_OpName
            '    Add_BOM_Log_Val = CInt(par_val)
            'Case LngID_OpName
            '    LngID_Val = CInt(par_val)
        End Select
        Save_Parameters()
    End Sub
    Sub ReadOptionsAll()
        Try
            Using r As StreamReader = New StreamReader(Opt_File_Puth, System.Text.Encoding.GetEncoding(1251))
                Dim line As String
                line = r.ReadLine

                Do While (Not line Is Nothing)
                    If line.IndexOf(Opt_Comment_Char) <> 0 Then
                        Dim line_arr() As String = line.Split(Opt_Del_Char)
                        Select Case line_arr(0)
                            'Case Select_Foldef_OpName
                            '    Select_Foldef_Val = line_arr(1)
                            'Case Create_Unfold_OpName
                            '    Create_Unfold_Val = line_arr(1)
                            'Case AddLog_OpName
                            '    AddLog_Val = line_arr(1)
                            'Case Add_SuppresCom_OpName
                            '    Add_SuppresCom_Val = line_arr(1)
                            'Case Add_BOM_Log_OpName
                            '    Add_BOM_Log_Val = line_arr(1)
                            'Case LngID_OpName
                            '    LngID_Val = line_arr(1)
                        End Select
                    End If
                    line = r.ReadLine
                Loop
            End Using
        Catch ex As Exception

        End Try
    End Sub
    Function Read_ReadMeTXT() As String
        Dim read_Text As String = ""

        Dim strFile As String = Fl_ReadMePath
        Dim fileExists As Boolean = File.Exists(strFile)
        If fileExists Then
            Using r As StreamReader = New StreamReader(Fl_ReadMePath, System.Text.Encoding.GetEncoding(1251))
                Do While (Not r.EndOfStream)
                    read_Text += r.ReadLine() + Environment.NewLine ' &= r.ReadLine & Environment.NewLine

                Loop
            End Using
        Else
            read_Text = AboutBox1.TextBoxDescription.Text
        End If
        Return read_Text
    End Function
End Module
