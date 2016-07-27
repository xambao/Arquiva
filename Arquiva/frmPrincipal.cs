using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Arquiva
{
    public partial class frmPrincipal : Form
    {

        #region Prop Form Arquivados
        private frmArquiva _arquivados;
        public frmArquiva Arquivados
        {
            get
            {


                if (_arquivados == null || _arquivados.IsDisposed)
                    _arquivados = new frmArquiva();

                _arquivados.MdiParent = this;

                return _arquivados;
            }
        }
        #endregion

        #region Prop Form Tramitando
        private frmTramitando _tramitando;
        public frmTramitando Tramitando
        {
            get
            {
                if (_tramitando == null || _tramitando.IsDisposed)
                    _tramitando = new frmTramitando();

                _tramitando.MdiParent = this;

                return _tramitando;
            }
        }
        #endregion

        #region Prop Form Sobre
        private frmSobre _sobre;
        public frmSobre Sobre
        {
            get
            {


                if (_sobre == null || _sobre.IsDisposed)
                    _sobre = new frmSobre();

                return _sobre;
            }
        }
        #endregion

        #region Prop Form Pessoas
        private frmPessoa _pessoas;
        public frmPessoa Pessoas
        {
            get
            {


                if (_pessoas == null || _pessoas.IsDisposed)
                    _pessoas = new frmPessoa();

                _pessoas.MdiParent = this;

                return _pessoas;
            }
        }
        #endregion

        #region Prop Form Destino
        private frmDestino _destino;
        public frmDestino Destino
        {
            get
            {


                if (_destino == null || _destino.IsDisposed)
                    _destino = new frmDestino();

                _destino.MdiParent = this;

                return _destino;
            }
        }
        #endregion

        #region ctor
        public frmPrincipal()
        {
            InitializeComponent();
        }

        #endregion

        #region frmPrincipal Load
        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            Text = "Arquiva: " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        #endregion

        #region mnArquivados Click
        private void mnArquivados_Click(object sender, EventArgs e)
        {
            Arquivados.Show();
        }
        
        #endregion

        #region mnSair Click
        private void mnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        #endregion
        
        #region mnSobre Click
        private void mnSobre_Click(object sender, EventArgs e)
        {
            Sobre.ShowDialog(this);
        }
        
        #endregion

        #region mnPessoas Click
		private void mnPessoas_Click(object sender, EventArgs e)
        {
            Pessoas.Show();
        }
 
	    #endregion    

        #region mnDestino Click
        private void mnDestino_Click(object sender, EventArgs e)
        {
            Destino.Show();
        }
        
        #endregion

        #region mnTramitando Click
        private void mnTramitando_Click(object sender, EventArgs e)
        {
            Tramitando.Show();
        }
        
        #endregion
    }
}
