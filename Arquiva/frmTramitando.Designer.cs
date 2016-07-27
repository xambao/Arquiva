namespace Arquiva
{
    partial class frmTramitando
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Interno", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Externo", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTramitando));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbExterno = new System.Windows.Forms.RadioButton();
            this.rbInterno = new System.Windows.Forms.RadioButton();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.cbDestino = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbResponsavel = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAssunto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.mcPrevista = new System.Windows.Forms.MonthCalendar();
            this.label2 = new System.Windows.Forms.Label();
            this.mcEntrada = new System.Windows.Forms.MonthCalendar();
            this.txtREG = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbResumo = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lvResultado = new System.Windows.Forms.ListView();
            this.chREG = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDtEntrada = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDtPrevista = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDtSaida = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chResponsavel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDestino = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chAssunto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsResultado = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiEditar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiArquivar = new System.Windows.Forms.ToolStripMenuItem();
            this.gbEnvio = new System.Windows.Forms.GroupBox();
            this.mcEnvio = new System.Windows.Forms.MonthCalendar();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.cmsResultado.SuspendLayout();
            this.gbEnvio.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gbEnvio);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.btnNovo);
            this.groupBox1.Controls.Add(this.btnSalvar);
            this.groupBox1.Controls.Add(this.cbDestino);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cbResponsavel);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtAssunto);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.mcPrevista);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.mcEntrada);
            this.groupBox1.Controls.Add(this.txtREG);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1295, 212);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cadastro";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rbExterno);
            this.groupBox4.Controls.Add(this.rbInterno);
            this.groupBox4.Location = new System.Drawing.Point(1008, 107);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(280, 70);
            this.groupBox4.TabIndex = 16;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Local atual:";
            // 
            // rbExterno
            // 
            this.rbExterno.AutoSize = true;
            this.rbExterno.Location = new System.Drawing.Point(7, 47);
            this.rbExterno.Name = "rbExterno";
            this.rbExterno.Size = new System.Drawing.Size(135, 17);
            this.rbExterno.TabIndex = 1;
            this.rbExterno.Text = "Externo (fora da seção)";
            this.rbExterno.UseVisualStyleBackColor = true;
            this.rbExterno.CheckedChanged += new System.EventHandler(this.rbExterno_CheckedChanged);
            // 
            // rbInterno
            // 
            this.rbInterno.AutoSize = true;
            this.rbInterno.Checked = true;
            this.rbInterno.Location = new System.Drawing.Point(7, 20);
            this.rbInterno.Name = "rbInterno";
            this.rbInterno.Size = new System.Drawing.Size(144, 17);
            this.rbInterno.TabIndex = 0;
            this.rbInterno.TabStop = true;
            this.rbInterno.Text = "Interno (dentro da seção)";
            this.rbInterno.UseVisualStyleBackColor = true;
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(1132, 183);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(75, 23);
            this.btnNovo.TabIndex = 15;
            this.btnNovo.Text = "Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(1213, 183);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 14;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // cbDestino
            // 
            this.cbDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDestino.FormattingEnabled = true;
            this.cbDestino.Location = new System.Drawing.Point(1008, 80);
            this.cbDestino.Name = "cbDestino";
            this.cbDestino.Size = new System.Drawing.Size(280, 21);
            this.cbDestino.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1005, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Destino:";
            // 
            // cbResponsavel
            // 
            this.cbResponsavel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbResponsavel.FormattingEnabled = true;
            this.cbResponsavel.Location = new System.Drawing.Point(1004, 36);
            this.cbResponsavel.Name = "cbResponsavel";
            this.cbResponsavel.Size = new System.Drawing.Size(284, 21);
            this.cbResponsavel.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1001, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Responsável:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Assunto:";
            // 
            // txtAssunto
            // 
            this.txtAssunto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAssunto.Location = new System.Drawing.Point(6, 94);
            this.txtAssunto.Multiline = true;
            this.txtAssunto.Name = "txtAssunto";
            this.txtAssunto.Size = new System.Drawing.Size(257, 104);
            this.txtAssunto.TabIndex = 8;
            this.txtAssunto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAssunto_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(517, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(187, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Data de prevista para a próxima ação:";
            // 
            // mcPrevista
            // 
            this.mcPrevista.Location = new System.Drawing.Point(520, 36);
            this.mcPrevista.MaxSelectionCount = 1;
            this.mcPrevista.Name = "mcPrevista";
            this.mcPrevista.ShowToday = false;
            this.mcPrevista.ShowTodayCircle = false;
            this.mcPrevista.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(275, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Data de entrada:";
            // 
            // mcEntrada
            // 
            this.mcEntrada.Location = new System.Drawing.Point(275, 36);
            this.mcEntrada.MaxSelectionCount = 1;
            this.mcEntrada.Name = "mcEntrada";
            this.mcEntrada.TabIndex = 2;
            this.mcEntrada.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.mcEntrada_DateChanged);
            // 
            // txtREG
            // 
            this.txtREG.Location = new System.Drawing.Point(10, 36);
            this.txtREG.Name = "txtREG";
            this.txtREG.Size = new System.Drawing.Size(253, 20);
            this.txtREG.TabIndex = 1;
            this.txtREG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "REG:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lbResumo);
            this.groupBox2.Location = new System.Drawing.Point(1313, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(209, 212);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Resumo:";
            // 
            // lbResumo
            // 
            this.lbResumo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbResumo.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbResumo.FormattingEnabled = true;
            this.lbResumo.ItemHeight = 16;
            this.lbResumo.Location = new System.Drawing.Point(3, 16);
            this.lbResumo.Name = "lbResumo";
            this.lbResumo.Size = new System.Drawing.Size(203, 193);
            this.lbResumo.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.lvResultado);
            this.groupBox3.Location = new System.Drawing.Point(12, 230);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1507, 366);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Resultado:";
            // 
            // lvResultado
            // 
            this.lvResultado.BackColor = System.Drawing.SystemColors.Window;
            this.lvResultado.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chREG,
            this.chDtEntrada,
            this.chDtPrevista,
            this.chDtSaida,
            this.chResponsavel,
            this.chDestino,
            this.chAssunto});
            this.lvResultado.ContextMenuStrip = this.cmsResultado;
            this.lvResultado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvResultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvResultado.FullRowSelect = true;
            this.lvResultado.GridLines = true;
            listViewGroup1.Header = "Interno";
            listViewGroup1.Name = "lvgInterno";
            listViewGroup2.Header = "Externo";
            listViewGroup2.Name = "lvgExterno";
            this.lvResultado.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            this.lvResultado.Location = new System.Drawing.Point(3, 16);
            this.lvResultado.MultiSelect = false;
            this.lvResultado.Name = "lvResultado";
            this.lvResultado.Size = new System.Drawing.Size(1501, 347);
            this.lvResultado.TabIndex = 1;
            this.lvResultado.UseCompatibleStateImageBehavior = false;
            this.lvResultado.View = System.Windows.Forms.View.Details;
            // 
            // chREG
            // 
            this.chREG.Text = "REG";
            this.chREG.Width = 140;
            // 
            // chDtEntrada
            // 
            this.chDtEntrada.Text = "Entrada";
            this.chDtEntrada.Width = 80;
            // 
            // chDtPrevista
            // 
            this.chDtPrevista.Text = "Prevista";
            this.chDtPrevista.Width = 80;
            // 
            // chDtSaida
            // 
            this.chDtSaida.Text = "Saída";
            this.chDtSaida.Width = 80;
            // 
            // chResponsavel
            // 
            this.chResponsavel.Text = "Responsável";
            this.chResponsavel.Width = 180;
            // 
            // chDestino
            // 
            this.chDestino.Text = "Destino";
            this.chDestino.Width = 180;
            // 
            // chAssunto
            // 
            this.chAssunto.Text = "Assunto";
            this.chAssunto.Width = 460;
            // 
            // cmsResultado
            // 
            this.cmsResultado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiEditar,
            this.tsmiArquivar});
            this.cmsResultado.Name = "cmsResultado";
            this.cmsResultado.Size = new System.Drawing.Size(120, 48);
            // 
            // tsmiEditar
            // 
            this.tsmiEditar.Name = "tsmiEditar";
            this.tsmiEditar.Size = new System.Drawing.Size(119, 22);
            this.tsmiEditar.Text = "Editar";
            this.tsmiEditar.Click += new System.EventHandler(this.tsmiEditar_Click);
            // 
            // tsmiArquivar
            // 
            this.tsmiArquivar.Name = "tsmiArquivar";
            this.tsmiArquivar.Size = new System.Drawing.Size(119, 22);
            this.tsmiArquivar.Text = "Arquivar";
            this.tsmiArquivar.Click += new System.EventHandler(this.tsmiArquivar_Click);
            // 
            // gbEnvio
            // 
            this.gbEnvio.Controls.Add(this.mcEnvio);
            this.gbEnvio.Enabled = false;
            this.gbEnvio.Location = new System.Drawing.Point(753, 20);
            this.gbEnvio.Name = "gbEnvio";
            this.gbEnvio.Size = new System.Drawing.Size(229, 178);
            this.gbEnvio.TabIndex = 17;
            this.gbEnvio.TabStop = false;
            this.gbEnvio.Text = "Data de envio para o destino:";
            // 
            // mcEnvio
            // 
            this.mcEnvio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mcEnvio.Location = new System.Drawing.Point(3, 16);
            this.mcEnvio.MaxSelectionCount = 1;
            this.mcEnvio.Name = "mcEnvio";
            this.mcEnvio.ShowToday = false;
            this.mcEnvio.ShowTodayCircle = false;
            this.mcEnvio.TabIndex = 6;
            // 
            // frmTramitando
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1534, 598);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTramitando";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Tramitando";
            this.Shown += new System.EventHandler(this.frmTramitando_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.cmsResultado.ResumeLayout(false);
            this.gbEnvio.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.ComboBox cbDestino;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbResponsavel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MonthCalendar mcPrevista;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MonthCalendar mcEntrada;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lbResumo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rbExterno;
        private System.Windows.Forms.RadioButton rbInterno;
        private System.Windows.Forms.ListView lvResultado;
        private System.Windows.Forms.ColumnHeader chDtEntrada;
        private System.Windows.Forms.ColumnHeader chDtPrevista;
        private System.Windows.Forms.ColumnHeader chDtSaida;
        private System.Windows.Forms.ColumnHeader chResponsavel;
        private System.Windows.Forms.ColumnHeader chDestino;
        private System.Windows.Forms.ColumnHeader chAssunto;
        private System.Windows.Forms.ColumnHeader chREG;
        private System.Windows.Forms.ContextMenuStrip cmsResultado;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditar;
        private System.Windows.Forms.ToolStripMenuItem tsmiArquivar;
        public System.Windows.Forms.TextBox txtREG;
        public System.Windows.Forms.TextBox txtAssunto;
        private System.Windows.Forms.GroupBox gbEnvio;
        private System.Windows.Forms.MonthCalendar mcEnvio;
    }
}