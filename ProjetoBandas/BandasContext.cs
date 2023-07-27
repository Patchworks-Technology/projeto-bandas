using Microsoft.EntityFrameworkCore;
using ProjetoBandas.Entidades;

namespace ProjetoBandas
{
    public class BandasContext : DbContext
    {
        public BandasContext(DbContextOptions<BandasContext> options) : base(options) { }

        public DbSet<Banda> Bandas { get; set; }
    }
}
