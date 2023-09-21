namespace Application;

public interface IPublisher
{
    List<ISubscriber> Subscribers { get; }

    void AddSubscriber(ISubscriber subscriber);
    void RemoveSubscriber(ISubscriber subscriber);
    void NotifySubscribers(string result);
}