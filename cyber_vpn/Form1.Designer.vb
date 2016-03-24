<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ShowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HideToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TimerLog = New System.Windows.Forms.Timer(Me.components)
        Me.getMyData = New System.ComponentModel.BackgroundWorker()
        Me.updateChecker = New System.ComponentModel.BackgroundWorker()
        Me.ImageTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer_Notice = New System.Windows.Forms.Timer(Me.components)
        Me.ChromeThemeContainer1 = New SixGrade.ChromeThemeContainer()
        Me.loglabel = New System.Windows.Forms.Label()
        Me.LogButton = New SixGrade.ChromeButton()
        Me.Logs = New System.Windows.Forms.RichTextBox()
        Me.GplusBox = New System.Windows.Forms.PictureBox()
        Me.TwitterBox = New System.Windows.Forms.PictureBox()
        Me.FacebookBox = New System.Windows.Forms.PictureBox()
        Me.CopyrightBox = New System.Windows.Forms.Label()
        Me.UDPButton = New SixGrade.FlatRadioButton()
        Me.ProtocolLabel = New System.Windows.Forms.Label()
        Me.ChromeSeparator1 = New SixGrade.ChromeSeparator()
        Me.ServerLabel = New System.Windows.Forms.Label()
        Me.ServersBox = New SixGrade.FlatCombo()
        Me.FlatGroupBox1 = New SixGrade.FlatGroupBox()
        Me.DropButton = New SixGrade.FlatButton()
        Me.LinkLabel = New System.Windows.Forms.LinkLabel()
        Me.RecBox = New System.Windows.Forms.Label()
        Me.SentBox = New System.Windows.Forms.Label()
        Me.AboutButton = New SixGrade.FlatButton()
        Me.RecLabel = New System.Windows.Forms.Label()
        Me.SentLabel = New System.Windows.Forms.Label()
        Me.InfoLabel = New System.Windows.Forms.Label()
        Me.InfoBar = New System.Windows.Forms.Label()
        Me.SettingsButton = New SixGrade.FlatButton()
        Me.TCPButton = New SixGrade.FlatRadioButton()
        Me.ConnectButton = New SixGrade.FlatButton()
        Me.IconBox = New System.Windows.Forms.PictureBox()
        Me.LogoBox = New System.Windows.Forms.PictureBox()
        Me.ChromeSeparator2 = New SixGrade.ChromeSeparator()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ChromeThemeContainer1.SuspendLayout()
        CType(Me.GplusBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TwitterBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FacebookBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlatGroupBox1.SuspendLayout()
        CType(Me.IconBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LogoBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "六年级"
        Me.NotifyIcon1.Visible = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowToolStripMenuItem, Me.HideToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(101, 70)
        '
        'ShowToolStripMenuItem
        '
        Me.ShowToolStripMenuItem.Name = "ShowToolStripMenuItem"
        Me.ShowToolStripMenuItem.Size = New System.Drawing.Size(100, 22)
        Me.ShowToolStripMenuItem.Text = "显示"
        '
        'HideToolStripMenuItem
        '
        Me.HideToolStripMenuItem.Name = "HideToolStripMenuItem"
        Me.HideToolStripMenuItem.Size = New System.Drawing.Size(100, 22)
        Me.HideToolStripMenuItem.Text = "隐藏"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(100, 22)
        Me.ExitToolStripMenuItem.Text = "退出"
        '
        'Timer1
        '
        '
        'TimerLog
        '
        '
        'getMyData
        '
        '
        'updateChecker
        '
        '
        'ImageTimer
        '
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "logo1.png")
        Me.ImageList1.Images.SetKeyName(1, "1.png")
        '
        'Timer2
        '
        '
        'Timer_Notice
        '
        '
        'ChromeThemeContainer1
        '
        Me.ChromeThemeContainer1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ChromeThemeContainer1.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.ChromeThemeContainer1.Controls.Add(Me.loglabel)
        Me.ChromeThemeContainer1.Controls.Add(Me.LogButton)
        Me.ChromeThemeContainer1.Controls.Add(Me.Logs)
        Me.ChromeThemeContainer1.Controls.Add(Me.GplusBox)
        Me.ChromeThemeContainer1.Controls.Add(Me.TwitterBox)
        Me.ChromeThemeContainer1.Controls.Add(Me.FacebookBox)
        Me.ChromeThemeContainer1.Controls.Add(Me.CopyrightBox)
        Me.ChromeThemeContainer1.Controls.Add(Me.UDPButton)
        Me.ChromeThemeContainer1.Controls.Add(Me.ProtocolLabel)
        Me.ChromeThemeContainer1.Controls.Add(Me.ChromeSeparator1)
        Me.ChromeThemeContainer1.Controls.Add(Me.ServerLabel)
        Me.ChromeThemeContainer1.Controls.Add(Me.ServersBox)
        Me.ChromeThemeContainer1.Controls.Add(Me.FlatGroupBox1)
        Me.ChromeThemeContainer1.Controls.Add(Me.IconBox)
        Me.ChromeThemeContainer1.Controls.Add(Me.LogoBox)
        Me.ChromeThemeContainer1.Controls.Add(Me.ChromeSeparator2)
        Me.ChromeThemeContainer1.Customization = "AAAA/1paWv9ycnL/"
        Me.ChromeThemeContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ChromeThemeContainer1.Font = New System.Drawing.Font("微软雅黑", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ChromeThemeContainer1.Image = Nothing
        Me.ChromeThemeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ChromeThemeContainer1.Movable = True
        Me.ChromeThemeContainer1.Name = "ChromeThemeContainer1"
        Me.ChromeThemeContainer1.NoRounding = False
        Me.ChromeThemeContainer1.Sizable = True
        Me.ChromeThemeContainer1.Size = New System.Drawing.Size(336, 398)
        Me.ChromeThemeContainer1.SmartBounds = True
        Me.ChromeThemeContainer1.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.ChromeThemeContainer1.TabIndex = 0
        Me.ChromeThemeContainer1.Text = "    6Box"
        Me.ChromeThemeContainer1.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.ChromeThemeContainer1.Transparent = False
        '
        'loglabel
        '
        Me.loglabel.AutoSize = True
        Me.loglabel.Font = New System.Drawing.Font("微软雅黑", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.loglabel.Location = New System.Drawing.Point(248, 316)
        Me.loglabel.Name = "loglabel"
        Me.loglabel.Size = New System.Drawing.Size(61, 19)
        Me.loglabel.TabIndex = 29
        Me.loglabel.Text = "查看日志"
        '
        'LogButton
        '
        Me.LogButton.Customization = "7e3t//Ly8v/r6+v/5ubm/+vr6//f39//p6en/zw8PP8UFBT/gICA/w=="
        Me.LogButton.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.LogButton.Image = Nothing
        Me.LogButton.Location = New System.Drawing.Point(311, 316)
        Me.LogButton.Name = "LogButton"
        Me.LogButton.NoRounding = False
        Me.LogButton.Size = New System.Drawing.Size(21, 21)
        Me.LogButton.TabIndex = 28
        Me.LogButton.Text = ">"
        Me.LogButton.Transparent = False
        '
        'Logs
        '
        Me.Logs.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Logs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Logs.Location = New System.Drawing.Point(338, 29)
        Me.Logs.Name = "Logs"
        Me.Logs.Size = New System.Drawing.Size(307, 368)
        Me.Logs.TabIndex = 27
        Me.Logs.Text = ""
        '
        'GplusBox
        '
        Me.GplusBox.Image = Global.SixGrade.My.Resources.Resources.Twitter_32
        Me.GplusBox.Location = New System.Drawing.Point(70, 313)
        Me.GplusBox.Name = "GplusBox"
        Me.GplusBox.Size = New System.Drawing.Size(24, 22)
        Me.GplusBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.GplusBox.TabIndex = 26
        Me.GplusBox.TabStop = False
        Me.GplusBox.Visible = False
        '
        'TwitterBox
        '
        Me.TwitterBox.Image = Global.SixGrade.My.Resources.Resources.Facebook_32
        Me.TwitterBox.Location = New System.Drawing.Point(40, 313)
        Me.TwitterBox.Name = "TwitterBox"
        Me.TwitterBox.Size = New System.Drawing.Size(24, 22)
        Me.TwitterBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.TwitterBox.TabIndex = 25
        Me.TwitterBox.TabStop = False
        Me.TwitterBox.Visible = False
        '
        'FacebookBox
        '
        Me.FacebookBox.Image = Global.SixGrade.My.Resources.Resources.GooglePlus_32
        Me.FacebookBox.Location = New System.Drawing.Point(10, 313)
        Me.FacebookBox.Name = "FacebookBox"
        Me.FacebookBox.Size = New System.Drawing.Size(24, 22)
        Me.FacebookBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.FacebookBox.TabIndex = 24
        Me.FacebookBox.TabStop = False
        Me.FacebookBox.Visible = False
        '
        'CopyrightBox
        '
        Me.CopyrightBox.AutoSize = True
        Me.CopyrightBox.BackColor = System.Drawing.Color.Transparent
        Me.CopyrightBox.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CopyrightBox.ForeColor = System.Drawing.Color.Gray
        Me.CopyrightBox.Location = New System.Drawing.Point(49, 345)
        Me.CopyrightBox.Name = "CopyrightBox"
        Me.CopyrightBox.Size = New System.Drawing.Size(223, 15)
        Me.CopyrightBox.TabIndex = 23
        Me.CopyrightBox.Text = "版权归赛尔新技术(北京)有限公司所有"
        '
        'UDPButton
        '
        Me.UDPButton.Checked = False
        Me.UDPButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UDPButton.Location = New System.Drawing.Point(193, 202)
        Me.UDPButton.Name = "UDPButton"
        Me.UDPButton.Size = New System.Drawing.Size(103, 18)
        Me.UDPButton.TabIndex = 11
        Me.UDPButton.Text = "UDP"
        Me.UDPButton.Visible = False
        '
        'ProtocolLabel
        '
        Me.ProtocolLabel.AutoSize = True
        Me.ProtocolLabel.BackColor = System.Drawing.Color.Transparent
        Me.ProtocolLabel.Font = New System.Drawing.Font("微软雅黑", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ProtocolLabel.Location = New System.Drawing.Point(10, 179)
        Me.ProtocolLabel.Name = "ProtocolLabel"
        Me.ProtocolLabel.Size = New System.Drawing.Size(61, 19)
        Me.ProtocolLabel.TabIndex = 8
        Me.ProtocolLabel.Text = "通讯协议"
        Me.ProtocolLabel.Visible = False
        '
        'ChromeSeparator1
        '
        Me.ChromeSeparator1.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.ChromeSeparator1.Colors = New SixGrade.Bloom(-1) {}
        Me.ChromeSeparator1.Customization = ""
        Me.ChromeSeparator1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.ChromeSeparator1.Image = Nothing
        Me.ChromeSeparator1.Location = New System.Drawing.Point(92, 138)
        Me.ChromeSeparator1.Name = "ChromeSeparator1"
        Me.ChromeSeparator1.NoRounding = False
        Me.ChromeSeparator1.Size = New System.Drawing.Size(240, 1)
        Me.ChromeSeparator1.TabIndex = 7
        Me.ChromeSeparator1.Text = "ChromeSeparator1"
        Me.ChromeSeparator1.Transparent = False
        '
        'ServerLabel
        '
        Me.ServerLabel.AutoSize = True
        Me.ServerLabel.BackColor = System.Drawing.Color.Transparent
        Me.ServerLabel.Font = New System.Drawing.Font("微软雅黑", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ServerLabel.Location = New System.Drawing.Point(9, 129)
        Me.ServerLabel.Name = "ServerLabel"
        Me.ServerLabel.Size = New System.Drawing.Size(74, 19)
        Me.ServerLabel.TabIndex = 6
        Me.ServerLabel.Text = "服务器列表"
        '
        'ServersBox
        '
        Me.ServersBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ServersBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ServersBox.Font = New System.Drawing.Font("微软雅黑", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ServersBox.FormattingEnabled = True
        Me.ServersBox.ItemHeight = 20
        Me.ServersBox.Location = New System.Drawing.Point(21, 152)
        Me.ServersBox.Name = "ServersBox"
        Me.ServersBox.Size = New System.Drawing.Size(302, 26)
        Me.ServersBox.TabIndex = 4
        '
        'FlatGroupBox1
        '
        Me.FlatGroupBox1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.FlatGroupBox1.Controls.Add(Me.DropButton)
        Me.FlatGroupBox1.Controls.Add(Me.LinkLabel)
        Me.FlatGroupBox1.Controls.Add(Me.RecBox)
        Me.FlatGroupBox1.Controls.Add(Me.SentBox)
        Me.FlatGroupBox1.Controls.Add(Me.AboutButton)
        Me.FlatGroupBox1.Controls.Add(Me.RecLabel)
        Me.FlatGroupBox1.Controls.Add(Me.SentLabel)
        Me.FlatGroupBox1.Controls.Add(Me.InfoLabel)
        Me.FlatGroupBox1.Controls.Add(Me.InfoBar)
        Me.FlatGroupBox1.Controls.Add(Me.SettingsButton)
        Me.FlatGroupBox1.Controls.Add(Me.TCPButton)
        Me.FlatGroupBox1.Controls.Add(Me.ConnectButton)
        Me.FlatGroupBox1.Font = New System.Drawing.Font("宋体", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.FlatGroupBox1.Location = New System.Drawing.Point(-2, 189)
        Me.FlatGroupBox1.Name = "FlatGroupBox1"
        Me.FlatGroupBox1.Size = New System.Drawing.Size(338, 119)
        Me.FlatGroupBox1.TabIndex = 3
        Me.FlatGroupBox1.Text = "FlatGroupBox1"
        '
        'DropButton
        '
        Me.DropButton.ButtonStyle = SixGrade.FlatButton.Style.Blue
        Me.DropButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DropButton.Font = New System.Drawing.Font("微软雅黑", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DropButton.Image = Nothing
        Me.DropButton.Location = New System.Drawing.Point(98, 85)
        Me.DropButton.Name = "DropButton"
        Me.DropButton.RoundedCorners = False
        Me.DropButton.Size = New System.Drawing.Size(62, 24)
        Me.DropButton.TabIndex = 27
        Me.DropButton.Text = "强制下线"
        '
        'LinkLabel
        '
        Me.LinkLabel.AutoSize = True
        Me.LinkLabel.Font = New System.Drawing.Font("微软雅黑", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LinkLabel.Location = New System.Drawing.Point(225, 58)
        Me.LinkLabel.Name = "LinkLabel"
        Me.LinkLabel.Size = New System.Drawing.Size(101, 16)
        Me.LinkLabel.TabIndex = 26
        Me.LinkLabel.TabStop = True
        Me.LinkLabel.Text = "服务到期?点此续费"
        '
        'RecBox
        '
        Me.RecBox.AutoSize = True
        Me.RecBox.BackColor = System.Drawing.Color.Transparent
        Me.RecBox.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RecBox.Location = New System.Drawing.Point(93, 57)
        Me.RecBox.Name = "RecBox"
        Me.RecBox.Size = New System.Drawing.Size(56, 17)
        Me.RecBox.TabIndex = 25
        Me.RecBox.Text = "0.00 Mb"
        '
        'SentBox
        '
        Me.SentBox.AutoSize = True
        Me.SentBox.BackColor = System.Drawing.Color.Transparent
        Me.SentBox.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SentBox.Location = New System.Drawing.Point(93, 36)
        Me.SentBox.Name = "SentBox"
        Me.SentBox.Size = New System.Drawing.Size(56, 17)
        Me.SentBox.TabIndex = 24
        Me.SentBox.Text = "0.00 Mb"
        '
        'AboutButton
        '
        Me.AboutButton.ButtonStyle = SixGrade.FlatButton.Style.Blue
        Me.AboutButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.AboutButton.Font = New System.Drawing.Font("微软雅黑", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AboutButton.Image = Nothing
        Me.AboutButton.Location = New System.Drawing.Point(252, 86)
        Me.AboutButton.Name = "AboutButton"
        Me.AboutButton.RoundedCorners = False
        Me.AboutButton.Size = New System.Drawing.Size(61, 24)
        Me.AboutButton.TabIndex = 11
        Me.AboutButton.Text = "关  于"
        '
        'RecLabel
        '
        Me.RecLabel.AutoSize = True
        Me.RecLabel.BackColor = System.Drawing.Color.Transparent
        Me.RecLabel.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RecLabel.Location = New System.Drawing.Point(39, 57)
        Me.RecLabel.Name = "RecLabel"
        Me.RecLabel.Size = New System.Drawing.Size(47, 17)
        Me.RecLabel.TabIndex = 10
        Me.RecLabel.Text = "接收量:"
        '
        'SentLabel
        '
        Me.SentLabel.AutoSize = True
        Me.SentLabel.BackColor = System.Drawing.Color.Transparent
        Me.SentLabel.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.SentLabel.Location = New System.Drawing.Point(40, 36)
        Me.SentLabel.Name = "SentLabel"
        Me.SentLabel.Size = New System.Drawing.Size(51, 17)
        Me.SentLabel.TabIndex = 9
        Me.SentLabel.Text = "发送量: "
        '
        'InfoLabel
        '
        Me.InfoLabel.AutoSize = True
        Me.InfoLabel.BackColor = System.Drawing.Color.Transparent
        Me.InfoLabel.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.InfoLabel.Location = New System.Drawing.Point(28, 13)
        Me.InfoLabel.Name = "InfoLabel"
        Me.InfoLabel.Size = New System.Drawing.Size(63, 17)
        Me.InfoLabel.TabIndex = 8
        Me.InfoLabel.Text = "连接状态: "
        '
        'InfoBar
        '
        Me.InfoBar.AutoSize = True
        Me.InfoBar.BackColor = System.Drawing.Color.Transparent
        Me.InfoBar.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InfoBar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.InfoBar.Location = New System.Drawing.Point(93, 14)
        Me.InfoBar.Name = "InfoBar"
        Me.InfoBar.Size = New System.Drawing.Size(44, 17)
        Me.InfoBar.TabIndex = 7
        Me.InfoBar.Text = "未连接"
        '
        'SettingsButton
        '
        Me.SettingsButton.ButtonStyle = SixGrade.FlatButton.Style.Blue
        Me.SettingsButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SettingsButton.Font = New System.Drawing.Font("微软雅黑", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SettingsButton.Image = Nothing
        Me.SettingsButton.Location = New System.Drawing.Point(173, 86)
        Me.SettingsButton.Name = "SettingsButton"
        Me.SettingsButton.RoundedCorners = False
        Me.SettingsButton.Size = New System.Drawing.Size(61, 24)
        Me.SettingsButton.TabIndex = 6
        Me.SettingsButton.Text = "设  置"
        '
        'TCPButton
        '
        Me.TCPButton.BackColor = System.Drawing.Color.White
        Me.TCPButton.Checked = False
        Me.TCPButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCPButton.ForeColor = System.Drawing.Color.SteelBlue
        Me.TCPButton.Location = New System.Drawing.Point(82, 14)
        Me.TCPButton.Name = "TCPButton"
        Me.TCPButton.Size = New System.Drawing.Size(107, 18)
        Me.TCPButton.TabIndex = 10
        Me.TCPButton.Text = "TCP"
        Me.TCPButton.Visible = False
        '
        'ConnectButton
        '
        Me.ConnectButton.ButtonStyle = SixGrade.FlatButton.Style.Blue
        Me.ConnectButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ConnectButton.Font = New System.Drawing.Font("微软雅黑", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ConnectButton.Image = Nothing
        Me.ConnectButton.Location = New System.Drawing.Point(24, 86)
        Me.ConnectButton.Name = "ConnectButton"
        Me.ConnectButton.RoundedCorners = False
        Me.ConnectButton.Size = New System.Drawing.Size(61, 24)
        Me.ConnectButton.TabIndex = 5
        Me.ConnectButton.Text = "连  接"
        '
        'IconBox
        '
        Me.IconBox.Image = Global.SixGrade.My.Resources.Resources.cernet_gui
        Me.IconBox.Location = New System.Drawing.Point(5, 8)
        Me.IconBox.Name = "IconBox"
        Me.IconBox.Size = New System.Drawing.Size(18, 17)
        Me.IconBox.TabIndex = 2
        Me.IconBox.TabStop = False
        '
        'LogoBox
        '
        Me.LogoBox.ErrorImage = Nothing
        Me.LogoBox.Image = Global.SixGrade.My.Resources.Resources.stretch
        Me.LogoBox.Location = New System.Drawing.Point(0, 29)
        Me.LogoBox.Name = "LogoBox"
        Me.LogoBox.Size = New System.Drawing.Size(338, 83)
        Me.LogoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.LogoBox.TabIndex = 1
        Me.LogoBox.TabStop = False
        '
        'ChromeSeparator2
        '
        Me.ChromeSeparator2.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.ChromeSeparator2.Colors = New SixGrade.Bloom(-1) {}
        Me.ChromeSeparator2.Customization = ""
        Me.ChromeSeparator2.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.ChromeSeparator2.Image = Nothing
        Me.ChromeSeparator2.Location = New System.Drawing.Point(79, 195)
        Me.ChromeSeparator2.Name = "ChromeSeparator2"
        Me.ChromeSeparator2.NoRounding = False
        Me.ChromeSeparator2.Size = New System.Drawing.Size(248, 1)
        Me.ChromeSeparator2.TabIndex = 9
        Me.ChromeSeparator2.Text = "ChromeSeparator2"
        Me.ChromeSeparator2.Transparent = False
        Me.ChromeSeparator2.Visible = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(336, 398)
        Me.Controls.Add(Me.ChromeThemeContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "六年级"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ChromeThemeContainer1.ResumeLayout(False)
        Me.ChromeThemeContainer1.PerformLayout()
        CType(Me.GplusBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TwitterBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FacebookBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlatGroupBox1.ResumeLayout(False)
        Me.FlatGroupBox1.PerformLayout()
        CType(Me.IconBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LogoBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ChromeThemeContainer1 As SixGrade.ChromeThemeContainer
    Friend WithEvents LogoBox As System.Windows.Forms.PictureBox
    Friend WithEvents IconBox As System.Windows.Forms.PictureBox
    Friend WithEvents FlatGroupBox1 As SixGrade.FlatGroupBox
    Friend WithEvents ServersBox As SixGrade.FlatCombo
    Friend WithEvents ConnectButton As SixGrade.FlatButton
    Friend WithEvents ServerLabel As System.Windows.Forms.Label
    Friend WithEvents ChromeSeparator1 As SixGrade.ChromeSeparator
    Friend WithEvents ChromeSeparator2 As SixGrade.ChromeSeparator
    Friend WithEvents ProtocolLabel As System.Windows.Forms.Label
    Friend WithEvents CopyrightBox As System.Windows.Forms.Label
    Friend WithEvents UDPButton As SixGrade.FlatRadioButton
    Friend WithEvents TCPButton As SixGrade.FlatRadioButton
    Friend WithEvents InfoLabel As System.Windows.Forms.Label
    Friend WithEvents InfoBar As System.Windows.Forms.Label
    Friend WithEvents SettingsButton As SixGrade.FlatButton
    Friend WithEvents RecBox As System.Windows.Forms.Label
    Friend WithEvents SentBox As System.Windows.Forms.Label
    Friend WithEvents AboutButton As SixGrade.FlatButton
    Friend WithEvents RecLabel As System.Windows.Forms.Label
    Friend WithEvents SentLabel As System.Windows.Forms.Label
    Friend WithEvents FacebookBox As System.Windows.Forms.PictureBox
    Friend WithEvents GplusBox As System.Windows.Forms.PictureBox
    Friend WithEvents TwitterBox As System.Windows.Forms.PictureBox
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ShowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HideToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Logs As System.Windows.Forms.RichTextBox
    Friend WithEvents LogButton As SixGrade.ChromeButton
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents TimerLog As System.Windows.Forms.Timer
    Friend WithEvents getMyData As System.ComponentModel.BackgroundWorker
    Friend WithEvents updateChecker As System.ComponentModel.BackgroundWorker
    Friend WithEvents loglabel As System.Windows.Forms.Label
    Friend WithEvents LinkLabel As System.Windows.Forms.LinkLabel
    Friend WithEvents ImageTimer As System.Windows.Forms.Timer
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents Timer_Notice As System.Windows.Forms.Timer
    Friend WithEvents DropButton As SixGrade.FlatButton
End Class
