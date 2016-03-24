Public Class Form2
    ' -----------------------------------------------XXXXXXXXXXXXXXXXX-----------------------------------------------
    '
    ' Name  All In One VPN Client for Windows
    ' Author Balaji
    ' Copyright © 2014 ProThemes.Biz
    '
    ' -----------------------------------------------XXXXXXXXXXXXXXXXX-----------------------------------------------
    Private ConfigPathname As String = Application.StartupPath & "\data\settings.dat"
    Dim tempData As String = "1.0::http://script8.prothemes.biz/update.zip::News"  ' Sample data
    Public Shared update_link As String = "http://www.6nianji.cn/download.html"
    Private PvtKey As String = "99999999"
    Private Sub FlatCheckbox3_CheckedChanged(ByVal sender As Object) Handles LPageBox.CheckedChanged
        'If UpdateBox.Checked = True Then
        '    LPageTextBox.Enabled = True
        'ElseIf UpdateBox.Checked = False Then
        '    LPageTextBox.Enabled = False
        'End If
    End Sub

    Private Sub FlatButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveButton1.Click
        Try
            If StartBox.Checked = True Then
                My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True).SetValue(Form1.AppName, Application.ExecutablePath)
            ElseIf StartBox.Checked = False Then
                My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True).DeleteValue(Form1.AppName)
            End If
        Catch ex As Exception

        End Try
        If UDP_PortBox.Text.Trim = "" Then
            MsgBox("服务器端口未设置!", , Form1.AppName)
            GoTo line1
        End If
        If BindBox.Text.Trim = "" Then
            MsgBox("本地端口未设置!", , Form1.AppName)
            GoTo line1
        End If
        If UsernameBox.Text.Trim = "" Then
            MsgBox("用户名不能为空!", , Form1.AppName)
            GoTo line1
        End If
        If PasswordBox.Text.Trim = "" Then
            MsgBox("密码不能为空!", , Form1.AppName)
            GoTo line1
        End If
        Try
            'add ycr 2015.11.20
            Dim des As New ZU14.DES()
            Dim tmp As String
            tmp = "tmp"
            des.PASS = "cernewtech"
            des.PrivateKey = PvtKey
            des.DecryptFile(Application.StartupPath + "\data\settings.tmp", Application.StartupPath + "\data\settings.dat")
            ' des.DecryptFile(Application.StartupPath + "\data\acc.log", Application.StartupPath + "\data\acc.tmp")
            'add end
            Dim xoption As New _Set
            Dim xoptionRow As _Set.optionsRow
            xoptionRow = xoption.options.NewoptionsRow
            xoptionRow.startup = StartBox.Checked
            xoptionRow.notify = UpdateBox.Checked
            xoptionRow.landing_page = LPageBox.Checked
            xoptionRow.tcprport = TCP_PortBox.Text.Trim
            xoptionRow.udprport = UDP_PortBox.Text.Trim
            xoptionRow.ping = PingBox.Checked
            xoptionRow.lport = BindBox.Text.Trim
            xoptionRow.username = UsernameBox.Text.Trim
            xoptionRow.password = PasswordBox.Text.Trim
            xoptionRow.page = LPageTextBox.Text.Trim
            xoption.options.AddoptionsRow(xoptionRow)
            xoption.WriteXml(ConfigPathname, System.Data.XmlWriteMode.IgnoreSchema)
            'add ycr 2015.11.20
            des.EncryptFile(Application.StartupPath + "\data\settings.dat", Application.StartupPath + "\data\settings.tmp")
            FileIO.FileSystem.DeleteFile(Application.StartupPath + "\data\settings.dat")
            'end
            Try
                FileOpen(1, Application.StartupPath & ("\data\acc.tmp"), OpenMode.Output)
            Catch
            End Try
            Try
                PrintLine(1, UsernameBox.Text)
                Print(1, PasswordBox.Text)
            Catch

            End Try
            FileClose(1)
            'add ycr 2015.11.20
            'des.EncryptFile(Application.StartupPath + "\data\acc.tmp", Application.StartupPath + "\data\acc.log")
            ' FileIO.FileSystem.DeleteFile(Application.StartupPath + "\data\acc.tmp")
            'add end
            MsgBox("保存设置成功", , Form1.AppName)
            Me.Hide()
        Catch ex As Exception
            MsgBox("保存设置失败!", , Form1.AppName)
        End Try
