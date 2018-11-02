namespace Twitter.MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FallowersIliskiDeneme : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Fallower_ID", c => c.Int());
            CreateIndex("dbo.Users", "Fallower_ID");
            AddForeignKey("dbo.Users", "Fallower_ID", "dbo.Fallowers", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Fallower_ID", "dbo.Fallowers");
            DropIndex("dbo.Users", new[] { "Fallower_ID" });
            DropColumn("dbo.Users", "Fallower_ID");
        }
    }
}
