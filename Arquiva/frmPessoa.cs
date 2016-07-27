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
    public partial class frmPessoa : Form
    {
        #region Field
        private List<Pessoa> _pessoas;
        
        #endregion

        #region ctor
        public frmPessoa()
        {
            InitializeComponent();

            _pessoas = FileHelper.RecuperarPessoas();

            cbLocal.SelectedIndex = 0;

            PreencherLista();
        }
        
        #endregion


        #region - PreencherLista
        private void PreencherLista()
        {
            lbPessoas.Items.Clear();

            foreach (var pessoa in _pessoas.Where(d => d.Local == cbLocal.SelectedItem.ToString()).OrderBy(d => d.Nome))
                lbPessoas.Items.Add(pessoa.Nome);
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

            _pessoas.Add(new Pessoa
            {
                Local = cbLocal.SelectedItem.ToString(),
                Nome = txtNome.Text
            });

            if (!FileHelper.SalvarPessoas(_pessoas))
            {
                MessageBox.Show("Não foi possível salvar a pessoa, tente novamente.");
                return;
            }

            PreencherLista();
        }
        
        #endregion

        #region lbPessoas DoubleClick
        private void lbPessoas_DoubleClick(object sender, EventArgs e)
        {

            if (lbPessoas.SelectedIndex < 0)
                return;

            if (MessageBox.Show("Confirma a exclusão?", "Atenção", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                return;

            var pessoa = _pessoas.Find(d => d.Local == cbLocal.SelectedItem.ToString() && d.Nome == lbPessoas.SelectedItem.ToString());

            if (pessoa == null)
                return;

            _pessoas.Remove(pessoa);

            if (!FileHelper.SalvarPessoas(_pessoas))
            {
                MessageBox.Show("Não foi possível excluir a pessoa, tente novamente.");
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
