using Arquiva.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Arquiva
{
    public partial class frmDestino : Form
    {
        #region Field
        private List<Destino> _destinos;

        #endregion

        #region ctor
        public frmDestino()
        {
            InitializeComponent();

            _destinos = FileHelper.RecuperarDestinos();

            cbLocal.SelectedIndex = 0;

            PreencherLista();
        }

        #endregion


        #region - PreencherLista
        private void PreencherLista()
        {
            lbDestino.Items.Clear();

            foreach (var destino in _destinos.Where(d => d.Local == cbLocal.SelectedItem.ToString()).OrderBy(d => d.Nome))
                lbDestino.Items.Add(destino.Nome);
        }

        #endregion

        #region btnSalvar Click
        private void btnSalvar_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrWhiteSpace(txtNome.Text) || txtNome.Text.Length < 3)
            {
                MessageBox.Show("Preencha pelo menos 3 letras.");
                return;
            }

            if (MessageBox.Show("Confirma a operação?", "Atenção", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                return;

            _destinos.Add(new Destino
            {
                Local = cbLocal.SelectedItem.ToString(),
                Nome = txtNome.Text
            });

            if (!FileHelper.SalvarDestinos(_destinos))
            {
                MessageBox.Show("Não foi possível salvar o destino, tente novamente.");
                return;
            }

            PreencherLista();
        }

        #endregion

        #region lbDestino DoubleClick
        private void lbDestino_DoubleClick(object sender, EventArgs e)
        {

            if (lbDestino.SelectedIndex < 0)
                return;

            if (MessageBox.Show("Confirma a exclusão?", "Atenção", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                return;

            var destino = _destinos.Find(d => d.Local == cbLocal.SelectedItem.ToString() && d.Nome == lbDestino.SelectedItem.ToString());

            if (destino == null)
                return;

            _destinos.Remove(destino);

            if (!FileHelper.SalvarDestinos(_destinos))
            {
                MessageBox.Show("Não foi possível excluir o destino, tente novamente.");
                return;
            }

            PreencherLista();

        }

        #endregion

        #region txtNome KeyPress
        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ';' ||
                e.KeyChar == '|')
                e.Handled = true;

            if ((sender as TextBox).Text.Length > 100)
                e.Handled = true;
        }

        #endregion

        #region cbLocal SelectedIndexChanged
        private void cbLocal_SelectedIndexChanged(object sender, EventArgs e)
        {
            PreencherLista();
        }

        #endregion
    }
}
