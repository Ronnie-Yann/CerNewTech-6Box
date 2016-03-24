Public Class Form3
    ' -----------------------------------------------XXXXXXXXXXXXXXXXX-----------------------------------------------
    '
    ' Name Custom OpenVPN Client for Windows
    ' Author Balaji
    ' Copyright © 2014 ProThemes.Biz
    '
    ' -----------------------------------------------XXXXXXXXXXXXXXXXX-----------------------------------------------
    Private Sub FlatButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatButton1.Click
        Me.Hide()
    End Sub

    Private Sub ChromeThemeContainer1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChromeThemeContainer1.Click

    End Sub

    Private Sub Form3_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Icon = Form1.Icon
    End Sub

    Public Sub New()

        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class