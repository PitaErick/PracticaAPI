using Microsoft.EntityFrameworkCore;
using practica.models.Producto;

namespace practica.controllers.Database
{
    public class ContextDB : DbContext
    {
        public ContextDB(DbContextOptions<ContextDB> options) : base(options)
        {
        }
        public DbSet<ProductoModel> Productos { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProductoModel>().HasNoKey().ToView(null);
        }

    }
}