line1:
    End Sub

    Private Sub FlatButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveButton3.Click
        Try
            If StartBox.Checked = True Then
                My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True).SetValue(Form1.AppName, Application.ExecutablePath)
            ElseIf StartBox.Checked = False Then
                My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True).DeleteValue(Form1.AppName)
            End If
        Catch ex As Exception

        End Try
        If UDP_PortBox.Text.Trim = "" Then
            MsgBox("服务器端口未设置!", , Form1.AppName)
            GoTo line1
        End If
        If BindBox.Text.Trim = "" Then
            MsgBox("本地端口未设置!", , Form1.AppName)
            GoTo line1
        End If
        If UsernameBox.Text.Trim = "" Then
            MsgBox("用户名不能为空!", , Form1.AppName)
            GoTo line1
        End If
        If PasswordBox.Text.Trim = "" Then
            MsgBox("密码不能为空!", , Form1.AppName)
            GoTo line1
        End If
        Try
            'add ycr 2015.11.20
            Dim des As New ZU14.DES()
            Dim tmp As String
            tmp = "tmp"
            des.PASS = "cernewtech"
            des.PrivateKey = PvtKey
            des.DecryptFile(Application.StartupPath + "\data\settings.tmp", Application.StartupPath + "\data\settings.dat")
            'des.DecryptFile(Application.StartupPath + "\data\acc.log", Application.StartupPath + "\data\acc.tmp")
            'add end
            Dim xoption As New _Set
            Dim xoptionRow As _Set.optionsRow
            xoptionRow = xoption.options.NewoptionsRow
            xoptionRow.startup = StartBox.Checked
            xoptionRow.notify = UpdateBox.Checked
            xoptionRow.landing_page = LPageBox.Checked
            xoptionRow.tcprport = TCP_PortBox.Text.Trim
            xoptionRow.lport = BindBox.Text.Trim
            xoptionRow.udprport = UDP_PortBox.Text.Trim
            xoptionRow.ping = PingBox.Checked
            xoptionRow.username = UsernameBox.Text.Trim
            xoptionRow.password = PasswordBox.Text.Trim
            xoptionRow.page = LPageTextBox.Text.Trim
            xoption.options.AddoptionsRow(xoptionRow)
            xoption.WriteXml(ConfigPathname, System.Data.XmlWriteMode.IgnoreSchema)
            'add ycr 2015.11.20
            des.EncryptFile(Application.StartupPath + "\data\settings.dat", Application.StartupPath + "\data\settings.tmp")
            FileIO.FileSystem.DeleteFile(Application.StartupPath + "\data\settings.dat")
            'add end
            Try
                FileOpen(1, Application.StartupPath & ("\data\acc.tmp"), OpenMode.Output)
            Catch
            End Try
            Try
                PrintLine(1, UsernameBox.Text)
                Print(1, PasswordBox.Text)
            Catch

            End Try
            FileClose(1)
            'add ycr 2015.11.20
            'des.EncryptFile(Application.StartupPath + "\data\acc.tmp", Application.StartupPath + "\data\acc.log")
            'FileIO.FileSystem.DeleteFile(Application.StartupPath + "\data\acc.tmp")
            'add end
            MsgBox("保存设置成功", , Form1.AppName)
            Me.Hide()
        Catch ex As Exception
            MsgBox("保存设置失败!", , Form1.AppName)
        End Try
