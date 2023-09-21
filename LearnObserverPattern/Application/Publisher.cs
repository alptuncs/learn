namespace Application;

public class Publisher : IPublisher
{
    private readonly List<ISubscriber> _subscribers;
    public List<ISubscriber> Subscribers => _subscribers;

    public void AddSubscriber(ISubscriber subscriber) =>
        _subscribers.Add(subscriber);

    public void RemoveSubscriber(ISubscriber subscriber) =>
        _subscribers.Remove(subscriber);

    public void NotifySubscribers(string result)
    {
        foreach (var subscriber in _subscribers)
        {
            subscriber.Update(result);
        }
    }

    public Publisher()
    {
        _subscribers = new List<ISubscriber>();
    }

    public void DoBusiness()
    {
        NotifySubscribers("Notify subscribers");
    }
}
