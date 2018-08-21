namespace EcommerceOsorioManha.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adicionando_Table_ItensVenda : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItensVenda",
                c => new
                    {
                        VendaId = c.Int(nullable: false, identity: true),
                        QtdVenda = c.Int(nullable: false),
                        PrecoVenda = c.Double(nullable: false),
                        Data = c.DateTime(nullable: false),
                        CarrinhoId = c.String(),
                        ProdutoVenda_ProdutoId = c.Int(),
                    })
                .PrimaryKey(t => t.VendaId)
                .ForeignKey("dbo.Produtos", t => t.ProdutoVenda_ProdutoId)
                .Index(t => t.ProdutoVenda_ProdutoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItensVenda", "ProdutoVenda_ProdutoId", "dbo.Produtos");
            DropIndex("dbo.ItensVenda", new[] { "ProdutoVenda_ProdutoId" });
            DropTable("dbo.ItensVenda");
        }
    }
}
