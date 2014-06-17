using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.hattai.core
{
    public enum CrudOperation : int
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("Creates Entity")]
        CREATE = 1,
        /// <summary>
        /// 
        /// </summary>
        [Description("Read The Entity")]
        READ = 2,
        /// <summary>
        /// 
        /// </summary>
        [Description("Update an Entity")]
        UPDATE = 3,
        /// <summary>
        /// 
        /// </summary>
        [Description("Deletes an Entity")]
        DELETE = 4,
        /// <summary>
        /// 
        /// </summary>
        [Description("Gets an Entity")]
        GET = 5,
        /// <summary>
        /// 
        /// </summary>
        [Description("Read Take First Row")]
        READ_TAKE = 6,
        /// <summary>
        /// 
        /// </summary>
        [Description("Read Start ID end ID")]
        READ_START_ID_END_ID = 7,
        /// <summary>
        /// 
        /// </summary>
        [Description("Read According to Date")]
        READ_DATE = 8,
        /// <summary>
        /// 
        /// </summary>
        [Description("Read Start Date End Date")]
        READ_START_DATE_END_DATE = 9,
        /// <summary>
        /// 
        /// </summary>
        [Description("Read Ascendant Elements")]
        READ_ASCENDANT = 10,
        /// <summary>
        /// 
        /// </summary>
        [Description("Read Descendant Elements")]
        READ_DESCENDAT = 11
    }
}
