using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace com.hattai.core
{
    [DataContract]
    public class Entity : IComparable<Entity>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Entity other)
        {
            return 0;
        }
    }
}
