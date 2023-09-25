using Application.Device;
using Application.Display;
using Application.MultiMediaCable;
using Application.MultiMediaPort;
using Moq;

namespace AdapterTests;

public static class SpecExtensions
{
    public static IMultimediaCable AMultimediaCable(this Spec.Mocker _)
    {
        var result = new Mock<IMultimediaCable>();

        return result.Object;
    }

    public static IMultimediaPort AMultimediaPort(this Spec.Mocker mockMe, IMultimediaCable compatibleCable)
    {
        var result = new Mock<IMultimediaPort>();

        result.Setup(p => p.TryConnect(It.Is<IMultimediaCable>(c => c.GetType().IsAssignableTo(compatibleCable.GetType()))))
            .Returns(true);

        return result.Object;
    }

    public static IMultimediaCable AMultiMediaCable(this Spec.Mocker _)
    {
        var result = new Mock<IMultimediaCable>();

        return result.Object;
    }

    public static TV ATV(this Spec.Stubber _) => new();
    public static HDMICable AnHDMICable(this Spec.Stubber _) => new();

    public static Laptop ALaptop(this Spec.Stubber _) => new();
    public static USBCCable AUSBCCable(this Spec.Stubber _) => new();

    public static HDMIUSBCAdapter AnAdapter(this Spec.Stubber giveMe) => new(giveMe.AnHDMICable());
}
