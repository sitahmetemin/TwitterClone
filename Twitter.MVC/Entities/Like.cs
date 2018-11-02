using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Twitter.MVC.Entities
{
    public class Like
    {
        public int ID { get; set; }
        public int TweetId { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual Tweet Tweet { get; set; }

    }
}