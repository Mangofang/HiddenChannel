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

namespace HiddenChannel
{
    public partial class AddKey : Form
    {
        static string Server_Ip = Program.Server_Ip;
        public AddKey()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Program.RoomId != "0")
            {
                string RoomName = Program.Sendwebapi(string.Format(Server_Ip + "/room/get_roomname?RoomId={0}", Program.RoomId), "get", "");
                if (!Directory.Exists("Keys"))
                {
                    Directory.CreateDirectory("Keys");
                }
                File.WriteAllText("./Keys/" + RoomName + "PrivateKey.xml", richTextBox1.Text);
                MessageBox.Show("导入完成");
                this.Dispose();
            }
            else
            {
                MessageBox.Show("房间号设置错误，请重新进入房间后重试");
                this.Dispose();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            dialog.Title = "请选择私钥文件";
            dialog.Filter = "私钥文件(*.xml)|*.xml";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string file_path = dialog.FileName;
                textBox1.Text = file_path;
                richTextBox1.Text =  File.ReadAllText(file_path);
            }
        }
    }
}
