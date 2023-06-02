namespace codefirst_net.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.ClientId);
            
            CreateTable(
                "dbo.Details",
                c => new
                    {
                        DetailId = c.Int(nullable: false, identity: true),
                        InvoiceId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DetailId)
                .ForeignKey("dbo.Invoices", t => t.InvoiceId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.InvoiceId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceId = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceId)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Details", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Details", "InvoiceId", "dbo.Invoices");
            DropForeignKey("dbo.Invoices", "ClientId", "dbo.Clients");
            DropIndex("dbo.Invoices", new[] { "ClientId" });
            DropIndex("dbo.Details", new[] { "ProductId" });
            DropIndex("dbo.Details", new[] { "InvoiceId" });
            DropTable("dbo.Products");
            DropTable("dbo.Invoices");
            DropTable("dbo.Details");
            DropTable("dbo.Clients");
        }
    }
}
