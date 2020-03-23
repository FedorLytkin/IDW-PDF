Imports System
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Net
Imports System.IO
Imports System.Threading.Tasks
Imports System.Net.Mail
Public Class SendMailClass
    Private Shared MailAddressFrom As String = "dxfautosender@gmail.com"
    Private Shared MailAddressTo As String = "dxfautohelp@gmail.com"
    Private Shared Ps As String = "DXFAutoSender123"

    Private Shared logFile As String = $"C:\Users\Public\Documents\{Application.ProductName}\SM\SM.LOG"
    Private Shared log_Split As String = "#"
    Dim perenos As String = "<br/>"

    Public Sub New()
        addLogFile()
    End Sub
    Sub SendMailProc(withAtttach As Boolean, MailText As String)
        Dim from As MailAddress = New MailAddress(MailAddressFrom, Application.ProductName & $" Inventor {SaveAsPDF.ProgramVersionFlag}")
        Dim adresat As MailAddress = New MailAddress(MailAddressTo)
        Dim m As MailMessage = New MailMessage(from, adresat)
        m.Subject = Application.ProductName & " " + Application.ProductVersion & " " + Environment.MachineName
        m.Body = MailText & "</h2>"

        If withAtttach Then m.Attachments.Add(New Attachment(logFile))

        m.IsBodyHtml = True
        Dim smtp As SmtpClient = New SmtpClient("smtp.gmail.com", 587)
        smtp.Credentials = New NetworkCredential(MailAddressFrom, Ps)
        smtp.EnableSsl = True

        Try
            smtp.Send(m)
        Catch ex As Exception
        End Try
    End Sub
    Sub addLogFile()
        Dim Foldername As String = Path.GetDirectoryName(logFile)
        If Not Directory.Exists(Foldername) Then
            Directory.CreateDirectory(Foldername)
        End If

        If Not File.Exists(logFile) Then
            SendMailProc(False, $"<h2>Программа: {Application.ProductName} {perenos}" &
                             $"Версия: {Application.ProductVersion} {perenos}" &
                             $"Имя компьютера: {Environment.MachineName} {perenos}" &
                             $"Демоверсия: {Pr_Options.This_Demo_App.ToString}")
        End If

        Dim strFile As String = logFile
        Try
            Dim lines
            Using r As StreamReader = New StreamReader(strFile, System.Text.Encoding.GetEncoding(1251))
                lines = r.ReadToEnd.Split(New Char() {vbLf})
            End Using

            Using sw As New StreamWriter(File.Open(strFile, FileMode.OpenOrCreate), System.Text.Encoding.GetEncoding(1251))
                For Each oLine As String In lines
                    If Not String.IsNullOrEmpty(oLine) Then sw.WriteLine(oLine.Trim(vbCr))
                Next
                sw.WriteLine(Now & log_Split & "Программа: " & Application.ProductName & log_Split & "Версия: " + Application.ProductVersion & log_Split & "Имя компьютера: " + Environment.MachineName)
            End Using
        Catch ex As Exception
            Using sw As New StreamWriter(File.Open(strFile, FileMode.OpenOrCreate), System.Text.Encoding.GetEncoding(1251))
                sw.WriteLine(Now & log_Split & "Программа: " & Application.ProductName & log_Split & "Версия: " + Application.ProductVersion & log_Split & "Имя компьютера: " + Environment.MachineName)
            End Using
        End Try
        check_App_Start_Count()
    End Sub
    Sub check_App_Start_Count()
        Dim count
        Using r As StreamReader = New StreamReader(logFile, System.Text.Encoding.GetEncoding(1251))
            Dim lines = r.ReadToEnd.Split(New Char() {vbLf})
            count = lines.Count - 1
        End Using

        For i As Integer = 60 To 0 Step -30
            If count = i Then
                SendMailProc(True, $"<h2>Программа: {Application.ProductName} {perenos}" &
                             $"Версия: {Application.ProductVersion} {perenos}" &
                             $"Имя компьютера: {Environment.MachineName} {perenos}" &
                             $"Запущено: {i} раз(а) {perenos}" &
                             $"Демоверсия: {Pr_Options.This_Demo_App.ToString}")
                Exit For
            End If
        Next
    End Sub
End Class
