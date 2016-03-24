Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Xml
Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Text.RegularExpressions
Imports DSAPI.图形图像
' -----------------------------------------------XXXXXXXXXXXXXXXXX-----------------------------------------------
'
' Name Custom OpenVPN Client for Windows
' Author Balaji
' Copyright © 2014 ProThemes.Biz
'
' -----------------------------------------------XXXXXXXXXXXXXXXXX-----------------------------------------------
Public Class Form1

    ' Enter your VPN Service name
    Public Const AppName As String = "六年级"

    ' Enter your social media links
    Dim twitter_page As String = "https://twitter.com/"
    Dim facebook_page As String = "https://www.facebook.com/"
    Dim google_page As String = "https://plus.google.com/"

    'Enter your VPN account creation link
    Public Shared account_link As String = "http://www.6nianji.cn/register.php"
    Public Shared paymore_link As String = "https://shop135650059.taobao.com/shop/view_shop.htm?tracelog=twddp&user_number_id=120780328"
    'Remotely server list 

    ' 0 refers remotetly server list option is disbaled 
    ' 1 refers remotetly server list option is enabled 
    Dim remote_option As String = 0
    Public Shared version_num As String = 1.0
    'Enter your server path (Server side located files) (Note enter without http://)
    Public Shared domain As String = "6nianji.cn/Upload"

    'Don't modify until you may know what you are doing
    Dim sent As Long
    Dim received As Long
    Dim list1 As New ArrayList
    Dim list2 As New ArrayList
    Dim tcp_ca As New ArrayList
    Dim udp_ca As New ArrayList
    Dim rnd_port As New ArrayList
    Dim ca As String
    Dim servertcp As String
    Dim serverudp As String
    Dim statusread As String
    Dim statusr As String
    Dim statusw As String
    Dim tempData As String
    Dim ldata As String
    Dim IPServer As String
    Dim lport As String
    Dim proto As String
    Dim rport As String
    Dim selectserver As String
    Dim noticeone As String
    Dim noticetwo As String
    Dim noticethree As String
    Public Shared connected_yes As String
    Private configpathname As String = Application.StartupPath & "\data\settings.dat"
    Public Shared pvtkey As String = "99999999"
    'Public Shared serverip As String = "211.68.121.206"
    Public Shared serverip As String = "59.64.114.125"
    'Public Shared serverip As String = "120.27.116.59"
    Public Shared serverport As String = "1998"
    Dim imagenum As Integer = 0
    Public Shared phonenumhead As New ArrayList
    Dim runflag As String = "-1"
    Dim isfirstrun As String = ""
    Dim UsrID As StringBuilder
    Dim logserverflag As Integer = 0

    Public Structure userinfo
        Dim userid As String    '账号
        Dim accouttype As Integer   '账户类型 :0-7天 1-30天 2-1G 3-10G
        Dim loginstatus As Integer  '登录状态 0-未登录 1-已登录
        Dim userproperty As Integer '账户属性 0-冻结 1-正常 2-到期
        Dim activationflag As Integer   '激活状态 0-未激活 1:已激活
        Dim agentcode As String    '代理商识别码
        Dim isofficial As Integer  '账号所属标志 0-特色版本账户,1-官方版本账户
        Dim returnnum As Integer '返回结果  0-正常 -1:无此账户 -2:密码错误 -3:已登录
        Dim noticeone As String '公告信息
        Dim noticetwo As String
        Dim noticethree As String
    End Structure

    Public Structure loginfo
        Dim userid As String  '账户
        Dim userpwd As String   '密码
        Dim hostip As String    'IP地址
        Dim usercode As String  '代理识别码
    End Structure

    Public Structure flowinfo
        Dim userid As String    '账户
        Dim dayflow As String   '当日流量
        Dim month As String     '当月流量
        Dim usedflow As String  '已使用流量
        Dim total As String     '总流量
    End Structure

    Public Structure sendidentifyinfo
        Dim phonenum As String  '手机号
        Dim mac As String       'MAC地址
    End Structure

    Public Structure recvidentifyinfo
        Dim identifycode As String  '验证码
        Dim result As Integer       '返回结果
    End Structure

    Private Property PhoneFlag As Integer

    Private Declare Function GetPrivateProfileInt Lib "kernel32" Alias "GetPrivateProfileIntA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As Integer, ByVal lpFileName As String) As Int32
    Private Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As StringBuilder, ByVal nSize As Int32, ByVal lpFileName As String) As Int32

        ' OpenVPN Configuration File

    Public Function myConnection()

        If TCPButton.Checked = True Then
            IPServer = list1(ServersBox.SelectedIndex)  'TCP
            ca = tcp_ca(ServersBox.SelectedIndex)
        Else
            IPServer = list2(ServersBox.SelectedIndex)  'UDP
            ca = udp_ca(ServersBox.SelectedIndex)
        End If

        If remote_option = 1 Then

            If TCPButton.Checked = True Then
                proto = "tcp"
            Else
                proto = "udp"
            End If

            Try
                Dim client As New WebClient
                ldata = client.DownloadString("http://" & domain & "/get_data.php?server_code=" & Trim(ServersBox.SelectedIndex) & "&proto=" & proto)

            Catch ex As Exception

            End Try
            Dim getca As String = Trim(Split(Split(ldata, "<ca>")(1), "</ca>")(0))
            Dim path As String = Application.StartupPath & "\data\" & ca

            If File.Exists(path) Then
                File.Delete(path)
            End If
            Dim fs As FileStream = File.Create(path, 1024)
            Dim info As Byte() = New UTF8Encoding(True).GetBytes(getca)
            fs.Write(info, 0, info.Length)
            fs.Close()
        End If

        If TCPButton.Checked = True Then
            If Form2.TCP_PortBox.Text.Trim = "" Then
                rport = "443"
            Else
                rport = Form2.TCP_PortBox.Text.Trim
            End If
        Else
            If Form2.UDP_PortBox.Text.Trim = "" Then
                rport = "1194"
            Else
                rport = Form2.UDP_PortBox.Text.Trim
            End If
        End If

        If Form2.BindBox.Text.Trim = "" Then
            lport = "1194"
        Else
            lport = Form2.BindBox.Text.Trim
        End If
        'add ycr 2015.11.13 鉴于目前端口比较少,可以写死到程序中.以后如果有修改端口的需求时可以改为读取配置文件的形式'
        Randomize()
        Dim crtname As String
        Dim crt As String
        Dim tmp As String
        Dim pos As Integer
        Dim des As New ZU14.DES()
        des.PASS = "cernewtech"
        des.PrivateKey = pvtkey
        crt = ".crt"
        Dim rnd_num As Integer = CInt(Int((12 * Rnd()) + 1))
        rnd_port.Add(80)
        rnd_port.Add(8080)
        rnd_port.Add(443)
        rnd_port.Add(21)
        rnd_port.Add(110)
        rnd_port.Add(20)
        rnd_port.Add(25)
        rnd_port.Add(143)
        rnd_port.Add(990)
        rnd_port.Add(995)
        rnd_port.Add(23)
        rnd_port.Add(22)

        rport = rnd_port.Item(rnd_num - 1)
        tmp = ca
        pos = InStr(ca, ".")
        Mid(tmp, pos, 4) = Mid(crt, 1, 4)
        crtname = Application.StartupPath + "/data/" + tmp
        des.DecryptFile(Application.StartupPath + "/data/" + ca, Application.StartupPath + "/data/" + tmp)
        'des.DecryptFile(Application.StartupPath + "/data/acc.log", Application.StartupPath + "/data/acc.tmp")
        ca = tmp

        '内测使用，上线删除
        'Try
        '    FileOpen(1, Application.StartupPath & ("\data\acc.tmp"), OpenMode.Output)
        'Catch
        'End Try
        'Try
        '    PrintLine(1, "XJSTB20154708862")
        '    Print(1, "162464")
        'Catch

        'End Try
        'FileClose(1)
        'end

        '基于xBase64算法对IP地址加解密，有需要可以去掉注释直接使用
        'IPServer = System.Convert.ToBase64String(System.Text.UnicodeEncoding.Unicode.GetBytes(IPServer))
        'MsgBox("IPserver=" + IPServer, , "提示")
        'IPServer = System.Text.UnicodeEncoding.Unicode.GetString(System.Convert.FromBase64String(IPServer))
        'MsgBox("IPserver=" + IPServer, , "提示")
        'add end'

        'add ycr 20160223
        Dim TmpPath As String
        TmpPath = System.IO.Path.GetTempPath()
        TmpPath += "status.dat"
        'add end

        ' TCP Config File
        servertcp = "--client --dev tap --remote " & IPServer & " --proto tcp --port " & rport & " --lport " & lport & _
        " --keepalive 20 60 --auth-user-pass data\acc.tmp --reneg-sec 432000 --resolv-retry infinite --ca data\" & ca & " --comp-lzo --verb 3" & _
        " --log data\logfile.tmp --status TmpPath 1 "
        '        servertcp = "--client --dev tap --remote " & IPServer & " --proto tcp --port " & rport & " --lport " & lport & _
        '" --keepalive 20 60 --auth-user-pass data\acc.tmp --reneg-sec 432000 --resolv-retry infinite --ca data\" & ca & " --comp-lzo --verb 3" & _
        '" --log data\logfile.tmp --status data\status.dat 1 "


        ' UDP Config File

        serverudp = "--client --dev tap --remote " & IPServer & " --proto udp --port " & rport & " --lport " & lport & _
        "  --resolv-retry infinite --mssfix 1450 --tun-mtu 1500 --tun-mtu-extra 32 --persist-key --persist-tun --auth-user-pass data\acc.tmp --ca data\" & ca & " --comp-lzo --verb 3" & _
        " --log data\logfile.tmp --status " & TmpPath &" 1 "
        '        serverudp = "--client --dev tap --remote " & IPServer & " --proto udp --port " & rport & " --lport " & lport & _
        '"  --resolv-retry infinite --mssfix 1450 --tun-mtu 1500 --tun-mtu-extra 32 --persist-key --persist-tun --auth-user-pass data\acc.tmp --ca data\" & ca & " --comp-lzo --verb 3" & _
        '" --log data\logfile.tmp --status data\status.dat 1 "


        'Load Config File
        If TCPButton.Checked = True Then
            selectserver = servertcp
        Else
            selectserver = serverudp
        End If
    End Function

    Private Sub Form1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick

    End Sub

    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            Me.Hide()
            NotifyIcon1.Visible = True
            NotifyIcon1.ShowBalloonTip(3000, AppName, "程序已隐藏至托盘", ToolTipIcon.Info)
        End If
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = 150
        Me.Left = 500

        'Query.ShowDialog()
        '++++++++++++++++++++++
        Dim ss As String
        Dim req As HttpWebRequest = WebRequest.Create("http://120.27.116.59:8080/LiuN/andr/UserAndroidService/name/12312312312")
        Dim reqStream As Stream
        Dim reqStreamReader As StreamReader
        Dim response As HttpWebResponse
        Dim responseStream As Stream
        Dim ResponseHtml As String
        req.ContentType = "application/x-www-form-urlencoded"
        req.ContentLength = 0
        req.Method = "POST"
        'reqStream = req.GetRequestStream()

        Dim encode As Encoding = New UTF8Encoding()
        Dim b As Byte()

        'b = encode.GetBytes(String.Format("name=%s", 12312312312)) '传参函数
        'req.ContentLength = b.Length
        'req.GetRequestStream.Write(b, 0, b.Length)

        response = req.GetResponse()
        responseStream = response.GetResponseStream()
        reqStreamReader = New StreamReader(responseStream, Encoding.UTF8)

        ResponseHtml = reqStreamReader.ReadToEnd()
        responseStream.Close()
        reqStreamReader.Close()
        '++++++++++++++++++++++
        'add ycr 2015.11.20
        Dim des As New ZU14.DES()
        des.PASS = "cernewtech"
        des.PrivateKey = pvtkey
        'Trace.Listeners.Add(New TextWriterTraceListener(Application.StartupPath + "/data/log.log"))
        'Trace.AutoFlush = True
        'Trace.Indent()
        'add end

        'add ycr 2015.12.29
        phonenumhead.Add("130")
        phonenumhead.Add("131")
        phonenumhead.Add("132")
        phonenumhead.Add("133")
        phonenumhead.Add("134")
        phonenumhead.Add("135")
        phonenumhead.Add("136")
        phonenumhead.Add("137")
        phonenumhead.Add("138")
        phonenumhead.Add("139")
        phonenumhead.Add("145")
        phonenumhead.Add("147")
        phonenumhead.Add("150")
        phonenumhead.Add("151")
        phonenumhead.Add("152")
        phonenumhead.Add("153")
        phonenumhead.Add("154")
        phonenumhead.Add("155")
        phonenumhead.Add("156")
        phonenumhead.Add("157")
        phonenumhead.Add("158")
        phonenumhead.Add("159")
        phonenumhead.Add("156")
        phonenumhead.Add("170")
        phonenumhead.Add("177")
        phonenumhead.Add("178")
        phonenumhead.Add("180")
        phonenumhead.Add("181")
        phonenumhead.Add("182")
        phonenumhead.Add("183")
        phonenumhead.Add("184")
        phonenumhead.Add("185")
        phonenumhead.Add("186")
        phonenumhead.Add("187")
        phonenumhead.Add("188")
        phonenumhead.Add("189")
        'add end

        'add ycr 20160317
        Dim g As String
        g = "taskkill /f /im openvpn.exe"
        Shell("cmd /c" & g, vbHide)
        'add end

        If File.Exists(Application.StartupPath & "\bin\openvpn.exe") Then
            'Okay
        Else
            MsgBox("系统文件丢失!", , AppName + "-错误")
            End
        End If
        Try
            If New FileInfo(Application.StartupPath + "/data/settings.tmp").Exists Then
                Dim xoption As New _Set
                Dim xoptionRow As _Set.optionsRow
                'add ycr 2015.11.20
                des.DecryptFile(Application.StartupPath + "\data\settings.tmp", Application.StartupPath + "\data\settings.dat")
                If New FileInfo(Application.StartupPath + "\data\logfile.tmp").Exists Then
                Else
                    FileOpen(1, Application.StartupPath + "\data\logfile.tmp", OpenMode.Append, OpenAccess.Default, OpenShare.Default)
                    FileClose(1)
                End If
                'end
                xoption.ReadXml(configpathname, System.Data.XmlReadMode.IgnoreSchema)
                If xoption.options.Rows.Count > 0 Then
                    xoptionRow = xoption.options.Rows.Item(0)
                    If Not xoptionRow.IsstartupNull Then
                        Form2.StartBox.Checked = xoptionRow.startup
                    End If
                    If Not xoptionRow.IsnotifyNull Then
                        Form2.UpdateBox.Checked = xoptionRow.notify
                    End If
                    If Not xoptionRow.Islanding_pageNull Then
                        Form2.LPageBox.Checked = xoptionRow.landing_page
                    End If
                    If Not xoptionRow.IspageNull Then
                        Form2.LPageTextBox.Text = xoptionRow.page
                    End If
                    If Not xoptionRow.IsusernameNull Then
                        Form2.UsernameBox.Text = xoptionRow.username
                    End If
                    If Not xoptionRow.IspasswordNull Then
                        Form2.PasswordBox.Text = xoptionRow.password
                    End If
                    If Not xoptionRow.IstcprportNull Then
                        Form2.TCP_PortBox.Text = xoptionRow.tcprport
                    End If
                    If Not xoptionRow.IslportNull Then
                        Form2.BindBox.Text = xoptionRow.lport
                    End If
                    If Not xoptionRow.IsudprportNull Then
                        Form2.UDP_PortBox.Text = xoptionRow.udprport
                    End If
                    If Not xoptionRow.IspingNull Then
                        Form2.PingBox.Checked = xoptionRow.ping
                    End If
                    If Not xoptionRow.IsversionNull Then
                        version_num = xoptionRow.version
                    End If
                    If Not xoptionRow.IsisfirstrunNull Then
                        isfirstrun = xoptionRow.isfirstrun
                    End If
                End If
                'add ycr 2015.11.20
                des.EncryptFile(Application.StartupPath + "\data\settings.dat", Application.StartupPath + "\data\settings.tmp")
                FileIO.FileSystem.DeleteFile(Application.StartupPath + "\data\settings.dat")
                Form2.Label6.Text = "v" + version_num
                'end
            End If


            Try
                ServersBox.Items.Clear()
                ServersBox.Text = ""
                list2.Clear()
                udp_ca.Clear()
                'add ycr 2015.11.15
                des.DecryptFile(Application.StartupPath + "\data\udp.tmp", Application.StartupPath + "\data\udp.xml")
                'add end
                Dim udp As XmlReader = XmlReader.Create(Application.StartupPath + "/data/udp.xml")
                Do While udp.Read()
                    If udp.NodeType = XmlNodeType.Element AndAlso udp.Name = "name" Then
                        ServersBox.Items.Add(udp.ReadElementString & " ")
                    ElseIf udp.NodeType = XmlNodeType.Element AndAlso udp.Name = "ip" Then
                        list2.Add(udp.ReadElementString)
                    ElseIf udp.NodeType = XmlNodeType.Element AndAlso udp.Name = "ca" Then
                        udp_ca.Add(udp.ReadElementString)
                    Else
                        udp.Read()
                    End If
                Loop
                udp.Close()
                FileIO.FileSystem.DeleteFile(Application.StartupPath + "\data\udp.xml")
                ServersBox.SelectedIndex = 0

                Timer2.Enabled = True
            Catch ex As Exception
                MsgBox("无法载入配置信息!", , AppName)
                End
            End Try

        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try
        Try
            'add ycr 2015.11.15
            ' des.DecryptFile(Application.StartupPath + "\data\udp.tmp", Application.StartupPath + "\data\udp.xml")
            'des.DecryptFile(Application.StartupPath + "\data\acc.log", Application.StartupPath + "\data\acc.tmp")
            'add end
            'Dim test As System.Reflection.Assembly = System.Reflection.Assembly.LoadFile("DSAPI.dll")
            FileOpen(1, Application.StartupPath & ("\data\acc.tmp"), OpenMode.Output)
        Catch
        End Try

        Try
            PrintLine(1, Form2.UsernameBox.Text)
            Print(1, Form2.PasswordBox.Text)
        Catch

        End Try
        FileClose(1)
        ' des.EncryptFile(Application.StartupPath + "\data\acc.tmp", Application.StartupPath + "\data\acc.log")
        ' FileIO.FileSystem.DeleteFile(Application.StartupPath + "\data\acc.tmp")

        If remote_option = 1 Then
            Dim path1 As String = Application.StartupPath & "\data\tcp.xml"
            Dim path2 As String = Application.StartupPath & "\data\udp.xml"
            If File.Exists(path1) Then
                File.Delete(path1)
            End If
            If File.Exists(path2) Then
                File.Delete(path2)
            End If
            Try
                getMyData.RunWorkerAsync()
            Catch ex As Exception

            End Try
        Else
            If Form2.UpdateBox.Checked = True Then
                Try
                    updateChecker.RunWorkerAsync()
                Catch ex As Exception
                    End
                End Try
            End If
        End If
    End Sub
    Private Sub FlatButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConnectButton.Click

        '    If TCPButton.Checked = True Or UDPButton.Checked = True Then   'mod ycr 2015.11.11'

        If ConnectButton.Text = "连  接" Then

            If ServersBox.Text = "" Then
                MsgBox("请先选择您要连接的服务器!", , AppName)
            Else

                Try
                    Dim tmpstring As String
                    Dim des As New ZU14.DES()
                    des.PASS = "cernewtech"
                    des.PrivateKey = pvtkey
                    Dim Filenum As Integer = FreeFile()
                    FileOpen(Filenum, Application.StartupPath & "\data\logfile.tmp", OpenMode.Output)
                    FileClose(Filenum)

                    UsrID = New StringBuilder(20)
                    'add ycr 20160223 读取客户端邀请码
                    If File.Exists(Application.StartupPath + "\data\usr.tmp") Then
                        des.DecryptFile(Application.StartupPath + "\data\usr.tmp", Application.StartupPath + "\data\usr.ini")
                        GetPrivateProfileString("BUSINESS", "ID", "1000001", UsrID, UsrID.Capacity, Application.StartupPath & "\data\usr.ini")
                        System.IO.File.Delete(Application.StartupPath & "\data\usr.ini")
                    Else
                        MsgBox("系统文件丢失，请重新安装客户端!")
                    End If
                    'add end
                Catch ex As Exception

                End Try
                InfoBar.Text = "正在连接..."
                InfoBar.ForeColor = Color.FromArgb(243, 156, 18)
                InfoBar.Refresh()
                ConnectButton.Text = "连接中"
                ConnectButton.Enabled = False
                ConnectButton.Update()
                ConnectButton.Refresh()
                ' connected_yes = 0
                NotifyIcon1.ShowBalloonTip(3000, AppName, "正在连接中...", ToolTipIcon.Info)
                myConnection()
                Shell(Application.StartupPath & "\bin\openvpn " & selectserver, AppWinStyle.Hide)
                TimerLog.Start()
                Timer1.Start()
            End If
        ElseIf ConnectButton.Text = "停止" Then
            If MsgBox("想要停止" + AppName + "与服务器的连接吗?", MsgBoxStyle.YesNo, AppName) = vbYes Then
                Dim g As String
                g = "taskkill /f /im openvpn.exe"
                Shell("cmd /c" & g, vbHide)
                If Form2.PingBox.Checked = True Then
                    Dim gg As String
                    gg = "taskkill /f /im ping.exe"
                    Shell("cmd /c" & gg, vbHide)
                End If
                TimerLog.Stop()
                Try
                    Dim Filenum As Integer = FreeFile()
                    FileOpen(Filenum, Application.StartupPath & "\data\logfile.tmp", OpenMode.Output)
                    FileClose(Filenum)
                Catch ex As Exception

                End Try
                'add ycr 20160318
                Dim dropline As New trade.TRADE
                Dim result As String
                Dim errinfo As String
                If dropline.DropLine(result, Form2.UsernameBox.Text, errinfo) = True Then
                    InfoBar.Text = "账号退出成功"
                Else
                    MsgBox("账号退出失败，下次启动请先点击强制下线以便可以正常登陆")
                End If
                'add end

                Timer1.Stop()
                Timer1.Enabled = False
                connected_yes = 0
                InfoBar.ForeColor = Color.FromArgb(253, 106, 72)
                InfoBar.Text = "未连接"
                InfoBar.Update()
                InfoBar.Refresh()
                ConnectButton.Text = "连  接"
                ConnectButton.Refresh()
                Logs.SelectedText = Logs.SelectedText & "网络服务已停止" & vbCrLf
                NotifyIcon1.ShowBalloonTip(3000, AppName, "网络服务已停止", ToolTipIcon.Info)
            End If
        ElseIf ConnectButton.Text = "未连接" Then

            Dim g As String
            g = "taskkill /f /im openvpn.exe"
            Shell("cmd /c" & g, vbHide)
            If Form2.PingBox.Checked = True Then
                Dim gg As String
                gg = "taskkill /f /im ping.exe"
                Shell("cmd /c" & gg, vbHide)
            End If
            connected_yes = 0
            InfoBar.ForeColor = Color.FromArgb(253, 106, 72)
            InfoBar.Update()
            InfoBar.Refresh()
            InfoBar.Text = "未连接"
            ConnectButton.Text = "连  接"
            ConnectButton.Refresh()

            NotifyIcon1.ShowBalloonTip(3000, AppName, "未连接", ToolTipIcon.Info)
            Timer1.Stop()
            Timer1.Enabled = False
            TimerLog.Stop()
            Try
                Dim Filenum As Integer = FreeFile()
                FileOpen(Filenum, Application.StartupPath & "\data\logfile.tmp", OpenMode.Output)
                FileClose(Filenum)
            Catch ex As Exception

            End Try

        End If
        '  Else '
        ' MsgBox("Please select your Protocol!", , AppName)'
        ' End If'
    End Sub

    Private Sub FlatButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SettingsButton.Click
        Form2.ShowDialog()
    End Sub

    Private Sub FlatButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutButton.Click
        Form3.ShowDialog()
    End Sub
    Public Function BytesToMegabytes(ByVal Bytes As Double) As Double
        'This function gives an estimate to two decimal
        'places.  For a more precise answer, format to
        'more decimal places or just return dblAns

        Dim dblAns As Double
        dblAns = (Bytes / 1024) / 1024
        BytesToMegabytes = Format(dblAns, "###,###,##0.00")

    End Function
    Public Function BytesToMegabyte(ByVal Bytes As Double) As Double
        'This function gives an estimate to two decimal
        'places.  For a more precise answer, format to
        'more decimal places or just return dblAns

        Dim dblAns As Double
        dblAns = (Bytes / 1024) / 1024
        BytesToMegabyte = Format(dblAns, "###,###,##0.00")

    End Function

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            ' Dim logFileStream As New FileStream(Application.StartupPath & "\data\status.dat", FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
            Dim logFileStream As New FileStream(System.IO.Path.GetTempPath() & "\status.dat", FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
            Dim logFileReader As New StreamReader(logFileStream)

            ' Your code here
            statusread = logFileReader.ReadToEnd
            ' Clean up
            logFileReader.Close()
            logFileStream.Close()
        Catch ex As Exception

        End Try
        Try
            statusr = Split(Split(statusread, "TCP/UDP read bytes,")(1), "TCP/UDP write bytes,")(0)
            statusw = Split(Split(statusread, "TCP/UDP write bytes,")(1), "Auth read bytes,")(0)
        Catch ex As Exception

        End Try
        'It is for Sent Bytes
        Try
            SentBox.Text = BytesToMegabyte(statusw.Trim) & " Mb"
        Catch ex As Exception

        End Try

        'It is for Rec Bytes
        Try
            RecBox.Text = BytesToMegabytes(statusr.Trim) & " Mb"
        Catch ex As Exception

        End Try
    End Sub
    'add ycr 2015.12.8
    'add end
    Private Sub FlatRadioButton1_CheckedChanged(ByVal sender As System.Object) Handles TCPButton.CheckedChanged
        Try
            ServersBox.Items.Clear()
            ServersBox.Text = ""
            list1.Clear()
            tcp_ca.Clear()
            Dim tcp As XmlReader = XmlReader.Create(Application.StartupPath + "/data/tcp.xml")
            Do While tcp.Read()
                If tcp.NodeType = XmlNodeType.Element AndAlso tcp.Name = "name" Then
                    ServersBox.Items.Add(tcp.ReadElementString & " ")
                ElseIf tcp.NodeType = XmlNodeType.Element AndAlso tcp.Name = "ip" Then
                    list1.Add(tcp.ReadElementString)
                ElseIf tcp.NodeType = XmlNodeType.Element AndAlso tcp.Name = "ca" Then
                    tcp_ca.Add(tcp.ReadElementString)
                Else
                    tcp.Read()
                End If
            Loop
            tcp.Close()
        Catch ex As Exception
            MsgBox("读取服务器列表错误,请查看安装目录下系统文件是否完整!", , AppName)
            ConnectButton.Enabled = True

        End Try
    End Sub
    Private Sub FlatRadioButton2_CheckedChanged(ByVal sender As System.Object) Handles UDPButton.CheckedChanged
        'Try
        '    ServersBox.Items.Clear()
        '    ServersBox.Text = ""
        '    list2.Clear()
        '    udp_ca.Clear()
        '    Dim udp As XmlReader = XmlReader.Create(Application.StartupPath + "/data/udp.xml")
        '    Do While udp.Read()
        '        If udp.NodeType = XmlNodeType.Element AndAlso udp.Name = "name" Then
        '            ServersBox.Items.Add(udp.ReadElementString & " ")
        '        ElseIf udp.NodeType = XmlNodeType.Element AndAlso udp.Name = "ip" Then
        '            list2.Add(udp.ReadElementString)
        '        ElseIf udp.NodeType = XmlNodeType.Element AndAlso udp.Name = "ca" Then
        '            udp_ca.Add(udp.ReadElementString)
        '        Else
        '            udp.Read()
        '        End If
        '    Loop
        '    udp.Close()
        'Catch ex As Exception
        '    MsgBox("读取UDP服务器列表错误,请查看安装目录下系统文件是否完整!", , AppName)
        'End Try
    End Sub

    Private Sub ChromeButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogButton.Click
        If LogButton.Text = ">" Then
            Me.Size = New Size(645, 381)
            LogButton.Text = "<"
        ElseIf LogButton.Text = "<" Then
            Me.Size = New Size(336, 381)
            LogButton.Text = ">"
        End If
    End Sub

    Private Sub PictureBox3_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles FacebookBox.MouseEnter
        FacebookBox.Height = 26
        FacebookBox.Width = 26
        ToolTip1.SetToolTip(FacebookBox, "点击访问FaceBook主页")
    End Sub

    Private Sub PictureBox3_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles FacebookBox.MouseHover
        FacebookBox.Height = 26
        FacebookBox.Width = 26
        ToolTip1.SetToolTip(FacebookBox, "点击访问FaceBook主页")
    End Sub

    Private Sub PictureBox3_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles FacebookBox.MouseLeave
        FacebookBox.Height = 24
        FacebookBox.Width = 24
    End Sub

    Private Sub PictureBox4_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TwitterBox.MouseEnter
        TwitterBox.Height = 26
        TwitterBox.Width = 26
        ToolTip1.SetToolTip(TwitterBox, "点击访问Twitter主页")
    End Sub

    Private Sub PictureBox4_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles TwitterBox.MouseHover
        TwitterBox.Height = 26
        TwitterBox.Width = 26
        ToolTip1.SetToolTip(TwitterBox, "点击访问Twitter主页")
    End Sub
    Private Sub PictureBox4_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TwitterBox.MouseLeave
        TwitterBox.Height = 24
        TwitterBox.Width = 24
    End Sub

    Private Sub PictureBox5_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles GplusBox.MouseEnter
        GplusBox.Height = 26
        GplusBox.Width = 26
        ToolTip1.SetToolTip(GplusBox, "点击访问GPlus主页")
    End Sub

    Private Sub PictureBox5_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles GplusBox.MouseHover
        GplusBox.Height = 26
        GplusBox.Width = 26
        ToolTip1.SetToolTip(GplusBox, "点击访问GPlus主页")
    End Sub
    Private Sub PictureBox5_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles GplusBox.MouseLeave
        GplusBox.Height = 24
        GplusBox.Width = 24
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FacebookBox.Click
        Process.Start(facebook_page)
    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TwitterBox.Click
        Process.Start(twitter_page)
    End Sub

    Private Sub PictureBox5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GplusBox.Click
        Process.Start(google_page)
    End Sub
    Private Sub NotifyIcon1_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles NotifyIcon1.DoubleClick
        Try
            If Me.WindowState = FormWindowState.Minimized Then
                Me.Show()
                Me.WindowState = FormWindowState.Normal
            End If
            Me.Activate()
            Me.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub HideToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideToolStripMenuItem.Click
        Me.Hide()
    End Sub

    Private Sub ShowToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowToolStripMenuItem.Click
        Try
            If Me.WindowState = FormWindowState.Minimized Then
                Me.Show()
                Me.WindowState = FormWindowState.Normal
            End If
            Me.Activate()
            Me.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        If connected_yes = 0 Then
            If File.Exists(Application.StartupPath & "\data\*.crt") Then
                Kill(Application.StartupPath & "\data\*.crt")
            End If
            End
        Else
            Try
                If MsgBox("想要停止" + AppName + "与服务器的连接吗?", MsgBoxStyle.YesNo, AppName) = vbYes Then
                    Dim g As String
                    g = "taskkill /f /im openvpn.exe"
                    Shell("cmd /c" & g, vbHide)
                    TimerLog.Stop()
                    If Form2.PingBox.Checked = True Then
                        Dim gg As String
                        gg = "taskkill /f /im ping.exe"
                        Shell("cmd /c" & gg, vbHide)
                    End If
                    Try
                        Dim Filenum As Integer = FreeFile()
                        FileOpen(Filenum, Application.StartupPath & "\data\logfile.tmp", OpenMode.Output)
                        FileClose(Filenum)
                        Kill(Application.StartupPath & "\data\*.crt")

                    Catch ex As Exception

                    End Try
                    Timer1.Stop()
                    Timer1.Enabled = False
                    connected_yes = 0
                    InfoBar.ForeColor = Color.FromArgb(253, 106, 72)
                    InfoBar.Text = "未连接"
                    InfoBar.Update()
                    InfoBar.Refresh()
                    ConnectButton.Text = "连  接"
                    ConnectButton.Refresh()
                    NotifyIcon1.ShowBalloonTip(3000, AppName, "未连接", ToolTipIcon.Info)
                    End
                End If
            Catch ex As Exception

            End Try
        End If

    End Sub

    Private Sub TimerLog_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerLog.Tick
        Try
            Logs.Text = ""
            Dim textline(10000) As String
            Dim TestfileX As String = Application.StartupPath & "\data\logfile.tmp"
            Dim log_ctr As Integer
            Dim tapg As String = 0
            Dim last_log As Integer
            FileOpen(1, TestfileX, OpenMode.Input, OpenAccess.Read, OpenShare.LockRead)
            Do Until EOF(1)
                textline(log_ctr) = LineInput(1)
                log_ctr = log_ctr + 1
                If last_log <> log_ctr Then
                    For n = last_log To log_ctr - 1
                        If tapg = 1 Then
                            textline(n) = "TAP 错误"
                        End If
                        If textline(n).Contains("There are no TAP-Win32 adapters on this system.") Then
                            Logs.SelectedText = Logs.SelectedText & "系统中未安装TAP-Win32网卡适配器!" & vbCrLf
                            Dim g As String
                            g = "taskkill /f /im openvpn.exe"
                            Shell("cmd /c" & g, vbHide)
                            connected_yes = 0
                            NotifyIcon1.ShowBalloonTip(3000, AppName, "没有发现TAP-Win32网卡适配器!", ToolTipIcon.Info)
                            InfoBar.ForeColor = Color.FromArgb(253, 106, 72)
                            InfoBar.Text = "没有发现TAP-Win32网卡适配器!"
                            If Form2.PingBox.Checked = True Then
                                Dim gg As String
                                gg = "taskkill /f /im ping.exe"
                                Shell("cmd /c" & gg, vbHide)
                            End If
                            InfoBar.Update()
                            InfoBar.Refresh()
                            ConnectButton.Text = "连  接"
                            ConnectButton.Update()
                            ConnectButton.Refresh()
                            ConnectButton.Enabled = True
                            TimerLog.Stop()
                            Timer1.Stop()
                            TimerLog.Enabled = False
                            tapg = 1
                            Dim tap_error As New tap_error
                            tap_error.ShowDialog()

                        ElseIf textline(n).Contains("SYSTEM ROUTING TABLE") Then
                            Logs.SelectedText = Logs.SelectedText & "系统中未安装TAP-Win32网卡适配器!" & vbCrLf
                            Dim g As String
                            g = "taskkill /f /im openvpn.exe"
                            Shell("cmd /c" & g, vbHide)
                            If Form2.PingBox.Checked = True Then
                                Dim gg As String
                                gg = "taskkill /f /im ping.exe"
                                Shell("cmd /c" & gg, vbHide)
                            End If
                            connected_yes = 0
                            NotifyIcon1.ShowBalloonTip(3000, AppName, "检测到TAP驱动无法正常工作!", ToolTipIcon.Info)
                            InfoBar.ForeColor = Color.FromArgb(253, 106, 72)
                            InfoBar.Text = "TAP驱动错误!"
                            InfoBar.Update()
                            InfoBar.Refresh()
                            ConnectButton.Text = "连  接"
                            ConnectButton.Update()
                            ConnectButton.Refresh()
                            ConnectButton.Enabled = True
                            TimerLog.Stop()
                            Timer1.Stop()
                            TimerLog.Enabled = False
                            tapg = 1
                            Dim tap_error As New tap_error
                            tap_error.ShowDialog()
                        End If

                        'add ycr 2015.12.21
                        'ImageTimer.Enabled = True
                        'ImageTimer.Interval = 5000
                        'add end

                                If InStrRev(textline(n), "OpenVPN 2.3.6 i686-w64-mingw32") > 0 Then
                                    Logs.SelectedText = Logs.SelectedText & "正在连接到网络...." & vbCrLf
                                ElseIf InStrRev(textline(n), "LZO compression initialized") > 0 Then
                                    Logs.SelectedText = Logs.SelectedText & "LZO压缩包初始化完成" & vbCrLf
                                ElseIf InStrRev(textline(n), "Attempting") > 0 Then
                                    Logs.SelectedText = Logs.SelectedText & "正在越过防火墙并连接到web服务器...." & vbCrLf
                                ElseIf InStrRev(textline(n), "VERIFY OK:") > 0 Then
                                    Logs.SelectedText = Logs.SelectedText & "验证认证文件...." & vbCrLf
                                ElseIf InStrRev(textline(n), "Peer Connection Initiated with 0.0.0.0:0") > 0 Then
                                    Logs.SelectedText = Logs.SelectedText & "初始化服务中...." & vbCrLf
                                ElseIf InStrRev(textline(n), "TAP-WIN32 device") > 0 Then
                                    Logs.SelectedText = Logs.SelectedText & "正在与适配器端口绑定...." & vbCrLf
                                ElseIf InStrRev(textline(n), "NETSH: C:\WINDOWS\system32\netsh.exe interface ip set address {") > 0 Then
                                    Logs.SelectedText = Logs.SelectedText & "警告!! 虚拟网卡已被分配了IP地址!!" & vbCrLf
                                ElseIf InStrRev(textline(n), "Successful ARP Flush on interface") > 0 Then
                                    Logs.SelectedText = Logs.SelectedText & "请等待........" & vbCrLf
                                ElseIf InStrRev(textline(n), "Initialization Sequence Completed") > 0 Then
                                    Logs.SelectedText = "初始化虚拟网卡完成!" & vbCrLf
                                    If connected_yes = 0 Then

                                        '  Connected! 
                                        Timer1.Start()
                                NotifyIcon1.ShowBalloonTip(3000, AppName, "连接IPv6服务成功!", ToolTipIcon.Info)
                                        connected_yes = 1
                                Logs.SelectedText = Logs.SelectedText & "连接IPv6服务成功!" & vbCrLf
                                TimerLog.Stop()
                                'add ycr 20160306
                                Try
                                    Logs.SelectedText = Logs.SelectedText & "开始连接六Box服务器" & vbCrLf
                                    Dim login As New trade.TRADE()
                                    Dim loginfo As loginfo
                                    Dim userinfo As userinfo
                                    Dim ipaddress As IPHostEntry
                                    Dim hostname As String = ""
                                    Dim g As String
                                    hostname = System.Net.Dns.GetHostName()
                                    ipaddress = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName())
                                    For i As Integer = 0 To ipaddress.AddressList.Length
                                        If ipaddress.AddressList(i).AddressFamily.ToString = "InterNetwork" Then
                                            loginfo.hostip = ipaddress.AddressList(i).ToString
                                            Exit For
                                        End If
                                    Next
                                    loginfo.userid = Form2.UsernameBox.Text
                                    loginfo.userpwd = Form2.PasswordBox.Text
                                    loginfo.usercode = UsrID.ToString
                                    Logs.SelectedText = Logs.SelectedText & "正在登录6Box,请稍候" & vbCrLf
                                    Dim a As Boolean
                                    a = login.Login(loginfo, userinfo)
                                    If a = False Then
                                        TimerLog.Stop()
                                        g = "taskkill /f /im openvpn.exe"
                                        Shell("cmd /c" & g, vbHide)
                                        If File.Exists(Application.StartupPath & "\data\*.crt") Then
                                            Kill(Application.StartupPath & "\data\*.crt")
                                        End If
                                        Logs.SelectedText = Logs.SelectedText & "登录6Box服务器失败!" & vbCrLf
                                        TimerLog.Stop()
                                        InfoBar.Text = "未连接"
                                        InfoBar.ForeColor = Color.FromArgb(253, 106, 72)
                                        ConnectButton.Text = "连  接"
                                        ConnectButton.Enabled = True
                                        Exit Sub
                                    Else
                                        Select Case userinfo.returnnum
                                            Case -1
                                                Logs.SelectedText = Logs.SelectedText & "无此账号" & vbCrLf
                                                TimerLog.Stop()
                                                InfoBar.Text = "未连接"
                                                InfoBar.ForeColor = Color.FromArgb(253, 106, 72)
                                                ConnectButton.Text = "连  接"
                                                ConnectButton.Enabled = True
                                                g = "taskkill /f /im openvpn.exe"
                                                Shell("cmd /c" & g, vbHide)
                                                If File.Exists(Application.StartupPath & "\data\*.crt") Then
                                                    Kill(Application.StartupPath & "\data\*.crt")
                                                End If
                                                Exit Sub
                                            Case -2
                                                Logs.SelectedText = Logs.SelectedText & "密码错误" & vbCrLf
                                                TimerLog.Stop()
                                                InfoBar.Text = "未连接"
                                                InfoBar.ForeColor = Color.FromArgb(253, 106, 72)
                                                ConnectButton.Text = "连  接"
                                                ConnectButton.Enabled = True
                                                g = "taskkill /f /im openvpn.exe"
                                                Shell("cmd /c" & g, vbHide)
                                                If File.Exists(Application.StartupPath & "\data\*.crt") Then
                                                    Kill(Application.StartupPath & "\data\*.crt")
                                                End If
                                                Exit Sub
                                            Case 0
                                                ' Logs.SelectedText = Logs.SelectedText & "成功登录6BOX服务器" & vbCrLf
                                                ' Logs.SelectedText = Logs.SelectedText & "开始连接IPv6环境" & vbCrLf
                                        End Select

                                        If userinfo.isofficial = 0 Then
                                            If UsrID.ToString = "HERONGQING" Then
                                                Logs.SelectedText = Logs.SelectedText & "该客户端不支持此账户,请使用特色版客户端登录" & vbCrLf
                                                InfoBar.Text = "未连接"
                                                InfoBar.ForeColor = Color.FromArgb(253, 106, 72)
                                                ConnectButton.Text = "连  接"
                                                ConnectButton.Enabled = True
                                                g = "taskkill /f /im openvpn.exe"
                                                Shell("cmd /c" & g, vbHide)
                                                If File.Exists(Application.StartupPath & "\data\*.crt") Then
                                                    Kill(Application.StartupPath & "\data\*.crt")
                                                End If
                                                Exit Sub
                                            End If
                                        End If

                                        If userinfo.loginstatus = 1 Then
                                            Logs.SelectedText = Logs.SelectedText & "此账号已登录" & vbCrLf
                                            TimerLog.Stop()
                                            InfoBar.Text = "未连接"
                                            InfoBar.ForeColor = Color.FromArgb(253, 106, 72)
                                            ConnectButton.Text = "连  接"
                                            ConnectButton.Enabled = True
                                            g = "taskkill /f /im openvpn.exe"
                                            Shell("cmd /c" & g, vbHide)
                                            If File.Exists(Application.StartupPath & "\data\*.crt") Then
                                                Kill(Application.StartupPath & "\data\*.crt")
                                            End If
                                            Exit Sub
                                        End If
                                        If userinfo.userproperty = 0 Then
                                            Logs.SelectedText = Logs.SelectedText & "该账户已被冻结，不允许登录,请联系客服" & vbCrLf
                                            TimerLog.Stop()
                                            InfoBar.Text = "未连接"
                                            InfoBar.ForeColor = Color.FromArgb(253, 106, 72)
                                            ConnectButton.Text = "连  接"
                                            ConnectButton.Enabled = True
                                            g = "taskkill /f /im openvpn.exe"
                                            Shell("cmd /c" & g, vbHide)
                                            If File.Exists(Application.StartupPath & "\data\*.crt") Then
                                                Kill(Application.StartupPath & "\data\*.crt")
                                            End If
                                            Exit Sub
                                        ElseIf userinfo.userproperty = 2 Then
                                            Logs.SelectedText = Logs.SelectedText & "该账户已到期，不允许登录" & vbCrLf
                                            TimerLog.Stop()
                                            InfoBar.Text = "未连接"
                                            InfoBar.ForeColor = Color.FromArgb(253, 106, 72)
                                            ConnectButton.Text = "连  接"
                                            ConnectButton.Enabled = True
                                            g = "taskkill /f /im openvpn.exe"
                                            Shell("cmd /c" & g, vbHide)
                                            If File.Exists(Application.StartupPath & "\data\*.crt") Then
                                                Kill(Application.StartupPath & "\data\*.crt")
                                            End If
                                            Exit Sub
                                        End If
                                        If userinfo.activationflag = 0 Then
                                            'add ycr 20160307
                                            Dim ss As String
                                            Dim reg As New Regex("XJS[1-9][0-9][TG][YJBNS][0-9]{8}")

                                            ss = Form2.UsernameBox.Text
                                            Dim m As Match = reg.Match(ss)
                                            If m.Success Then
                                                Dim req As HttpWebRequest = WebRequest.Create("http://tui.6box.cn/admin/AdminApis/thirdConnecting")
                                                Dim reqStream As Stream
                                                Dim reqStreamReader As StreamReader
                                                Dim response As HttpWebResponse
                                                Dim responseStream As Stream
                                                Dim ResponseHtml As String
                                                req.ContentType = "application/x-www-form-urlencoded"
                                                req.ContentLength = 0
                                                req.Method = "POST"
                                                'reqStream = req.GetRequestStream()

                                                Dim encode As Encoding = New UTF8Encoding()
                                                Dim b As Byte()

                                                b = encode.GetBytes(String.Format("invitorcode=%s&trafficaccount=%s&trafficaccountpwd=%s&type=1", UsrID.ToString, ss, Form2.PasswordBox.Text)) '传参函数
                                                req.ContentLength = b.Length
                                                req.GetRequestStream.Write(b, 0, b.Length)

                                                response = req.GetResponse()
                                                responseStream = response.GetResponseStream()
                                                reqStreamReader = New StreamReader(responseStream, Encoding.UTF8)

                                                ResponseHtml = reqStreamReader.ReadToEnd()
                                                responseStream.Close()
                                                reqStreamReader.Close()
                                                'add end
                                            End If

                                            '邀请码处理段
                                        End If
                                        If userinfo.activationflag <> 0 Then
                                            '无操作
                                        Else
                                            '向平台发送账号信息
                                        End If

                                        noticeone = userinfo.noticeone
                                        noticetwo = userinfo.noticetwo
                                        noticethree = userinfo.noticethree

                                        Logs.SelectedText = Logs.SelectedText & "登录成功!" & vbCrLf
                                        End If
                                Catch ex As Exception
                                    MsgBox(ex.Message)
                                End Try
                                'add end
                                'add ycr 20160306
                                Timer_Notice.Start()
                                'add end
                                        If Form2.LPageBox.Checked = True Then
                                            Process.Start(Form2.LPageTextBox.Text.Trim)
                                        End If
                                        If Form2.PingBox.Checked = True Then
                                            Shell("cmd /c ping google.com -t", AppWinStyle.Hide)
                                        End If
                                        InfoBar.ForeColor = Color.FromArgb(39, 174, 96)
                                        InfoBar.Text = "已连接"
                                        InfoBar.Update()
                                        InfoBar.Refresh()
                                        ConnectButton.Text = "停止"
                                        ConnectButton.Update()
                                        ConnectButton.Refresh()
                                        ConnectButton.Enabled = True
                                    End If

                                ElseIf InStrRev(textline(n), "AUTH: Received control message: AUTH_FAILED") > 0 Then
                                    Logs.SelectedText = "认证失败!" & vbCrLf
                                    Logs.SelectedText = "请检查账号信息是否正确!" & vbCrLf

                                    Dim g As String
                                    g = "taskkill /f /im openvpn.exe"
                                    Shell("cmd /c" & g, vbHide)
                                    TimerLog.Stop()
                                    Timer1.Stop()
                                    connected_yes = 0
                                    InfoBar.ForeColor = Color.FromArgb(253, 106, 72)
                                    InfoBar.Text = "认证失败!"
                                    InfoBar.Update()
                                    InfoBar.Refresh()
                            ConnectButton.Text = "连  接"
                                    If Form2.PingBox.Checked = True Then
                                        Dim gg As String
                                        gg = "taskkill /f /im ping.exe"
                                        Shell("cmd /c" & gg, vbHide)
                                    End If
                                    ConnectButton.Update()
                                    ConnectButton.Refresh()
                                    ConnectButton.Enabled = True
                                    NotifyIcon1.ShowBalloonTip(3000, AppName, "认证失败!", ToolTipIcon.Info)

                                ElseIf InStrRev(textline(n), "There are no TAP-Windows adapters on this system") > 0 Then
                                    Logs.SelectedText = Logs.SelectedText & "系统中未安装TAP-Win32网卡适配器!" & vbCrLf
                                    Dim g As String
                                    g = "taskkill /f /im openvpn.exe"
                                    Shell("cmd /c" & g, vbHide)
                                    If Form2.PingBox.Checked = True Then
                                        Dim gg As String
                                        gg = "taskkill /f /im ping.exe"
                                        Shell("cmd /c" & gg, vbHide)
                                    End If
                                    connected_yes = 0
                                    NotifyIcon1.ShowBalloonTip(3000, AppName, "没有发现TAP-Windows网卡适配器!", ToolTipIcon.Info)
                                    InfoBar.ForeColor = Color.FromArgb(253, 106, 72)
                                    InfoBar.Text = "没有发现TAP-Win32网卡适配器!"
                                    InfoBar.Update()
                                    InfoBar.Refresh()
                            ConnectButton.Text = "连  接"
                                    ConnectButton.Update()
                                    ConnectButton.Refresh()
                                    ConnectButton.Enabled = True
                                    TimerLog.Stop()
                                    Timer1.Stop()
                                    TimerLog.Enabled = False
                                    tapg = 1
                                    Dim tap_error As New tap_error
                                    tap_error.ShowDialog()
                                ElseIf InStrRev(textline(n), "Inactivity timeout (--ping-restart), restarting") > 0 Then
                                    Dim g As String
                                    g = "taskkill /f /im openvpn.exe"
                                    Shell("cmd /c" & g, vbHide)
                                    If Form2.PingBox.Checked = True Then
                                        Dim gg As String
                                        gg = "taskkill /f /im ping.exe"
                                        Shell("cmd /c" & gg, vbHide)
                                    End If
                                    Logs.Text = "======Inactivity timeout======" & vbNewLine & "无法连接到服务器...." & vbCrLf & "请尝试重新连接" & vbCrLf & vbCrLf & "=======Try Again======"
                                    TimerLog.Stop()
                                    Timer1.Stop()
                                    connected_yes = 0
                            ConnectButton.Text = "连  接"
                                    ConnectButton.Update()
                                    ConnectButton.Refresh()
                                    ConnectButton.Enabled = True
                                    InfoBar.ForeColor = Color.FromArgb(253, 106, 72)
                                    InfoBar.Text = "连接超时,请检查本地网络是否正常。"
                                    InfoBar.Update()
                                    InfoBar.Refresh()
                                    NotifyIcon1.ShowBalloonTip(3000, AppName, "连接超时!", ToolTipIcon.Info)
                                ElseIf InStrRev(textline(n), "Exiting") > 0 Then
                                    Dim g As String
                                    g = "taskkill /f /im openvpn.exe"
                                    Shell("cmd /c" & g, vbHide)
                                    If Form2.PingBox.Checked = True Then
                                        Dim gg As String
                                        gg = "taskkill /f /im ping.exe"
                                        Shell("cmd /c" & gg, vbHide)
                                    End If
                                    Try
                                        TimerLog.Stop()
                                        Timer1.Stop()
                                    Catch ex As Exception

                                    End Try

                            ConnectButton.Text = "连  接"
                                    connected_yes = 0
                                    InfoBar.ForeColor = Color.FromArgb(253, 106, 72)
                                    InfoBar.Text = "未连接"
                                    ConnectButton.Update()
                                    ConnectButton.Refresh()
                                    ConnectButton.Enabled = True
                                    InfoBar.Update()
                                    InfoBar.Refresh()
                                    NotifyIcon1.ShowBalloonTip(3000, AppName, "无法连接到服务器", ToolTipIcon.Info)
                                    Logs.Text = "无法连接到服务器" & vbCrLf & "请尝试重新连接"
                                    TimerLog.Enabled = False
                                End If
                    Next
                    last_log = log_ctr
                End If
            Loop
            FileClose(1)
        Catch ex As Exception

        End Try
        Try
            FileClose(1)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub getMyData_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles getMyData.DoWork
        Try
            Dim webClient As New System.Net.WebClient
            webClient.DownloadFile("http://" + domain + "/tcp.xml", Application.StartupPath & "\data\tcp.xml")
            webClient.DownloadFile("http://" + domain + "/udp.xml", Application.StartupPath & "\data\udp.xml")
            webClient.Dispose()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub updateChecker_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles updateChecker.DoWork
        Try
            Dim webClient As New System.Net.WebClient
            tempData = webClient.DownloadString("http://" + domain + "/updater.php")
            webClient.Dispose()
        Catch ex As Exception
            'add ycr 2015.11.27 当没有网络时运行程序会报索引越界错误
            MsgBox("获取更新信息失败,请确保网络通畅!", , AppName)
            End
            'add end
        End Try
    End Sub

    Private Sub updateChecker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles updateChecker.RunWorkerCompleted
        Dim ver_no As String
        Dim file_path As String
        Dim news_data As String
        ver_no = Split(tempData, "::")(0)
        file_path = Split(tempData, "::")(1)
        news_data = Split(tempData, "::")(2)
        Form2.Label7.Text = "v" & ver_no
        Form2.Label7.Refresh()
        Form2.RainoTextBox6.Text = news_data
        Form2.RainoTextBox6.Refresh()
        If ver_no.Contains(version_num) Then

        Else
            MsgBox("发现新版本,请到官网下载最新版", , "更新提示")
            Process.Start(Form2.update_link)
            End
        End If
    End Sub

    Private Sub getMyData_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles getMyData.RunWorkerCompleted
        If Form2.UpdateBox.Checked = True Then
            Try
                updateChecker.RunWorkerAsync()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub CopyrightBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyrightBox.Click

    End Sub

    Private Sub ServersBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ServersBox.SelectedIndexChanged

    End Sub

    Private Sub ChromeThemeContainer1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChromeThemeContainer1.Click

    End Sub

    Private Sub ServerLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ServerLabel.Click

    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick

    End Sub

    Private Sub LinkLabel_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel.LinkClicked
        Try
            Process.Start(Form1.paymore_link)
        Catch ex As Exception
            ' The error message
            MessageBox.Show("在不安全的环境中无法打开链接")
        End Try
    End Sub

    Private Sub ImageTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImageTimer.Tick
        ImageTimer.Enabled = False
        LogoBox.Image = ImageList1.Images(imagenum)
        'Dim dsapi As New DSAPI.图形图像
        'Dim size As Size = New Size(338, 38)
        'Dim image As New Bitmap(ImageList1.Images(0))
        'System.Threading.Thread.Sleep(100)
        If imagenum = 1 Then
            imagenum = 0
        Else
            imagenum += 1
        End If
        ImageTimer.Enabled = True
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        'add ycr 2015.12.29
        Timer2.Enabled = False
        Dim TmpPath As String
        Dim PhoneFlag As Integer

        TmpPath = System.IO.Path.GetTempPath()
        TmpPath += "XConfig.ini"
        'If isfirstrun = 0 Then
        If File.Exists(TmpPath) Then
            Try
                PhoneFlag = GetPrivateProfileInt("VERIFY", "FLAG", 0, TmpPath)
                If PhoneFlag <> 1001 Then
                    MsgBox("这是第一次在本设备上运行程序，请先进行手机验证")
                    SMSForm.ShowDialog()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MsgBox("这是第一次在本设备上运行程序，请先进行手机验证")
            SMSForm.ShowDialog()
        End If
        'add end
    End Sub

    Private Sub FlatGroupBox1_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Timer_Notice_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Notice.Tick

        Timer_Notice.Stop()
        Dim strNotice As String
        If String.IsNullOrEmpty(noticeone) = False Then
            strNotice = "1. " & noticeone & vbCrLf
        End If

        If String.IsNullOrEmpty(noticetwo) = False Then
            strNotice += "2. " & noticetwo & vbCrLf
        End If

        If String.IsNullOrEmpty(noticethree) = False Then
            strNotice += "3. " & noticethree
        End If

        If strNotice.Length > 0 Then
            NotifyIcon1.BalloonTipText = "公告"
            NotifyIcon1.ShowBalloonTip(15000, NotifyIcon1.BalloonTipText, strNotice, ToolTipIcon.Info)
        End If

    End Sub

    Private Sub DropButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DropButton.Click
        If MsgBox("确定要强制下线吗?", MsgBoxStyle.YesNo, AppName) = vbYes Then
            PassWord.ShowDialog()
        End If
    End Sub
End Class