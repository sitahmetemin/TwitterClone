using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Twitter.MVC.Entities;

namespace Twitter.MVC.Dal
{
    public class UserDal : IRepostory<User>
    {
        private TwitterContext _context = new TwitterContext();

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetUser(string user, string password)
        {
            return _context.Users.FirstOrDefault(x => x.DisplayName == user && x.Password == password);
        }

        public User Get(int Id)
        {
            return _context.Users.FirstOrDefault(x => x.UserId == Id);
        }

        public void Add(User Entitiy)
        {
            _context.Users.Add(Entitiy);
            _context.SaveChanges();
        }

        public void Update(User Entitiy)
        {
            _context.Users.AddOrUpdate(Entitiy);
            _context.SaveChanges();
        }

        public void Delete(User Entitiy)
        {
            _context.Users.Remove(Entitiy);
            _context.SaveChanges();
        }
    }
}