'This is the setting page source code.
Imports System.Runtime.InteropServices

Public Class Settings
    Private Sub MaterialFlatButton1_Click(sender As Object, e As EventArgs) Handles MaterialFlatButton1.Click
        Me.Close()                                                       'cancel键自动关闭窗口
    End Sub

    Public Structure frequency_base
        Shared Start_var As Double
        Shared Stop_var As Double
        Shared point_var As Double

    End Structure

    Public Sub MaterialFlatButton3_Click(sender As Object, e As EventArgs) Handles MaterialFlatButton3.Click
        If (TextBox4.Text <> "" And TextBox6.Text <> "" And TextBox7.Text <> "") Then
            frequency_base.Start_var = TextBox4.Text
            frequency_base.Stop_var = TextBox6.Text
            frequency_base.point_var = TextBox7.Text
            Dim checker As Integer
            Dim frenquencylist As String
            Dim stp As Double
            Dim fre_rst As String
            checker = Fix(frequency_base.point_var)

            If _
                (frequency_base.Start_var > frequency_base.Stop_var Or frequency_base.Start_var <= 0 Or
                 frequency_base.Stop_var <= 0 Or frequency_base.point_var <= 0 Or frequency_base.point_var <> checker) _
                Then
                Formwrong.Show()
            Else
                While (frequency_base.point_var > 0)
                    stp = (frequency_base.Stop_var - frequency_base.Start_var) / (frequency_base.point_var - 1)
                    fre_rst = CStr(frequency_base.Start_var)
                    frenquencylist += (fre_rst + vbNewLine)
                    frequency_base.Start_var += stp
                    frequency_base.point_var -= 1
                End While
            End If
            TextBox3.Text = frenquencylist
        Else
            Formwrong.Show()
        End If
    End Sub

End Class