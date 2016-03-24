<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PassWord
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
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.PWDLabel = New System.Windows.Forms.Label()
        Me.PWDBox = New System.Windows.Forms.TextBox()
        Me.InfoLabel = New System.Windows.Forms.Label()
        Me.UserNameTextBox = New System.Windows.Forms.TextBox()
        Me.UserNameLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ButtonOK
        '
        Me.ButtonOK.Location = New System.Drawing.Point(161, 115)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(75, 23)
        Me.ButtonOK.TabIndex = 0
        Me.ButtonOK.Text = "确定"
        Me.ButtonOK.UseVisualStyleBackColor = True
        '
        'PWDLabel
        '
        Me.PWDLabel.AutoSize = True
        Me.PWDLabel.Font = New System.Drawing.Font("微软雅黑", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.PWDLabel.Location = New System.Drawing.Point(33, 59)
        Me.PWDLabel.Name = "PWDLabel"
        Me.PWDLabel.Size = New System.Drawing.Size(38, 19)
        Me.PWDLabel.TabIndex = 1
        Me.PWDLabel.Text = "密码:"
        '
        'PWDBox
        '
        Me.PWDBox.Font = New System.Drawing.Font("微软雅黑", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.PWDBox.Location = New System.Drawing.Point(80, 56)
        Me.PWDBox.Name = "PWDBox"
        Me.PWDBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.PWDBox.Size = New System.Drawing.Size(156, 25)
        Me.PWDBox.TabIndex = 2
        '
        'InfoLabel
        '
        Me.InfoLabel.AutoSize = True
        Me.InfoLabel.Font = New System.Drawing.Font("微软雅黑", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.InfoLabel.ForeColor = System.Drawing.Color.Red
        Me.InfoLabel.Location = New System.Drawing.Point(31, 87)
        Me.InfoLabel.Name = "InfoLabel"
        Me.InfoLabel.Size = New System.Drawing.Size(155, 19)
        Me.InfoLabel.TabIndex = 3
        Me.InfoLabel.Text = "提示:请输入密码进行验证"
        '
        'UserNameTextBox
        '
        Me.UserNameTextBox.Enabled = False
        Me.UserNameTextBox.Font = New System.Drawing.Font("微软雅黑", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.UserNameTextBox.Location = New System.Drawing.Point(80, 12)
        Me.UserNameTextBox.Name = "UserNameTextBox"
        Me.UserNameTextBox.Size = New System.Drawing.Size(156, 25)
        Me.UserNameTextBox.TabIndex = 5
        '
        'UserNameLabel
        '
        Me.UserNameLabel.AutoSize = True
        Me.UserNameLabel.Font = New System.Drawing.Font("微软雅黑", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.UserNameLabel.Location = New System.Drawing.Point(33, 15)
        Me.UserNameLabel.Name = "UserNameLabel"
        Me.UserNameLabel.Size = New System.Drawing.Size(38, 19)
        Me.UserNameLabel.TabIndex = 4
        Me.UserNameLabel.Text = "账号:"
        '
        'PassWord
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(269, 155)
        Me.Controls.Add(Me.UserNameTextBox)
        Me.Controls.Add(Me.UserNameLabel)
        Me.Controls.Add(Me.InfoLabel)
        Me.Controls.Add(Me.PWDBox)
        Me.Controls.Add(Me.PWDLabel)
        Me.Controls.Add(Me.ButtonOK)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PassWord"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "密码验证"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonOK As System.Windows.Forms.Button
    Friend WithEvents PWDLabel As System.Windows.Forms.Label
    Friend WithEvents PWDBox As System.Windows.Forms.TextBox
    Friend WithEvents InfoLabel As System.Windows.Forms.Label
    Friend WithEvents UserNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents UserNameLabel As System.Windows.Forms.Label
End Class
