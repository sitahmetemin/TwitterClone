namespace Twitter.MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateSeed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Description");
        }
    }
}
