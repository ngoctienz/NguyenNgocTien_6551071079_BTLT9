using System;
using C3_QuanLyDaNgoai.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace C3_QuanLyDaNgoai.Models.EF
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChuyenDi> ChuyenDis { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Program.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChuyenDi>(entity =>
            {
                entity.HasKey(e => e.MaChuyen);

                entity.ToTable("ChuyenDi");

                entity.Property(e => e.TenChuyen)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DiaDiem)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.NgayDi)
                    .HasColumnType("date");

                entity.Property(e => e.NganSach)
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.PhuongTien)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.GhiChu)
                    .HasMaxLength(200);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}