namespace mcknaldi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderupdate4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderLijsts", "Product_Id", c => c.Int());
            AlterColumn("dbo.OrderLijsts", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.OrderLijsts", "TotalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Orders", "TotalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            CreateIndex("dbo.OrderLijsts", "Product_Id");
            AddForeignKey("dbo.OrderLijsts", "Product_Id", "dbo.Products", "Id");
            DropColumn("dbo.OrderLijsts", "ProductId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderLijsts", "ProductId", c => c.Int(nullable: false));
            DropForeignKey("dbo.OrderLijsts", "Product_Id", "dbo.Products");
            DropIndex("dbo.OrderLijsts", new[] { "Product_Id" });
            AlterColumn("dbo.Orders", "TotalPrice", c => c.Single(nullable: false));
            AlterColumn("dbo.OrderLijsts", "TotalPrice", c => c.Single(nullable: false));
            AlterColumn("dbo.OrderLijsts", "Price", c => c.Single(nullable: false));
            DropColumn("dbo.OrderLijsts", "Product_Id");
        }
    }
}
