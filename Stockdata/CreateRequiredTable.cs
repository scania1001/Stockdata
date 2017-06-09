using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.CSharp;
using System.Configuration;

namespace Stockdata
{
    public static class CreateRequiredTable
    {
        public static int PrepareTable()
        {
            try
            {
                var sqlCmdStr = @"
                    IF NOT EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[seq_StockDividendInformation]') AND type = 'SO')
                    BEGIN
                        CREATE SEQUENCE [dbo].[seq_StockDividendInformation] 
                         START WITH 1
                    END
                IF (NOT EXISTS (SELECT * 
                                 FROM INFORMATION_SCHEMA.TABLES 
                                 WHERE TABLE_SCHEMA = 'dbo' 
                                 AND  TABLE_NAME = 'StockDividendInformation'))
                BEGIN
                    CREATE TABLE [dbo].[StockDividendInformation] (
                     [ID] [int] NOT NULL default(next value for [dbo].[seq_StockDividendInformation]),
                     [SID] [int] NOT NULL,
                     Year int null,
                     [Sdate] [date] NULL,
                     [ExRdate] [date] NULL,
                     [ExR] [money] NULL,
                     [ExDdate] [date] NULL,
                     [ExD] [money] NULL,
                     [Cashdate] [date] NULL,
                     [CashDividendTotal] [money] NULL,
                     [StockDividendSurplus] [money] NULL,
                     [StockDividendCR] [money] NULL,
                     AvgStockPrice [money] NULL,
                     YieldRate [decimal] NULL,
                     CONSTRAINT [PK_StockDividendInformation] PRIMARY KEY NONCLUSTERED 
                    (
                     [ID] ASC
                    ), INDEX CX_SDI CLUSTERED ([SID], SDate)
                    )
                END

            ";
                var connStr = ConfigurationManager.ConnectionStrings["StockModel"].ConnectionString;
                var data = new Data.CSharp.Data(connStr);
                var sc = new SQLContext();
                sc.cmd = sqlCmdStr;
                sc.cmdTyp = System.Data.CommandType.Text;
                var rr = data.ExecuteSql(sc);
                if (rr.resultExp == null) {
                    return 1;
                } else
                {
                    return -1;
                }
            } catch
            {
                return -2;
            }
        }
    }
}
