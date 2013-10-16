#define hardware

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Timers;
using System.IO.Ports;

public partial class PumpController : System.ComponentModel.Component
{
    Timer delayMaker = new Timer();
    SerialPort _serialPort;
    public string PortName
    {
        get { return _serialPort.PortName; }
        set
        {
            _serialPort.PortName = value;

        }
    }
    int portNumber;

    public int PortNumber
    {
        get { return portNumber; }
        set { portNumber = value; }
    }

    public PumpController(int portNumber, string serialPort)
    {
        //InitializeComponent();
        _serialPort = new SerialPort();
        _serialPort.PortName = serialPort;
        _serialPort.BaudRate = 9600;
        this.portNumber = portNumber;
    }


    public PumpController(IContainer container)
    {
        container.Add(this);

        //InitializeComponent();
    }
    public void start(int duration, byte speed)
    {
        doPump(speed);
        try
        {
            delayMaker.Interval = duration;
            delayMaker.Enabled = true;
            delayMaker.Start();
            try
            {
                delayMaker.Elapsed -= timer1_Tick;
            }
            catch
            {
            }
            delayMaker.Elapsed += timer1_Tick;
        }
        catch (Exception exc)
        {
            //System.Windows.Forms.MessageBox.Show(exc.Message);
        }

    }

    void doPump(object speed)
    {
        byte pumpingSpeed = (byte)speed;
        byte[] startB = new byte[3];
        startB.SetValue((byte)255, 0);
        startB.SetValue((byte)portNumber, 1);
        startB.SetValue(pumpingSpeed, 2);
#if hardware
        if (!_serialPort.IsOpen) _serialPort.Open();
        _serialPort.Write(startB, 0, 3);
        _serialPort.Close();
#endif
    }
    void stopPump()
    {
        byte[] endB = new byte[3];
        endB.SetValue((byte)255, 0);
        endB.SetValue((byte)portNumber, 1);
        endB.SetValue((byte)0, 2);
#if hardware
        if (!_serialPort.IsOpen) _serialPort.Open();
        _serialPort.Write(endB, 0, 3);
        _serialPort.Close();
#endif
    }

    public void stop()
    {
        stopPump();
    }
    public void start(byte speed)
    {
        doPump(speed);
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
        delayMaker.Stop();
        delayMaker.Enabled = false;
        Console.WriteLine(string.Format("Delay with {0} duration finished! Stopping pump#{1}", delayMaker.Interval, portNumber));
        stopPump();
        Console.WriteLine(string.Format("pump#{0} stopped", portNumber));
    }

    public void shoot(byte value, int sleep)
    {
        _serialPort.Open();
        start(value);

        System.Threading.Thread.Sleep(sleep);
        stop();
        _serialPort.Close();
        //System.Threading.Thread.Sleep(2000);
    }

}