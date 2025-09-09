using LearBank.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearBank.Bll
{
    public interface IUsuarioService
    {
        Task<Usuario> AutenticarUsuario(string email, string senha);
        Task<Usuario> CriarUsuario(string nomeCompleto, string cpf, DateTime dataNascimento, string email, string senha);
    }
}
