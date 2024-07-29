using AnotherQuizAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace AnotherQuizAPI.Data
{
    public class QuizDBContext : DbContext
    {
        public QuizDBContext(DbContextOptions<QuizDBContext> options)
            : base(options)
        {

        }

        public DbSet<QuizList> QuizLists { get; set; }
        public DbSet<QuizItem> QuizItems { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Result> Results { get; set; }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<Result>()
        //         .HasMany(r => r.QuizLists)
        //         .WithMany(q => q.Results)
        //         .UsingEntity<QuizListResult>();
        // }
    }
}