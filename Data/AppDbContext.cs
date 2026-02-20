using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using apiUsuarios.Models;
namespace apiUsuarios.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }

    }
}
