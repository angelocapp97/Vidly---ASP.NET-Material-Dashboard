namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LinkMembershipTypeToGroup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "MembershipTypeGroupId", c => c.Byte(nullable: false));
            CreateIndex("dbo.MembershipTypes", "MembershipTypeGroupId");
            AddForeignKey("dbo.MembershipTypes", "MembershipTypeGroupId", "dbo.MembershipTypeGroups", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MembershipTypes", "MembershipTypeGroupId", "dbo.MembershipTypeGroups");
            DropIndex("dbo.MembershipTypes", new[] { "MembershipTypeGroupId" });
            DropColumn("dbo.MembershipTypes", "MembershipTypeGroupId");
        }
    }
}
