using Arquiva.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Arquiva
{
    public partial class frmTramitando : Form
    {

        #region Fields
        private List<Tramite> _tramites;
        private int _alterarIndex = -1;

        private const string PATTERN_RESUMO = "{0}{1}";
        private const string PATTERN_DATE = "dd/MM/yyyy";

        private const char SEPARADOR = '_';
        #endregion

        #region ctor
        public frmTramitando()
        {
            InitializeComponent();

            _tramites = FileHelper.RecuperarTramites();

            PreencherResultado();            
        }

        #endregion

        #region txtREG KeyPress
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

        }

        #endregion

        #region txtAssunto KeyPress
        private void txtAssunto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ';' ||
                e.KeyChar == '|')
                e.Handled = true;

            if ((sender as TextBox).Text.Length > 100)
                e.Handled = true;
        }

        #endregion
        
        #region frmTramitando Shown
        private void frmTramitando_Shown(object sender, EventArgs e)
        {
            MudarCombos();
        }

        #endregion

        #region mcEntrada DateChanged
        private void mcEntrada_DateChanged(object sender, DateRangeEventArgs e)
        {
            var days = 5;
            mcPrevista.MinDate = mcEntrada.SelectionStart;
            mcPrevista.SelectionStart = mcEntrada.SelectionStart.AddDays(days);
            mcPrevista.SelectionEnd = mcEntrada.SelectionStart.AddDays(days);


            mcEnvio.MinDate = mcEntrada.SelectionStart;
            mcEnvio.SelectionStart = mcEntrada.SelectionStart.AddDays(days);
            mcEnvio.SelectionEnd = mcEntrada.SelectionStart.AddDays(days);
        }

        #endregion

        #region btnSalvar Click
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtREG.Text))
            {
                MessageBox.Show("Preencha o campo REG");
                return;
            }

            if (MessageBox.Show("Confirma a operação?", "Atenção", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                return;

            var aux = CleanString(txtREG.Text);
            if (_tramites.Any(d => d.REG.Trim() ==  aux) && _alterarIndex < 0)
            {
                MessageBox.Show("Esse número de REG já está tramitando.");
                return;
            }

            var arquivados = FileHelper.RecuperarArquivados();
            if (arquivados.Any(t => t.REG.Trim() == aux))
            {
                MessageBox.Show("Esse número de REG está arquivado.");
                return;
            }


            if (_alterarIndex < 0)
            {
                if (_tramites.Count > 0)
                    _alterarIndex = _tramites.Max(t => t.Id) + 1;
                else
                    _alterarIndex = 0;

                _tramites.Add(new Tramite
                {
                    Id = _alterarIndex,
                    REG = CleanString(txtREG.Text),
                    REGMasked = txtREG.Text.Trim(),
                    Entrada = mcEntrada.SelectionStart,
                    Prevista = mcPrevista.SelectionStart,
                    Saida = mcEnvio.SelectionStart,
                    Responsavel = cbResponsavel.SelectedItem.ToString(),
                    Destino = cbDestino.SelectedItem.ToString(),
                    Status = RecuperarStatus(),
                    Assunto = txtAssunto.Text
                });
            }
            else
            {
                var tramite = _tramites.Find(t => t.Id == _alterarIndex);
                tramite.REG = CleanString(txtREG.Text);
                tramite.REGMasked = txtREG.Text.Trim();
                tramite.Entrada = mcEntrada.SelectionStart;
                tramite.Prevista = mcPrevista.SelectionStart;
                tramite.Saida = mcEnvio.SelectionStart;
                tramite.Responsavel = cbResponsavel.SelectedItem.ToString();
                tramite.Destino = cbDestino.SelectedItem.ToString();
                tramite.Status = RecuperarStatus();
                tramite.Assunto = txtAssunto.Text; ;

            }


            if (!FileHelper.SalvarTramites(_tramites))
            {
                MessageBox.Show("Houve um erro ao salvar o registro, porfavor tente novamente");
                return;
            }

            PreencherResultado();

            btnNovo_Click(sender, e);
        }

        #endregion

        #region btnNovo Click
        public void btnNovo_Click(object sender, EventArgs e)
        {
            _alterarIndex = -1;
            txtREG.Text = String.Empty;
            txtREG.Text = String.Empty;
            mcEntrada.SelectionStart = DateTime.Now;
            mcPrevista.SelectionStart = DateTime.Now;
            mcEnvio.SelectionStart = DateTime.Now;
            cbResponsavel.SelectedIndex = cbResponsavel.Items.Count == 0 ? -1 : 0;
            cbDestino.SelectedIndex = cbDestino.Items.Count == 0 ? -1 : 0;
            rbInterno.Checked = true;
            txtAssunto.Text = String.Empty;

            txtREG.Enabled = true;
        }

        #endregion

        #region tsmiEditar Click
        private void tsmiEditar_Click(object sender, EventArgs e)
        {
            if (lvResultado.SelectedIndices.Count == 0)
                return;

            if (!Int32.TryParse(lvResultado.SelectedItems[0].Tag.ToString(), out _alterarIndex))
            {
                _alterarIndex = -1;
                return;
            }

            var tramite = _tramites.Find(t => t.Id == _alterarIndex);
            txtREG.Text = tramite.REGMasked;
            txtAssunto.Text = tramite.Assunto;
            mcEntrada.SelectionStart = tramite.Entrada;
            mcPrevista.SelectionStart = tramite.Prevista;
            mcEnvio.SelectionStart = tramite.Saida;

            cbResponsavel.SelectedIndex = cbResponsavel.Items.Contains(tramite.Responsavel) ? cbResponsavel.Items.IndexOf(tramite.Responsavel) : 0;
            cbDestino.SelectedIndex = cbDestino.Items.Contains(tramite.Destino) ? cbDestino.Items.IndexOf(tramite.Destino) : 0;

            rbInterno.Checked = tramite.Status == TramiteStatus.Interno;
            rbExterno.Checked = tramite.Status == TramiteStatus.Externo;

            mcEntrada_DateChanged(sender, null);

            txtREG.Enabled = false;
        }
        
        #endregion        

        #region tsmiArquivar Click
        private void tsmiArquivar_Click(object sender, EventArgs e)
        {
            if (lvResultado.SelectedIndices.Count == 0)
                return;

            int id;
            if (!Int32.TryParse(lvResultado.SelectedItems[0].Tag.ToString(), out id))
                return;

            var principal = this.MdiParent as frmPrincipal;

            if (principal == null)
                return;


            if (MessageBox.Show(String.Format("ATENÇÃO!{0}Esta ação eliminará o tramite atual e permitirá o arquivamento do documento.{0}Confirma a operação?", Environment.NewLine), "Atenção", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                return;



            var tramite = _tramites.Find(t => t.Id == id);
            principal.Arquivados.txtReg.Text = tramite.REGMasked;
            principal.Arquivados.txtAssunto.Text = tramite.Assunto;

            _tramites.Remove(tramite);


            if (!FileHelper.SalvarTramites(_tramites))
            {
                MessageBox.Show("Houve um erro ao salvar o registro, porfavor tente novamente");
                return;
            }

            PreencherResultado();

            btnNovo_Click(sender, e);

            principal.Arquivados.Show();

        }
        
        #endregion

        #region rbExterno CheckedChanged
        private void rbExterno_CheckedChanged(object sender, EventArgs e)
        {
            gbEnvio.Enabled = rbExterno.Checked;
            MudarCombos();
        }

        #endregion



        #region - PreencherResumo
        private void PreencherResumo(int vencidos, int vencendo, int aVencer, int interno, int externo, int total)
        {
            lbResumo.Items.Clear();

            lbResumo.Items.Add(
                String.Format(PATTERN_RESUMO,
                "Status".PadRight(15),
                "  Qtd."));

            lbResumo.Items.Add(
                String.Format(PATTERN_RESUMO,
                "Vencidos".PadRight(15, SEPARADOR),
                vencidos.ToString().PadLeft(6, SEPARADOR)));

            lbResumo.Items.Add(
                String.Format(PATTERN_RESUMO,
                "Vencendo hoje".PadRight(15, SEPARADOR),
                vencendo.ToString().PadLeft(6, SEPARADOR)));

            lbResumo.Items.Add(
                String.Format(PATTERN_RESUMO,
                "A vencer".PadRight(15, SEPARADOR),
                aVencer.ToString().PadLeft(6, SEPARADOR)));

            lbResumo.Items.Add(
                String.Format(PATTERN_RESUMO,
                String.Empty.PadRight(15),
                String.Empty.PadLeft(6)));

            lbResumo.Items.Add(
                String.Format(PATTERN_RESUMO,
                "Internos".PadRight(15, SEPARADOR),
                interno.ToString().PadLeft(6, SEPARADOR)));

            lbResumo.Items.Add(
                String.Format(PATTERN_RESUMO,
                "Externos".PadRight(15, SEPARADOR),
                externo.ToString().PadLeft(6, SEPARADOR)));

            lbResumo.Items.Add(
                String.Format(PATTERN_RESUMO,
                "Total".PadRight(15, SEPARADOR),
                total.ToString().PadLeft(6, SEPARADOR)));
        }
        
        #endregion

        #region - PreencherResultado
        private void PreencherResultado()
        {

            int vencidos = 0, vencendo = 0, aVencer = 0, interno = 0, externo = 0, total = 0;
            lvResultado.Items.Clear();

            foreach (var tram in _tramites.OrderBy(t => t.Prevista))
            {
                total++;

                var lvItem = lvResultado.Items.Add(tram.REGMasked);

                lvItem.Tag = tram.Id;
                lvItem.SubItems.Add(tram.Entrada.ToString(PATTERN_DATE));
                lvItem.SubItems.Add(tram.Prevista.ToString(PATTERN_DATE), Color.White, Color.Red, lvResultado.Font);
                
                
                

                if (tram.Status == TramiteStatus.Interno)
                {
                    interno++;
                    lvItem.SubItems.Add("-");
                    lvItem.Group = lvResultado.Groups[0];
                    if (tram.Prevista < DateTime.Now.Date)
                    {
                        vencidos++;
                        lvItem.BackColor = Color.Tomato;
                    }
                    else if (tram.Prevista == DateTime.Now.Date)
                    {
                        vencendo++;
                        lvItem.BackColor = Color.Khaki;
                    }
                    else
                    {
                        aVencer++;
                    }

                }
                else
                {
                    externo++;
                    
                    lvItem.SubItems.Add(tram.Saida.ToString(PATTERN_DATE));
                    lvItem.Group = lvResultado.Groups[1];
                }


                lvItem.SubItems.Add(tram.Responsavel);
                lvItem.SubItems.Add(tram.Destino);
                lvItem.SubItems.Add(tram.Assunto);

            }

            PreencherResumo(vencidos, vencendo, aVencer, interno, externo, total);
        }

        #endregion

        #region - CleanString
        private static string CleanString(string value)
        {
            Regex digitsOnly = new Regex(@"[^\d]");
            return digitsOnly.Replace(value, "").Trim();
        }

        #endregion

        #region - RecuperarStatus
        private TramiteStatus RecuperarStatus()
        {
            if (rbInterno.Checked)
                return TramiteStatus.Interno;

            return TramiteStatus.Externo;
        }

        #endregion


        private void MudarCombos()
        {
            cbDestino.Items.Clear();
            cbResponsavel.Items.Clear();

            var _destinos = FileHelper.RecuperarDestinos();
            var _responsaveis = FileHelper.RecuperarPessoas();

            string aux = rbInterno.Checked ? "Interno": "Externo";
            cbDestino.Items.AddRange(_destinos.Where(d=>d.Local == aux).OrderBy(d => d.Nome).Select(d => d.Nome).ToArray());
            cbResponsavel.Items.AddRange(_responsaveis.Where(d => d.Local == aux).OrderBy(r => r.Nome).Select(r => r.Nome).ToArray());

            cbDestino.SelectedIndex = cbDestino.Items.Count == 0 ? -1 : 0;
            cbResponsavel.SelectedIndex = cbResponsavel.Items.Count == 0 ? -1 : 0;


        }


    }
}

