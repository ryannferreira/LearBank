using LearBank.Bll;
using LearBank.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearBank.Ui
{
    public partial class FrmRegistrar : Form
    {
        private readonly UsuarioService _usuarioService;
        public FrmRegistrar(UsuarioService usuarioService)
        {
            InitializeComponent();
            _usuarioService = usuarioService;
        }

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNomeCompleto.Text) || string.IsNullOrWhiteSpace(txtCpf.Text) ||string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtSenha.Text))
                {
                    MessageBox.Show("Por favor, preencha todos os campos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                Usuario usuario = await _usuarioService.CriarUsuario(txtNomeCompleto.Text, txtCpf.Text, dtpDataNascimento.Value, txtEmail.Text, txtSenha.Text);

                if (usuario == null)
                {
                    MessageBox.Show("Não foi possível registrar o usuário.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao registrar usuário: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
    }
}
