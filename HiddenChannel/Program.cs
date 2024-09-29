using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace HiddenChannel
{
    internal static class Program
    {
        public static string Username = "";
        public static string Session = "";
        public static string RoomId = "0";
        public static string Server_Ip = "http://114.55.145.131:7890";
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        public static string Sendwebapi(string url,string request,string postdata)
        {
            if (request.ToUpper() == "GET")
            {
                WebRequest webrequest = WebRequest.Create(url);
                WebResponse webresponse = webrequest.GetResponse();
                Stream s = webresponse.GetResponseStream();
                StreamReader sr = new StreamReader(s, Encoding.GetEncoding("UTF-8"));
                string result = sr.ReadToEnd();
                webrequest.Abort();
                webresponse.Close();
                s.Close();
                return result;
            }
            if (request.ToUpper() == "POST")
            {
                try
                {
                    string postdate = postdata;
                    byte[] bt = Encoding.UTF8.GetBytes(postdate);
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(new Uri(url));
                    req.Method = "POST";
                    req.ContentType = "text/plain";
                    Stream stm = req.GetRequestStream();
                    stm.Write(bt, 0, bt.Length);
                    stm.Close();
                    HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                    Stream stms = res.GetResponseStream();
                    StreamReader reader = new StreamReader(stms, Encoding.UTF8);
                    string result = reader.ReadToEnd();
                    reader.Close();
                    req.Abort();
                    return result;
                }
                catch (Exception ex) { return "0"; }

            }
            return "0";
        }
        public static string CreateRsa(string path,string filename)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            using (StreamWriter writer = new StreamWriter(path + filename + "PrivateKey.xml"))
            {
                writer.WriteLine(rsa.ToXmlString(true));
            }
            using (StreamWriter writer = new StreamWriter(path + filename + "PublicKey.xml"))
            {
                writer.WriteLine(rsa.ToXmlString(false));
            }
            return "1";
        }
        public static string RSAEncrypt(string xmlPublicKey, string content)
        {
            string encryptedContent = string.Empty;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(xmlPublicKey);
                byte[] encryptedData = rsa.Encrypt(Encoding.Default.GetBytes(content), false);
                encryptedContent = Convert.ToBase64String(encryptedData);
            }
            return encryptedContent;
        }
        public static string RSADecrypt(string xmlPrivateKey, string content)
        {
            string decryptedContent = string.Empty;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(xmlPrivateKey);
                byte[] decryptedData = rsa.Decrypt(Convert.FromBase64String(content), false);
                decryptedContent = Encoding.GetEncoding("gb2312").GetString(decryptedData);
            }
            return decryptedContent;
        }
        public static string GetMD5_32(string s, string _input_charset)
        {
            MD5 md5 = MD5.Create();
            byte[] t = md5.ComputeHash(Encoding.GetEncoding(_input_charset).GetBytes(s));
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < t.Length; i++)
            {
                stringBuilder.Append(t[i].ToString("x").PadLeft(2, '0'));
            }
            return stringBuilder.ToString();
        }
    }
}
