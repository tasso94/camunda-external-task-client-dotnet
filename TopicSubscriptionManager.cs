using System.Collections.Generic;
using Refit;
using System.Threading.Tasks;

namespace Camunda
{
    class TopicSubscriptionManager
    {
        public Dictionary<string, IHandler> handlers = new Dictionary<string, IHandler>();
        protected IRequestExecutor restService = RestService.For<IRequestExecutor>("http://localhost:8080/engine-rest/external-task");

        protected ExternalTaskService externalTaskService = new ExternalTaskService();

        protected FetchAndLockRequestDto payload = new FetchAndLockRequestDto() {
            maxTasks = 500,
            workerId = "bar",
            topics = new List<TopicRequestDto>()
        };

        public void acquire() {

            while (true) {

                var topics = payload.topics;

                topics.Clear();

                foreach(KeyValuePair<string, IHandler> entry in handlers)
                {
                    var topic = new TopicRequestDto() {
                        topicName = entry.Key,
                        lockDuration = 20_000
                    };
                    
                    topics.Add(topic);
                }

                var tasks = restService.FetchAndLock(payload);

                foreach (var task in tasks.Result)
                {
                    IHandler handler;
                    if (handlers.TryGetValue(task.TopicName, out handler)) {
                        handler.execute(task, externalTaskService);
                    }
                }

            }
            
        }


    }
}