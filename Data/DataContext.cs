using Microsoft.EntityFrameworkCore;

namespace superhero_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<superhero> Superheroes => Set<superhero>();
    }
}
