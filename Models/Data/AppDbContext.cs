using Microsoft.EntityFrameworkCore;
using LojaT.Models.Entities;

namespace LojaT.Models.Data 
{ 
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Cliente> Clientes { get; set; }
    }
}