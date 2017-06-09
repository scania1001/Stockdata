#define DEBUG6438
using Stockdata.Model;

using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Collections.Specialized;
using System.Threading;
using System.Configuration;

namespace Stockdata
{
    public class stock
    {
        public int SID { get; set; } //股票代碼
        public int Year { get; set; }
        public DateTime? Sdate { get; set; }//股東會日期
        public DateTime? ExRdate { get; set; }//除息日期
        public Decimal? ExR { get; set; }//除息價格
        public DateTime? ExDdate { get; set; }//除權日期
        public Decimal? ExD { get; set; }//除權價格
        public DateTime? Cashdate { get; set; }//現金股利發放日
        public Decimal? CashDividendTotal { get; set; }//現金股利
        public Decimal? StockDividendSurplus { get; set; }//盈餘配股
        public Decimal? StockDividendCR { get; set; }//股利合計
        public Decimal? AvgStockPrice { get; set; }
        public Decimal? YieldRate { get; set; }
    }
    public class Program
    {
        static int Main(string[] args)
        {            
            #if DEBUG6438
            if (args.Length >= 0)
            #else
            if (args.Length > 0)
            #endif
            {
                var sid = args.Length > 0 ? args[0] : "6438";
                try
                {
                    GetStock(sid);
                    return 0;
                }
                catch (Exception exn)
                {
                    Console.WriteLine("Internal Error: {0}", exn.Message);
                    return -2;
                }
            }
            else
            {
                Console.WriteLine("Please Provide Stock Id");
                return -1;
            }
        }
        static void GetStock(string Stockid)
        {
            var ct = CreateRequiredTable.PrepareTable();
            if(ct != 1)
            {
                throw new Exception("Target table not exists!");
            }
            var url = ConfigurationManager.AppSettings["DIVURL"];
            var sleep = Int32.Parse(ConfigurationManager.AppSettings["SLEEP"]);
            using (WebClient wc = new WebClient())
            {
                wc.Encoding = Encoding.UTF8;//換成UTF8避免亂碼
                wc.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

                var htmlstr = wc.DownloadString(string.Format(url, Stockid));
                Thread.Sleep(sleep);
                HtmlDocument doc = new HtmlDocument();
                HtmlDocument hdc = new HtmlDocument();
                HtmlDocument hdd = new HtmlDocument();
                doc.LoadHtml(htmlstr);

                var table = doc.DocumentNode.SelectNodes("//*[@id=\"divDetail\"]");//抓table
                var list_tr = table.ToList<HtmlNode>()[0];//第1個table
                hdc.LoadHtml(list_tr.InnerHtml);//解析html
                var tr_in_tbl = hdc.DocumentNode.SelectNodes("//tr");
                var td_in_tr = tr_in_tbl.ToList<HtmlNode>();
                var fet = td_in_tr.Skip(3).Take(17);
                var fe = fet.Select(tr =>
                {
                    hdd.LoadHtml(tr.InnerHtml);

                    var toStock =
                        hdd.DocumentNode.SelectNodes("//td")
                            .Select(tr2 => tr2.InnerText)
                            .ToArray();

                    var o = new stock();
                    o.SID                   = Int32.Parse(Stockid);
                    o.Year                  = Int32.Parse(toStock[0]);
                    o.Sdate                 = toStock[2 ] == "" ? null : (DateTime?)DateTime.Parse(toStock[2 ]);                    
                    o.ExRdate               = toStock[3 ] == "" ? null : (DateTime?)DateTime.Parse(toStock[3 ]);
                    o.ExR                   = toStock[4 ] == "" ? null : (Decimal?)  Decimal.Parse(toStock[4 ]);
                    o.ExDdate               = toStock[5 ] == "" ? null : (DateTime?)DateTime.Parse(toStock[5 ]);
                    o.ExD                   = toStock[6 ] == "" ? null : (Decimal?)  Decimal.Parse(toStock[6 ]);
                    o.Cashdate              = toStock[7 ] == "" ? null : (DateTime?)DateTime.Parse(toStock[7 ]);
                    o.CashDividendTotal     = toStock[10] == "" ? null : (Decimal?)  Decimal.Parse(toStock[10]);
                    o.StockDividendSurplus  = toStock[11] == "" ? null : (Decimal?)  Decimal.Parse(toStock[11]);
                    o.StockDividendCR       = toStock[12] == "" ? null : (Decimal?)  Decimal.Parse(toStock[12]);
                    o.AvgStockPrice         = toStock[15] == "" ? null : (Decimal?)Decimal.Parse(toStock[15]);
                    o.YieldRate             = toStock[16] == "" ? null : (Decimal?)Decimal.Parse(toStock[16]);

                    return o;
                }).ToList();

                using (StockModel model = new StockModel())
                {
                    
                    foreach (var item in fe)
                    {
                        Stock data = new Stock();
                        data.SID = item.SID;
                        data.Sdate = item.Sdate;
                        data.ExRdate = item.ExRdate;
                        data.ExR = item.ExR;
                        data.ExDdate = item.ExDdate;
                        data.ExD = item.ExD;
                        data.Cashdate = item.Cashdate;
                        data.CashDividendTotal = item.CashDividendTotal;
                        data.StockDividendSurplus = item.StockDividendSurplus;
                        data.StockDividendCR = item.StockDividendCR;
                        data.AvgStockPrice = item.AvgStockPrice;
                        data.YieldRate = item.YieldRate;

                        model.Stock.Add(data);
                        
                        Console.WriteLine(Stockid);

                    }
                    model.SaveChanges();
                }

            }
        }

    }

}
