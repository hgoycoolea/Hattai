using com.hattai.core;
using com.hattai.data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.hattai.injectors
{
    public class MsSqlDataAccessInjector<k, h>
        where k : ICrudDataAccess<h>
        where h : Entity
    {
        /// <summary>
        /// Private instance of the Singleton
        /// </summary>
        private static ICrudDataAccess<h> _instance;
        /// <summary>
        /// Objecto to Block
        /// </summary>
        private static object synlock = new object();
        /// <summary>
        /// Gets and Instance of the Database based on an Entity
        /// </summary>
        /// <param name="DataContainer"></param>
        /// <returns></returns>
        public static ICrudDataAccess<h> GetDatabaseInstance(string Name, string Container, string Section)
        {
            /// Multithreading support using 
            /// Double checked locking pattern, this means
            /// that avoid locking each time the method is
            /// invoked
            if (_instance == null)
            {
                lock (synlock)
                {
                    /// Unity Container on the Web.config refference
                    IUnityContainer container = new UnityContainer();
                    /// Search for the section of the unity container
                    UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager.GetSection(Section);
                    /// get the section of the datacontainer
                    section.Configure(container, Container);
                    /// le decimos que use la base de mercado
                    container.RegisterType<k>(Name, new InjectionMember[] { new InjectionConstructor(new ResolvedParameter(typeof(Database), Name)) });
                    //// Resolvemos el de cliente
                    _instance = container.Resolve<k>(Name);
                }
            }
            /// now we return the instanace of the object 
            return _instance;
        }
    }
}
