<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LicForm2
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LicForm2))
        Me.buttonGenerate = New System.Windows.Forms.Button()
        Me.button2 = New System.Windows.Forms.Button()
        Me.buttonImortFile = New System.Windows.Forms.Button()
        Me.toolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.linkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.openFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SuspendLayout()
        '
        'buttonGenerate
        '
        Me.buttonGenerate.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.buttonGenerate.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.buttonGenerate.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.buttonGenerate.Location = New System.Drawing.Point(12, 12)
        Me.buttonGenerate.Name = "buttonGenerate"
        Me.buttonGenerate.Size = New System.Drawing.Size(333, 59)
        Me.buttonGenerate.TabIndex = 14
        Me.buttonGenerate.Text = "Сгенерировать файл-запрос"
        Me.buttonGenerate.UseVisualStyleBackColor = False
        '
        'button2
        '
        Me.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.button2.Location = New System.Drawing.Point(289, 77)
        Me.button2.Name = "button2"
        Me.button2.Size = New System.Drawing.Size(56, 26)
        Me.button2.TabIndex = 13
        Me.button2.Text = "Выйти"
        Me.button2.UseVisualStyleBackColor = True
        '
        'buttonImortFile
        '
        Me.buttonImortFile.BackColor = System.Drawing.Color.Lime
        Me.buttonImortFile.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.buttonImortFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.buttonImortFile.Location = New System.Drawing.Point(12, 77)
        Me.buttonImortFile.Name = "buttonImortFile"
        Me.buttonImortFile.Size = New System.Drawing.Size(271, 42)
        Me.buttonImortFile.TabIndex = 12
        Me.buttonImortFile.Text = "Ввести файл-ключ"
        Me.buttonImortFile.UseVisualStyleBackColor = False
        '
        'linkLabel1
        '
        Me.linkLabel1.AutoSize = True
        Me.linkLabel1.Location = New System.Drawing.Point(295, 106)
        Me.linkLabel1.Name = "linkLabel1"
        Me.linkLabel1.Size = New System.Drawing.Size(50, 13)
        Me.linkLabel1.TabIndex = 15
        Me.linkLabel1.TabStop = True
        Me.linkLabel1.Text = "Справка"
        '
        'openFileDialog1
        '
        Me.openFileDialog1.FileName = "openFileDialog1"
        '
        'LicForm2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(354, 131)
        Me.Controls.Add(Me.buttonGenerate)
        Me.Controls.Add(Me.button2)
        Me.Controls.Add(Me.buttonImortFile)
        Me.Controls.Add(Me.linkLabel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(370, 170)
        Me.MinimumSize = New System.Drawing.Size(370, 170)
        Me.Name = "LicForm2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Менеджер лицензий"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents buttonGenerate As Button
    Private WithEvents button2 As Button
    Private WithEvents buttonImortFile As Button
    Private WithEvents toolTip1 As ToolTip
    Private WithEvents linkLabel1 As LinkLabel
    Private WithEvents openFileDialog1 As OpenFileDialog
End Class
