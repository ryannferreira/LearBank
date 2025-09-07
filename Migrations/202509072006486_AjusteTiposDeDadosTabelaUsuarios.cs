namespace LearBank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjusteTiposDeDadosTabelaUsuarios : DbMigration
    {
        public override void Up()
        {
            AddColumn("PDBADMIN.USUARIOS", "EMAIL_TEMP", c => c.String(maxLength: 255, unicode: false));

            Sql("UPDATE PDBADMIN.USUARIOS SET EMAIL_TEMP = TO_CHAR(EMAIL)");

            DropColumn("PDBADMIN.USUARIOS", "EMAIL");

            RenameColumn("PDBADMIN.USUARIOS", "EMAIL_TEMP", "EMAIL");

            AddColumn("PDBADMIN.USUARIOS", "SENHA_TEMP", c => c.String(maxLength: 255, unicode: false));
            Sql("UPDATE PDBADMIN.USUARIOS SET SENHA_TEMP = TO_CHAR(SENHA)");
            DropColumn("PDBADMIN.USUARIOS", "SENHA");
            RenameColumn("PDBADMIN.USUARIOS", "SENHA_TEMP", "SENHA");
        }
        
        public override void Down()
        {
            AddColumn("PDBADMIN.USUARIOS", "SENHA_TEMP", c => c.String(unicode: true, storeType: "nclob"));
            Sql("UPDATE PDBADMIN.USUARIOS SET SENHA_TEMP = SENHA");
            DropColumn("PDBADMIN.USUARIOS", "SENHA");
            RenameColumn("PDBADMIN.USUARIOS", "SENHA_TEMP", "SENHA");


            AddColumn("PDBADMIN.USUARIOS", "EMAIL_TEMP", c => c.String(unicode: true, storeType: "nclob"));
            Sql("UPDATE PDBADMIN.USUARIOS SET EMAIL_TEMP = EMAIL");
            DropColumn("PDBADMIN.USUARIOS", "EMAIL");
            RenameColumn("PDBADMIN.USUARIOS", "EMAIL_TEMP", "EMAIL");
        }
    }
}
