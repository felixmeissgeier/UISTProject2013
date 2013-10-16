using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class StepperController
{
    SerialPort _serialPort;
    byte _nozzleStepperID = 0;
    byte _shirtStepperID = 1;
    int _verticalPosition;
    int _horizontalPosition;
    int _stepsVerticalLine = -8;
    int _stepHorizontalLine = 8;
    bool _isInitialized = false;

    public StepperController(string serialPort)
    {
        //InitializeComponent();
        _serialPort = new SerialPort();
        _serialPort.PortName = serialPort;
        _serialPort.BaudRate = 9600;
        _serialPort.Close();
        _serialPort.Open();
    }

    public void close(){
        _serialPort.Close();
    }

    public void initialize()
    {
        _isInitialized = true;
            
        //moveShirtStepper(-90);

        /*
        moveNozzleStepper(30);
            */
        _horizontalPosition = 0;
        _verticalPosition = 0;
    }

    public bool isInitialized(){
        return _isInitialized;
    }

    //moving left=negative; right=positive
    public void moveNozzleStepper(int value)
    {
        if (_serialPort.IsOpen)
        {
            byte sign = 0;
            if (value < 0)
            {
                sign = 1;
            }
            byte[] sendBuffer = { _nozzleStepperID, sign, (byte) Math.Abs(value)};
            _serialPort.Write(sendBuffer, 0, 3);
            System.Threading.Thread.Sleep((int)(50 * Math.Abs(value)));
        }
    }

    //moving forward/print direction=negative; backwards=positive
    public void moveShirtStepper(int value)
    {
        if (_serialPort.IsOpen)
        {
            byte sign = 0;
            if (value < 0)
            {
                sign = 1;
            }
            byte[] sendBuffer = { _shirtStepperID, sign, (byte)Math.Abs(value) };
            _serialPort.Write(sendBuffer, 0, 3);
            System.Threading.Thread.Sleep((int)(50 * Math.Abs(value)));
        }
    }

    public void moveToVerticalLine(int i)
    {
        int linesToMove = i - _verticalPosition;
        _verticalPosition += linesToMove;
        int moveValue = linesToMove * _stepsVerticalLine;
        moveShirtStepper(moveValue);
    }

    public void moveToHorizontalLine(int j)
    {
        int linesToMove = j - _horizontalPosition;
        _horizontalPosition += linesToMove;
        int moveValue = linesToMove * _stepHorizontalLine;
        moveNozzleStepper(moveValue);
    }

    public void moveHorizontalStep(int value)
    {
        moveNozzleStepper(value * _stepHorizontalLine);
        _horizontalPosition += value;
    }

    public void moveVerticalStep(int value)
    {
        moveShirtStepper(value * _stepsVerticalLine);
        _verticalPosition += value;
    }

    public void returnToInitialPosition()
    {
            moveNozzleStepper(-_horizontalPosition * _stepHorizontalLine);
            _horizontalPosition = 0;
            moveShirtStepper(-_verticalPosition * _stepsVerticalLine);
            _verticalPosition = 0;
                
    }
}

