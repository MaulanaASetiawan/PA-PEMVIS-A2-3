<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TambahDataRoti
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TambahDataRoti))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.namaRoti = New System.Windows.Forms.TextBox()
        Me.hargaRoti = New System.Windows.Forms.TextBox()
        Me.jenisRoti = New System.Windows.Forms.ComboBox()
        Me.expired = New System.Windows.Forms.DateTimePicker()
        Me.idRoti = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.stokRoti = New System.Windows.Forms.NumericUpDown()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.rbLembut = New System.Windows.Forms.RadioButton()
        Me.rbKering = New System.Windows.Forms.RadioButton()
        Me.rbChewy = New System.Windows.Forms.RadioButton()
        Me.rbRenyah = New System.Windows.Forms.RadioButton()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.btnInsert = New System.Windows.Forms.Button()
        Me.PBoxRoti = New System.Windows.Forms.PictureBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.btnlogout = New System.Windows.Forms.Button()
        CType(Me.stokRoti, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip2.SuspendLayout()
        CType(Me.PBoxRoti, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(51, 174)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(126, 27)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nama Roti"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(51, 235)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(130, 27)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Harga Roti"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(51, 295)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(114, 27)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Stok Roti"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(51, 360)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 27)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Rasa Roti"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(51, 420)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 27)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Expired"
        '
        'namaRoti
        '
        Me.namaRoti.Font = New System.Drawing.Font("Arial", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.namaRoti.Location = New System.Drawing.Point(227, 171)
        Me.namaRoti.Name = "namaRoti"
        Me.namaRoti.Size = New System.Drawing.Size(431, 34)
        Me.namaRoti.TabIndex = 2
        '
        'hargaRoti
        '
        Me.hargaRoti.Font = New System.Drawing.Font("Arial", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.hargaRoti.Location = New System.Drawing.Point(227, 232)
        Me.hargaRoti.Name = "hargaRoti"
        Me.hargaRoti.Size = New System.Drawing.Size(431, 34)
        Me.hargaRoti.TabIndex = 3
        '
        'jenisRoti
        '
        Me.jenisRoti.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.jenisRoti.Font = New System.Drawing.Font("Arial", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.jenisRoti.FormattingEnabled = True
        Me.jenisRoti.Location = New System.Drawing.Point(227, 356)
        Me.jenisRoti.Name = "jenisRoti"
        Me.jenisRoti.Size = New System.Drawing.Size(431, 35)
        Me.jenisRoti.TabIndex = 5
        '
        'expired
        '
        Me.expired.Font = New System.Drawing.Font("Arial", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.expired.Location = New System.Drawing.Point(227, 413)
        Me.expired.MaxDate = New Date(2045, 12, 31, 0, 0, 0, 0)
        Me.expired.Name = "expired"
        Me.expired.Size = New System.Drawing.Size(431, 34)
        Me.expired.TabIndex = 6
        '
        'idRoti
        '
        Me.idRoti.Font = New System.Drawing.Font("Arial", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.idRoti.Location = New System.Drawing.Point(227, 111)
        Me.idRoti.Name = "idRoti"
        Me.idRoti.Size = New System.Drawing.Size(431, 34)
        Me.idRoti.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(51, 114)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 27)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "ID Roti"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(186, 170)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(20, 29)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = ":"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(186, 110)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(20, 29)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = ":"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(186, 231)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(20, 29)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = ":"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(186, 291)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(20, 29)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = ":"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(186, 356)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(20, 29)
        Me.Label11.TabIndex = 17
        Me.Label11.Text = ":"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(186, 416)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(20, 29)
        Me.Label12.TabIndex = 18
        Me.Label12.Text = ":"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Sienna
        Me.Button1.Font = New System.Drawing.Font("Arial", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(56, 570)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(602, 46)
        Me.Button1.TabIndex = 19
        Me.Button1.Text = "Tambah"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'stokRoti
        '
        Me.stokRoti.Font = New System.Drawing.Font("Arial", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stokRoti.Location = New System.Drawing.Point(227, 293)
        Me.stokRoti.Name = "stokRoti"
        Me.stokRoti.Size = New System.Drawing.Size(431, 34)
        Me.stokRoti.TabIndex = 4
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(186, 475)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(20, 29)
        Me.Label13.TabIndex = 24
        Me.Label13.Text = ":"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Arial", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(51, 479)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(96, 27)
        Me.Label14.TabIndex = 23
        Me.Label14.Text = "Tekstur"
        '
        'rbLembut
        '
        Me.rbLembut.AutoSize = True
        Me.rbLembut.BackColor = System.Drawing.Color.Transparent
        Me.rbLembut.Font = New System.Drawing.Font("Arial", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbLembut.Location = New System.Drawing.Point(227, 477)
        Me.rbLembut.Name = "rbLembut"
        Me.rbLembut.Size = New System.Drawing.Size(116, 31)
        Me.rbLembut.TabIndex = 7
        Me.rbLembut.TabStop = True
        Me.rbLembut.Text = "Lembut"
        Me.rbLembut.UseVisualStyleBackColor = False
        '
        'rbKering
        '
        Me.rbKering.AutoSize = True
        Me.rbKering.BackColor = System.Drawing.Color.Transparent
        Me.rbKering.Font = New System.Drawing.Font("Arial", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbKering.Location = New System.Drawing.Point(227, 514)
        Me.rbKering.Name = "rbKering"
        Me.rbKering.Size = New System.Drawing.Size(108, 31)
        Me.rbKering.TabIndex = 8
        Me.rbKering.TabStop = True
        Me.rbKering.Text = "Kering"
        Me.rbKering.UseVisualStyleBackColor = False
        '
        'rbChewy
        '
        Me.rbChewy.AutoSize = True
        Me.rbChewy.BackColor = System.Drawing.Color.Transparent
        Me.rbChewy.Font = New System.Drawing.Font("Arial", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbChewy.Location = New System.Drawing.Point(366, 477)
        Me.rbChewy.Name = "rbChewy"
        Me.rbChewy.Size = New System.Drawing.Size(108, 31)
        Me.rbChewy.TabIndex = 9
        Me.rbChewy.TabStop = True
        Me.rbChewy.Text = "Chewy"
        Me.rbChewy.UseVisualStyleBackColor = False
        '
        'rbRenyah
        '
        Me.rbRenyah.AutoSize = True
        Me.rbRenyah.BackColor = System.Drawing.Color.Transparent
        Me.rbRenyah.Font = New System.Drawing.Font("Arial", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbRenyah.Location = New System.Drawing.Point(366, 514)
        Me.rbRenyah.Name = "rbRenyah"
        Me.rbRenyah.Size = New System.Drawing.Size(117, 31)
        Me.rbRenyah.TabIndex = 10
        Me.rbRenyah.TabStop = True
        Me.rbRenyah.Text = "Renyah"
        Me.rbRenyah.UseVisualStyleBackColor = False
        '
        'MenuStrip2
        '
        Me.MenuStrip2.BackColor = System.Drawing.Color.Sienna
        Me.MenuStrip2.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem3, Me.ToolStripMenuItem2})
        Me.MenuStrip2.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.MenuStrip2.Size = New System.Drawing.Size(1098, 32)
        Me.MenuStrip2.TabIndex = 26
        Me.MenuStrip2.Text = "MenuStrip2"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripMenuItem1.ForeColor = System.Drawing.Color.White
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(164, 28)
        Me.ToolStripMenuItem1.Text = "Lihat Data Roti"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripMenuItem3.ForeColor = System.Drawing.Color.White
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(196, 28)
        Me.ToolStripMenuItem3.Text = "Tambah Rasa Roti"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripMenuItem2.ForeColor = System.Drawing.Color.White
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(184, 28)
        Me.ToolStripMenuItem2.Text = "Update Data Roti"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(822, 108)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(23, 31)
        Me.Label15.TabIndex = 104
        Me.Label15.Text = ":"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(710, 111)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(99, 29)
        Me.Label16.TabIndex = 103
        Me.Label16.Text = "Gambar"
        '
        'btnInsert
        '
        Me.btnInsert.BackColor = System.Drawing.Color.Sienna
        Me.btnInsert.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInsert.ForeColor = System.Drawing.Color.White
        Me.btnInsert.Location = New System.Drawing.Point(851, 281)
        Me.btnInsert.Name = "btnInsert"
        Me.btnInsert.Size = New System.Drawing.Size(222, 46)
        Me.btnInsert.TabIndex = 102
        Me.btnInsert.Text = "Insert"
        Me.btnInsert.UseVisualStyleBackColor = False
        '
        'PBoxRoti
        '
        Me.PBoxRoti.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PBoxRoti.Location = New System.Drawing.Point(851, 114)
        Me.PBoxRoti.Name = "PBoxRoti"
        Me.PBoxRoti.Size = New System.Drawing.Size(222, 146)
        Me.PBoxRoti.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBoxRoti.TabIndex = 101
        Me.PBoxRoti.TabStop = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'btnlogout
        '
        Me.btnlogout.BackColor = System.Drawing.Color.Sienna
        Me.btnlogout.Font = New System.Drawing.Font("Arial", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnlogout.ForeColor = System.Drawing.Color.White
        Me.btnlogout.Location = New System.Drawing.Point(886, 570)
        Me.btnlogout.Name = "btnlogout"
        Me.btnlogout.Size = New System.Drawing.Size(139, 46)
        Me.btnlogout.TabIndex = 105
        Me.btnlogout.Text = "Logout"
        Me.btnlogout.UseVisualStyleBackColor = False
        '
        'TambahDataRoti
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.RosyBrown
        Me.BackgroundImage = Global.Posttest4.My.Resources.Resources.Liceria___Co___1_
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1098, 647)
        Me.Controls.Add(Me.btnlogout)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.btnInsert)
        Me.Controls.Add(Me.PBoxRoti)
        Me.Controls.Add(Me.rbLembut)
        Me.Controls.Add(Me.rbKering)
        Me.Controls.Add(Me.rbRenyah)
        Me.Controls.Add(Me.rbChewy)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.stokRoti)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.idRoti)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.expired)
        Me.Controls.Add(Me.jenisRoti)
        Me.Controls.Add(Me.hargaRoti)
        Me.Controls.Add(Me.namaRoti)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MenuStrip2)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "TambahDataRoti"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tambah Data Roti"
        CType(Me.stokRoti, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        CType(Me.PBoxRoti, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents namaRoti As TextBox
    Friend WithEvents hargaRoti As TextBox
    Friend WithEvents jenisRoti As ComboBox
    Friend WithEvents expired As DateTimePicker
    Friend WithEvents idRoti As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents stokRoti As NumericUpDown
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents rbChewy As RadioButton
    Friend WithEvents rbKering As RadioButton
    Friend WithEvents rbLembut As RadioButton
    Friend WithEvents rbRenyah As RadioButton
    Friend WithEvents MenuStrip2 As MenuStrip
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripMenuItem
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents btnInsert As Button
    Friend WithEvents PBoxRoti As PictureBox
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents btnlogout As Button
End Class
