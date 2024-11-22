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
        Button1 = New Button()
        Button2 = New Button()
        DataGridView1 = New DataGridView()
        Label1 = New Label()
        OpenFileDialog1 = New OpenFileDialog()
        TextBox1 = New TextBox()
        Button3 = New Button()
        Label2 = New Label()
        GroupBox1 = New GroupBox()
        txtAltoEtiq = New TextBox()
        Label6 = New Label()
        txtAnchoEtiq = New TextBox()
        Label5 = New Label()
        ProgressBar1 = New ProgressBar()
        Label7 = New Label()
        TabControl1 = New TabControl()
        TabPage1 = New TabPage()
        Label3 = New Label()
        Label4 = New Label()
        TabPage2 = New TabPage()
        TabPage3 = New TabPage()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox1.SuspendLayout()
        TabControl1.SuspendLayout()
        TabPage1.SuspendLayout()
        TabPage2.SuspendLayout()
        TabPage3.SuspendLayout()
        SuspendLayout()
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(27, 163)
        Button1.Name = "Button1"
        Button1.Size = New Size(149, 29)
        Button1.TabIndex = 0
        Button1.Text = "Extraer"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.BackColor = SystemColors.ButtonHighlight
        Button2.BackgroundImageLayout = ImageLayout.Zoom
        Button2.Image = CType(resources.GetObject("Button2.Image"), Image)
        Button2.ImageAlign = ContentAlignment.MiddleLeft
        Button2.Location = New Point(320, 610)
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
        DataGridView1.Dock = DockStyle.Fill
        DataGridView1.Location = New Point(3, 3)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.Size = New Size(803, 732)
        DataGridView1.TabIndex = 2
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(27, 42)
        Label1.Name = "Label1"
        Label1.Size = New Size(158, 15)
        Label1.TabIndex = 3
        Label1.Text = "Seleccionar archivo de Excel:"
        ' 
        ' OpenFileDialog1
        ' 
        OpenFileDialog1.FileName = "OpenFileDialog1"
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(27, 70)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(632, 23)
        TextBox1.TabIndex = 4
        ' 
        ' Button3
        ' 
        Button3.Font = New Font("Segoe UI", 10F)
        Button3.Location = New Point(664, 67)
        Button3.Name = "Button3"
        Button3.Size = New Size(106, 28)
        Button3.TabIndex = 5
        Button3.Text = "🔍 Buscar"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(27, 24)
        Label2.Name = "Label2"
        Label2.Size = New Size(45, 15)
        Label2.TabIndex = 6
        Label2.Text = "Paso 1:"
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(txtAltoEtiq)
        GroupBox1.Controls.Add(Label6)
        GroupBox1.Controls.Add(txtAnchoEtiq)
        GroupBox1.Controls.Add(Label5)
        GroupBox1.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        GroupBox1.Location = New Point(19, 18)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(767, 64)
        GroupBox1.TabIndex = 9
        GroupBox1.TabStop = False
        GroupBox1.Text = "Propiedades de la etiqueta:"
        ' 
        ' txtAltoEtiq
        ' 
        txtAltoEtiq.Font = New Font("Segoe UI", 9F)
        txtAltoEtiq.Location = New Point(171, 16)
        txtAltoEtiq.MaxLength = 4
        txtAltoEtiq.Name = "txtAltoEtiq"
        txtAltoEtiq.Size = New Size(51, 23)
        txtAltoEtiq.TabIndex = 3
        txtAltoEtiq.Text = "230"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 9F)
        Label6.Location = New Point(128, 19)
        Label6.Name = "Label6"
        Label6.Size = New Size(32, 15)
        Label6.TabIndex = 2
        Label6.Text = "Alto:"
        ' 
        ' txtAnchoEtiq
        ' 
        txtAnchoEtiq.Font = New Font("Segoe UI", 9F)
        txtAnchoEtiq.Location = New Point(49, 16)
        txtAnchoEtiq.MaxLength = 4
        txtAnchoEtiq.Name = "txtAnchoEtiq"
        txtAnchoEtiq.Size = New Size(51, 23)
        txtAnchoEtiq.TabIndex = 1
        txtAnchoEtiq.Text = "200"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 9F)
        Label5.Location = New Point(6, 19)
        Label5.Name = "Label5"
        Label5.Size = New Size(45, 15)
        Label5.TabIndex = 0
        Label5.Text = "Ancho:"
        ' 
        ' ProgressBar1
        ' 
        ProgressBar1.Location = New Point(19, 670)
        ProgressBar1.Name = "ProgressBar1"
        ProgressBar1.Size = New Size(765, 10)
        ProgressBar1.TabIndex = 10
        ProgressBar1.Visible = False
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(338, 694)
        Label7.Name = "Label7"
        Label7.Size = New Size(152, 15)
        Label7.TabIndex = 11
        Label7.Text = "© Emmanuel Mejía Castillo"
        ' 
        ' TabControl1
        ' 
        TabControl1.Controls.Add(TabPage1)
        TabControl1.Controls.Add(TabPage2)
        TabControl1.Controls.Add(TabPage3)
        TabControl1.Dock = DockStyle.Fill
        TabControl1.Location = New Point(0, 0)
        TabControl1.Name = "TabControl1"
        TabControl1.SelectedIndex = 0
        TabControl1.Size = New Size(817, 766)
        TabControl1.TabIndex = 12
        ' 
        ' TabPage1
        ' 
        TabPage1.Controls.Add(Label3)
        TabPage1.Controls.Add(Label2)
        TabPage1.Controls.Add(Label4)
        TabPage1.Controls.Add(Label1)
        TabPage1.Controls.Add(Button1)
        TabPage1.Controls.Add(TextBox1)
        TabPage1.Controls.Add(Button3)
        TabPage1.Location = New Point(4, 24)
        TabPage1.Name = "TabPage1"
        TabPage1.Padding = New Padding(3)
        TabPage1.Size = New Size(809, 738)
        TabPage1.TabIndex = 0
        TabPage1.Text = "Archivo"
        TabPage1.UseVisualStyleBackColor = True
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(27, 113)
        Label3.Name = "Label3"
        Label3.Size = New Size(45, 15)
        Label3.TabIndex = 13
        Label3.Text = "Paso 2:"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(27, 131)
        Label4.Name = "Label4"
        Label4.Size = New Size(149, 15)
        Label4.TabIndex = 14
        Label4.Text = "Extrae los datos en la tabla:"
        ' 
        ' TabPage2
        ' 
        TabPage2.Controls.Add(DataGridView1)
        TabPage2.Location = New Point(4, 24)
        TabPage2.Name = "TabPage2"
        TabPage2.Padding = New Padding(3)
        TabPage2.Size = New Size(809, 738)
        TabPage2.TabIndex = 1
        TabPage2.Text = "Datos"
        TabPage2.UseVisualStyleBackColor = True
        ' 
        ' TabPage3
        ' 
        TabPage3.Controls.Add(GroupBox1)
        TabPage3.Controls.Add(Label7)
        TabPage3.Controls.Add(Button2)
        TabPage3.Controls.Add(ProgressBar1)
        TabPage3.Location = New Point(4, 24)
        TabPage3.Name = "TabPage3"
        TabPage3.Padding = New Padding(3)
        TabPage3.Size = New Size(809, 738)
        TabPage3.TabIndex = 2
        TabPage3.Text = "Propiedades de la Etiqueta"
        TabPage3.UseVisualStyleBackColor = True
        ' 
        ' form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(817, 766)
        Controls.Add(TabControl1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Generador de Codigos QR"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        TabControl1.ResumeLayout(False)
        TabPage1.ResumeLayout(False)
        TabPage1.PerformLayout()
        TabPage2.ResumeLayout(False)
        TabPage3.ResumeLayout(False)
        TabPage3.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button3 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtAnchoEtiq As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtAltoEtiq As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Label7 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage


End Class
