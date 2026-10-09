using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Cliente> Clientes => Set<Cliente>();
    public DbSet<Puesto> Puestos => Set<Puesto>();
    public DbSet<Empleado> Empleados => Set<Empleado>();
    public DbSet<Marca> Marcas => Set<Marca>();
    public DbSet<Producto> Productos => Set<Producto>();
    public DbSet<Factura> Facturas => Set<Factura>();
    public DbSet<DetalleFactura> DetalleFacturas => Set<DetalleFactura>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>().HasIndex(c => c.Nit).IsUnique();
    }
}
