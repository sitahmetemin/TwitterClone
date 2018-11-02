namespace Twitter.MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RetweetNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tweets", "ParentId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tweets", "ParentId", c => c.Int(nullable: false));
        }
    }
}
