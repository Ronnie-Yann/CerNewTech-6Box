Imports System.IO
Imports System.Net
Imports System.Net.Sockets

Namespace TCPOPER

    Public NotInheritable Class TCPOPERATE

        Public Shared sclient As New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
        Public Shared serverip As IPAddress = IPAddress.Parse(Form1.serverip)        '服务端IP
        Public Shared serverport As New IPEndPoint(serverip, Form1.serverport)                   '设置服务端IP，Port

        Public Function ConnectServer(ByRef ret As Integer) As Boolean
            sclient = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)

            Dim clientport As New IPEndPoint(serverip, 2002)         '设置客户端IP，Port和超时时间
            sclient.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, 20000)
            sclient.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 20000)
            Try
                sclient.Connect(serverport)                           '客户端绑定服务端
                ConnectServer = True
            Catch ex As SocketException
                ConnectServer = False
                ret = ex.ErrorCode
            Catch ex As Exception
                ConnectServer = False
                MsgBox(ex.Message)
            End Try
        End Function

        Public Function SendAndRecv(ByVal Filename As String, ByRef recvfilenam As String, ByRef ret As Integer) As Boolean
            Dim Content As String
            Dim Sendbuf() As Byte
            Dim Revbuf(2048) As Byte
            Try
                If File.Exists(Filename) Then
                    Content = File.ReadAllText(Filename)
                    Sendbuf = System.Text.Encoding.UTF8.GetBytes(Content)
                    sclient.SendTo(Sendbuf, serverport)

                    sclient.ReceiveFrom(Revbuf, serverport)
                    Content = System.Text.Encoding.UTF8.GetString(Revbuf)
                    recvfilenam = System.IO.Path.GetTempFileName()
                    FileOpen(2, recvfilenam, OpenMode.Output)
                    PrintLine(2, Content)
                    FileClose(2)
                    sclient.Close()
                    If File.Exists(Filename) Then
                        FileIO.FileSystem.DeleteFile(Filename)
                    End If
                    SendAndRecv = True
                End If
            Catch ex As SocketException
                SendAndRecv = False
                sclient.Close()
                ret = ex.ErrorCode
            Catch ex As Exception
                SendAndRecv = False
                sclient.Close()
                ret = 10099
            End Try
        End Function
    End Class 'TCPOPERATE
End Namespace