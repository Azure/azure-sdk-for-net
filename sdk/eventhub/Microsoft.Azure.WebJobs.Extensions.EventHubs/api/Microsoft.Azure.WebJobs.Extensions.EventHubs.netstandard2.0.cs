namespace Microsoft.Azure.WebJobs
{
    [Microsoft.Azure.WebJobs.Description.BindingAttribute]
    [System.AttributeUsageAttribute(System.AttributeTargets.Parameter | System.AttributeTargets.ReturnValue)]
    public sealed partial class EventHubAttribute : System.Attribute
    {
        public EventHubAttribute(string eventHubName) { }
        public string Connection { get { throw null; } set { } }
        public string EventHubName { get { throw null; } }
    }
    [Microsoft.Azure.WebJobs.Description.BindingAttribute]
    [System.AttributeUsageAttribute(System.AttributeTargets.Parameter)]
    public sealed partial class EventHubTriggerAttribute : System.Attribute
    {
        public EventHubTriggerAttribute(string eventHubName) { }
        public string Connection { get { throw null; } set { } }
        public string ConsumerGroup { get { throw null; } set { } }
        public string EventHubName { get { throw null; } }
    }
}
namespace Microsoft.Azure.WebJobs.EventHubs
{
    public partial class EventHubOptions : Microsoft.Azure.WebJobs.Hosting.IOptionsFormatter
    {
        public EventHubOptions() { }
        public int BatchCheckpointFrequency { get { throw null; } set { } }
        public Azure.Messaging.EventHubs.EventHubsRetryOptions ClientRetryOptions { get { throw null; } set { } }
        public Azure.Messaging.EventHubs.EventHubConnectionOptions ConnectionOptions { get { throw null; } set { } }
        public Microsoft.Azure.WebJobs.EventHubs.InitialOffsetOptions InitialOffsetOptions { get { throw null; } }
        public System.TimeSpan LoadBalancingUpdateInterval { get { throw null; } set { } }
        public int MaxBatchSize { get { throw null; } set { } }
        public System.TimeSpan PartitionOwnershipExpirationInterval { get { throw null; } set { } }
        public int PrefetchCount { get { throw null; } set { } }
        public long? PrefetchSizeInBytes { get { throw null; } set { } }
        public bool TrackLastEnqueuedEventProperties { get { throw null; } set { } }
        string Microsoft.Azure.WebJobs.Hosting.IOptionsFormatter.Format() { throw null; }
    }
    public partial class InitialOffsetOptions
    {
        public InitialOffsetOptions() { }
        public System.DateTimeOffset? EnqueuedTimeUtc { get { throw null; } set { } }
        public Microsoft.Azure.WebJobs.EventHubs.OffsetType? Type { get { throw null; } set { } }
    }
    public enum OffsetType
    {
        FromStart = 0,
        FromEnd = 1,
        FromEnqueuedTime = 2,
    }
}
namespace Microsoft.Extensions.Hosting
{
    public static partial class EventHubWebJobsBuilderExtensions
    {
        public static Microsoft.Azure.WebJobs.IWebJobsBuilder AddEventHubs(this Microsoft.Azure.WebJobs.IWebJobsBuilder builder) { throw null; }
        public static Microsoft.Azure.WebJobs.IWebJobsBuilder AddEventHubs(this Microsoft.Azure.WebJobs.IWebJobsBuilder builder, System.Action<Microsoft.Azure.WebJobs.EventHubs.EventHubOptions> configure) { throw null; }
    }
}
