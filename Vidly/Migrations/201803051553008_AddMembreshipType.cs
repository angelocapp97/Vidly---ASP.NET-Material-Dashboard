namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembreshipType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MembreshipTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        SignUpFree = c.Short(nullable: false),
                        DurationInMonth = c.Byte(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Customers", "MembershipTypeId", c => c.Byte(nullable: false));
            AddColumn("dbo.Customers", "MembreshipType_Id", c => c.Byte());
            CreateIndex("dbo.Customers", "MembreshipType_Id");
            AddForeignKey("dbo.Customers", "MembreshipType_Id", "dbo.MembreshipTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MembreshipType_Id", "dbo.MembreshipTypes");
            DropIndex("dbo.Customers", new[] { "MembreshipType_Id" });
            DropColumn("dbo.Customers", "MembreshipType_Id");
            DropColumn("dbo.Customers", "MembershipTypeId");
            DropTable("dbo.MembreshipTypes");
        }
    }
}
