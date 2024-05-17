Imports MySql.Data.MySqlClient

Public Class Login

    Public loggedInUserId As Integer

    Sub Kosong()
        txtUsername.Clear()
        txtPassword.Clear()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtUsername.Text = "admin" AndAlso txtPassword.Text = "admin" Then
            MessageBox.Show("Welcome, Admin!", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Hide()
            TambahDataRoti.Show()
        Else
            Try
                If CONN.State = ConnectionState.Closed Then
                    CONN.Open()
                End If

                Dim query As String = "SELECT * FROM akun WHERE username = '" & txtUsername.Text & "' AND password = '" & txtPassword.Text & "'"
                CMD = New MySqlCommand(query, CONN)
                RD = CMD.ExecuteReader()

                If RD.Read() Then
                    loggedInUserId = RD("id")
                    Dim welcomeMessage As String = "Welcome, " & txtUsername.Text & " !"
                    MessageBox.Show(welcomeMessage, "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Kosong()
                    Dim form9 As New DisplayStore(loggedInUserId)
                    form9.Show()
                    Me.Hide()
                Else
                    MessageBox.Show("Username atau Password Salah !", "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Kosong()
                    txtUsername.Focus()
                End If

            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            Finally
                If CONN.State = ConnectionState.Open Then
                    CONN.Close()
                End If
            End Try
        End If
    End Sub


    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Kosong()
        DBConnect()
        CONN.Close()
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Dim Register As New Register()
        Register.Show()
        Me.Hide()
    End Sub
End Class