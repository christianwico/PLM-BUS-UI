using System.Security.Cryptography;
using System.Text;

namespace BUR_UI.Interface
{
    public class Crypt
    {
        public static string ConvertToHash(string password)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5Provider = new MD5CryptoServiceProvider();
            byte[] bs = md5Provider.ComputeHash(new UTF8Encoding().GetBytes(password));

            foreach (byte b in bs)
            {
                hash.Append(b.ToString("x2"));
            }

            return hash.ToString();
        }
    }
}
