namespace SBSClientServerManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClientToSqlServerRelationship1toM : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SqlServers", "ClientId", c => c.Int(nullable: false));
            CreateIndex("dbo.SqlServers", "ClientId");
            AddForeignKey("dbo.SqlServers", "ClientId", "dbo.Clients", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SqlServers", "ClientId", "dbo.Clients");
            DropIndex("dbo.SqlServers", new[] { "ClientId" });
            DropColumn("dbo.SqlServers", "ClientId");
        }
    }
}
