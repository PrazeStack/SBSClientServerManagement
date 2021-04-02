namespace SBSClientServerManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populatesServerTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO ServerTypes(Type)VALUES('Live')");
            Sql("INSERT INTO ServerTypes(Type)VALUES('Test')");
        }
        
        public override void Down()
        {
        }
    }
}
