using System.Collections.Generic;

namespace Camunda
{
    public class FetchAndLockRequestDto
    {
        public int maxTasks;

        public string workerId;

        public List<TopicRequestDto> topics;

    }
}