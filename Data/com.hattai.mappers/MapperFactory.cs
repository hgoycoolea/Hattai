using com.hattai.core;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.hattai.mappers
{
    public static class MapperFactory<k, h>
        where k : IEntityMapper<h>
        where h : Entity
    {
        /// <summary>
        /// Private instance of the Singleton
        /// </summary>
        private static IEntityMapper<h> _instance;
        /// <summary>
        /// Object to Block
        /// </summary>
        private static object synlock = new object();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IEntityMapper<h> GetInstance()
        {
            /// Multithreading support using 
            /// Double checked locking pattern, this means
            /// that avoid locking each time the method is
            /// invoked
            if (_instance == null)
            {
                lock (synlock)
                {
                    /// Container
                    var container = new UnityContainer();
                    ///
                    container.RegisterType<IEntityMapper<h>, k>();
                    /// 
                    var instance = container.Resolve<IEntityMapper<h>>();
                    /// 
                    _instance = instance;
                }
            }
            /// now we return the instanace of the object 
            return _instance;
        }

    }
}
