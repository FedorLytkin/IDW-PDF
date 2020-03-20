Imports System
Imports System.Windows.Forms
Imports System.Security.Cryptography
Imports System.IO
Public Class LicForm2
    Dim Rijndael As Rijndael
    Dim CryptoClass_ As CryptoClass
    Dim compressedFile As CompressedFile

    Public Shared PatternID As String = "100"
    Public Shared ThisPCLic As String
    Public Sub New()
        InitializeComponent()
        Rijndael = New RijndaelManaged()
        'MyBase.Load += New EventHandler(LicForm2_Load)
    End Sub
    Private Sub GenerateQueryFile(ByVal path As String)
        Using sw As StreamWriter = New StreamWriter(File.Open(path, FileMode.OpenOrCreate), System.Text.Encoding.GetEncoding(1251))
            sw.WriteLine(PatternID)
            sw.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"))
            sw.WriteLine(CryptoClass.CADProgramVersion_)
            sw.WriteLine(CryptoClass.ComputerName_)
            sw.WriteLine(CryptoClass.ProgramVersion_)
            sw.WriteLine(CryptoClass.ProgramID_)
            sw.WriteLine(CryptoClass.ProcessorID_)
            sw.WriteLine(CryptoClass.Volumeserialnumber_)
            sw.WriteLine(CryptoClass.MotherBoardID_)
        End Using

        compressedFile.AddCompressedFile(path, True)
    End Sub
    Public Sub GetKeyFile(ByVal inString As String, ByVal path As String)
        Dim key As Byte() = New Byte(31) {}

        For i As Integer = 0 To &H1F
            key(i) = &H1F
        Next

        Rijndael.Key = key
        Dim transformer As ICryptoTransform = Rijndael.CreateEncryptor()
        Dim fs As FileStream = New FileStream(path, FileMode.Create)
        fs.Write(Rijndael.IV, 0, Rijndael.IV.Length)
        Dim cs As CryptoStream = New CryptoStream(fs, transformer, CryptoStreamMode.Write)
        Dim sw As StreamWriter = New StreamWriter(cs)
        sw.Write(inString)
        sw.Flush()
        cs.FlushFinalBlock()
        sw.Close()
    End Sub

    Private Sub buttonGenerate_Click_1(sender As Object, e As EventArgs) Handles buttonGenerate.Click
        Dim dialog As SaveFileDialog = New SaveFileDialog()
        dialog.FileName = $"Queryfile_({CryptoClass.ComputerName_}_{CryptoClass.ProgramID_})"
        dialog.Filter = "datq files(*.datq)|*.datq"

        If dialog.ShowDialog() = DialogResult.OK Then
            GenerateQueryFile(dialog.FileName)
            MessageBox.Show("Файл запрос создан.", Application.ProductName)
        End If
    End Sub

    Private Sub buttonImortFile_Click_1(sender As Object, e As EventArgs) Handles buttonImortFile.Click
        If String.IsNullOrWhiteSpace(ThisPCLic) Then Return
        openFileDialog1.FileName = "keyfile"
        openFileDialog1.Filter = "dat files(*.dat)|*.dat"

        If openFileDialog1.ShowDialog() = DialogResult.OK Then

            Try
                If File.Exists(Pr_Options.KeyFile_Puth) Then File.Delete(Pr_Options.KeyFile_Puth)
                File.Copy(openFileDialog1.FileName, Pr_Options.KeyFile_Puth)
            Catch ex As Exception
                MessageBox.Show("")
            End Try

            GetKeyFile(ThisPCLic, Pr_Options.KeyFile_Puth)
            Me.Close()
        End If
    End Sub

    Private Sub LicForm2_Load(sender As Object, e As EventArgs) Handles Me.Load
        CryptoClass_ = New CryptoClass()
        compressedFile = New CompressedFile()
        CryptoClass_.loadStaticParam()
        ThisPCLic = CryptoClass_.Char_Mix2(CryptoClass.MotherBoardID_, CryptoClass.ProcessorID_, CryptoClass.Volumeserialnumber_, CryptoClass.ProgramID_, CryptoClass.ProgramVersion_)
    End Sub

    Private Sub linkLabel1_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkLabel1.LinkClicked
        System.Diagnostics.Process.Start("https://www.evernote.com/l/AjJSBG66FZBA7KMBazxxsVvqEjyUddPCVfw/")
    End Sub
End Class