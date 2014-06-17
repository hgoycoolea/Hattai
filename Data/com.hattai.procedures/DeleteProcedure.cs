using com.hattai.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.hattai.procedures
{
    public class DeleteProcedure<h> where h : Entity
    {
        /// <summary>
        /// Method to return the complete PLSQL for the giving Class
        /// </summary>
        /// <returns></returns>
        public static string DefaultSQL(int id)
        {
            /// we will build the all SQL string for the Procedure
            return "DELETE FROM " + typeof(h).Name + " WHERE ID=" + id.ToString();
        }
        /// <summary>
        /// Method to Wipe the data out
        /// </summary>
        /// <returns></returns>
        public static string CleanTableSQL()
        {
            /// we will build the all SQL string for the Procedure
            return "DELETE FROM " + typeof(h).Name;
        }
    }
}
