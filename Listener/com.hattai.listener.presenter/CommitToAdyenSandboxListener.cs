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
                /// Dictionary Collection
                Dictionary<string, string> Collection = cl.maia.bus.Utils.ContextForm.ProcessNativeEncryptedForm(context.Request.Form);
                /// we send the decrypted code to the user
                string Html = PaymentHelper.CommitTransactionToAdyenSandBox(PaymentMapper.Map(Collection));
                /// we response to the user
                context.Response.Write(Html);
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
