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
        Me.cbAutostartRecord30 = New System.Windows.Forms.CheckBox()
        Me.cbAutostartRecord70 = New System.Windows.Forms.CheckBox()
        Me.cbAutostopRecordAt100 = New System.Windows.Forms.CheckBox()
        Me.cbAutostopRecordAt0 = New System.Windows.Forms.CheckBox()
        Me.cbAutostartRecord1 = New System.Windows.Forms.CheckBox()
        Me.cbOk = New System.Windows.Forms.CheckBox()
        Me.bRecordStop = New System.Windows.Forms.Button()
        Me.bRecord = New System.Windows.Forms.Button()
        Me.tbSpeed = New System.Windows.Forms.TextBox()
        Me.tbLocation = New System.Windows.Forms.TextBox()
        Me.tbTime = New System.Windows.Forms.TextBox()
        Me.tbGpsState = New System.Windows.Forms.TextBox()
        Me.tRate = New System.Windows.Forms.Timer(Me.components)
        Me.tTime = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.tbAvgSpeed = New System.Windows.Forms.TextBox()
        Me.tbAvgSpeedTime2 = New System.Windows.Forms.TextBox()
        Me.tbAvgSpeedTime1 = New System.Windows.Forms.TextBox()
        Me.bMeashureAverage = New System.Windows.Forms.Button()
        Me.tbAverageSpeedInfo = New System.Windows.Forms.TextBox()
        Me.bPoint2Set = New System.Windows.Forms.Button()
        Me.bPoint1Set = New System.Windows.Forms.Button()
        Me.tbPoint2 = New System.Windows.Forms.TextBox()
        Me.tbPoint1 = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.tbPointSpeed = New System.Windows.Forms.TextBox()
        Me.tbPoint0time = New System.Windows.Forms.TextBox()
        Me.tbMeashurePoint = New System.Windows.Forms.Button()
        Me.bPoint0Set = New System.Windows.Forms.Button()
        Me.tbPoint0 = New System.Windows.Forms.TextBox()
        Me.cbAutostopRecordAt30 = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'logWriter
        '
        Me.logWriter.ExtendedView = False
        Me.logWriter.Location = New System.Drawing.Point(0, 463)
        Me.logWriter.Size = New System.Drawing.Size(978, 168)
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbAutostopRecordAt30)
        Me.GroupBox1.Controls.Add(Me.cbAutostartRecord30)
        Me.GroupBox1.Controls.Add(Me.cbAutostartRecord70)
        Me.GroupBox1.Controls.Add(Me.cbAutostopRecordAt100)
        Me.GroupBox1.Controls.Add(Me.cbAutostopRecordAt0)
        Me.GroupBox1.Controls.Add(Me.cbAutostartRecord1)
        Me.GroupBox1.Controls.Add(Me.cbOk)
        Me.GroupBox1.Controls.Add(Me.bRecordStop)
        Me.GroupBox1.Controls.Add(Me.bRecord)
        Me.GroupBox1.Controls.Add(Me.tbSpeed)
        Me.GroupBox1.Controls.Add(Me.tbLocation)
        Me.GroupBox1.Controls.Add(Me.tbTime)
        Me.GroupBox1.Controls.Add(Me.tbGpsState)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 27)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(297, 381)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GPS"
        '
        'cbAutostartRecord30
        '
        Me.cbAutostartRecord30.AutoSize = True
        Me.cbAutostartRecord30.Location = New System.Drawing.Point(6, 207)
        Me.cbAutostartRecord30.Name = "cbAutostartRecord30"
        Me.cbAutostartRecord30.Size = New System.Drawing.Size(187, 20)
        Me.cbAutostartRecord30.TabIndex = 12
        Me.cbAutostartRecord30.Text = "Auto Start Record > 30 kmh"
        Me.cbAutostartRecord30.UseVisualStyleBackColor = True
        '
        'cbAutostartRecord70
        '
        Me.cbAutostartRecord70.AutoSize = True
        Me.cbAutostartRecord70.Location = New System.Drawing.Point(6, 233)
        Me.cbAutostartRecord70.Name = "cbAutostartRecord70"
        Me.cbAutostartRecord70.Size = New System.Drawing.Size(187, 20)
        Me.cbAutostartRecord70.TabIndex = 11
        Me.cbAutostartRecord70.Text = "Auto Start Record < 70 kmh"
        Me.cbAutostartRecord70.UseVisualStyleBackColor = True
        '
        'cbAutostopRecordAt100
        '
        Me.cbAutostopRecordAt100.AutoSize = True
        Me.cbAutostopRecordAt100.Location = New System.Drawing.Point(5, 346)
        Me.cbAutostopRecordAt100.Name = "cbAutostopRecordAt100"
        Me.cbAutostopRecordAt100.Size = New System.Drawing.Size(195, 20)
        Me.cbAutostopRecordAt100.TabIndex = 10
        Me.cbAutostopRecordAt100.Text = "Auto Stop Record > 110 kmh"
        Me.cbAutostopRecordAt100.UseVisualStyleBackColor = True
        '
        'cbAutostopRecordAt0
        '
        Me.cbAutostopRecordAt0.AutoSize = True
        Me.cbAutostopRecordAt0.Location = New System.Drawing.Point(6, 289)
        Me.cbAutostopRecordAt0.Name = "cbAutostopRecordAt0"
        Me.cbAutostopRecordAt0.Size = New System.Drawing.Size(181, 20)
        Me.cbAutostopRecordAt0.TabIndex = 9
        Me.cbAutostopRecordAt0.Text = "Auto Stop Record < 2 kmh"
        Me.cbAutostopRecordAt0.UseVisualStyleBackColor = True
        '
        'cbAutostartRecord1
        '
        Me.cbAutostartRecord1.AutoSize = True
        Me.cbAutostartRecord1.Location = New System.Drawing.Point(6, 181)
        Me.cbAutostartRecord1.Name = "cbAutostartRecord1"
        Me.cbAutostartRecord1.Size = New System.Drawing.Size(180, 20)
        Me.cbAutostartRecord1.TabIndex = 8
        Me.cbAutostartRecord1.Text = "Auto Start Record > 1 kmh"
        Me.cbAutostartRecord1.UseVisualStyleBackColor = True
        '
        'cbOk
        '
        Me.cbOk.AutoSize = True
        Me.cbOk.Location = New System.Drawing.Point(155, 25)
        Me.cbOk.Name = "cbOk"
        Me.cbOk.Size = New System.Drawing.Size(45, 20)
        Me.cbOk.TabIndex = 7
        Me.cbOk.Text = "OK"
        Me.cbOk.UseVisualStyleBackColor = True
        '
        'bRecordStop
        '
        Me.bRecordStop.Enabled = False
        Me.bRecordStop.Location = New System.Drawing.Point(154, 113)
        Me.bRecordStop.Name = "bRecordStop"
        Me.bRecordStop.Size = New System.Drawing.Size(137, 62)
        Me.bRecordStop.TabIndex = 6
        Me.bRecordStop.Text = "Stop recording"
        Me.bRecordStop.UseVisualStyleBackColor = True
        '
        'bRecord
        '
        Me.bRecord.Location = New System.Drawing.Point(6, 113)
        Me.bRecord.Name = "bRecord"
        Me.bRecord.Size = New System.Drawing.Size(142, 62)
        Me.bRecord.TabIndex = 5
        Me.bRecord.Text = "Record"
        Me.bRecord.UseVisualStyleBackColor = True
        '
        'tbSpeed
        '
        Me.tbSpeed.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbSpeed.Location = New System.Drawing.Point(154, 53)
        Me.tbSpeed.Name = "tbSpeed"
        Me.tbSpeed.Size = New System.Drawing.Size(137, 22)
        Me.tbSpeed.TabIndex = 4
        '
        'tbLocation
        '
        Me.tbLocation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbLocation.Location = New System.Drawing.Point(6, 83)
        Me.tbLocation.Name = "tbLocation"
        Me.tbLocation.Size = New System.Drawing.Size(285, 22)
        Me.tbLocation.TabIndex = 3
        '
        'tbTime
        '
        Me.tbTime.Location = New System.Drawing.Point(6, 53)
        Me.tbTime.Name = "tbTime"
        Me.tbTime.Size = New System.Drawing.Size(142, 22)
        Me.tbTime.TabIndex = 2
        '
        'tbGpsState
        '
        Me.tbGpsState.Location = New System.Drawing.Point(6, 23)
        Me.tbGpsState.Name = "tbGpsState"
        Me.tbGpsState.Size = New System.Drawing.Size(142, 22)
        Me.tbGpsState.TabIndex = 0
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
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.tbAvgSpeed)
        Me.GroupBox2.Controls.Add(Me.tbAvgSpeedTime2)
        Me.GroupBox2.Controls.Add(Me.tbAvgSpeedTime1)
        Me.GroupBox2.Controls.Add(Me.bMeashureAverage)
        Me.GroupBox2.Controls.Add(Me.tbAverageSpeedInfo)
        Me.GroupBox2.Controls.Add(Me.bPoint2Set)
        Me.GroupBox2.Controls.Add(Me.bPoint1Set)
        Me.GroupBox2.Controls.Add(Me.tbPoint2)
        Me.GroupBox2.Controls.Add(Me.tbPoint1)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(315, 27)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(455, 231)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Average Speed"
        '
        'tbAvgSpeed
        '
        Me.tbAvgSpeed.Location = New System.Drawing.Point(87, 167)
        Me.tbAvgSpeed.Name = "tbAvgSpeed"
        Me.tbAvgSpeed.Size = New System.Drawing.Size(360, 22)
        Me.tbAvgSpeed.TabIndex = 9
        '
        'tbAvgSpeedTime2
        '
        Me.tbAvgSpeedTime2.Location = New System.Drawing.Point(330, 107)
        Me.tbAvgSpeedTime2.Name = "tbAvgSpeedTime2"
        Me.tbAvgSpeedTime2.Size = New System.Drawing.Size(117, 22)
        Me.tbAvgSpeedTime2.TabIndex = 8
        '
        'tbAvgSpeedTime1
        '
        Me.tbAvgSpeedTime1.Location = New System.Drawing.Point(330, 50)
        Me.tbAvgSpeedTime1.Name = "tbAvgSpeedTime1"
        Me.tbAvgSpeedTime1.Size = New System.Drawing.Size(117, 22)
        Me.tbAvgSpeedTime1.TabIndex = 7
        '
        'bMeashureAverage
        '
        Me.bMeashureAverage.Location = New System.Drawing.Point(6, 167)
        Me.bMeashureAverage.Name = "bMeashureAverage"
        Me.bMeashureAverage.Size = New System.Drawing.Size(75, 57)
        Me.bMeashureAverage.TabIndex = 6
        Me.bMeashureAverage.Text = "Start"
        Me.bMeashureAverage.UseVisualStyleBackColor = True
        '
        'tbAverageSpeedInfo
        '
        Me.tbAverageSpeedInfo.Location = New System.Drawing.Point(87, 22)
        Me.tbAverageSpeedInfo.Name = "tbAverageSpeedInfo"
        Me.tbAverageSpeedInfo.Size = New System.Drawing.Size(237, 22)
        Me.tbAverageSpeedInfo.TabIndex = 5
        '
        'bPoint2Set
        '
        Me.bPoint2Set.Location = New System.Drawing.Point(6, 107)
        Me.bPoint2Set.Name = "bPoint2Set"
        Me.bPoint2Set.Size = New System.Drawing.Size(75, 54)
        Me.bPoint2Set.TabIndex = 4
        Me.bPoint2Set.Text = "Point2"
        Me.bPoint2Set.UseVisualStyleBackColor = True
        '
        'bPoint1Set
        '
        Me.bPoint1Set.Location = New System.Drawing.Point(6, 50)
        Me.bPoint1Set.Name = "bPoint1Set"
        Me.bPoint1Set.Size = New System.Drawing.Size(75, 51)
        Me.bPoint1Set.TabIndex = 3
        Me.bPoint1Set.Text = "Point1"
        Me.bPoint1Set.UseVisualStyleBackColor = True
        '
        'tbPoint2
        '
        Me.tbPoint2.Location = New System.Drawing.Point(87, 107)
        Me.tbPoint2.Name = "tbPoint2"
        Me.tbPoint2.Size = New System.Drawing.Size(237, 22)
        Me.tbPoint2.TabIndex = 2
        '
        'tbPoint1
        '
        Me.tbPoint1.Location = New System.Drawing.Point(87, 50)
        Me.tbPoint1.Name = "tbPoint1"
        Me.tbPoint1.Size = New System.Drawing.Size(237, 22)
        Me.tbPoint1.TabIndex = 1
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.tbPointSpeed)
        Me.GroupBox3.Controls.Add(Me.tbPoint0time)
        Me.GroupBox3.Controls.Add(Me.tbMeashurePoint)
        Me.GroupBox3.Controls.Add(Me.bPoint0Set)
        Me.GroupBox3.Controls.Add(Me.tbPoint0)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(315, 264)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(455, 144)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Point Speed"
        '
        'tbPointSpeed
        '
        Me.tbPointSpeed.Location = New System.Drawing.Point(87, 79)
        Me.tbPointSpeed.Name = "tbPointSpeed"
        Me.tbPointSpeed.Size = New System.Drawing.Size(360, 22)
        Me.tbPointSpeed.TabIndex = 9
        '
        'tbPoint0time
        '
        Me.tbPoint0time.Location = New System.Drawing.Point(330, 22)
        Me.tbPoint0time.Name = "tbPoint0time"
        Me.tbPoint0time.Size = New System.Drawing.Size(117, 22)
        Me.tbPoint0time.TabIndex = 7
        '
        'tbMeashurePoint
        '
        Me.tbMeashurePoint.Location = New System.Drawing.Point(6, 79)
        Me.tbMeashurePoint.Name = "tbMeashurePoint"
        Me.tbMeashurePoint.Size = New System.Drawing.Size(75, 57)
        Me.tbMeashurePoint.TabIndex = 6
        Me.tbMeashurePoint.Text = "Start"
        Me.tbMeashurePoint.UseVisualStyleBackColor = True
        '
        'bPoint0Set
        '
        Me.bPoint0Set.Location = New System.Drawing.Point(6, 22)
        Me.bPoint0Set.Name = "bPoint0Set"
        Me.bPoint0Set.Size = New System.Drawing.Size(75, 51)
        Me.bPoint0Set.TabIndex = 3
        Me.bPoint0Set.Text = "Point"
        Me.bPoint0Set.UseVisualStyleBackColor = True
        '
        'tbPoint0
        '
        Me.tbPoint0.Location = New System.Drawing.Point(87, 22)
        Me.tbPoint0.Name = "tbPoint0"
        Me.tbPoint0.Size = New System.Drawing.Size(237, 22)
        Me.tbPoint0.TabIndex = 1
        '
        'cbAutostopRecordAt30
        '
        Me.cbAutostopRecordAt30.AutoSize = True
        Me.cbAutostopRecordAt30.Location = New System.Drawing.Point(6, 317)
        Me.cbAutostopRecordAt30.Name = "cbAutostopRecordAt30"
        Me.cbAutostopRecordAt30.Size = New System.Drawing.Size(188, 20)
        Me.cbAutostopRecordAt30.TabIndex = 13
        Me.cbAutostopRecordAt30.Text = "Auto Stop Record < 30 kmh"
        Me.cbAutostopRecordAt30.UseVisualStyleBackColor = True
        '
        'CarMeter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(978, 634)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "CarMeter"
        Me.Text = "Bwl CarMeter"
        Me.Controls.SetChildIndex(Me.logWriter, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.GroupBox3, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents tbGpsState As TextBox
    Friend WithEvents tRate As Timer
    Friend WithEvents tbLocation As TextBox
    Friend WithEvents tbTime As TextBox
    Friend WithEvents tbSpeed As TextBox
    Friend WithEvents tTime As Timer
    Friend WithEvents bRecordStop As Button
    Friend WithEvents bRecord As Button
    Friend WithEvents cbOk As CheckBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cbAutostopRecordAt100 As CheckBox
    Friend WithEvents cbAutostopRecordAt0 As CheckBox
    Friend WithEvents cbAutostartRecord1 As CheckBox
    Friend WithEvents tbPoint2 As TextBox
    Friend WithEvents tbPoint1 As TextBox
    Friend WithEvents cbAutostartRecord70 As CheckBox
    Friend WithEvents bPoint2Set As Button
    Friend WithEvents bPoint1Set As Button
    Friend WithEvents tbAverageSpeedInfo As TextBox
    Friend WithEvents tbAvgSpeed As TextBox
    Friend WithEvents tbAvgSpeedTime2 As TextBox
    Friend WithEvents tbAvgSpeedTime1 As TextBox
    Friend WithEvents bMeashureAverage As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents tbPointSpeed As TextBox
    Friend WithEvents tbPoint0time As TextBox
    Friend WithEvents tbMeashurePoint As Button
    Friend WithEvents bPoint0Set As Button
    Friend WithEvents tbPoint0 As TextBox
    Friend WithEvents cbAutostartRecord30 As CheckBox
    Friend WithEvents cbAutostopRecordAt30 As CheckBox
End Class
