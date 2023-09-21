using Moq;
using NUnit.Framework;

namespace PublishSubscribeTests.SubscriberApp;

public class Publish : Spec
{
    [Test]
    public void Subscriber_is_notified_and_updates_when_publisher_notifies_subscribers()
    {
        var publisher = MockMe.APublisher();
        var subscriber = MockMe.ASubscriber();
        publisher.AddSubscriber(subscriber);

        publisher.NotifySubscribers("Notify");

        Mock.Get(subscriber).Verify(s => s.Update("Notify"), Times.Once());
    }
}
