using com.hattai.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.hattai.data
{
    public interface ICrudDataAccess<K> where K : Entity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        K Get(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CreateEntity"></param>
        /// <returns></returns>
        int Create(K CreateEntity);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<K> Read();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="takeFirstRows"></param>
        /// <returns></returns>
        List<K> Read(int take);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="startID"></param>
        /// <param name="endID"></param>
        /// <returns></returns>
        List<K> Read(int startID, int endID);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateRange"></param>
        /// <returns></returns>
        List<K> Read(string date);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        List<K> Read(string startDate, string endDate);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        List<K> Read(DataAccessFilter filter);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UpdateEntity"></param>
        /// <returns></returns>
        int Update(K UpdateEntity);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int Delete(int id);
    }
}
