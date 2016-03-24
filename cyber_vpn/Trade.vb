Imports System.IO
Imports System.Net
Imports System.Net.Sockets


Namespace trade
    Public Class TRADE

        '账户登录
        Public Function Login(ByVal login_info As Form1.loginfo, ByRef result As Form1.userinfo) As Boolean
            Dim tmpfilename As String
            Dim recvfilename As String
            Dim xmloper As New XMLOPER.XMLOPERATE()
            Dim tcpoper As New TCPOPER.TCPOPERATE()
            Dim ret As Integer = 0
            Dim errinfo As String = ""
            Try
                '创建临时文件名
                tmpfilename = System.IO.Path.GetTempFileName()
                '连接服务器
                If tcpoper.ConnectServer(ret) = False Then
                    Throw New Exception()
                End If
                '写登录交易xml
                xmloper.SendUserInfoXML(tmpfilename, login_info)
                '发送并接受返回信息
                tcpoper.SendAndRecv(tmpfilename, recvfilename, ret)
                '解析返回的报文
                xmloper.ReadUserInfoXMl(recvfilename, result)
                Login = True
            Catch ex As Exception
                Login = False
                Select Case ret
                    Case 10024
                        errinfo = "服务器忙，请稍后再试"
                    Case 10048
                        errinfo = "IP端口冲突"
                    Case 10050
                        errinfo = "没有网络，请查看后再试"
                    Case 10051
                        errinfo = "无法连接到服务器，请确认本地路由是否配置正确"
                    Case 10056
                        errinfo = "程序重复登录"
                    Case 10060
                        errinfo = "连接超时"
                    Case 10061
                        errinfo = "服务器正在维护，登录失败"
                End Select
                Form1.InfoBar.ForeColor = Color.FromArgb(253, 106, 72)
                Form1.InfoBar.Text = errinfo
                Form1.InfoBar.Update()
                Form1.InfoBar.Refresh()
            Finally
                System.IO.File.Delete(tmpfilename)                  '删除临时文件
            End Try
        End Function

        '流量查询
        Public Function QueryFlow(ByVal user_info As Form1.userinfo, ByRef result As Form1.flowinfo, ByRef errinfo As String) As Boolean
            Dim tmpfilename As String
            Dim recvfilename As String
            Dim xmloper As New XMLOPER.XMLOPERATE()
            Dim tcpoper As New TCPOPER.TCPOPERATE()
            Dim ret As Integer
            Try
                '创建临时文件名
                tmpfilename = System.IO.Path.GetTempFileName()
                '连接服务器
                tcpoper.ConnectServer(ret)
                '写登录交易xml
                xmloper.SendQueryFlowXML(tmpfilename, user_info)
                '发送并接受返回信息
                tcpoper.SendAndRecv(tmpfilename, recvfilename, ret)
                '解析返回的报文
                xmloper.ReadQueryFlowXMl(tmpfilename, result)
                QueryFlow = True
            Catch ex As Exception
                QueryFlow = False
                Select Case ret
                    Case 10024
                        errinfo = "服务器忙，请稍后再试"
                    Case 10048
                        errinfo = "IP端口冲突"
                    Case 10050
                        errinfo = "没有网络，请查看后再试"
                    Case 10051
                        errinfo = "无法连接到服务器，请确认本地路由是否配置正确"
                    Case 10056
                        errinfo = "程序重复登录"
                    Case 10060
                        errinfo = "连接超时"
                    Case 10061
                        errinfo = "服务器正在维护，登录失败"
                End Select
            Finally
                System.IO.File.Delete(tmpfilename)                  '删除临时文件
            End Try
        End Function

        '获取验证码
        Public Function GetIdentifyCode(ByVal IdentifyInfo As Form1.sendidentifyinfo, ByRef recvinfo As Form1.recvidentifyinfo, ByRef errinfo As String) As Boolean
            Dim tmpfilename As String
            Dim recvfilename As String
            Dim xmloper As New XMLOPER.XMLOPERATE()
            Dim tcpoper As New TCPOPER.TCPOPERATE()
            Dim ret As Integer
            Try
                '创建临时文件名
                tmpfilename = System.IO.Path.GetTempFileName()
                '连接服务器
                If tcpoper.ConnectServer(ret) = False Then
                    Throw New Exception()
                End If
                '写登录交易xml
                If xmloper.SendIdentifyCodeXML(tmpfilename, IdentifyInfo) = False Then
                    ret = 11000
                    Throw New Exception("生成数据发生错误")
                End If
                '发送并接受返回信息
                If tcpoper.SendAndRecv(tmpfilename, recvfilename, ret) = False Then
                    Throw New Exception()
                End If
                '解析返回的报文
                If xmloper.ReadIdentifyCodeXML(recvfilename, recvinfo) = False Then
                    ret = 11001
                    Throw New Exception()
                End If
                GetIdentifyCode = True
            Catch ex As Exception
                GetIdentifyCode = False
                'MsgBox("错误码:" + ret.ToString)
                Select Case ret
                    Case 10024
                        errinfo = "服务器忙，请稍后再试"
                    Case 10048
                        errinfo = "IP端口冲突"
                    Case 10050
                        errinfo = "无法连接到网络"
                    Case 10051
                        errinfo = "无法连接到服务器，请确认本地路由是否配置正确"
                    Case 10056
                        errinfo = "程序重复登录"
                    Case 10060
                        errinfo = "连接超时"
                    Case 10061
                        errinfo = "服务器正在维护，发送失败"
                    Case 10065
                        errinfo = "没有网络，请检查网络状态"
                    Case 11000
                        errinfo = "数据处理发生错误"
                    Case 11001
                        errinfo = "解析返回数据发生错误"
                    Case Else
                        errinfo = "发生未知错误"
                End Select
            Finally
                System.IO.File.Delete(tmpfilename)                  '删除临时文件
            End Try
        End Function
        '发送验证成功报文
        Public Function IdentifySuccess(ByRef result As String, ByVal Identifyinfo As Form1.sendidentifyinfo, ByRef errinfo As String) As Boolean
            Dim tmpfilename As String
            Dim recvfilename As String
            Dim xmloper As New XMLOPER.XMLOPERATE()
            Dim tcpoper As New TCPOPER.TCPOPERATE()
            Dim ret As Integer
            Try
                '创建临时文件名
                tmpfilename = System.IO.Path.GetTempFileName()
                '连接服务器
                If tcpoper.ConnectServer(ret) = False Then
                    Throw New Exception()
                End If
                '写登录交易xml
                If xmloper.SendIdentifySuccessXML(tmpfilename, Identifyinfo) = False Then
                    errinfo = 11000
                    Throw New Exception()
                End If
                '发送并接受返回信息
                If tcpoper.SendAndRecv(tmpfilename, recvfilename, ret) = False Then
                    Throw New Exception()
                End If
                '解析返回的报文
                If xmloper.ReadIdentifySuccessXML(tmpfilename, result) = False Then
                    errinfo = 11001
                    Throw New Exception()
                End If
                IdentifySuccess = True
            Catch ex As Exception
                IdentifySuccess = False
                Select Case ret
                    Case 10024
                        errinfo = "服务器忙，请稍后再试"
                    Case 10048
                        errinfo = "IP端口冲突"
                    Case 10050
                        errinfo = "无法连接到网络"
                    Case 10051
                        errinfo = "无法连接到服务器，请确认本地路由是否配置正确"
                    Case 10056
                        errinfo = "程序重复登录"
                    Case 10060
                        errinfo = "连接超时"
                    Case 10061
                        errinfo = "服务器正在维护，发送失败"
                    Case 10065
                        errinfo = "没有网络，请检查网络状态"
                    Case 11000
                        errinfo = "数据处理发生错误"
                    Case 11001
                        errinfo = "解析返回数据发生错误"
                    Case Else
                        errinfo = "发生未知错误"
                End Select
            Finally
                System.IO.File.Delete(tmpfilename)                  '删除临时文件
            End Try
        End Function


        '发送用户下线报文
        Public Function DropLine(ByRef result As String, ByVal Account As String, ByRef errinfo As String) As Boolean
            Dim tmpfilename As String
            Dim recvfilename As String
            Dim xmloper As New XMLOPER.XMLOPERATE()
            Dim tcpoper As New TCPOPER.TCPOPERATE()
            Dim ret As Integer
            Try
                '创建临时文件名
                tmpfilename = System.IO.Path.GetTempFileName()
                '连接服务器
                If tcpoper.ConnectServer(ret) = False Then
                    Throw New Exception()
                End If
                '写登录交易xml
                If xmloper.SendDropLineXML(tmpfilename, Account) = False Then
                    errinfo = 11000
                    Throw New Exception()
                End If
                '发送并接受返回信息
                If tcpoper.SendAndRecv(tmpfilename, recvfilename, ret) = False Then
                    Throw New Exception()
                End If
                '解析返回的报文
                If xmloper.ReadDropLineXML(recvfilename, result) = False Then
                    errinfo = 11001
                    Throw New Exception()
                End If
                DropLine = True
            Catch ex As Exception
                DropLine = False
                Select Case ret
                    Case 10024
                        errinfo = "服务器忙，请稍后再试"
                    Case 10048
                        errinfo = "IP端口冲突"
                    Case 10050
                        errinfo = "无法连接到网络"
                    Case 10051
                        errinfo = "无法连接到服务器，请确认本地路由是否配置正确"
                    Case 10056
                        errinfo = "程序重复登录"
                    Case 10060
                        errinfo = "连接超时"
                    Case 10061
                        errinfo = "服务器正在维护，发送失败"
                    Case 10065
                        errinfo = "没有网络，请检查网络状态"
                    Case 11000
                        errinfo = "数据处理发生错误"
                    Case 11001
                        errinfo = "解析返回数据发生错误"
                    Case Else
                        errinfo = "发生未知错误"
                End Select
            Finally
                System.IO.File.Delete(tmpfilename)                  '删除临时文件
            End Try
        End Function
    End Class

End Namespace
