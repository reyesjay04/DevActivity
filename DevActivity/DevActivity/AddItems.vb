Public Class AddItems
    Public ITEMSID As Integer
    Public ITEMSCODE As String
    Public ITEMSDESC As String
    Public ITEMSPRICE As Double
    Public ITEMSGROUP As String
    Public ITEMSUPDATE As Boolean = False
    Private Sub AddItems_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ITEMSUPDATE = False
        Form1.Enabled = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If Not String.IsNullOrEmpty(Trim(TextBox1.Text)) Then
                If Not String.IsNullOrEmpty(Trim(TextBox2.Text)) Then
                    If Not String.IsNullOrEmpty(Trim(TextBox3.Text)) Then
                        If Not String.IsNullOrEmpty(Trim(ComboBox1.Text)) Then
                            If Button1.Text = "Save" Then
                                InsertItems(Trim(TextBox1.Text), Trim(TextBox2.Text), Trim(TextBox3.Text), ComboBox1.Text)
                            Else
                                UpdateItems(ITEMSID, Trim(TextBox1.Text), Trim(TextBox2.Text), Trim(TextBox3.Text), ComboBox1.Text)
                            End If
                            ReturnErrorMessage(True, ToolStripStatusLabel1)
                            Form1.FillDatagridviewItems("All")
                        Else
                            ReturnErrorMessage(False, ToolStripStatusLabel1)
                        End If
                    Else
                        ReturnErrorMessage(False, ToolStripStatusLabel1)
                    End If
                Else
                    ReturnErrorMessage(False, ToolStripStatusLabel1)
                End If
            Else
                ReturnErrorMessage(False, ToolStripStatusLabel1)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        Try
            Numeric(sender, e)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub AddItems_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim Groups As DataTable = LoadGroups()

            For i As Integer = 0 To Groups.Rows.Count - 1 Step +1
                ComboBox1.Items.Add(Groups(i)(1))
            Next

            If Groups.Rows.Count > 0 Then
                ComboBox1.SelectedIndex = 0
            End If

            If ITEMSUPDATE Then
                TextBox1.Text = ITEMSCODE
                TextBox2.Text = ITEMSDESC
                TextBox3.Text = ITEMSPRICE
                ComboBox1.SelectedItem = ITEMSGROUP
                Button1.Text = "Update"
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class