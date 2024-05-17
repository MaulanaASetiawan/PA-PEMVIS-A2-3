Imports MySql.Data.MySqlClient
Imports System.Drawing.Printing

Public Class Checkout

    Private loggedInUserId As Integer

    Public Sub New(userId As Integer)
        InitializeComponent()
        loggedInUserId = userId
    End Sub

    Private Sub Checkout_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCartData()
        AddCheckBoxColumn()
        SetColumnHeaders()
    End Sub

    Private Sub LoadCartData()
        Try
            Using CONN
                CONN.Open()
                Dim query As String = "SELECT jenis_roti, nama_roti, jmlRoti, harga_roti, expired, total_harga FROM cart WHERE id_akun = @id_akun"
                Using command As New MySqlCommand(query, CONN)
                    command.Parameters.AddWithValue("@id_akun", loggedInUserId)
                    Using reader As MySqlDataReader = command.ExecuteReader()
                        Dim dt As New DataTable()
                        dt.Load(reader)
                        DataGridView1.DataSource = dt
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            If CONN.State = ConnectionState.Open Then
                CONN.Close()
            End If
        End Try
    End Sub

    Private Sub AddCheckBoxColumn()
        Dim checkBoxColumn As New DataGridViewCheckBoxColumn()
        checkBoxColumn.HeaderText = "Select"
        checkBoxColumn.Name = "CheckBoxColumn"
        checkBoxColumn.Width = 50
        DataGridView1.Columns.Insert(0, checkBoxColumn)
    End Sub

    Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        If e.ColumnIndex = 0 Then
            CalculateTotal()
        End If
    End Sub

    Private Sub DataGridView1_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DataGridView1.CurrentCellDirtyStateChanged
        If DataGridView1.IsCurrentCellDirty Then
            DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub SetColumnHeaders()
        DataGridView1.Columns(0).HeaderText = "Select"
        DataGridView1.Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.Columns(1).HeaderText = "Jenis Roti"
        DataGridView1.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.Columns(2).HeaderText = "Nama Roti"
        DataGridView1.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.Columns(3).HeaderText = "Jumlah Roti"
        DataGridView1.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.Columns(4).HeaderText = "Harga Roti"
        DataGridView1.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.Columns(5).HeaderText = "Expired"
        DataGridView1.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.Columns(6).HeaderText = "Total Harga"
        DataGridView1.Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub

    Private Sub CalculateTotal()
        Dim total As Decimal = 0
        For Each row As DataGridViewRow In DataGridView1.Rows
            If Convert.ToBoolean(row.Cells(0).Value) Then
                total += Convert.ToDecimal(row.Cells("total_harga").Value)
            End If
        Next
        TextBoxTotal.Text = total.ToString("C")
    End Sub

    Class Transaksi
        Public banyakItem As Integer
        Public namaItem As String
        Public hargaItem As Integer
        Public total As Integer

        Public Sub New(ByVal banyakItem As Integer, ByVal namaItem As String, ByVal hargaItem As Integer, ByVal total As Integer)
            Me.banyakItem = banyakItem
            Me.namaItem = namaItem
            Me.hargaItem = hargaItem
            Me.total = total
        End Sub
    End Class

    Dim listTransaksi As New List(Of Transaksi)
    Dim gTotal As Integer

    Private Sub ButtonCheckout_Click(sender As Object, e As EventArgs) Handles ButtonCheckout.Click
        Dim selectedRows As New List(Of DataGridViewRow)()
        For Each row As DataGridViewRow In DataGridView1.Rows
            If Convert.ToBoolean(row.Cells(0).Value) Then
                selectedRows.Add(row)
            End If
        Next
        If selectedRows.Count = 0 Then
            MessageBox.Show("No items selected for checkout.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Try
            If CONN.State = ConnectionState.Closed Then
                CONN.Open()
            End If
            Dim buyerName As String = ""
            CMD = New MySqlCommand("SELECT username FROM akun WHERE id = @id_akun", CONN)
            CMD.Parameters.AddWithValue("@id_akun", loggedInUserId)
            Dim reader As MySqlDataReader = CMD.ExecuteReader()

            If reader.Read() Then
                buyerName = reader("username").ToString()
            End If
            reader.Close()


            Dim grandTotal As Decimal = 0
            For Each row As DataGridViewRow In selectedRows
                Dim selectedNama As String = row.Cells("nama_roti").Value.ToString()
                Dim quantity As Integer = Convert.ToInt32(row.Cells("jmlRoti").Value)
                Dim availableStock As Integer

                CMD = New MySqlCommand("SELECT stok_roti FROM dbroti WHERE nama_roti = @nama_roti", CONN)
                CMD.Parameters.AddWithValue("@nama_roti", selectedNama)
                reader = CMD.ExecuteReader()

                If reader.Read() Then
                    availableStock = Convert.ToInt32(reader("stok_roti"))
                    If quantity > availableStock Then
                        MessageBox.Show("Stok roti tidak mencukupi untuk " & selectedNama & "!", "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        reader.Close()
                        Return
                    End If
                Else
                    MessageBox.Show("Roti " & selectedNama & " tidak ditemukan!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    reader.Close()
                    Return
                End If
                reader.Close()

                CMD = New MySqlCommand("UPDATE dbroti SET stok_roti = stok_roti - @quantity WHERE nama_roti = @nama_roti", CONN)
                CMD.Parameters.AddWithValue("@quantity", quantity)
                CMD.Parameters.AddWithValue("@nama_roti", selectedNama)
                CMD.ExecuteNonQuery()
                CMD = New MySqlCommand("DELETE FROM dbroti WHERE stok_roti <= 0", CONN)
                CMD.ExecuteNonQuery()

                Dim transactionId As Integer
                CMD = New MySqlCommand("INSERT INTO transaksi (id_akun, nama_pembeli, tanggal_transaksi, nama_roti, jumlah, harga_satuan, total_harga) VALUES (@id_akun, @nama_pembeli, @tanggal_transaksi, @nama_roti, @jumlah, @harga_satuan, @total_harga)", CONN)
                CMD.Parameters.AddWithValue("@id_akun", loggedInUserId)
                CMD.Parameters.AddWithValue("@nama_pembeli", buyerName)
                CMD.Parameters.AddWithValue("@tanggal_transaksi", DateTime.Now)
                CMD.Parameters.AddWithValue("@nama_roti", selectedNama)
                CMD.Parameters.AddWithValue("@jumlah", quantity)
                CMD.Parameters.AddWithValue("@harga_satuan", Convert.ToDecimal(row.Cells("harga_roti").Value))
                CMD.Parameters.AddWithValue("@total_harga", Convert.ToDecimal(row.Cells("total_harga").Value))
                CMD.ExecuteNonQuery()

                transactionId = CMD.LastInsertedId

                listTransaksi.Add(New Transaksi(quantity, selectedNama, row.Cells("harga_roti").Value, row.Cells("total_harga").Value))

                grandTotal += Convert.ToDecimal(row.Cells("total_harga").Value)
            Next

            gTotal = grandTotal

            For Each row As DataGridViewRow In selectedRows
                Dim selectedNama As String = row.Cells("nama_roti").Value.ToString()
                CMD = New MySqlCommand("DELETE FROM cart WHERE id_akun = @id_akun AND nama_roti = @nama_roti", CONN)
                CMD.Parameters.AddWithValue("@id_akun", loggedInUserId)
                CMD.Parameters.AddWithValue("@nama_roti", selectedNama)
                CMD.ExecuteNonQuery()
                DataGridView1.Rows.Remove(row)
            Next
            TextBoxTotal.Text = 0

            PrintPreviewDialog1.Document = PrintDocument1
            PrintPreviewDialog1.ShowDialog()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            If CONN.State = ConnectionState.Open Then
                CONN.Close()
            End If
        End Try
    End Sub

    Private Sub PrintDocument1_BeginPrint(sender As Object, e As PrintEventArgs) Handles PrintDocument1.BeginPrint
        Dim margins As New Margins(10, 10, 10, 10)
        PrintDocument1.DefaultPageSettings.Margins = margins
        PrintDocument1.PrinterSettings.DefaultPageSettings.Margins = margins

        Dim pagesetup As New PageSettings
        pagesetup.PaperSize = New PaperSize("Custom", 250, 500)
        PrintDocument1.DefaultPageSettings = pagesetup

    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim f8 As New Font("Calibri", 8, FontStyle.Regular)
        Dim f10 As New Font("Calibri", 10, FontStyle.Regular)
        Dim f10b As New Font("Calibri", 10, FontStyle.Bold)
        Dim f14 As New Font("Calibri", 14, FontStyle.Bold)

        Dim leftmargin As Integer = PrintDocument1.DefaultPageSettings.Margins.Left
        Dim centermargin As Integer = PrintDocument1.DefaultPageSettings.PaperSize.Width / 2
        Dim rightmargin As Integer = PrintDocument1.DefaultPageSettings.PaperSize.Width

        Dim right As New StringFormat
        Dim center As New StringFormat

        right.Alignment = StringAlignment.Far
        center.Alignment = StringAlignment.Center

        Dim line As String
        line = ""

        e.Graphics.DrawString("Tinkery Bakery", f10, Brushes.Black, centermargin, 40, center)
        e.Graphics.DrawString("085171231400", f10, Brushes.Black, centermargin, 55, center)

        e.Graphics.DrawString("Tanggal", f8, Brushes.Black, 0, 75)
        e.Graphics.DrawString(":", f8, Brushes.Black, 50, 75)
        e.Graphics.DrawString(Date.Now.ToString, f8, Brushes.Black, 70, 75)

        e.Graphics.DrawString("Cashier", f8, Brushes.Black, 0, 85)
        e.Graphics.DrawString(":", f8, Brushes.Black, 50, 85)
        e.Graphics.DrawString("Ridwan", f8, Brushes.Black, 70, 85)

        e.Graphics.DrawString("Qty", f8, Brushes.Black, 0, 110)
        e.Graphics.DrawString("Item", f8, Brushes.Black, 25, 110)
        e.Graphics.DrawString("Price", f8, Brushes.Black, 180, 110, right)
        e.Graphics.DrawString("Total", f8, Brushes.Black, rightmargin, 110, right)
        e.Graphics.DrawString(line, f8, Brushes.Black, 0, 120)

        Dim height As Integer = 0
        For Each item As Transaksi In listTransaksi
            e.Graphics.DrawString(item.banyakItem, f8, Brushes.Black, 0, 120 + height)
            e.Graphics.DrawString(item.namaItem, f8, Brushes.Black, 25, 120 + height)
            e.Graphics.DrawString(item.hargaItem, f8, Brushes.Black, 180, 120 + height, right)
            e.Graphics.DrawString(item.total, f8, Brushes.Black, rightmargin, 120 + height, right)

            height += 15
        Next
        e.Graphics.DrawString("Grand Total", f8, Brushes.Black, 180, height + 125, right)
        e.Graphics.DrawString(gTotal, f8, Brushes.Black, rightmargin, height + 125, right)

    End Sub

    Private Sub InitializePrintDocument()
        AddHandler PrintDocument1.BeginPrint, AddressOf PrintDocument1_BeginPrint
        AddHandler PrintDocument1.PrintPage, AddressOf PrintDocument1_PrintPage
    End Sub


    Private Sub ButtonRemove_Click(sender As Object, e As EventArgs) Handles ButtonRemove.Click
        Dim selectedRows As New List(Of DataGridViewRow)()
        For Each row As DataGridViewRow In DataGridView1.Rows
            If Convert.ToBoolean(row.Cells(0).Value) Then
                selectedRows.Add(row)
            End If
        Next
        If selectedRows.Count = 0 Then
            MessageBox.Show("No items selected for removal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Try
            If CONN.State = ConnectionState.Closed Then
                CONN.Open()
            End If
            For Each row As DataGridViewRow In selectedRows
                Dim selectedNama As String = row.Cells("nama_roti").Value.ToString()
                CMD = New MySqlCommand("DELETE FROM cart WHERE id_akun = @id_akun AND nama_roti = @nama_roti", CONN)
                CMD.Parameters.AddWithValue("@id_akun", loggedInUserId)
                CMD.Parameters.AddWithValue("@nama_roti", selectedNama)
                CMD.ExecuteNonQuery()
                DataGridView1.Rows.Remove(row)
            Next
            TextBoxTotal.Text = 0
            MessageBox.Show("Selected items removed successfully.")
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            If CONN.State = ConnectionState.Open Then
                CONN.Close()
            End If
        End Try
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Close()
        Dim form9 As New DisplayStore(loggedInUserId)
        form9.Show()
    End Sub

End Class





