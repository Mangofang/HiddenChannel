using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace HiddenChannel
{
    public partial class Message : Form
    {
        static string Server_Ip = Program.Server_Ip;
        static string roomname = Program.Sendwebapi(string.Format(Server_Ip + "/room/get_roomname?RoomId={0}", Program.RoomId), "get", "");
        bool windows = true;
        string PublicKey = "";
        public Message()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void Messages_Load(object sender, EventArgs e)
        {
            if (Program.RoomId != "0")
            {
                PublicKey = Program.Sendwebapi(string.Format(Server_Ip + "/room/get_publickey?Username={0}&Session={1}&RoomId={2}", Program.Username, Program.Session, Program.RoomId), "get", "");
            }
            if (Program.Username != "" && Program.Session != "")
            {
                if (File.Exists("./Keys/" + roomname + "PrivateKey.xml"))
                {
                    try
                    {
                        string PrivateKey = File.ReadAllText("./Keys/" + roomname + "PrivateKey.xml");
                        ThreadPool.QueueUserWorkItem(get_message =>
                        {
                            while (windows)
                            {
                                string RoomId = Program.RoomId;
                                string result = Program.Sendwebapi(string.Format(Server_Ip + "/messages/get_message?Username={0}&Session={1}&RoomId={2}", Program.Username, Program.Session, RoomId), "get", "");
                                if (result != "0")
                                {
                                    JArray jArray = JArray.Parse(result);
                                    string text = "";
                                    for (int i = 0; i < jArray.Count; i++)
                                    {
                                        string UserName = jArray[i]["Username"].Value<string>();
                                        string Message = jArray[i]["Text"].Value<string>();
                                        Message = Program.RSADecrypt(PrivateKey, Message);
                                        string new_text = UserName + ":\n" + Message + "\n";
                                        text += new_text;
                                    }
                                    richTextBox2.Text = text;
                                    richTextBox2.SelectionStart = richTextBox2.Text.Length;
                                    richTextBox2.ScrollToCaret();
                                }
                                Thread.Sleep(2000);
                                richTextBox2.Clear();
                                string Name = Program.Sendwebapi(string.Format(Server_Ip + "/room/whoinroom?Username={0}&Session={1}&RoomId={2}", Program.Username, Program.Session, Program.RoomId), "get", "");
                                JArray jobj = JArray.Parse(Name);
                                listView1.Items.Clear();
                                for (int i = 0; i < jobj.Count; i++)
                                {
                                    ListViewItem li = new ListViewItem();
                                    li.Text = i.ToString();
                                    li.SubItems.Add(jobj[i]["Username"].Value<string>());
                                    string state = "离线";
                                    if (jobj[i]["IsLogin"].Value<string>() == "1")
                                    {
                                        state = "在线";
                                    }
                                    li.SubItems.Add(state);
                                    listView1.Items.Add(li);
                                }
                            }
                        });
                    }
                    catch (Exception ex)
                    {
                        AddKey addKey = new AddKey();
                        addKey.ShowDialog();
                        this.Dispose();
                    }
                }
                else 
                {
                    MessageBox.Show("未检测到当前房间密钥，请先导入密钥");
                    AddKey addKey = new AddKey();
                    addKey.ShowDialog();
                    this.Dispose();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Program.Username != "" && Program.Session != "")
            {
                string send_text = richTextBox1.Text;
                send_text = Program.RSAEncrypt(PublicKey, send_text);
                Program.Sendwebapi(string.Format(Server_Ip + "/messages/send_message?Username={0}&Session={1}&RoomId={2}", Program.Username, Program.Session, Program.RoomId),"post", send_text);
                richTextBox1.Clear();
            }
        }

        private void Message_FormClosing(object sender, FormClosingEventArgs e)
        {
            windows = false;
        }
    }
}
