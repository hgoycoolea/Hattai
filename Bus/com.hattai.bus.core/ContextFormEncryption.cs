using com.hattai.encryption.Global;
using com.hattai.encryption.strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.hattai.bus.core
{
    public static class ContextFormEncryption
    {
        public static Dictionary<string, string> ProcessEncryptedForm(System.Collections.Specialized.NameValueCollection FormContextObject, string PrivateKey)
        {
            try
            {
                /// rsa strategy
                RSAContext context = new RSAContext();
                /// sort strategy we are using that is the bus
                context.SetStrategy(new RSAInterface());
                /// we create the collection based on a dictionary
                Dictionary<string, string> Collection = new Dictionary<string, string>();
                /// we loop now the collection
                for (int i = 0; i < FormContextObject.Count; i++)
                {
                    /// get the key for the object that is the key only
                    string key = FormContextObject.GetKey(i);
                    /// get the for object and decrypt it
                    string value = context.Decrypt(FormContextObject.Get(i), "base64", PrivateKey);
                    /// we add the value for it
                    Collection.Add(key, value);
                }
                /// we return the collection
                return Collection;
            }
            catch
            {
                /// we return the null entity 
                return null;
            }
        }
    }
}
