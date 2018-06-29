namespace mcknaldi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelupdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Categories", "Type", c => c.String(nullable: false));
            AlterColumn("dbo.Orders", "Products", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Brand", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "ShortDescription", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "FullDescription", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Image", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Weight", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Weight", c => c.String());
            AlterColumn("dbo.Products", "Image", c => c.String());
            AlterColumn("dbo.Products", "FullDescription", c => c.String());
            AlterColumn("dbo.Products", "ShortDescription", c => c.String());
            AlterColumn("dbo.Products", "Brand", c => c.String());
            AlterColumn("dbo.Products", "Title", c => c.String());
            AlterColumn("dbo.Orders", "Products", c => c.String());
            AlterColumn("dbo.Categories", "Type", c => c.String());
            AlterColumn("dbo.Categories", "Name", c => c.String());
        }
    }
}
