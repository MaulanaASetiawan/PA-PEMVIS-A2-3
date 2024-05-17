Imports MySql.Data.MySqlClient

Public Class Form10
    Private loggedInUserId As Integer
    Public Sub New(userId As Integer)
        InitializeComponent()
        loggedInUserId = userId
    End Sub

    Sub Kosong()
        jenisRoti.Clear()
        namaRoti.Clear()
        hargaRoti.Clear()
        JmlRoti.Value = 0
        expired.Value = DateTime.Today
        namaRoti.Focus()
    End Sub

    Private Sub Form10_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CONN.Close()
    End Sub

    Private Sub btnInsert_Click_1(sender As Object, e As EventArgs) Handles btnInsert.Click
        Dim checkQuery As String = "SELECT jmlRoti, harga_roti FROM cart WHERE id_akun = @id_akun AND jenis_roti = @jenis_roti AND nama_roti = @nama_roti"
        Dim insertQuery As String = "INSERT INTO cart (id_akun, jenis_roti, nama_roti, jmlRoti, harga_roti, expired, total_harga) VALUES (@id_akun, @jenis_roti, @nama_roti, @jmlRoti, @harga_roti, @expired, @total_harga)"
        Dim updateQuery As String = "UPDATE cart SET jmlRoti = @jmlRoti, total_harga = @total_harga WHERE id_akun = @id_akun AND jenis_roti = @jenis_roti AND nama_roti = @nama_roti"

        Try
            Using CONN
                CONN.Open()
                Dim command As New MySqlCommand(checkQuery, CONN)
                command.Parameters.AddWithValue("@id_akun", loggedInUserId)
                command.Parameters.AddWithValue("@jenis_roti", jenisRoti.Text)
                command.Parameters.AddWithValue("@nama_roti", namaRoti.Text)

                Dim reader As MySqlDataReader = command.ExecuteReader()
                Dim exists As Boolean = reader.HasRows
                Dim currentQuantity As Integer = 0
                Dim currentPrice As Integer = 0

                If exists Then
                    reader.Read()
                    currentQuantity = reader.GetInt32("jmlRoti")
                    currentPrice = reader.GetInt32("harga_roti")
                End If
                reader.Close()

                Dim harga As Integer = Convert.ToInt32(hargaRoti.Text)
                Dim jumlah As Integer = Convert.ToInt32(JmlRoti.Text)
                If jumlah < 1 Then
                    MessageBox.Show("Jumlah tidak boleh 0")
                    Return
                End If
                Dim newQuantity As Integer = currentQuantity + jumlah
                Dim totalHarga As Integer = harga * newQuantity

                If exists Then
                    command = New MySqlCommand(updateQuery, CONN)
                Else
                    command = New MySqlCommand(insertQuery, CONN)
                End If

                command.Parameters.AddWithValue("@id_akun", loggedInUserId)
                command.Parameters.AddWithValue("@jenis_roti", jenisRoti.Text)
                command.Parameters.AddWithValue("@nama_roti", namaRoti.Text)
                command.Parameters.AddWithValue("@jmlRoti", newQuantity)
                command.Parameters.AddWithValue("@harga_roti", harga)
                command.Parameters.AddWithValue("@expired", expired.Value)
                command.Parameters.AddWithValue("@total_harga", totalHarga)

                command.ExecuteNonQuery()
                MessageBox.Show("Data berhasil ditambahkan.")
                Kosong()
                Me.Close()
                Dim form9 As New DisplayStore(loggedInUserId)
                form9.Show()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            If CONN.State = ConnectionState.Open Then
                CONN.Close()
            End If
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
        Dim form9 As New DisplayStore(loggedInUserId)
        form9.Show()
    End Sub
End Class