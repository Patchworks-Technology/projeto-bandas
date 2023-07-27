using Microsoft.EntityFrameworkCore;
using ProjetoBandas.Entidades;



namespace ProjetoBandas
{
    public class AlbunsContext : DbContext
    {
        public AlbunsContext(DbContextOptions<AlbunsContext> options) : base(options) { }

        public DbSet<Album> Albuns { get; set; }
    }
}