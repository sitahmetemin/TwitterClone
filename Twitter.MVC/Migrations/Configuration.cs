using Twitter.MVC.Entities;

namespace Twitter.MVC.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Twitter.MVC.Entities.TwitterContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Twitter.MVC.Entities.TwitterContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Tweets.AddOrUpdate(x => x.TweetId,
                new Tweet()
                {
                    TweetId = 1,
                    Content = "Pride and Prejudice",
                    UserId = 1,
                    CreatedAt = DateTime.Now
                },
                new Tweet()
                {
                    TweetId = 2,
                    Content =
                        "Pride and Prejudice Pride and Prejudice Pride and Prejudice Pride and Prejudice Pride and Prejudice Pride and Prejudice ",
                    UserId = 1,
                    CreatedAt = DateTime.Now
                },
                new Tweet()
                {
                    TweetId = 3,
                    Content =
                        "Pride and PrejudicePride and Prejudice Pride and Prejudice Pride and Prejudice Pride and Prejudice ",
                    UserId = 1,
                    CreatedAt = DateTime.Now
                },
                new Tweet()
                {
                    TweetId = 4,
                    Content = "Pride and Prejudice Pride and Prejudice Pride and Prejudice ",
                    UserId = 1,
                    CreatedAt = DateTime.Now
                },
                new Tweet()
                {
                    TweetId = 5,
                    Content =
                        "Pride and PrejudicePride and Prejudice Pride and Prejudice Pride and Prejudice Pride and Prejudice Pride and Prejudice Pride and Prejudice Pride and Prejudice Pride and Prejudice Pride and Prejudice Pride and Prejudice Pride and Prejudice Pride and Prejudice ",
                    UserId = 1,
                    CreatedAt = DateTime.Now
                },
                new Tweet()
                {
                    TweetId = 6,
                    Content = "Pride and Prejudice Pride and Prejudice Pride and Prejudice ",
                    UserId = 1,
                    CreatedAt = DateTime.Now
                }
            );

            context.Users.AddOrUpdate(x => x.UserId,
                new User()
                {
                    UserId = 1,
                    FirstName = "Ahmet Emin",
                    LastName = "ÞÝT",
                    DisplayName = "sitahmetemin",
                    Description = "Twitter Clone App on Owner",
                    Password = "123654",
                    Email = "sitahmetemin@gmail.com"
                });
        }
    }
}
