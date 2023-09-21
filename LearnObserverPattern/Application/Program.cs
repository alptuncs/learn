namespace Application;

internal class Program
{
    static void Main(string[] args)
    {
        var publisher = new Publisher();
        var subscriber = new Subscriber();

        subscriber.Subscribe(publisher);

        publisher.NotifySubscribers("Test Notification");
    }
}
