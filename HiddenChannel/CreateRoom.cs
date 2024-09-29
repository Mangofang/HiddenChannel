using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HiddenChannel
{
    public partial class CreateRoom : Form
    {
        string Server_Ip = Program.Server_Ip;
        public CreateRoom()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Program.Username != "" && Program.Session != "")
            {
                string RoomName = textBox1.Text;
                string Info = textBox2.Text;
                if (!Directory.Exists("Keys"))
                {
                    Directory.CreateDirectory("Keys");
                }
                string CreateRsa_Result = Program.CreateRsa(".\\Keys\\", RoomName);
                string PrivateKey = File.ReadAllText("./Keys/" + RoomName + "PrivateKey.xml");
                string PublicKey = File.ReadAllText("./Keys/" + RoomName + "PublicKey.xml");
                string RoomId = Program.Sendwebapi(string.Format(Server_Ip + "/room/create?Username={0}&Session={1}&RoomName={2}&Info={3}", Program.Username, Program.Session, RoomName, Info), "post", PublicKey);
                MessageBox.Show("创建完成");
                string result = Program.Sendwebapi(string.Format(Server_Ip + "/room/join?Username={0}&Session={1}&RoomId={2}", Program.Username, Program.Session, RoomId), "get", "");
                this.Dispose();
            }
        }
    }
}
