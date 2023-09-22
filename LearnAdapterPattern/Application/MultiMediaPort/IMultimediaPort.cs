using Application.MultiMediaCable;

namespace Application.MultiMediaPort;

public interface IMultimediaPort
{
    bool TryConnect(IMultimediaCable multimediaCable);
}
