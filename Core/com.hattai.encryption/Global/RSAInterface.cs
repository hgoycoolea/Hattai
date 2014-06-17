using com.hattai.encryption.strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.hattai.encryption.Global
{
    public class RSAInterface : RSAStrategy
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="StrToEncrypt"></param>
        /// <param name="EncodingMode"></param>
        /// <returns></returns>
        public override string Encrypt(string StrToEncrypt, string EncodingMode, string RSAPublicKey)
        {
            try
            {
                /// rsa object
                Chilkat.Rsa rsa = new Chilkat.Rsa();
                /// bool for success
                bool success;
                /// unlock component
                success = rsa.UnlockComponent("VIENTORSA_TbpfVVr01Or6");
                /// rsa encoding mode as base64, hex
                rsa.EncodingMode = EncodingMode;
                /// import the public key to the API
                rsa.ImportPublicKey(RSAPublicKey);
                /// decrypted string
                string encryptedStr;
                ///we now decript the string
                encryptedStr = rsa.EncryptStringENC(StrToEncrypt, false);
                /// return the string
                return encryptedStr;
            }
            catch
            {
                return null;
            }
            finally
            {
                GC.Collect();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="StrToDecrypt"></param>
        /// <param name="EncodingMode"></param>
        /// <returns></returns>
        public override string Decrypt(string StrToDecrypt, string EncodingMode, string RSAPrivateKey)
        {
            try
            {
                //  Now decrypt:
                Chilkat.Rsa rsaDecryptor = new Chilkat.Rsa();
                /// bool for success
                bool success;
                /// unlock component
                success = rsaDecryptor.UnlockComponent("VIENTORSA_TbpfVVr01Or6");
                /// we encode in 64 base bits
                rsaDecryptor.EncodingMode = EncodingMode;
                ///rsa import private 
                rsaDecryptor.ImportPrivateKey(RSAPrivateKey);
                /// decrypted string
                string decryptedStr;
                ///we now decript the string
                decryptedStr = rsaDecryptor.DecryptStringENC(StrToDecrypt, true);
                /// return the string
                return decryptedStr;
            }
            catch
            {
                return null;
            }
            finally
            {
                GC.Collect();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override List<string> GenerateNewRSAKeyPair()
        {
            try
            {
                /// rsa object from library
                Chilkat.Rsa rsa = new Chilkat.Rsa();
                /// unlock component
                bool success = rsa.UnlockComponent("VIENTORSA_TbpfVVr01Or6");
                /// we generate the amount key from amount of bits
                success = rsa.GenerateKey(2048);
                /// this is the public key
                string publicKey = rsa.ExportPublicKey();
                /// this is the private key
                string privateKey = rsa.ExportPrivateKey();
                /// we return the new elements
                return new List<string>() { privateKey, publicKey };
            }
            catch
            {
                return null;
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
