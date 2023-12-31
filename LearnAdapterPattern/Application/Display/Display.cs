﻿using Application.Device;
using Application.MultiMediaCable;
using Application.MultiMediaPort;

namespace Application.Display;

public abstract class Display : IDisplay
{
    protected virtual IMultimediaPort MultimediaPort { get; private set; }
    IMultimediaPort IDisplay.MultimediaPort => MultimediaPort;

    public Display(IMultimediaPort multimediaPort)
    {
        MultimediaPort = multimediaPort;
    }

    public virtual bool TryConnect(IDevice device, IMultimediaCable multimediaCable) =>
        MultimediaPort.TryConnect(multimediaCable) && device.TryAddConnection(this, multimediaCable);
    public virtual void UpdateDisplay(string update) { }

    bool IDisplay.TryConnect(IDevice device, IMultimediaCable multimediaCable) =>
        TryConnect(device, multimediaCable);
    void IDisplay.UpdateDisplay(string update) =>
        UpdateDisplay(update);
}
