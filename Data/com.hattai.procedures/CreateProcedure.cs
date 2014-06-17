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
    public class CreateProcedure<h> where h : Entity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Broker"></param>
        /// <returns></returns>
        public static string DefaultSQL(h Broker)
        {
            try
            {
                /// we prepare the id
                string id = string.Empty;
                /// we will build the all SQL string for the Procedure
                string SQL = "INSERT INTO " + typeof(h).Name + "(";
                /// this gets the properties in the class
                PropertyInfo[] properties = typeof(h).GetProperties();
                /// we now loop the properties until the last statement
                PropertyInfo lastItem = properties[properties.Length - 1];
                /// this will generate the loop
                foreach (PropertyInfo parent in properties)
                {
                    /// name for the property
                    string Name = parent.Name;
                    /// must be diff from ID
                    if (Name != "ID")
                    {
                        SQL += parent != lastItem ? parent.Name + "," : parent.Name + ")VALUES(";
                    }
                }
                /// now we re-loop for the completion
                foreach (PropertyInfo parent in properties)
                {
                    /// name for the property
                    string Name = parent.Name;
                    /// must be diff from ID
                    if (Name != "ID")
                    {
                        /// Type of the property
                        Type type = parent.PropertyType;
                        /// Database property type
                        DbType dbType = MapperType.ToDbType(type);
                        /// case for the string
                        if (dbType == DbType.String)
                        {
                            SQL += parent != lastItem ? "'" + parent.GetValue(Broker, null) + "'," : "'" + parent.GetValue(Broker, null) + "')";
                        }
                        /// in case for the int
                        if (dbType == DbType.Int32)
                        {
                            SQL += parent != lastItem ? parent.GetValue(Broker, null) + "," : parent.GetValue(Broker, null) + ")";
                        }
                    }
                }
                /// we also prepare the ID form the name
                SQL += " SELECT @@IDENTITY AS ID FROM " + typeof(h).Name;
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
