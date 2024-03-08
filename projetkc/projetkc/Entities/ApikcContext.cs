using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;

namespace projetkc.Entities;

public partial class ApikcContext : DbContext
{
    public ApikcContext()
    {
    }

    public ApikcContext(DbContextOptions<ApikcContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Information> Information { get; set; }

    public virtual DbSet<Plante> Plantes { get; set; }

    public virtual DbSet<Type> Types { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Information>(entity =>
        {
            entity.HasKey(e => e.IdInformation).HasName("PRIMARY");

            entity.ToTable("information");

            entity.Property(e => e.IdInformation).HasColumnName("Id_information");
            entity.Property(e => e.Irrigation).HasMaxLength(50);
            entity.Property(e => e.Kc)
                .HasMaxLength(50)
                .HasColumnName("kc");
            entity.Property(e => e.Periode)
                .HasMaxLength(50)
                .HasColumnName("periode");
            entity.Property(e => e.Stades)
                .HasMaxLength(50)
                .HasColumnName("stades");
            entity.Property(e => e.Vergers).HasMaxLength(50);
        });

        modelBuilder.Entity<Plante>(entity =>
        {
            entity.HasKey(e => e.IdPlante).HasName("PRIMARY");

            entity.ToTable("plante");

            entity.HasIndex(e => e.IdInformation, "Id_information");

            entity.Property(e => e.IdPlante).HasColumnName("Id_plante");
            entity.Property(e => e.IdInformation).HasColumnName("Id_information");
            entity.Property(e => e.NomPlante)
                .HasMaxLength(50)
                .HasColumnName("nom_plante");

            entity.HasOne(d => d.IdInformationNavigation).WithMany(p => p.Plantes)
                .HasForeignKey(d => d.IdInformation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("plante_ibfk_1");
        });

        modelBuilder.Entity<Type>(entity =>
        {
            entity.HasKey(e => e.IdType).HasName("PRIMARY");

            entity.ToTable("type");

            entity.HasIndex(e => e.IdPlante, "Id_plante");

            entity.Property(e => e.IdType).HasColumnName("Id_type");
            entity.Property(e => e.IdPlante).HasColumnName("Id_plante");
            entity.Property(e => e.NomType)
                .HasMaxLength(50)
                .HasColumnName("nom_type");

            entity.HasOne(d => d.IdPlanteNavigation).WithMany(p => p.Types)
                .HasForeignKey(d => d.IdPlante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("type_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
