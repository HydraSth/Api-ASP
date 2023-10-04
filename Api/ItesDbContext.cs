using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Api;

public partial class ItesDbContext : DbContext
{
    public ItesDbContext()
    {
    }

    public ItesDbContext(DbContextOptions<ItesDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionString:DeafultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.Property(e => e.Basico).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Funcion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.Property(e => e.Productoid).HasColumnName("productoid");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(12, 0)")
                .HasColumnName("precio");
            entity.Property(e => e.Stock).HasColumnName("stock");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => new { e.Ticketid, e.Productoid }).HasName("PK_Tickets_1");

            entity.Property(e => e.Ticketid)
                .ValueGeneratedOnAdd()
                .HasColumnName("ticketid");
            entity.Property(e => e.Productoid).HasColumnName("productoid");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");

            entity.HasOne(d => d.Producto).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.Productoid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tickets_Productos");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
