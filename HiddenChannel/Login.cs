using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace HiddenChannel
{
    public partial class Login : Form
    {
        string Server_Ip = Program.Server_Ip;
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Username = textBox1.Text;
            string Passwd_MD5 = Program.GetMD5_32(textBox2.Text, "utf-8");
            if (Username != "" && Passwd_MD5 != "")
            {
                WebRequest webrequest = WebRequest.Create(string.Format(Server_Ip + "/login?Username={0}&Passwd={1}", Username, Passwd_MD5));
                WebResponse webresponse = webrequest.GetResponse();
                Stream s = webresponse.GetResponseStream();
                StreamReader sr = new StreamReader(s, Encoding.GetEncoding("UTF-8"));
                string result = sr.ReadToEnd();
                if (result == "0")
                {
                    MessageBox.Show("账号密码错误，请检查后重新输入");
                }
                else
                {
                    Program.Username = Username;
                    Program.Session = result;
                    Form1 form1 = new Form1();
                    form1.JoinedRoom();
                    form1.MyCreateRoom();
                    this.Dispose();
                }
            }
            else
            {
                MessageBox.Show("请输入用户名和密码");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Username = textBox1.Text;
            string Passwd_MD5 = Program.GetMD5_32(textBox2.Text, "utf-8");
            if (Username != "" && Passwd_MD5 != "")
            {
                WebRequest webrequest = WebRequest.Create(string.Format(Server_Ip + "/register?Username={0}&Passwd={1}", Username, Passwd_MD5));
                WebResponse webresponse = webrequest.GetResponse();
                Stream s = webresponse.GetResponseStream();
                StreamReader sr = new StreamReader(s, Encoding.GetEncoding("UTF-8"));
                string result = sr.ReadToEnd();
                if (result == "0")
                {
                    MessageBox.Show("用户名已存在");
                }
                else
                {
                    MessageBox.Show("注册成功，请重新登录");
                }
            }
            else
            {
                MessageBox.Show("请输入用户名和密码");
            }
        }
    }
}
