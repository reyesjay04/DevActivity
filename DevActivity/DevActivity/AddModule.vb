Imports MySql.Data.MySqlClient
Module AddModule

    Public Sub InsertItems(Code, Desc, Price, Group)
        Try
            Dim ConnectionLocal As MySqlConnection = LocalhostConn()
            Dim Query As String = "INSERT INTO `devactivity`.`items` (`code`,`description`,`price`,`group_id`,`active`) VALUES (@1, @2, @3, @4, @5);"
            Dim Command As MySqlCommand = New MySqlCommand(Query, ConnectionLocal)
            Command.Parameters.Add("@1", MySqlDbType.Text).Value = Code
            Command.Parameters.Add("@2", MySqlDbType.Text).Value = Desc
            Command.Parameters.Add("@3", MySqlDbType.Double).Value = Price
            Command.Parameters.Add("@4", MySqlDbType.Text).Value = Group
            Command.Parameters.Add("@5", MySqlDbType.Text).Value = 1
            Command.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Public Sub InsertGroup(Code, Desc)
        Try
            Dim ConnectionLocal As MySqlConnection = LocalhostConn()
            Dim Query As String = "INSERT INTO `devactivity`.`itemgroup` (`code`,`description`) VALUES (@1, @2);"
            Dim Command As MySqlCommand = New MySqlCommand(Query, ConnectionLocal)
            Command.Parameters.Add("@1", MySqlDbType.Text).Value = Code
            Command.Parameters.Add("@2", MySqlDbType.Text).Value = Desc
            Command.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

End Module
