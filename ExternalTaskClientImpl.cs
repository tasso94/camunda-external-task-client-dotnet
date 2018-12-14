namespace Camunda
{
    class ExternalTaskClientImpl : ExternalTaskClient
    {

        TopicSubscriptionManager topicSubscriptionManager;

        public ExternalTaskClientImpl(TopicSubscriptionManager topicSubscriptionManager) {
            this.topicSubscriptionManager = topicSubscriptionManager;
        }

        public override TopicSubscriptionBuilder subscribe(string topicName)
        {
            return new TopicSubscriptionBuilderImpl(topicName, topicSubscriptionManager);
        }

    }
}
