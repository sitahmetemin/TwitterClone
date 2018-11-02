using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Twitter.MVC.Entities;

namespace Twitter.MVC.Dal
{
    public class TweetDal : IRepostory<Tweet>
    {
        private TwitterContext _context = new TwitterContext();

        public List<Tweet> GetAll()
        {
            return _context.Tweets.OrderByDescending(x=>x.CreatedAt).ToList();
        }

        public Tweet Get(int Id)
        {
            return _context.Tweets.FirstOrDefault(x => x.TweetId == Id);
        }

        public void Add(Tweet Entitiy)
        {
            _context.Tweets.Add(Entitiy);
            _context.SaveChanges();
        }

        public void Update(Tweet Entitiy)
        {
            _context.Tweets.AddOrUpdate(Entitiy);
            _context.SaveChanges();
        }

        public void Delete(Tweet Entitiy)
        {
            _context.Tweets.Remove(Entitiy);
            _context.SaveChanges();
        }
    }
}