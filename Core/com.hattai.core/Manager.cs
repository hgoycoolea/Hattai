using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.hattai.core
{
    public class Manager : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            /// we collect the memmory leek
            GC.Collect();
            /// we supress the actual class
            GC.SuppressFinalize(this);
        }
    }
}
