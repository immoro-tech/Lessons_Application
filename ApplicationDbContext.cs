using Lessons_Application_Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Lessons_Application_Backend
{
    class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-SLBDID4;DataBase=Lesson_DB;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }
}
