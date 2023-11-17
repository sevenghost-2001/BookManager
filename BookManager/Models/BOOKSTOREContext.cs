using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BookManager.Models
{
    public partial class BOOKSTOREContext : DbContext
    {
        public BOOKSTOREContext()
        {
        }

        public BOOKSTOREContext(DbContextOptions<BOOKSTOREContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Sach> Saches { get; set; } = null!;
        public virtual DbSet<TheLoai> TheLoais { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-3U33KT3\\MSSQLSERVER01;Initial Catalog=BOOKSTORE;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sach>(entity =>
            {
                entity.HasKey(e => e.MaSach)
                    .HasName("PK_Books");

                entity.ToTable("Sach");

                entity.Property(e => e.Hinh).HasMaxLength(150);

                entity.Property(e => e.TacGia).HasMaxLength(500);

                entity.Property(e => e.TenSach).HasMaxLength(250);

                entity.Property(e => e.TheLoai)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.TheLoaiNavigation)
                    .WithMany(p => p.Saches)
                    .HasForeignKey(d => d.TheLoai)
                    .HasConstraintName("FK_Sach_TheLoai");
            });

            modelBuilder.Entity<TheLoai>(entity =>
            {
                entity.HasKey(e => e.MaTheLoai);

                entity.ToTable("TheLoai");

                entity.Property(e => e.MaTheLoai)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TenTheLoai).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
