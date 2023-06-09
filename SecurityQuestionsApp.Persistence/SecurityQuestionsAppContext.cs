using Microsoft.EntityFrameworkCore;
using SecurityQuestionsApp.Models;

namespace SecurityQuestionsApp.Persistence
{
    public class SecurityQuestionsAppContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<SecurityQuestion> SecurityQuestions { get; set; }
        public DbSet<SecurityAnswer> SecurityAnswers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SecurityQuestionsAppDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.SecurityAnswers)
                .WithOne(e => e.Person);

            // Configure the initial migration
            modelBuilder.Entity<SecurityQuestion>().HasData(
                    new SecurityQuestion { Id = 1, Question = "In what city were you born?" },
                    new SecurityQuestion { Id = 2, Question = "What is the name of your favorite pet?" },
                    new SecurityQuestion { Id = 3, Question = "What is your mother's maiden name?" },
                    new SecurityQuestion { Id = 4, Question = "What high school did you attend?" },
                    new SecurityQuestion { Id = 5, Question = "What was the mascot of your high school?" },
                    new SecurityQuestion { Id = 6, Question = "What was the make of your first car?" },
                    new SecurityQuestion { Id = 7, Question = "What was your favorite toy as a child?" },
                    new SecurityQuestion { Id = 8, Question = "Where did you meet your spouse?" },
                    new SecurityQuestion { Id = 9, Question = "What is your favorite meal?" },
                    new SecurityQuestion { Id = 10, Question = "Who is your favorite actor/actress?" },
                    new SecurityQuestion { Id = 11, Question = "What is your favorite album?" }
            );
        }
    }
}