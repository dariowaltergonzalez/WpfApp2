using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WpfApp2.Entities;

public partial class PruebasContext : DbContext
{
    public PruebasContext()
    {
    }
      

    public DbSet<Sucursales> Sucursal { get; set; }

    public DbSet<Usuarios> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=BANGHOMAX\\SQLEXPRESS;user=sa;password=avestruz;database=Pruebas;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.Entity<Sucursales>(entity =>
        {
            entity.ToTable("SUCURSAL");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Sucursal)
                .HasMaxLength(50)
                .HasColumnName("SUCURSAL");
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_USUARIOS");

            entity.ToTable("USUARIOS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Activo).HasColumnName("ACTIVO");
            entity.Property(e => e.Pass)
                .HasMaxLength(50)
                .HasColumnName("PASS");
            entity.Property(e => e.Sucursal).HasColumnName("SUCURSAL");
            entity.Property(e => e.Usuario)
                .HasMaxLength(50)
                .HasColumnName("USUARIO");
            entity.Property(e => e.Usuariobloqueado).HasColumnName("USUARIOBLOQUEADO");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
