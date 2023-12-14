
using System.Security.Cryptography;
using System.Text;

namespace Project.Utilities
{
    public class Functions
    {
        public static int _UserID = 0;
        public static string _UserName = String.Empty;
        public static string _UserEmail = String.Empty;
        public static string _Mess = String.Empty;
        public static string _MessEmail = String.Empty;
        public static string TitleSlugGenerator(string type, string title, long id)
        {
            string sTitle = type + "-" + SlugGenerator.SlugGenerator.GenerateSlug(title) + "-" + id.ToString() + ".html";
            return sTitle;
        }
        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
            byte[] result = md5.Hash;
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                str.Append(result[i].ToString("x2"));
            }
            return str.ToString();
        }
        public static string MD5Passwod(string? text)
        {
            string str = MD5Hash(text);
            for (int i = 0; i <= 5; i++)
            {
                str = MD5Hash(str + "_" + str);

            }
            return str;
        }
        public static bool IsLogin()
        {
            if (string.IsNullOrEmpty(Functions._UserName) || string.IsNullOrEmpty(Functions._UserEmail) || (Functions._UserID == 0))
                return false;
            return true;
        }
    }
}
