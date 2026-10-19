using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNRPropMover.Types
{
    internal enum PropControllerState
    {
        None = 0,

        TiltForward = 1,
        TiltBackward = 2,
        TiltLeft = 4,
        TiltRight = 8,

        TiltForwardBackward = TiltForward | TiltBackward,
        TiltLeftRight = TiltLeft | TiltRight
    }
}
