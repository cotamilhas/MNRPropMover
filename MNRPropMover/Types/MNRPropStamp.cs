using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNRPropMover.Types
{
    internal class MNRPropStamp
    {
        public MNRProp? CurrentProp
        {
            get
            {
                var pCurrentProp = _process.ReadPointer32(RPCS3Constants.RPCS3_EMU_BASE_ADDRESS + RPCS3Constants.PROP_STAMP_ADDRESS);

                if (pCurrentProp == 0)
                    return null;

                return new MNRProp(_process, pCurrentProp);
            }
            set
            { 
                _process.WritePointer32(RPCS3Constants.RPCS3_EMU_BASE_ADDRESS + RPCS3Constants.PROP_STAMP_ADDRESS, value == null ? 0 : value.Address);
            }
        }

        private EmulatorProcess _process;

        public MNRPropStamp(EmulatorProcess process)
        {
            _process = process;
        }
    }
}
