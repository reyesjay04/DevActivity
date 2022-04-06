Imports System.Drawing.Printing

Module Functions
    Public Sub Numeric(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        If e.KeyChar <> ControlChars.Back Then
            e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".")
        End If
    End Sub
    Public Sub ReturnErrorMessage(Success As Boolean, ToolStripStatusText As ToolStripStatusLabel)
        Try
            If Success Then
                ToolStripStatusText.ForeColor = Color.Green
                ToolStripStatusText.Text = "Success"
            Else
                ToolStripStatusText.ForeColor = Color.Red
                ToolStripStatusText.Text = "All fields are required"
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub SimpleTextDisplay(sender As Object, e As PrintPageEventArgs, myText As String, myFont As Font, ShopX As Integer, ShopY As Integer)
        Dim shopnameX As Integer = 10, shopnameY As Integer = 20
        e.Graphics.DrawString(myText, myFont, Brushes.Black, New PointF(shopnameX + ShopX, shopnameY + ShopY))
    End Sub
End Module
