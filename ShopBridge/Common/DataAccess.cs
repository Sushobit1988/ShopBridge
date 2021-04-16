using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using System.Data.SqlClient;

namespace ShopBridge.Common
{
    public class DataAccess
    {
        public static DataSet Procedure(Hashtable ht, string Procname)
        {
            DataSet ds = new DataSet();
            List<SqlParameter> parameters = new List<SqlParameter>();
            ICollection key = ht.Keys;
            if (key.Count > 0)
            {
                foreach (var k in key)
                {
                    string hello = k + ":" + ht[k];
                    parameters.Add(new SqlParameter(Convert.ToString(k), Convert.ToString(ht[k])));

                }

                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.ConnectionStrings["constrwebapi"].ConnectionString, CommandType.StoredProcedure, Procname, parameters.ToArray());
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.ConnectionStrings["constrwebapi"].ConnectionString, CommandType.StoredProcedure, Procname);
            }
            return ds;
        }



        public static DataSet Select_Parameter(Hashtable ht, string Query)
        {
            DataSet ds = new DataSet();
            List<SqlParameter> parameters = new List<SqlParameter>();
            ICollection key = ht.Keys;
            if (key.Count > 0)
            {
                foreach (var k in key)
                {
                    string hello = k + ":" + ht[k];
                    parameters.Add(new SqlParameter(Convert.ToString(k), Convert.ToString(ht[k])));

                }
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.ConnectionStrings["constrwebapi"].ConnectionString, CommandType.Text, Query, parameters.ToArray());
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.ConnectionStrings["constrwebapi"].ConnectionString, CommandType.Text, Query);
            }


            return ds;
        }

        public static DataSet Select(string Query)
        {

            DataSet ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.ConnectionStrings["constrwebapi"].ConnectionString, CommandType.Text, Query);
            return ds;
        }

        public static string DtaSet_single(DataSet Query)
        {
            string str = "NA";
            if (Query.Tables[0].Rows.Count > 0)
            {
                str = Convert.ToString(Query.Tables[0].Rows[0][0]);

            }
            return str;
        }
    }
}