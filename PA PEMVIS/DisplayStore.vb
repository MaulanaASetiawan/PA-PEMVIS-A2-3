Imports MySql.Data.MySqlClient
Imports System.IO

Public Class DisplayStore
    Private loggedInUserId As Integer

    Public Sub New(userId As Integer)
        InitializeComponent()
        loggedInUserId = userId
    End Sub

    Private Sub Form9_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CONN.Close()
        LoadImagesFromDatabase()
    End Sub

    Private Sub LoadImagesFromDatabase()
        Try
            Using CONN
                CONN.Open()
                Dim query As String = "SELECT * FROM dbroti"
                Using command As New MySqlCommand(query, CONN)
                    Using reader As MySqlDataReader = command.ExecuteReader()
                        Dim index As Integer = 0
                        Dim maxPerRow As Integer = 4
                        Dim pictureBoxWidth As Integer = 150
                        Dim pictureBoxHeight As Integer = 150
                        Dim spacing As Integer = 30
                        Dim panelWidth As Integer = Panel1.Width
                        Dim panelHeight As Integer = 0

                        While reader.Read() AndAlso index <= 100
                            Dim idRoti As Integer = Convert.ToInt32(reader("id_roti"))
                            Dim imageData As String = reader("gambar").ToString()
                            Dim jenisRoti As String = reader("jenis_roti").ToString()
                            Dim namaRoti As String = reader("nama_roti").ToString()
                            Dim hargaRoti As String = reader("harga_roti").ToString()
                            Dim expired As Date = Convert.ToDateTime(reader("expired"))

                            Dim pictureBox As New PictureBox()
                            pictureBox.Name = "PictureBox" & idRoti
                            pictureBox.Size = New Size(pictureBoxWidth, pictureBoxHeight)
                            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage
                            pictureBox.Cursor = Cursors.Hand
                            AddHandler pictureBox.Click, Sub(sender, e) ShowDetailForm(idRoti)
                            Panel1.Controls.Add(pictureBox)

                            Dim label As New Label()
                            label.Name = "Label" & idRoti
                            label.Text = namaRoti
                            label.AutoSize = True
                            label.ForeColor = Color.White
                            label.Font = New Font(label.Font.FontFamily, 12, FontStyle.Bold)
                            label.TextAlign = ContentAlignment.MiddleCenter
                            Panel1.Controls.Add(label)

                            Dim button As New Button()
                            button.Name = "Buy" & idRoti
                            button.Text = "Buy"
                            button.ForeColor = Color.White
                            button.Size = New Size(100, 30)
                            button.Cursor = Cursors.Hand
                            AddHandler button.Click, Sub(sender, e) ShowDetailForm(idRoti)
                            Panel1.Controls.Add(button)

                            Dim rowIndex As Integer = Math.Floor(index / maxPerRow)
                            Dim columnIndex As Integer = index Mod maxPerRow
                            pictureBox.Location = New Point((panelWidth - maxPerRow * (pictureBoxWidth + spacing)) / 2 + columnIndex * (pictureBoxWidth + spacing), rowIndex * (pictureBoxHeight + 60 + spacing))
                            label.Location = New Point(pictureBox.Left + (pictureBoxWidth - label.Width) / 2, pictureBox.Bottom + 15)
                            button.Location = New Point(pictureBox.Left + (pictureBoxWidth - button.Width) / 2, label.Bottom + 15)

                            panelHeight = (rowIndex + 1) * (pictureBoxHeight + 60 + spacing)

                            Dim destinationFolder As String = "Image"
                            Dim imagePath As String = Path.Combine(destinationFolder, imageData)

                            If File.Exists(imagePath) Then
                                pictureBox.Image = Image.FromFile(imagePath)
                            Else
                                MessageBox.Show("File Gambar tidak ditemukan: " & imagePath)
                            End If

                            index += 1
                        End While

                        If panelHeight > Panel1.Height Then
                            Panel1.AutoScroll = True
                            Panel1.VerticalScroll.Enabled = True
                            Panel1.VerticalScroll.Visible = True
                            Panel1.VerticalScroll.Minimum = 0
                            Panel1.VerticalScroll.Maximum = panelHeight - Panel1.ClientSize.Height
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub ShowDetailForm(idRoti As Integer)
        Try
            Dim detailForm As New Form10(loggedInUserId)
            Dim query As String = "SELECT * FROM dbroti WHERE id_roti = @idRoti"
            Using CONN
                CONN.Open()
                Using command As New MySqlCommand(query, CONN)
                    command.Parameters.AddWithValue("@idRoti", idRoti)
                    Using reader As MySqlDataReader = command.ExecuteReader()
                        If reader.Read() Then
                            detailForm.jenisRoti.Text = reader("jenis_roti").ToString()
                            detailForm.namaRoti.Text = reader("nama_roti").ToString()
                            detailForm.hargaRoti.Text = reader("harga_roti").ToString()
                            detailForm.expired.Value = Convert.ToDateTime(reader("expired"))

                            Dim imageData As String = reader("gambar").ToString()
                            Dim destinationFolder As String = "Image"
                            Dim imagePath As String = Path.Combine(destinationFolder, imageData)
                            If File.Exists(imagePath) Then
                                detailForm.PBoxRoti.Image = Image.FromFile(imagePath)
                            Else
                                MessageBox.Show("File Gambar tidak ditemukan: " & imagePath)
                            End If
                        Else
                            MessageBox.Show("Data tidak ditemukan. Silakan periksa kembali ID." & idRoti)
                        End If
                    End Using
                End Using
            End Using
            Me.Hide()
            detailForm.Show()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            If CONN.State = ConnectionState.Open Then
                CONN.Close()
            End If
        End Try
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Dim Checkout As New Checkout(loggedInUserId)
        Checkout.Show()
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Dim confirmation As DialogResult = MessageBox.Show("Apakah Anda yakin ingin keluar dari akun?", "Konfirmasi Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If confirmation = DialogResult.Yes Then
            loggedInUserId = 0
            Me.Close()
            Login.Show()
        End If
    End Sub

End Class