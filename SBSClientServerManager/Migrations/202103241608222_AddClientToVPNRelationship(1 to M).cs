namespace SBSClientServerManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClientToVPNRelationship1toM : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VPNs", "ClientId", c => c.Int(nullable: false));
            CreateIndex("dbo.VPNs", "ClientId");
            AddForeignKey("dbo.VPNs", "ClientId", "dbo.Clients", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VPNs", "ClientId", "dbo.Clients");
            DropIndex("dbo.VPNs", new[] { "ClientId" });
            DropColumn("dbo.VPNs", "ClientId");
        }
    }
}
