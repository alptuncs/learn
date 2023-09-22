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

    public static IMultimediaPort AMultimediaPort(this Spec.Mocker mockMe, IMultimediaCable? compatibleCable = default)
    {
        var result = new Mock<IMultimediaPort>();

        result.Setup(p => p.CompatibleCable).Returns(compatibleCable ?? mockMe.AMultiMediaCable());

        result.Setup(p => p.TryConnect(It.Is<IMultimediaCable>(c => c.GetType().IsAssignableTo(result.Object.CompatibleCable.GetType()))))
            .Returns(true);

        return result.Object;
    }

    public static IMultimediaCable AMultiMediaCable(this Spec.Mocker _)
    {
        var result = new Mock<IMultimediaCable>();

        return result.Object;
    }
}
