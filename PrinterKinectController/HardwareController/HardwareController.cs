using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Samples.Kinect.ControlsBasics
{
    class HardwareController
    {
        string _serialPortPumpSpark;
        string _serialPortStepperController;
        bool _initialized = false;
        int _numOfPumps;
        int _pixelsEachPump;

        public HardwareController(int numOfPumps, int pixelsEachPump, string serialPortPumpSpark, string serialPortStepperControl)
        {
            _serialPortPumpSpark = serialPortPumpSpark;
            _serialPortStepperController = serialPortStepperControl;
            _numOfPumps = numOfPumps;
            _pixelsEachPump = pixelsEachPump;
               
        }

        public void initialize(bool skipStepperCalibration = false)
        {
            if (skipStepperCalibration == false)
            {
                StepperController stepperController = new StepperController(_serialPortStepperController); 
                stepperController.initialize();
                stepperController.close();
            }
            _initialized = true;
        }

        public void print(bool[,] printArray, int lastVerticalLine)
        {
            int horizontal = printArray.GetLength(0);
            int vertical = printArray.GetLength(1);

            PrintSpark printSpark = new PrintSpark(new int[horizontal, vertical], _numOfPumps, _pixelsEachPump-1, printArray, lastVerticalLine, _serialPortPumpSpark, _serialPortStepperController);
            printSpark.printOnLandscape();
        }

        private void initializePumps(byte value, int sleep)
        {
            PumpController p0 = new PumpController(0, _serialPortPumpSpark);
            PumpController p1 = new PumpController(1, _serialPortPumpSpark);
            PumpController p2 = new PumpController(2, _serialPortPumpSpark);
            PumpController p3 = new PumpController(3, _serialPortPumpSpark);
            PumpController p4 = new PumpController(4, _serialPortPumpSpark);
            PumpController p5 = new PumpController(5, _serialPortPumpSpark);

            List<PumpController> pumpControllerList = new List<PumpController>();
            pumpControllerList.Add(p0);
            pumpControllerList.Add(p1);
            pumpControllerList.Add(p2);
            pumpControllerList.Add(p3);
            pumpControllerList.Add(p4);
            pumpControllerList.Add(p5);

            foreach (PumpController p in pumpControllerList)
            {
                for (int i = 0; i < 3; i++)
                {
                    p.shoot(value, sleep);
                }
            }
        }

        public void stepBackShirtCarrier()
        {
            StepperController stepperController = new StepperController(_serialPortStepperController); 
            stepperController.moveVerticalStep(-20);
            stepperController.close();
        }
        
        public void goToInitialPositionShirtCarrier()
        {
            StepperController stepperController = new StepperController(_serialPortStepperController); 
            stepperController.moveVerticalStep(8);
            stepperController.close();
        }
        public void stepBackNozzleCarrier()
        {
            StepperController stepperController = new StepperController(_serialPortStepperController); 
            stepperController.moveHorizontalStep(-2);
            stepperController.close();
        }

        public void goToInitialPositionNozzleCarrier()
        {
            StepperController stepperController = new StepperController(_serialPortStepperController); 
            stepperController.moveHorizontalStep(3);
            stepperController.close();
        }

    }
}
