namespace Twitter.MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FallowersIliskiDeneme3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Fallowers", "UserId", "dbo.Users");
            DropIndex("dbo.Fallowers", new[] { "UserId" });
            AlterColumn("dbo.Fallowers", "UserId", c => c.Int());
            CreateIndex("dbo.Fallowers", "UserId");
            AddForeignKey("dbo.Fallowers", "UserId", "dbo.Users", "UserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fallowers", "UserId", "dbo.Users");
            DropIndex("dbo.Fallowers", new[] { "UserId" });
            AlterColumn("dbo.Fallowers", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Fallowers", "UserId");
            AddForeignKey("dbo.Fallowers", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
    }
}
