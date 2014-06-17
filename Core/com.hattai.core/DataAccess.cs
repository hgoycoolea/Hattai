﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.hattai.core
{
    public class DataAccess : IDisposable
    {
        public void Dispose()
        {
            /// we collect the memmory leek
            GC.Collect();
            /// we supress the actual class
            GC.SuppressFinalize(this);
        }
    }
}
