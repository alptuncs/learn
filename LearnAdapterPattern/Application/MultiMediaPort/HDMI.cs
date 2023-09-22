using Application.MultiMediaCable;

namespace Application.MultiMediaPort;

public class HDMI : IMultimediaPort
{
    public bool TryConnect(IMultimediaCable multimediaCable) =>
        multimediaCable.GetType().IsAssignableTo(typeof(IHDMICable));
}
