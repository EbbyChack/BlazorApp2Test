using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp2Test.Shared.Entities;

public partial class CdStoreContext : DbContext
{
    public CdStoreContext()
    {
    }

    public CdStoreContext(DbContextOptions<CdStoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cd> Cds { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderCd> OrderCds { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=EBBY\\SQLEXPRESS;Database=CD_STORE;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cd>(entity =>
        {
            entity.HasKey(e => e.IdCd);

            entity.ToTable("Cd");

            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.IdOrder);

            entity.ToTable("Order");

            entity.Property(e => e.FkUserId).HasColumnName("FK_UserId");
            entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.FkUser).WithMany(p => p.Orders)
                .HasForeignKey(d => d.FkUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_User");
        });

        modelBuilder.Entity<OrderCd>(entity =>
        {
            entity.HasKey(e => e.IdOrderCd);

            entity.ToTable("OrderCd");

            entity.Property(e => e.FkIdCd).HasColumnName("FK_IdCd");
            entity.Property(e => e.FkIdOrder).HasColumnName("FK_IdOrder");

            entity.HasOne(d => d.FkIdCdNavigation).WithMany(p => p.OrderCds)
                .HasForeignKey(d => d.FkIdCd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderCd_Cd");

            entity.HasOne(d => d.FkIdOrderNavigation).WithMany(p => p.OrderCds)
                .HasForeignKey(d => d.FkIdOrder)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderCd_Order");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser);

            entity.ToTable("User");

            entity.Property(e => e.UserType).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
