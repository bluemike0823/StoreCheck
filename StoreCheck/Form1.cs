using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Printing;
using System.IO.Ports;
using System.Threading;
using System.Net.NetworkInformation;
using System.Net;
using static System.Environment;
using System.Security.Principal;
using System.Security;
using System.ServiceProcess;
using System.IO;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using System.Management;

namespace StoreCheck
{


    public partial class Form1 : Form
    {
        public static int user = 0;
        
        const string VERSION = "1.1.3:564";

        static string ip_str = Dns.GetHostEntry(Dns.GetHostName()).AddressList[1].ToString();
        
        //if (ip_str.Substring(ip_str.Length - 2).Equals(".2"))
        //{
        //    return "此電腦無相關資料夾";
        //}
        

        public static SerialPort port = new SerialPort("com11", 9600, Parity.None, 8, StopBits.One);
        public static string URL = "http://192.168.1.12/fmo/jsp/api/storechk_api.jsp?";
        public static string[] myclass = { "EGUI-29176610", "EGUI-12974203", "EGUI-23530966", "EGUI-84945045" };
        //public static string[] paths = { @"192.168.2.21", @"192.168.200.2" };
        public static string[] paths = { @"192.168.200.1",@"192.168.200.2", @""};
        static string find_path = "";
        static string find_class = "";
        static int[] run_solution = {0, 0, 0, 0};

        public Form1()
        {

            System.Security.Principal.WindowsIdentity identity = System.Security.Principal.WindowsIdentity.GetCurrent();
            System.Security.Principal.WindowsPrincipal principal = new System.Security.Principal.WindowsPrincipal(identity);

            chk_version();


            if (principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator))
            {
                user = 1;
            }

            InitializeComponent();
            
            if(user == 1)
            {
                this.Text = "門市系統測試(管理員權限)";
                res_label.Focus();
            }
            this.Text += "  " + VERSION;
        }

        private static void chk_version()
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(URL + "func=get_version&app_kind=storechk");
            req.Method = "GET";
            req.ContentType = "application/x-www-form-urlencoded";

            req.Timeout = 5000;

            string result = "";

            using (HttpWebResponse res = (HttpWebResponse)req.GetResponse())
            {
                using (StreamReader sr = new StreamReader(res.GetResponseStream()))
                {
                    result = sr.ReadToEnd();
                }
            }

