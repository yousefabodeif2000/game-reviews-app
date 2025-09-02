using game_reviews_app.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace game_reviews_app.Data
{
    public class DBContext: IdentityDbContext<User>
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }
        public DbSet<Game> Games { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = "1",
                    UserName = "testuser",
                    NormalizedUserName = "TESTUSER",
                    Email = "testuser@example.com",
                    NormalizedEmail = "TESTUSER@EXAMPLE.COM",
                    EmailConfirmed = true,
                    DisplayName = "Yousef",

                    // Required Identity fields with STATIC values
                    SecurityStamp = "STATIC-SECURITY-STAMP-0001",
                    ConcurrencyStamp = "STATIC-CONCURRENCY-STAMP-0001",
                    PasswordHash = "AQAAAAEAACcQAAAAEFAKEHASH123456==", // fake hash
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = false,
                    AccessFailedCount = 0
                });


            modelBuilder.Entity<Favorite>().HasIndex(f => new { f.GameId, f.UserId }).IsUnique(); //users can't favorite a game twice.
            modelBuilder.Entity<Game>().Property(g => g.Rating).HasPrecision(3, 2); // Set precision for rating to 3 digits total, 2 decimal places
        }
    }
}
