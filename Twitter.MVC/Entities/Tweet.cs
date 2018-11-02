using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Twitter.MVC.Entities
{
    public class Tweet
    {
        public int TweetId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public Tweet ParentTweet { get; set; }
        public int? ParentId { get; set; }


        public Nullable<int> UserId { get; set; }
        public virtual User User { get; set; }
        public ICollection<Like> Likes { get; set; }
        
    }
}