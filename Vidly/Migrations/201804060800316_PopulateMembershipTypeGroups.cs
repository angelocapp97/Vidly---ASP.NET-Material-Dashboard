namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypeGroups : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypeGroups (Id, Name) VALUES (0, 'Group 1')");
            Sql("INSERT INTO MembershipTypeGroups (Id, Name) VALUES (1, 'Group 2')");
        }
        
        public override void Down()
        {
        }
    }
}
