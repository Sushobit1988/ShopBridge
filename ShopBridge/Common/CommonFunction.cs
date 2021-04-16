using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopBridge.Common
{
    public class CommonFunction
    {

        private static string[] blackListnew = new[] { "@", "/*", "*/", "char ", "nchar", "varchar", "nvarchar", "alter", "begin", "cast", "create", "cursor", "declare", "delete", " drop ", "exec", "execute", "fetch", "insert", "kill", "select", "sys", "sysobjects", "syscolumns", "table", "update", "<", ">", "script", "www", "www2", "union", "src", "select", "union", " drop ", " DROP ", "&#8212;", "insert", "delete", "xp_", "* ", " or ", "having", " group ", "update", "<script>", "</script>", "\"", "<", ">", "alert", "language", "javascript", "vbscript", "http", "* ", "'", "?", "<", ">", "{", "[", "}", "]", "~", "=", "+", "|", "`", "~", "!", "#", "$", "%", "%", "^", "* ", "+", "=", "[", "]", "'", "<", ">", "|" };

        public static bool CheckInjectBooleanNew(string BefString)
        {
            bool flag = false;
            string CheckString = BefString.Replace("'", "''");
            for (int i = 0; i <= blackListnew.Length - 1; i++)
            {
                if ((BefString.IndexOf(blackListnew[i], StringComparison.OrdinalIgnoreCase) >= 0))
                {
                    CheckString = CheckString.Replace(blackListnew[i], "");
                    flag = true;
                }
            }
            return flag;
        }


        public static string NewItemId()
        {
            string strRandom = "";
            string[] strArray = new string[36];
            strArray = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            Random autoRand = new Random();
            int x;
            for (x = 0; x <= 5; x++)
            {
                int i = Convert.ToInt32(autoRand.Next(0, 36));
                strRandom += strArray[i].ToString();
            }

            return strRandom.ToString();
        }
    }
}