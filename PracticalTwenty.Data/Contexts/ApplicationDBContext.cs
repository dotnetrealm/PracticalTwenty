using Microsoft.EntityFrameworkCore;
using PracticalSeventeen.Data.Models;
using PracticalTwenty.Data.Models;

namespace PracticalTwenty.Data.Contexts
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedUsers();
        }
    }
}
