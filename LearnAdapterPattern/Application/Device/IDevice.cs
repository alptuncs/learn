using Application.Display;
using Application.MultiMediaCable;
using Application.MultiMediaPort;

namespace Application.Device;

public interface IDevice
{
    IMultimediaPort MultimediaPort { get; }
    List<IDisplay> ConnectedDisplays { get; }
    bool TryAddConnection(IDisplay display, IMultimediaCable multimediaCable);
    void SendInformation(string information);
}
