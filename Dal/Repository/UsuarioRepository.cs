using Dapper;
using LearBank.Model;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearBank.Dal
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly string _connectionString;
        public UsuarioRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        private IDbConnection CreateConnection() => new OracleConnection(_connectionString);

        public async Task<Usuario> CriarUsuario(string email, string senha)
        {
            using (var connection = CreateConnection())
            {
                string sql = $@"INSERT INTO USUARIOS (EMAIL, SENHA) VALUES (:Email, :Senha) RETURNING Id INTO :Id";
                var parameters = new DynamicParameters();

                parameters.Add("Email", email);
                parameters.Add("Senha", senha);
                parameters.Add("Id", dbType: DbType.Int32, direction: ParameterDirection.Output);

                await connection.ExecuteAsync(sql, parameters);

                int id = parameters.Get<int>("Id");

                return new Usuario { Id = id, Email = email, Senha = senha };
            }
        }

        public async Task<Usuario> ObterUsuarioPorEmail(string email)
        {
            using (var connection = CreateConnection())
            {
                string sql = $@"SELECT * FROM USUARIOS WHERE EMAIL = :Email";
                var parameters = new DynamicParameters();

                parameters.Add("Email", email);

                return await connection.QuerySingleOrDefaultAsync<Usuario>(sql, parameters);
            }
        }
    }
}
