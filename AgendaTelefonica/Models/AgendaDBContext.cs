using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AgendaTelefonica.Models
{
    public partial class AgendaDBContext : DbContext
    {
        public AgendaDBContext()
        {
        }

        public AgendaDBContext(DbContextOptions<AgendaDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agenda> Agenda { get; set; }
        public virtual DbSet<CompaniaTelefonica> CompaniaTelefonica { get; set; }
        public virtual DbSet<Contacto> Contacto { get; set; }
        public virtual DbSet<Direccion> Direccion { get; set; }
        public virtual DbSet<Email> Email { get; set; }
        public virtual DbSet<Telefono> Telefono { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=JUAN-PC\\SQLEXPRESS;Database=AgendaDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agenda>(entity =>
            {
                entity.HasKey(e => e.IdAgenda);

                entity.Property(e => e.NombreAgenda)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CompaniaTelefonica>(entity =>
            {
                entity.HasKey(e => e.IdCompania);

                entity.Property(e => e.NombreCompania)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Contacto>(entity =>
            {
                entity.HasKey(e => e.IdContacto);

                entity.Property(e => e.IdContacto).HasColumnName("idContacto");

                entity.Property(e => e.NombreCompleto)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Direccion>(entity =>
            {
                entity.HasKey(e => e.IdDireccion);

                entity.Property(e => e.Calle)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdContacto).HasColumnName("idContacto");

                entity.Property(e => e.IdDireccion).HasColumnName("idDireccion");

                entity.Property(e => e.Localidad)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Provincia)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Email>(entity =>
            {
                entity.HasKey(e => e.IdEmail);

                entity.Property(e => e.CorreoElectronico)
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.IdEmail).HasColumnName("idEmail");
            });

            modelBuilder.Entity<Telefono>(entity =>
            {
                entity.HasKey(e => e.IdTelefono);

                entity.Property(e => e.IdContacto).HasColumnName("idContacto");

                entity.Property(e => e.IdTelefono).HasColumnName("idTelefono");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
