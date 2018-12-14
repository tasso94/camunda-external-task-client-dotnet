using System.Collections.Generic;

namespace Camunda
{
    public class TopicRequestDto
    {
        public string topicName;

        public long lockDuration;

        public override string ToString() => topicName;
    }
}