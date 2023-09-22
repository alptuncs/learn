using Application.Device;
using Application.Display;
using Application.MultiMediaPort;
using NUnit.Framework;
using Shouldly;

namespace AdapterTests;

public class Compatibility : Spec
{
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

    [Test]
    public void TV_can_connect_to_Laptop_using_adapter()
    {
        var tV = GiveMe.ATV();
        var laptop = GiveMe.ALaptop();
        var adapter = GiveMe.AnAdapter();

        tV.TryConnect(laptop, adapter).ShouldBeTrue();
    }
}
