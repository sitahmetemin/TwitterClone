using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Twitter.MVC.Entities;

namespace Twitter.MVC.Dal
{
    public class FollowDal : IRepostory<Follower>
    {

        private TwitterContext _context = new TwitterContext();

        public List<Follower> GetAll()
        {
            throw new NotImplementedException();
        }

        public Follower Get(int Id)
        {
            throw new NotImplementedException();
        }

        public void Add(Follower Entitiy)
        {
            throw new NotImplementedException();
        }

        public void Update(Follower Entitiy)
        {
            throw new NotImplementedException();
        }

        public void Delete(Follower Entitiy)
        {
            _context.Followers.Attach(Entitiy);
            _context.Followers.Remove(Entitiy);
            _context.SaveChanges();
        }
    }
}