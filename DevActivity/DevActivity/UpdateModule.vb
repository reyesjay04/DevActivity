Imports MySql.Data.MySqlClient
Module UpdateModule

    Public Sub UpdateStatus(ID)
        Try
            Try
                Dim ConnectionLocal As MySqlConnection = LocalhostConn()
                Dim Query As String = "UPDATE `devactivity`.`items` SET `active`= @1 WHERE id = " & ID
                Dim Command As MySqlCommand = New MySqlCommand(Query, ConnectionLocal)
                Command.Parameters.Add("@1", MySqlDbType.Text).Value = 0
                Command.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub UpdateItems(ID, code, desc, price, group)
        Try
            Try
                Dim ConnectionLocal As MySqlConnection = LocalhostConn()
                Dim Query As String = "UPDATE `devactivity`.`items` SET `code`= @1,`description`= @2,`price`= @3,`group_id`= @4,`active`= @5 WHERE id = " & ID
                Console.WriteLine(Query)
                Dim Command As MySqlCommand = New MySqlCommand(Query, ConnectionLocal)
                Command.Parameters.Add("@1", MySqlDbType.Text).Value = code
                Command.Parameters.Add("@2", MySqlDbType.Text).Value = desc
                Command.Parameters.Add("@3", MySqlDbType.Double).Value = price
                Command.Parameters.Add("@4", MySqlDbType.Text).Value = group
                Command.Parameters.Add("@5", MySqlDbType.Text).Value = 1
                Command.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Public Sub UpdateGroups(ID, code, desc)
        Try
            Try
                Dim ConnectionLocal As MySqlConnection = LocalhostConn()
                Dim Query As String = "UPDATE `devactivity`.`itemgroup` SET `code`= @1,`description`= @2 WHERE id = " & ID
                Console.WriteLine(Query)
                Dim Command As MySqlCommand = New MySqlCommand(Query, ConnectionLocal)
                Command.Parameters.Add("@1", MySqlDbType.Text).Value = code
                Command.Parameters.Add("@2", MySqlDbType.Text).Value = desc
                Command.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Module
