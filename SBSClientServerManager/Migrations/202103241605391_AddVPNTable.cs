namespace SBSClientServerManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVPNTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VPNs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.VPNs");
        }
    }
}
