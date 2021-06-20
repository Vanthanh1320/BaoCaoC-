namespace ModelEF.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class VoVanThanhContext : DbContext
    {
        public VoVanThanhContext()
            : base("name=VoVanThanhContext")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<UserAccount> UserAccounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.UnitCost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.Image)
                .IsUnicode(false);
        }
    }
}
