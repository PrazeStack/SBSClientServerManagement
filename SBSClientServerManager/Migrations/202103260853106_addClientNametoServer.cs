namespace SBSClientServerManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addClientNametoServer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Servers", "ServerTypeId", "dbo.ServerTypes");
            DropIndex("dbo.Servers", new[] { "ServerTypeId" });
            AddColumn("dbo.Servers", "ServerTypeName", c => c.Int(nullable: false));
            DropColumn("dbo.Servers", "ServerTypeId");
            DropTable("dbo.ServerTypes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ServerTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Servers", "ServerTypeId", c => c.Int(nullable: false));
            DropColumn("dbo.Servers", "ServerTypeName");
            CreateIndex("dbo.Servers", "ServerTypeId");
            AddForeignKey("dbo.Servers", "ServerTypeId", "dbo.ServerTypes", "Id", cascadeDelete: true);
        }
    }
}
