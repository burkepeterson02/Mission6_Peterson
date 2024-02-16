using Microsoft.EntityFrameworkCore;

namespace Mission6_Peterson.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base (options) 
        { 
        }

        public DbSet<MovieModel> Movies { get; set; }
    }
}
