<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(form1))
        OpenFileDialog1 = New OpenFileDialog()
        TabPage3 = New TabPage()
        GroupBox11 = New GroupBox()
        Button2 = New Button()
        GroupBox2 = New GroupBox()
        Button6 = New Button()
        Button5 = New Button()
        Button4 = New Button()
        Button1 = New Button()
        pbPreview = New PictureBox()
        GroupBox1 = New GroupBox()
        cbxnegritaheader = New CheckBox()
        cbxNegrita = New CheckBox()
        GroupBox10 = New GroupBox()
        cmbFont = New ComboBox()
        GroupBox13 = New GroupBox()
        Label6 = New Label()
        txttamanoheader = New NumericUpDown()
        Label11 = New Label()
        GroupBox9 = New GroupBox()
        Label5 = New Label()
        txtTamanoFuente = New NumericUpDown()
        Label3 = New Label()
        GroupBox8 = New GroupBox()
        txtAltoEtiq = New NumericUpDown()
        Label2 = New Label()
        GroupBox7 = New GroupBox()
        txtAnchoEtiq = New NumericUpDown()
        Label10 = New Label()
        GroupBox6 = New GroupBox()
        txtMargenes = New NumericUpDown()
        Label8 = New Label()
        GroupBox3 = New GroupBox()
        NumericQRWidth = New NumericUpDown()
        RadioButtonQRFullSize = New RadioButton()
        RadioButtonQRCustom = New RadioButton()
        Label15 = New Label()
        Label13 = New Label()
        Label12 = New Label()
        Label9 = New Label()
        TabPage2 = New TabPage()
        ComboBoxHojas = New ComboBox()
        Label4 = New Label()
        Label1 = New Label()
        TextBox1 = New TextBox()
        Button3 = New Button()
        DataGridView1 = New DataGridView()
        TabControl1 = New TabControl()
        ProgressBar1 = New ProgressBar()
        Label7 = New Label()
        GroupBox5 = New GroupBox()
        TabPage3.SuspendLayout()
        GroupBox11.SuspendLayout()
        GroupBox2.SuspendLayout()
        CType(pbPreview, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox1.SuspendLayout()
        GroupBox10.SuspendLayout()
        GroupBox13.SuspendLayout()
        CType(txttamanoheader, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox9.SuspendLayout()
        CType(txtTamanoFuente, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox8.SuspendLayout()
        CType(txtAltoEtiq, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox7.SuspendLayout()
        CType(txtAnchoEtiq, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox6.SuspendLayout()
        CType(txtMargenes, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox3.SuspendLayout()
        CType(NumericQRWidth, ComponentModel.ISupportInitialize).BeginInit()
        TabPage2.SuspendLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        TabControl1.SuspendLayout()
        GroupBox5.SuspendLayout()
        SuspendLayout()
        ' 
        ' OpenFileDialog1
        ' 
        OpenFileDialog1.FileName = "OpenFileDialog1"
        ' 
        ' TabPage3
        ' 
        TabPage3.Controls.Add(GroupBox11)
        TabPage3.Controls.Add(GroupBox2)
        TabPage3.Controls.Add(GroupBox1)
        TabPage3.Location = New Point(4, 24)
        TabPage3.Name = "TabPage3"
        TabPage3.Padding = New Padding(3)
        TabPage3.Size = New Size(809, 780)
        TabPage3.TabIndex = 2
        TabPage3.Text = "Propiedades de la Etiqueta"
        TabPage3.UseVisualStyleBackColor = True
        ' 
        ' GroupBox11
        ' 
        GroupBox11.Controls.Add(Button2)
        GroupBox11.Dock = DockStyle.Bottom
        GroupBox11.Location = New Point(3, 722)
        GroupBox11.Name = "GroupBox11"
        GroupBox11.Size = New Size(803, 55)
        GroupBox11.TabIndex = 18
        GroupBox11.TabStop = False
        ' 
        ' Button2
        ' 
        Button2.Anchor = AnchorStyles.None
        Button2.BackColor = SystemColors.ButtonHighlight
        Button2.BackgroundImageLayout = ImageLayout.Zoom
        Button2.Enabled = False
        Button2.Image = CType(resources.GetObject("Button2.Image"), Image)
        Button2.ImageAlign = ContentAlignment.MiddleLeft
        Button2.Location = New Point(315, 13)
        Button2.Margin = New Padding(5, 3, 5, 3)
        Button2.Name = "Button2"
        Button2.Padding = New Padding(20, 5, 20, 5)
        Button2.Size = New Size(186, 36)
        Button2.TabIndex = 1
        Button2.Text = "Generar codigos QR"
        Button2.TextAlign = ContentAlignment.MiddleRight
        Button2.UseVisualStyleBackColor = False
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        GroupBox2.Controls.Add(Button6)
        GroupBox2.Controls.Add(Button5)
        GroupBox2.Controls.Add(Button4)
        GroupBox2.Controls.Add(Button1)
        GroupBox2.Controls.Add(pbPreview)
        GroupBox2.Location = New Point(3, 129)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(803, 548)
        GroupBox2.TabIndex = 13
        GroupBox2.TabStop = False
        GroupBox2.Text = "Vista previa de la etiqueta:"
        ' 
        ' Button6
        ' 
        Button6.Anchor = AnchorStyles.Bottom
        Button6.Font = New Font("Segoe UI", 11F)
        Button6.Location = New Point(452, 500)
        Button6.Name = "Button6"
        Button6.Size = New Size(38, 40)
        Button6.TabIndex = 17
        Button6.Text = "⏩"
        Button6.UseVisualStyleBackColor = True
        ' 
        ' Button5
        ' 
        Button5.Anchor = AnchorStyles.Bottom
        Button5.Font = New Font("Segoe UI", 11F)
        Button5.Location = New Point(320, 500)
        Button5.Name = "Button5"
        Button5.Size = New Size(38, 40)
        Button5.TabIndex = 16
        Button5.Text = "⏪"
        Button5.UseVisualStyleBackColor = True
        ' 
        ' Button4
        ' 
        Button4.Anchor = AnchorStyles.Bottom
        Button4.Font = New Font("Segoe UI", 11F)
        Button4.Location = New Point(364, 500)
        Button4.Name = "Button4"
        Button4.Size = New Size(38, 40)
        Button4.TabIndex = 15
        Button4.Text = "◀️"
        Button4.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.Anchor = AnchorStyles.Bottom
        Button1.Font = New Font("Segoe UI", 11F)
        Button1.Location = New Point(408, 500)
        Button1.Name = "Button1"
        Button1.Size = New Size(38, 40)
        Button1.TabIndex = 14
        Button1.Text = "▶️"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' pbPreview
        ' 
        pbPreview.BackColor = Color.Gainsboro
        pbPreview.BorderStyle = BorderStyle.FixedSingle
        pbPreview.Dock = DockStyle.Fill
        pbPreview.Location = New Point(3, 19)
        pbPreview.Name = "pbPreview"
        pbPreview.Size = New Size(797, 526)
        pbPreview.SizeMode = PictureBoxSizeMode.CenterImage
        pbPreview.TabIndex = 12
        pbPreview.TabStop = False
        ' 
        ' GroupBox1
        ' 
        GroupBox1.AutoSize = True
        GroupBox1.Controls.Add(cbxnegritaheader)
        GroupBox1.Controls.Add(cbxNegrita)
        GroupBox1.Controls.Add(GroupBox10)
        GroupBox1.Controls.Add(GroupBox13)
        GroupBox1.Controls.Add(Label11)
        GroupBox1.Controls.Add(GroupBox9)
        GroupBox1.Controls.Add(Label3)
        GroupBox1.Controls.Add(GroupBox8)
        GroupBox1.Controls.Add(GroupBox7)
        GroupBox1.Controls.Add(GroupBox6)
        GroupBox1.Controls.Add(GroupBox3)
        GroupBox1.Controls.Add(Label13)
        GroupBox1.Controls.Add(Label12)
        GroupBox1.Controls.Add(Label9)
        GroupBox1.Dock = DockStyle.Top
        GroupBox1.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        GroupBox1.Location = New Point(3, 3)
        GroupBox1.Margin = New Padding(1)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Padding = New Padding(0)
        GroupBox1.Size = New Size(803, 131)
        GroupBox1.TabIndex = 9
        GroupBox1.TabStop = False
        ' 
        ' cbxnegritaheader
        ' 
        cbxnegritaheader.AutoSize = True
        cbxnegritaheader.Location = New Point(694, 47)
        cbxnegritaheader.Name = "cbxnegritaheader"
        cbxnegritaheader.Size = New Size(68, 19)
        cbxnegritaheader.TabIndex = 35
        cbxnegritaheader.Text = "Negrita"
        cbxnegritaheader.UseVisualStyleBackColor = True
        ' 
        ' cbxNegrita
        ' 
        cbxNegrita.AutoSize = True
        cbxNegrita.Checked = True
        cbxNegrita.CheckState = CheckState.Checked
        cbxNegrita.Location = New Point(506, 46)
        cbxNegrita.Name = "cbxNegrita"
        cbxNegrita.Size = New Size(68, 19)
        cbxNegrita.TabIndex = 31
        cbxNegrita.Text = "Negrita"
        cbxNegrita.UseVisualStyleBackColor = True
        ' 
        ' GroupBox10
        ' 
        GroupBox10.Controls.Add(cmbFont)
        GroupBox10.Font = New Font("Segoe UI", 9F)
        GroupBox10.Location = New Point(413, 71)
        GroupBox10.Name = "GroupBox10"
        GroupBox10.Size = New Size(161, 41)
        GroupBox10.TabIndex = 29
        GroupBox10.TabStop = False
        GroupBox10.Text = "Fuente:"
        ' 
        ' cmbFont
        ' 
        cmbFont.FormattingEnabled = True
        cmbFont.Items.AddRange(New Object() {"Helvetica", "Helvetica Italic", "Courier Prime", "Times-Roman", "Times-Roman Italic"})
        cmbFont.Location = New Point(6, 13)
        cmbFont.Name = "cmbFont"
        cmbFont.Size = New Size(149, 23)
        cmbFont.TabIndex = 30
        cmbFont.Text = "Helvetica"
        ' 
        ' GroupBox13
        ' 
        GroupBox13.Controls.Add(Label6)
        GroupBox13.Controls.Add(txttamanoheader)
        GroupBox13.Font = New Font("Segoe UI", 9F)
        GroupBox13.Location = New Point(601, 30)
        GroupBox13.Name = "GroupBox13"
        GroupBox13.Size = New Size(87, 42)
        GroupBox13.TabIndex = 32
        GroupBox13.TabStop = False
        GroupBox13.Text = "Tamaño:"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 9F)
        Label6.Location = New Point(65, 17)
        Label6.Name = "Label6"
        Label6.Size = New Size(18, 15)
        Label6.TabIndex = 17
        Label6.Text = "pt"
        ' 
        ' txttamanoheader
        ' 
        txttamanoheader.Location = New Point(6, 13)
        txttamanoheader.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        txttamanoheader.Name = "txttamanoheader"
        txttamanoheader.Size = New Size(53, 23)
        txttamanoheader.TabIndex = 28
        txttamanoheader.Value = New Decimal(New Integer() {10, 0, 0, 0})
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        Label11.Location = New Point(601, 17)
        Label11.Name = "Label11"
        Label11.Size = New Size(80, 15)
        Label11.TabIndex = 33
        Label11.Text = "Encabezados:"
        ' 
        ' GroupBox9
        ' 
        GroupBox9.Controls.Add(Label5)
        GroupBox9.Controls.Add(txtTamanoFuente)
        GroupBox9.Font = New Font("Segoe UI", 9F)
        GroupBox9.Location = New Point(413, 29)
        GroupBox9.Name = "GroupBox9"
        GroupBox9.Size = New Size(87, 42)
        GroupBox9.TabIndex = 25
        GroupBox9.TabStop = False
        GroupBox9.Text = "Tamaño:"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 9F)
        Label5.Location = New Point(65, 17)
        Label5.Name = "Label5"
        Label5.Size = New Size(18, 15)
        Label5.TabIndex = 17
        Label5.Text = "pt"
        ' 
        ' txtTamanoFuente
        ' 
        txtTamanoFuente.Location = New Point(6, 13)
        txtTamanoFuente.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        txtTamanoFuente.Name = "txtTamanoFuente"
        txtTamanoFuente.Size = New Size(53, 23)
        txtTamanoFuente.TabIndex = 28
        txtTamanoFuente.Value = New Decimal(New Integer() {10, 0, 0, 0})
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        Label3.Location = New Point(413, 16)
        Label3.Name = "Label3"
        Label3.Size = New Size(42, 15)
        Label3.TabIndex = 27
        Label3.Text = "Datos:"
        ' 
        ' GroupBox8
        ' 
        GroupBox8.Controls.Add(txtAltoEtiq)
        GroupBox8.Controls.Add(Label2)
        GroupBox8.Font = New Font("Segoe UI", 9F)
        GroupBox8.Location = New Point(6, 66)
        GroupBox8.Name = "GroupBox8"
        GroupBox8.Size = New Size(105, 41)
        GroupBox8.TabIndex = 26
        GroupBox8.TabStop = False
        GroupBox8.Text = "Alto:"
        ' 
        ' txtAltoEtiq
        ' 
        txtAltoEtiq.DecimalPlaces = 2
        txtAltoEtiq.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        txtAltoEtiq.Location = New Point(5, 15)
        txtAltoEtiq.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        txtAltoEtiq.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
        txtAltoEtiq.Name = "txtAltoEtiq"
        txtAltoEtiq.Size = New Size(53, 23)
        txtAltoEtiq.TabIndex = 30
        txtAltoEtiq.Value = New Decimal(New Integer() {15, 0, 0, 0})
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 9F)
        Label2.Location = New Point(64, 19)
        Label2.Name = "Label2"
        Label2.Size = New Size(24, 15)
        Label2.TabIndex = 9
        Label2.Text = "cm"
        ' 
        ' GroupBox7
        ' 
        GroupBox7.Controls.Add(txtAnchoEtiq)
        GroupBox7.Controls.Add(Label10)
        GroupBox7.Font = New Font("Segoe UI", 9F)
        GroupBox7.Location = New Point(5, 24)
        GroupBox7.Name = "GroupBox7"
        GroupBox7.Size = New Size(106, 42)
        GroupBox7.TabIndex = 25
        GroupBox7.TabStop = False
        GroupBox7.Text = "Ancho:"
        ' 
        ' txtAnchoEtiq
        ' 
        txtAnchoEtiq.DecimalPlaces = 2
        txtAnchoEtiq.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        txtAnchoEtiq.Location = New Point(6, 14)
        txtAnchoEtiq.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        txtAnchoEtiq.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
        txtAnchoEtiq.Name = "txtAnchoEtiq"
        txtAnchoEtiq.Size = New Size(53, 23)
        txtAnchoEtiq.TabIndex = 29
        txtAnchoEtiq.Value = New Decimal(New Integer() {10, 0, 0, 0})
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Segoe UI", 9F)
        Label10.Location = New Point(65, 17)
        Label10.Name = "Label10"
        Label10.Size = New Size(24, 15)
        Label10.TabIndex = 9
        Label10.Text = "cm"
        ' 
        ' GroupBox6
        ' 
        GroupBox6.Controls.Add(txtMargenes)
        GroupBox6.Controls.Add(Label8)
        GroupBox6.Font = New Font("Segoe UI", 9F)
        GroupBox6.Location = New Point(120, 25)
        GroupBox6.Name = "GroupBox6"
        GroupBox6.Size = New Size(114, 41)
        GroupBox6.TabIndex = 26
        GroupBox6.TabStop = False
        GroupBox6.Text = "Al rededor"
        ' 
        ' txtMargenes
        ' 
        txtMargenes.DecimalPlaces = 2
        txtMargenes.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        txtMargenes.Location = New Point(3, 13)
        txtMargenes.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        txtMargenes.Name = "txtMargenes"
        txtMargenes.Size = New Size(46, 23)
        txtMargenes.TabIndex = 31
        txtMargenes.Value = New Decimal(New Integer() {15, 0, 0, 65536})
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Segoe UI", 9F)
        Label8.Location = New Point(84, 18)
        Label8.Name = "Label8"
        Label8.Size = New Size(24, 15)
        Label8.TabIndex = 8
        Label8.Text = "cm"
        ' 
        ' GroupBox3
        ' 
        GroupBox3.Controls.Add(NumericQRWidth)
        GroupBox3.Controls.Add(RadioButtonQRFullSize)
        GroupBox3.Controls.Add(RadioButtonQRCustom)
        GroupBox3.Controls.Add(Label15)
        GroupBox3.Font = New Font("Segoe UI", 9F)
        GroupBox3.Location = New Point(245, 24)
        GroupBox3.Name = "GroupBox3"
        GroupBox3.Size = New Size(157, 38)
        GroupBox3.TabIndex = 24
        GroupBox3.TabStop = False
        GroupBox3.Text = "Ancho:"
        ' 
        ' NumericQRWidth
        ' 
        NumericQRWidth.DecimalPlaces = 2
        NumericQRWidth.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        NumericQRWidth.Location = New Point(75, 11)
        NumericQRWidth.Minimum = New Decimal(New Integer() {5, 0, 0, 65536})
        NumericQRWidth.Name = "NumericQRWidth"
        NumericQRWidth.Size = New Size(53, 23)
        NumericQRWidth.TabIndex = 29
        NumericQRWidth.Value = New Decimal(New Integer() {5, 0, 0, 0})
        ' 
        ' RadioButtonQRFullSize
        ' 
        RadioButtonQRFullSize.AutoSize = True
        RadioButtonQRFullSize.Checked = True
        RadioButtonQRFullSize.Font = New Font("Segoe UI", 9F)
        RadioButtonQRFullSize.Location = New Point(4, 14)
        RadioButtonQRFullSize.Margin = New Padding(1)
        RadioButtonQRFullSize.Name = "RadioButtonQRFullSize"
        RadioButtonQRFullSize.Size = New Size(53, 19)
        RadioButtonQRFullSize.TabIndex = 15
        RadioButtonQRFullSize.TabStop = True
        RadioButtonQRFullSize.Text = "100%"
        RadioButtonQRFullSize.UseVisualStyleBackColor = True
        ' 
        ' RadioButtonQRCustom
        ' 
        RadioButtonQRCustom.AutoSize = True
        RadioButtonQRCustom.Font = New Font("Segoe UI", 9F)
        RadioButtonQRCustom.Location = New Point(59, 17)
        RadioButtonQRCustom.Margin = New Padding(1)
        RadioButtonQRCustom.Name = "RadioButtonQRCustom"
        RadioButtonQRCustom.Size = New Size(14, 13)
        RadioButtonQRCustom.TabIndex = 22
        RadioButtonQRCustom.UseVisualStyleBackColor = True
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.Font = New Font("Segoe UI", 9F)
        Label15.Location = New Point(127, 14)
        Label15.Name = "Label15"
        Label15.Size = New Size(24, 15)
        Label15.TabIndex = 17
        Label15.Text = "cm"
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        Label13.Location = New Point(240, 11)
        Label13.Name = "Label13"
        Label13.Size = New Size(93, 15)
        Label13.TabIndex = 14
        Label13.Text = "Tamaño del QR:"
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        Label12.Location = New Point(120, 10)
        Label12.Name = "Label12"
        Label12.Size = New Size(65, 15)
        Label12.TabIndex = 13
        Label12.Text = "Márgenes:"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        Label9.Location = New Point(4, 11)
        Label9.Name = "Label9"
        Label9.Size = New Size(53, 15)
        Label9.TabIndex = 9
        Label9.Text = "Tamaño:"
        ' 
        ' TabPage2
        ' 
        TabPage2.Controls.Add(ComboBoxHojas)
        TabPage2.Controls.Add(Label4)
        TabPage2.Controls.Add(Label1)
        TabPage2.Controls.Add(TextBox1)
        TabPage2.Controls.Add(Button3)
        TabPage2.Controls.Add(DataGridView1)
        TabPage2.Location = New Point(4, 24)
        TabPage2.Name = "TabPage2"
        TabPage2.Padding = New Padding(3)
        TabPage2.Size = New Size(809, 780)
        TabPage2.TabIndex = 1
        TabPage2.Text = "Datos"
        TabPage2.UseVisualStyleBackColor = True
        ' 
        ' ComboBoxHojas
        ' 
        ComboBoxHojas.FormattingEnabled = True
        ComboBoxHojas.Location = New Point(8, 93)
        ComboBoxHojas.Name = "ComboBoxHojas"
        ComboBoxHojas.Size = New Size(174, 23)
        ComboBoxHojas.TabIndex = 11
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(8, 75)
        Label4.Name = "Label4"
        Label4.Size = New Size(104, 15)
        Label4.TabIndex = 10
        Label4.Text = "Selecciona la hoja:"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(8, 16)
        Label1.Name = "Label1"
        Label1.Size = New Size(284, 15)
        Label1.TabIndex = 7
        Label1.Text = "Selecciona un archivo de Excel para extraer los datos:"
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(8, 44)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(681, 23)
        TextBox1.TabIndex = 8
        ' 
        ' Button3
        ' 
        Button3.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Button3.Font = New Font("Segoe UI", 10F)
        Button3.Location = New Point(695, 41)
        Button3.Name = "Button3"
        Button3.Size = New Size(106, 28)
        Button3.TabIndex = 9
        Button3.Text = "🔍 Buscar"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' DataGridView1
        ' 
        DataGridView1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        DataGridView1.BackgroundColor = SystemColors.ControlLight
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(3, 122)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.Size = New Size(803, 655)
        DataGridView1.TabIndex = 2
        ' 
        ' TabControl1
        ' 
        TabControl1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        TabControl1.Controls.Add(TabPage2)
        TabControl1.Controls.Add(TabPage3)
        TabControl1.Location = New Point(0, 0)
        TabControl1.Name = "TabControl1"
        TabControl1.SelectedIndex = 0
        TabControl1.Size = New Size(817, 808)
        TabControl1.TabIndex = 12
        ' 
        ' ProgressBar1
        ' 
        ProgressBar1.BackColor = SystemColors.ControlDarkDark
        ProgressBar1.Dock = DockStyle.Bottom
        ProgressBar1.Location = New Point(3, 37)
        ProgressBar1.Name = "ProgressBar1"
        ProgressBar1.Size = New Size(811, 16)
        ProgressBar1.TabIndex = 10
        ProgressBar1.Visible = False
        ' 
        ' Label7
        ' 
        Label7.Anchor = AnchorStyles.None
        Label7.AutoSize = True
        Label7.Location = New Point(332, 16)
        Label7.Name = "Label7"
        Label7.Size = New Size(152, 15)
        Label7.TabIndex = 11
        Label7.Text = "© Emmanuel Mejía Castillo"
        ' 
        ' GroupBox5
        ' 
        GroupBox5.Controls.Add(Label7)
        GroupBox5.Controls.Add(ProgressBar1)
        GroupBox5.Dock = DockStyle.Bottom
        GroupBox5.Location = New Point(0, 805)
        GroupBox5.Name = "GroupBox5"
        GroupBox5.Size = New Size(817, 56)
        GroupBox5.TabIndex = 13
        GroupBox5.TabStop = False
        ' 
        ' form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(817, 861)
        Controls.Add(GroupBox5)
        Controls.Add(TabControl1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Generador de Codigos QR"
        TabPage3.ResumeLayout(False)
        TabPage3.PerformLayout()
        GroupBox11.ResumeLayout(False)
        GroupBox2.ResumeLayout(False)
        CType(pbPreview, ComponentModel.ISupportInitialize).EndInit()
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        GroupBox10.ResumeLayout(False)
        GroupBox13.ResumeLayout(False)
        GroupBox13.PerformLayout()
        CType(txttamanoheader, ComponentModel.ISupportInitialize).EndInit()
        GroupBox9.ResumeLayout(False)
        GroupBox9.PerformLayout()
        CType(txtTamanoFuente, ComponentModel.ISupportInitialize).EndInit()
        GroupBox8.ResumeLayout(False)
        GroupBox8.PerformLayout()
        CType(txtAltoEtiq, ComponentModel.ISupportInitialize).EndInit()
        GroupBox7.ResumeLayout(False)
        GroupBox7.PerformLayout()
        CType(txtAnchoEtiq, ComponentModel.ISupportInitialize).EndInit()
        GroupBox6.ResumeLayout(False)
        GroupBox6.PerformLayout()
        CType(txtMargenes, ComponentModel.ISupportInitialize).EndInit()
        GroupBox3.ResumeLayout(False)
        GroupBox3.PerformLayout()
        CType(NumericQRWidth, ComponentModel.ISupportInitialize).EndInit()
        TabPage2.ResumeLayout(False)
        TabPage2.PerformLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        TabControl1.ResumeLayout(False)
        GroupBox5.ResumeLayout(False)
        GroupBox5.PerformLayout()
        ResumeLayout(False)
    End Sub
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Button6 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents pbPreview As PictureBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cbxNegrita As CheckBox
    Public WithEvents GroupBox10 As GroupBox
    Friend WithEvents cmbFont As ComboBox
    Friend WithEvents GroupBox9 As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtTamanoFuente As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox8 As GroupBox
    Friend WithEvents txtAltoEtiq As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents txtAnchoEtiq As NumericUpDown
    Friend WithEvents Label10 As Label
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents txtMargenes As NumericUpDown
    Friend WithEvents Label8 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents RadioButtonQRFullSize As RadioButton
    Friend WithEvents RadioButtonQRCustom As RadioButton
    Friend WithEvents Label15 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button3 As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents GroupBox11 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents ComboBoxHojas As ComboBox
    Friend WithEvents cbxnegritaheader As CheckBox
    Friend WithEvents GroupBox13 As GroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txttamanoheader As NumericUpDown
    Friend WithEvents Label11 As Label
    Friend WithEvents NumericQRWidth As NumericUpDown


End Class
