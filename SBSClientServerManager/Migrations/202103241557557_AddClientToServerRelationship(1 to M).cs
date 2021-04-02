namespace SBSClientServerManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClientToServerRelationship1toM : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Servers", "ClientId", c => c.Int(nullable: false));
            CreateIndex("dbo.Servers", "ClientId");
            AddForeignKey("dbo.Servers", "ClientId", "dbo.Clients", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Servers", "ClientId", "dbo.Clients");
            DropIndex("dbo.Servers", new[] { "ClientId" });
            DropColumn("dbo.Servers", "ClientId");
        }
    }
}
