namespace Ponto.Forms
{
    partial class frmPonto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPonto));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblHora = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnGravar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnXls = new System.Windows.Forms.Button();
            this.dtgRel = new System.Windows.Forms.DataGridView();
            this.cboFunc = new System.Windows.Forms.ComboBox();
            this.cboEmpresa = new System.Windows.Forms.ComboBox();
            this.dtPicker2 = new System.Windows.Forms.DateTimePicker();
            this.dtPicker1 = new System.Windows.Forms.DateTimePicker();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lblId_C = new System.Windows.Forms.Label();
            this.btnExcluir_C = new System.Windows.Forms.Button();
            this.btnGravar_C = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtgCad = new System.Windows.Forms.DataGridView();
            this.cboStatus_C = new System.Windows.Forms.ComboBox();
            this.txtNome_C = new System.Windows.Forms.TextBox();
            this.txtCPF_C = new System.Windows.Forms.TextBox();
            this.cboEmpresa_C = new System.Windows.Forms.ComboBox();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgRel)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCad)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3});
            this.statusStrip1.Location = new System.Drawing.Point(0, 193);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(647, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AutoSize = false;
            this.toolStripStatusLabel1.BackColor = System.Drawing.Color.White;
            this.toolStripStatusLabel1.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(200, 17);
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.AutoSize = false;
            this.toolStripStatusLabel2.BackColor = System.Drawing.Color.White;
            this.toolStripStatusLabel2.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(330, 17);
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.AutoSize = false;
            this.toolStripStatusLabel3.BackColor = System.Drawing.Color.White;
            this.toolStripStatusLabel3.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel3.ForeColor = System.Drawing.Color.Black;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(80, 17);
            this.toolStripStatusLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(646, 197);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Black;
            this.tabPage1.Controls.Add(this.lblHora);
            this.tabPage1.Controls.Add(this.listBox1);
            this.tabPage1.Controls.Add(this.btnGravar);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(638, 171);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Horário";
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.BackColor = System.Drawing.Color.Transparent;
            this.lblHora.Font = new System.Drawing.Font("Verdana", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHora.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblHora.Location = new System.Drawing.Point(74, 39);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(206, 45);
            this.lblHora.TabIndex = 7;
            this.lblHora.Text = "00:00:00";
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.Black;
            this.listBox1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.ForeColor = System.Drawing.Color.White;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(510, 44);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(94, 84);
            this.listBox1.TabIndex = 6;
            // 
            // btnGravar
            // 
            this.btnGravar.Image = global::Ponto.Properties.Resources.botao02;
            this.btnGravar.Location = new System.Drawing.Point(422, 44);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(62, 57);
            this.btnGravar.TabIndex = 5;
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Ponto.Properties.Resources.Visor01;
            this.pictureBox1.Location = new System.Drawing.Point(35, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(355, 121);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.LightGray;
            this.tabPage2.Controls.Add(this.btnXls);
            this.tabPage2.Controls.Add(this.dtgRel);
            this.tabPage2.Controls.Add(this.cboFunc);
            this.tabPage2.Controls.Add(this.cboEmpresa);
            this.tabPage2.Controls.Add(this.dtPicker2);
            this.tabPage2.Controls.Add(this.dtPicker1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(638, 171);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Relatório";
            // 
            // btnXls
            // 
            this.btnXls.Image = global::Ponto.Properties.Resources.EXCEL;
            this.btnXls.Location = new System.Drawing.Point(582, 33);
            this.btnXls.Name = "btnXls";
            this.btnXls.Size = new System.Drawing.Size(39, 38);
            this.btnXls.TabIndex = 9;
            this.btnXls.UseVisualStyleBackColor = true;
            this.btnXls.Click += new System.EventHandler(this.btnXls_Click);
            // 
            // dtgRel
            // 
            this.dtgRel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgRel.Location = new System.Drawing.Point(25, 33);
            this.dtgRel.Name = "dtgRel";
            this.dtgRel.Size = new System.Drawing.Size(554, 132);
            this.dtgRel.TabIndex = 5;
            // 
            // cboFunc
            // 
            this.cboFunc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFunc.FormattingEnabled = true;
            this.cboFunc.Location = new System.Drawing.Point(397, 5);
            this.cboFunc.Name = "cboFunc";
            this.cboFunc.Size = new System.Drawing.Size(224, 21);
            this.cboFunc.TabIndex = 3;
            this.cboFunc.SelectedIndexChanged += new System.EventHandler(this.cboFunc_SelectedIndexChanged);
            // 
            // cboEmpresa
            // 
            this.cboEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmpresa.FormattingEnabled = true;
            this.cboEmpresa.Location = new System.Drawing.Point(230, 6);
            this.cboEmpresa.Name = "cboEmpresa";
            this.cboEmpresa.Size = new System.Drawing.Size(146, 21);
            this.cboEmpresa.TabIndex = 2;
            this.cboEmpresa.SelectedIndexChanged += new System.EventHandler(this.cboEmpresa_SelectedIndexChanged);
            // 
            // dtPicker2
            // 
            this.dtPicker2.CalendarTrailingForeColor = System.Drawing.Color.Gray;
            this.dtPicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPicker2.Location = new System.Drawing.Point(126, 6);
            this.dtPicker2.Name = "dtPicker2";
            this.dtPicker2.Size = new System.Drawing.Size(79, 20);
            this.dtPicker2.TabIndex = 1;
            this.dtPicker2.ValueChanged += new System.EventHandler(this.dtPicker2_ValueChanged);
            // 
            // dtPicker1
            // 
            this.dtPicker1.CalendarTrailingForeColor = System.Drawing.Color.Gray;
            this.dtPicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPicker1.Location = new System.Drawing.Point(25, 6);
            this.dtPicker1.Name = "dtPicker1";
            this.dtPicker1.Size = new System.Drawing.Size(79, 20);
            this.dtPicker1.TabIndex = 0;
            this.dtPicker1.ValueChanged += new System.EventHandler(this.dtPicker1_ValueChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.LightGray;
            this.tabPage3.Controls.Add(this.lblId_C);
            this.tabPage3.Controls.Add(this.btnExcluir_C);
            this.tabPage3.Controls.Add(this.btnGravar_C);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.dtgCad);
            this.tabPage3.Controls.Add(this.cboStatus_C);
            this.tabPage3.Controls.Add(this.txtNome_C);
            this.tabPage3.Controls.Add(this.txtCPF_C);
            this.tabPage3.Controls.Add(this.cboEmpresa_C);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(638, 171);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Cadastro";
            // 
            // lblId_C
            // 
            this.lblId_C.AutoSize = true;
            this.lblId_C.Location = new System.Drawing.Point(618, 143);
            this.lblId_C.Name = "lblId_C";
            this.lblId_C.Size = new System.Drawing.Size(13, 13);
            this.lblId_C.TabIndex = 16;
            this.lblId_C.Text = "0";
            // 
            // btnExcluir_C
            // 
            this.btnExcluir_C.Location = new System.Drawing.Point(264, 125);
            this.btnExcluir_C.Name = "btnExcluir_C";
            this.btnExcluir_C.Size = new System.Drawing.Size(86, 31);
            this.btnExcluir_C.TabIndex = 15;
            this.btnExcluir_C.Text = "Excluir";
            this.btnExcluir_C.UseVisualStyleBackColor = true;
            this.btnExcluir_C.Click += new System.EventHandler(this.btnExcluir_C_Click);
            // 
            // btnGravar_C
            // 
            this.btnGravar_C.Location = new System.Drawing.Point(75, 125);
            this.btnGravar_C.Name = "btnGravar_C";
            this.btnGravar_C.Size = new System.Drawing.Size(86, 31);
            this.btnGravar_C.TabIndex = 14;
            this.btnGravar_C.Text = "Gravar";
            this.btnGravar_C.UseVisualStyleBackColor = true;
            this.btnGravar_C.Click += new System.EventHandler(this.btnGravar_C_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Status";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Nome";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "CPF";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Empresa";
            // 
            // dtgCad
            // 
            this.dtgCad.Location = new System.Drawing.Point(376, 18);
            this.dtgCad.Name = "dtgCad";
            this.dtgCad.RowHeadersVisible = false;
            this.dtgCad.Size = new System.Drawing.Size(240, 138);
            this.dtgCad.TabIndex = 7;
            this.dtgCad.DoubleClick += new System.EventHandler(this.dtgCad_DoubleClick);
            // 
            // cboStatus_C
            // 
            this.cboStatus_C.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus_C.FormattingEnabled = true;
            this.cboStatus_C.Location = new System.Drawing.Point(75, 97);
            this.cboStatus_C.Name = "cboStatus_C";
            this.cboStatus_C.Size = new System.Drawing.Size(149, 21);
            this.cboStatus_C.TabIndex = 5;
            // 
            // txtNome_C
            // 
            this.txtNome_C.Location = new System.Drawing.Point(75, 71);
            this.txtNome_C.MaxLength = 30;
            this.txtNome_C.Name = "txtNome_C";
            this.txtNome_C.Size = new System.Drawing.Size(275, 20);
            this.txtNome_C.TabIndex = 4;
            this.txtNome_C.Leave += new System.EventHandler(this.txtNome_C_Leave);
            // 
            // txtCPF_C
            // 
            this.txtCPF_C.Location = new System.Drawing.Point(75, 45);
            this.txtCPF_C.MaxLength = 11;
            this.txtCPF_C.Name = "txtCPF_C";
            this.txtCPF_C.Size = new System.Drawing.Size(149, 20);
            this.txtCPF_C.TabIndex = 3;
            this.txtCPF_C.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCPF_C_KeyPress);
            this.txtCPF_C.Leave += new System.EventHandler(this.txtCPF_C_Leave);
            // 
            // cboEmpresa_C
            // 
            this.cboEmpresa_C.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmpresa_C.FormattingEnabled = true;
            this.cboEmpresa_C.Location = new System.Drawing.Point(75, 18);
            this.cboEmpresa_C.Name = "cboEmpresa_C";
            this.cboEmpresa_C.Size = new System.Drawing.Size(275, 21);
            this.cboEmpresa_C.TabIndex = 1;
            this.cboEmpresa_C.SelectedIndexChanged += new System.EventHandler(this.cboEmpresa_C_SelectedIndexChanged);
            // 
            // frmPonto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(647, 215);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPonto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Resize += new System.EventHandler(this.frmPonto_Resize);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgRel)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dtgRel;
        private System.Windows.Forms.ComboBox cboFunc;
        private System.Windows.Forms.ComboBox cboEmpresa;
        private System.Windows.Forms.DateTimePicker dtPicker2;
        private System.Windows.Forms.DateTimePicker dtPicker1;
        private System.Windows.Forms.Button btnXls;
        private System.Windows.Forms.Button btnExcluir_C;
        private System.Windows.Forms.Button btnGravar_C;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtgCad;
        private System.Windows.Forms.ComboBox cboStatus_C;
        private System.Windows.Forms.TextBox txtNome_C;
        private System.Windows.Forms.TextBox txtCPF_C;
        private System.Windows.Forms.ComboBox cboEmpresa_C;
        private System.Windows.Forms.Label lblId_C;
    }
}