line1:
    End Sub

    Private Sub FlatLabel6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AccountLinkBox.Click
        Process.Start(Form1.account_link)
    End Sub

    Private Sub FlatButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateButton.Click
        Try
            Dim webClient As New System.Net.WebClient
            tempData = webClient.DownloadString("http://" + Form1.domain + "/updater.php")
            webClient.Dispose()
        Catch ex As Exception

        End Try
        Dim ver_no As String
        Dim file_path As String
        Dim news_data As String
        ver_no = Split(tempData, "::")(0)
        file_path = Split(tempData, "::")(1)
        news_data = Split(tempData, "::")(2)
        Label7.Text = "v" & ver_no
        Label7.Refresh()
        RainoTextBox6.Text = news_data
        RainoTextBox6.Refresh()
        If ver_no.Contains(Form1.version_num) Then
            MsgBox("已经是最新版", , "更新提示")
        Else
            MsgBox("发现新版本,请到官网下载最新版", , "更新提示")
            Process.Start(update_link)
            End
            'Not avilable - Contact Support
            '  Process.Start(Application.StartupPath & "\Updater.exe")
            '   End
        End If
    End Sub

    Private Sub FlatButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveButton2.Click
        Try
            If StartBox.Checked = True Then
                My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True).SetValue(Form1.AppName, Application.ExecutablePath)
            ElseIf StartBox.Checked = False Then
                My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True).DeleteValue(Form1.AppName)
            End If
        Catch ex As Exception

        End Try
        If UDP_PortBox.Text.Trim = "" Then
            MsgBox("服务器端口未设置!", , Form1.AppName)
            GoTo line1
        End If
        If BindBox.Text.Trim = "" Then
            MsgBox("本地端口未设置!", , Form1.AppName)
            GoTo line1
        End If
        If UsernameBox.Text.Trim = "" Then
            MsgBox("用户名不能为空!", , Form1.AppName)
            GoTo line1
        End If
        If PasswordBox.Text.Trim = "" Then
            MsgBox("密码不能为空!", , Form1.AppName)
            GoTo line1
        End If
        Try
            'add ycr 2015.11.20
            Dim des As New ZU14.DES()
            Dim tmp As String
            tmp = "tmp"
            des.PASS = "cernewtech"
            des.PrivateKey = PvtKey
            des.DecryptFile(Application.StartupPath + "\data\settings.tmp", Application.StartupPath + "\data\settings.dat")
            'add end
            Dim xoption As New _Set
            Dim xoptionRow As _Set.optionsRow
            xoptionRow = xoption.options.NewoptionsRow
            xoptionRow.startup = StartBox.Checked
            xoptionRow.notify = UpdateBox.Checked
            xoptionRow.landing_page = LPageBox.Checked
            xoptionRow.tcprport = TCP_PortBox.Text.Trim
            xoptionRow.lport = BindBox.Text.Trim
            xoptionRow.udprport = UDP_PortBox.Text.Trim
            xoptionRow.ping = PingBox.Checked
            xoptionRow.username = UsernameBox.Text.Trim
            xoptionRow.password = PasswordBox.Text.Trim
            xoptionRow.page = LPageTextBox.Text.Trim
            xoption.options.AddoptionsRow(xoptionRow)
            xoption.WriteXml(ConfigPathname, System.Data.XmlWriteMode.IgnoreSchema)
            'add ycr 2015.11.20
            des.EncryptFile(Application.StartupPath + "\data\settings.dat", Application.StartupPath + "\data\settings.tmp")
            FileIO.FileSystem.DeleteFile(Application.StartupPath + "\data\settings.dat")
            'add end
            Try
                FileOpen(1, Application.StartupPath & ("\data\acc.tmp"), OpenMode.Output)
            Catch
            End Try
            Try
                PrintLine(1, UsernameBox.Text)
                Print(1, PasswordBox.Text)
            Catch

            End Try
            FileClose(1)
            'add ycr 2015.11.20
            ' des.EncryptFile(Application.StartupPath + "\data\acc.tmp", Application.StartupPath + "\data\acc.log")
            'FileIO.FileSystem.DeleteFile(Application.StartupPath + "\data\acc.tmp")
            'add end
            MsgBox("保存设置成功", , Form1.AppName)
            Me.Hide()
        Catch ex As Exception
            MsgBox("保存设置失败!", , Form1.AppName)
        End Try
line1:
    End Sub

    Private Sub StartBox_CheckedChanged(ByVal sender As System.Object) Handles StartBox.CheckedChanged

    End Sub

    Private Sub TabPage4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage4.Click

    End Sub

    Private Sub PingBox_CheckedChanged(ByVal sender As System.Object) Handles PingBox.CheckedChanged

    End Sub

    Private Sub Form2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Top = 200
        Me.Left = 400
    End Sub

    Private Sub TabPage2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage2.Click

    End Sub

    Private Sub TabPage3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage3.Click

    End Sub

    Private Sub TabPage1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage1.Click
        LPageTextBox.Enabled = False
    End Sub

    Private Sub BindBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindBox.Click

    End Sub

    Private Sub FlatLabel10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatLabel10.Click

    End Sub

    Private Sub UpdateBox_CheckedChanged(ByVal sender As System.Object) Handles UpdateBox.CheckedChanged

    End Sub

    Private Sub FlatTabControl1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles FlatTabControl1.Click

    End Sub

    Private Sub ChromeThemeContainer1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChromeThemeContainer1.Click

    End Sub
End Class