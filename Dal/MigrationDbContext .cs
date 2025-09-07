using LearBank.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearBank
{
    public class MigrationDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        public MigrationDbContext(string connectionString) : base(connectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("PDBADMIN");

            base.OnModelCreating(modelBuilder);
        }
    }
}
