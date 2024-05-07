using API.Docentes.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Docentes.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ciudad>()
                .HasOne(d => d.Docente)
                .WithOne(c => c.Ciudad)
                .HasForeignKey<Docente>(d => d.CiudadId);

            modelBuilder.Entity<EscalafonTecnico>()
                .HasOne(d => d.Docente)
                .WithOne(c => c.EscalafonTecnico)
                .HasForeignKey<Docente>(d => d.EscalafonTecnicoId);

            modelBuilder.Entity<EscalafonExtension>()
                .HasOne(d => d.Docente)
                .WithOne(c => c.EscalafonExtension)
                .HasForeignKey<Docente>(d => d.EscalafonExtensionId);
        }

        public DbSet <Docente> Docentes { get; set; }   
        public DbSet<Ciudad> Ciudades { get; set; }

        public DbSet<EscalafonTecnico> EscalafonTecnicos { get; set; }

        public DbSet<EscalafonExtension> EscalafonExtensiones { get; set; }
        public DbSet <Usuario> Usuarios { get; set; }
    }
}
