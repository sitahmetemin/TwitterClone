using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Twitter.MVC.Entities.Abstracts;

namespace Twitter.MVC.Entities
{
    public class Follower: BaseEntity
    {

        public int UserId { get; set; }
        public int FollowId { get; set; }
        public virtual User User { get; set; }
        public virtual User Follow { get; set; }

    }
}