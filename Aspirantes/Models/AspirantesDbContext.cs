using Aspirantes.Models;
using Microsoft.EntityFrameworkCore;

public class AspiranteDbContext : DbContext
{
    public AspiranteDbContext(DbContextOptions<AspiranteDbContext> options) : base(options)
    {
    }

    public DbSet<Aspirante> Aspirantes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuración de la clave primaria para la entidad Aspirante
        modelBuilder.Entity<Aspirante>().HasKey(a => a.Id);
    }
}
