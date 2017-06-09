namespace Stockdata.Model
{
    using System;    
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using System.Configuration;

    public partial class StockModel : DbContext
    {
        public StockModel()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
            string sConnString = ConfigurationManager.ConnectionStrings["StockModel"].ConnectionString;
            optionbuilder.UseSqlServer(sConnString);
        }
        public virtual DbSet<Stock> Stock { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ForSqlServerHasSequence<int>("seq_StockDividendInformation");

            modelBuilder.Entity<Stock>()
                .Property(e => e.ExR)
                .HasColumnType("decimal(19, 4)");


            modelBuilder.Entity<Stock>()
                .Property(e => e.ID)
                .HasDefaultValueSql("NEXT VALUE FOR seq_StockDividendInformation");

            modelBuilder.Entity<Stock>()
                .Property(e => e.ExD)
                .HasColumnType("decimal(19, 4)");

            modelBuilder.Entity<Stock>()
                .Property(e => e.CashDividendTotal)
                .HasColumnType("decimal(19, 4)");

            modelBuilder.Entity<Stock>()
                .Property(e => e.StockDividendSurplus)
                .HasColumnType("decimal(19, 4)");

            modelBuilder.Entity<Stock>()
                .Property(e => e.StockDividendCR)
                .HasColumnType("decimal(19, 4)");

            modelBuilder.Entity<Stock>()
                .Property(e => e.AvgStockPrice)
                .HasColumnType("decimal(19, 4)");
            
        }
    }
}
