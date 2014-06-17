using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.hattai.encryption.strategy
{
    public abstract class RSAStrategy
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="StrToEncrypt"></param>
        /// <param name="EncodingMode"></param>
        /// <param name="RSAPublicKey"></param>
        /// <returns></returns>
        public abstract string Encrypt(string StrToEncrypt, string EncodingMode, string RSAPublicKey);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="StrToDecrypt"></param>
        /// <param name="EncodingMode"></param>
        /// <param name="RSAPrivateKey"></param>
        /// <returns></returns>
        public abstract string Decrypt(string StrToDecrypt, string EncodingMode, string RSAPrivateKey);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract List<string> GenerateNewRSAKeyPair();
    }
}
