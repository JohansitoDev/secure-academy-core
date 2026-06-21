using Microsoft.EntityFrameworkCore;
using SistemaEscolar.Domain.Entities;

namespace SistemaEscolar.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public DbSet<Estudiante> Estudiantes => Set<Estudiante>();
    public DbSet<Profesor> Profesores => Set<Profesor>();
    public DbSet<Calificacion> Calificaciones => Set<Calificacion>();

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.ToTable("Estudiantes");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Matricula).IsRequired().HasMaxLength(20);
            entity.HasIndex(e => e.Matricula).IsUnique();
            entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Apellido).IsRequired().HasMaxLength(100);
            entity.Property(e => e.CorreoElectronico).IsRequired().HasMaxLength(150);
        });

        modelBuilder.Entity<Profesor>(entity =>
        {
            entity.ToTable("Profesores");
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Nombre).IsRequired().HasMaxLength(100);
            entity.Property(p => p.Apellido).IsRequired().HasMaxLength(100);
            entity.Property(p => p.CorreoElectronico).IsRequired().HasMaxLength(150);
        });

        modelBuilder.Entity<Calificacion>(entity =>
        {
            entity.ToTable("Calificaciones");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.NotaTeorica).IsRequired();
            entity.Property(c => c.NotaPractica).IsRequired();
            
            entity.HasOne<Estudiante>()
                  .WithMany(e => e.Calificaciones)
                  .HasForeignKey(c => c.EstudianteId)
                  .OnDelete(DeleteBehavior.Cascade);
        });
    }
}