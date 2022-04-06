Imports MySql.Data.MySqlClient

Module Connection

    Public Function LocalhostConn() As MySqlConnection
        Dim Connectionstring As String = "server=localhost;user id=root;password=;database=devactivity;port=3306;"
        Dim ConnectionLocal As MySqlConnection = New MySqlConnection

        Try
            ConnectionLocal.ConnectionString = Connectionstring
            ConnectionLocal.Open()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ConnectionLocal

    End Function

End Module
