namespace mcknaldi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Order : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carts", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Orders", "Product_Id", "dbo.Products");
            DropIndex("dbo.Carts", new[] { "User_Id" });
            DropIndex("dbo.Orders", new[] { "Product_Id" });
            AddColumn("dbo.Orders", "Status", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "Product_Id");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EAN = c.Long(nullable: false),
                        Amount = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Products", "Amount", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "Product_Id", c => c.Int());
            DropColumn("dbo.Orders", "Status");
            CreateIndex("dbo.Orders", "Product_Id");
            CreateIndex("dbo.Carts", "User_Id");
            AddForeignKey("dbo.Orders", "Product_Id", "dbo.Products", "Id");
            AddForeignKey("dbo.Carts", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
