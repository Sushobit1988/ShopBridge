using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Globalization;

namespace ShopBridge.Common
{
    public class BussinessLogic
    {

        public static DataTable InsertItem(string Name, string Description,string price,string itemid)
        {
            DataTable dt = null;
            Hashtable ht = new Hashtable();
            ht.Add("@Name", Name);
            ht.Add("@Description",Description);
            ht.Add("@price", Convert.ToDouble(price));
            ht.Add("@Status", "Insert");
            ht.Add("@itemid", itemid.ToUpper());


            dt = DataAccess.Procedure(ht, "Proc_CrudOperation").Tables[0];
            return dt;
        }

        public static DataTable UpdateItem(string Name, string Description, string price, string itemid)
        {
            DataTable dt = null;
            Hashtable ht = new Hashtable();
            ht.Add("@Name", Name);
            ht.Add("@Description", Description);
            ht.Add("@price", Convert.ToDouble(price));
            ht.Add("@Status", "Update");
            ht.Add("@itemid", itemid.ToUpper());


            dt = DataAccess.Procedure(ht, "Proc_CrudOperation").Tables[0];
            return dt;
        }

        public static DataTable DeleteItem( string itemid)
        {
            DataTable dt = null;
            Hashtable ht = new Hashtable();
            ht.Add("@Name", "");
            ht.Add("@Description","");
            ht.Add("@price", Convert.ToDouble(0));
            ht.Add("@Status", "Delete");
            ht.Add("@itemid", itemid.ToUpper());


            dt = DataAccess.Procedure(ht, "Proc_CrudOperation").Tables[0];
            return dt;
        }

        public static DataTable ListItem()
        {
            DataTable dt = null;
            Hashtable ht = new Hashtable();
            ht.Add("@Name", "");
            ht.Add("@Description", "");
            ht.Add("@price", Convert.ToDouble(0));
            ht.Add("@Status", "Search");
            ht.Add("@itemid", "");


            dt = DataAccess.Procedure(ht, "Proc_CrudOperation").Tables[0];
            return dt;
        }
    }
}