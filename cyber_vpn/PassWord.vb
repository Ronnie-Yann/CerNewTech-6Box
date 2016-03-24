Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Net.NetworkInformation
Imports System.Management

Public Class PassWord

    Private Sub ButtonOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOK.Click

        Dim dropline As New trade.TRADE
        Dim result As String
        Dim errinfo As String

        If PWDBox.TextLength = 0 Then
            InfoLabel.Text = "提示:密码不能为空"

        Else
            If PWDBox.Text = Form2.PasswordBox.Text Then
                InfoLabel.Text = "提示:下线中,请等待"
                If dropline.DropLine(result, Form2.UsernameBox.Text, errinfo) = True Then
                    If result = 0 Then
                        MsgBox("强制下线成功!")
                        InfoLabel.Text = ""
                        PWDBox.Text =""
                        Me.Close()
                    Else
                        InfoLabel.Text = "提示:强制下线失败,请重试"
                        PWDBox.Text = ""
                    End If
                Else
                    InfoLabel.Text = "提示:" + errinfo
                End If
            Else
                InfoLabel.Text = "提示:密码错误"
            End If
        End If
    End Sub

    Private Sub PassWord_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        UserNameTextBox.Text = Form2.UsernameBox.Text
    End Sub

    Private Sub PassWord_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

    End Sub

    Private Sub PWDBox_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles PWDBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            ButtonOK_Click(sender, e)
        End If
    End Sub
End Class