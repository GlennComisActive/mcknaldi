namespace mcknaldi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class applicationuserchanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "PostalCode", c => c.String());
            DropColumn("dbo.AspNetUsers", "AddressCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "AddressCode", c => c.String());
            DropColumn("dbo.AspNetUsers", "PostalCode");
        }
    }
}
