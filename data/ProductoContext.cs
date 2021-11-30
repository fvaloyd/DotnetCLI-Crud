using Microsoft.EntityFrameworkCore;
using Practica.Models;

namespace Practica.data
{
    public class ProductoContext : DbContext
    {

        public ProductoContext(DbContextOptions<ProductoContext> options):base(options)
        {

        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    
    }
}