Imports System.IO
Imports MySql.Data.MySqlClient
Public Class UpdateDataRoti
    Private ImageStatus As Boolean = False
    Private Function pilihTekstur() As String
        Dim tekstur As String = ""
        If rbLembut.Checked = True Then
            rbLembut.Text = "Lembut"
            tekstur = rbLembut.Text
        ElseIf rbKering.Checked = True Then
            rbKering.Text = "Kering"
            tekstur = rbKering.Text
        ElseIf rbChewy.Checked = True Then
            rbChewy.Text = "Chewy"
            tekstur = rbChewy.Text
        ElseIf rbRenyah.Checked = True Then
            rbRenyah.Text = "Renyah"
            tekstur = rbRenyah.Text
        End If
        Return tekstur
    End Function
    Sub tampilRasa()
        CMD = New MySqlCommand("select rasa from dbrasa", CONN)
        RD = CMD.ExecuteReader
        Do While RD.Read
            jenisRoti.Items.Add(RD.Item(0))
        Loop
        RD.Close()
    End Sub

    Sub Kosong()
        idRoti.Clear()
        namaRoti.Clear()
        hargaRoti.Clear()
        stokRoti.Value = 0
        jenisRoti.SelectedIndex = -1
        rbLembut.Checked = False
        rbKering.Checked = False
        rbChewy.Checked = False
        rbRenyah.Checked = False
        expired.Value = DateTime.Today
        PBoxRoti.Image = Nothing

        idRoti.Focus()
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DBConnect()
        Kosong()
        tampilRasa()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim imageData As String = TextBoxImagePath.Text
        Dim tekstur As String = pilihTekstur()
        If idRoti.Text = Nothing Or namaRoti.Text = Nothing Or hargaRoti.Text = Nothing Or stokRoti.Text = Nothing Or jenisRoti.Text = Nothing Or tekstur = Nothing Or expired.Text = Nothing Or PBoxRoti.Image Is Nothing Then
            MessageBox.Show("Data Belum Lengkap !, Tolong Lengkapi", "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            idRoti.Focus()
        Else
            CMD = New MySqlCommand("Select * from dbroti where id_roti ='" & idRoti.Text & "'", CONN)
            RD = CMD.ExecuteReader
            RD.Read()
            If Not RD.HasRows Then
                RD.Close()
                MessageBox.Show("Data Belum ada Tambahkan Dahulu!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Kosong()
            Else
                RD.Close()
                Dim fileName As String = namaRoti.Text & Path.GetExtension(imageData)
                Dim destinationFolder As String = "Image"
                Dim destinationPath As String = Path.Combine(destinationFolder, fileName)
                CMD = New MySqlCommand("update dbroti set nama_roti = '" & namaRoti.Text & "', harga_roti = '" & hargaRoti.Text & "', stok_roti = '" & stokRoti.Text & "', jenis_roti = '" & jenisRoti.Text & "', tekstur_roti = '" & tekstur & "', expired = '" & expired.Value.ToString("yyyy-MM-dd") & "',gambar ='" & fileName & "' where id_roti = '" & idRoti.Text & "'", CONN)
                CMD.ExecuteNonQuery()
                File.Copy(imageData, destinationPath, True)

                Kosong()
                DisplayDataRoti.Refresh()
                MessageBox.Show("Data Berhasil Disimpan !", "Success !", MessageBoxButtons.OK, MessageBoxIcon.Information)
                idRoti.Focus()
                ImageStatus = False
            End If
        End If
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Me.Hide()
        DisplayDataRoti.Show()
    End Sub
    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        Me.Hide()
        TambahDataRoti.Show()
    End Sub

    Private Sub hargaRoti_KeyPress(sender As Object, e As KeyPressEventArgs) Handles hargaRoti.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub stokRoti_KeyPress(sender As Object, e As KeyPressEventArgs) Handles stokRoti.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub idRoti_KeyPress(sender As Object, e As KeyPressEventArgs) Handles idRoti.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub idRoti_TextChanged(sender As Object, e As EventArgs) Handles idRoti.TextChanged
        If idRoti.Text <> "" Then
            CMD = New MySqlCommand("SELECT * FROM dbroti WHERE id_roti = '" & idRoti.Text & "'", CONN)
            RD = CMD.ExecuteReader()
            If RD.Read() Then
                namaRoti.Text = RD("nama_roti").ToString()
                hargaRoti.Text = RD("harga_roti").ToString()
                stokRoti.Value = Convert.ToInt32(RD("stok_roti"))
                jenisRoti.Text = RD("jenis_roti").ToString()

                Dim tekstur As String = RD("tekstur_roti").ToString()
                Select Case tekstur
                    Case "Lembut"
                        rbLembut.Checked = True
                    Case "Kering"
                        rbKering.Checked = True
                    Case "Chewy"
                        rbChewy.Checked = True
                    Case "Renyah"
                        rbRenyah.Checked = True
                End Select

                Dim imageData As String = RD("gambar").ToString()

                If Not String.IsNullOrEmpty(imageData) Then
                    Dim destinationFolder As String = "Image"
                    Dim imagePath As String = Path.Combine(destinationFolder, imageData)
                    If File.Exists(imagePath) Then
                        PBoxRoti.Image = Image.FromFile(imagePath)
                    Else
                        MessageBox.Show("File gambar tidak ditemukan: " & imagePath)
                    End If
                Else
                    MessageBox.Show("Path gambar kosong")
                End If

                expired.Value = Convert.ToDateTime(RD("expired"))
            Else
                MessageBox.Show("Data tidak ada!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                namaRoti.Clear()
                hargaRoti.Clear()
                stokRoti.Value = 0
                jenisRoti.SelectedIndex = -1
                rbLembut.Checked = False
                rbKering.Checked = False
                rbChewy.Checked = False
                rbRenyah.Checked = False
                expired.Value = DateTime.Today
                idRoti.Focus()
            End If
            RD.Close()
        Else
            Kosong()
        End If
    End Sub

    Private TextBoxImagePath As New TextBox()

    Private Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Image files (.jpg, *.jpeg, *.png, *.gif)|.jpg;.jpeg;.png;.gif|All files (.)|.*"
        openFileDialog.InitialDirectory = "../Download"
        openFileDialog.Title = "Select an image file"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Try
                Dim selectedImagePath As String = openFileDialog.FileName
                PBoxRoti.Load(selectedImagePath)
                TextBoxImagePath.Text = selectedImagePath
                ImageStatus = True
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End If
    End Sub
End Class