Imports System
Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports MySql.Data.Types


Public Class BDD
   
    Private _connexionParams As String = "SERVER=localhost;DATABASE=gestiondupersonnel;UID=root;PWD=root;"
    Private _connexion As New MySqlConnection(_connexionParams)
    Private _requete As New MySqlCommand
    Private _donnee As MySqlDataReader

    ''Getters - Setters

    Public ReadOnly Property connexionParams() As String
        Get
            Return _connexionParams
        End Get
    End Property

    ''Methodes

    Public Sub Connexion()
        Try
            _connexion.Open()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub Deconnexion()
        Try
            _connexion.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Public Sub EnvoiRequetes(ByVal requete As String)
        Try
            _requete.Connection = _connexion
            _requete.CommandType = CommandType.Text
            _requete.CommandText = requete
            _donnee = _requete.ExecuteReader
            While _donnee.Read()
                MessageBox.Show(_donnee.GetValue(0))
            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
