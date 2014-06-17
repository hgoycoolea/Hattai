using com.hattai.core;
using com.hattai.mappers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace com.hattai.procedures
{
    public class UpdateProcedure<h> where h : Entity
    {
        /// <summary>
        /// Method to build the SQL
        /// </summary>
        /// <returns></returns>
        public static string DefaultSQL(h Broker)
        {
            try
            {
                /// we prepare the id
                string id = string.Empty;
                /// we will build the all SQL string for the Procedure
                string SQL = "UPDATE " + typeof(h).Name + " SET ";
                /// this gets the properties in the class
                PropertyInfo[] properties = typeof(h).GetProperties();
                /// we now loop the properties until the last statement
                PropertyInfo lastItem = properties[properties.Length - 1];
                /// this will generate the loop
                foreach (PropertyInfo parent in properties)
                {
                    /// name for the property
                    string Name = parent.Name;
                    /// name
                    if (Name == "ID")
                    {
                        /// Parameter of the Database index
                        id = parent.GetValue(Broker, null).ToString();
                    }
                    else
                    {
                        /// Type of the property
                        Type type = parent.PropertyType;
                        /// Database property type
                        DbType dbType = MapperType.ToDbType(type);
                        /// case for the string
                        if (dbType == DbType.String)
                        {
                            SQL += parent.Name + "='" + parent.GetValue(Broker, null) + "',";
                        }
                        /// in case for the int
                        if (dbType == DbType.Int32)
                        {
                            SQL += parent.Name + "=" + parent.GetValue(Broker, null) + ",";
                        }
                    }
                }
                SQL = SQL.Remove(SQL.Length - 1);
                /// we now close the paramenters for the sql sentence for the Select
                SQL += " WHERE ID=" + id;
                /// we now return the SQL for the user
                return SQL;
            }
            catch
            {
                /// there's an error
                return null;
            }
        }
    }
}
