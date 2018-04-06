namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyMembershipTypeGroups : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypeGroups SET Name = 'For all Users' WHERE Id = 0");
            Sql("UPDATE MembershipTypeGroups SET Name = 'Only for adults' WHERE Id = 1");
        }
        
        public override void Down()
        {
        }
    }
}
