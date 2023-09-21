using NUnit.Framework;
using Shouldly;

namespace PublishSubscribeTests.PublisherApp;

public class Subscribe : Spec
{
    [Test]
    public void Subcriber_can_subscribe_to_a_publisher()
    {
        var publisher = GiveMe.APublisher();
        var subscriber = MockMe.ASubscriber();

        publisher.AddSubscriber(subscriber);

        publisher.Subscribers.ShouldContain(subscriber);
    }

    [Test]
    public void Subcriber_can_unsubscribe_from_a_publisher()
    {
        var publisher = GiveMe.APublisher();
        var subscriber = MockMe.ASubscriber();
        subscriber.Subscribe(publisher);

        publisher.RemoveSubscriber(subscriber);

        publisher.Subscribers.ShouldNotContain(subscriber);
    }
}
