using MNRPropMover.Types;

namespace MNRPropMover
{
    internal class Program
    {
        private static EmulatorProcess _process;
        private static MNRPropStamp _propStamp;
        private static PropController _propController;

        static void Main(string[] args)
        {
            _process = new EmulatorProcess("rpcs3");
            if (!_process.Attach())
            {
                Console.WriteLine("Unable to attach to rpcs3.exe!");
                return;
            }

            _propStamp = new MNRPropStamp(_process);
            _propController = new PropController();

            while (true)
            {
                Console.Clear();

                var windowTitle = _process.WindowTitle;
                var deltaTime = 0.3333f;

                if (windowTitle.StartsWith("FPS: "))
                    deltaTime = 1f / float.Parse(windowTitle.Substring(5, windowTitle.IndexOf(" | ") - 5));

                Update(deltaTime);

                Thread.Sleep((int)(deltaTime * 1000f));
            }
        }

        static void Update(float deltaTime)
        {
            var currentProp = _propStamp.CurrentProp;

            if (currentProp != null)
            {
                if (currentProp.Address != _propController.Prop?.Address)
                    _propController.SetProp(currentProp);

                _propController.Update(deltaTime);

                Console.Write($"Current Prop Information:\n\n" +
                               $"Address: 0x{currentProp.Address:x}\n" +
                               $"Position: X={currentProp.PositionX}, Y={currentProp.PositionY}, Z={currentProp.PositionZ}\n" +
                               $"Rotation: X={currentProp.RotationX}, Y={currentProp.RotationY}, Z={currentProp.RotationZ}\n" +
                               $"Scale: {currentProp.Scale}");
            }
            else
                Console.Write("No prop is currently selected.");
        }
    }
}
