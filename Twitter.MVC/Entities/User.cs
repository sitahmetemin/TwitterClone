using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Twitter.MVC.Entities
{
    public class User
    {

        public User()
        {
            this.Tweets = new HashSet<Tweet>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


        public virtual ICollection<Tweet> Tweets { get; set; }

        public  ICollection<Follower> Followers  { get; set; }
        public ICollection<Follower> Follows { get; set; }
        public ICollection<Like> Likes { get; set; }
    }
}