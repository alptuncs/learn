using Application.Device;
using Application.Display;
using Application.MultiMediaCable;
using Application.MultiMediaPort;

namespace Application;

internal class Program
{
    static void Main(string[] args)
    {
        var laptop = new Laptop();
        var display = new TV();

        Console.WriteLine("With HDMI cable");
        var hDMICable = new HDMICable();
        display.TryConnect(laptop, hDMICable);

        Console.WriteLine("----");

        Console.WriteLine("With USB-C cable");
        var displayPortCable = new USBCCable();
        display.TryConnect(laptop, displayPortCable);

        Console.WriteLine("----");

        Console.WriteLine("With HDMI USB-C Adapter");
        var adapterCable = new HDMIUSBCAdapter(hDMICable);
        display.TryConnect(laptop, adapterCable);
    }
}
