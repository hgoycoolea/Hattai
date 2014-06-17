using com.hattai.core;
using com.hattai.data;
using com.hattai.injectors;
using com.hattai.mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.hattai.facades
{
    public class MsSqlFacade<h, k> : Facade
        where h : Entity
        where k : IEntityMapper<h>
    {
        /// <summary>
        /// 
        /// </summary>
        ICrudDataAccess<h> iDataAccess;
        /// <summary>
        /// 
        /// </summary>
        public MsSqlFacade()
        {
            this.iDataAccess = MsSqlDataAccessInjector<GenericMSSQLDataAccess<h, k>, h>.GetDatabaseInstance("DataAccess", "dataContainer", "unity");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public h Get(int id)
        {
            return iDataAccess.Get(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CreateEntity"></param>
        /// <returns></returns>
        public int Create(h CreateEntity)
        {
            return iDataAccess.Create(CreateEntity);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<h> Read()
        {
            return iDataAccess.Read();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="take"></param>
        /// <returns></returns>
        public List<h> Read(int take)
        {
            return iDataAccess.Read(take);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="startID"></param>
        /// <param name="endID"></param>
        /// <returns></returns>
        public List<h> Read(int startID, int endID)
        {
            return iDataAccess.Read(startID, endID);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<h> Read(string date)
        {
            return iDataAccess.Read(date);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public List<h> Read(string startDate, string endDate)
        {
            return iDataAccess.Read(startDate, endDate);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public List<h> Read(DataAccessFilter filter)
        {
            return iDataAccess.Read(filter);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UpdateEntity"></param>
        /// <returns></returns>
        public int Update(h UpdateEntity)
        {
            return iDataAccess.Update(UpdateEntity);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(int id)
        {
            return iDataAccess.Delete(id);
        }
    }
}
