using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Twitter.MVC.Entities;

namespace Twitter.MVC.Models.ViewModel
{
    public class HomeViewModel
    {

        public List<Tweet> Tweets { get; set; }

        public List<User> Users { get; set; }

        public List<Follower> Followers { get; set; }
        public List<Like> Likes { get; set; }

    }
}