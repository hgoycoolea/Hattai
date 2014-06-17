using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.hattai.encryption.strategy
{
    public class RSAContext
    {
        /// <summary>
        /// 
        /// </summary>
        private RSAStrategy _strategy;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sortstrategy"></param>
        public void SetStrategy(RSAStrategy sortstrategy)
        {
            this._strategy = sortstrategy;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="StrToEncrypt"></param>
        /// <param name="EncodingMode"></param>
        /// <param name="RSAPublicKey"></param>
        /// <returns></returns>
        public string Encrypt(string StrToEncrypt, string EncodingMode, string RSAPublicKey)
        {
            return _strategy.Encrypt(StrToEncrypt, EncodingMode, RSAPublicKey);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="StrToDecrypt"></param>
        /// <param name="EncodingMode"></param>
        /// <param name="RSAPrivateKey"></param>
        /// <returns></returns>
        public string Decrypt(string StrToDecrypt, string EncodingMode, string RSAPrivateKey)
        {
            return _strategy.Decrypt(StrToDecrypt, EncodingMode, RSAPrivateKey);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<string> GenerateNewRSAKeyPair()
        {
            return _strategy.GenerateNewRSAKeyPair();
        }
    }
}
