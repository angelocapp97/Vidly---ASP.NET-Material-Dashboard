namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeMembershipTypeRelationship : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET MembershipTypeGroupId = 0 WHERE Id = 1");
            Sql("UPDATE MembershipTypes SET MembershipTypeGroupId = 1 WHERE Id = 2");
            Sql("UPDATE MembershipTypes SET MembershipTypeGroupId = 1 WHERE Id = 3");
            Sql("UPDATE MembershipTypes SET MembershipTypeGroupId = 1 WHERE Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
