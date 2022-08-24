using FiveMinusThree.Api.Models;
using Microsoft.EntityFrameworkCore;
namespace FiveMinusThree.Api.Data
{
    public class FiveMinusThreeContext : DbContext
    {
        //TODO => Add relations => Figure out how to store claims
        public FiveMinusThreeContext(DbContextOptions<FiveMinusThreeContext> contextOptions ):base(contextOptions)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<RefreshToken> RefreshTokens{get;set;}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                 .HasMany(c => c.Posts)
                 .WithOne(c => c.User)
                 .HasForeignKey(c => c.UserId)
                 .IsRequired(false)
                 .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<Reply>()
                .HasOne(c => c.User)
               .WithMany(c => c.Replies)
               .HasForeignKey(c => c.UserId)
               .IsRequired(false)
               .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
