namespace mcknaldi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "OrderCode", c => c.String(nullable: false));
            AddColumn("dbo.Orders", "OrderName", c => c.String(nullable: false));
            AlterColumn("dbo.Orders", "TotalPrice", c => c.Single(nullable: false));
            DropColumn("dbo.Orders", "Products");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Products", c => c.String(nullable: false));
            AlterColumn("dbo.Orders", "TotalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Orders", "OrderName");
            DropColumn("dbo.Orders", "OrderCode");
        }
    }
}
