namespace ResourceIT.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Firstmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Detalhe",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Telefone = c.String(maxLength: 15),
                        Endereco = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Sobrenome = c.String(maxLength: 100),
                        Email = c.String(maxLength: 100),
                        DetalheId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Detalhe", t => t.DetalheId, cascadeDelete: true)
                .Index(t => t.DetalheId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuario", "DetalheId", "dbo.Detalhe");
            DropIndex("dbo.Usuario", new[] { "DetalheId" });
            DropTable("dbo.Usuario");
            DropTable("dbo.Detalhe");
        }
    }
}
