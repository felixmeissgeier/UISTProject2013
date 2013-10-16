using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PrintSpark
{
    int[,] Resolution;
    int TotalPumps;
    int DistanceBetweenPumps;
    //DraftPixel Draft;
    bool[,] _printData;
    int _lastVerticalLine;
    StepperController _stepperController;
    PumpController _p0;
    PumpController _p1;
    PumpController _p2;
    PumpController _p3;
    PumpController _p4;
    PumpController _p5;
    string _serialPortPumpSpark;
    string _serialPortStepperController;
    List<PumpController> pumpCollection;

    public PrintSpark(int[,] Resolution, int TotalPumps, int DistanceBetweenPumps, bool[,] printData, int lastVerticalLine, string serialPortPumpSpark, string serialPortStepperController)
    {
        this.Resolution = Resolution;
        this.DistanceBetweenPumps = DistanceBetweenPumps;
        this.TotalPumps = TotalPumps;
        this._printData = printData;
        this._lastVerticalLine = lastVerticalLine;
        _serialPortPumpSpark = serialPortPumpSpark;
        _serialPortStepperController = serialPortStepperController;
            
        Initialize();
    }

    void Initialize()
    {
        _stepperController = new StepperController(_serialPortStepperController);
        _p0 = new PumpController(0, _serialPortPumpSpark);
        _p1 = new PumpController(1, _serialPortPumpSpark);
        _p2 = new PumpController(2, _serialPortPumpSpark);
        _p3 = new PumpController(3, _serialPortPumpSpark);
        _p4 = new PumpController(4, _serialPortPumpSpark);
        _p5 = new PumpController(5, _serialPortPumpSpark);
        pumpCollection = new List<PumpController>();
        pumpCollection.Add(_p0);
        pumpCollection.Add(_p1);
        pumpCollection.Add(_p2);
        pumpCollection.Add(_p3);
        pumpCollection.Add(_p4);
        pumpCollection.Add(_p5);
        _stepperController.initialize();
    }

    public void printOnLandscape()
    {
        int stateP0 = 0;
        int stateP1 = stateP0 + DistanceBetweenPumps + 1;
        int stateP2 = stateP1 + DistanceBetweenPumps + 1;
        int stateP3 = stateP2 + DistanceBetweenPumps + 1;
        int stateP4 = stateP3 + DistanceBetweenPumps + 1;
        int stateP5 = stateP4 + DistanceBetweenPumps + 1;
            
        for (int y = 0; y < _lastVerticalLine+1; y++){
            for (int x = 0; x < DistanceBetweenPumps+1; x++)
            {
                if(_printData[stateP0 + x,y]==true){
                    Console.WriteLine("PrintSpark _p0...");
                    _p5.shoot(140, 100);
                }
                if(_printData[stateP1 + x,y]==true){
                    Console.WriteLine("PrintSpark _p1...");
                    _p4.shoot(140, 100);
                }
                if (_printData[stateP2 + x, y] == true)
                {
                    Console.WriteLine("PrintSpark _p2...");
                    _p3.shoot(140, 100);
                }
                if (_printData[stateP3 + x, y] == true)
                {
                    Console.WriteLine("PrintSpark _p3...");
                    _p2.shoot(140, 100);
                }
                if (_printData[stateP4 + x, y] == true)
                {
                    Console.WriteLine("PrintSpark _p4...");
                    _p1.shoot(140, 100);
                }
                if (_printData[stateP5 + x, y] == true)
                {
                    Console.WriteLine("PrintSpark _p5...");
                    _p0.shoot(140, 100);
                }
                System.Threading.Thread.Sleep(800);
                _stepperController.moveHorizontalStep(1);
            }
            _stepperController.moveHorizontalStep(-DistanceBetweenPumps-1);
            _stepperController.moveVerticalStep(1);
        }
        _stepperController.returnToInitialPosition();
        _stepperController.close();
    }
}
