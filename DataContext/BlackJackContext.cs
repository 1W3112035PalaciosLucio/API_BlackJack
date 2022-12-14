using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BlackJack_Api.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BlackJack_Api.DataContext
{
    public partial class BlackJackContext : DbContext
    {
        public BlackJackContext()
        {
        }

        public BlackJackContext(DbContextOptions<BlackJackContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cartas> Cartas { get; set; }
        public virtual DbSet<Detallepartida> Detallepartida { get; set; }
        public virtual DbSet<Juegos> Juegos { get; set; }
        public virtual DbSet<Partida> Partida { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;database=BlackJack;port=3306;user id=root;password=45262", x => x.ServerVersion("8.0.30-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cartas>(entity =>
            {
                entity.ToTable("cartas");

                entity.Property(e => e.Disponible)
                    .HasColumnName("disponible")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.Numero).HasColumnName("numero");

                entity.Property(e => e.Palo)
                    .IsRequired()
                    .HasColumnName("palo")
                    .HasColumnType("varchar(2)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<Detallepartida>(entity =>
            {
                entity.ToTable("detallepartida");

                entity.HasIndex(e => e.IdCarta)
                    .HasName("id_carta_idx");

                entity.HasIndex(e => e.IdPartida)
                    .HasName("Usuarios_Cartas_Juegos");

                entity.Property(e => e.IdCarta).HasColumnName("id_carta");

                entity.Property(e => e.IdPartida).HasColumnName("id_partida");

                entity.HasOne(d => d.IdCartaNavigation)
                    .WithMany(p => p.Detallepartida)
                    .HasForeignKey(d => d.IdCarta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("UsuariosCartas");

                entity.HasOne(d => d.IdPartidaNavigation)
                    .WithMany(p => p.Detallepartida)
                    .HasForeignKey(d => d.IdPartida)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("UsuariosPartidas");
            });

            modelBuilder.Entity<Juegos>(entity =>
            {
                entity.ToTable("juegos");

                entity.HasIndex(e => e.Id)
                    .HasName("Juegos_Usuarios_idx");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("Juegos_Usuarios");

                entity.Property(e => e.Activo)
                    .HasColumnName("activo")
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Juegos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Juegos_Usuarios");
            });

            modelBuilder.Entity<Partida>(entity =>
            {
                entity.ToTable("partida");

                entity.HasIndex(e => e.Id)
                    .HasName("Juegos_Usuarios_idx");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("Partida_Usuarios");

                entity.Property(e => e.Activo)
                    .HasColumnName("activo")
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Partida)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Partida_Usuarios");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.ToTable("usuarios");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasColumnName("apellido")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasColumnName("clave");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
