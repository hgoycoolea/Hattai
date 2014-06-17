using com.hattai.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.hattai.wrappers
{
    public interface IEntityWrapper<K> where K : Entity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        K WrapEntity(System.Data.IDataReader reader);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        List<K> WrapEntityList(System.Data.IDataReader reader);
    }
}
