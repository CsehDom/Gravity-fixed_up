using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO;
using System.Threading;

namespace Gravitáció
{
    public static class PlanetHandler
    {
        public static Thread OpenOnNewThread()
        {
            Thread t = new Thread(Open);
            t.Start();
            return t;
        }

        static Dictionary<string, Action<argsObj>> actions = new Dictionary<string, Action<argsObj>>
        {
            {"list", (args) =>
            {
                try
                {
                    Bolygó.EnterListLockRead();
                    foreach(Bolygó b in Bolygó.lista) Console.WriteLine(b.ToString());
                }
                finally
                {
                    Bolygó.ExitListLockRead();
                }
            }
            },
            {"help", (args) =>
            {
                foreach(var kp in actions) Console.WriteLine(kp.Key);
            } }
        };

        public static void Open()
        {
            try
            {
                openConsole();
                argsObj args = new argsObj();
                string command;
                while ((command = Console.ReadLine()) != "exit")
                {
                    args.clArgs = command.Split(' ');
                    if (actions.ContainsKey(args.clArgs[0])) actions[args.clArgs[0]](args);
                    else Console.WriteLine("This command does not exist. Use help to list commands");
                }
            }
            finally
            {
                closeConsole();
            }
        }
        public class argsObj
        {
            public string[] clArgs;
        }
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern bool FreeConsole();

        [DllImport("Kernel32")]
        private static extern bool SetConsoleCtrlHandler(SetConsoleCtrlEventHandler handler, bool add);
        private delegate bool SetConsoleCtrlEventHandler(CtrlType sig);

        private enum CtrlType
        {
            CTRL_C_EVENT = 0,
            CTRL_BREAK_EVENT = 1,
            CTRL_CLOSE_EVENT = 2,
            CTRL_LOGOFF_EVENT = 5,
            CTRL_SHUTDOWN_EVENT = 6
        }

        [DllImport("kernel32.dll",
            EntryPoint = "CreateFileW",
            SetLastError = true,
            CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr CreateFileW(
              string lpFileName,
              UInt32 dwDesiredAccess,
              UInt32 dwShareMode,
              IntPtr lpSecurityAttributes,
              UInt32 dwCreationDisposition,
              UInt32 dwFlagsAndAttributes,
              IntPtr hTemplateFile
            );
        private static void openConsole()
        {
            AllocConsole();
            SetConsoleCtrlHandler(handleConsoleClose, true);
            FileStream fs = new FileStream(new Microsoft.Win32.SafeHandles.SafeFileHandle(CreateFileW("CONOUT$", 0x40000000, 0x00000002, IntPtr.Zero, 0x00000003, 0x80, IntPtr.Zero), true), FileAccess.Write);
            StreamWriter sstrW = new StreamWriter(fs);
            sstrW.AutoFlush = true;
            Console.SetOut(sstrW);
            fs = new FileStream(new Microsoft.Win32.SafeHandles.SafeFileHandle(CreateFileW("CONIN$", 0x80000000, 0x00000002, IntPtr.Zero, 0x00000003, 0x80, IntPtr.Zero), true), FileAccess.Read);
            StreamReader sstrR = new StreamReader(fs);
            Console.SetIn(sstrR);
        }

        public static void closeConsole()
        {
            Console.In.Dispose();
            Console.Out.Dispose();
            Console.Error.Dispose();
            FreeConsole();
        }

        private static bool handleConsoleClose(CtrlType sig)
        {
            if (sig == CtrlType.CTRL_BREAK_EVENT || sig == CtrlType.CTRL_CLOSE_EVENT || sig == CtrlType.CTRL_C_EVENT || sig == CtrlType.CTRL_LOGOFF_EVENT || sig == CtrlType.CTRL_SHUTDOWN_EVENT)
                FreeConsole();
            return true;
        }
    }
}