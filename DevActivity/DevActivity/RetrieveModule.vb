Imports MySql.Data.MySqlClient
Module RetrieveModule


    Public Function LoadItems(Active) As DataTable
        Dim ItemsDatatable As DataTable = New DataTable
        Try
            Dim GetStatus As String = ""
            If Active = "All" Then
                GetStatus = ""
            ElseIf Active = "Active" Then
                GetStatus = " WHERE active = 1"
            Else
                GetStatus = " WHERE active = 0"
            End If
            Dim Connectionlocal As MySqlConnection = LocalhostConn()
            Dim Query As String = "SELECT `items`.`code`, `items`.`description`,`items`.`price`,`items`.`group_id`,`items`.`created_date`,`items`.`active`,`items`.`id` FROM items " & GetStatus
            Dim Command As MySqlCommand = New MySqlCommand(Query, Connectionlocal)
            Dim Da As MySqlDataAdapter = New MySqlDataAdapter(Command)
            Da.Fill(ItemsDatatable)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ItemsDatatable
    End Function

    Public Function LoadGroups() As DataTable
        Dim Groups As DataTable = New DataTable
        Try
            Dim Connectionlocal As MySqlConnection = LocalhostConn()
            Dim Query As String = "SELECT * FROM itemgroup"
            Dim Command As MySqlCommand = New MySqlCommand(Query, Connectionlocal)
            Dim Da As MySqlDataAdapter = New MySqlDataAdapter(Command)
            Da.Fill(Groups)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return Groups
    End Function

    Public Function CheckGroupExist(Code) As Boolean
        Dim ReturnBool As Boolean = False
        Try
            Dim Connectionlocal As MySqlConnection = LocalhostConn()
            Dim Query As String = "SELECT code FROM itemgroup WHERE code = '" & Code & "'"
            Dim Command As MySqlCommand = New MySqlCommand(Query, Connectionlocal)
            Using reader As MySqlDataReader = Command.ExecuteReader
                If reader.HasRows Then
                    ReturnBool = True
                Else
                    ReturnBool = False
                End If
            End Using

        Catch ex As Exception

        End Try
        Return ReturnBool
    End Function

End Module
