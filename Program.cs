using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace RWMemory
{
    class Program
    {
        static void Main(string[] args)
        {
            string ProcessName = "BlackDesert64";
            var ex = 0x10f4f4;
            int blapblap = 0;
            Process proc = Process.GetProcessesByName(ProcessName)[0];
            var hProc = ghapi.OpenProcess(ghapi.ProcessAccessFlags.All, false, proc.Id);
            var read1 = ghapi.GetModuleBaseAddress(proc, $"{ProcessName}.exe");
            var read2 = ghapi.GetModuleBaseAddress(proc.Id, $"{ProcessName}.exe");
            var blap = ghapi.FindDMAAddy(hProc, (IntPtr)(read2 + ex), new int[] { 0x374, 0x14, 0 });
            Console.WriteLine("Last Error: " + Marshal.GetLastWin32Error());
            Console.WriteLine("Something address " + "0x" + blap.ToString("X"));
            ghapi.WriteProcessMemory(hProc, blap, blapblap, 4, out _);
            Console.ReadKey();
        }
    }
}