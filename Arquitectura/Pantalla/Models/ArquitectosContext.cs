using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Pantalla.Models
{
    public partial class ArquitectosContext : DbContext
    {
        public ArquitectosContext()
        {
        }

        public ArquitectosContext(DbContextOptions<ArquitectosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<ClienteProyecto> ClienteProyecto { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<Proyecto> Proyecto { get; set; }
        public virtual DbSet<TipoProyecto> TipoProyecto { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=Marti;Database=Arquitectos;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.Aporte).HasColumnType("money");

                entity.Property(e => e.Correo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClienteProyecto>(entity =>
            {
                entity.HasKey(e => new { e.IdCliente, e.IdProyecto })
                    .HasName("Cliented_pk");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.ClienteProyecto)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cliente");

                entity.HasOne(d => d.IdProyectoNavigation)
                    .WithMany(p => p.ClienteProyecto)
                    .HasForeignKey(d => d.IdProyecto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Proyecto");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.Property(e => e.Correo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nomina)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdProyectoNavigation)
                    .WithMany(p => p.Empleado)
                    .HasForeignKey(d => d.IdProyecto)
                    .HasConstraintName("FK__Empleado__IdProy__1FCDBCEB");
            });

            modelBuilder.Entity<Proyecto>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Presup)
                    .HasColumnName("presup")
                    .HasColumnType("money");

                entity.Property(e => e.Residen)
                    .HasColumnName("residen")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.IdJefeNavigation)
                    .WithMany(p => p.Proyecto)
                    .HasForeignKey(d => d.IdJefe)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Proyecto__IdJefe__1B0907CE");

                entity.HasOne(d => d.TipoNavigation)
                    .WithMany(p => p.Proyecto)
                    .HasForeignKey(d => d.Tipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Proyecto__Tipo__1A14E395");
            });

            modelBuilder.Entity<TipoProyecto>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasIndex(e => e.IdEmpleado)
                    .HasName("UQ__Usuario__CE6D8B9F49A97664")
                    .IsUnique();

                entity.Property(e => e.Contraseña)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario1)
                    .IsRequired()
                    .HasColumnName("Usuario")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithOne(p => p.Usuario)
                    .HasForeignKey<Usuario>(d => d.IdEmpleado)
                    .HasConstraintName("FK__Usuario__IdEmple__1367E606");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
