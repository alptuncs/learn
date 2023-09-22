using Application.Device;
using Application.Display;
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

    [Test]
    public void Display_can_not_connect_to_device_using_incompatible_cable()
    {
        var compatibleCable = MockMe.AMultimediaCable();
        var device = new XDevice(MockMe.AMultimediaPort(compatibleCable: compatibleCable));
        var display = new XDisplay(MockMe.AMultimediaPort());
        var cable = MockMe.AMultiMediaCable();

        display.TryConnect(device, cable).ShouldBeFalse();
    }

    #endregion


    #region TV Implementation

    [Test]
    public void TV_can_connect_to_device_using_compatible_cable()
    {
        var tv = GiveMe.ATV();
        var device = MockMe.ADevice();
        var cable = MockMe.AMultimediaCable();

        tv.TryConnect(device, cable).ShouldBeTrue();
    }

    #endregion

    #region Laptop Implementation

    [Test]
    public void Display_can_connect_to_laptop_using_compatible_cable()
    {
        var display = MockMe.ADisplay();
        var laptop = GiveMe.ALaptop();
        var cable = MockMe.AMultimediaCable();

        display.TryConnect(laptop, cable).ShouldBeTrue();
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
