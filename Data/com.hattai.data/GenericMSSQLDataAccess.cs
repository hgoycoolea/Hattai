using com.hattai.core;
using com.hattai.mappers;
using com.hattai.procedures;
using com.hattai.wrappers;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.hattai.data
{
    public class GenericMSSQLDataAccess<h, k> : ICrudDataAccess<h>
        where h : Entity
        where k : IEntityMapper<h>
    {
        /// <summary>
        /// 
        /// </summary>
        private Database _db = null;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        [InjectionConstructor]
        public GenericMSSQLDataAccess([Dependency]Database db)
        {
            this._db = db;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public h Get(int id)
        {
            try
            {
                using (DbCommand dbCommand = _db.GetSqlStringCommand(SelectProcedure<h>.SelectFromID(id)))
                {
                    /// Identity return
                    return GenericWrapper<k, h>.WrapEntity(_db.ExecuteReader(dbCommand));
                }
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CreateEntity"></param>
        /// <returns></returns>
        public int Create(h CreateEntity)
        {
            try
            {
                using (DbCommand dbCommand = _db.GetSqlStringCommand(CreateProcedure<h>.DefaultSQL(CreateEntity)))
                {
                    /// Identity return
                    return int.Parse(SingleValueGenericWrapper.GetValue(_db.ExecuteReader(dbCommand), "ID"));
                }
            }
            catch
            {
                return -1;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<h> Read()
        {
            try
            {
                using (DbCommand dbCommand = _db.GetSqlStringCommand(SelectProcedure<h>.DefaultSQL()))
                {
                    /// Identity return
                    return GenericWrapper<k, h>.WrapEntityList(_db.ExecuteReader(dbCommand));
                }
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="take"></param>
        /// <returns></returns>
        public List<h> Read(int take)
        {
            try
            {
                using (DbCommand dbCommand = _db.GetSqlStringCommand(SelectProcedure<h>.TakeSQL(take)))
                {
                    /// Identity return
                    return GenericWrapper<k, h>.WrapEntityList(_db.ExecuteReader(dbCommand));
                }
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="startID"></param>
        /// <param name="endID"></param>
        /// <returns></returns>
        public List<h> Read(int startID, int endID)
        {
            try
            {
                using (DbCommand dbCommand = _db.GetSqlStringCommand(SelectProcedure<h>.BetweenSQL(startID, endID)))
                {
                    /// Identity return
                    return GenericWrapper<k, h>.WrapEntityList(_db.ExecuteReader(dbCommand));
                }
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<h> Read(string date)
        {
            try
            {
                using (DbCommand dbCommand = _db.GetSqlStringCommand(SelectProcedure<h>.DateSQL(date)))
                {
                    /// Identity return
                    return GenericWrapper<k, h>.WrapEntityList(_db.ExecuteReader(dbCommand));
                }
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public List<h> Read(string startDate, string endDate)
        {
            try
            {
                using (DbCommand dbCommand = _db.GetSqlStringCommand(SelectProcedure<h>.BetweenDateSQL(startDate, endDate)))
                {
                    /// Identity return
                    return GenericWrapper<k, h>.WrapEntityList(_db.ExecuteReader(dbCommand));
                }
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public List<h> Read(DataAccessFilter filter)
        {
            try
            {
                if (filter == DataAccessFilter.ASC)
                {
                    using (DbCommand dbCommand = _db.GetSqlStringCommand(SelectProcedure<h>.AscendantIDSQL()))
                    {
                        /// Identity return
                        return GenericWrapper<k, h>.WrapEntityList(_db.ExecuteReader(dbCommand));
                    }
                }
                else
                {
                    using (DbCommand dbCommand = _db.GetSqlStringCommand(SelectProcedure<h>.DescendantIDSQL()))
                    {
                        /// Identity return
                        return GenericWrapper<k, h>.WrapEntityList(_db.ExecuteReader(dbCommand));
                    }
                }
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UpdateEntity"></param>
        /// <returns></returns>
        public int Update(h UpdateEntity)
        {
            try
            {
                using (DbCommand dbCommand = _db.GetSqlStringCommand(UpdateProcedure<h>.DefaultSQL(UpdateEntity)))
                {
                    /// Identity return
                    return int.Parse(SingleValueGenericWrapper.GetValue(_db.ExecuteReader(dbCommand), "ID"));
                }
            }
            catch
            {
                return -1;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(int id)
        {
            try
            {
                using (DbCommand dbCommand = _db.GetSqlStringCommand(DeleteProcedure<h>.DefaultSQL(id)))
                {
                    /// Identity return
                    return int.Parse(SingleValueGenericWrapper.GetValue(_db.ExecuteReader(dbCommand), "ID"));
                }
            }
            catch
            {
                return -1;
            }
        }
    }
}
