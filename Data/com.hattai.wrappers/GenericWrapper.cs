using com.hattai.core;
using com.hattai.mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.hattai.wrappers
{
    public static class GenericWrapper<k, h>
        where k : IEntityMapper<h>
        where h : Entity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static h WrapEntity(System.Data.IDataReader reader)
        {
            using (reader)
            {
                IEntityMapper<h> instance = MapperFactory<k, h>.GetInstance();
                /// we process at least one row
                while (reader.Read()) { return instance.Map(reader); }
                /// just in case there's no read at all
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static List<h> WrapEntityList(System.Data.IDataReader reader)
        {
            using (reader)
            {
                IEntityMapper<h> instance = MapperFactory<k, h>.GetInstance();
                /// Collection for the Abstraction
                List<h> Collection = new List<h>();
                /// loop for the reader
                while (reader.Read()) { Collection.Add(instance.Map(reader)); }
                /// return of the code
                return Collection;
            }
        }
    }
}
