using com.hattai.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace com.hattai.procedures
{
    public class SelectProcedure<h> where h : Entity
    {
        /// <summary>
        /// Method to return the complete PLSQL for the giving Class
        /// </summary>
        /// <returns></returns>
        public static string DefaultSQL()
        {
            /// we will build the all SQL string for the Procedure
            string SQL = "SELECT ";
            /// this gets the properties in the class
            PropertyInfo[] properties = typeof(h).GetProperties();
            /// we now loop the properties until the last statement
            PropertyInfo lastItem = properties[properties.Length - 1];
            /// this will generate the loop
            foreach (PropertyInfo parent in properties)
            {
                SQL += parent != lastItem ? "A.[" + parent.Name + "]," : "A.[" + parent.Name + "]";
            }
            /// we now close the paramenters for the sql sentence for the Select
            SQL += " from " + typeof(h).Name + " as A";
            /// we now return the SQL for the user
            return SQL;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string SelectFromID(int id)
        {

            /// this will get the default sql that we need;
            string SQL = DefaultSQL() + " where A.[ID]=" + id.ToString();
            /// we now return the SQL for the user
            return SQL;
        }
        /// <summary>
        /// Method to return the complete PLSQL for the giving Class
        /// Ordered ascendant sort
        /// </summary>
        /// <returns></returns>
        public static string AscendantSQL()
        {
            /// this will get the default sql that we need;
            string SQL = DefaultSQL() + " order asc";
            /// we now return the SQL for the user
            return SQL;
        }
        /// <summary>
        /// Method to return the complete PLSQL for the giving Class
        /// Ordered descendant sort
        /// </summary>
        /// <returns></returns>
        public static string DescendantSQL()
        {
            /// this will get the default sql that we need;
            string SQL = DefaultSQL() + " order desc";
            /// we now return the SQL for the user
            return SQL;
        }
        /// <summary>
        /// Method to return the complete PLSQL for the giving Class
        /// Ordered ascendant sort
        /// </summary>
        /// <returns></returns>
        public static string AscendantIDSQL()
        {
            /// this will get the default sql that we need;
            string SQL = DefaultSQL() + " order by A.[ID] asc";
            /// we now return the SQL for the user
            return SQL;
        }
        /// <summary>
        /// Method to return the complete PLSQL for the giving Class
        /// Ordered ascendant sort
        /// </summary>
        /// <returns></returns>
        public static string DescendantIDSQL()
        {
            /// this will get the default sql that we need;
            string SQL = DefaultSQL() + " order by A.[ID] desc";
            /// we now return the SQL for the user
            return SQL;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rows"></param>
        /// <returns></returns>
        public static string TakeSQL(int rows)
        {
            /// we will build the all SQL string for the Procedure
            string SQL = "SELECT TOP " + rows.ToString();
            /// this gets the properties in the class
            PropertyInfo[] properties = typeof(h).GetProperties();
            /// we now loop the properties until the last statement
            PropertyInfo lastItem = properties[properties.Length - 1];
            /// this will generate the loop
            foreach (PropertyInfo parent in properties)
            {
                SQL += parent != lastItem ? " A.[" + parent.Name + "]," : " A.[" + parent.Name + "]";
            }
            /// we now close the paramenters for the sql sentence for the Select
            SQL += " from " + typeof(h).Name + "as A";
            /// we now return the SQL for the user
            return SQL;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string BetweenSQL(int a, int b)
        {
            /// this will get the default sql that we need;
            string SQL = DefaultSQL() + " WHERE ID BETWEEN " + a.ToString() + " and " + b.ToString();
            /// we now return the SQL for the user
            return SQL;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string DateSQL(string date)
        {
            /// this will get the default sql that we need;
            string SQL = DefaultSQL() + " WHERE Date='" + date + "'";
            /// we now return the SQL for the user
            return SQL;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="date_a"></param>
        /// <param name="date_b"></param>
        /// <returns></returns>
        public static string BetweenDateSQL(string date_a, string date_b)
        {
            /// this will get the default sql that we need;
            string SQL = DefaultSQL() + " WHERE Date BETWEEN '" + date_a + "' and '" + date_b + "'";
            /// we now return the SQL for the user
            return SQL;
        }
    }
}