            if(result.Substring(0,result.LastIndexOf(".")).Equals(VERSION.Substring(0, result.LastIndexOf(".")))){
                //MessageBox.Show("目前版本 : " + VERSION);
            }
            else
            {
                MessageBox.Show("建議至 'eROS >> 元件下載' 更新版本 : " + result);
                //Environment.Exit(ExitCode);
            }

        }

        public static String myPing()
        {
            //String URL = "http://192.168.1.15/fmo";
            String URL = "192.168.1.15";
            //Console.WriteLine("myPing");
            bool IsOnline = false;
            Ping pinger = new Ping();
            try
            {
                PingReply pingReply = pinger.Send(hostNameOrAddress: URL, timeout: 120);

                IsOnline = true;
                return String.Format("網路正常 , eROS可正常使用" + "\n");
            }
            catch (Exception e)
            {
                //Console.WriteLine("eROS 無法連線 -> {0}", e);
                return String.Format("網路異常 , 請連絡資訊室" 
         +"若網路電話也不通, 請聯絡 0809 - 000 - 365(台灣固網客服)" 
         + "\n");
            }
        }


        public static String myPrintInvoice()
        {
            Process[] process = Process.GetProcesses();
            bool IsExist = false;
            foreach (Process i in process)
            {
                if (i.ProcessName.Equals("PrintInvoice"))
                {
                    IsExist = true;
                    //Console.Write("PrintInvoice is work \n");
                }
                else
                {
                    //Console.Write("PrintInvoice isn't work \n");
                }
            }
            if (IsExist)
            {
               // Console.WriteLine("PrintInvoice 已執行");
                return String.Format("金財通發票程式正常" + "\n");
               //return true;
            }
            else
            {
                run_solution[3] = 1;
                return String.Format("金財通發票程式異常，請執行'修復測試'" + "\n");
                //return false;
            }
        }

        public static String myPdisk()
        {
            paths[2] = ip_str;

            //Ping ping = new Ping();
            //PingResponse
            //net 
            try
            {
                //string path = @"\\192.168.200.1\";
                //string path2 = @"\\192.168.200.2\";
                //foreach (string i in myclass)
                //{
                //    //string path = @"C:\" + i;

                //    if (Directory.Exists(path) || Directory.Exists(path2))
                //    {
                //        find_class = i;
                //    }
                //    else
                //    {
                //        continue;
                //    }
                //}

                //DirectoryInfo info = new DirectoryInfo(path);
                //DirectoryInfo info2 = new DirectoryInfo(path);


                string [] dir;
                bool ispass = false;
                string ret = "";

                //using (ManagementClass shares = new ManagementClass("Win32_Share"))
                //{
                //    //ret += "folder : " + p + "\n";
                //    foreach (ManagementObject share in shares.GetInstances())
                //    {
                //        string n = share["Name"].ToString();
                //        if (n.Contains("EGUI-") || n.Contains("egui-"))
                //        {
                //            find_class = n;
                //            MessageBox.Show("find_class = " + n);
                //        }
                //        //MessageBox.Show(share["Name"].ToString());
                //        //ret += "--> " + share["Name"].ToString() + " \n";
                //    }

                //};
                foreach (string n in myclass)
                {
                    foreach (string p in paths)
                    {
                        string _path = @"\\" + p + @"\" + n;
                        //MessageBox.Show(_path);
                        Task.Factory.StartNew(() =>
                        {
                            //MessageBox.Show(_path);
                            if (Directory.Exists(_path))
                            {
                                ispass = true;
                                find_class = n;
                                find_path = p;
                            //MessageBox.Show("get");
                        }
                        }).Wait(1 * 1000);

                        //dir = Directory.GetDirectories(p);
                        //foreach (string x in dir)
                        //{
                        //    //x = x.Substring(x.LastIndexOf(@"\") + 1,x.Length - x.LastIndexOf(@"\") - 1);
                        //    //MessageBox.Show(x.Substring(x.LastIndexOf(@"\") + 1, x.Length - x.LastIndexOf(@"\") - 1));
                        //    string n = x.Substring(x.LastIndexOf(@"\") + 1, x.Length - x.LastIndexOf(@"\") - 1);
                        //    if (n.Contains("egui-") || n.Contains("EGUI-"))
                        //    {
                        //        ispass = true;
                        //        find_path = p;
                        //        find_class = n;
                        //    }
                        //}
                        if (ispass) break;
                    }
                }
                //return ret;

                if(!ispass) return String.Format(" P槽遺失，請執行'修復測試'" + "\n");





                // if find_class = ""
                // second machine

                DriveInfo[] drives = DriveInfo.GetDrives();
                foreach (DriveInfo temp in drives)
                {
                    if (temp.Name.Equals(@"P:\"))
                    {
                        Process prc = new Process();
                        prc.StartInfo.FileName = @"\\" + find_path + @"\" + find_class;
                        prc.Start();
                        return String.Format("P槽正常" + "\n");
                        //Console.WriteLine("P槽存在");
                        //return true;
                    }
                    //Console.WriteLine(string.Format("name : {0}", temp.Name));
                }
                run_solution[2] = 1;
                return String.Format(" P槽異常，請執行'修復測試'" + "\n");
                //return false;
            }
            catch (Exception ex)
            {
                run_solution[2] = 1;
                return String.Format(" P槽異常，請執行'修復測試'" + "\n");
                //return String.Format("P槽偵測錯誤" + ex);
                //return false;
            }
        }

        class EscPOS
        {
            public EscPOS() { }
            ~EscPOS() { }

            //public enum Alignment{ Left, Center, Right};

            public byte[] Initialize() { return new byte[2] { 0x1b, 0x40 }; }
            public byte[] PageMode(Boolean Param) { return Param ? new byte[2] { 0x1b, 0x02 } : new byte[2] { 0x1b, 0x03 }; }
            public byte[] Align(byte Param) { return new byte[3] { 0x1b, 0x61, Param }; }

            public byte[] CutPartial() { return new byte[2] { 0x1b, 0x6d }; }
            public byte[] CutFull() { return new byte[2] { 0x1b, 0x69 }; }

            public byte[] EmphasizedMode(Boolean Param) { return new byte[3] { 0x1b, 0x47, (byte)(Param ? 1 : 0) }; }
            public byte[] LineSpacing(byte Param) { return new byte[3] { 0x1b, 0x33, Param }; }
            public byte[] FeedLine(byte Param) { return new byte[3] { 0x1b, 0x64, Param }; }
            public byte[] FeedDot(byte Param) { return new byte[3] { 0x1b, 0x4a, Param }; }
            public byte[] FeedDotBack(byte Param) { return new byte[3] { 0x1b, 0x4B, Param }; }
            public byte[] CrLf() { return new byte[2] { 0x0d, 0x0a }; }
            public byte[] FontSize(byte Width, byte Height) { return new byte[3] { 0x1d, 0x21, (byte)(Width << 4 | Height) }; }

            public byte[] PrintNV(byte Param) { return new byte[4] { 0x1c, 0x70, Param, 0x0 }; }

            public byte[] StatusRealTime() { return new byte[12] { 0x10, 0x04, 1, 0x10, 0x04, 2, 0x10, 0x04, 3, 0x10, 0x04, 4 }; }

            public byte[] eReceiptBarCode(byte[] p_bufData, int p_intHeight)
            {
                byte[] s_bufHeader = new byte[] { 0x1D, 0x48, 0x30, 0x1d, 0x66, 0, 0x1d, 0x77, 1, 0x1d, 0x68, (byte)p_intHeight, 0x1d, 0x6B, 69, (byte)p_bufData.Length };
                byte[] s_bufReturn = new byte[s_bufHeader.Length + p_bufData.Length];
                s_bufHeader.CopyTo(s_bufReturn, 0);
                p_bufData.CopyTo(s_bufReturn, s_bufHeader.Length);
                return s_bufReturn;
            }

            public byte[] eReceiptQRCode(byte[] p_bufData)
            {
                byte[] s_bufHeader = new byte[] {   0x1D, 0x28, 0x6B, 3, 0, 0x31, 0x76, 6,
                                                0x1d, 0x28, 0x6b, 4, 0, 0x31, 0x41, 50, 0,
                                                0x1d, 0x28, 0x6b, 3, 0, 0x31, 0x43, 3,
                                                0x1d, 0x28, 0x6b, 3, 0, 0x31, 0x45, 48,
                                                0x1d, 0x28, 0x6b, (byte)((p_bufData.Length +3) & 0xff), (byte)((p_bufData.Length +3)>>8), 0x31, 0x50, 0x30};
                byte[] s_bufFooter = new byte[] { 0x1d, 0x28, 0x6b, 3, 0, 0x31, 0x51, 0x30 };
                byte[] s_bufReturn = new byte[s_bufHeader.Length + p_bufData.Length + s_bufFooter.Length];
                s_bufHeader.CopyTo(s_bufReturn, 0);
                p_bufData.CopyTo(s_bufReturn, s_bufHeader.Length);
                s_bufFooter.CopyTo(s_bufReturn, s_bufHeader.Length + p_bufData.Length);
                return s_bufReturn;
            }

        }

        public static bool printerIspause(PrintQueue pq)
        {

            //printQueue.Pause();
            if (pq.IsPaused)
            {
                Console.WriteLine("列印序列暫停");
                return false;
            }
            else
            {
                Console.WriteLine("列印序列執行中");
                return true;
            }
        }

        public static String myPrinter(SerialPort port)
        {

            EscPOS input = new EscPOS();
            //SerialPort port;
            Boolean IsAlive = false;
            try
            {
                if (!port.IsOpen)
                {
                    port.Open();
                }
                
                //port.Write()
                //port.Write(new byte[] { 0x02, 0x00, 0x00, 0x00, 0x00, 0x02 }, 0, 6);
                int n = 0;
                //MessageBox.Show("run");

                Task.Factory.StartNew(() =>
                {
                    while (!(IsAlive))
                    {
                        port.Write(input.StatusRealTime(), 0, 12);
                        port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
                        n++;
                    }
                }).Wait(3 * 1000);


                //MessageBox.Show("run100");
                if (IsAlive)
                {
                    return String.Format("發票機可正常運作" + "\n");
                    //return String.Format("發票機可正常運作" + "\n" + "portname : " + port.PortName + "\n");
                    //Console.WriteLine("發票機正常運作");
                    //return true;
                }
                else
                {
                    run_solution[1] = 1;
                    return String.Format("發票機無回應 , 請檢查線路後，執行'修復測試'" + "\n");
                    //return false;
                }
            }
            catch (IOException ioe)
            {
                //return String.Format("發票機錯誤 , 請檢查線路後重啟發票機 , 請選擇'嘗試修復'選項重試 : "+ fe + "\n");
                run_solution[1] = 1;

                return String.Format("發票機連線異常 , 請檢查線路後，執行'修復測試'" + "\n");
                //return String.Format("發票機連線異常 , 請檢查線路後，執行'修復測試'" + ioe.ToString() + "\n");
                //Console.WriteLine("發票機異常 : 無法取得連線" + fe);
                //return false;
            }
            catch (ArgumentException ae)
            {
                // 0029
                //return String.Format("發票機錯誤 , 請檢查線路後重啟發票機 , 請選擇'嘗試修復'選項重試 : "+ fe + "\n");
                run_solution[1] = 1;

                return String.Format("發票機無異常,如有問題請檢查線路後，執行'修復測試'" + "\n");
                //return String.Format("發票機錯誤 , 請檢查線路後，執行'修復測試'" + ae.ToString() + "\n" + "portname : " + port.PortName + "\n");
                //Console.WriteLine("發票機異常 : 無法取得連線" + fe);
                //return false;
            }
            catch (Exception e)
            {
                //return String.Format("發票機錯誤 , 請檢查線路後重啟發票機 , 請選擇'嘗試修復'選項重試 : "+ fe + "\n");
                run_solution[1] = 1;

                return String.Format("發票機錯誤 , 請檢查線路後，執行'修復測試'" + "\n");
                //return String.Format("發票機錯誤 , 請檢查線路後，執行'修復測試'" + e.ToString() + "\n");
                //Console.WriteLine("發票機異常 : 無法取得連線" + fe);
                //return false;
            }


            void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
            {
                // Show all the incoming data in the port's buffer
                //Console.WriteLine("Reader : " +port.ReadExisting());
                if (port.ReadExisting() != null)
                {
                    IsAlive = true;
                }
            }

        }

        public static void PingRecovery()
        {
            Console.WriteLine("請聯繫相關廠商");
        }

        public static String PrinterRecovery()
        {
            
            try
            {

                var processInfo = new ProcessStartInfo
                {
                    UseShellExecute = true,
                    FileName = @".\sol2.bat",
                    //FileName = @"Resources\sol2.bat",
                    Verb = "runas",
                    CreateNoWindow = true
                    
                };

                //var processInfo = new ProcessStartInfo
                //{
                //    UseShellExecute = true,
                //    FileName = @"cmd.exe",
                //    Verb = "runas",
                //    CreateNoWindow = true,
                //    //Arguments = "net stop \"Print Spooler\" net start \"Print Spooler\""
                //    Arguments = "net use"
                //};

                //Process prc = new Process();
                //prc.StartInfo.FileName = @".\sol2.bat";
                //prc.StartInfo.UseShellExecute = false;
                //prc.StartInfo.RedirectStandardInput = true;
                //prc.StartInfo.RedirectStandardOutput = true;
                //prc.StartInfo.CreateNoWindow = true;
                //prc.StartInfo.Verb = "runas";
                //prc.Start();
                //prc.WaitForExit();
                //prc.Close();
                Process.Start(processInfo);
                return String.Format("發票機修復完成 , 請回eros 正常使用 " + "\n"
                    + "  如無法使用請聯繫新耀 (02) 2298-2456" + "\n");
            }catch(Exception e)
            {
                return String.Format("發票機修復失敗 " + "\n" + "請聯繫新耀 (02) 2298-2456" + "\n");
            }

            
            /*
            string msg = null;

            ServiceController service = new ServiceController("Spooler");
            msg += "服務狀態 " + service.Status + "\n";
            if (service.Status.Equals(ServiceControllerStatus.Running))
            {
                msg += "服務狀態 " + service.Status + "\n";
                service.Stop();
            }
            else
            {
                msg += "服務狀態 " + service.Status + " 不關閉 " + "\n";
            }

            ServiceController service1 = new ServiceController("Spooler");
            if (service1.Status.Equals(ServiceControllerStatus.Stopped))
            {
                msg += "服務狀態 " + service1.Status + "\n";
                service1.Start();
            }
            else
            {
                msg += "服務狀態 " + service1.Status + " 不重啟 " + "\n";
            }
            //service1.Start();
            msg += "發票機修復 : 修復完成" + "\n";
            return String.Format(msg);

            */

            if (user == 1)
            {
               
            }
            else
            {
                
                /*
                MessageBox.Show("此功能需有管理員權限，重啟中");
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.UseShellExecute = true;
                startInfo.WorkingDirectory = Environment.CurrentDirectory;
                startInfo.FileName = Application.ExecutablePath;
                //设置启动动作,确保以管理员身份运行
                startInfo.Verb = "runas";
                System.Diagnostics.Process.Start(startInfo);
                
                Application.Exit();
                return String.Format("重啟程式\n");
                
                try
                {
                    System.Diagnostics.Process.Start(startInfo);
                    Application.Exit();
                    return String.Format("test  \n");
                }
                catch (Exception ex)
                {
                    //Form1.Close();
                    Application.Exit();
                    return String.Format("需有管理員權限 :" + ex + "\n"); 
                }
                */
                //退出


            }
            /*
            try { 
                ServiceController service = new ServiceController("Spooler");
                service.Stop();
                ServiceController service1 = new ServiceController("Spooler");
                //service1.Start();
                return String.Format("發票機修復 : 修復完成" + "\n");
            }
            catch(Exception e)
            {
                return String.Format("發票機修復 : 修復失敗 " + e +"\n");
            }
             */
        }

        //static無須建立物件
        public static String InvoiceRecovery()
        {

            try
            {
                System.Diagnostics.Process.Start("C://printinvoice/PrintInvoice.exe");
                //Console.WriteLine("金財通重啟成功");
                return String.Format("金財通修復成功 , 請回eros 正常使用\n");
            }
            catch (Exception ex)
            {
                //Console.WriteLine("金財通重啟失敗");
                return String.Format("金財通修復失敗，請連絡資訊室" + "\n");
            }
        }

        public static String pqPause(PrintQueue pq)
        {
            try
            {
                pq.Pause();
                Console.WriteLine("發票序列暫停");
                return String.Format("發票序列已暫停\n");
            }
            catch (Exception e)
            {
                return String.Format("發票序列暫停失敗 : " +e+"\n");
            }
        }

        public static String pqResume(PrintQueue pq)
        {
            try
            {
                pq.Resume();
                Console.WriteLine("發票序列重啟");
                return String.Format("發票序列已重啟\n");
            }
            catch (Exception e)
            {
                return String.Format("發票序列重啟失敗 : " + e + "\n");
            }
        }

        public static String PdiskRecovery()
        {
            DriveInfo[] disklist = DriveInfo.GetDrives();
            try
            {
               
                Process prc = new Process();
                prc.StartInfo.FileName = @"cmd.exe";
                prc.StartInfo.UseShellExecute = false;

                prc.StartInfo.RedirectStandardInput = true;
                prc.StartInfo.RedirectStandardOutput = true;
                prc.StartInfo.RedirectStandardError = true;
                prc.StartInfo.CreateNoWindow = false;
                prc.Start();

                String cmd = @"net use p: /delete /y";
                prc.StandardInput.WriteLine(cmd);
                cmd = @"net use P: \\" + find_path + @"\" + find_class + @" /USER:FMO\%username%";
                prc.StandardInput.WriteLine(cmd);
                cmd = @"net use P: \\" + find_path + @"\" + find_class;
                prc.StandardInput.WriteLine(cmd);
                cmd = @"net config server / autodisconnect:-1"; 
                prc.StandardInput.WriteLine(cmd);
                //cmd = @"pause";
                //prc.StandardInput.WriteLine(cmd);
                prc.StandardInput.Close();
                return String.Format("P槽已修復完成 , 請回eros 正常使用\n");
            }
            catch (Exception ex)
            {
                return String.Format("P 槽建立失敗，請連絡資訊室" + "\n");
                //Console.WriteLine("P 槽建立失敗 " + ex);
            }
        }

        private static SecureString ConvertToSecureString(string str)
        {
            SecureString secureString = new SecureString();
            foreach (char c in str)
            {
                secureString.AppendChar(c);
            }
            return secureString;
        }

        private void btn_net_test_Click(object sender, EventArgs e)
        {
            //res_label.Text = myPing("\\192.168.1.15\fmo");

            res_label.Text += "  " + myPing();
            res_label.Text += "================================\n";
            //myPing("\\192.168.1.15\fmo");
        }

        private void btn_machine_test_Click(object sender, EventArgs e)
        {
            res_label.Text += "  " + myPrinter(port);
            res_label.Text += "================================\n";
        }

        private void btn_pdisk_test_Click(object sender, EventArgs e)
        {
            res_label.Text += "  此流程較耗時，請稍等\n";
            res_label.Text += "  " + myPdisk();
            res_label.Text += "================================\n";
        }

        private void btn_prinrinvoice_test_Click(object sender, EventArgs e)
        {
            res_label.Text += "  " + myPrintInvoice();
            res_label.Text += "================================\n";
        }

        private void btn_net_solve_Click(object sender, EventArgs e)
        {
            res_label.Text+= "  "+"⠄⠄⠄⠄⠄⠄⠄⠈⠉⠁⠈⠉⠉⠙⠿⣿⣿⣿⣿⣿\n" +
                             "  "+"⠄⠄⠄⠄⠄⠄⠄⠄⣀⣀⣀⠄⠄⠄⠄⠄⠹⣿⣿⣿\n" +
                             "  "+"⠄⠄⠄⠄⠄⢐⣲⣿⣿⣯⠭⠉⠙⠲⣄⡀⠄⠈⢿⣿\n" +
                             "  "+"⠐⠄⠄⠰⠒⠚⢩⣉⠼⡟⠙⠛⠿⡟⣤⡳⡀⠄⠄⢻\n" +
                             "  "+"⠄⠄⢀⣀⣀⣢⣶⣿⣦⣭⣤⣭⣵⣶⣿⣿⣏⠄⠄⣿\n" +
                             "  "+"⠄⣼⣿⣿⣿⡉⣿⣀⣽⣸⣿⣿⣿⣿⣿⣿⣿⡆⣀⣿\n" +
                             "  "+"⢠⣿⣿⣿⠿⠟⠛⠻⢿⠿⣿⣿⣿⣿⣿⣿⣿⣿⣶⣼\n" +
                             "  "+"⠄⣿⣿⣿⡆⠄⠄⠄⠄⠳⡈⣿⣿⣿⣿⣿⣿⣿⣿⣿\n" +
                             "  "+"⠄⢹⣿⣿⡇⠄⠄⠄⠄⢀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿\n" +
                             "  "+"⠄⠄⢿⣿⣷⣨⣽⣭⢁⣡⣿⣿⠟⣩⣿⣿⣿⠿⠿⠟\n" +
                             "  "+"⠄⠄⠈⡍⠻⣿⣿⣿⣿⠟⠋⢁⣼⠿⠋⠉⠄⠄⠄⠄\n" +
                             "  "+"⠄⠄⠄⠈⠴⢬⣙⣛⡥⠴⠂⠄⠄⠄⠄⠄⠄⠄⠄⠄\n" +
                             "  "+"                              \n" +
                             "  "+"  你很壞哦，偷看人家  \n";
            res_label.Text += "================================\n";
        }

        private void btn_machine_solve_Click(object sender, EventArgs e)
        {
            res_label.Text += "  " + PrinterRecovery();
            res_label.Text += "================================\n";
        }

        private void btn_pdisk_solve_Click(object sender, EventArgs e)
        {
            
            res_label.Text += "  " + PdiskRecovery();
            res_label.Text += "================================\n";
        }

        private void btn_printinvoice_solve_Click(object sender, EventArgs e)
        {
            res_label.Text += "  " + InvoiceRecovery();
            res_label.Text += "================================\n";

        }

        private void btn_for_all_Click(object sender, EventArgs e)
        {
            res_label.Text += "----------> 開始測試 <----------\n";
            run_solution = new int[4] { 0, 0, 0, 0 };
            //this.btn_net_test.Click();
            /*
            this.btn_for_all.Click += new System.EventHandler(btn_net_test_Click);
            btn_net_test.PerformClick();
            this.btn_for_all.Click += new System.EventHandler(btn_machine_test_Click);
            this.btn_for_all.Click += new System.EventHandler(btn_pdisk_test_Click);
            this.btn_for_all.Click += new System.EventHandler(btn_prinrinvoice_test_Click);
          this.btn_for_all.Click += new System.EventHandler(btn_net_test_Click);
            this.btn_for_all.Click += new System.EventHandler(btn_machine_solve_Click);
            this.btn_for_all.Click += new System.EventHandler(btn_pdisk_solve_Click);
            this.btn_for_all.Click += new System.EventHandler(btn_printinvoice_solve_Click);
            */
            btn_net_test.PerformClick();
            Application.DoEvents();
            btn_machine_test.PerformClick();
            Application.DoEvents();
            btn_pdisk_test.PerformClick();
            Application.DoEvents();
            btn_prinrinvoice_test.PerformClick();
            Application.DoEvents();
            //btn_net_solve.PerformClick();
            //btn_pdisk_solve.PerformClick();
            //btn_printinvoice_solve.PerformClick();
            //btn_machine_solve.PerformClick();
            //btn_machine_solve.PerformClick();

            //res_label.Text += "回傳P曹LOG至資料庫...\n";
            //pass_log_to_12();
            //res_label.Text += "完成\n";

        }

        private void pass_log_to_12()
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(URL + "func=pass_log");
            req.Method = "GET";
            req.ContentType = "application/x-www-form-urlencoded";

            req.Timeout = 5000;

            string result = "";

            using (HttpWebResponse res = (HttpWebResponse)req.GetResponse())
            {
                using (StreamReader sr = new StreamReader(res.GetResponseStream()))
                {
                    result = sr.ReadToEnd();
                }
            }

            if (result.Substring(0, result.LastIndexOf(".")).Equals(VERSION.Substring(0, result.LastIndexOf("."))))
            {
                //MessageBox.Show("目前版本 : " + VERSION);
            }
            else
            {
                MessageBox.Show("建議至 'eROS >> 元件下載' 更新版本 : " + result);
                //Environment.Exit(ExitCode);
            }

        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            res_label.Text = "";
        }

        private void btn_test_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("test");
            //String res = "";
            //String Username = "";
            //(UserName,"FMO",,,);
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach(DriveInfo drive in drives)
            {
                res_label.Text += drive.Name +" " +drive.DriveType + "\n";
            }
            //res_label.Text += "  " + res + "\n";
            res_label.Text += "================================\n";
            
        }

        private void btn_repair_Click(object sender, EventArgs e)
        {
            res_label.Text += "----------> 開始修復 <----------\n";
            //if(run_solution[0] == 1)
            btn_net_solve.PerformClick();
            Application.DoEvents();
            //if (run_solution[1] == 1)
            btn_machine_solve.PerformClick();
            Application.DoEvents();
            //if (run_solution[2] == 1)
            //res_label.Text += "暫停5秒\n";
            //Application.DoEvents();
            Thread.Sleep(5000);
            //res_label.Text += "繼續\n";
            //Application.DoEvents();
            btn_pdisk_solve.PerformClick();
            Application.DoEvents();
            //if (run_solution[3] == 1)
            
            btn_printinvoice_solve.PerformClick();
            Application.DoEvents();
            MessageBox.Show("若修復後仍有問題，請聯繫維修窗口\n左側有聯絡電話");
            //res_label.Text += "修復'發票機'須相關權限，不納入一鍵處理\n";
            //res_label.Text += "自行點擊修復\n";
        }

        private void btn_testify_click(object sender, EventArgs e)
        {
            PrintServer ps = new PrintServer();
            PrintQueueCollection pqs = ps.GetPrintQueues() ;
            PrintQueue pq = ps.GetPrintQueue("WP-T810 Ver.4.00");
            res_label.Text += pqPause(pq);
            res_label.Text += pqResume(pq);
            /*
            foreach (PrintQueue pq in pqs)
            {
                res_label.Text += pq.Name + "\n";
            }
            */
            MessageBox.Show("Test End");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
