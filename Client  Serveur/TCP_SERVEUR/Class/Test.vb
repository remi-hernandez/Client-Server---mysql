Imports System.Data.Odbc
Imports System.Data.Sql
Imports System.Data.SqlClient

Imports MySql.Data
Imports MySql.Data.MySqlClient


Public Class Test
    Public Sub Connexion()
        Dim connStr As String = "SERVER=localhost;DATABASE=GestionDuPersonnel;UID=test;PASSWORD=test"
        Dim connection As New MySqlConnection(connStr)
        connection.Open()
    End Sub
End Class
