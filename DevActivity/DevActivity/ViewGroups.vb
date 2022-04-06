Public Class ViewGroups
    Private Sub ViewGroups_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            FillDatagridviewGroups()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub


    Public Sub FillDatagridviewGroups()
        Try
            Dim GroupsDatatable As DataTable = LoadGroups()
            DataGridView1.Rows.Clear()

            For i As Integer = 0 To GroupsDatatable.Rows.Count - 1 Step +1

                DataGridView1.Rows.Add(GroupsDatatable(i)(0), GroupsDatatable(i)(1), GroupsDatatable(i)(2))
            Next

            ToolStripStatusLabelRowCount.Text = DataGridView1.Rows.Count

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub ViewGroups_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Form1.Enabled = True
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Enabled = False
        AddGroup.Show()
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Try
            If DataGridView1.SelectedRows.Count = 1 Then
                AddGroup.GROUPSID = DataGridView1.SelectedRows(0).Cells(0).Value
                AddGroup.GROUPSCODE = DataGridView1.SelectedRows(0).Cells(1).Value
                AddGroup.GROUPSDESC = DataGridView1.SelectedRows(0).Cells(2).Value
                AddGroup.GROUPSUPDATE = True
                Enabled = False
                AddGroup.Show()
            ElseIf DataGridView1.SelectedRows.Count > 1 Then
                MsgBox("Select one item only")
            Else
                MsgBox("Select items first")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Try
            If DataGridView1.SelectedRows.Count = 1 Then
                Dim msg = MessageBox.Show("Are you sure you want to delete this group?", "NOTICE", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If msg = DialogResult.Yes Then
                    DeleteData("itemgroup", DataGridView1.SelectedRows(0).Cells(0).Value)
                    FillDatagridviewGroups()
                End If
            ElseIf DataGridView1.SelectedRows.Count > 1 Then
                MsgBox("Select one item only")
            Else
                MsgBox("Select items first")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class