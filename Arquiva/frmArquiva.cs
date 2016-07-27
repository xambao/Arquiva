using Arquiva.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Arquiva
{
    public partial class frmArquiva : Form
    {
        #region Fields
        private const string PATTERN_LB = "{0} | {1} | {2} | {3} | {4}";
        private const string PATTERN_RESUMO = "{0} | {1} | {2} |";


        private readonly List<Documento> _documentos;
        private int _alterarIndex = -1;
        #endregion

        #region ctor
        public frmArquiva()
        {
            InitializeComponent();

            _documentos = FileHelper.RecuperarArquivados();

            PreencherResumo();
        }

        #endregion

        #region KeyPress txtREG
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.'
                && e.KeyChar != '-'
                && e.KeyChar != '/'
                )
            {
                e.Handled = true;
            }

            //if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            //    e.Handled = true;
            if (e.KeyChar == '-' && (sender as TextBox).Text.IndexOf('-') > -1)
                e.Handled = true;
            if (e.KeyChar == '/' && (sender as TextBox).Text.IndexOf('/') > -1)
                e.Handled = true;

            if ((sender as TextBox).Text.Length > 20)
                e.Handled = true;


            if ((sender as TextBox).Name == "txtPesquisar" && e.KeyChar == (char)13)
            {
                btnPesquisar_Click(sender, e);
            }
        }

        #endregion

        #region KeyPress txtAssunto
        private void txtAssunto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ';' ||
                e.KeyChar == '|')
                e.Handled = true;

            if ((sender as TextBox).Text.Length > 100)
                e.Handled = true;
        }

        #endregion

        #region Click btnSalvar
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtReg.Text))
            {
                MessageBox.Show("Preencha o campo REG");
                return;
            }

            if (MessageBox.Show("Confirma a alteração?", "Atenção", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                return;

            var aux = CleanString(txtReg.Text);
            var doc = _documentos.Find(d => d.REG.Trim() == aux);
            if (doc != null && _alterarIndex < 0)
            {
                MessageBox.Show("Esse número de REG já foi arquivado.");
                return;
            }

            //verifica se o documento existe
            if (doc == null)
            { 
                //se nao existir testa a pasta e o documento
                if (_documentos.Any(d => d.NumPasta == numPasta.Value && d.NumDocumento == numDocumento.Value))
                {
                    MessageBox.Show("Esse número de Documento, nessa Pasta ja foi usado.");
                    return;
                }

            }
            else
            {
                //se o documento existir verifica se esta tentando pegar o numero de outro documento
                if (_documentos.Any(d => d.Id != doc.Id && d.NumPasta == numPasta.Value && d.NumDocumento == numDocumento.Value))
                {
                    MessageBox.Show("Esse número de Documento, nessa Pasta ja foi usado.");
                    return;
                }
            }


            var tramites = FileHelper.RecuperarTramites();
            if (tramites.Any(t => t.REG.Trim() == aux))
            {
                MessageBox.Show("Esse número de REG está em tramitação.");
                return;
            }

            if (_alterarIndex < 0)
            {
                if (_documentos.Count > 0)
                    _alterarIndex = _documentos.Max(t => t.Id) + 1;
                else
                    _alterarIndex = 0;


                _documentos.Add(new Documento
                    {
                        Id = _alterarIndex,
                        REG = CleanString(txtReg.Text),
                        REGMasked = txtReg.Text.Trim(),
                        NumPasta = (int)numPasta.Value,
                        NumDocumento = (int)numDocumento.Value,
                        Assunto = txtAssunto.Text
                    });
            }
            else
            {

                var documento = _documentos.Find(d => d.Id == _alterarIndex);
                documento.Id = _alterarIndex;
                documento.REG = CleanString(txtReg.Text);
                documento.REGMasked = txtReg.Text.Trim();
                documento.NumPasta = (int)numPasta.Value;
                documento.NumDocumento = (int)numDocumento.Value;
                documento.Assunto = txtAssunto.Text;
            }


            if (!FileHelper.SalvarArquivados(_documentos))
            {
                MessageBox.Show("Houve um erro ao salvar o registro, porfavor tente novamente");
                return;
            }

            PreencherResumo();

            btnNovo_Click(sender, e);

            lbResultado.Items.Clear();
        }

        #endregion

        #region Click btnPesquisar
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtPesquisar.Text) || txtPesquisar.Text.Length < 3)
            {
                MessageBox.Show("Preencha pelo menos 3 numeros");
                return;
            }

            var resultado = _documentos.Where(s => Regex.IsMatch(s.REG, txtPesquisar.Text));

            PreencherResultado(resultado);
        }

        #endregion

        #region Click lbResultado
        private void lbResultado_Click(object sender, EventArgs e)
        {
            if (lbResultado.SelectedItem == null)
                return;

            var campos = lbResultado.SelectedItem.ToString().Split('|');

            if (!Int32.TryParse(campos[0], out _alterarIndex))
            {
                _alterarIndex = -1;
                return;
            }

            txtReg.Text = campos[1].Trim();

            int value;
            if (Int32.TryParse(campos[2], out value))
                numPasta.Value = value;

            if (Int32.TryParse(campos[3], out value))
                numDocumento.Value = value;

            txtAssunto.Text = campos[4];

            txtReg.Enabled = false;

        }

        #endregion

        #region Click btnNovo
        private void btnNovo_Click(object sender, EventArgs e)
        {
            txtReg.Text = String.Empty;
            numPasta.Value = 1;
            numDocumento.Value = 1;
            txtAssunto.Text = String.Empty;
            _alterarIndex = -1;

            txtReg.Enabled = true;
        }
        #endregion


        #region DoubleClick lbResumo
        private void lbResumo_DoubleClick(object sender, EventArgs e)
        {
            if (lbResumo.SelectedItem == null)
                return;

            var campos = lbResumo.SelectedItem.ToString().Split('|');

            int value;
            if (!Int32.TryParse(campos[0], out value))
                return;

            var resultado = _documentos.Where(s => s.NumPasta == value);

            PreencherResultado(resultado);

        }

        #endregion

        #region Click lbResumo
        private void lbResumo_Click(object sender, EventArgs e)
        {
            if (lbResumo.SelectedItem == null)
                return;

            var campos = lbResumo.SelectedItem.ToString().Split('|');

            int value;
            if (!Int32.TryParse(campos[0], out value))
                return;

            numPasta.Value = value;

            if (!Int32.TryParse(campos[2], out value))
                return;

            numDocumento.Value = ++value;
        }

        #endregion



        #region - CleanString
        private static string CleanString(string value)
        {
            Regex digitsOnly = new Regex(@"[^\d]");
            return digitsOnly.Replace(value, "").Trim();
        }

        #endregion

        #region - PreencherResultado
        private void PreencherResultado(IEnumerable<Documento> resultado)
        {
            lbResultado.Items.Clear();

            lbResultado.Items.Add(String.Format(PATTERN_LB,
                "#".PadLeft(8),
                "REG".PadRight(20),
                "Pasta".PadRight(5),
                " Doc.",
                "Assunto"));

            if (resultado == null)
                return;

            foreach (var reg in resultado)
            {
                var item = String.Format(PATTERN_LB,
                    reg.Id.ToString().PadLeft(8),
                    reg.REGMasked.PadRight(20),
                    reg.NumPasta.ToString().PadLeft(5),
                    reg.NumDocumento.ToString().PadLeft(5),
                    reg.Assunto);

                lbResultado.Items.Add(item);
            }
        }

        #endregion

        #region - PreencherResumo
        private void PreencherResumo()
        {
            lbResumo.Items.Clear();
            lbResumo.Items.Add(
                String.Format(PATTERN_RESUMO, "Pasta", "  Qtd", "Ultimo")
                );


            var pastas = _documentos.GroupBy(r => r.NumPasta).OrderBy(r => r.Key);

            foreach (var pasta in pastas)
            {

                lbResumo.Items.Add(
                    String.Format(PATTERN_RESUMO,
                        pasta.Key.ToString().PadLeft(5),
                        pasta.Count().ToString().PadLeft(5),
                        pasta.Max(p => p.NumDocumento).ToString().PadLeft(6)
                        ));
            }

            lblQtd.Text = "Registros: " + _documentos.Count;
        }

        #endregion

        private void tsmTramitar_Click(object sender, EventArgs e)
        {
            if (lbResultado.SelectedItem == null)
                return;

            var campos = lbResultado.SelectedItem.ToString().Split('|');

            int id;
            if (!Int32.TryParse(campos[0], out id))
                return;

            var principal = this.MdiParent as frmPrincipal;

            if (principal == null)
                return;


            if (MessageBox.Show(String.Format("ATENÇÃO!{0}Esta ação eliminará o Arquivo atual e permitirá a tramitação do documento.{0}Confirma a operação?", Environment.NewLine), "Atenção", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                return;



            var documento = _documentos.Find(t => t.Id == id);
            principal.Tramitando.btnNovo_Click(this, null);
            principal.Tramitando.txtREG.Text = documento.REGMasked;
            principal.Tramitando.txtAssunto.Text = documento.Assunto;

            _documentos.Remove(documento);


            if (!FileHelper.SalvarArquivados(_documentos))
            {
                MessageBox.Show("Houve um erro ao salvar o registro, porfavor tente novamente");
                return;
            }

            PreencherResultado(null);
            PreencherResumo();

            btnNovo_Click(sender, e);

            principal.Tramitando.Show();
        }


    }
}
