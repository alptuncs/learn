namespace Application.MultiMediaCable;

public class HDMIUSBCAdapter : IHDMICable, IUSBCCable
{
    public IHDMICable Out { get; private set; }
    public IUSBCCable In { get; private set; }

    public HDMIUSBCAdapter(IHDMICable _) { }
}