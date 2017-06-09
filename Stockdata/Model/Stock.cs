namespace Stockdata.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Stock")]
    public partial class Stock
    {
        public int ID { get; set; }

        public int SID { get; set; }

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
        public decimal? CashDividend { get; set; }

        [Column(TypeName = "money")]
        public decimal? StockDividendRE { get; set; }

        [Column(TypeName = "money")]
        public decimal? StockDividendCR { get; set; }
    }
}
