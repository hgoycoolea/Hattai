using com.hattai.business.entities;
using com.hattai.business.mappers;
using com.hattai.facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.hattai.business.logic
{
    public static class PaymentsLogics
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Payments Get(int id)
        {
            using (MsSqlFacade<Payments, PaymentsMapper> facade = new MsSqlFacade<Payments, PaymentsMapper>())
            {
                //// we use the Collection to build the broker entity on an abstract phase to manage it as a all
                return facade.Read().Single(p => p.ID == id);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Broker"></param>
        /// <returns></returns>
        public static int Create(Payments Broker)
        {
            using (MsSqlFacade<Payments, PaymentsMapper> facade = new MsSqlFacade<Payments, PaymentsMapper>())
            {
                //// we use the Collection to build the broker entity on an abstract phase to manage it as a all
                return facade.Create(Broker);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<Payments> Read()
        {
            using (MsSqlFacade<Payments, PaymentsMapper> facade = new MsSqlFacade<Payments, PaymentsMapper>())
            {
                //// we use the Collection to build the broker entity on an abstract phase to manage it as a all
                return facade.Read();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Broker"></param>
        /// <returns></returns>
        public static int Update(Payments Broker)
        {
            using (MsSqlFacade<Payments, PaymentsMapper> facade = new MsSqlFacade<Payments, PaymentsMapper>())
            {
                //// we use the Collection to build the broker entity on an abstract phase to manage it as a all
                return facade.Update(Broker);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int Delete(int id)
        {
            using (MsSqlFacade<Payments, PaymentsMapper> facade = new MsSqlFacade<Payments, PaymentsMapper>())
            {
                //// we use the Collection to build the broker entity on an abstract phase to manage it as a all
                return facade.Delete(id);
            }
        }
    }
}
