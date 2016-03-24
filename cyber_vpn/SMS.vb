Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Net.NetworkInformation
Imports System.Management
Imports DSAPI.硬件信息

Public Class SMSForm
    Dim flag As Integer = 0 '标记用户第几次点击按钮
    Dim time As Integer = 180
    Dim identifycode As String = ""
    Dim info As Form1.sendidentifyinfo
    Dim closeflag As Integer = 0 '标记用户是否是验证成功关闭的窗口

    Private Sub Label1_Click(ByVal sender As system.Object, ByVal e As system.EventArgs) Handles PhoneNum_Label.Click

    End Sub

    Private Sub PhoneBox_KeyPress(ByVal sender As system.Object, ByVal e As system.Windows.Forms.KeyPressEventArgs) Handles PhoneBox.KeyPress
        If Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(8) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub GetIdentifyButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GetIdentifyButton.Click
        Dim recvinfo As Form1.recvidentifyinfo
        'Dim nics() As NetworkInterface = NetworkInterface.GetAllNetworkInterfaces()
        Dim tmp As String = ""
        Dim getidentifycode As New trade.TRADE()
        Dim ret As String = ""
        Dim errmsg As String = ""
        If flag = 0 Then
            Try
                If PhoneBox.Text.Length <> 11 Then
                    InfoText.ForeColor = Color.Black
                    InfoText.Text = "手机号码应为11位。"
                    Exit Sub
                End If

                tmp = Mid(PhoneBox.Text, 1, 3)
                If Form1.phonenumhead.IndexOf(tmp) < 0 Then
                    InfoText.ForeColor = Color.Black
                    InfoText.Text = "号码非法，请重新输入。"
                    Exit Sub
                End If

               
                'Dim netid As String = ""
                'Dim searcher As New ManagementObjectSearcher("select * from win32_NetworkAdapterConfiguration")
                'Dim moc2 As ManagementObjectCollection = searcher.Get()
                'For Each mo As ManagementObject In moc2
                '    If CBool(mo("IPEnabled")) Then
                '        info.mac = mo("MACAddress")
                '    End If
                'Next


                Dim CompSys As New ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapter WHERE (MACAddress IS NOT NULL) AND (NOT (PNPDeviceID LIKE 'ROOT%'))")
                'Dim Lst As New List(Of String)
                Dim macstring As ArrayList = New ArrayList
                For Each MyObject As ManagementObject In CompSys.[Get]()
                    Try
                        Dim S As String = MyObject("MACAddress").ToString()
                        If S IsNot Nothing Then
                            macstring.Add(S)
                        End If
                    Catch
        End Try
                Next

                info.mac = macstring.Item(0)
                ' info.mac = nics(0).GetPhysicalAddress.ToString()
                info.phonenum = PhoneBox.Text

                IdentifyBox.Text = ""

                If getidentifycode.GetIdentifyCode(info, recvinfo, errmsg) = False Then
                    InfoText.ForeColor = Color.Red
                    InfoText.Text = errmsg
                    Exit Sub
                Else
                    If recvinfo.result = 0 Then
                        identifycode = recvinfo.identifycode
                        flag = 1
                        Timer.Enabled = True
                        Timer.Interval = 1000
                        GetIdentifyButton.Enabled = False
                        ButtonOK.Enabled = True
                        InfoText.ForeColor = Color.Black
                        InfoText.Text = "发送成功!"

                    ElseIf recvinfo.result = -1 Then
                        InfoText.ForeColor = Color.Red
                        InfoText.Text = "发送验证码失败,请重新尝试"
                        Exit Sub
                    ElseIf recvinfo.result = -2 Then
                        MsgBox("该设备已进行过验证，无需重复验证,现为您跳转至主界面")
                        closeflag = 1

                        Me.Close()
                    Else

                    End If
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf flag = 1 Then

        End If
    End Sub

    Private Sub Timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer.Tick
        GetIdentifyButton.Text = time
        time -= 1
        If time < 0 Then
            Timer.Enabled = False
            GetIdentifyButton.Enabled = True
            time = 180
            GetIdentifyButton.Text = "获取验证码"
            InfoText.ForeColor = Color.Black
            InfoText.Text = "输入超时，请重新获取"
            ButtonOK.Enabled = False
            flag = 0
        End If
    End Sub

    Private Sub SMSForm_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If closeflag = 1 Then
            Try
                'add ycr 2015.12.30
                'Dim des As New ZU14.DES()
                'Dim xoption As New _Set
                'Dim xoptionRow As _Set.optionsRow
                'Dim version_num As String = ""
                'Dim isfirstrun As String = ""

                'des.PASS = "cernewtech"
                'des.PrivateKey = Form1.pvtkey

                'Try
                '    des.DecryptFile(Application.StartupPath + "\data\settings.tmp", Application.StartupPath + "\data\settings.dat")
                '    xoption.ReadXml(Application.StartupPath & "\data\settings.dat", System.Data.XmlReadMode.IgnoreSchema)
                '    If xoption.options.Rows.Count > 0 Then
                '        xoptionRow = xoption.options.Rows.Item(0)
                '        If Not xoptionRow.IsstartupNull Then
                '            Form2.StartBox.Checked = xoptionRow.startup
                '        End If
                '        If Not xoptionRow.IsnotifyNull Then
                '            Form2.UpdateBox.Checked = xoptionRow.notify
                '        End If
                '        If Not xoptionRow.Islanding_pageNull Then
                '            Form2.LPageBox.Checked = xoptionRow.landing_page
                '        End If
                '        If Not xoptionRow.IspageNull Then
                '            Form2.LPageTextBox.Text = xoptionRow.page
                '        End If
                '        If Not xoptionRow.IsusernameNull Then
                '            Form2.UsernameBox.Text = xoptionRow.username
                '        End If
                '        If Not xoptionRow.IspasswordNull Then
                '            Form2.PasswordBox.Text = xoptionRow.password
                '        End If
                '        If Not xoptionRow.IstcprportNull Then
                '            Form2.TCP_PortBox.Text = xoptionRow.tcprport
                '        End If
                '        If Not xoptionRow.IslportNull Then
                '            Form2.BindBox.Text = xoptionRow.lport
                '        End If
                '        If Not xoptionRow.IsudprportNull Then
                '            Form2.UDP_PortBox.Text = xoptionRow.udprport
                '        End If
                '        If Not xoptionRow.IspingNull Then
                '            Form2.PingBox.Checked = xoptionRow.ping
                '        End If
                '        If Not xoptionRow.IsversionNull Then
                '            version_num = xoptionRow.version
                '        End If
                '        If Not xoptionRow.IsversionNull Then
                '            isfirstrun = xoptionRow.isfirstrun
                '        End If
                '    End If
                '        Dim writer As New Xml.XmlTextWriter(Application.StartupPath & "\data\settings.dat", System.Text.Encoding.GetEncoding("GBK"))
                '        '使用自动缩进便于阅读
                '        writer.Formatting = Xml.Formatting.Indented
                '        writer.WriteRaw("<?xml version=""1.0"" standalone=""yes""?>")
                '        '书写根元素()
                '        writer.WriteStartElement("Set", "http://prothemes.biz/Set.xsd")
                '        '添加次级元素()
                '        writer.WriteStartElement("options")
                '        '添加子元素()
                '        writer.WriteElementString("username", xoptionRow.username)
                '        writer.WriteElementString("password", xoptionRow.password)
                '        writer.WriteElementString("landing_page", xoptionRow.landing_page)
                '        writer.WriteElementString("startup", xoptionRow.startup)
                '        writer.WriteElementString("lport", xoptionRow.lport)
                '        writer.WriteElementString("tcprport", xoptionRow.tcprport)
                '        writer.WriteElementString("notify", xoptionRow.notify)
                '        writer.WriteElementString("page", xoptionRow.page)
                '        writer.WriteElementString("udprport", xoptionRow.udprport)
                '        writer.WriteElementString("ping", xoptionRow.ping)
                '        writer.WriteElementString("version", xoptionRow.version)
                '        writer.WriteElementString("isfirstrun", "1")
                '        '关闭次级元素option
                '        writer.WriteEndElement()
                '        '关闭根元素
                '        writer.WriteFullEndElement()
                '        '将XML写入文件并关闭writer
                '        writer.Close()
                '        des.EncryptFile(Application.StartupPath + "\data\settings.dat", Application.StartupPath + "\data\settings.tmp")
                closeflag = 1
                Me.Dispose(True)
            Catch ex As Exception
                MsgBox("内部错误，验证失败!")
            End Try
            'add end
            Exit Sub
        End If
        If MsgBox("不进行验证无法使用程序，确定退出？", vbOKCancel, "提示") = vbOK Then
            End
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub SMSForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub GetIdentifyButton_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles GetIdentifyButton.Disposed

    End Sub

    Private Sub ButtonOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOK.Click
        Dim getidentifycode As New trade.TRADE()
        Dim ret As String = ""
        Dim errmsg As String = ""

        Dim TmpPath As String
        Dim Content As String

        If identifycode = IdentifyBox.Text Then
            TmpPath = System.IO.Path.GetTempPath()
            TmpPath += "\XConfig.ini"
            Content = "[VERIFY]" & vbNewLine & "FLAG=1001"

            FileOpen(1, TmpPath, 2, , 1, )
            PrintLine(1, Content)
            MsgBox("验证成功,祝您使用愉快!")
            closeflag = 1
            Me.Close()

            'If getidentifycode.IdentifySuccess(ret, info, errmsg) = False Then
            '    InfoText.ForeColor = Color.Red
            '    InfoText.Text = errmsg
            'Else
            '    'add ycr 2015.12.30
            '    Dim des As New ZU14.DES()
            '    Dim xoption As New _Set
            '    Dim xoptionRow As _Set.optionsRow
            '    Dim version_num As String = ""
            '    Dim isfirstrun As String = ""

            '    des.PASS = "cernewtech"
            '    des.PrivateKey = Form1.pvtkey

            '    Try
            '        des.DecryptFile(Application.StartupPath + "\data\settings.tmp", Application.StartupPath + "\data\settings.dat")
            '        xoption.ReadXml(Application.StartupPath & "\data\settings.dat", System.Data.XmlReadMode.IgnoreSchema)
            '        If xoption.options.Rows.Count > 0 Then
            '            xoptionRow = xoption.options.Rows.Item(0)
            '            If Not xoptionRow.IsstartupNull Then
            '                Form2.StartBox.Checked = xoptionRow.startup
            '            End If
            '            If Not xoptionRow.IsnotifyNull Then
            '                Form2.UpdateBox.Checked = xoptionRow.notify
            '            End If
            '            If Not xoptionRow.Islanding_pageNull Then
            '                Form2.LPageBox.Checked = xoptionRow.landing_page
            '            End If
            '            If Not xoptionRow.IspageNull Then
            '                Form2.LPageTextBox.Text = xoptionRow.page
            '            End If
            '            If Not xoptionRow.IsusernameNull Then
            '                Form2.UsernameBox.Text = xoptionRow.username
            '            End If
            '            If Not xoptionRow.IspasswordNull Then
            '                Form2.PasswordBox.Text = xoptionRow.password
            '            End If
            '            If Not xoptionRow.IstcprportNull Then
            '                Form2.TCP_PortBox.Text = xoptionRow.tcprport
            '            End If
            '            If Not xoptionRow.IslportNull Then
            '                Form2.BindBox.Text = xoptionRow.lport
            '            End If
            '            If Not xoptionRow.IsudprportNull Then
            '                Form2.UDP_PortBox.Text = xoptionRow.udprport
            '            End If
            '            If Not xoptionRow.IspingNull Then
            '                Form2.PingBox.Checked = xoptionRow.ping
            '            End If
            '            If Not xoptionRow.IsversionNull Then
            '                version_num = xoptionRow.version
            '            End If
            '            If Not xoptionRow.IsversionNull Then
            '                isfirstrun = xoptionRow.isfirstrun
            '            End If
            '        End If
            '        Try
            '            Dim writer As New Xml.XmlTextWriter(Application.StartupPath & "\data\settings.dat", System.Text.Encoding.GetEncoding("GBK"))
            '            '使用自动缩进便于阅读
            '            writer.Formatting = Xml.Formatting.Indented
            '            writer.WriteRaw("<?xml version=""1.0"" standalone=""yes""?>")
            '            '书写根元素()
            '            writer.WriteStartElement("Set", "http://prothemes.biz/Set.xsd")
            '            '添加次级元素()
            '            writer.WriteStartElement("options")
            '            '添加子元素()
            '            writer.WriteElementString("username", xoptionRow.username)
            '            writer.WriteElementString("password", xoptionRow.password)
            '            writer.WriteElementString("landing_page", xoptionRow.landing_page)
            '            writer.WriteElementString("startup", xoptionRow.startup)
            '            writer.WriteElementString("lport", xoptionRow.lport)
            '            writer.WriteElementString("tcprport", xoptionRow.tcprport)
            '            writer.WriteElementString("notify", xoptionRow.notify)
            '            writer.WriteElementString("page", xoptionRow.page)
            '            writer.WriteElementString("udprport", xoptionRow.udprport)
            '            writer.WriteElementString("ping", xoptionRow.ping)
            '            writer.WriteElementString("version", xoptionRow.version)
            '            writer.WriteElementString("isfirstrun", "1")
            '            '关闭次级元素option
            '            writer.WriteEndElement()
            '            '关闭根元素
            '            writer.WriteFullEndElement()
            '            '将XML写入文件并关闭writer
            '            writer.Close()
            '            des.EncryptFile(Application.StartupPath + "\data\settings.dat", Application.StartupPath + "\data\settings.tmp")
            '            MsgBox("验证成功,祝您使用愉快!")
            '            closeflag = 1
            '            Me.Dispose(True)
            '        Catch ex As Exception
            '            MsgBox("内部错误，验证失败!")
            '        End Try
            '        'add end
            '    Catch ex As Exception
            '        InfoText.Text = ex.Message
            '    End Try
            'End If
        Else
            flag = 0
            InfoText.ForeColor = Color.Red
            InfoText.Text = "验证码输入错误"
        End If
    End Sub
End Class