Imports System.IO
Imports MySql.Data.MySqlClient
Public Class DisplayDataRoti
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DBConnect()
        tampilRoti()
        DataGridView1.Refresh()
        aturGrid()
    End Sub
    Sub aturGrid()
        DataGridView1.Columns(0).Width = 25
        DataGridView1.Columns(1).Width = 100
        DataGridView1.Columns(2).Width = 50
        DataGridView1.Columns(3).Width = 50
        DataGridView1.Columns(4).Width = 100
        DataGridView1.Columns(5).Width = 100
        DataGridView1.Columns(6).Width = 100
        DataGridView1.Columns(7).Width = 100

        DataGridView1.Columns(0).HeaderText = "ID Roti"
        DataGridView1.Columns(1).HeaderText = "Nama Roti"
        DataGridView1.Columns(2).HeaderText = "Harga Roti"
        DataGridView1.Columns(3).HeaderText = "Stok Roti"
        DataGridView1.Columns(4).HeaderText = "Jenis Roti"
        DataGridView1.Columns(5).HeaderText = "Tekstur Roti"
        DataGridView1.Columns(6).HeaderText = "Expired"
        DataGridView1.Columns(7).HeaderText = "Gambar"
    End Sub

    Sub tampilRoti()
        Try
            Dim CMD As New MySqlCommand("SELECT * FROM dbroti", CONN)
            Dim DataTable As New DataTable()
            DataTable.Load(CMD.ExecuteReader())
            DataGridView1.Columns.Clear()
            DataGridView1.DataSource = Nothing
            DataGridView1.DataSource = DataTable
            DataGridView1.ReadOnly = True

            If DataTable.Columns.Contains("gambar") Then
                If DataGridView1.Columns.Contains("gambar") Then
                    DataGridView1.Columns("gambar").Visible = False
                End If
                Dim imageColumn As New DataGridViewImageColumn()
                imageColumn.Name = "ImageColumn"
                imageColumn.HeaderText = "Gambar"
                imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch
                DataGridView1.Columns.Add(imageColumn)
                Dim destinationFolder As String = "Image"
                For Each row As DataGridViewRow In DataGridView1.Rows
                    Dim imageData As String = TryCast(row.Cells("gambar").Value, String)
                    If Not String.IsNullOrEmpty(imageData) Then
                        Dim imagePath As String = Path.Combine(destinationFolder, imageData)
                        If File.Exists(imagePath) Then
                            Try
                                Dim image As Image = Image.FromFile(imagePath)
                                row.Cells("ImageColumn").Value = image
                            Catch ex As Exception
                                MessageBox.Show("Gagal memuat gambar: " & ex.Message)
                            End Try
                        Else
                            MessageBox.Show("File gambar tidak ditemukan: " & imagePath)
                        End If
                    End If
                Next
            Else
                MessageBox.Show("Kolom Path Gambar tidak ada atau tipe datanya tidak sesuai")
            End If
            aturGrid()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Me.Close()
        TambahDataRoti.Show()
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        Me.Close()
        UpdateDataRoti.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtIdHapus.Text = "" Then
            MessageBox.Show("Data Belum Lengkap! Harap lengkapi data.", "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtIdHapus.Focus()
        Else
            Try
                If CONN.State = ConnectionState.Closed Then
                    CONN.Open()
                End If
                CMD = New MySqlCommand("SELECT * FROM dbroti WHERE id_roti = @id_roti", CONN)
                CMD.Parameters.AddWithValue("@id_roti", txtIdHapus.Text)
                RD = CMD.ExecuteReader()
                If RD.Read() Then
                    Dim imageData As String = RD("gambar").ToString()
                    Dim destinationFolder As String = "Image"
                    Dim imagePathToDelete As String = Path.Combine(destinationFolder, imageData)
                    RD.Close()
                    For Each row As DataGridViewRow In DataGridView1.Rows
                        If row.Cells("ImageColumn").Value IsNot Nothing Then
                            Dim image As Image = CType(row.Cells("ImageColumn").Value, Image)
                            image.Dispose()
                            row.Cells("ImageColumn").Value = Nothing
                        End If
                    Next
                    DataGridView1.Refresh()
                    If File.Exists(imagePathToDelete) Then
                        Try
                            File.Delete(imagePathToDelete)
                        Catch ex As IOException
                            MessageBox.Show("File gambar sedang digunakan oleh aplikasi lain atau tidak bisa dihapus: " & ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End Try
                    Else
                        MessageBox.Show("File gambar tidak ditemukan: " & imagePathToDelete, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                    CMD = New MySqlCommand("DELETE FROM dbroti WHERE id_roti = @id_roti", CONN)
                    CMD.Parameters.AddWithValue("@id_roti", txtIdHapus.Text)
                    CMD.ExecuteNonQuery()
                    tampilRoti()
                    MessageBox.Show("Data berhasil dihapus.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    RD.Close()
                    MessageBox.Show("Data tidak ditemukan. Silakan periksa kembali ID.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                If CONN.State = ConnectionState.Open Then
                    CONN.Close()
                End If
            End Try
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtCari.TextChanged
        Try
            If txtCari.Text <> Nothing Then
                CMD = New MySqlCommand("SELECT * FROM dbroti WHERE nama_roti LIKE '%" & txtCari.Text & "%'", CONN)
                RD = CMD.ExecuteReader()
                If RD.HasRows Then
                    Dim DS As New DataTable()
                    DS.Load(RD)

                    For Each row As DataGridViewRow In DataGridView1.Rows
                        If row.Cells("ImageColumn").Value IsNot Nothing Then
                            Dim image As Image = CType(row.Cells("ImageColumn").Value, Image)
                            image.Dispose()
                            row.Cells("ImageColumn").Value = Nothing
                        End If
                    Next
                    DataGridView1.Refresh()
                    DataGridView1.Columns.Clear()
                    DataGridView1.DataSource = Nothing
                    DataGridView1.DataSource = DS
                    DataGridView1.ReadOnly = True
                    If DS.Columns.Contains("gambar") Then
                        If DataGridView1.Columns.Contains("gambar") Then
                            DataGridView1.Columns("gambar").Visible = False
                        End If
                        Dim imageColumn As New DataGridViewImageColumn()
                        imageColumn.Name = "ImageColumn"
                        imageColumn.HeaderText = "Gambar"
                        imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch
                        DataGridView1.Columns.Add(imageColumn)
                        Dim destinationFolder As String = "Image"
                        For Each row As DataGridViewRow In DataGridView1.Rows
                            Dim imageData As String = TryCast(row.Cells("gambar").Value, String)
                            If Not String.IsNullOrEmpty(imageData) Then
                                Dim imagePath As String = Path.Combine(destinationFolder, imageData)
                                If File.Exists(imagePath) Then
                                    Try
                                        Dim image As Image = Image.FromFile(imagePath)
                                        row.Cells("ImageColumn").Value = image
                                    Catch ex As Exception
                                        MessageBox.Show("Gagal memuat gambar: " & ex.Message)
                                    End Try
                                Else
                                    MessageBox.Show("File gambar tidak ditemukan: " & imagePath)
                                End If
                            End If
                        Next
                    Else
                        MessageBox.Show("Kolom Path Gambar tidak ada atau tipe datanya tidak sesuai")
                    End If
                Else
                    MessageBox.Show("Data Belum ada Tambahkan Dahulu!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
                RD.Close()
            Else
                tampilRoti()
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub
End Class