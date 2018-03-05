namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembreshipTypes", "SignUpFee", c => c.Short(nullable: false));
            DropColumn("dbo.MembreshipTypes", "SignUpFree");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MembreshipTypes", "SignUpFree", c => c.Short(nullable: false));
            DropColumn("dbo.MembreshipTypes", "SignUpFee");
        }
    }
}
