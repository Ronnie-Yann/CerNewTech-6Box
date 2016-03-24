Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.IO
Imports System.Security
Imports System.Security.Cryptography

Namespace ZU14
    Public NotInheritable Class DES
        Private iv As String
        Private key As String

        '/ <summary> 
        '/ DES加密偏移量，必须是>=8位长的字符串  
        '/ </summary> 

        Public Property PASS() As String
            Get
                Return iv
            End Get
            Set(ByVal value As String)
                iv = value
            End Set
        End Property
        '/ <summary> 
        '/ DES加密的私钥，必须是8位长的字符串  
        '/ </summary> 

        Public Property PrivateKey() As String
            Get
                Return Key
            End Get
            Set(ByVal value As String)
                key = value
            End Set
        End Property

        '/ <summary> 
        '/ 对字符串进行DES加密  
        '/ </summary> 
        '/ <param name="sourceString">待加密的字符串</param> 
        '/ <returns>加密后的BASE64编码的字符串</returns> 
        Public Function Encrypt(ByVal sourceString As String) As String
            Dim btKey As Byte() = Encoding.Default.GetBytes(key)
            Dim btIV As Byte() = Encoding.Default.GetBytes(iv)
            Dim des As New DESCryptoServiceProvider()
            Dim ms As New MemoryStream()
            Try
                Dim inData As Byte() = Encoding.Default.GetBytes(sourceString)
                Try
                    Dim cs As New CryptoStream(ms, des.CreateEncryptor(btKey, btIV), CryptoStreamMode.Write)
                    Try
                        cs.Write(inData, 0, inData.Length)
                        cs.FlushFinalBlock()
                    Finally
                        cs.Dispose()
                    End Try

                    Return Convert.ToBase64String(ms.ToArray())
                Catch
                End Try
            Finally
                ms.Dispose()
            End Try
        End Function 'Encrypt  

        '/ <summary> 
        '/ 对DES加密后的字符串进行解密  
        '/ </summary> 
        '/ <param name="encryptedString">待解密的字符串</param> 
        '/ <returns>解密后的字符串</returns> 
        Public Function Decrypt(ByVal encryptedString As String) As String
            Dim btKey As Byte() = Encoding.Default.GetBytes(key)
            Dim btIV As Byte() = Encoding.Default.GetBytes(iv)
            Dim des As New DESCryptoServiceProvider()

            Dim ms As New MemoryStream()
            Try
                Dim inData As Byte() = Convert.FromBase64String(encryptedString)
                Try
                    Dim cs As New CryptoStream(ms, des.CreateDecryptor(btKey, btIV), CryptoStreamMode.Write)
                    Try
                        cs.Write(inData, 0, inData.Length)
                        cs.FlushFinalBlock()
                    Finally
                        cs.Dispose()
                    End Try

                    Return Encoding.Default.GetString(ms.ToArray())
                Catch
                End Try
            Finally
                ms.Dispose()
            End Try
        End Function 'Decrypt  

        '/ <summary> 
        '/ 对文件内容进行DES加密  
        '/ </summary> 
        '/ <param name="sourceFile">待加密的文件绝对路径</param> 
        '/ <param name="destFile">加密后的文件保存的绝对路径</param> 
        Public Overloads Sub EncryptFile(ByVal sourceFile As String, ByVal destFile As String)
            If Not File.Exists(sourceFile) Then
                Throw New FileNotFoundException("指定的文件路径不存在！", sourceFile)
            End If
            Dim btKey As Byte() = Encoding.Default.GetBytes(key)
            Dim btIV As Byte() = Encoding.Default.GetBytes(iv)
            Dim des As New DESCryptoServiceProvider()
            Dim btFile As Byte() = File.ReadAllBytes(sourceFile)

            Dim fs As New FileStream(destFile, FileMode.Create, FileAccess.Write)
            Try
                Try

                    Dim cs As New CryptoStream(fs, des.CreateEncryptor(btKey, btIV), CryptoStreamMode.Write)
                    Try
                        cs.Write(btFile, 0, btFile.Length)
                        cs.FlushFinalBlock()
                    Finally
                        cs.Dispose()
                    End Try
                Catch
                Finally
                    fs.Close()
                End Try
            Finally
                fs.Dispose()
            End Try
        End Sub 'EncryptFile  

        '/ <summary> 
        '/ 对文件内容进行DES加密，加密后覆盖掉原来的文件  
        '/ </summary> 
        '/ <param name="sourceFile">待加密的文件的绝对路径</param> 
        Public Overloads Sub EncryptFile(ByVal sourceFile As String)
            EncryptFile(sourceFile, sourceFile)
        End Sub 'EncryptFile  

        '/ <summary> 
        '/ 对文件内容进行DES解密  
        '/ </summary> 
        '/ <param name="sourceFile">待解密的文件绝对路径</param> 
        '/ <param name="destFile">解密后的文件保存的绝对路径</param> 
        Public Overloads Sub DecryptFile(ByVal sourceFile As String, ByVal destFile As String)
            If Not File.Exists(sourceFile) Then
                Throw New FileNotFoundException("指定的文件路径不存在！", sourceFile)
            End If
            Dim btKey As Byte() = Encoding.Default.GetBytes(key)
            Dim btIV As Byte() = Encoding.Default.GetBytes(iv)
            Dim des As New DESCryptoServiceProvider()
            Dim btFile As Byte() = File.ReadAllBytes(sourceFile)

            Dim fs As New FileStream(destFile, FileMode.Create, FileAccess.Write)
            Try
                Try
                    Dim cs As New CryptoStream(fs, des.CreateDecryptor(btKey, btIV), CryptoStreamMode.Write)
                    Try
                        cs.Write(btFile, 0, btFile.Length)
                        cs.FlushFinalBlock()
                    Finally
                        cs.Dispose()
                    End Try
                Catch
                Finally
                    fs.Close()
                End Try
            Finally
                fs.Dispose()
            End Try
        End Sub 'DecryptFile  

        '/ <summary> 
        '/ 对文件内容进行DES解密，加密后覆盖掉原来的文件  
        '/ </summary> 
        '/ <param name="sourceFile">待解密的文件的绝对路径</param> 
        Public Overloads Sub DecryptFile(ByVal sourceFile As String)
            DecryptFile(sourceFile, sourceFile)
        End Sub 'DecryptFile  
    End Class 'DES  
End Namespace 'ZU14 
