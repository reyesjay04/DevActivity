Imports MySql.Data.MySqlClient
Module DeleteModule

    Public Sub DeleteData(Table, ID)
        Try
            Try
                Dim ConnectionLocal As MySqlConnection = LocalhostConn()
                Dim Query As String = "DELETE FROM " & Table & " WHERE id = " & ID
                Dim Command As MySqlCommand = New MySqlCommand(Query, ConnectionLocal)
                Command.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Module
