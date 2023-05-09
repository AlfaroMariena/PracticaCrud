using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CMAH.AppMVC.Models;

public partial class CmahContext : DbContext
{
    public CmahContext()
    {
    }

    public CmahContext(DbContextOptions<CmahContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Proveedore> Proveedores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Proveedore>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("proveedores");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Direccion).HasMaxLength(100);
            entity.Property(e => e.NombreProveedor).HasMaxLength(55);
            entity.Property(e => e.Telefono).HasMaxLength(45);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
