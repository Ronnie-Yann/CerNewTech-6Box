<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SMSForm
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SMSForm))
        Me.PhoneNum_Label = New System.Windows.Forms.Label()
        Me.PhoneBox = New System.Windows.Forms.TextBox()
        Me.Identify_Label = New System.Windows.Forms.Label()
        Me.IdentifyBox = New System.Windows.Forms.TextBox()
        Me.GetIdentifyButton = New System.Windows.Forms.Button()
        Me.Timer = New System.Windows.Forms.Timer(Me.components)
        Me.InfoLabel = New System.Windows.Forms.Label()
        Me.InfoText = New System.Windows.Forms.Label()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'PhoneNum_Label
        '
        Me.PhoneNum_Label.AutoSize = True
        Me.PhoneNum_Label.Font = New System.Drawing.Font("微软雅黑", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.PhoneNum_Label.Location = New System.Drawing.Point(36, 21)
        Me.PhoneNum_Label.Name = "PhoneNum_Label"
        Me.PhoneNum_Label.Size = New System.Drawing.Size(51, 19)
        Me.PhoneNum_Label.TabIndex = 0
        Me.PhoneNum_Label.Text = "手机号:"
        Me.PhoneNum_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PhoneBox
        '
        Me.PhoneBox.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.PhoneBox.Location = New System.Drawing.Point(91, 20)
        Me.PhoneBox.MaxLength = 11
        Me.PhoneBox.Name = "PhoneBox"
        Me.PhoneBox.Size = New System.Drawing.Size(150, 21)
        Me.PhoneBox.TabIndex = 1
        '
        'Identify_Label
        '
        Me.Identify_Label.AutoSize = True
        Me.Identify_Label.Font = New System.Drawing.Font("微软雅黑", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Identify_Label.Location = New System.Drawing.Point(36, 66)
        Me.Identify_Label.Name = "Identify_Label"
        Me.Identify_Label.Size = New System.Drawing.Size(51, 19)
        Me.Identify_Label.TabIndex = 2
        Me.Identify_Label.Text = "验证码:"
        Me.Identify_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'IdentifyBox
        '
        Me.IdentifyBox.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.IdentifyBox.Location = New System.Drawing.Point(90, 66)
        Me.IdentifyBox.MaxLength = 6
        Me.IdentifyBox.Name = "IdentifyBox"
        Me.IdentifyBox.Size = New System.Drawing.Size(65, 21)
        Me.IdentifyBox.TabIndex = 3
        '
        'GetIdentifyButton
        '
        Me.GetIdentifyButton.Location = New System.Drawing.Point(170, 64)
        Me.GetIdentifyButton.Name = "GetIdentifyButton"
        Me.GetIdentifyButton.Size = New System.Drawing.Size(73, 23)
        Me.GetIdentifyButton.TabIndex = 4
        Me.GetIdentifyButton.Text = "获取验证码"
        Me.GetIdentifyButton.UseVisualStyleBackColor = True
        '
        'Timer
        '
        '
        'InfoLabel
        '
        Me.InfoLabel.AutoSize = True
        Me.InfoLabel.Font = New System.Drawing.Font("微软雅黑", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.InfoLabel.Location = New System.Drawing.Point(24, 108)
        Me.InfoLabel.Name = "InfoLabel"
        Me.InfoLabel.Size = New System.Drawing.Size(64, 19)
        Me.InfoLabel.TabIndex = 5
        Me.InfoLabel.Text = "提示信息:"
        Me.InfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'InfoText
        '
        Me.InfoText.AutoSize = True
        Me.InfoText.Font = New System.Drawing.Font("微软雅黑", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.InfoText.Location = New System.Drawing.Point(84, 108)
        Me.InfoText.Name = "InfoText"
        Me.InfoText.Size = New System.Drawing.Size(100, 19)
        Me.InfoText.TabIndex = 6
        Me.InfoText.Text = "请输入手机号码"
        Me.InfoText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ButtonOK
        '
        Me.ButtonOK.Enabled = False
        Me.ButtonOK.Location = New System.Drawing.Point(246, 64)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(47, 23)
        Me.ButtonOK.TabIndex = 7
        Me.ButtonOK.Text = "确定"
        Me.ButtonOK.UseVisualStyleBackColor = True
        '
        'SMSForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(304, 153)
        Me.Controls.Add(Me.ButtonOK)
        Me.Controls.Add(Me.InfoText)
        Me.Controls.Add(Me.InfoLabel)
        Me.Controls.Add(Me.GetIdentifyButton)
        Me.Controls.Add(Me.IdentifyBox)
        Me.Controls.Add(Me.Identify_Label)
        Me.Controls.Add(Me.PhoneBox)
        Me.Controls.Add(Me.PhoneNum_Label)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SMSForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "手机验证"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PhoneNum_Label As System.Windows.Forms.Label
    Friend WithEvents PhoneBox As System.Windows.Forms.TextBox
    Friend WithEvents Identify_Label As System.Windows.Forms.Label
    Friend WithEvents IdentifyBox As System.Windows.Forms.TextBox
    Friend WithEvents GetIdentifyButton As System.Windows.Forms.Button
    Friend WithEvents Timer As System.Windows.Forms.Timer
    Friend WithEvents InfoLabel As System.Windows.Forms.Label
    Friend WithEvents InfoText As System.Windows.Forms.Label
    Friend WithEvents ButtonOK As System.Windows.Forms.Button
End Class
