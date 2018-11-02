namespace Twitter.MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Retweet : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tweets", "ParentId", c => c.Int(nullable: false));
            AddColumn("dbo.Tweets", "ParentTweet_TweetId", c => c.Int());
            CreateIndex("dbo.Tweets", "ParentTweet_TweetId");
            AddForeignKey("dbo.Tweets", "ParentTweet_TweetId", "dbo.Tweets", "TweetId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tweets", "ParentTweet_TweetId", "dbo.Tweets");
            DropIndex("dbo.Tweets", new[] { "ParentTweet_TweetId" });
            DropColumn("dbo.Tweets", "ParentTweet_TweetId");
            DropColumn("dbo.Tweets", "ParentId");
        }
    }
}
