using System;
using System.IO;
using System.Management;
using System.Windows.Forms;

namespace SysInfo {
    class Program {
        [STAThread]
        static void Main(string[] args) {
            string uuid = null; 
            string query = "SELECT * FROM Win32_ComputerSystemProduct";

            ManagementObjectSearcher moSearch = new ManagementObjectSearcher(query);
            ManagementObjectCollection moCollection = moSearch.Get();

            foreach (ManagementObject mo in moCollection) {
                uuid = mo["UUID"].ToString();
                Console.Title = "UUID to Clipboard";
                Console.WriteLine();
                Console.WriteLine("UUID added to clipboard");
                Console.WriteLine(uuid);
                Clipboard.SetText(uuid);
                //Console.ReadKey();
            }
        }
    }
}