using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.hattai.wrappers
{
    public static class SingleValueGenericWrapper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static string GetValue(IDataReader Reader, string Value)
        {
            using (Reader)
            {
                try
                {
                    /// leemos
                    Reader.Read();
                    /// retorno valor
                    return Reader[Value].ToString();
                }
                catch
                {
                    // en caos de error
                    return "-1";
                }
                finally
                {
                    /// sentencia que se leera si o si
                    Reader.Close();
                }
            }
        }
    }
}
