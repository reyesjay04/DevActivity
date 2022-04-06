Public Class AddGroup

    Public GROUPSCODE As String
    Public GROUPSDESC As String
    Public GROUPSUPDATE As Boolean = False
    Public GROUPSID As Integer
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If CheckGroupExist(TextBox1.Text) Then
                ToolStripStatusLabel1.ForeColor = Color.Red
                ToolStripStatusLabel1.Text = "Code already exist!"
                Exit Sub
            End If

            If Not String.IsNullOrEmpty(Trim(TextBox1.Text)) Then
                If Not String.IsNullOrEmpty(Trim(TextBox2.Text)) Then
                    If Button1.Text = "Save" Then
                        InsertGroup(Trim(TextBox1.Text), Trim(TextBox2.Text))
                    Else
                        UpdateGroups(GROUPSID, Trim(TextBox1.Text), Trim(TextBox2.Text))
                    End If
                    ToolStripStatusLabel1.ForeColor = Color.Green
                    ToolStripStatusLabel1.Text = "Success!"
                    ViewGroups.FillDatagridviewGroups()
                Else
                    ToolStripStatusLabel1.ForeColor = Color.Red
                    ToolStripStatusLabel1.Text = "All fields are required"
                End If
            Else
                ToolStripStatusLabel1.ForeColor = Color.Red
                ToolStripStatusLabel1.Text = "All fields are required"
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub AddGroup_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        GROUPSUPDATE = False
        ViewGroups.Enabled = True
    End Sub

    Private Sub AddGroup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If GROUPSUPDATE Then
            Button1.Text = "Update"
            TextBox1.Text = GROUPSCODE
            TextBox2.Text = GROUPSDESC
        End If
    End Sub
End Class