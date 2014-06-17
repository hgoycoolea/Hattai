using com.hattai.business.entities;
using com.hattai.business.logic;
using com.hattai.contracts;
using com.hattai.payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.hattai.endpoints
{
    public class HattaiPaymentSandbox : IHattaiPaymentSandbox
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Currency"></param>
        /// <param name="Amount"></param>
        /// <param name="Cvc"></param>
        /// <param name="ExpMonth"></param>
        /// <param name="ExpYear"></param>
        /// <param name="CardHolderName"></param>
        /// <param name="CardNumber"></param>
        /// <param name="ShopperEmail"></param>
        /// <param name="Reference"></param>
        /// <param name="ip"></param>
        /// <param name="SignatureImage"></param>
        /// <param name="UID"></param>
        /// <param name="Longitude"></param>
        /// <param name="Latitude"></param>
        /// <param name="Client"></param>
        /// <param name="Result"></param>
        /// <param name="AuthCode"></param>
        /// <param name="PspReference"></param>
        /// <param name="TimeStamp"></param>
        /// <returns></returns>
        public List<string> CommitToAdyenSandbox(string Currency, string Amount, string Cvc, string ExpMonth, string ExpYear, string CardHolderName, string CardNumber, string ShopperEmail, string Reference, string ip, string SignatureImage, string UID, string Longitude, string Latitude, int Client)
        {
            /// commit to sandbox
            List<string> Collection =  AdyenGateway.CommitToSandbox(Currency, Amount, Cvc, ExpMonth, ExpYear, CardHolderName, CardNumber, ShopperEmail, Reference, ip, SignatureImage, UID);
            /// return the payment to the logics on the database
            PaymentsLogics.Create(new Payments { Amount = Amount, AuthCode = Collection[3], CardHolderCvc = Cvc, CardHolderName = CardHolderName, CardHolderNumber = CardHolderName, Client = Client, Currency = Currency, ExpMonth = ExpMonth, ExpYear = ExpYear, Ip = ip, Latitude = Latitude, Longitude = Longitude, PspReference = Collection[1], Reference = Reference, Result = Collection[0] + Collection[2], ShopperEmail = ShopperEmail, SignatureImage = SignatureImage, TimeStamp = DateTime.Now.ToLongTimeString(), Uuid = UID });
            /// collection for the results
            return Collection;
        }
    }
}
