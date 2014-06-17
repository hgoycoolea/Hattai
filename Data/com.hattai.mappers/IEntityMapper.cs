using com.hattai.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.hattai.mappers
{
    public interface IEntityMapper<K> where K : Entity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        /// <returns></returns>
        K Map(System.Data.IDataRecord parent);
    }
}
