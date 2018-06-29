namespace mcknaldi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class promotion : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Promotions", "Title", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Promotions", "Title", c => c.String());
        }
    }
}
