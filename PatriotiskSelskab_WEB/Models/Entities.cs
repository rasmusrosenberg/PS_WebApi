namespace PatriotiskSelskab_WEB.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }

        public virtual DbSet<Crop> Crops { get; set; }
        public virtual DbSet<FieldBlock> FieldBlocks { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<Result> Results { get; set; }
        public virtual DbSet<SubBlock> SubBlocks { get; set; }
        public virtual DbSet<Treatment> Treatments { get; set; }
        public virtual DbSet<Treatment_Product> Treatment_Products { get; set; }
        public virtual DbSet<TreatmentType> TreatmentTypes { get; set; }
        public virtual DbSet<TrialGroup> TrialGroups { get; set; }
        public virtual DbSet<TrialType> TrialTypes { get; set; }
        public virtual DbSet<UnitType> UnitTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FieldBlock>()
                .Property(e => e.Comment)
                .IsUnicode(false);

            modelBuilder.Entity<SubBlock>()
                .Property(e => e.Comment)
                .IsUnicode(false);

            modelBuilder.Entity<Treatment>()
                .Property(e => e.Comment)
                .IsUnicode(false);

            modelBuilder.Entity<Treatment_Product>()
                .Property(e => e.ProductDose)
                .HasPrecision(8, 2);

            modelBuilder.Entity<TrialGroup>()
                .Property(e => e.Comment)
                .IsUnicode(false);

            modelBuilder.Entity<UnitType>()
                .HasMany(e => e.Treatment_Product)
                .WithOptional(e => e.UnitType)
                .HasForeignKey(e => e.ProductUnit);
        }
    }
}
