Imports System.IO
Imports MySql.Data.MySqlClient
Public Class TambahDataRoti
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

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DBConnect()
        Kosong()
        tampilRasa()
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim tekstur As String = pilihTekstur()
        Dim imageData As String = TextBoxImagePath.Text

        If idRoti.Text = "" Or namaRoti.Text = "" Or hargaRoti.Text = "" Or stokRoti.Text = "" Or jenisRoti.Text = "" Or tekstur = "" Or expired.Text = "" Or PBoxRoti.Image Is Nothing Then
            MessageBox.Show("Data Belum Lengkap!, Tolong Lengkapi", "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            idRoti.Focus()
        ElseIf hargaRoti.Text < 1000 Then
            MessageBox.Show("Harga Roti Minimal adalah 1000!", "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            hargaRoti.Focus()
        ElseIf stokRoti.Value < 1 Then
            MessageBox.Show("Stok tidak boleh 0!", "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            stokRoti.Focus()
        Else
            CMD = New MySqlCommand("Select * from dbroti where id_roti ='" & idRoti.Text & "'", CONN)
            RD = CMD.ExecuteReader
            RD.Read()

            If Not RD.HasRows Then
                RD.Close()

                Dim fileName As String = namaRoti.Text & Path.GetExtension(imageData)
                Dim destinationFolder As String = "Image"
                Dim destinationPath As String = Path.Combine(destinationFolder, fileName)
                CMD = New MySqlCommand("insert into dbroti values('" & idRoti.Text & "', '" & namaRoti.Text & "','" & hargaRoti.Text & "', '" & stokRoti.Text & "', '" & jenisRoti.Text & "', '" & tekstur & "', '" & expired.Value.ToString("yyyy-MM-dd") & "', '" & fileName & "')", CONN)
                CMD.ExecuteNonQuery()
                File.Copy(imageData, destinationPath, True)

                Kosong()
                MessageBox.Show("Data Berhasil Disimpan !", "Success !", MessageBoxButtons.OK, MessageBoxIcon.Information)
                idRoti.Focus()
                ImageStatus = False
            Else
                RD.Close()
                MessageBox.Show("Data Sudah Ada!, Tolong Ganti!", "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Me.Close()
        DisplayDataRoti.Show()
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        Me.Close()
        UpdateDataRoti.Show()
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

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        TambahDataRasa.Show()
        Me.Close()
    End Sub

    Private TextBoxImagePath As New TextBox()
    Private Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png, *.gif)|*.jpg;*.jpeg;*.png;*.gif|All files (*.*)|*.*"
        openFileDialog.InitialDirectory = "../Download"
        openFileDialog.Title = "Select an image file"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Try
                Dim selectedImagePath As String = openFileDialog.FileName
                PBoxRoti.Image = Image.FromFile(selectedImagePath)
                TextBoxImagePath.Text = selectedImagePath
                ImageStatus = True
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub btnlogout_Click(sender As Object, e As EventArgs) Handles btnlogout.Click
        Dim confirmation As DialogResult = MessageBox.Show("Apakah Anda yakin ingin keluar dari akun?", "Konfirmasi Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirmation = DialogResult.Yes Then
            Me.Close()
            Login.Show()
            Login.Kosong()
        End If
    End Sub
End Class