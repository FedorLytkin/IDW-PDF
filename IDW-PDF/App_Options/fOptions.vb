Public Class fOptions
    Public find_Subfolder As Boolean
    Public save_report As Boolean
    Public save_path_method As Boolean
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Cancel_Bt.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles OK_Bt.Click
        find_Subfolder = CheckBox1.Checked
        set_regisrt_value("find_Subfolder", find_Subfolder)
        save_report = CheckBox2.Checked
        set_regisrt_value("save_report", save_report)
        save_path_method = RadioButton1.Checked
        set_regisrt_value("save_path_method", save_path_method)
        Me.Close()
    End Sub

    Private Sub fOptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        find_Subfolder = get_regisrt_value("find_Subfolder", True)
        save_report = get_regisrt_value("save_report", False)
        save_path_method = get_regisrt_value("save_path_method", True)
        CheckBox1.Checked = find_Subfolder
        CheckBox2.Checked = save_report
        RadioButton1.Checked = save_path_method
        RadioButton2.Checked = Not save_path_method
    End Sub
    Function get_regisrt_value(RegName As String, defolt_value As String)
        Dim regVersion = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(
                  "Software\\Microsoft\\IDW-PDF\\0.9", True)
        If regVersion Is Nothing Then
            ' Key doesn't exist; create it.
            regVersion = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(
                 "Software\\Microsoft\\IDW-PDF\\0.9")
        End If
        Dim regValue As String
        If regVersion IsNot Nothing Then
            regValue = regVersion.GetValue(RegName, defolt_value)
            regVersion.Close()
        End If
        Return regValue
    End Function
    Sub set_regisrt_value(regName As String, regValue As String)
        Dim regVersion = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(
                  "Software\\Microsoft\\IDW-PDF\\0.9", True)
        If regVersion Is Nothing Then
            ' Key doesn't exist; create it.
            regVersion = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(
                 "Software\\Microsoft\\IDW-PDF\\0.9")
        End If
        If regVersion IsNot Nothing Then
            regVersion.SetValue(regName, regValue)
            regVersion.Close()
        End If
    End Sub

    Private Sub fOptions_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.KeyPreview = False
                Me.Close()
        End Select
        Me.KeyPreview = True

        'If e.KeyCode = Keys.Escape Then
        '    Me.Close()
        'End If
    End Sub
End Class