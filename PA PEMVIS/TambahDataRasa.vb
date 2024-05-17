Imports MySql.Data.MySqlClient

Public Class TambahDataRasa
    Sub Kosong()
        txtRasa.Clear()
        idrasa.Clear()
    End Sub
    Sub tampilRasa()
        DA = New MySqlDataAdapter("select * from dbrasa", CONN)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "dbrasa")
        DataGridView1.DataSource = DS.Tables("dbrasa")
        DataGridView1.ReadOnly = True
    End Sub
    Sub aturGrid()
        DataGridView1.Columns(0).Width = 60
        DataGridView1.Columns(1).Width = 200
        DataGridView1.Columns(0).HeaderText = "Id Roti"
        DataGridView1.Columns(1).HeaderText = "Rasa"
    End Sub



    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        If txtRasa.Text = Nothing And idrasa.Text = Nothing Then
            MsgBox("Data Belum Lengkap")
            idrasa.Focus()
        Else
            CMD = New MySqlCommand("Select * from dbrasa where idrasa ='" & idrasa.Text & "'", CONN)
            RD = CMD.ExecuteReader
            RD.Read()
            If Not RD.HasRows Then
                RD.Close()
                CMD = New MySqlCommand("insert into dbrasa values('" & idrasa.Text & "', '" & txtRasa.Text & "')", CONN)
                CMD.ExecuteNonQuery()
                tampilRasa()
                Kosong()
                MsgBox("Simpan Data Sukses!")
                idrasa.Focus()
            Else
                RD.Close()
                MsgBox("Data Tersebut Sudah Ada")
            End If
        End If
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        If idrasa.Text = Nothing Then
            MsgBox("Id Roti belum diisi")
            idrasa.Focus()
        Else
            Dim ubah As String = "delete from dbrasa where idrasa = '" &
            idrasa.Text & "'"
            CMD = New MySqlCommand(ubah, CONN)
            CMD.ExecuteNonQuery()
            MsgBox("Data berhasil dihapus")
            tampilRasa()
            Kosong()
        End If
    End Sub

    Private Sub txtRasa_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRasa.KeyPress
        txtRasa.MaxLength = 50
        If e.KeyChar = Chr(13) Then
            txtRasa.Text = UCase(txtRasa.Text)
        End If
    End Sub

    Private Sub btnUbah_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If idrasa.Text = Nothing Then
            MsgBox("Id Roti belum diisi")
            idrasa.Focus()
        Else
            Dim ubah As String = "update dbrasa set rasa = '" &
            txtRasa.Text & "' where idrasa = '" & idrasa.Text & "'"
            CMD = New MySqlCommand(ubah, CONN)
            CMD.ExecuteNonQuery()
            MsgBox("Data berhasil diubah")
            tampilRasa()
            Kosong()
        End If
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Kosong()
        tampilRasa()
    End Sub

    Private Sub idrasa_KeyPress(sender As Object, e As KeyPressEventArgs) Handles idrasa.KeyPress
        idrasa.MaxLength = 2
        If e.KeyChar = Chr(13) Then
            CMD = New MySqlCommand("select * from dbrasa", CONN)
            RD = CMD.ExecuteReader()
            RD.Read()
            If RD.HasRows Then
                txtRasa.Text = RD("rasa")
                txtRasa.Focus()
            Else
                txtRasa.Focus()
            End If
        End If
    End Sub
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If txtSearch.Text <> Nothing Then
            CMD = New MySqlCommand("select * from dbrasa where rasa like '%" & txtSearch.Text & "%'", CONN)
            RD = CMD.ExecuteReader()
            If RD.HasRows Then
                Dim DS As New DataTable()
                DS.Load(RD)
                DataGridView1.DataSource = DS
                DataGridView1.Refresh()
                RD.Close()
            Else
                RD.Close()
                MessageBox.Show("Data Belum ada Tambahkan Dahulu!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            RD.Close()
        Else
            tampilRasa()
        End If
    End Sub

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DBConnect()
        tampilRasa()
        Kosong()
        aturGrid()
    End Sub

    Private Sub btnKembali_Click(sender As Object, e As EventArgs) Handles btnKembali.Click
        TambahDataRoti.Show()
        Me.Close()
    End Sub
End Class