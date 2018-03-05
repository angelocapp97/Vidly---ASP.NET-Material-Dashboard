namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.MembreshipTypes", newName: "MembershipTypes");
            DropForeignKey("dbo.Customers", "MembreshipType_Id", "dbo.MembreshipTypes");
            DropIndex("dbo.Customers", new[] { "MembreshipType_Id" });
            DropColumn("dbo.Customers", "MembershipTypeId");
            RenameColumn(table: "dbo.Customers", name: "MembreshipType_Id", newName: "MembershipTypeId");
            AlterColumn("dbo.Customers", "MembershipTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Customers", "MembershipTypeId");
            AddForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipTypeId" });
            AlterColumn("dbo.Customers", "MembershipTypeId", c => c.Byte());
            RenameColumn(table: "dbo.Customers", name: "MembershipTypeId", newName: "MembreshipType_Id");
            AddColumn("dbo.Customers", "MembershipTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Customers", "MembreshipType_Id");
            AddForeignKey("dbo.Customers", "MembreshipType_Id", "dbo.MembreshipTypes", "Id");
            RenameTable(name: "dbo.MembershipTypes", newName: "MembreshipTypes");
        }
    }
}
