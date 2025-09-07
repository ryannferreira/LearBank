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
        Task<Usuario> CriarUsuario(string email, string senha);
        Task<Usuario> ObterUsuarioPorEmail(string email);
    }
}
