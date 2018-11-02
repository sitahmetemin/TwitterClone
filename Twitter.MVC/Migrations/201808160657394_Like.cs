namespace Twitter.MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Like : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Likes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TweetId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tweets", t => t.TweetId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.TweetId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Likes", "UserId", "dbo.Users");
            DropForeignKey("dbo.Likes", "TweetId", "dbo.Tweets");
            DropIndex("dbo.Likes", new[] { "UserId" });
            DropIndex("dbo.Likes", new[] { "TweetId" });
            DropTable("dbo.Likes");
        }
    }
}
