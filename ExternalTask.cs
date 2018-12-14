using System;

namespace Camunda
{
    public class ExternalTask
    {
        public string ActivityId;

        public string ActivityInstanceId;

        public string ErrorMessage;

        public string ExecutionId;

        public string Id;

        public DateTime? LockExpirationTime;

        public string ProcessDefinitionId;

        public string ProcessDefinitionKey;

        public string ProcessInstanceId;

        public int? Retries;

        public bool Suspended;

        public string WorkerId;

        public string TopicName;

        public string TenantId;

        public long Priority;

        public override string ToString() => Id;
    }
}