namespace Application;

public class Subscriber : ISubscriber
{
    public void Subscribe(IPublisher publisher) =>
        publisher.AddSubscriber(this);

    public void Unsubscribe(IPublisher publisher) =>
        publisher.RemoveSubscriber(this);

    public void Update(string result) =>
        Console.WriteLine($"Received {result} from Publisher");
}