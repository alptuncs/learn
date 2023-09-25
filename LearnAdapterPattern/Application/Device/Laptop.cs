using Application.MultiMediaPort;

namespace Application.Device;

public class Laptop : Device
{
    public Laptop()
        : base(new USBC()) { }
}
