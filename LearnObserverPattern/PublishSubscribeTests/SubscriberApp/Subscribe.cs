using Moq;
using NUnit.Framework;

namespace PublishSubscribeTests.SubscriberApp;

public class Subscribe : Spec
{
    [Test]
    public void Subcriber_can_subscribe_to_a_publisher()
    {
        var publisher = MockMe.APublisher();
        var subscriber = GiveMe.ASubscriber();

        subscriber.Subscribe(publisher);

        Mock.Get(publisher).Verify(p => p.AddSubscriber(subscriber), Times.Once());
    }

    [Test]
    public void Subcriber_can_unsubscribe_from_a_publisher()
    {
        var publisher = MockMe.APublisher();
        var subscriber = GiveMe.ASubscriber();

        subscriber.Unsubscribe(publisher);

        Mock.Get(publisher).Verify(p => p.RemoveSubscriber(subscriber), Times.Once());
    }
}
