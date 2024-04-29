using System.Drawing.Imaging;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;

namespace webbanxe.Help
{
    public class EncryptPassword
    {
        // md5
        public static string  EncrytMd5(string password)
        {
            StringBuilder hash = new StringBuilder();
            // defining MD5 object
            var md5provider = new MD5CryptoServiceProvider();
            // computing MD5 hash
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(password));
            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            // final output
           return hash.ToString();
        }
        


        // RSA

        private static UnicodeEncoding _encoder = new UnicodeEncoding();

       
        public static string EncryptRSA(string data, string _publicKey)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            //NẠP PUBLIC KEY
            rsa.FromXmlString(_publicKey);
            byte[] dataToEncrypt = _encoder.GetBytes(data);
            //MÃ HÓA
            byte[] encryptedByteArray = rsa.Encrypt(dataToEncrypt, false);
            long length = encryptedByteArray.LongLength;
            long item = 0;
            StringBuilder sb = new StringBuilder();
            foreach (byte x in encryptedByteArray)
            {
                item++;
                sb.Append(x);

                if (item < length)
                    sb.Append(",");
            }

            return sb.ToString();
        }

        public static string DecryptRSA(string data, string _privateKey)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            string[] dataArray = data.Split(new char[] { ',' });
            byte[] dataByte = new byte[dataArray.Length];
            for (int i = 0; i < dataArray.Length; i++)
            {
                dataByte[i] = Convert.ToByte(dataArray[i]);
            }
            //NẠP PRIVATE KEY
            rsa.FromXmlString(_privateKey);
            //GIẢI MÃ
            byte[] decryptedByte = rsa.Decrypt(dataByte, false);
            return _encoder.GetString(decryptedByte);
        }
    }
}
