using Microsoft.EntityFrameworkCore;
using Peliculas_Api.Entidades;

namespace Peliculas_Api
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Genero> Generos { get; set; }
        
    }
}
