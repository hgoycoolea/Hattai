using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.hattai.listener.presenter
{
    public static class PaymentMiddleDecryptionMapper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Collection"></param>
        /// <returns></returns>
        public static dynamic Map(Dictionary<string, string> Collection)
        {
            dynamic payment = new ExpandoObject();
            /// foreach string for the value collection
            foreach (KeyValuePair<string, string> kvp in Collection)
            {
                if (kvp.Key == "Cvc")
                {
                    payment.Cvc = kvp.Value;
                }

                if (kvp.Key == "ExpMonth")
                {
                    string month = kvp.Value;
                    int aux_mont = int.Parse(month);
                    payment.ExpMonth = aux_mont.ToString();
                }

                if (kvp.Key == "ExpYear")
                {
                    payment.ExpYear = "20" + kvp.Value;
                }

                if (kvp.Key == "CardHolderName")
                {
                    payment.CardHolderName = kvp.Value;
                }

                if (kvp.Key == "CardNumber")
                {
                    payment.CardNumber = kvp.Value;
                }

                if (kvp.Key == "Currency")
                {
                    payment.Currency = kvp.Value;
                }

                if (kvp.Key == "ip")
                {
                    payment.ip = kvp.Value;
                }

                if (kvp.Key == "Client")
                {
                    payment.Client = int.Parse(kvp.Value);
                }
                if (kvp.Key == "Amount")
                {
                    payment.Amount = kvp.Value + "00";
                }

                if (kvp.Key == "Reference")
                {
                    payment.Reference = kvp.Value;
                }
                if (kvp.Key == "ShopperEmail")
                {
                    payment.ShopperEmail = kvp.Value;
                }
                if (kvp.Key == "SignatureImage")
                {
                    payment.SignatureImage = "http://2get.mobi/assets/images/" + kvp.Value;
                }
                if (kvp.Key == "UID")
                {
                    payment.UID = kvp.Value;
                }
                if (kvp.Key == "Latitude")
                {
                    payment.Latitude = kvp.Value;
                }
                if (kvp.Key == "Longitude")
                {
                    payment.Longitude = kvp.Value;
                }
            }

            return payment;
        }
    }
}
