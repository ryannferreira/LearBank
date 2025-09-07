using LearBank.Dal;
using LearBank.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearBank.Bll
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Usuario> CriarUsuario(string email, string senha)
        {
            bool emailValido = EmailValido(email);

            if (emailValido == false)
            {
                throw new Exception("Email inválido.");
            }

            Usuario usuario = await _usuarioRepository.ObterUsuarioPorEmail(email);

            if (usuario != null)
            {
                throw new Exception("Usuário já existe.");
            }

            string senhaHash = BCrypt.Net.BCrypt.HashPassword(senha);

            usuario = await _usuarioRepository.CriarUsuario(email, senhaHash);

            return usuario;
        }

        public async Task<Usuario> AutenticarUsuario(string email, string senha)
        {
            Usuario usuario = await _usuarioRepository.ObterUsuarioPorEmail(email);

            if (usuario == null)
            {
                return null;
            }

            bool senhaValida = BCrypt.Net.BCrypt.Verify(senha, usuario.Senha);

            return senhaValida ? usuario : null;
        }

        public bool EmailValido(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
