using Application.Display;
using Application.MultiMediaCable;
using Application.MultiMediaPort;

namespace Application.Device;

public abstract class Device : IDevice
{
    protected virtual IMultimediaPort MultimediaPort { get; private set; }
    protected virtual List<IDisplay> ConnectedDisplays { get; private set; }

    IMultimediaPort IDevice.MultimediaPort => MultimediaPort;
    List<IDisplay> IDevice.ConnectedDisplays => ConnectedDisplays;

    public Device(IMultimediaPort multimediaPort)
    {
        MultimediaPort = multimediaPort;
        ConnectedDisplays = new();
    }

    public virtual bool TryAddConnection(IDisplay display, IMultimediaCable multimediaCable)
    {
        if (!MultimediaPort.TryConnect(multimediaCable)) { return false; }

        ConnectedDisplays.Add(display);

        SendInformation("Current screen information");

        return true;
    }

    public virtual void SendInformation(string information)
    {
        foreach (var display in ConnectedDisplays)
        {
            display.UpdateDisplay(information);
        }
    }

    bool IDevice.TryAddConnection(IDisplay display, IMultimediaCable multimediaCable) =>
        TryAddConnection(display, multimediaCable);
    void IDevice.SendInformation(string information) =>
        SendInformation(information);
}