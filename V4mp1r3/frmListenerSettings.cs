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

namespace V4mp1r3
{
    public partial class frmListenerSettings : Form
    {
        public frmListenerSettings()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Int32.Parse(textBox1.Text);
                string[] port = { "" };
                port[0] = textBox1.Text;
                File.WriteAllLines("Port.txt", port);
                MessageBox.Show("设置成功！重启程序以生效！", "提示");
            }
            catch
            {
                MessageBox.Show("请输入正确端口号！", "提示");
            }
        }

        private void frmListenerSettings_Load(object sender, EventArgs e)
        {
            try
            {
                string[] port = { "" };
                port = File.ReadAllLines("Port.txt");
                textBox1.Text = port[0];
            }
            catch
            {
                MessageBox.Show("配置文件丢失！", "提示");
            }
        }
    }
}
