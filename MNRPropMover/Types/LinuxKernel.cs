using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNRPropMover.Types
{
    internal class LinuxKernel
    {
#if _LINUX
        [StructLayout(LayoutKind.Sequential)]
        struct iovec
        {
          public nint iov_base;
          public int iov_len;
        }

        [DllImport("libc")]
        public static extern unsafe int process_vm_readv(int pid,
            iovec local_iov,
            ulong liovcnt,
            iovec remote_iov,
            ulong riovcnt,
            ulong flags);
            
        [DllImport("libc")]
        private static extern unsafe int process_vm_readv(int pid,
            iovec local_iov,
            ulong liovcnt,
            iovec remote_iov,
            ulong riovcnt,
            ulong flags);
#endif
    }
}
