using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearBank
{
    public class MigrationDbContextFactory : IDbContextFactory<MigrationDbContext>
    {
        public MigrationDbContext Create()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            var connectionString = configuration.GetConnectionString("OracleDb");

            return new MigrationDbContext(connectionString);
        }
    }
}
