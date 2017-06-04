﻿using Stockdata.Model;
using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Collections.Specialized;

namespace Stockdata
{
    public class stock
    {
            public int SID { get; set; }
            public DateTime Sdate { get; set; }
            public DateTime ExRdate { get; set; }
            public Decimal ExR { get; set; }
            public DateTime ExDdate { get; set; }
            public Decimal ExD { get; set; }
            public DateTime Cashdate { get; set; }
            public Decimal CashDividend { get; set; }
            public Decimal StockDividendRE { get; set; }
            public Decimal StockDividendCR { get; set; }
    }
    class Program
    {

        static void Main(string[] args)
        {
            //Stock data = new Stock();
            //data.SID = 1;
            //data.Sdate = Convert.ToDateTime("2015-05-29");
            //data.ExRdate = Convert.ToDateTime("2015-05-29");
            //data.ExR = (Decimal)79.5;
            //data.ExRdate = Convert.ToDateTime("2015-05-29");
            //data.ExD = (Decimal)80.5;
            //data.ExDdate= Convert.ToDateTime("2016-05-29");
            //data.Cashdate = Convert.ToDateTime("2015-05-29");
            //data.CashDividend = (Decimal)1.5;
            //data.StockDividendRE = (Decimal)5.5;
            //data.StockDividendCR = (Decimal)9.5;

            //Model1 model = new Model1();
            //model.Stock.Add(data);
            //model.SaveChanges();
            GetStock("2317");

        }
        static void GetStock(string Stockid)
        {
            WebClient wc = new WebClient();
            wc.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            var nvc = new NameValueCollection();
            nvc["is_check"] = "1";
            var buffer = wc.UploadValues(string.Format("http://goodinfo.tw/StockInfo/StockDividendSchedule.asp?STOCK_ID={0}", Stockid), nvc);
            var htmlstr = Encoding.UTF8.GetString(buffer);


            MemoryStream ms = new MemoryStream(buffer);
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(htmlstr);
            //doc.Load(ms, Encoding.UTF8);
            HtmlDocument hdc = new HtmlDocument();
            //*[@id="tb_chart"]/tbody/tr[1]/td[1]

            //List<stock> nowStock = new List<stock>();
            //var table = doc.DocumentNode.SelectNodes("//*[@id='tb_chart']/tr");
            //var list_tr = table.ToList<HtmlNode>().Skip(1).Select(hn =>
            //{
            //    HtmlDocument hdctmp = new HtmlDocument();
            //    hdctmp.LoadHtml(hn.InnerHtml);
            //    var o = new stock();
            //    var toStock = hdctmp.DocumentNode
            //            .SelectNodes("//td")
            //            .Select(hn2 => hn2.InnerText)
            //            .ToArray();
            //    o.Time = DateTime.Parse(toStock[0]);
            //    o.BuyPrice = toStock[1] == "--" ? null : (decimal?)Decimal.Parse(toStock[1]);
            //    o.SellingPrice = toStock[2] == "--" ? null : (decimal?)Decimal.Parse(toStock[2]);
            //    o.FinalPrice = Decimal.Parse(toStock[3]);
            //    o.Volume = Int32.Parse(toStock[5]);
            //    o.AccumulatedVolume = Int32.Parse(toStock[6]);
            //    return o;
            //}).ToList();


            var table = doc.DocumentNode.SelectNodes("//*[@id=\"row1\"]/td[5]");
            Console.WriteLine(table);
            Console.Read();



        }

    }

}
