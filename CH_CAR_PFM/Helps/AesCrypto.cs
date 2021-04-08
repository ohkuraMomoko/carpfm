using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CH_CAR_PFM.Helps
{
    public class AesCrypto
    {
        private AesCryptoServiceProvider AesCryptoServiceProvider { get; set; }

        public AesCrypto(string Key, string IV)
        {
            this.AesCryptoServiceProvider = new AesCryptoServiceProvider()
            {
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7,
                Key = new SHA256Managed().ComputeHash(Encoding.ASCII.GetBytes(Key)),
                IV = Encoding.ASCII.GetBytes(IV)
            };
        }

        /// <summary>
        /// 字串加密
        /// </summary>
        /// <param name="Source">加密前字串</param>
        /// <returns>加密後字串</returns>
        public string Encryptor(string Source)
        {
            byte[] dataByteArray = Encoding.UTF8.GetBytes(Source);
            using (MemoryStream ms = new MemoryStream())
            using (CryptoStream cs = new CryptoStream(ms, this.AesCryptoServiceProvider.CreateEncryptor(), CryptoStreamMode.Write))
            {
                cs.Write(dataByteArray, 0, dataByteArray.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray());
            }
        }

        /// <summary>
        /// 字串解密
        /// </summary>
        /// <param name="Source">解密前字串</param>
        /// <returns>解密後字串</returns>
        public string Decryptor(string Source)
        {
            byte[] dataByteArray = Convert.FromBase64String(Source);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, this.AesCryptoServiceProvider.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(dataByteArray, 0, dataByteArray.Length);
                    cs.FlushFinalBlock();
                    return Encoding.UTF8.GetString(ms.ToArray());
                }
            }
        }
    }
}