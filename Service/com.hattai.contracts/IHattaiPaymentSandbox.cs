using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace com.hattai.contracts
{
    [ServiceContract(Namespace = "http://2get.mobi/", Name = "IHattaiPaymentSandbox", ProtectionLevel = ProtectionLevel.None)]
    public interface IHattaiPaymentSandbox
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="codeToScan"></param>
        /// <returns></returns>
        [OperationContract()]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "CommitToAdyenSandbox/")]
        List<string> CommitToAdyenSandbox(string Currency, string Amount, string Cvc, string ExpMonth, string ExpYear, string CardHolderName, string CardNumber, string ShopperEmail, string Reference, string ip, string SignatureImage, string UID, string Longitude, string Latitude, int Client);
    }
}
