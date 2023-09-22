using Application.Display;
using Application.MultiMediaCable;
using Application.MultiMediaPort;

namespace Application.Device;

public class Laptop : Device
{
    public Laptop(IMultimediaPort multimediaPort)
        : base(multimediaPort) { }
}
