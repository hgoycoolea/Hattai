using com.hattai.bus.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace com.hattai.listener.presenter
{
    public class CommitToAdyenSandboxListener : IHttpHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                string privateKey = "<BitStrength>2048</BitStrength><RSAKeyValue><Modulus>lLTUuYOXpEub1k3tF+1ZVbyT5R0mxF6zoyGOgh1N4ULxUT5l5ZZ7DMzeaGGEt7Zxus8oD9QVW6Xwf0AOj/R/14pi9UWCjJySb6UslinF+MGqOdS/BNK5vh2xgCYaiEzXHiDj6hsjllVdmYK79qtFRn08ABY4y7qTrCfJmB6OVw+rkj1aBb+VPh/vDEkd/ycNxcCKOCGdfHZ0xJ3NzpjsAjafh/mxww3jqvdzNX/+XisfJOTOxVmAxYFTnhaU3dnwyxiUjhHukDh8mRI/Jp+8WfnpUzsQoK8sZiRJot4SA8XJwbuIZvHeI4DDriUXMx44KcrwPGKchKB7U6r+/k/71w==</Modulus><Exponent>AQAB</Exponent><P>w0MQ0fkeEWAOMJgrSXH5Az+6/+aRSHwCCgNlS6q9jGpB48YlawsPCF+4dbYHtDWyaEmZ4tyNd5sHE174in50T6Ulir4186WeBZUUXWKTJ9nk27T0kOPpGwm+WxGU4FibDXycD8M6I1ZGDo5bLiW5BKSv5KkZ6IzWxsP0axB89OU=</P><Q>wvZ9P5CirRZcxtdS/MCNCEWnjMNbxlbK4YDLZ+Mw/9aLaAYbc2447wPgbq40sREFAU9QAJqWwXTqz3PS8SW7QUuX6BanN8ruTE4MN5O4UNauOzVXKgT4d0OIBQLKO3qkCPUXMUjX+f7jfEUX5fGqIW8BlcgYpjVxJLnecIb6Pgs=</Q><DP>aIhl39Ma6rhewFsmiVovsjKTHN5FluV0fgHVX83XTe2wuozgiU7RTG1aJgI+W5aHnVcRwCbMwWRIRHGKYzJReDX0RDOSVI6sa1alIV1dZG89GvXkHBE3QRdVRhHCftxQncbBEZs1a6eLN820OJ9PTpIP7D0vNpT3gk9zcUHRc5U=</DP><DQ>eYpgmnf4ch82x18FBTykrzt9MGu5kvQYlmxMYf9oVJXTYo4sHtHf/GFWUKmZf6k0jZR8M2QsB35zw9BY+KylCBewI6e7pzSDSl59j0gv53VuOMsQA8oFe5RF/5m1qU7TZCImyzq2KcuU1avdMiRuA1nIiy+q7jLyzgpxeYUsC/E=</DQ><InverseQ>l9Diz9ShXMFGrXWwxYEaaa3yEwC3usLbZkR43nyyKGv+UGS3S96ABOmV5y8tZnXI/8uzhfE4OpiJNdwXtQzdbjeRrT7FZ2Xinit9ITfuEspG+5pu9ghR5DurCVoB3TtVTDKZGvtlwPKch65Mu9V5Zi943WoRotbVwER1J6RiKF4=</InverseQ><D>g7KWxul1DitsC2KePNeWi6jkLkAgCj94xlu8sx0y0PIReAtUAP3BYne57SWYfX9Vv8UhTMteUvlmQbxAaVt3MTO9Kk1yLgeoZLoa/65lR0Z09Jymw6XAnE/92GlmjBnJVkR4tOduIADgUUkIIJBUXPYigk0r5boKeKgQEOnW0+CSULWD81ShcOKjfLfkYLSjos/a8+s2AapFBMrbOjPpdAhNAO7SKP7hn99tioVcevmd6ifB51SmenRbx59t6rUqCN82waipuk4m0VYCjKTD+641YHu+JXcwJx+5bdqhPB6/hXyffSq2vcdfcce/mvqVLP9FZDrdpKX8VL4DtFz/qQ==</D></RSAKeyValue>";
                /// Dictionary Collection
                Dictionary<string, string> Collection = ContextFormEncryption.ProcessEncryptedForm(context.Request.Form,privateKey);
                using (HattaiPaymentSandboxEndpoint.HattaiPaymentSandboxClient svc = new HattaiPaymentSandboxEndpoint.HattaiPaymentSandboxClient())
                {
                    dynamic payment = PaymentMiddleDecryptionMapper.Map(Collection);
                    /// we send the decrypted code to the user
                    string Html = svc.CommitToAdyenSandbox(payment.Currency, payment.Amount, payment.Cvc, payment.ExpMonht, payment.ExpYear, payment.CardHolderName, payment.CardNumber, payment.ShopperEmail, payment.Reference,payment.ip,payment.SignatureImage,payment.UID,payment.Longitude, payment.Latitude, payment.Client);
                    /// we response to the user
                    context.Response.Write(Html);
                }
            }
            catch (Exception ex)
            {
                /// Html
                string Html = string.Empty;
                Html += "<img src=\"http://\" height=\"80\" />";
                Html += "<br/><br/><br/><strong>Instructions</strong><br/>";
                Html += "<p>Wellcome to the Encrypted BUS Handler.<br/>The System Expects 2048 bits encrypted RSA FORM variables<br/>You need to submit variables to the BUS in the correct Format.";
                Html += "</p>";
                Html += "<hr size=1 width=\"100%\" />";
                Html += "<strong>Structure</strong><br/><br/>";
                Html += "{ <br/>";
                Html += "{ sorry, private structure }<br/>";
                Html += "}<br/>";
                Html += "<hr size=1 width=\"100%\" />";
                Html += "<strong>Exception Detail:<strong><br/><p style=\"color:red;\">" + ex.ToString() + "</p>";
                /// Context for the Response
                context.Response.Write(Html);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsReusable
        {
            get { throw new NotImplementedException(); }
        }
    }
}
