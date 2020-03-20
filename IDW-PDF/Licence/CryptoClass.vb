Imports System
Imports System.Linq
Imports System.Text
Imports System.Security.Cryptography
Imports System.Windows.Forms
Imports System.Management
Imports System.IO
Public Class CryptoClass
    Public Shared MotherBoardID_ As String
    Public Shared ProcessorID_ As String
    Public Shared Volumeserialnumber_ As String
    Public Shared ProgramID_ As String
    Public Shared ProgramVersion_ As String
    Public Shared CADProgramVersion_ As String
    Public Shared LicKey_ As String
    Public Shared ComputerName_ As String
    Public Shared DelimerChar As String = "ANK"
    Private Rijndael As RijndaelManaged

    Public Sub New()
        Rijndael = New RijndaelManaged()
    End Sub
    Private Function GetMotherBoardID() As String
        Dim MotherBoardID As String = String.Empty
        Dim query As SelectQuery = New SelectQuery("Win32_BaseBoard")
        Dim searcher As ManagementObjectSearcher = New ManagementObjectSearcher(query)
        Dim enumerator As ManagementObjectCollection.ManagementObjectEnumerator = searcher.[Get]().GetEnumerator()

        While enumerator.MoveNext()
            Dim info As ManagementObject = CType(enumerator.Current, ManagementObject)
            MotherBoardID = info("SerialNumber").ToString().Trim()
        End While

        MotherBoardID_ = MotherBoardID
        Return MotherBoardID
    End Function
    Private Function GetProgrammVersion() As String
        Dim ProgrammVers As String = Nothing
        Dim versPoint As Char = "."c
        Dim verDelArr As String() = Application.ProductVersion.Split(versPoint)
        ProgrammVers = verDelArr(0) & versPoint & verDelArr(1) & versPoint & verDelArr(2)
        ProgramVersion_ = ProgrammVers
        Return ProgrammVers
    End Function

    Private Function GetProgramName(ByVal TranslateID As Boolean) As String
        Dim ProgramName As String = Nothing

        If TranslateID Then
            ProgramName = SaveAsPDF.ProgramID
        Else
            ProgramName = System.Windows.Forms.Application.ProductName
        End If

        ProgramID_ = ProgramName
        Return ProgramName
    End Function
    Private Function GetProcessorID() As String
        Dim ProcessorID As String = String.Empty
        Dim query As SelectQuery = New SelectQuery("Win32_processor")
        Dim searcher As ManagementObjectSearcher = New ManagementObjectSearcher(query)
        Dim enumerator As ManagementObjectCollection.ManagementObjectEnumerator = searcher.[Get]().GetEnumerator()

        While enumerator.MoveNext()
            Dim info As ManagementObject = CType(enumerator.Current, ManagementObject)
            ProcessorID = info("processorId").ToString().Trim()
        End While

        ProcessorID_ = ProcessorID
        Return ProcessorID
    End Function
    Private Function GetVolumeSerial(ByVal Optional strDriveLetter As String = "C") As String
        Dim VolumeSerial As ManagementObject = New ManagementObject(String.Format("win32_logicaldisk.deviceid=""{0}:""", strDriveLetter))
        VolumeSerial.[Get]()
        Dim VolumeSeria As String = VolumeSerial("VolumeSerialNumber").ToString().Trim()
        Volumeserialnumber_ = VolumeSeria
        Return VolumeSeria
    End Function
    Private Function GetComputerName(ByVal EncodInByte As Boolean) As String
        Dim ComputerName As String = Nothing

        If EncodInByte Then
            Dim bytes As Byte() = Encoding.ASCII.GetBytes(Environment.MachineName)
            Dim result As Integer = BitConverter.ToInt32(bytes, 0)
            ComputerName = Convert.ToString(result)
        Else
            ComputerName = Environment.MachineName
        End If

        ComputerName_ = ComputerName
        Return ComputerName
    End Function
    Private Function GetCADProgramVersion() As String
        Dim CADProgramVersion As String = Nothing
        CADProgramVersion = SaveAsPDF.ProgramVersion
        CADProgramVersion_ = CADProgramVersion
        Return CADProgramVersion
    End Function
    Private Function Char_Mix(ByVal MotherBoardID As String, ByVal ProcID As String, ByVal VolSerial As String) As String
        Dim sOut As String = ""
        Dim MotherDoardArr As Char() = MotherBoardID.ToCharArray()
        Dim ProcIDArr As Char() = ProcID.ToCharArray()
        Dim VolSerialArr As Char() = VolSerial.ToCharArray()
        Dim arr_lenth As Integer() = New Integer() {MotherBoardID.Length, ProcID.Length, VolSerial.Length}
        Dim CharMinCount As Integer = arr_lenth.Max()

        For i As Integer = 0 To CharMinCount - 1
            Dim MotherDoardArr_Ind As String = "0"
            Dim ProcIDArr_Ind As String = "1"
            Dim VolSerialArr_Ind As String = "2"

            Try
                MotherDoardArr_Ind = Convert.ToString(MotherDoardArr(i))
            Catch ec As Exception
            End Try

            Try
                ProcIDArr_Ind = Convert.ToString(ProcIDArr(i))
            Catch ec As Exception
            End Try

            Try
                VolSerialArr_Ind = Convert.ToString(VolSerialArr(i))
            Catch ec As Exception
            End Try

            sOut += MotherDoardArr_Ind & ProcIDArr_Ind & VolSerialArr_Ind
        Next

        Return sOut
    End Function
    Public Function Char_Mix2(ByVal MotherBoardID As String, ByVal ProcID As String, ByVal VolSerial As String, ByVal ProgID As String, ByVal ProgVersion As String) As String
        Dim sOut As String = ""
        Dim MotherDoardArr As Char() = MotherBoardID.ToCharArray()
        Dim ProcIDArr As Char() = ProcID.ToCharArray()
        Dim VolSerialArr As Char() = VolSerial.ToCharArray()
        Dim ProgIDArr As Char() = ProgID.ToCharArray()
        Dim ProgVersionArr As Char() = ProgVersion.ToCharArray()
        Dim arr_lenth As Integer() = New Integer() {MotherBoardID.Length, ProcID.Length, VolSerial.Length}
        Dim CharMinCount As Integer = arr_lenth.Max()

        For i As Integer = 0 To CharMinCount - 1
            Dim MotherDoardArr_Ind As String = "0"
            Dim ProcIDArr_Ind As String = "1"
            Dim VolSerialArr_Ind As String = "2"
            Dim ProgIDArr_Ind As String = "2"
            Dim ProgVersionArr_Ind As String = "2"

            Try
                MotherDoardArr_Ind = Convert.ToString(MotherDoardArr(i))
            Catch ec As Exception
            End Try

            Try
                ProcIDArr_Ind = Convert.ToString(ProcIDArr(i))
            Catch ec As Exception
            End Try

            Try
                VolSerialArr_Ind = Convert.ToString(VolSerialArr(i))
            Catch ec As Exception
            End Try

            Try
                ProgIDArr_Ind = Convert.ToString(ProgIDArr(i))
            Catch ec As Exception
            End Try

            Try
                ProgVersionArr_Ind = Convert.ToString(ProgVersionArr(i))
            Catch ec As Exception
            End Try

            sOut += MotherDoardArr_Ind & ProcIDArr_Ind & VolSerialArr_Ind & ProgIDArr_Ind & ProgVersionArr_Ind & MotherBoardID & ProcID & VolSerial & ProgID & ProgVersion
        Next

        Return sOut & DelimerChar & MotherBoardID + DelimerChar & ProcID + DelimerChar & VolSerial & ProgVersion + DelimerChar & ProgID + DelimerChar
    End Function
    Public Sub loadStaticParam()
        GetMotherBoardID()
        GetProcessorID()
        GetVolumeSerial()
        GetProgramName(True)
        GetProgrammVersion()
        GetCADProgramVersion()
        GetComputerName(False)
    End Sub
    Public Function Form_LoadTrue(ByVal VisMessagForUser As Boolean) As Boolean
        Dim number As String = Char_Mix2(GetMotherBoardID(), GetProcessorID(), GetVolumeSerial(), GetProgramName(True), GetProgrammVersion())
        LicKey_ = number
        Dim fPath As String = Application.StartupPath & "\keyfile.dat"
        fPath = Pr_Options.KeyFile_Puth

        If File.Exists(fPath) Then

            If Not DecodeKey(number, fPath) Then
                Return False
            Else

                If VisMessagForUser Then
                    MessageBox.Show("Ключ лицензии не верный!" & vbLf &
                                    "Сформируйте файл-запрос в Менеджере лицензии(Справка - Менеджер лицензии)." & vbLf &
                                    "Отправьте полученный файл разработчику для получения ключа!",
                                    Application.ProductName & ". Менеджер лицензии",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error)
                End If

                Clipboard.SetText(number)
                Return True
            End If
        Else

            If VisMessagForUser Then
                MessageBox.Show("Ключ лицензии не верный!" & vbLf &
                                    "Сформируйте файл-запрос в Менеджере лицензии(Справка - Менеджер лицензии)." & vbLf &
                                    "Отправьте полученный файл разработчику для получения ключа!",
                                    Application.ProductName & ". Менеджер лицензии",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error)
            End If

            Return True
        End If

        Return True
    End Function
    Public Function DecodeKey(ByVal inString As String, ByVal path As String) As Boolean
        Try
            Dim decryptstring As String = Nothing
            Dim key As Byte() = New Byte(31) {}

            For i As Integer = 0 To &H1F
                key(i) = &H1F
            Next

            Rijndael.Key = key
            Dim fs As FileStream = New FileStream(path, FileMode.Open)
            Dim IV As Byte() = New Byte(Rijndael.IV.Length - 1) {}
            fs.Read(IV, 0, IV.Length)
            Rijndael.IV = IV
            Dim transformer As ICryptoTransform = Rijndael.CreateDecryptor()
            Dim cs As CryptoStream = New CryptoStream(fs, transformer, CryptoStreamMode.Read)
            Dim sr As StreamReader = New StreamReader(cs)
            decryptstring = sr.ReadToEnd()
            fs.Close()

            If Not (decryptstring = inString) Then
                Return True
            Else
                Return False
            End If

        Catch Ex As Exception
            Return True
        End Try
    End Function
    Public Function DecodeKey2strings(ByVal inString As String, ByVal path As String) As Boolean
        Try
            Dim decryptstring As String = Nothing
            Dim key As Byte() = New Byte(31) {}

            For i As Integer = 0 To &H1F
                key(i) = &H1F
            Next

            Rijndael.Key = key
            Return True
        Catch ex As Exception
            Return True
        End Try
    End Function
End Class
