using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BasicApi.Models
{
    public class UserContext : DbContext
    {
        public UserContext()
        : base("UserContext")
        {
        }
        public DbSet<User> Users { get; set; }
        //public DbSet<Category> Categories { get; set; }
        //public DbSet<Article> Articles { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // İlişkileri kuruyoruz one-to-many olarak.
            //modelBuilder.Entity<Article>()
            //.HasRequired<Category>(x => x.Category)
            //.WithMany(x => x.Articles)
            //.HasForeignKey(x => x.CategoryId);
            //modelBuilder.Entity<Article>()
            //.HasRequired<User>(x => x.User)
            //.WithMany(x => x.Articles)
            //.HasForeignKey(x => x.UserId);
            //base.OnModelCreating(modelBuilder);
        }
    }
}