using Application;
using Moq;

namespace PublishSubscribeTests;

public static class SpecExtensions
{
    #region PublisherApp

    public static Publisher APublisher(this Spec.Stubber _) =>
    new();

    public static ISubscriber ASubscriber(this Spec.Mocker _)
    {
        var result = new Mock<ISubscriber>();

        return result.Object;
    }

    #endregion

    #region SubscriberApp

    public static Subscriber ASubscriber(this Spec.Stubber _) =>
    new();

    public static IPublisher APublisher(this Spec.Mocker _)
    {
        var result = new Mock<IPublisher>();

        result.Setup(p => p.Subscribers).Returns(new List<ISubscriber>());

        result.Setup(p => p.AddSubscriber(It.IsAny<ISubscriber>())).Callback((ISubscriber subscriber) =>
        {
            result.Object.Subscribers.Add(subscriber);
        });

        result.Setup(p => p.RemoveSubscriber(It.IsAny<ISubscriber>())).Callback((ISubscriber subscriber) =>
        {
            result.Object.Subscribers.Remove(subscriber);
        });

        result.Setup(p => p.NotifySubscribers(It.IsAny<string>())).Callback((string notifyResult) =>
        {
            foreach (var subscriber in result.Object.Subscribers)
            {
                subscriber.Update(notifyResult);
            }
        });

        return result.Object;
    }

    #endregion
}
