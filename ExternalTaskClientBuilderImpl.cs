using System.Threading;

namespace Camunda
{
    class ExternalTaskClientBuilderImpl : ExternalTaskClientBuilder
    {
        

        protected TopicSubscriptionManager topicSubscriptionManager;
        protected string endpointUrl;

        public ExternalTaskClientBuilder endpoint(string url)
        {
            endpointUrl = url;

            return this;
        }

        public ExternalTaskClient build() {
            topicSubscriptionManager = new TopicSubscriptionManager();
            ThreadStart threadDelegate = new ThreadStart(topicSubscriptionManager.acquire);
            Thread newThread = new Thread(threadDelegate);
            newThread.Start();

            return new ExternalTaskClientImpl(topicSubscriptionManager);
        }

    }
}