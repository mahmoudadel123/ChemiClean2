using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAL.Models
{
    public partial class crossoverContext : DbContext
    {
        public crossoverContext()
        {
        }

        public crossoverContext(DbContextOptions<crossoverContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblProduct> TblProduct { get; set; }

      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblProduct>(entity =>
            {
                entity.ToTable("tblProduct");

                entity.Property(e => e.DownLoadDate).HasColumnType("date");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.SupplierName).HasMaxLength(250);

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(300);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
