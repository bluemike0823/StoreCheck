using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Text;
//add Reference
using System.Management;
using System.Diagnostics;
using System.Drawing.Printing;
//<FrameworkReference Include="Microsoft.WindowsDesktop.App.WPF" />
//using System.Printing;
//using System.ServiceProcess;
using System.IO.Ports;
using System.Threading;
using System.Security.Principal;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Data.SqlClient;
using System.Net;
using System.IO;

namespace StoreCheck
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        /// 
        //LogonUser(帳號, 網域, 密碼, 登入類別, 登入提供者, out UserToken)

        public static string temp = "";
        public static string URL = "http://192.168.1.12/fmo/jsp/api/apiwinform.jsp?";
        public static string _version = "1.1.0.817";
        [STAThread]
        static void Main()
        {

            //chk_version();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 myform = new Form1();
            Application.Run(myform);

            /*
            if(new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator)){

                //Application.EnableVisualStyles();
                //Application.SetCompatibleTextRenderingDefault(false);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Form1 myform = new Form1();
                Application.Run(myform);

            }
            else
            {
                var processInfo = new ProcessStartInfo
                {
                    UseShellExecute = true,
                    FileName = Application.ExecutablePath,
                    Verb = "runas"
                };

                try
                {
                    Process.Start(processInfo);
                }catch(Exception ex)
                {
                    MessageBox.Show("須以系統管理員身分啟動");
                }

            }
            */
            
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Form1 myform = new Form1();
            //Application.Run(myform);
            //bool ping = myPing("192.168.1.15");
            //myPrinter();
            //myPrintInvoice();
            //Console.ReadLine();  
            //Environment.Exit(1);
        }
    }
}


    

