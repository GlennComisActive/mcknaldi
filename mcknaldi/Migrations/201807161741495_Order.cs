namespace mcknaldi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Order : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderLijsts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        ProductName = c.String(),
                        OrderId_Id = c.Int(),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Orders", t => t.OrderId_Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .Index(t => t.OrderId_Id)
                .Index(t => t.Product_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderLijsts", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.OrderLijsts", "OrderId_Id", "dbo.Orders");
            DropIndex("dbo.OrderLijsts", new[] { "Product_Id" });
            DropIndex("dbo.OrderLijsts", new[] { "OrderId_Id" });
            DropTable("dbo.OrderLijsts");
        }
    }
}
