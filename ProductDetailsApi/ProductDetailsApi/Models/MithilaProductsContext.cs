using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProductDetailsApi.Models
{
    public partial class MithilaProductsContext : DbContext
    {
        public MithilaProductsContext()
        {
        }

        public MithilaProductsContext(DbContextOptions<MithilaProductsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Products> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=mithilaorgdb.ckabxksv35jx.ap-south-1.rds.amazonaws.com,1433;Database=MithilaProducts;User Id=MithilaOrgDb;Password=vmckarna1993;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.ProductId })
                    .HasName("PK__products");

                entity.ToTable("products");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.ProductId)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasComputedColumnSql("('PID'+right('000000000'+CONVERT([varchar](8),[Id]),(8)))")
                    .ValueGeneratedNever();

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Painting')");

                entity.Property(e => e.Color)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Path)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SubCategory)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
