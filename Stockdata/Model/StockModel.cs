namespace Stockdata.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Stockdata.Model;

    public partial class StockModel : DbContext
    {
        public StockModel()
            : base("name=StockModel")
        {
            Database.SetInitializer<StockModel>(null);
        }

        public virtual DbSet<Stock> Stock { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stock>()
                .Property(e => e.ExR)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Stock>()
                .Property(e => e.ExD)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Stock>()
                .Property(e => e.CashDividend)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Stock>()
                .Property(e => e.StockDividendRE)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Stock>()
                .Property(e => e.StockDividendCR)
                .HasPrecision(19, 4);
        }
    }
}
