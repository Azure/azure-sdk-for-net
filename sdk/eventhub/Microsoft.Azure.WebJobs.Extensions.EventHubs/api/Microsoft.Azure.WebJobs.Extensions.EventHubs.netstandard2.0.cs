namespace Microsoft.Azure.WebJobs
{
    [Microsoft.Azure.WebJobs.Description.BindingAttribute]
    [System.AttributeUsageAttribute(System.AttributeTargets.Parameter | System.AttributeTargets.ReturnValue)]
    public sealed partial class EventHubAttribute : System.Attribute
    {
        public EventHubAttribute(string eventHubName) { }
        [Microsoft.Azure.WebJobs.Description.AutoResolveAttribute]
        public string Connection { get { throw null; } set { } }
        public string EventHubName { get { throw null; } }
    }
    [Microsoft.Azure.WebJobs.Description.BindingAttribute]
    [System.AttributeUsageAttribute(System.AttributeTargets.Parameter)]
    public sealed partial class EventHubTriggerAttribute : System.Attribute
    {
        public EventHubTriggerAttribute(string eventHubName) { }
        [Microsoft.Azure.WebJobs.Description.AutoResolveAttribute]
        public string Connection { get { throw null; } set { } }
        [Microsoft.Azure.WebJobs.Description.AutoResolveAttribute]
        public string ConsumerGroup { get { throw null; } set { } }
        public string EventHubName { get { throw null; } }
    }
}
namespace Microsoft.Azure.WebJobs.EventHubs
{
    public partial class EventHubOptions : Microsoft.Azure.WebJobs.Hosting.IOptionsFormatter
    {
        public const string LeaseContainerName = "azure-webjobs-eventhub";
        public EventHubOptions() { }
        public int BatchCheckpointFrequency { get { throw null; } set { } }
        public Azure.Messaging.EventHubs.Primitives.EventProcessorOptions EventProcessorOptions { get { throw null; } }
        public Microsoft.Azure.WebJobs.EventHubs.InitialOffsetOptions InitialOffsetOptions { get { throw null; } }
        public bool InvokeProcessorAfterReceiveTimeout { get { throw null; } set { } }
        public int MaxBatchSize { get { throw null; } set { } }
        public void AddReceiver(string eventHubName, string receiverConnectionString) { }
        public void AddReceiver(string eventHubName, string receiverConnectionString, string storageConnectionString) { }
        public void AddSender(string eventHubName, string sendConnectionString) { }
        public string Format() { throw null; }
        public static string GetBlobPrefix(string eventHubName, string serviceBusNamespace) { throw null; }
    }
    public partial class EventHubsWebJobsStartup : Microsoft.Azure.WebJobs.Hosting.IWebJobsStartup
    {
        public EventHubsWebJobsStartup() { }
        public void Configure(Microsoft.Azure.WebJobs.IWebJobsBuilder builder) { }
    }
    public partial class InitialOffsetOptions
    {
        public InitialOffsetOptions() { }
        public string EnqueuedTimeUTC { get { throw null; } set { } }
        public string Type { get { throw null; } set { } }
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
