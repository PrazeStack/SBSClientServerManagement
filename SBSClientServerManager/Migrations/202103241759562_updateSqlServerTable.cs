namespace SBSClientServerManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateSqlServerTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SqlServers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InstanceName = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SqlServers");
        }
    }
}
