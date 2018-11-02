using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Twitter.MVC.Entities.Abstracts;

namespace Twitter.MVC.Entities
{
    public class TwitterContext : DbContext
    {
        public TwitterContext():base("TwitterContext")
        {
            
        }

        public DbSet<Tweet> Tweets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Follower> Followers { get; set; }
        public DbSet<Like> Likes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Follower>()
                .HasRequired(m => m.User)
                .WithMany(t => t.Follows)
                .HasForeignKey(m => m.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Follower>()
                .HasRequired(m => m.Follow)
                .WithMany(t => t.Followers)
                .HasForeignKey(m => m.FollowId)
                .WillCascadeOnDelete(false);

        }


        //public override int SaveChanges()
        //{
        //    PreDelete();
        //    return base.SaveChanges();
        //}

        private void PreDelete()
        {
            //var deleteds = ChangeTracker.Entries().Where(p => p.Entity is BaseEntity).Select(p=> p.Entity  as BaseEntity);
            //foreach (var entity in deleteds.Where(p=> p!=null))
            //{
            //    entity.IsDeleted = true;
               

            //}
        }
    }
}