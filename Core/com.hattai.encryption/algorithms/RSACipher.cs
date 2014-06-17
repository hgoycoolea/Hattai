using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.hattai.encryption.algorithms
{
    public class RSACipher
    {
        /// <summary>
        /// Encrypt using Given Public Key
        /// </summary>
        /// <param name="StringToEncrypt">w to Encrypt</param>
        /// <param name="PublicKey"></param>
        /// <returns></returns>
        public static string Encrypt(string StrToEncrypt, string PublicKey, string EncodingMode)
        {
            try
            {
                /// First we get the RSA Public Key
                string RSAPublicKey = PublicKey;
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
        /// Decrypt using a Given Private Key
        /// </summary>
        /// <param name="StringToDecrypt">w to Decrypt</param>
        /// <param name="PrivateKey"></param>
        /// <param name="EncodingMode">base64, hex</param>
        /// <returns></returns>
        public static string Decrypt(string StrToDecrypt, string PrivateKey, string EncodingMode)
        {
            try
            {
                /// First we get the RSA Public Key
                string RSAPrivateKey = PrivateKey;
                /// rsa object
                Chilkat.Rsa rsa = new Chilkat.Rsa();
                /// bool for success
                bool success;
                /// unlock component
                success = rsa.UnlockComponent("VIENTORSA_TbpfVVr01Or6");
                /// private key
                string privateKey;
                ///we now export the private key
                privateKey = rsa.ExportPrivateKey();
                //  Now decrypt:
                Chilkat.Rsa rsaDecryptor = new Chilkat.Rsa();
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
        /// Method to Generate new keys according Possition
        /// { "keys" :
        /// { "0" : private key,
        ///   "1" : public key }
        /// }
        /// </summary>
        /// <returns></returns>
        public static List<string> GenerateNewRSAKeyPair()
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
    }
}
