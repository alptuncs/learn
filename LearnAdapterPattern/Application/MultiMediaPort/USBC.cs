using Application.MultiMediaCable;

namespace Application.MultiMediaPort;

public class USBC : IMultimediaPort
{
    public bool TryConnect(IMultimediaCable multimediaCable) =>
        multimediaCable.GetType().IsAssignableTo(typeof(IUSBCCable));
}
