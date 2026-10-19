using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MNRPropMover.Types
{
    internal class Win32
    {
#if _WINDOWS
        public static readonly int PROCESS_VM_OPERATION = 0x0008;
        public static readonly int PROCESS_VM_READ = 0x0010;
        public static readonly int PROCESS_VM_WRITE = 0x0020;

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(nint hProcess, ulong lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

        [DllImport("kernel32.dll")]
        public static extern bool WriteProcessMemory(nint hProcess, ulong lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesWritten);

        public static readonly int VK_LEFT = 0x25;
        public static readonly int VK_UP = 0x26;
        public static readonly int VK_RIGHT = 0x27;
        public static readonly int VK_DOWN = 0x28;

        [DllImport("User32.dll")]
        public static extern short GetAsyncKeyState(int vKey);
#endif
    }
}
