using Microsoft.EntityFrameworkCore;
using MoviesAnalysis.Models;

namespace MoviesAnalysis.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }
    }
}
