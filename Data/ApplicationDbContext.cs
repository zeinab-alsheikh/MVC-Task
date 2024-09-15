using Microsoft.EntityFrameworkCore;
using Task_MVC.Models;

namespace Task_MVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
      : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
