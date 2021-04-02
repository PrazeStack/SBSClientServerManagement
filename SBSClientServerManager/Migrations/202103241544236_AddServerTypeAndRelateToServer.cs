namespace SBSClientServerManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddServerTypeAndRelateToServer : DbMigration
    {
        public override void Up()
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
            CreateIndex("dbo.Servers", "ServerTypeId");
            AddForeignKey("dbo.Servers", "ServerTypeId", "dbo.ServerTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Servers", "ServerTypeId", "dbo.ServerTypes");
            DropIndex("dbo.Servers", new[] { "ServerTypeId" });
            DropColumn("dbo.Servers", "ServerTypeId");
            DropTable("dbo.ServerTypes");
        }
    }
}
