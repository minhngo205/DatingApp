using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.DatingApp.API.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.DatingApp.API.Database
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        
        public DbSet<User> Users { get; set; }

        public DbSet<UserLike> UserLikes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<UserLike>()
                .HasKey(k => new { k.likedUserID, k.srcUserID });

            builder.Entity<UserLike>()
                .HasOne(s => s.srcUser)
                .WithMany(s => s.SourceUsers)
                .HasForeignKey(k => k.srcUserID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<UserLike>()
                .HasOne(s => s.likedUser)
                .WithMany(s => s.LikedUsers)
                .HasForeignKey(k => k.likedUserID)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}