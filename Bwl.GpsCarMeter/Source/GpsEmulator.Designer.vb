<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GpsEmulator
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
        Me.pbMap = New System.Windows.Forms.PictureBox()
        Me.tGps = New System.Windows.Forms.Timer(Me.components)
        CType(Me.pbMap, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pbMap
        '
        Me.pbMap.Image = Global.Bwl.GpsCarMeter.My.Resources.Resources.map
        Me.pbMap.Location = New System.Drawing.Point(1, 1)
        Me.pbMap.Name = "pbMap"
        Me.pbMap.Size = New System.Drawing.Size(992, 792)
        Me.pbMap.TabIndex = 0
        Me.pbMap.TabStop = False
        '
        'tGps
        '
        Me.tGps.Enabled = True
        '
        'GpsEmulator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(994, 793)
        Me.Controls.Add(Me.pbMap)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "GpsEmulator"
        Me.Text = "GpsEmulator"
        CType(Me.pbMap, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pbMap As PictureBox
    Friend WithEvents tGps As Timer
End Class
