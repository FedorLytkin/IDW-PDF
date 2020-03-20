<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SaveAsPDF
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SaveAsPDF))
        Me.lstResults = New System.Windows.Forms.ListBox()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.КонвертироватьВыделенноеToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.КонвертироватьВсеToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ДоToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.УдалитьЗаписьToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ОчиститьСписокToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ОткрытьЧертежToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ОткрытьPDFЧертежаToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ОткрытьToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ВыбратьБланкToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ОчиститьСписокToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ДействиеToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ПеревестиБланкиToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.УказатьПапкуХраненияToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.СервисToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.НастройкиToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ОПрограммеToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.СправкаToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ОПрограммеToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.МенеджерЛицензииToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstResults
        '
        Me.lstResults.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lstResults.FormattingEnabled = True
        Me.lstResults.Location = New System.Drawing.Point(0, 222)
        Me.lstResults.Name = "lstResults"
        Me.lstResults.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstResults.Size = New System.Drawing.Size(447, 95)
        Me.lstResults.TabIndex = 12
        '
        'ListBox1
        '
        Me.ListBox1.AllowDrop = True
        Me.ListBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListBox1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(-1, 36)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(447, 186)
        Me.ListBox1.TabIndex = 13
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.КонвертироватьВыделенноеToolStripMenuItem, Me.КонвертироватьВсеToolStripMenuItem, Me.ToolStripSeparator2, Me.ДоToolStripMenuItem, Me.УдалитьЗаписьToolStripMenuItem, Me.ОчиститьСписокToolStripMenuItem1, Me.ToolStripSeparator1, Me.ОткрытьЧертежToolStripMenuItem, Me.ОткрытьPDFЧертежаToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(246, 170)
        '
        'КонвертироватьВыделенноеToolStripMenuItem
        '
        Me.КонвертироватьВыделенноеToolStripMenuItem.Name = "КонвертироватьВыделенноеToolStripMenuItem"
        Me.КонвертироватьВыделенноеToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.КонвертироватьВыделенноеToolStripMenuItem.Text = "Конвертировать выделенное"
        '
        'КонвертироватьВсеToolStripMenuItem
        '
        Me.КонвертироватьВсеToolStripMenuItem.Name = "КонвертироватьВсеToolStripMenuItem"
        Me.КонвертироватьВсеToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.КонвертироватьВсеToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.КонвертироватьВсеToolStripMenuItem.Text = "Конвертировать список"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(242, 6)
        '
        'ДоToolStripMenuItem
        '
        Me.ДоToolStripMenuItem.Name = "ДоToolStripMenuItem"
        Me.ДоToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.ДоToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.ДоToolStripMenuItem.Text = "Добавить"
        '
        'УдалитьЗаписьToolStripMenuItem
        '
        Me.УдалитьЗаписьToolStripMenuItem.Name = "УдалитьЗаписьToolStripMenuItem"
        Me.УдалитьЗаписьToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete
        Me.УдалитьЗаписьToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.УдалитьЗаписьToolStripMenuItem.Text = "Удалить запись"
        '
        'ОчиститьСписокToolStripMenuItem1
        '
        Me.ОчиститьСписокToolStripMenuItem1.Name = "ОчиститьСписокToolStripMenuItem1"
        Me.ОчиститьСписокToolStripMenuItem1.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Delete), System.Windows.Forms.Keys)
        Me.ОчиститьСписокToolStripMenuItem1.Size = New System.Drawing.Size(245, 22)
        Me.ОчиститьСписокToolStripMenuItem1.Text = "Очистить список"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(242, 6)
        '
        'ОткрытьЧертежToolStripMenuItem
        '
        Me.ОткрытьЧертежToolStripMenuItem.Name = "ОткрытьЧертежToolStripMenuItem"
        Me.ОткрытьЧертежToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.ОткрытьЧертежToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.ОткрытьЧертежToolStripMenuItem.Text = "Открыть чертеж"
        '
        'ОткрытьPDFЧертежаToolStripMenuItem
        '
        Me.ОткрытьPDFЧертежаToolStripMenuItem.Name = "ОткрытьPDFЧертежаToolStripMenuItem"
        Me.ОткрытьPDFЧертежаToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.ОткрытьPDFЧертежаToolStripMenuItem.Text = "Открыть PDF чертежа"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ОткрытьToolStripMenuItem, Me.ДействиеToolStripMenuItem, Me.СервисToolStripMenuItem, Me.ОПрограммеToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(447, 24)
        Me.MenuStrip1.TabIndex = 14
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ОткрытьToolStripMenuItem
        '
        Me.ОткрытьToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ВыбратьБланкToolStripMenuItem, Me.ОчиститьСписокToolStripMenuItem})
        Me.ОткрытьToolStripMenuItem.Name = "ОткрытьToolStripMenuItem"
        Me.ОткрытьToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
        Me.ОткрытьToolStripMenuItem.Text = "Открыть"
        '
        'ВыбратьБланкToolStripMenuItem
        '
        Me.ВыбратьБланкToolStripMenuItem.Name = "ВыбратьБланкToolStripMenuItem"
        Me.ВыбратьБланкToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.ВыбратьБланкToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.ВыбратьБланкToolStripMenuItem.Text = "Добавить"
        '
        'ОчиститьСписокToolStripMenuItem
        '
        Me.ОчиститьСписокToolStripMenuItem.Name = "ОчиститьСписокToolStripMenuItem"
        Me.ОчиститьСписокToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Delete), System.Windows.Forms.Keys)
        Me.ОчиститьСписокToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.ОчиститьСписокToolStripMenuItem.Text = "Очистить список"
        '
        'ДействиеToolStripMenuItem
        '
        Me.ДействиеToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ПеревестиБланкиToolStripMenuItem, Me.УказатьПапкуХраненияToolStripMenuItem})
        Me.ДействиеToolStripMenuItem.Name = "ДействиеToolStripMenuItem"
        Me.ДействиеToolStripMenuItem.Size = New System.Drawing.Size(70, 20)
        Me.ДействиеToolStripMenuItem.Text = "Действие"
        '
        'ПеревестиБланкиToolStripMenuItem
        '
        Me.ПеревестиБланкиToolStripMenuItem.Name = "ПеревестиБланкиToolStripMenuItem"
        Me.ПеревестиБланкиToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.ПеревестиБланкиToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.ПеревестиБланкиToolStripMenuItem.Text = "Конвертировать"
        '
        'УказатьПапкуХраненияToolStripMenuItem
        '
        Me.УказатьПапкуХраненияToolStripMenuItem.Name = "УказатьПапкуХраненияToolStripMenuItem"
        Me.УказатьПапкуХраненияToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.УказатьПапкуХраненияToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.УказатьПапкуХраненияToolStripMenuItem.Text = "Указать папку хранения"
        '
        'СервисToolStripMenuItem
        '
        Me.СервисToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.НастройкиToolStripMenuItem})
        Me.СервисToolStripMenuItem.Name = "СервисToolStripMenuItem"
        Me.СервисToolStripMenuItem.Size = New System.Drawing.Size(59, 20)
        Me.СервисToolStripMenuItem.Text = "Сервис"
        '
        'НастройкиToolStripMenuItem
        '
        Me.НастройкиToolStripMenuItem.Name = "НастройкиToolStripMenuItem"
        Me.НастройкиToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F3), System.Windows.Forms.Keys)
        Me.НастройкиToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.НастройкиToolStripMenuItem.Text = "Настройки"
        '
        'ОПрограммеToolStripMenuItem
        '
        Me.ОПрограммеToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.СправкаToolStripMenuItem, Me.ОПрограммеToolStripMenuItem1, Me.МенеджерЛицензииToolStripMenuItem})
        Me.ОПрограммеToolStripMenuItem.Name = "ОПрограммеToolStripMenuItem"
        Me.ОПрограммеToolStripMenuItem.Size = New System.Drawing.Size(94, 20)
        Me.ОПрограммеToolStripMenuItem.Text = "О программе"
        '
        'СправкаToolStripMenuItem
        '
        Me.СправкаToolStripMenuItem.Name = "СправкаToolStripMenuItem"
        Me.СправкаToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.СправкаToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.СправкаToolStripMenuItem.Text = "Справка"
        '
        'ОПрограммеToolStripMenuItem1
        '
        Me.ОПрограммеToolStripMenuItem1.Name = "ОПрограммеToolStripMenuItem1"
        Me.ОПрограммеToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.ОПрограммеToolStripMenuItem1.Size = New System.Drawing.Size(188, 22)
        Me.ОПрограммеToolStripMenuItem1.Text = "О программе"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ProgressBar1.Location = New System.Drawing.Point(0, 24)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(447, 12)
        Me.ProgressBar1.TabIndex = 15
        Me.ProgressBar1.Visible = False
        '
        'МенеджерЛицензииToolStripMenuItem
        '
        Me.МенеджерЛицензииToolStripMenuItem.Name = "МенеджерЛицензииToolStripMenuItem"
        Me.МенеджерЛицензииToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.МенеджерЛицензииToolStripMenuItem.Text = "Менеджер лицензии"
        '
        'SaveAsPDF
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(447, 317)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.lstResults)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MinimumSize = New System.Drawing.Size(463, 356)
        Me.Name = "SaveAsPDF"
        Me.Text = "IDW-PDF"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lstResults As ListBox
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ОткрытьToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ВыбратьБланкToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ОчиститьСписокToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ДействиеToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ПеревестиБланкиToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents СервисToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents НастройкиToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ОПрограммеToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents СправкаToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ОПрограммеToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents УдалитьЗаписьToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ОчиститьСписокToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ОткрытьЧертежToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ОткрытьPDFЧертежаToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents КонвертироватьВыделенноеToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents КонвертироватьВсеToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents УказатьПапкуХраненияToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ДоToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents МенеджерЛицензииToolStripMenuItem As ToolStripMenuItem
End Class
