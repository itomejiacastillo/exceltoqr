﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
        Button2 = New Button()
        DataGridView1 = New DataGridView()
        OpenFileDialog1 = New OpenFileDialog()
        GroupBox1 = New GroupBox()
        cbxNegrita = New CheckBox()
        GroupBox10 = New GroupBox()
        cmbFont = New ComboBox()
        GroupBox9 = New GroupBox()
        Label5 = New Label()
        txtTamanoFuente = New NumericUpDown()
        Label3 = New Label()
        GroupBox8 = New GroupBox()
        lblcmalto = New Label()
        txtAltoEtiq = New NumericUpDown()
        Label2 = New Label()
        GroupBox7 = New GroupBox()
        lblcmancho = New Label()
        txtAnchoEtiq = New NumericUpDown()
        Label10 = New Label()
        GroupBox6 = New GroupBox()
        txtMargenes = New NumericUpDown()
        Label8 = New Label()
        GroupBox4 = New GroupBox()
        txtQRAlto = New TextBox()
        RadioButton5 = New RadioButton()
        RadioButton6 = New RadioButton()
        Label14 = New Label()
        GroupBox3 = New GroupBox()
        txtQRAncho = New TextBox()
        RadioButton1 = New RadioButton()
        RadioButton3 = New RadioButton()
        Label15 = New Label()
        Label13 = New Label()
        Label12 = New Label()
        Label9 = New Label()
        ProgressBar1 = New ProgressBar()
        Label7 = New Label()
        TabControl1 = New TabControl()
        TabPage2 = New TabPage()
        Label1 = New Label()
        TextBox1 = New TextBox()
        Button3 = New Button()
        TabPage3 = New TabPage()
        GroupBox2 = New GroupBox()
        btnUpdatePreview = New Button()
        pbPreview = New PictureBox()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox1.SuspendLayout()
        GroupBox10.SuspendLayout()
        GroupBox9.SuspendLayout()
        CType(txtTamanoFuente, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox8.SuspendLayout()
        CType(txtAltoEtiq, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox7.SuspendLayout()
        CType(txtAnchoEtiq, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox6.SuspendLayout()
        CType(txtMargenes, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox4.SuspendLayout()
        GroupBox3.SuspendLayout()
        TabControl1.SuspendLayout()
        TabPage2.SuspendLayout()
        TabPage3.SuspendLayout()
        GroupBox2.SuspendLayout()
        CType(pbPreview, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Button2
        ' 
        Button2.BackColor = SystemColors.ButtonHighlight
        Button2.BackgroundImageLayout = ImageLayout.Zoom
        Button2.Image = CType(resources.GetObject("Button2.Image"), Image)
        Button2.ImageAlign = ContentAlignment.MiddleLeft
        Button2.Location = New Point(315, 628)
        Button2.Margin = New Padding(5, 3, 5, 3)
        Button2.Name = "Button2"
        Button2.Padding = New Padding(20, 5, 20, 5)
        Button2.Size = New Size(186, 35)
        Button2.TabIndex = 1
        Button2.Text = "Generar codigos QR"
        Button2.TextAlign = ContentAlignment.MiddleRight
        Button2.UseVisualStyleBackColor = False
        ' 
        ' DataGridView1
        ' 
        DataGridView1.BackgroundColor = SystemColors.ControlLight
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Dock = DockStyle.Bottom
        DataGridView1.Location = New Point(3, 86)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.Size = New Size(803, 598)
        DataGridView1.TabIndex = 2
        ' 
        ' OpenFileDialog1
        ' 
        OpenFileDialog1.FileName = "OpenFileDialog1"
        ' 
        ' GroupBox1
        ' 
        GroupBox1.AutoSize = True
        GroupBox1.Controls.Add(cbxNegrita)
        GroupBox1.Controls.Add(GroupBox10)
        GroupBox1.Controls.Add(GroupBox9)
        GroupBox1.Controls.Add(Label3)
        GroupBox1.Controls.Add(GroupBox8)
        GroupBox1.Controls.Add(GroupBox7)
        GroupBox1.Controls.Add(GroupBox6)
        GroupBox1.Controls.Add(GroupBox4)
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
        GroupBox1.Size = New Size(803, 126)
        GroupBox1.TabIndex = 9
        GroupBox1.TabStop = False
        ' 
        ' cbxNegrita
        ' 
        cbxNegrita.AutoSize = True
        cbxNegrita.Location = New Point(676, 41)
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
        GroupBox10.Location = New Point(583, 66)
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
        cmbFont.Location = New Point(3, 14)
        cmbFont.Name = "cmbFont"
        cmbFont.Size = New Size(156, 23)
        cmbFont.TabIndex = 30
        cmbFont.Text = "Helvetica"
        ' 
        ' GroupBox9
        ' 
        GroupBox9.Controls.Add(Label5)
        GroupBox9.Controls.Add(txtTamanoFuente)
        GroupBox9.Font = New Font("Segoe UI", 9F)
        GroupBox9.Location = New Point(583, 24)
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
        txtTamanoFuente.Name = "txtTamanoFuente"
        txtTamanoFuente.Size = New Size(53, 23)
        txtTamanoFuente.TabIndex = 28
        txtTamanoFuente.Value = New Decimal(New Integer() {10, 0, 0, 0})
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        Label3.Location = New Point(583, 11)
        Label3.Name = "Label3"
        Label3.Size = New Size(42, 15)
        Label3.TabIndex = 27
        Label3.Text = "Texto:"
        ' 
        ' GroupBox8
        ' 
        GroupBox8.Controls.Add(lblcmalto)
        GroupBox8.Controls.Add(txtAltoEtiq)
        GroupBox8.Controls.Add(Label2)
        GroupBox8.Font = New Font("Segoe UI", 9F)
        GroupBox8.Location = New Point(6, 66)
        GroupBox8.Name = "GroupBox8"
        GroupBox8.Size = New Size(168, 41)
        GroupBox8.TabIndex = 26
        GroupBox8.TabStop = False
        GroupBox8.Text = "Alto:"
        ' 
        ' lblcmalto
        ' 
        lblcmalto.AutoSize = True
        lblcmalto.Font = New Font("Segoe UI", 9F)
        lblcmalto.Location = New Point(81, 19)
        lblcmalto.Name = "lblcmalto"
        lblcmalto.Size = New Size(39, 15)
        lblcmalto.TabIndex = 31
        lblcmalto.Text = "00 cm"
        ' 
        ' txtAltoEtiq
        ' 
        txtAltoEtiq.Location = New Point(5, 15)
        txtAltoEtiq.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        txtAltoEtiq.Minimum = New Decimal(New Integer() {20, 0, 0, 0})
        txtAltoEtiq.Name = "txtAltoEtiq"
        txtAltoEtiq.Size = New Size(46, 23)
        txtAltoEtiq.TabIndex = 30
        txtAltoEtiq.Value = New Decimal(New Integer() {390, 0, 0, 0})
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 9F)
        Label2.Location = New Point(53, 19)
        Label2.Name = "Label2"
        Label2.Size = New Size(29, 15)
        Label2.TabIndex = 9
        Label2.Text = "pt ="
        ' 
        ' GroupBox7
        ' 
        GroupBox7.Controls.Add(lblcmancho)
        GroupBox7.Controls.Add(txtAnchoEtiq)
        GroupBox7.Controls.Add(Label10)
        GroupBox7.Font = New Font("Segoe UI", 9F)
        GroupBox7.Location = New Point(5, 24)
        GroupBox7.Name = "GroupBox7"
        GroupBox7.Size = New Size(169, 42)
        GroupBox7.TabIndex = 25
        GroupBox7.TabStop = False
        GroupBox7.Text = "Ancho:"
        ' 
        ' lblcmancho
        ' 
        lblcmancho.AutoSize = True
        lblcmancho.Font = New Font("Segoe UI", 9F)
        lblcmancho.Location = New Point(82, 18)
        lblcmancho.Name = "lblcmancho"
        lblcmancho.Size = New Size(39, 15)
        lblcmancho.TabIndex = 30
        lblcmancho.Text = "00 cm"
        ' 
        ' txtAnchoEtiq
        ' 
        txtAnchoEtiq.Location = New Point(6, 14)
        txtAnchoEtiq.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        txtAnchoEtiq.Minimum = New Decimal(New Integer() {20, 0, 0, 0})
        txtAnchoEtiq.Name = "txtAnchoEtiq"
        txtAnchoEtiq.Size = New Size(46, 23)
        txtAnchoEtiq.TabIndex = 29
        txtAnchoEtiq.Value = New Decimal(New Integer() {300, 0, 0, 0})
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Segoe UI", 9F)
        Label10.Location = New Point(54, 18)
        Label10.Name = "Label10"
        Label10.Size = New Size(29, 15)
        Label10.TabIndex = 9
        Label10.Text = "pt ="
        ' 
        ' GroupBox6
        ' 
        GroupBox6.Controls.Add(txtMargenes)
        GroupBox6.Controls.Add(Label8)
        GroupBox6.Font = New Font("Segoe UI", 9F)
        GroupBox6.Location = New Point(185, 25)
        GroupBox6.Name = "GroupBox6"
        GroupBox6.Size = New Size(183, 41)
        GroupBox6.TabIndex = 26
        GroupBox6.TabStop = False
        GroupBox6.Text = "Al rededor"
        ' 
        ' txtMargenes
        ' 
        txtMargenes.Location = New Point(3, 13)
        txtMargenes.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        txtMargenes.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
        txtMargenes.Name = "txtMargenes"
        txtMargenes.Size = New Size(46, 23)
        txtMargenes.TabIndex = 31
        txtMargenes.Value = New Decimal(New Integer() {20, 0, 0, 0})
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Segoe UI", 9F)
        Label8.Location = New Point(51, 18)
        Label8.Name = "Label8"
        Label8.Size = New Size(43, 15)
        Label8.TabIndex = 8
        Label8.Text = "pixeles"
        ' 
        ' GroupBox4
        ' 
        GroupBox4.Controls.Add(txtQRAlto)
        GroupBox4.Controls.Add(RadioButton5)
        GroupBox4.Controls.Add(RadioButton6)
        GroupBox4.Controls.Add(Label14)
        GroupBox4.Font = New Font("Segoe UI", 9F)
        GroupBox4.Location = New Point(379, 66)
        GroupBox4.Name = "GroupBox4"
        GroupBox4.Size = New Size(192, 41)
        GroupBox4.TabIndex = 25
        GroupBox4.TabStop = False
        GroupBox4.Text = "Alto:"
        ' 
        ' txtQRAlto
        ' 
        txtQRAlto.Font = New Font("Segoe UI", 9F)
        txtQRAlto.Location = New Point(75, 11)
        txtQRAlto.Margin = New Padding(3, 0, 3, 0)
        txtQRAlto.MaxLength = 4
        txtQRAlto.Name = "txtQRAlto"
        txtQRAlto.Size = New Size(32, 23)
        txtQRAlto.TabIndex = 16
        txtQRAlto.Text = "10"
        ' 
        ' RadioButton5
        ' 
        RadioButton5.AutoSize = True
        RadioButton5.Checked = True
        RadioButton5.Font = New Font("Segoe UI", 9F)
        RadioButton5.Location = New Point(4, 14)
        RadioButton5.Margin = New Padding(1)
        RadioButton5.Name = "RadioButton5"
        RadioButton5.Size = New Size(51, 19)
        RadioButton5.TabIndex = 15
        RadioButton5.TabStop = True
        RadioButton5.Text = "Auto"
        RadioButton5.UseVisualStyleBackColor = True
        ' 
        ' RadioButton6
        ' 
        RadioButton6.AutoSize = True
        RadioButton6.Font = New Font("Segoe UI", 9F)
        RadioButton6.Location = New Point(59, 18)
        RadioButton6.Margin = New Padding(1)
        RadioButton6.Name = "RadioButton6"
        RadioButton6.Size = New Size(14, 13)
        RadioButton6.TabIndex = 22
        RadioButton6.UseVisualStyleBackColor = True
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.Font = New Font("Segoe UI", 9F)
        Label14.Location = New Point(108, 16)
        Label14.Name = "Label14"
        Label14.Size = New Size(20, 15)
        Label14.TabIndex = 17
        Label14.Text = "px"
        ' 
        ' GroupBox3
        ' 
        GroupBox3.Controls.Add(txtQRAncho)
        GroupBox3.Controls.Add(RadioButton1)
        GroupBox3.Controls.Add(RadioButton3)
        GroupBox3.Controls.Add(Label15)
        GroupBox3.Font = New Font("Segoe UI", 9F)
        GroupBox3.Location = New Point(379, 24)
        GroupBox3.Name = "GroupBox3"
        GroupBox3.Size = New Size(192, 42)
        GroupBox3.TabIndex = 24
        GroupBox3.TabStop = False
        GroupBox3.Text = "Ancho:"
        ' 
        ' txtQRAncho
        ' 
        txtQRAncho.Font = New Font("Segoe UI", 9F)
        txtQRAncho.Location = New Point(75, 10)
        txtQRAncho.Margin = New Padding(3, 0, 3, 0)
        txtQRAncho.MaxLength = 4
        txtQRAncho.Name = "txtQRAncho"
        txtQRAncho.Size = New Size(32, 23)
        txtQRAncho.TabIndex = 16
        txtQRAncho.Text = "10"
        ' 
        ' RadioButton1
        ' 
        RadioButton1.AutoSize = True
        RadioButton1.Checked = True
        RadioButton1.Font = New Font("Segoe UI", 9F)
        RadioButton1.Location = New Point(4, 14)
        RadioButton1.Margin = New Padding(1)
        RadioButton1.Name = "RadioButton1"
        RadioButton1.Size = New Size(53, 19)
        RadioButton1.TabIndex = 15
        RadioButton1.TabStop = True
        RadioButton1.Text = "100%"
        RadioButton1.UseVisualStyleBackColor = True
        ' 
        ' RadioButton3
        ' 
        RadioButton3.AutoSize = True
        RadioButton3.Font = New Font("Segoe UI", 9F)
        RadioButton3.Location = New Point(59, 17)
        RadioButton3.Margin = New Padding(1)
        RadioButton3.Name = "RadioButton3"
        RadioButton3.Size = New Size(14, 13)
        RadioButton3.TabIndex = 22
        RadioButton3.UseVisualStyleBackColor = True
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.Font = New Font("Segoe UI", 9F)
        Label15.Location = New Point(108, 15)
        Label15.Name = "Label15"
        Label15.Size = New Size(20, 15)
        Label15.TabIndex = 17
        Label15.Text = "px"
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        Label13.Location = New Point(374, 11)
        Label13.Name = "Label13"
        Label13.Size = New Size(93, 15)
        Label13.TabIndex = 14
        Label13.Text = "Tamaño del QR:"
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        Label12.Location = New Point(185, 10)
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
        ' ProgressBar1
        ' 
        ProgressBar1.BackColor = SystemColors.ControlDarkDark
        ProgressBar1.Dock = DockStyle.Bottom
        ProgressBar1.Location = New Point(0, 750)
        ProgressBar1.Name = "ProgressBar1"
        ProgressBar1.Size = New Size(817, 16)
        ProgressBar1.TabIndex = 10
        ProgressBar1.Visible = False
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(333, 724)
        Label7.Name = "Label7"
        Label7.Size = New Size(152, 15)
        Label7.TabIndex = 11
        Label7.Text = "© Emmanuel Mejía Castillo"
        ' 
        ' TabControl1
        ' 
        TabControl1.Controls.Add(TabPage2)
        TabControl1.Controls.Add(TabPage3)
        TabControl1.Dock = DockStyle.Top
        TabControl1.Location = New Point(0, 0)
        TabControl1.Name = "TabControl1"
        TabControl1.SelectedIndex = 0
        TabControl1.Size = New Size(817, 715)
        TabControl1.TabIndex = 12
        ' 
        ' TabPage2
        ' 
        TabPage2.Controls.Add(Label1)
        TabPage2.Controls.Add(TextBox1)
        TabPage2.Controls.Add(Button3)
        TabPage2.Controls.Add(DataGridView1)
        TabPage2.Location = New Point(4, 24)
        TabPage2.Name = "TabPage2"
        TabPage2.Padding = New Padding(3)
        TabPage2.Size = New Size(809, 687)
        TabPage2.TabIndex = 1
        TabPage2.Text = "Datos"
        TabPage2.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(8, 16)
        Label1.Name = "Label1"
        Label1.Size = New Size(286, 15)
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
        Button3.Font = New Font("Segoe UI", 10F)
        Button3.Location = New Point(695, 41)
        Button3.Name = "Button3"
        Button3.Size = New Size(106, 28)
        Button3.TabIndex = 9
        Button3.Text = "🔍 Buscar"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' TabPage3
        ' 
        TabPage3.Controls.Add(GroupBox2)
        TabPage3.Controls.Add(GroupBox1)
        TabPage3.Controls.Add(Button2)
        TabPage3.Location = New Point(4, 24)
        TabPage3.Name = "TabPage3"
        TabPage3.Padding = New Padding(3)
        TabPage3.Size = New Size(809, 687)
        TabPage3.TabIndex = 2
        TabPage3.Text = "Propiedades de la Etiqueta"
        TabPage3.UseVisualStyleBackColor = True
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Controls.Add(btnUpdatePreview)
        GroupBox2.Controls.Add(pbPreview)
        GroupBox2.Location = New Point(2, 133)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(803, 475)
        GroupBox2.TabIndex = 13
        GroupBox2.TabStop = False
        GroupBox2.Text = "Vista previa de la etiqueta:"
        ' 
        ' btnUpdatePreview
        ' 
        btnUpdatePreview.Location = New Point(688, 429)
        btnUpdatePreview.Name = "btnUpdatePreview"
        btnUpdatePreview.Size = New Size(103, 32)
        btnUpdatePreview.TabIndex = 14
        btnUpdatePreview.Text = "Actualizar"
        btnUpdatePreview.UseVisualStyleBackColor = True
        ' 
        ' pbPreview
        ' 
        pbPreview.BackColor = Color.Gainsboro
        pbPreview.BorderStyle = BorderStyle.FixedSingle
        pbPreview.Dock = DockStyle.Fill
        pbPreview.Location = New Point(3, 19)
        pbPreview.Name = "pbPreview"
        pbPreview.Size = New Size(797, 453)
        pbPreview.SizeMode = PictureBoxSizeMode.CenterImage
        pbPreview.TabIndex = 12
        pbPreview.TabStop = False
        ' 
        ' form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(817, 766)
        Controls.Add(TabControl1)
        Controls.Add(Label7)
        Controls.Add(ProgressBar1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Generador de Codigos QR"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        GroupBox10.ResumeLayout(False)
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
        GroupBox4.ResumeLayout(False)
        GroupBox4.PerformLayout()
        GroupBox3.ResumeLayout(False)
        GroupBox3.PerformLayout()
        TabControl1.ResumeLayout(False)
        TabPage2.ResumeLayout(False)
        TabPage2.PerformLayout()
        TabPage3.ResumeLayout(False)
        TabPage3.PerformLayout()
        GroupBox2.ResumeLayout(False)
        CType(pbPreview, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Button2 As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Label7 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button3 As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents pbPreview As PictureBox
    Friend WithEvents btnUpdatePreview As Button
    Friend WithEvents Label12 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents txtQRAncho As TextBox
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents RadioButton3 As RadioButton
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents txtQRAlto As TextBox
    Friend WithEvents RadioButton5 As RadioButton
    Friend WithEvents RadioButton6 As RadioButton
    Friend WithEvents Label14 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents Label8 As Label
    Friend WithEvents GroupBox8 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox9 As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtTamanoFuente As NumericUpDown
    Friend WithEvents cmbFont As ComboBox
    Friend WithEvents cbxNegrita As CheckBox
    Friend WithEvents txtAnchoEtiq As NumericUpDown
    Friend WithEvents txtAltoEtiq As NumericUpDown
    Friend WithEvents txtMargenes As NumericUpDown
    Public WithEvents GroupBox10 As GroupBox
    Friend WithEvents lblcmancho As Label
    Friend WithEvents lblcmalto As Label


End Class
