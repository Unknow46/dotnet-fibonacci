using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Fibonacci
{
    public partial class FibonacciDataContext : DbContext
    {
        public FibonacciDataContext()
        {
        }

        public FibonacciDataContext(DbContextOptions<FibonacciDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TFibonacci> TFibonacci { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=localhost,1433;Initial Catalog=FibonacciData;Integrated Security=False;User ID=sa;Password=Your_password123;MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TFibonacci>(entity =>
            {
                entity.HasKey(e => e.FibId)
                    .HasName("PK_Fibonacci");

                entity.ToTable("TFibonacci", "sch_fib");

                entity.Property(e => e.FibId)
                    .HasColumnName("FIB_Id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.FibInput).HasColumnName("FIB_Input");

                entity.Property(e => e.FibOutput).HasColumnName("FIB_Output");

                entity.Property(e => e.FibCreatedTimeStamp).HasColumnName("FIB_TimeStamp");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}