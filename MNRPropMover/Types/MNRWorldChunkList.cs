using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MNRPropMover.Types
{
    internal class MNRWorldChunkList
    {
        const int SIZE = 0x24;

        public int Count
        {
            get { return _process.ReadInt32(RPCS3Constants.RPCS3_EMU_BASE_ADDRESS + RPCS3Constants.WORLD_CHUNKS_ADDRESS + 0x20); }
        }

        private EmulatorProcess _process;

        public MNRWorldChunkList(EmulatorProcess process)
        {
            _process = process;
        }

        public byte[] ToBuffer() => _process.ReadBytes(RPCS3Constants.RPCS3_EMU_BASE_ADDRESS + RPCS3Constants.WORLD_CHUNKS_ADDRESS, SIZE);
    }
}
