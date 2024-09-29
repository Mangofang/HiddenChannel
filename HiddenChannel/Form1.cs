using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace HiddenChannel
{
    public partial class Form1 : Form
    {
        string Server_Ip = Program.Server_Ip;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            start:
            try
            {
                if (Program.Username == "" || Program.Session == "")
                {
                    label1.Text = "点击登录";
                }
                else
                {
                    JoinedRoom();
                    MyCreateRoom();
                }
                //获取公共房间
                string result = Program.Sendwebapi(Server_Ip + "/getroom", "get", "");
                JArray jobj = JArray.Parse(result);
                for (int i = 0; i < jobj.Count; i++)
                {
                    ListViewItem li = new ListViewItem();
                    li.Text = i.ToString();
                    li.SubItems.Add(jobj[i]["Name"].Value<string>());
                    li.SubItems.Add(jobj[i]["Own"].Value<string>());
                    li.SubItems.Add(jobj[i]["Info"].Value<string>());
                    li.SubItems.Add(jobj[i]["RoomId"].Value<string>());
                    listView1.Items.Add(li);
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("连接服务器失败...开始重试...");
                Thread.Sleep(500);
                goto start; 
            }
        }
        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            //公共房间Page右键菜单
            ListView listView = (ListView)sender;
            ListViewItem item = listView.GetItemAt(e.X, e.Y);
            if (item != null && e.Button == MouseButtons.Right)
            {
                this.ListViewEdit.Show(listView, e.X, e.Y);
            }
        }
        private void listView2_MouseClick(object sender, MouseEventArgs e)
        {
            //已加入的房间Page右键菜单
            ListView listView = (ListView)sender;
            ListViewItem item = listView.GetItemAt(e.X, e.Y);
            if (item != null && e.Button == MouseButtons.Right)
            {
                this.JoinedListViewEdit.Show(listView, e.X, e.Y);
            }
        }
        private void Join_Click(object sender, EventArgs e)
        {
            if (Program.Username != "" && Program.Session != "")
            {
                ListView.SelectedIndexCollection indexes = this.listView1.SelectedIndices;
                int roomid = 0;
                if (indexes.Count > 0)
                {
                    int index = indexes[0];
                    roomid = Convert.ToInt32(this.listView1.Items[index].SubItems[4].Text);
                }
                //加入房间
                string result = Program.Sendwebapi(string.Format(Server_Ip + "/room/join?Username={0}&Session={1}&RoomId={2}", Program.Username, Program.Session, roomid), "get", "");
                if (result == "1")
                {
                    MessageBox.Show("加入成功");
                    JoinedRoom();
                    MyCreateRoom();
                }
                else
                {
                    MessageBox.Show("加入失败或你以添加该房间");
                    JoinedRoom();
                    MyCreateRoom();
                }
            }
            else
            {
                MessageBox.Show("请先登录");
                label1_Click(sender, e);
            }
            
        }
        private void Info_Click(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {
            //登录按钮
            if (Program.Username == "" && Program.Session == "")
            {
                Login Login = new Login();
                Login.ShowDialog();
                if (Login == null || Login.CanFocus == false)
                {
                    if (Program.Username != "" && Program.Session != "")
                    {
                        label1.Text = "Hello " + Program.Username;
                        JoinedRoom();
                        MyCreateRoom();
                    }
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //注销登录
            Program.Sendwebapi(string.Format(Server_Ip + "/logout?Username={0}&Session={1}", Program.Username, Program.Session), "get", "");
        }

        private void QuitRoom_Click(object sender, EventArgs e)
        {
            //右键菜单退出房间
            ListView.SelectedIndexCollection indexes = this.listView2.SelectedIndices;
            int roomid = 0;
            if (indexes.Count > 0)
            {
                int index = indexes[0];
                roomid = Convert.ToInt32(this.listView2.Items[index].SubItems[4].Text);
            }
            string result = Program.Sendwebapi(string.Format(Server_Ip + "/room/quit?Username={0}&Session={1}&RoomId={2}", Program.Username, Program.Session, roomid), "get", "");
            if (result == "1")
            {
                MessageBox.Show("退出成功");
                JoinedRoom();
            }
            else
            {
                MessageBox.Show("操作失败或你是房主");
                JoinedRoom();
            }
        }
        public void MyCreateRoom()
        {
            //获取我创建的房间
            if (Program.Username != "" && Program.Session != "")
            {
                string result = Program.Sendwebapi(string.Format(Server_Ip + "/mycreateroom?Username={0}&Session={1}", Program.Username, Program.Session), "get", "");
                if (result != "0")
                {
                    string Username = Program.Username;
                    string Session = Program.Session;
                    JArray jArray = JArray.Parse(result);
                    listView3.Items.Clear();
                    for (int i = 0; i < jArray.Count; i++)
                    {
                        try
                        {
                            ListViewItem li = new ListViewItem();
                            li.Text = i.ToString();
                            li.SubItems.Add(jArray[i]["Name"].Value<string>());
                            li.SubItems.Add(jArray[i]["Own"].Value<string>());
                            li.SubItems.Add(jArray[i]["Info"].Value<string>());
                            li.SubItems.Add(jArray[i]["RoomId"].Value<string>());
                            listView3.Items.Add(li);
                        }
                        catch (Exception ex) { continue; }
                    }
                }
            }
        }
        public void JoinedRoom()
        {
            //获取已加入的房间
            if (Program.Username != "" && Program.Session != "")
            {
                string result = Program.Sendwebapi(string.Format(Server_Ip + "/joinedroom?Username={0}&Session={1}", Program.Username, Program.Session), "get", "");
                if (result != "0")
                {
                    string Username = Program.Username;
                    string Session = Program.Session;
                    JArray jArray = JArray.Parse(result);
                    listView2.Items.Clear();
                    for (int i = 0; i < jArray.Count; i++)
                    {
                        try
                        {
                            ListViewItem li = new ListViewItem();
                            li.Text = i.ToString();
                            li.SubItems.Add(jArray[i]["Name"].Value<string>());
                            li.SubItems.Add(jArray[i]["Own"].Value<string>());
                            li.SubItems.Add(jArray[i]["Info"].Value<string>());
                            li.SubItems.Add(jArray[i]["RoomId"].Value<string>());
                            listView2.Items.Add(li);
                        }
                        catch (Exception ex) { continue; }
                    }
                }
            }
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            //注销登录
            if (Program.Username != "" && Program.Session != "")
            {
                string result = Program.Sendwebapi(string.Format(Server_Ip + "/logout?Username={0}&Session={1}", Program.Username, Program.Session), "get", "");
                if (result == "1")
                {
                    MessageBox.Show("已退出当前登录状态");
                    label1.Text = "点击登录";
                    Program.Username = "";
                    Program.Session = "";
                    listView2.Items.Clear();
                    listView3.Items.Clear();
                }
            }
        }
        private void CreateRoomButton_Click(object sender, EventArgs e)
        {
            if (Program.Username != "" && Program.Session != "")
            {
                CreateRoom CreateRoom = new CreateRoom();
                CreateRoom.ShowDialog();
                if (CreateRoom == null || CreateRoom.CanFocus == false)
                {
                    if (Program.Username != "" && Program.Session != "")
                    {
                        JoinedRoom();
                        MyCreateRoom();
                        string result = Program.Sendwebapi(Server_Ip + "/getroom","get","");
                        JArray jobj = JArray.Parse(result);
                        listView1.Items.Clear();
                        for (int i = 0; i < jobj.Count; i++)
                        {
                            ListViewItem li = new ListViewItem();
                            li.Text = i.ToString();
                            li.SubItems.Add(jobj[i]["Name"].Value<string>());
                            li.SubItems.Add(jobj[i]["Own"].Value<string>());
                            li.SubItems.Add(jobj[i]["Info"].Value<string>());
                            li.SubItems.Add(jobj[i]["RoomId"].Value<string>());
                            listView1.Items.Add(li);
                        }
                    }
                }
            }
            else 
            {
                MessageBox.Show("请先登录");
                label1_Click(sender, e);
            }
        }

        private void DelRoom_Click(object sender, EventArgs e)
        {
            if (Program.Username != "" && Program.Session != "")
            {
                ListView.SelectedIndexCollection indexes = this.listView3.SelectedIndices;
                int roomid = 0;
                if (indexes.Count > 0)
                {
                    int index = indexes[0];
                    roomid = Convert.ToInt32(this.listView3.Items[index].SubItems[4].Text);
                }
                string result = Program.Sendwebapi(string.Format(Server_Ip + "/room/delete?Username={0}&Session={1}&RoomId={2}", Program.Username, Program.Session, roomid), "get", "");
                
                if (result == "1")
                {
                    MessageBox.Show("删除成功");
                    Program.Sendwebapi(string.Format(Server_Ip + "/room/quit?Username={0}&Session={1}&RoomId={2}", Program.Username, Program.Session, roomid), "get", "");
                    JoinedRoom();
                    MyCreateRoom();
                    string result_ = Program.Sendwebapi(Server_Ip + "/getroom", "get", "");
                    listView1.Items.Clear();
                    JArray jobj = JArray.Parse(result_);
                    for (int i = 0; i < jobj.Count; i++)
                    {
                        ListViewItem li = new ListViewItem();
                        li.Text = i.ToString();
                        li.SubItems.Add(jobj[i]["Name"].Value<string>());
                        li.SubItems.Add(jobj[i]["Own"].Value<string>());
                        li.SubItems.Add(jobj[i]["Info"].Value<string>());
                        li.SubItems.Add(jobj[i]["RoomId"].Value<string>());
                        listView1.Items.Add(li);
                    }
                }
                else
                {
                    MessageBox.Show("删除失败");
                    JoinedRoom();
                    MyCreateRoom();
                }
            }
        }

        private void listView3_MouseClick(object sender, MouseEventArgs e)
        {
            ListView listView = (ListView)sender;
            ListViewItem item = listView.GetItemAt(e.X, e.Y);
            if (item != null && e.Button == MouseButtons.Right)
            {
                this.MyCreateLiewEdit.Show(listView, e.X, e.Y);
            }
        }

        private void OpenRoom_Click(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection indexes = this.listView2.SelectedIndices;
            int roomid = 0;
            if (indexes.Count > 0)
            {
                int index = indexes[0];
                roomid = Convert.ToInt32(this.listView2.Items[index].SubItems[4].Text);
            }
            Program.RoomId = roomid.ToString();
            Message messages = new Message();
            messages.ShowDialog();
        }
    }
}
