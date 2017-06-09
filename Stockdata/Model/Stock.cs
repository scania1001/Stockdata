namespace Stockdata.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("StockDividendInformation")]
    public partial class Stock
    {
        
        [Key]
        //[DefaultValue("next value for seq_StockDividendInformation")]
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int ID { get; set; }

        public int SID { get; set; }

        public int Year { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Sdate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ExRdate { get; set; }

        [Column(TypeName = "money")]
        public decimal? ExR { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ExDdate { get; set; }

        [Column(TypeName = "money")]
        public decimal? ExD { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Cashdate { get; set; }

        [Column(TypeName = "money")]
        public decimal? CashDividendTotal { get; set; }

        [Column(TypeName = "money")]
        public decimal? StockDividendSurplus { get; set; }

        [Column(TypeName = "money")]
        public decimal? StockDividendCR { get; set; }

        [Column(TypeName = "money")]
        public decimal? AvgStockPrice { get; set; }
        
        public decimal? YieldRate { get; set; }
    }
}
