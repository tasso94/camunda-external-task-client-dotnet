namespace Camunda
{
    abstract class ExternalTaskClient
    {
        static public ExternalTaskClientBuilder create()
        {
            return new ExternalTaskClientBuilderImpl();
        }

        abstract public TopicSubscriptionBuilder subscribe(string topicName);

    }
}
