Imports MySql.Data.MySqlClient

Public Class Register
    Private Sub btnRegis_Click(sender As Object, e As EventArgs) Handles btnRegis.Click
        If txtUsername.Text = "" Then
            MessageBox.Show("Username belum diisi!", "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUsername.Focus()
        ElseIf txtPassword.Text = "" Then
            MessageBox.Show("Password belum diisi!", "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPassword.Focus()
        ElseIf txtKonfirmasi.Text = "" Then
            MessageBox.Show("Konfirmasi Password belum diisi!", "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtKonfirmasi.Focus()
        ElseIf txtPassword.Text <> txtKonfirmasi.Text Then
            MessageBox.Show("Konfirmasi Password tidak cocok dengan Password!", "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtKonfirmasi.Focus()
        Else
            Try
                If CONN.State = ConnectionState.Closed Then
                    CONN.Open()
                End If

                CMD = New MySqlCommand("SELECT * FROM akun WHERE username = '" & txtUsername.Text & "'", CONN)
                RD = CMD.ExecuteReader()

                If Not RD.HasRows Then
                    RD.Close()
                    CMD = New MySqlCommand("INSERT INTO akun (username, password) VALUES ('" & txtUsername.Text & "', '" & txtPassword.Text & "')", CONN)
                    CMD.ExecuteNonQuery()
                    MsgBox("Simpan Data Sukses!")
                    txtUsername.Focus()
                    Login.Show()
                    Login.Kosong()
                    Me.Close()
                Else
                    RD.Close()
                    MsgBox("Username sudah terdaftar!")
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

    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DBConnect()
    End Sub

    Private Sub lblLogin_Click(sender As Object, e As EventArgs) Handles lblLogin.Click
        Login.Show()
        Login.Kosong()
        Me.Close()
    End Sub
End Class