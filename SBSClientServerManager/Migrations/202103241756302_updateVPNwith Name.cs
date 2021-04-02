namespace SBSClientServerManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateVPNwithName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VPNs", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.VPNs", "Name");
        }
    }
}
