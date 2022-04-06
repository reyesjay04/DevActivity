Imports System.Drawing.Printing
Imports MySql.Data.MySqlClient
Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ToolStripComboBox1.SelectedIndex = 0

            FillDatagridviewItems(ToolStripComboBox1.Text)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Public Sub FillDatagridviewItems(Active)
        Try
            Dim ItemsDatatable As DataTable = LoadItems(Active)
            DataGridView1.Rows.Clear()

            For i As Integer = 0 To ItemsDatatable.Rows.Count - 1 Step +1
                Dim RowActive As String = ""
                If ItemsDatatable(i)(5) Then
                    RowActive = "Yes"
                Else
                    RowActive = "No"
                End If
                DataGridView1.Rows.Add(ItemsDatatable(i)(0), ItemsDatatable(i)(1), ItemsDatatable(i)(2), ItemsDatatable(i)(3), ItemsDatatable(i)(4), RowActive, ItemsDatatable(i)(6))
            Next

            ToolStripStatusLabelRowCount.Text = DataGridView1.Rows.Count

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Enabled = False
        AddItems.Show()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Enabled = False
        'AddGroup.Show()
        ViewGroups.Show()
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Try
            If DataGridView1.SelectedRows.Count = 1 Then
                AddItems.ITEMSID = DataGridView1.SelectedRows(0).Cells(6).Value
                AddItems.ITEMSCODE = DataGridView1.SelectedRows(0).Cells(0).Value
                AddItems.ITEMSDESC = DataGridView1.SelectedRows(0).Cells(1).Value
                AddItems.ITEMSPRICE = DataGridView1.SelectedRows(0).Cells(2).Value
                AddItems.ITEMSGROUP = DataGridView1.SelectedRows(0).Cells(3).Value
                AddItems.ITEMSUPDATE = True
                Enabled = False
                AddItems.Show()
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
                Dim msg = MessageBox.Show("Are you sure you want to delete this item?", "NOTICE", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If msg = DialogResult.Yes Then
                    UpdateStatus(DataGridView1.SelectedRows(0).Cells(6).Value)
                    FillDatagridviewItems(ToolStripComboBox1.Text)
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
    Private WithEvents printdoc As PrintDocument = New PrintDocument
    Private PrintPreviewDialog1 As New PrintPreviewDialog

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click

        Try


            printdoc.DefaultPageSettings.PaperSize = New PaperSize("Custom", 200, 500)
            PrintPreviewDialog1.Document = printdoc
            PrintPreviewDialog1.ShowDialog()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub pdoc_PrintPage(sender As Object, e As PrintPageEventArgs) Handles printdoc.PrintPage
        Try
            Dim PrintLineCount As Integer = 10
            Dim FontDefault As New Font("Tahoma", 5)


            Dim GroupDT As DataTable = LoadGroups()

            For i As Integer = 0 To GroupDT.Rows.Count - 1 Step +1
                Dim GroupCategory = GroupDT(i)(1)
                SimpleTextDisplay(sender, e, GroupCategory, FontDefault, 0, PrintLineCount)
                PrintLineCount += 10

                For a As Integer = 0 To DataGridView1.Rows.Count - 1 Step +1
                    If GroupCategory = DataGridView1.Rows(a).Cells(3).Value.ToString Then
                        SimpleTextDisplay(sender, e, "    - " & DataGridView1.Rows(a).Cells(1).Value, FontDefault, 0, PrintLineCount)
                        PrintLineCount += 10
                    End If
                Next
                PrintLineCount += 10
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub ToolStripComboBox1_TextChanged(sender As Object, e As EventArgs) Handles ToolStripComboBox1.TextChanged
        Try
            FillDatagridviewItems(ToolStripComboBox1.Text)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class
