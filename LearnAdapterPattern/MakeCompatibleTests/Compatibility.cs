using Application.Device;
using Application.Display;
using Application.MultiMediaCable;
using Application.MultiMediaPort;
using NUnit.Framework;
using Shouldly;

namespace AdapterTests;

public class Compatibility : Spec
{
    #region Display & Device

    public class XDevice : Device
    {
        public XDevice(IMultimediaPort multimediaPort)
            : base(multimediaPort) { }
    }

    public class XDisplay : Display
    {
        public XDisplay(IMultimediaPort multimediaPort)
            : base(multimediaPort) { }
    }

    public class XCable : IMultimediaCable { }

    [Test]
    public void Display_can_connect_to_device_using_compatible_cable()
    {
        var compatibleCable = new XCable();
        var device = new XDevice(MockMe.AMultimediaPort(compatibleCable));
        var display = new XDisplay(MockMe.AMultimediaPort(compatibleCable));

        display.TryConnect(device, compatibleCable).ShouldBeTrue();
    }

    #endregion


    #region TV Implementation

    [Test]
    public void TV_can_connect_to_device_using_compatible_cable()
    {
        var compatibleCable = GiveMe.AnHDMICable();
        var tv = GiveMe.ATV();
        var device = new XDevice(MockMe.AMultimediaPort(compatibleCable));

        tv.TryConnect(device, compatibleCable).ShouldBeTrue();
    }

    #endregion

    #region Laptop Implementation

    [Test]
    public void Display_can_connect_to_laptop_using_compatible_cable()
    {
        var compatibleCable = GiveMe.AUSBCCable();
        var display = new XDisplay(MockMe.AMultimediaPort(compatibleCable));
        var laptop = GiveMe.ALaptop();

        display.TryConnect(laptop, compatibleCable).ShouldBeTrue();
    }

    #endregion

    #region Adapter Implementation

    [Test]
    public void TV_can_connect_to_Laptop_using_adapter()
    {
        var tV = GiveMe.ATV();
        var laptop = GiveMe.ALaptop();
        var adapter = GiveMe.AnAdapter();

        tV.TryConnect(laptop, adapter).ShouldBeTrue();
    }

    #endregion
}
