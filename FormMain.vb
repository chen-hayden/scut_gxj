'Programmer:hzz 
'Last Modified : 2020.11.23
'Project:scut_gxj


Imports System.IO.Ports
Imports System
Imports System.Text
Imports System.Threading
Imports MaterialSkin

Public Class MainWindow
    Public WithEvents Sp1 As New SerialPort '串口操作对象
    Public WithEvents Sp2 As New SerialPort
    Public Property COM1 As String
    Public Property COM2 As String
    Private sendvalue As Object

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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim f5 As New Analysis
        f5.Show()
    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged

    End Sub



    Public Function DataConvert()
        Dim ArrGet() As String = Split(TextBox7.Text)
        Dim hexByte() As Byte
        ReDim hexByte(ArrGet.Length - 1)
        Dim i As Integer
        For i = 0 To ArrGet.Length - 1
            hexByte(i) = Val("&h" & ArrGet(i))
        Next
        Sp1.Write(hexByte, 0, hexByte.Length)
    End Function

    Public Sub Serial_Portpara1() '设置串口参数 配置文本文件
        Sp1.BaudRate =  '波特率
        Sp1.PortName = COM1   '串口名称
        Sp1.DataBits = 8     '数据位
        Sp1.StopBits = StopBits.One  '停止位
        Sp1.Parity =    '校验位
        Sp1.DtrEnable = True '是否启用终端就绪信号
        Sp1.RtsEnable = True '是否启用请求发送信号
        Sp1.ReadTimeout = 500   '超时时间
        Sp1.NewLine = vbCrLf       '行结束符合
    End Sub

    Public Sub Link()      '连接函数
        Serial_Portpara1()
        Try
            Sp1.Open() '打开串口
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub Dislink() '断开函数
        Try
            Sp1.Close() '关闭串口
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub Sp_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles Sp1.DataReceived '接受函数
        Me.BeginInvoke(New EventHandler(AddressOf Sp_Receiving)) '调用接收数据函数
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
                operation = Mid(strIncoming, 5, 2) '获取状态的值 
            End If
            Select Case CInt(operation) '根据数值记性响应逻辑 进行处理
                Case 1
                    '相关操作
                Case 2
                    '相关操作
            End Select
            Sp1.DiscardInBuffer()
        Catch ex As Exception
            MessageBox.Show(ex.Message) '把其他的情况进行抛出
        End Try
    End Sub
    Public Sub Sp_Send(ByVal sendvalue As String)
        Try
            Sp1.Write(sendvalue, 0, sendvalue.Length)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If Sp1.IsOpen = True Then

        Else
            Sp1.Open()
        End If
        '  DataConvert()
        Sp_Send(TextBox7.Text)

    End Sub
End Class
