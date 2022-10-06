using Microsoft.EntityFrameworkCore;

namespace locadora.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<CategoriadeFilme> Categorias { get; set; }
        public DbSet<Filmes> Filmes { get; set; }
    }
}