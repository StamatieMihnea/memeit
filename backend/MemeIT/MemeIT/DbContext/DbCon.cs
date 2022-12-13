using MemeIT.Entities;
using Microsoft.EntityFrameworkCore;

namespace MemeIT.DbContext
{
    public class DbCon : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbCon(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Meme> Meme { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();
        }
    }
}