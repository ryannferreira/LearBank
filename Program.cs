using LearBank.Bll;
using LearBank.Dal;
using LearBank.UI;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearBank
{
    internal static class Program
    {
        public static IConfiguration Configuration;

        [STAThread]
        static void Main()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var connectionString = Configuration.GetConnectionString("OracleDb");

            IUsuarioRepository usuarioRepository = new UsuarioRepository(connectionString);
            var usuarioService = new UsuarioService(usuarioRepository);

            var frmLogin = new FrmLogin(usuarioService);

            if (frmLogin.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            Application.Run(new FrmPrincipal());
        }
    }
}
