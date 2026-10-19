using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNRPropMover.Types
{
    internal class MNRProp
    {
        public ulong Address => _pointer;

        public float PositionX
        {
            get { return _process.ReadFloat32(RPCS3Constants.RPCS3_EMU_BASE_ADDRESS + _pointer + 0x1C); }
            set { _process.WriteFloat32(RPCS3Constants.RPCS3_EMU_BASE_ADDRESS + _pointer + 0x1C, value); }
        }
        public float PositionY
        {
            get { return _process.ReadFloat32(RPCS3Constants.RPCS3_EMU_BASE_ADDRESS + _pointer + 0x20); }
            set { _process.WriteFloat32(RPCS3Constants.RPCS3_EMU_BASE_ADDRESS + _pointer + 0x20, value); }
        }
        public float PositionZ
        {
            get { return _process.ReadFloat32(RPCS3Constants.RPCS3_EMU_BASE_ADDRESS + _pointer + 0x24); }
            set { _process.WriteFloat32(RPCS3Constants.RPCS3_EMU_BASE_ADDRESS + _pointer + 0x24, value); }
        }

        public float RotationX
        {
            get { return _process.ReadFloat32(RPCS3Constants.RPCS3_EMU_BASE_ADDRESS + _pointer + 0x28); }
            set { _process.WriteFloat32(RPCS3Constants.RPCS3_EMU_BASE_ADDRESS + _pointer + 0x28, value); }
        }
        public float RotationY
        {
            get { return _process.ReadFloat32(RPCS3Constants.RPCS3_EMU_BASE_ADDRESS + _pointer + 0x2C); }
            set { _process.WriteFloat32(RPCS3Constants.RPCS3_EMU_BASE_ADDRESS + _pointer + 0x2C, value); }
        }
        public float RotationZ
        {
            get { return _process.ReadFloat32(RPCS3Constants.RPCS3_EMU_BASE_ADDRESS + _pointer + 0x30); }
            set { _process.WriteFloat32(RPCS3Constants.RPCS3_EMU_BASE_ADDRESS + _pointer + 0x30, value); }
        }

        public float Scale
        {
            get { return _process.ReadFloat32(RPCS3Constants.RPCS3_EMU_BASE_ADDRESS + _pointer + 0x64); }
            set { _process.WriteFloat32(RPCS3Constants.RPCS3_EMU_BASE_ADDRESS + _pointer + 0x64, value); }
        }

        private EmulatorProcess _process;
        private ulong _pointer;

        public MNRProp(EmulatorProcess process, ulong pointer)
        {
            _process = process;
            _pointer = pointer;
        }
    }
}
