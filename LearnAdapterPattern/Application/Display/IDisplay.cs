using Application.Device;
using Application.MultiMediaCable;
using Application.MultiMediaPort;

namespace Application.Display;

public interface IDisplay
{
    IMultimediaPort MultimediaPort { get; }

    bool TryConnect(IDevice device, IMultimediaCable multimediaCable);
    void UpdateDisplay(string update);
}
