namespace Arquiva
{
    partial class frmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.mnPrincipal = new System.Windows.Forms.MenuStrip();
            this.mnProtocolo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnArquivados = new System.Windows.Forms.ToolStripMenuItem();
            this.mnTramitando = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnSair = new System.Windows.Forms.ToolStripMenuItem();
            this.mnCadastro = new System.Windows.Forms.ToolStripMenuItem();
            this.mnPessoas = new System.Windows.Forms.ToolStripMenuItem();
            this.mnDestino = new System.Windows.Forms.ToolStripMenuItem();
            this.mnAjuda = new System.Windows.Forms.ToolStripMenuItem();
            this.mnSobre = new System.Windows.Forms.ToolStripMenuItem();
            this.mnJanela = new System.Windows.Forms.ToolStripMenuItem();
            this.mnPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnPrincipal
            // 
            this.mnPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnProtocolo,
            this.mnCadastro,
            this.mnJanela,
            this.mnAjuda});
            this.mnPrincipal.Location = new System.Drawing.Point(0, 0);
            this.mnPrincipal.MdiWindowListItem = this.mnJanela;
            this.mnPrincipal.Name = "mnPrincipal";
            this.mnPrincipal.Size = new System.Drawing.Size(1037, 24);
            this.mnPrincipal.TabIndex = 1;
            this.mnPrincipal.Text = "Menu Principal";
            // 
            // mnProtocolo
            // 
            this.mnProtocolo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnArquivados,
            this.mnTramitando,
            this.toolStripMenuItem1,
            this.mnSair});
            this.mnProtocolo.Name = "mnProtocolo";
            this.mnProtocolo.Size = new System.Drawing.Size(71, 20);
            this.mnProtocolo.Text = "Protocolo";
            // 
            // mnArquivados
            // 
            this.mnArquivados.Name = "mnArquivados";
            this.mnArquivados.Size = new System.Drawing.Size(136, 22);
            this.mnArquivados.Text = "Arquivados";
            this.mnArquivados.Click += new System.EventHandler(this.mnArquivados_Click);
            // 
            // mnTramitando
            // 
            this.mnTramitando.Name = "mnTramitando";
            this.mnTramitando.Size = new System.Drawing.Size(136, 22);
            this.mnTramitando.Text = "Tramitando";
            this.mnTramitando.Click += new System.EventHandler(this.mnTramitando_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(133, 6);
            // 
            // mnSair
            // 
            this.mnSair.Name = "mnSair";
            this.mnSair.Size = new System.Drawing.Size(136, 22);
            this.mnSair.Text = "Sair";
            this.mnSair.Click += new System.EventHandler(this.mnSair_Click);
            // 
            // mnCadastro
            // 
            this.mnCadastro.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnPessoas,
            this.mnDestino});
            this.mnCadastro.Name = "mnCadastro";
            this.mnCadastro.Size = new System.Drawing.Size(66, 20);
            this.mnCadastro.Text = "Cadastro";
            // 
            // mnPessoas
            // 
            this.mnPessoas.Name = "mnPessoas";
            this.mnPessoas.Size = new System.Drawing.Size(196, 22);
            this.mnPessoas.Text = "Pessoas - Responsáveis";
            this.mnPessoas.Click += new System.EventHandler(this.mnPessoas_Click);
            // 
            // mnDestino
            // 
            this.mnDestino.Name = "mnDestino";
            this.mnDestino.Size = new System.Drawing.Size(196, 22);
            this.mnDestino.Text = "Destinos";
            this.mnDestino.Click += new System.EventHandler(this.mnDestino_Click);
            // 
            // mnAjuda
            // 
            this.mnAjuda.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnSobre});
            this.mnAjuda.Name = "mnAjuda";
            this.mnAjuda.Size = new System.Drawing.Size(50, 20);
            this.mnAjuda.Text = "Ajuda";
            // 
            // mnSobre
            // 
            this.mnSobre.Name = "mnSobre";
            this.mnSobre.Size = new System.Drawing.Size(104, 22);
            this.mnSobre.Text = "Sobre";
            this.mnSobre.Click += new System.EventHandler(this.mnSobre_Click);
            // 
            // mnJanela
            // 
            this.mnJanela.Name = "mnJanela";
            this.mnJanela.Size = new System.Drawing.Size(56, 20);
            this.mnJanela.Text = "Janelas";
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 459);
            this.Controls.Add(this.mnPrincipal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnPrincipal;
            this.Name = "frmPrincipal";
            this.Text = "Arquiva";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.mnPrincipal.ResumeLayout(false);
            this.mnPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnPrincipal;
        private System.Windows.Forms.ToolStripMenuItem mnProtocolo;
        private System.Windows.Forms.ToolStripMenuItem mnArquivados;
        private System.Windows.Forms.ToolStripMenuItem mnTramitando;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnSair;
        private System.Windows.Forms.ToolStripMenuItem mnAjuda;
        private System.Windows.Forms.ToolStripMenuItem mnSobre;
        private System.Windows.Forms.ToolStripMenuItem mnCadastro;
        private System.Windows.Forms.ToolStripMenuItem mnPessoas;
        private System.Windows.Forms.ToolStripMenuItem mnDestino;
        private System.Windows.Forms.ToolStripMenuItem mnJanela;
    }
}