using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace V4mp1r3
{
    public partial class frmV4mp1r3 : Form
    {
        public frmV4mp1r3()
        {
            InitializeComponent();
        }

        private void frmV4mp1r3_Load(object sender, EventArgs e)
        {
            label1.Text = "V4mp1r3是一款基于C#的开源WinForm远程控制软件。";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/7hr0wer/V4mp1r3/");
        }
    }
}
