using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Threading;

namespace D3_ThudLauncher
{
    internal class Launcher
    {
        // ReSharper disable once AssignNullToNotNullAttribute
        private static bool IsElevated => new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
        private static void Main(string[] args)
        {
            if(!IsElevated)throw new PrivilegeNotHeldException("You must run this as Admin");
            //Default path for my PC + allow anyone to cmd the sh!t out of these
            //Param 1 = THUD Path (including exe)
            //Param 2 = D3 Path (including exe)
            //Param 3 = User name to run Diablo
            //Param 4 = Password for the user that'll run Diablo
            var thudPath = args.Length > 0 ? args[0] : @"D:\THUD\THUD.exe";
            var d3Path = args.Length > 1 ? args[1] : @"D:\Program Files (x86)\Diablo III\Diablo III.exe";
            var spwD3 = new SecureString();
            var pw = args.Length > 3 ? args[3] : "diablo";
            foreach (var c in pw)
            {
                spwD3.AppendChar(c);
            }

            var workingDirectory = new FileInfo(d3Path).DirectoryName;
            if (workingDirectory != null)
            {
                var d3StartInfo = new ProcessStartInfo
                {
                    UserName = args.Length > 2 ? args[2] : "diablo",
                    Password = spwD3,
                    FileName = d3Path,
                    WorkingDirectory = workingDirectory,
                    UseShellExecute = false,
                    LoadUserProfile = true
                };

                //Make sure we won't try to launch something that does not exists
                if (!File.Exists(thudPath)) throw new FileNotFoundException(thudPath);
                if(!File.Exists(d3Path)) throw new FileNotFoundException(d3Path);

                //Starts Battle.Net
                var bnetHandle = StartBNet(d3StartInfo);
                //Starts Diablo 3 from Battle.Net (click at X,Y position on standard windows size)
                StartDiablo(bnetHandle);
            }
            //Stops Battle.Net from being an arse
            KillBNet();
            //Starts THUD
            StartThud(thudPath);
        }

        private static void StartThud(string thudPath)
        {
            //Give 5 second to start D3, even if it takes more like 10
            Thread.Sleep(5000);
            var workingDirectory = new FileInfo(thudPath).DirectoryName;
            if (workingDirectory == null) return;

            var thudStartInfo = new ProcessStartInfo
            {
                FileName = thudPath,
                WorkingDirectory = workingDirectory,
                UseShellExecute = false,
                LoadUserProfile = true,
                Verb = "runas"
            };
            Process.Start(thudStartInfo);
        }

        private static IntPtr StartBNet(ProcessStartInfo d3StartInfo)
        {
            Process.Start(d3StartInfo);
            return BringToFront("Blizzard Battle.net");
        }

        private static void StartDiablo(IntPtr handle)
        {
            //Makes sure D3 starts
            while (Process.GetProcessesByName("Diablo III64").Length < 1)
            {
                //Click Play at coords 290, 677 relatively to the Window's position
                ClickOnPointTool.ClickOnPoint(handle, new Point(290, 677));
                //Avoid overusing the CPU if we have to click alot
                Thread.Sleep(4000);
            }
        }

        private static void KillBNet()
        {
            //Get Battle.net process
            var bnetProcesses = Process.GetProcessesByName("Blizzard Battle.net");
            if (bnetProcesses.Length <= 0) return;
            var bnetProcess = bnetProcesses[0];
            //Kill it
            bnetProcess.Kill();
        }

        public static IntPtr BringToFront(string title)
        {
            // Get a handle to the Calculator application.
            var handle = FindWindow(null, title);

            //Wait until the app starts and can be shown
            while (handle == IntPtr.Zero)
            {
                //Sleeps one sec to not over-charge the CPU
                Thread.Sleep(1000);
                //Reset the handle
                handle = FindWindow(null, title);
            }
            

            // Make Calculator the foreground application
            SetForegroundWindow(handle);
            return handle;
        }

        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
    }
}
