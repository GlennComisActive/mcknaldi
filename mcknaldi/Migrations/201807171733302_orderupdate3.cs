namespace mcknaldi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderupdate3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderLijsts", "Product_Id", "dbo.Products");
            DropIndex("dbo.OrderLijsts", new[] { "Product_Id" });
            AddColumn("dbo.OrderLijsts", "ProductId", c => c.Int(nullable: false));
            DropColumn("dbo.OrderLijsts", "Product_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderLijsts", "Product_Id", c => c.Int());
            DropColumn("dbo.OrderLijsts", "ProductId");
            CreateIndex("dbo.OrderLijsts", "Product_Id");
            AddForeignKey("dbo.OrderLijsts", "Product_Id", "dbo.Products", "Id");
        }
    }
}
