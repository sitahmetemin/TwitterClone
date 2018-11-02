using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Twitter.MVC.Entities.Abstracts
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public  bool IsDeleted { get; set; }  
    }
}