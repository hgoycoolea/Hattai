using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.hattai.core
{
    public enum DataAccessFilter : int
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("Ascendant Database Filter")]
        ASC = 0,
        /// <summary>
        /// 
        /// </summary>
        [Description("Descendant Database Filter")]
        DESC = 1,
    }
}
