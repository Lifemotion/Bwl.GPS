<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CarMeter

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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.tRate = New System.Windows.Forms.Timer(Me.components)
        Me.tTime = New System.Windows.Forms.Timer(Me.components)
        Me.bRecord = New System.Windows.Forms.Button()
        Me.bRecordStop = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'logWriter
        '
        Me.logWriter.ExtendedView = False
        Me.logWriter.Location = New System.Drawing.Point(0, 322)
        Me.logWriter.Size = New System.Drawing.Size(761, 168)
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.bRecordStop)
        Me.GroupBox1.Controls.Add(Me.bRecord)
        Me.GroupBox1.Controls.Add(Me.TextBox4)
        Me.GroupBox1.Controls.Add(Me.TextBox3)
        Me.GroupBox1.Controls.Add(Me.TextBox2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 27)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(297, 281)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GPS"
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(167, 45)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(124, 20)
        Me.TextBox4.TabIndex = 4
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(19, 71)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(272, 20)
        Me.TextBox3.TabIndex = 3
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(19, 45)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(142, 20)
        Me.TextBox2.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Rate:"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(61, 19)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 0
        '
        'tRate
        '
        Me.tRate.Enabled = True
        Me.tRate.Interval = 1000
        '
        'tTime
        '
        Me.tTime.Enabled = True
        '
        'bRecord
        '
        Me.bRecord.Location = New System.Drawing.Point(19, 97)
        Me.bRecord.Name = "bRecord"
        Me.bRecord.Size = New System.Drawing.Size(272, 23)
        Me.bRecord.TabIndex = 5
        Me.bRecord.Text = "Record"
        Me.bRecord.UseVisualStyleBackColor = True
        '
        'bRecordStop
        '
        Me.bRecordStop.Enabled = False
        Me.bRecordStop.Location = New System.Drawing.Point(19, 126)
        Me.bRecordStop.Name = "bRecordStop"
        Me.bRecordStop.Size = New System.Drawing.Size(272, 23)
        Me.bRecordStop.TabIndex = 6
        Me.bRecordStop.Text = "Stop recording"
        Me.bRecordStop.UseVisualStyleBackColor = True
        '
        'CarMeter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(761, 493)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "CarMeter"
        Me.Text = "CarMeter"
        Me.Controls.SetChildIndex(Me.logWriter, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents tRate As Timer
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents tTime As Timer
    Friend WithEvents bRecordStop As Button
    Friend WithEvents bRecord As Button
End Class
