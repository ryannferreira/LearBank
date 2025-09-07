namespace LearBank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjusteTabelaUsuarios : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "PDBADMIN.Usuarios", newName: "USUARIOS");
            RenameColumn(table: "PDBADMIN.USUARIOS", name: "Id", newName: "ID");
            RenameColumn(table: "PDBADMIN.USUARIOS", name: "Email", newName: "EMAIL");
            RenameColumn(table: "PDBADMIN.USUARIOS", name: "Senha", newName: "SENHA");
        }

        public override void Down()
        {
            RenameColumn(table: "PDBADMIN.USUARIOS", name: "SENHA", newName: "Senha");
            RenameColumn(table: "PDBADMIN.USUARIOS", name: "EMAIL", newName: "Email");
            RenameColumn(table: "PDBADMIN.USUARIOS", name: "ID", newName: "Id");
            RenameTable(name: "PDBADMIN.USUARIOS", newName: "Usuarios");
        }
    }
}
