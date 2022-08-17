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
        DbSet<User> Users { get; set; }
        DbSet<Post> Posts { get; set; }
        DbSet<Theme> Themes { get; set; }
        DbSet<Comment> Comments { get; set; }
        DbSet<RefreshToken> RefreshTokens{get;set;}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Post>().HasOne(u => u.User).WithMany(c => c.Posts).HasForeignKey(u => u.UserId).IsRequired(false).OnDelete(DeleteBehavior.SetNull);
            builder.Entity<Post>().HasMany(u => u.Comments).WithOne(c => c.Post).HasForeignKey(u => u.PostId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Comment>().HasOne(u => u.User).WithMany(c => c.Comments).HasForeignKey(u => u.UserId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
