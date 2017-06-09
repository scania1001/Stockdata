using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Data.CSharp
{
    public class Data
    {
        private string connStr;
        private SqlConnection sqlConn;
        public Data(string configConnStr)
        {
            this.DataBase(configConnStr, null, null);
        }
        public Data(string configConnStr, Action<SqlCommand, ReturnResult> exnq, Action<SqlCommand, ReturnResult> fillds)
        {
            this.DataBase(configConnStr, exnq, fillds);
        }
        private void DataBase(string configConnStr, Action<SqlCommand, ReturnResult> exnq, Action<SqlCommand, ReturnResult> fillds)
        {
            connStr = configConnStr;
            sqlConn = new SqlConnection(connStr);
            Func<Action<SqlCommand, ReturnResult>, Func<SQLContext, ReturnResult>> dataGen = procCmd => {
                //Func<SQLContext, ReturnResult> gened =
                return ctx =>
                {
                    var rr = new ReturnResult();
                    rr.resultCtx = ctx;
                    rr.resultSQLConn = sqlConn;
                    try
                    {
                        if (sqlConn.State != ConnectionState.Open) { sqlConn.Open(); }
                        var sqlcmd = new SqlCommand(ctx.cmd, sqlConn);
                        sqlcmd.CommandTimeout = ctx.cmdTimeout;
                        if (ctx.cmdParams != null)
                        {
                            Array.ForEach(ctx.cmdParams, p => sqlcmd.Parameters.Add(p));
                        };
                        sqlcmd.CommandType = ctx.cmdTyp;
                        procCmd.Invoke(sqlcmd, rr);
                        rr.resultNo = 1;
                        rr.resultParams = ctx.cmdParams == null ? null : ctx.cmdParams.Where(p => p.Direction == ParameterDirection.Output || p.Direction == ParameterDirection.InputOutput);
                    }
                    catch (Exception e)
                    {
                        rr.resultNo = 0;
                        rr.resultExp = e;
                    }
                    return rr;
                };
                //return gened;
            };
            ExecuteSql = dataGen.Invoke(exnq != null ? exnq : (sqlcmd, rr) =>
            {
                sqlcmd.ExecuteNonQuery();
                sqlConn.Close();
                sqlConn.Dispose();
            });
            QuerySql = dataGen.Invoke(fillds != null ? fillds : (sqlcmd, rr) =>
            {
                var da = new SqlDataAdapter(sqlcmd);
                da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                var cb = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                rr.resultDS = ds;
                sqlConn.Close();
                sqlConn.Dispose();
            });
        }
        //~Data()
        //{
        //    sqlConn.Close();
        //    sqlConn.Dispose();
        //}
        public string ConnStr
        {
            get { return connStr; }
        }
        public SqlConnection SQLConn
        {
            get { return sqlConn; }
        }
        public Func<SQLContext, ReturnResult> ExecuteSql;
        public Func<SQLContext, ReturnResult> QuerySql;
    }
    public class ReturnResult
    {
        public int resultNo;
        public string resultMsg;
        public DataSet resultDS;
        public IEnumerable<SqlParameter> resultParams;
        public Exception resultExp;
        public SQLContext resultCtx;
        public SqlConnection resultSQLConn;
    }
    public class SQLContext
    {
        public int cmdTimeout = 30;
        public string cmd;
        public SqlParameter[] cmdParams;
        public CommandType cmdTyp;
        public void Params(Tuple<string, object>[] pArray)
        {
            if (pArray != null)
            {
                var curLen = this.cmdParams == null ? 0 : this.cmdParams.Length;
                var tmp = new SqlParameter[curLen + pArray.Length];
                if (this.cmdParams != null)
                {
                    this.cmdParams.CopyTo(tmp, 0);
                }
                pArray.Select(t => new SqlParameter(t.Item1, t.Item2)).ToArray().CopyTo(tmp, curLen);
                this.cmdParams = tmp;
            };
        }
    }
}
