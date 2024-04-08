using Microsoft.EntityFrameworkCore;

namespace Group2Intex.Models
{
    public class IntexContext : DbContext
    {
        public IntexContext (DbContextOptions<IntexContext> options) : base(options) { }

        public DbSet<Project> Projects { get; set; }
    }
}
