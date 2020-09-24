using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CycleAPI.Models
{
    public partial class masterContext : DbContext
    {

        public masterContext(DbContextOptions<masterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RideMetric> RideMetrics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RideMetric>(entity =>
            {
                entity.Property(e => e.Distance)
                    .HasColumnType("decimal(18, 0)")
                    .HasAnnotation("Relational:ColumnType", "decimal(18, 0)");

                entity.Property(e => e.Time)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
