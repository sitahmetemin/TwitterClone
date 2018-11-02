namespace Twitter.MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FallowersIliskiDeneme2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Fallower_ID", "dbo.Fallowers");
            DropIndex("dbo.Users", new[] { "Fallower_ID" });
            CreateIndex("dbo.Fallowers", "UserId");
            AddForeignKey("dbo.Fallowers", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
            DropColumn("dbo.Users", "Fallower_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Fallower_ID", c => c.Int());
            DropForeignKey("dbo.Fallowers", "UserId", "dbo.Users");
            DropIndex("dbo.Fallowers", new[] { "UserId" });
            CreateIndex("dbo.Users", "Fallower_ID");
            AddForeignKey("dbo.Users", "Fallower_ID", "dbo.Fallowers", "ID");
        }
    }
}
