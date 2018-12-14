namespace Camunda
{
    interface TopicSubscriptionBuilder
    {
        TopicSubscriptionBuilder handler(IHandler handler);

        TopicSubscription open();

    }
}
