namespace Twitter.MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Follow : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Fallowers", "UserId", "dbo.Users");
            DropIndex("dbo.Fallowers", new[] { "UserId" });
            CreateTable(
                "dbo.Followers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        FollowId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.FollowId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.FollowId);
            
            DropTable("dbo.Fallowers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Fallowers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FallowId = c.Int(nullable: false),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            DropForeignKey("dbo.Followers", "UserId", "dbo.Users");
            DropForeignKey("dbo.Followers", "FollowId", "dbo.Users");
            DropIndex("dbo.Followers", new[] { "FollowId" });
            DropIndex("dbo.Followers", new[] { "UserId" });
            DropTable("dbo.Followers");
            CreateIndex("dbo.Fallowers", "UserId");
            AddForeignKey("dbo.Fallowers", "UserId", "dbo.Users", "UserId");
        }
    }
}
