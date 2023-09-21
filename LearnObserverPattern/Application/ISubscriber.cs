namespace Application;

public interface ISubscriber
{
    void Subscribe(IPublisher publisher);
    void Unsubscribe(IPublisher publisher);
    void Update(string result);
}
