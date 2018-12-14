namespace Camunda
{
    class TopicSubscriptionBuilderImpl : TopicSubscriptionBuilder
    {
        string topicName;
        IHandler customHandler;
        TopicSubscriptionManager topicSubscriptionManager;

        public TopicSubscriptionBuilderImpl(string topicName, TopicSubscriptionManager topicSubscriptionManager)
        {
            this.topicName = topicName;
            this.topicSubscriptionManager = topicSubscriptionManager;
        }
        
        public TopicSubscriptionBuilder handler(IHandler handler)
        {
            this.customHandler = handler;

            return this;
        }

        public TopicSubscription open()
        {
            topicSubscriptionManager.handlers.Add(topicName, customHandler);

            return new TopicSubscriptionImpl(topicName);
        }

    }
}
