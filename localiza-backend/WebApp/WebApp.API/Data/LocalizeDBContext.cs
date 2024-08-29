using Microsoft.EntityFrameworkCore;
using WebApp.API.Data.Map;
using WebApp.API.Entities;

namespace WebApp.API.Data
{
    public class LocalizeDBContext : DbContext
    {
        public LocalizeDBContext(DbContextOptions<LocalizeDBContext> options)
            : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Cobranca> Cobrancas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new CobrancaMap());

            base.OnModelCreating(modelBuilder);
        }

    }
}
