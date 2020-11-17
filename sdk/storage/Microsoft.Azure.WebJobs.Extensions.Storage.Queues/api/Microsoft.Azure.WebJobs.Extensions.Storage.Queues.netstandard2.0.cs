namespace Microsoft.Azure.WebJobs
{
    [Microsoft.Azure.WebJobs.ConnectionProviderAttribute(typeof(Microsoft.Azure.WebJobs.StorageAccountAttribute))]
    [Microsoft.Azure.WebJobs.Description.BindingAttribute]
    [System.AttributeUsageAttribute(System.AttributeTargets.Parameter | System.AttributeTargets.ReturnValue)]
    [System.Diagnostics.DebuggerDisplayAttribute("{QueueName,nq}")]
    public partial class QueueAttribute : System.Attribute, Microsoft.Azure.WebJobs.IConnectionProvider
    {
        public QueueAttribute(string queueName) { }
        public string Connection { get { throw null; } set { } }
        [Microsoft.Azure.WebJobs.Description.AutoResolveAttribute]
        public string QueueName { get { throw null; } }
    }
    [Microsoft.Azure.WebJobs.ConnectionProviderAttribute(typeof(Microsoft.Azure.WebJobs.StorageAccountAttribute))]
    [Microsoft.Azure.WebJobs.Description.BindingAttribute]
    [System.AttributeUsageAttribute(System.AttributeTargets.Parameter)]
    [System.Diagnostics.DebuggerDisplayAttribute("{QueueName,nq}")]
    public sealed partial class QueueTriggerAttribute : System.Attribute, Microsoft.Azure.WebJobs.IConnectionProvider
    {
        public QueueTriggerAttribute(string queueName) { }
        public string Connection { get { throw null; } set { } }
        public string QueueName { get { throw null; } }
    }
}
namespace Microsoft.Azure.WebJobs.Extensions.Storage
{
    public partial class AzureStorageQueuesWebJobsStartup : Microsoft.Azure.WebJobs.Hosting.IWebJobsStartup
    {
        public AzureStorageQueuesWebJobsStartup() { }
        public void Configure(Microsoft.Azure.WebJobs.IWebJobsBuilder builder) { }
    }
}
namespace Microsoft.Azure.WebJobs.Host
{
    public partial class QueuesOptions : Microsoft.Azure.WebJobs.Hosting.IOptionsFormatter
    {
        public QueuesOptions() { }
        public int BatchSize { get { throw null; } set { } }
        public int MaxDequeueCount { get { throw null; } set { } }
        public System.TimeSpan MaxPollingInterval { get { throw null; } set { } }
        public Azure.Storage.Queues.QueueMessageEncoding MessageEncoding { get { throw null; } set { } }
        public int NewBatchThreshold { get { throw null; } set { } }
        public System.TimeSpan VisibilityTimeout { get { throw null; } set { } }
        public string Format() { throw null; }
    }
}
namespace Microsoft.Azure.WebJobs.Host.Queues
{
    public partial interface IQueueProcessorFactory
    {
        Microsoft.Azure.WebJobs.Host.Queues.QueueProcessor Create(Microsoft.Azure.WebJobs.Host.Queues.QueueProcessorOptions queueProcessorOptions);
    }
    public partial class PoisonMessageEventArgs : System.EventArgs
    {
        public PoisonMessageEventArgs(Azure.Storage.Queues.Models.QueueMessage message, Azure.Storage.Queues.QueueClient poisonQueue) { }
        public Azure.Storage.Queues.Models.QueueMessage Message { get { throw null; } }
        public Azure.Storage.Queues.QueueClient PoisonQueue { get { throw null; } }
    }
    public partial class QueueProcessor
    {
        protected internal QueueProcessor(Microsoft.Azure.WebJobs.Host.Queues.QueueProcessorOptions queueProcessorOptions) { }
        public event System.EventHandler<Microsoft.Azure.WebJobs.Host.Queues.PoisonMessageEventArgs> MessageAddedToPoisonQueue { add { } remove { } }
        protected internal virtual System.Threading.Tasks.Task<bool> BeginProcessingMessageAsync(Azure.Storage.Queues.Models.QueueMessage message, System.Threading.CancellationToken cancellationToken) { throw null; }
        protected internal virtual System.Threading.Tasks.Task CompleteProcessingMessageAsync(Azure.Storage.Queues.Models.QueueMessage message, Microsoft.Azure.WebJobs.Host.Executors.FunctionResult result, System.Threading.CancellationToken cancellationToken) { throw null; }
        protected virtual System.Threading.Tasks.Task CopyMessageToPoisonQueueAsync(Azure.Storage.Queues.Models.QueueMessage message, Azure.Storage.Queues.QueueClient poisonQueue, System.Threading.CancellationToken cancellationToken) { throw null; }
        protected virtual System.Threading.Tasks.Task DeleteMessageAsync(Azure.Storage.Queues.Models.QueueMessage message, System.Threading.CancellationToken cancellationToken) { throw null; }
        protected internal virtual void OnMessageAddedToPoisonQueue(Microsoft.Azure.WebJobs.Host.Queues.PoisonMessageEventArgs e) { }
        protected virtual System.Threading.Tasks.Task ReleaseMessageAsync(Azure.Storage.Queues.Models.QueueMessage message, Microsoft.Azure.WebJobs.Host.Executors.FunctionResult result, System.TimeSpan visibilityTimeout, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class QueueProcessorOptions
    {
        internal QueueProcessorOptions() { }
        public Microsoft.Extensions.Logging.ILogger Logger { get { throw null; } }
        public Microsoft.Azure.WebJobs.Host.QueuesOptions Options { get { throw null; } }
        public Azure.Storage.Queues.QueueClient PoisonQueue { get { throw null; } }
        public Azure.Storage.Queues.QueueClient Queue { get { throw null; } }
    }
}
namespace Microsoft.Extensions.Hosting
{
    public static partial class StorageQueuesWebJobsBuilderExtensions
    {
        public static Microsoft.Azure.WebJobs.IWebJobsBuilder AddAzureStorageQueues(this Microsoft.Azure.WebJobs.IWebJobsBuilder builder, System.Action<Microsoft.Azure.WebJobs.Host.QueuesOptions> configureQueues = null) { throw null; }
    }
}
