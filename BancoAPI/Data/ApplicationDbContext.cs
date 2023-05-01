using BancoAPI.Modelos;
using Microsoft.EntityFrameworkCore;

namespace BancoAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Movimientos> Movimientos { get; set; }
    }
}