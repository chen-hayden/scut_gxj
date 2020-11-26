Imports System.IO.Ports
Imports System.Text

Module Function1

    Public hexByte() As Byte
    Public Sub SwitchCommand(ComName As String, Command As String)
        Try
            DataConvert(Command)
        Catch ex As Exception
            MessageBox.Show("Can not convert data")
        End Try

        Try
            Try
                Serial_Portpara1(ComName)
            Catch ex As Exception

            End Try

            If MainWindow.Sp1.IsOpen = False Then
                MainWindow.Sp1.Open()
            End If
            MainWindow.Sp1.Write(hexByte, 0, hexByte.Length)
            MainWindow.Sp1.WriteLine(Environment.NewLine)

        Catch ex As Exception
            MessageBox.Show("Can not write data")
        End Try
    End Sub
    Public Sub DataConvert(str As String)
        Dim ArrGet() As String = Split(str, " ")
        ReDim hexByte(ArrGet.Length - 1)
        Dim i As Integer
        For i = 0 To ArrGet.Length - 1
            hexByte(i) = Val("&h" & ArrGet(i))
        Next
        i = 1
    End Sub
    Public Sub Serial_Portpara1(PortName As String) '设置串口参数 配置文本文件
        MainWindow.Sp1.PortName = PortName '串口名称
        MainWindow.Sp1.DataBits = 8     '数据位
        MainWindow.Sp1.StopBits = StopBits.One  '停止位
        MainWindow.Sp1.BaudRate = 115200  '波特率
        MainWindow.Sp1.DtrEnable = False '是否启用终端就绪信号
        MainWindow.Sp1.RtsEnable = False '是否启用请求发送信号
        MainWindow.Sp1.ReadTimeout = 500   '超时时间
        MainWindow.Sp1.Encoding = Encoding.Default
    End Sub
End Module
