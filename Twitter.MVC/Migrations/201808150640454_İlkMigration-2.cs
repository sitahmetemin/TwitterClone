namespace Twitter.MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class İlkMigration2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fallowers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        FallowId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Tweets",
                c => new
                    {
                        TweetId = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.TweetId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DisplayName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tweets", "UserId", "dbo.Users");
            DropIndex("dbo.Tweets", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.Tweets");
            DropTable("dbo.Fallowers");
        }
    }
}
