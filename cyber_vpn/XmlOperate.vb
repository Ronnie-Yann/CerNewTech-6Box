Imports System.Xml

Namespace XMLOPER
    Public NotInheritable Class XMLOPERATE
        ' <summary>
        '发送账户信息XML文件
        '</summary>
        '<param name="xmlFileName">要创建的XML文件名</param>
        '<remarks></remarks>
        Public Function SendUserInfoXML(ByVal xmlFileName As String, ByVal loginfo As Form1.loginfo) As Boolean
            Try
                Dim writer As New Xml.XmlTextWriter(xmlFileName, System.Text.Encoding.GetEncoding("utf-8"))
                '使用自动缩进便于阅读
                writer.Formatting = Xml.Formatting.Indented
                writer.WriteRaw("<?xml version=""1.0"" encoding=""utf-8"" ?>")
                '书写根元素()
                writer.WriteStartElement("Config")
                '添加次级元素
                writer.WriteStartElement("DatabaseSetting")
                '添加子元素()
                writer.WriteElementString("tradeno", "T10001")
                writer.WriteElementString("account", loginfo.userid)
                '为Datasource添加一个属性为value，值为test 的属性
                'writer.WriteAttributeString("value","test")
                writer.WriteElementString("account_password", loginfo.userpwd)
                writer.WriteElementString("login_ip", loginfo.hostip)
                writer.WriteElementString("usercode", loginfo.usercode)

                '关闭次级元素DatabaseSetting
                writer.WriteEndElement()
                '关闭根元素
                writer.WriteFullEndElement()
                '将XML写入文件并关闭writer
                writer.Close()
                SendUserInfoXML = True
            Catch ex As Exception
                SendUserInfoXML = False
                ' MsgBox(ex.Message & vbCrLf & ex.StackTrace)
            End Try
        End Function
        ' <summary>
        ' 修改XML
        ' </summary>
        ' <param name="xmlFileName">要修改的XML文件名</param>
        ' <param name="rootName">XML文件中的根元素名称</param>
        ' <param name="elementNameArry">要修改的元素数组</param>
        ' <param name="innerTextArry">对应于要修改的元素数组的修改文本数组</param>
        ' <remarks></remarks>
        Public Function modifXML(ByVal xmlFileName As String, ByVal rootName As String, ByVal elementNameArry() As String, ByVal innerTextArry() As String) As Boolean
            Try
                If My.Computer.FileSystem.FileExists(Application.StartupPath.Trim & "" & xmlFileName) Then
                    Dim doc As New Xml.XmlDocument
                    doc.Load(Application.StartupPath.Trim & "" & xmlFileName)
                    Dim list As Xml.XmlNodeList = doc.SelectSingleNode(rootName).ChildNodes
                    For Each xn As Xml.XmlNode In list
                        Dim xe As Xml.XmlElement
                        xe = xn
                        Dim nls As Xml.XmlNodeList = xe.ChildNodes
                        For Each xn1 As Xml.XmlNode In nls
                            Dim xe2 As Xml.XmlElement
                            xe2 = xn1
                            For i As Integer = 0 To elementNameArry.Length - 1
                                If xe2.Name = elementNameArry(i) Then
                                    xe2.InnerText = innerTextArry(i)
                                End If
                            Next
                        Next
                    Next
                    doc.Save(Application.StartupPath.Trim & "" & xmlFileName)
                End If
            Catch ex As Exception
                ' MsgBox(ex.Message)
            End Try
        End Function
        ' <summary>
        ' 读取账户信息XML文件
        ' </summary>
        '<param name="xmlFileName">要读取的XML文件名</param>
        ' <remarks></remarks>
        Public Function ReadUserInfoXMl(ByVal xmlFileName As String, ByRef userinfo As Form1.userinfo)
            Try
                If My.Computer.FileSystem.FileExists(xmlFileName) Then
                    Dim doc As New Xml.XmlDocument
                    doc.Load(xmlFileName)
                    Dim re As Xml.XmlNodeReader = New Xml.XmlNodeReader(doc)
                    Dim tmpStr As String = ""
                    Dim name As String

                    While re.Read
                        Select Case re.NodeType
                            Case Xml.XmlNodeType.Element
                                name = re.Name
                            Case Xml.XmlNodeType.Text
                                If name.Equals("account") Then
                                    userinfo.userid = re.Value
                                End If
                                If name.Equals("return_num") Then
                                    userinfo.returnnum = re.Value
                                End If
                                If name.Equals("account_type") Then
                                    userinfo.accouttype = re.Value
                                End If
                                If name.Equals("Login_state") Then
                                    userinfo.loginstatus = re.Value
                                End If
                                If name.Equals("account_property") Then
                                    userinfo.userproperty = re.Value
                                End If
                                If name.Equals("activation_flag") Then
                                    userinfo.activationflag = re.Value
                                End If
                                If name.Equals("isofficial_flag") Then
                                    userinfo.isofficial = re.Value
                                End If
                                If name.Equals("notice_one") Then
                                    userinfo.noticeone = re.Value
                                End If
                                If name.Equals("notice_two") Then
                                    userinfo.noticetwo = re.Value
                                End If
                                If name.Equals("notice_three") Then
                                    userinfo.noticethree = re.Value
                                End If
                                If name.Equals("agentcode") Then
                                    userinfo.agentcode = re.Value
                                End If
                        End Select
                    End While
                    ReadUserInfoXMl = True
                Else
                    ReadUserInfoXMl = False
                End If
            Catch ex As Exception
                ReadUserInfoXMl = False
                ' MsgBox(ex.Message & vbCrLf & ex.StackTrace)
            Finally
                System.IO.File.Delete(xmlFileName)                  '删除临时文件
            End Try
        End Function

        ' <summary>
        '发送流量用户信息查询XML文件
        '</summary>
        '<param name="xmlFileName">要创建的XML文件名</param>
        '<remarks></remarks>
        Public Function SendQueryFlowXML(ByVal xmlFileName As String, ByRef userinfo As Form1.userinfo) As Boolean
            Try
                Dim writer As New Xml.XmlTextWriter(xmlFileName, System.Text.Encoding.GetEncoding("utf-8"))
                '使用自动缩进便于阅读
                writer.Formatting = Xml.Formatting.Indented
                writer.WriteRaw("<?xml version=""1.0"" encoding=""utf-8"" ?>")
                '书写根元素()
                writer.WriteStartElement("Config")
                '添加次级元素
                writer.WriteStartElement("DatabaseSetting")
                '添加子元素()
                writer.WriteElementString("userid", userinfo.userid)
                '为Datasource添加一个属性为value，值为test 的属性
                'writer.WriteAttributeString("value","test")
                '关闭次级元素DatabaseSetting
                writer.WriteEndElement()
                '关闭根元素
                writer.WriteFullEndElement()
                '将XML写入文件并关闭writer
                writer.Close()
                SendQueryFlowXML = True
            Catch ex As Exception
                SendQueryFlowXML = False
                ' MsgBox(ex.Message & vbCrLf & ex.StackTrace)
            End Try
        End Function

        ' <summary>
        ' 读取流量账户查询信息XML文件
        ' </summary>
        '<param name="xmlFileName">要读取的XML文件名</param>
        ' <remarks></remarks>
        Public Function ReadQueryFlowXMl(ByVal xmlFileName As String, ByRef result As Form1.flowinfo) As Boolean
            Try
                If My.Computer.FileSystem.FileExists(xmlFileName) Then
                    Dim doc As New Xml.XmlDocument
                    doc.Load(xmlFileName)
                    Dim re As Xml.XmlNodeReader = New Xml.XmlNodeReader(doc)
                    Dim tmpStr As String = ""
                    Dim name As String

                    While re.Read
                        Select Case re.NodeType
                            Case Xml.XmlNodeType.Element
                                name = re.Name
                            Case Xml.XmlNodeType.Text
                                If name.Equals("userid") Then
                                    result.userid = re.Value
                                End If
                                If name.Equals("InitialCatalog") Then
                                    tmpStr = tmpStr & ";Initial Catalog=" & re.Value
                                End If
                                If name.Equals("UserID") Then
                                    tmpStr = tmpStr & ";User ID=" & re.Value
                                End If
                                If name.Equals("Password") Then
                                    tmpStr = tmpStr & ";Password=" & re.Value
                                End If
                        End Select
                    End While
                End If
                ReadQueryFlowXMl = True
            Catch ex As Exception
                ReadQueryFlowXMl = False
                ' MsgBox(ex.Message & vbCrLf & ex.StackTrace)
            End Try
        End Function

        ' <summary>
        '发送包月账户查询信息XML文件
        '</summary>
        '<param name="xmlFileName">要创建的XML文件名</param>
        '<remarks></remarks>
        Public Function SendQueryDateXML(ByVal xmlFileName As String) As Boolean
            Try
                Dim writer As New Xml.XmlTextWriter(xmlFileName, System.Text.Encoding.GetEncoding("utf-8"))
                '使用自动缩进便于阅读
                writer.Formatting = Xml.Formatting.Indented
                writer.WriteRaw("<?xml version=""1.0"" encoding=""utf-8"" ?>")
                '书写根元素()
                writer.WriteStartElement("Config")
                '添加次级元素
                writer.WriteStartElement("DatabaseSetting")
                '添加子元素()
                writer.WriteElementString("DataSource", "123")
                '为Datasource添加一个属性为value，值为test 的属性
                'writer.WriteAttributeString("value","test")
                writer.WriteElementString("InitialCatalog", "123")
                writer.WriteElementString("UserID", "123")
                writer.WriteElementString("Password", "123")
                '关闭次级元素DatabaseSetting
                writer.WriteEndElement()
                '添加次级元素StationSetting
                writer.WriteStartElement("StationSetting")
                '添加子元素
                writer.WriteElementString("StoreID", "123")
                writer.WriteElementString("StationID", "123")
                '关闭次级元素StationSetting
                writer.WriteEndElement()
                '关闭根元素
                writer.WriteFullEndElement()
                '将XML写入文件并关闭writer
                writer.Close()
                SendQueryDateXML = True
            Catch ex As Exception
                SendQueryDateXML = False
                '  MsgBox(ex.Message & vbCrLf & ex.StackTrace)
            End Try
        End Function

        ' <summary>
        ' 读取包月账户查询信息XML文件
        ' </summary>
        '<param name="xmlFileName">要读取的XML文件名</param>
        ' <remarks></remarks>
        Public Function ReadQueryDateXML(ByVal xmlFileName As String) As Boolean
            Try
                If My.Computer.FileSystem.FileExists(xmlFileName) Then
                    Dim doc As New Xml.XmlDocument
                    doc.Load(Application.StartupPath.Trim & "" & xmlFileName)
                    Dim re As Xml.XmlNodeReader = New Xml.XmlNodeReader(doc)
                    Dim tmpStr As String = ""
                    Dim name As String

                    While re.Read
                        Select Case re.NodeType
                            Case Xml.XmlNodeType.Element
                                name = re.Name
                            Case Xml.XmlNodeType.Text
                                If name.Equals("DataSource") Then
                                    tmpStr = tmpStr & "Data Source=" & re.Value
                                End If
                                If name.Equals("InitialCatalog") Then
                                    tmpStr = tmpStr & ";Initial Catalog=" & re.Value
                                End If
                                If name.Equals("UserID") Then
                                    tmpStr = tmpStr & ";User ID=" & re.Value
                                End If
                                If name.Equals("Password") Then
                                    tmpStr = tmpStr & ";Password=" & re.Value
                                End If
                        End Select
                    End While
                End If
                ReadQueryDateXML = True
            Catch ex As Exception
                ReadQueryDateXML = False
                'MsgBox(ex.Message & vbCrLf & ex.StackTrace)
            End Try
        End Function

        ' <summary>
        '发送手机验证码XML文件
        '</summary>
        '<param name="xmlFileName">要创建的XML文件名</param>
        '<remarks></remarks>
        Public Function SendIdentifyCodeXML(ByVal xmlFileName As String, ByVal sendidentifyinfo As Form1.sendidentifyinfo) As Boolean
            Try
                Dim writer As New Xml.XmlTextWriter(xmlFileName, System.Text.Encoding.GetEncoding("utf-8"))
                '使用自动缩进便于阅读
                writer.Formatting = Xml.Formatting.Indented
                writer.WriteRaw("<?xml version=""1.0"" encoding=""utf-8"" ?>")
                '书写根元素()
                writer.WriteStartElement("Config")
                '添加次级元素
                writer.WriteStartElement("DatabaseSetting")
                '添加子元素()
                writer.WriteElementString("tradeno", "T10005")
                writer.WriteElementString("phonenum", sendidentifyinfo.phonenum)
                '为Datasource添加一个属性为phonenum，值为sendidentifyinfo.phonenum的属性
                writer.WriteElementString("mac", sendidentifyinfo.mac)
                '关闭次级元素DatabaseSetting
                writer.WriteEndElement()
                '关闭根元素
                writer.WriteFullEndElement()
                '将XML写入文件并关闭writer
                writer.Close()
                SendIdentifyCodeXML = True
            Catch ex As Exception
                SendIdentifyCodeXML = False
                ' MsgBox(ex.Message & vbCrLf & ex.StackTrace)
            End Try
        End Function

        ' <summary>
        ' 读取手机验证返回XML文件
        ' </summary>
        '<param name="xmlFileName">要读取的XML文件名</param>
        ' <remarks></remarks>
        Public Function ReadIdentifyCodeXML(ByVal xmlFileName As String, ByRef recv As Form1.recvidentifyinfo) As Boolean
            Try
                If My.Computer.FileSystem.FileExists(xmlFileName) Then
                    Dim doc As New Xml.XmlDocument
                    doc.Load(xmlFileName)
                    Dim re As Xml.XmlNodeReader = New Xml.XmlNodeReader(doc)
                    Dim name As String

                    While re.Read
                        Select Case re.NodeType
                            Case Xml.XmlNodeType.Element
                                name = re.Name
                            Case Xml.XmlNodeType.Text
                                If name.Equals("identifycode") Then
                                    recv.identifycode = re.Value
                                End If
                                If name.Equals("result") Then
                                    recv.result = re.Value
                                End If
                        End Select
                    End While
                    ReadIdentifyCodeXML = True
                Else
                    ReadIdentifyCodeXML = False
                    recv.result = -1001
                End If
                FileIO.FileSystem.DeleteFile(xmlFileName)

            Catch ex As Exception
                ReadIdentifyCodeXML = False
                FileIO.FileSystem.DeleteFile(xmlFileName)
                'MsgBox(ex.Message & vbCrLf & ex.StackTrace)
            End Try
        End Function

        ' <summary>
        '发送验证成功XML文件
        '</summary>
        '<param name="xmlFileName">要创建的XML文件名</param>
        '<remarks></remarks>
        Public Function SendIdentifySuccessXML(ByVal xmlFileName As String, ByVal sendidentifyinfo As Form1.sendidentifyinfo) As Boolean
            Try
                Dim writer As New Xml.XmlTextWriter(xmlFileName, System.Text.Encoding.GetEncoding("utf-8"))
                '使用自动缩进便于阅读
                writer.Formatting = Xml.Formatting.Indented
                writer.WriteRaw("<?xml version=""1.0"" encoding=""utf-8"" ?>")
                '书写根元素()
                writer.WriteStartElement("Config")
                '添加次级元素
                writer.WriteStartElement("DatabaseSetting")
                '添加子元素()
                writer.WriteElementString("tradeno", "T10006")
                writer.WriteElementString("phonenum", sendidentifyinfo.phonenum)
                writer.WriteElementString("mac", sendidentifyinfo.mac)
                writer.WriteElementString("flag", "0")
                '为Datasource添加一个属性为flag，值为0的属性

                '关闭次级元素DatabaseSetting
                writer.WriteEndElement()
                '关闭根元素
                writer.WriteFullEndElement()
                '将XML写入文件并关闭writer
                writer.Close()
                SendIdentifySuccessXML = True
            Catch ex As Exception
                SendIdentifySuccessXML = False
                ' MsgBox(ex.Message & vbCrLf & ex.StackTrace)
            End Try
        End Function

        ' <summary>
        ' 读取验证成功返回XML文件
        ' </summary>
        '<param name="xmlFileName">要读取的XML文件名</param>
        ' <remarks></remarks>
        Public Function ReadIdentifySuccessXML(ByVal xmlFileName As String, ByRef recv As String) As Boolean
            Try
                If My.Computer.FileSystem.FileExists(xmlFileName) Then
                    Dim doc As New Xml.XmlDocument
                    doc.Load(xmlFileName)
                    Dim re As Xml.XmlNodeReader = New Xml.XmlNodeReader(doc)
                    Dim tmpStr As String = ""
                    Dim name As String

                    While re.Read
                        Select Case re.NodeType
                            Case Xml.XmlNodeType.Element
                                name = re.Name
                            Case Xml.XmlNodeType.Text
                                If name.Equals("result") Then
                                    recv = re.Value
                                End If
                        End Select
                    End While
                    ReadIdentifySuccessXML = True
                Else
                    ReadIdentifySuccessXML = False
                End If

            Catch ex As Exception
                ReadIdentifySuccessXML = False
                'MsgBox(ex.Message & vbCrLf & ex.StackTrace)
            End Try
        End Function


        ' <summary>
        '发送用户下线XML文件
        '</summary>
        '<param name="xmlFileName">要创建的XML文件名</param>
        '<remarks></remarks>
        Public Function SendDropLineXML(ByVal xmlFileName As String, ByVal UserAccount As String) As Boolean
            Try
                Dim writer As New Xml.XmlTextWriter(xmlFileName, System.Text.Encoding.GetEncoding("utf-8"))
                '使用自动缩进便于阅读
                writer.Formatting = Xml.Formatting.Indented
                writer.WriteRaw("<?xml version=""1.0"" encoding=""utf-8"" ?>")
                '书写根元素()
                writer.WriteStartElement("Config")
                '添加次级元素
                writer.WriteStartElement("DatabaseSetting")
                '添加子元素()
                writer.WriteElementString("tradeno", "T10007")
                writer.WriteElementString("account", UserAccount)
                '为Datasource添加一个属性为flag，值为0的属性

                '关闭次级元素DatabaseSetting
                writer.WriteEndElement()
                '关闭根元素
                writer.WriteFullEndElement()
                '将XML写入文件并关闭writer
                writer.Close()
                SendDropLineXML = True
            Catch ex As Exception
                SendDropLineXML = False
                ' MsgBox(ex.Message & vbCrLf & ex.StackTrace)
            End Try
        End Function



        ' <summary>
        ' 读取用户下线返回XML文件
        ' </summary>
        '<param name="xmlFileName">要读取的XML文件名</param>
        ' <remarks></remarks>
        Public Function ReadDropLineXML(ByVal xmlFileName As String, ByRef recv As String) As Boolean
            Try
                If My.Computer.FileSystem.FileExists(xmlFileName) Then
                    Dim doc As New Xml.XmlDocument
                    doc.Load(xmlFileName)
                    Dim re As Xml.XmlNodeReader = New Xml.XmlNodeReader(doc)
                    Dim tmpStr As String = ""
                    Dim name As String

                    While re.Read
                        Select Case re.NodeType
                            Case Xml.XmlNodeType.Element
                                name = re.Name
                            Case Xml.XmlNodeType.Text
                                If name.Equals("return_num") Then
                                    recv = re.Value
                                End If
                        End Select
                    End While
                    ReadDropLineXML = True
                End If
            Catch ex As Exception
                ReadDropLineXML = False
            Finally
                System.IO.File.Delete(xmlFileName)                  '删除临时文件
            End Try
        End Function
    End Class
End Namespace