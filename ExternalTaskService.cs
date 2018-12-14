using System;
using Refit;

namespace Camunda
{
    public class ExternalTaskService
    {

        protected IRequestExecutor restService = RestService.For<IRequestExecutor>("http://localhost:8080/engine-rest/external-task");

        public void complete(ExternalTask task) {
            CompleteExternalTask payload = new CompleteExternalTask() {
                workerId = "bar"
            };

            restService.Complete(task.Id, payload);
        }

    }
}