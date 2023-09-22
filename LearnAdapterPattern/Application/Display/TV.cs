using Application.MultiMediaPort;

namespace Application.Display;

public class TV : Display
{
    public TV()
        : base(new HDMI()) { }
}
