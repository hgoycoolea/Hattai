using com.hattai.core;
using com.hattai.mappers;
using com.hattai.wrappers;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace com.hattai.data
{
    public class GenericDataAccess<h, k> : ICrudDataAccess<h>
        where h : Entity
        where k : IEntityMapper<h>
    {
        /// <summary>
        /// 
        /// </summary>
        string StoredProcedure = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        private Database _db = null;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        [InjectionConstructor]
        public GenericDataAccess([Dependency]Database db, string StoredProcedure)
        {
            this._db = db;
            this.StoredProcedure = StoredProcedure;
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
                using (DbCommand dbCommand = _db.GetStoredProcCommand(StoredProcedure))
                {
                    /// Paramenter addin
                    _db.AddInParameter(dbCommand, "TID", DbType.Int32, CrudOperation.GET);
                    _db.AddInParameter(dbCommand, "ID", DbType.Int32, id);
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
                using (DbCommand dbCommand = _db.GetStoredProcCommand(StoredProcedure))
                {
                    /// Parameter addin
                    _db.AddInParameter(dbCommand, "TID", DbType.Int32, CrudOperation.CREATE);
                    /// this gets the properties in the class
                    PropertyInfo[] properties = typeof(h).GetProperties();
                    /// we now loop the properties
                    foreach (PropertyInfo parent in properties)
                    {
                        /// Name for the property
                        string Name = parent.Name;
                        /// Type of the property
                        Type type = parent.PropertyType;
                        /// Database property type
                        DbType dbType = MapperType.ToDbType(type);
                        /// this maps the entity for diffrent ID
                        if (Name != "ID")
                        {
                            /// Parameter of the Database
                            _db.AddInParameter(dbCommand, Name, dbType, parent.GetValue(CreateEntity, null));
                        }
                    }
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
                using (DbCommand dbCommand = _db.GetStoredProcCommand(StoredProcedure))
                {
                    /// Paramenter addin
                    _db.AddInParameter(dbCommand, "TID", DbType.Int32, CrudOperation.READ);
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
                using (DbCommand dbCommand = _db.GetStoredProcCommand(StoredProcedure))
                {
                    /// Paramenter addin
                    _db.AddInParameter(dbCommand, "TID", DbType.Int32, CrudOperation.READ_TAKE);
                    _db.AddInParameter(dbCommand, "take", DbType.Int32, take);
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
                using (DbCommand dbCommand = _db.GetStoredProcCommand(StoredProcedure))
                {
                    /// Paramenter addin
                    _db.AddInParameter(dbCommand, "TID", DbType.Int32, CrudOperation.READ_START_ID_END_ID);
                    _db.AddInParameter(dbCommand, "startID", DbType.Int32, startID);
                    _db.AddInParameter(dbCommand, "endID", DbType.Int32, endID);
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
                using (DbCommand dbCommand = _db.GetStoredProcCommand(StoredProcedure))
                {
                    /// Paramenter addin
                    _db.AddInParameter(dbCommand, "TID", DbType.Int32, CrudOperation.READ_DATE);
                    _db.AddInParameter(dbCommand, "date", DbType.String, date);
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
                using (DbCommand dbCommand = _db.GetStoredProcCommand(StoredProcedure))
                {
                    /// Paramenter addin
                    _db.AddInParameter(dbCommand, "TID", DbType.Int32, CrudOperation.READ_START_DATE_END_DATE);
                    _db.AddInParameter(dbCommand, "startDate", DbType.String, startDate);
                    _db.AddInParameter(dbCommand, "endDate", DbType.String, endDate);
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
                    using (DbCommand dbCommand = _db.GetStoredProcCommand(StoredProcedure))
                    {
                        /// Paramenter addin
                        _db.AddInParameter(dbCommand, "TID", DbType.Int32, CrudOperation.READ_ASCENDANT);
                        /// Identity return
                        return GenericWrapper<k, h>.WrapEntityList(_db.ExecuteReader(dbCommand));
                    }
                }
                else
                {
                    using (DbCommand dbCommand = _db.GetStoredProcCommand(StoredProcedure))
                    {
                        /// Paramenter addin
                        _db.AddInParameter(dbCommand, "TID", DbType.Int32, CrudOperation.READ_DESCENDAT);
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
                using (DbCommand dbCommand = _db.GetStoredProcCommand(StoredProcedure))
                {
                    /// Parameter addin
                    _db.AddInParameter(dbCommand, "TID", DbType.Int32, CrudOperation.UPDATE);
                    /// this gets the properties in the class
                    PropertyInfo[] properties = typeof(h).GetProperties();
                    /// we now loop the properties
                    foreach (PropertyInfo parent in properties)
                    {
                        /// Name for the property
                        string Name = parent.Name;
                        /// Type of the property
                        Type type = parent.PropertyType;
                        /// Database property type
                        DbType dbType = MapperType.ToDbType(type);
                        /// Parameter of the Database
                        _db.AddInParameter(dbCommand, Name, dbType, parent.GetValue(UpdateEntity, null));
                    }
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
                /// Command Construction over SP
                using (DbCommand dbCommand = _db.GetStoredProcCommand(StoredProcedure))
                {
                    /// Parameter addin
                    _db.AddInParameter(dbCommand, "TID", DbType.Int32, CrudOperation.DELETE);
                    _db.AddInParameter(dbCommand, "ID", DbType.Int32, id);
                    /// Identity return
                    _db.ExecuteNonQuery(dbCommand);
                    /// retorno de confirmacion
                    return 1;
                }
            }
            catch
            {
                return -1;
            }
        }
    }
}
