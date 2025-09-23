namespace LearBank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "PDBADMIN.USUARIOS",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 19, scale: 0, identity: true),
                        NOME_COMPLETO = c.String(nullable: false, maxLength: 150, unicode: false),
                        CPF = c.String(nullable: false, maxLength: 11),
                        EMAIL = c.String(maxLength: 255, unicode: false),
                        SENHA_HASH = c.String(maxLength: 255, unicode: false),
                        DATA_NASCIMENTO = c.DateTime(nullable: false),
                        DATA_CADASTRO = c.DateTime(nullable: false),
                        ATIVO = c.Decimal(nullable: false, precision: 1, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "PDBADMIN.CONTAS",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 19, scale: 0, identity: true),
                        AGENCIA = c.String(nullable: false, maxLength: 10),
                        NUMERO_CONTA = c.String(nullable: false, maxLength: 20),
                        TIPO_CONTA = c.Decimal(nullable: false, precision: 10, scale: 0),
                        SALDO = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DATA_ABERTURA = c.DateTime(nullable: false),
                        ATIVA = c.Decimal(nullable: false, precision: 1, scale: 0),
                        ID_USUARIO = c.Decimal(nullable: false, precision: 19, scale: 0),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("PDBADMIN.USUARIOS", t => t.ID_USUARIO, cascadeDelete: true)
                .Index(t => t.ID_USUARIO);
            
        }
        
        public override void Down()
        {
            DropForeignKey("PDBADMIN.CONTAS", "ID_USUARIO", "PDBADMIN.USUARIOS");
            DropIndex("PDBADMIN.CONTAS", new[] { "ID_USUARIO" });
            DropTable("PDBADMIN.CONTAS");
            DropTable("PDBADMIN.USUARIOS");
        }
    }
}
