using com.hattai.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace com.hattai.payments
{
    public static class AdyenGateway
    {
        public static List<string> CommitToSandbox(string Currency, string Amount, string Cvc, string ExpMonth, string ExpYear, string CardHolderName, string CardNumber, string ShopperEmail, string Reference, string ip, string SignatureImage = "", string UID = "")
        {
            try
            {
                using (AdyenGatewaySandbox.PaymentPortTypeClient svc = new AdyenGatewaySandbox.PaymentPortTypeClient())
                {
                    /// we set the new amount of the sells
                    AdyenGatewaySandbox.Amount amount = new AdyenGatewaySandbox.Amount();
                    /// currency 
                    amount.currency = Currency;
                    /// cast
                    amount.value = long.Parse(Amount);
                    /// card information
                    AdyenGatewaySandbox.Card card = new AdyenGatewaySandbox.Card();
                    card.cvc = Cvc;
                    card.expiryMonth = ExpMonth;
                    card.expiryYear = ExpYear;
                    card.holderName = CardHolderName;
                    card.number = CardNumber;
                    ////Payment Request
                    AdyenGatewaySandbox.PaymentRequest paymentReq = new AdyenGatewaySandbox.PaymentRequest();
                    paymentReq.merchantAccount = Properties.Settings.Default.adyenMerchantAccount;
                    paymentReq.shopperEmail = ShopperEmail;
                    paymentReq.shopperIP = ip;
                    paymentReq.reference = Reference;
                    /// this hold the refference to the map id of each client
                    AdyenGatewaySandbox.anyType2anyTypeMap additionalDataCollection = new AdyenGatewaySandbox.anyType2anyTypeMap();
                    /// signature image if the image exist, if not don't create it
                    if (SignatureImage != "" || SignatureImage != null)
                    {
                        additionalDataCollection.Add(new AdyenGatewaySandbox.entry() { key = "signature.mimetype", value = "image/jpeg" });
                        additionalDataCollection.Add(new AdyenGatewaySandbox.entry() { key = "signature.data", value = com.hattai.image.WebHandler.GetStreamImageFromWebRequest(SignatureImage) });
                    }
                    /// if the UID is not present do not assign them
                    if (UID != "" || SignatureImage != null)
                    {
                        additionalDataCollection.Add(new AdyenGatewaySandbox.entry() { key = "magstripe.terminalid", value = UID });
                    }
                    paymentReq.additionalData = additionalDataCollection;
                    /// we now pass the amount of the purchase
                    paymentReq.amount = amount;
                    /// we now pass the card of the buyer
                    paymentReq.card = card;
                    /// service details for the client credentials
                    svc.ClientCredentials.UserName.UserName = Properties.Settings.Default.adyenDirectPaymentUser;
                    svc.ClientCredentials.UserName.Password = Properties.Settings.Default.adyenDirectPaymentPwd;
                    svc.ClientCredentials.Windows.AllowedImpersonationLevel = TokenImpersonationLevel.Identification;
                    /// browser info
                    svc.ClientCredentials.Windows.ClientCredential = new NetworkCredential(Properties.Settings.Default.adyenDirectPaymentUser, Properties.Settings.Default.adyenDirectPaymentPwd);
                    AdyenGatewaySandbox.BrowserInfo bInfo = new AdyenGatewaySandbox.BrowserInfo();
                    bInfo.acceptHeader = "text/html,application/xhtml+xml, application/xml;q=0.9,*/*;q=0.8";
                    bInfo.userAgent = "Mozilla/5.0 (X11; U; Linux i686; en-US; rv:1.9) Gecko/2008052912 Firefox/3.0";
                    //// result composition
                    AdyenGatewaySandbox.PaymentResult result = svc.authorise(paymentReq);
                    /// this is the return on a natutal order
                    return new List<string>() { result.resultCode, result.pspReference, result.refusalReason, result.authCode };
                }
            }
            catch (Exception ex)
            {
                return new List<string>() { "-1", "-1", ex.ToString(), "-1" }; ;
            }
        }
    }
}
