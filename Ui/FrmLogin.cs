using LearBank.Bll;
using LearBank.Model;
using LearBank.Ui;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearBank.UI
{
    public partial class FrmLogin : Form
    {
        private readonly UsuarioService _usuarioService;
        public Usuario UsuarioLogado { get; private set; }
        public FrmLogin(UsuarioService usuarioService)
        {
            InitializeComponent();

            _usuarioService = usuarioService;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtSenha.Text))
                {
                    MessageBox.Show("Por favor, preencha todos os campos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                Usuario usuario = await _usuarioService.AutenticarUsuario(txtEmail.Text, txtSenha.Text);

                if (usuario == null)
                {
                    MessageBox.Show("Email ou senha inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                UsuarioLogado = usuario;
                this.DialogResult = DialogResult.OK;
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao autenticar usuário: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                this.Cursor = Cursors.Default;
                btnLogin.Enabled = true;
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            var frmRegistrar = new FrmRegistrar(_usuarioService);
            frmRegistrar.ShowDialog();

            if (frmRegistrar.DialogResult == DialogResult.OK)
            {
                MessageBox.Show("Usuário registrado com sucesso! Agora você pode fazer login.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
