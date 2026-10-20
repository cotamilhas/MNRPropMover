using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNRPropMover.Types
{
    internal class MNRProp
    {
        const int SIZE = 0xE0;

        public uint Address => _pointer;

        public MNRProp? PreviousProp
        {
            get
            {
                var pProp = _process.ReadPointer32(RPCS3Constants.RPCS3_EMU_BASE_ADDRESS + _pointer);

                if (pProp == 0)
                    return null;

                var prop = new MNRProp(_process, pProp);

                if (prop.UID == 0x014682D0) // This prop UID crashes the game if its selected, not sure what it is?
                    return prop.PreviousProp;

                return prop;
            }
        }
        public MNRProp? NextProp
        {
            get
            {
                var pProp = _process.ReadPointer32(RPCS3Constants.RPCS3_EMU_BASE_ADDRESS + _pointer + 0x04);

                if (pProp == 0)
                    return null;

                var prop = new MNRProp(_process, pProp);

                if (prop.UID == 0x014682D0) // This prop UID crashes the game if its selected, not sure what it is?
                    return prop.NextProp;

                return prop;
            }
        }

        public int UID
        {
            get { return _process.ReadInt32(RPCS3Constants.RPCS3_EMU_BASE_ADDRESS + _pointer + 0x14); }
        }

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
        private uint _pointer;

        public MNRProp(EmulatorProcess process, uint pointer)
        {
            _process = process;
            _pointer = pointer;
        }

        public byte[] ToBuffer() => _process.ReadBytes(RPCS3Constants.RPCS3_EMU_BASE_ADDRESS + _pointer, SIZE);
    }
}
