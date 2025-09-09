using LearBank.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearBank.Dal
{
    public interface IUsuarioRepository
    {
        Task<Usuario> CriarUsuario(string nomeCompleto, string cpf, DateTime dataNascimento, string email, string senhaHash);
        Task<Usuario> ObterUsuarioPorEmail(string email);
    }
}
