namespace mcknaldi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderupdate2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderLijsts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        OrderCode = c.String(),
                        Amount = c.Int(nullable: false),
                        ProductName = c.String(),
                        Price = c.Single(nullable: false),
                        TotalPrice = c.Single(nullable: false),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .Index(t => t.Product_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderLijsts", "Product_Id", "dbo.Products");
            DropIndex("dbo.OrderLijsts", new[] { "Product_Id" });
            DropTable("dbo.OrderLijsts");
        }
    }
}
