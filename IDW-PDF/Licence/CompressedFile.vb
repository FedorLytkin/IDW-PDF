Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.IO
Imports System.IO.Compression
Public Class CompressedFile
    Public Sub AddDeCompressedFile(ByVal FileName As String, ByVal DeletTempFile As Boolean)
        Dim TargetFileTmp As String = Path.Combine(Path.GetDirectoryName(FileName), "_" & Path.GetFileName(FileName))
        Dim FileCompressed As Boolean = False
        Decompress(FileName, TargetFileTmp, FileCompressed)
        If File.Exists(FileName) AndAlso DeletTempFile AndAlso FileCompressed = True Then File.Delete(FileName)
        If FileCompressed Then File.Move(TargetFileTmp, FileName)
    End Sub
    Public Sub AddCompressedFile(ByVal FileName As String, ByVal DeletTempFile As Boolean)
        Dim FileNameTmp As String = Path.Combine(Path.GetDirectoryName(FileName), "_" & Path.GetFileName(FileName))
        Compress(FileName, FileNameTmp)
        If File.Exists(FileName) AndAlso DeletTempFile Then File.Delete(FileName)
        File.Move(FileNameTmp, FileName)
    End Sub
    Public Function Decompress_to_(ByVal compressedFile As String) As List(Of String)
        Dim lst As List(Of String) = New List(Of String)()

        Using sourceStream As FileStream = New FileStream(compressedFile, FileMode.OpenOrCreate)

            Using decompressionStream As GZipStream = New GZipStream(sourceStream, CompressionMode.Decompress)
                Dim reader As StreamReader = New StreamReader(decompressionStream, Encoding.[Default])
                Dim i As Integer = 0

                While reader.EndOfStream = False
                    lst.Add(reader.ReadLine())
                    i += 1
                End While

                reader.Close()
            End Using
        End Using

        Return lst
    End Function
    Public Sub Decompress(ByVal compressedFile As String, ByVal targetFile As String, ByRef FileCompressed As Boolean)
        Using sourceStream As FileStream = New FileStream(compressedFile, FileMode.OpenOrCreate)

            Using targetStream As FileStream = File.Create(targetFile)

                Using decompressionStream As GZipStream = New GZipStream(sourceStream, CompressionMode.Decompress)

                    Try
                        decompressionStream.CopyTo(targetStream)
                        FileCompressed = True
                    Catch Ex As Exception
                        targetStream.Close()
                        File.Delete(targetFile)
                        FileCompressed = False
                    End Try
                End Using
            End Using
        End Using
    End Sub
    Public Sub Compress(ByVal sourceFile As String, ByVal compressedFile As String)
        Using sourceStream As FileStream = New FileStream(sourceFile, FileMode.OpenOrCreate)

            Using targetStream As FileStream = File.Create(compressedFile)

                Using compressionStream As GZipStream = New GZipStream(targetStream, CompressionMode.Compress)
                    sourceStream.CopyTo(compressionStream)
                End Using
            End Using
        End Using
    End Sub
End Class
