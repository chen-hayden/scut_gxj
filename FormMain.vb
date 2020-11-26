'Programmer:hzz 
'Last Modified : 2020.11.26
'Project:scut_gxj


Imports System.IO.Ports
Imports System
Imports System.Text
Imports System.Threading
Imports MaterialSkin

Public Class MainWindow
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim SkinManager As MaterialSkinManager = MaterialSkinManager.Instance
        SkinManager.AddFormToManage(Me)
        SkinManager.Theme = MaterialSkinManager.Themes.LIGHT
        SkinManager.ColorScheme = New ColorScheme(Primary.LightBlue800, Primary.LightBlue500, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim f2 As New Settings
        f2.Show()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim f1 As New SaveFileDialog
        f1.ShowDialog()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim f4 As New Ensure
        f4.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim f5 As New Analysis
        f5.Show()
    End Sub

    Public Sub Sp_Receiving(ByVal sender As Object, ByVal e As EventArgs) '接受函数响应逻辑
        Dim strIncoming As String '读取字符串 定义下位机ID 变量 以及比特数组
        Dim operation As String
        Dim num As String
        Dim i As Integer = 0
        Try '读取数值
            If Sp1.BytesToRead > 0 Then
                num = Sp1.BytesToRead
                strIncoming = Sp1.ReadExisting.ToString
                TextBox8.Text = strIncoming
                operation = Mid(strIncoming, 5, 2) '获取状态的值 
            End If
            ' Select Case CInt(operation) '根据数值记性响应逻辑 进行处理
            '  Case 1
            '         '相关操作
            ' Case 2
            '相关操作
            '  End Select
            Sp1.DiscardInBuffer()
        Catch ex As Exception
            MessageBox.Show(ex.Message) '把其他的情况进行抛出
        End Try
    End Sub


    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        SwitchCommand("COM3", TextBox7.Text)

    End Sub

    Private Sub Sp1_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles Sp1.DataReceived
        Me.BeginInvoke(New EventHandler(AddressOf Sp_Receiving))
    End Sub

End Class
