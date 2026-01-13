namespace Microsoft.Azure.WebJobs
{
    [System.AttributeUsageAttribute(System.AttributeTargets.Class | System.AttributeTargets.Method | System.AttributeTargets.Parameter)]
    public sealed partial class ServiceBusAccountAttribute : System.Attribute, Microsoft.Azure.WebJobs.IConnectionProvider
    {
        public ServiceBusAccountAttribute(string account) { }
        public string Account { get { throw null; } }
        string Microsoft.Azure.WebJobs.IConnectionProvider.Connection { get { throw null; } set { } }
    }
    [Microsoft.Azure.WebJobs.ConnectionProviderAttribute(typeof(Microsoft.Azure.WebJobs.ServiceBusAccountAttribute))]
    [Microsoft.Azure.WebJobs.Description.BindingAttribute]
    [System.AttributeUsageAttribute(System.AttributeTargets.Parameter | System.AttributeTargets.ReturnValue)]
    [System.Diagnostics.DebuggerDisplayAttribute("{QueueOrTopicName,nq}")]
    public sealed partial class ServiceBusAttribute : System.Attribute, Microsoft.Azure.WebJobs.IConnectionProvider
    {
        public ServiceBusAttribute(string queueOrTopicName, Microsoft.Azure.WebJobs.ServiceBus.ServiceBusEntityType entityType = Microsoft.Azure.WebJobs.ServiceBus.ServiceBusEntityType.Queue) { }
        public string Connection { get { throw null; } set { } }
        public Microsoft.Azure.WebJobs.ServiceBus.ServiceBusEntityType EntityType { get { throw null; } set { } }
        public string QueueOrTopicName { get { throw null; } }
    }
    [Microsoft.Azure.WebJobs.ConnectionProviderAttribute(typeof(Microsoft.Azure.WebJobs.ServiceBusAccountAttribute))]
    [Microsoft.Azure.WebJobs.Description.BindingAttribute]
    [System.AttributeUsageAttribute(System.AttributeTargets.Parameter)]
    [System.Diagnostics.DebuggerDisplayAttribute("{DebuggerDisplay,nq}")]
    public sealed partial class ServiceBusTriggerAttribute : System.Attribute, Microsoft.Azure.WebJobs.IConnectionProvider
    {
        public ServiceBusTriggerAttribute(string queueName) { }
        public ServiceBusTriggerAttribute(string topicName, string subscriptionName) { }
        public bool AutoCompleteMessages { get { throw null; } set { } }
        public string Connection { get { throw null; } set { } }
        public bool IsSessionsEnabled { get { throw null; } set { } }
        public int MaxMessageBatchSize { get { throw null; } set { } }
        public string QueueName { get { throw null; } }
        public string SubscriptionName { get { throw null; } }
        public string TopicName { get { throw null; } }
    }
}
namespace Microsoft.Azure.WebJobs.ServiceBus
{
    public partial class MessageProcessor
    {
        protected internal MessageProcessor(Azure.Messaging.ServiceBus.ServiceBusProcessor processor) { }
        protected internal Azure.Messaging.ServiceBus.ServiceBusProcessor Processor { get { throw null; } }
        protected internal virtual System.Threading.Tasks.Task<bool> BeginProcessingMessageAsync(Microsoft.Azure.WebJobs.ServiceBus.ServiceBusMessageActions actions, Azure.Messaging.ServiceBus.ServiceBusReceivedMessage message, System.Threading.CancellationToken cancellationToken) { throw null; }
        protected internal virtual System.Threading.Tasks.Task CompleteProcessingMessageAsync(Microsoft.Azure.WebJobs.ServiceBus.ServiceBusMessageActions actions, Azure.Messaging.ServiceBus.ServiceBusReceivedMessage message, Microsoft.Azure.WebJobs.Host.Executors.FunctionResult result, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class MessagingProvider
    {
        public MessagingProvider(Microsoft.Extensions.Options.IOptions<Microsoft.Azure.WebJobs.ServiceBus.ServiceBusOptions> options) { }
        protected internal virtual Azure.Messaging.ServiceBus.ServiceBusReceiver CreateBatchMessageReceiver(Azure.Messaging.ServiceBus.ServiceBusClient client, string entityPath, Azure.Messaging.ServiceBus.ServiceBusReceiverOptions options) { throw null; }
        protected internal virtual Azure.Messaging.ServiceBus.ServiceBusClient CreateClient(string fullyQualifiedNamespace, Azure.Core.TokenCredential credential, Azure.Messaging.ServiceBus.ServiceBusClientOptions options) { throw null; }
        protected internal virtual Azure.Messaging.ServiceBus.ServiceBusClient CreateClient(string connectionString, Azure.Messaging.ServiceBus.ServiceBusClientOptions options) { throw null; }
        protected internal virtual Microsoft.Azure.WebJobs.ServiceBus.MessageProcessor CreateMessageProcessor(Azure.Messaging.ServiceBus.ServiceBusClient client, string entityPath, Azure.Messaging.ServiceBus.ServiceBusProcessorOptions options) { throw null; }
        protected internal virtual Azure.Messaging.ServiceBus.ServiceBusSender CreateMessageSender(Azure.Messaging.ServiceBus.ServiceBusClient client, string entityPath) { throw null; }
        protected internal virtual Azure.Messaging.ServiceBus.ServiceBusProcessor CreateProcessor(Azure.Messaging.ServiceBus.ServiceBusClient client, string entityPath, Azure.Messaging.ServiceBus.ServiceBusProcessorOptions options) { throw null; }
        protected internal virtual Microsoft.Azure.WebJobs.ServiceBus.SessionMessageProcessor CreateSessionMessageProcessor(Azure.Messaging.ServiceBus.ServiceBusClient client, string entityPath, Azure.Messaging.ServiceBus.ServiceBusSessionProcessorOptions options) { throw null; }
        protected internal virtual Azure.Messaging.ServiceBus.ServiceBusSessionProcessor CreateSessionProcessor(Azure.Messaging.ServiceBus.ServiceBusClient client, string entityPath, Azure.Messaging.ServiceBus.ServiceBusSessionProcessorOptions options) { throw null; }
    }
    public enum ServiceBusEntityType
    {
        Queue = 0,
        Topic = 1,
    }
    public partial class ServiceBusMessageActions
    {
        protected ServiceBusMessageActions() { }
        public virtual System.Threading.Tasks.Task AbandonMessageAsync(Azure.Messaging.ServiceBus.ServiceBusReceivedMessage message, System.Collections.Generic.IDictionary<string, object> propertiesToModify = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task CompleteMessageAsync(Azure.Messaging.ServiceBus.ServiceBusReceivedMessage message, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task DeadLetterMessageAsync(Azure.Messaging.ServiceBus.ServiceBusReceivedMessage message, System.Collections.Generic.Dictionary<string, object> propertiesToModify, string deadLetterReason, string deadLetterErrorDescription = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task DeadLetterMessageAsync(Azure.Messaging.ServiceBus.ServiceBusReceivedMessage message, System.Collections.Generic.IDictionary<string, object> propertiesToModify = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task DeadLetterMessageAsync(Azure.Messaging.ServiceBus.ServiceBusReceivedMessage message, string deadLetterReason, string deadLetterErrorDescription = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task DeferMessageAsync(Azure.Messaging.ServiceBus.ServiceBusReceivedMessage message, System.Collections.Generic.IDictionary<string, object> propertiesToModify = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task RenewMessageLockAsync(Azure.Messaging.ServiceBus.ServiceBusReceivedMessage message, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceBusOptions : Microsoft.Azure.WebJobs.Hosting.IOptionsFormatter
    {
        public ServiceBusOptions() { }
        public bool AutoCompleteMessages { get { throw null; } set { } }
        public Azure.Messaging.ServiceBus.ServiceBusRetryOptions ClientRetryOptions { get { throw null; } set { } }
        public bool EnableCrossEntityTransactions { get { throw null; } set { } }
        public Newtonsoft.Json.JsonSerializerSettings JsonSerializerSettings { get { throw null; } set { } }
        public System.TimeSpan MaxAutoLockRenewalDuration { get { throw null; } set { } }
        public System.TimeSpan MaxBatchWaitTime { get { throw null; } set { } }
        public int MaxConcurrentCalls { get { throw null; } set { } }
        public int MaxConcurrentCallsPerSession { get { throw null; } set { } }
        public int MaxConcurrentSessions { get { throw null; } set { } }
        public int MaxMessageBatchSize { get { throw null; } set { } }
        public int MinMessageBatchSize { get { throw null; } set { } }
        public int PrefetchCount { get { throw null; } set { } }
        public System.Func<Azure.Messaging.ServiceBus.ProcessErrorEventArgs, System.Threading.Tasks.Task> ProcessErrorAsync { get { throw null; } set { } }
        public System.Func<Azure.Messaging.ServiceBus.ProcessSessionEventArgs, System.Threading.Tasks.Task> SessionClosingAsync { get { throw null; } set { } }
        public System.TimeSpan? SessionIdleTimeout { get { throw null; } set { } }
        public System.Func<Azure.Messaging.ServiceBus.ProcessSessionEventArgs, System.Threading.Tasks.Task> SessionInitializingAsync { get { throw null; } set { } }
        public Azure.Messaging.ServiceBus.ServiceBusTransportType TransportType { get { throw null; } set { } }
        public System.Net.IWebProxy WebProxy { get { throw null; } set { } }
        string Microsoft.Azure.WebJobs.Hosting.IOptionsFormatter.Format() { throw null; }
    }
    public partial class ServiceBusReceiveActions
    {
        protected ServiceBusReceiveActions() { }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IReadOnlyList<Azure.Messaging.ServiceBus.ServiceBusReceivedMessage>> PeekMessagesAsync(int maxMessages, long? fromSequenceNumber = default(long?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IReadOnlyList<Azure.Messaging.ServiceBus.ServiceBusReceivedMessage>> ReceiveDeferredMessagesAsync(System.Collections.Generic.IEnumerable<long> sequenceNumbers, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IReadOnlyList<Azure.Messaging.ServiceBus.ServiceBusReceivedMessage>> ReceiveMessagesAsync(int maxMessages, System.TimeSpan? maxWaitTime = default(System.TimeSpan?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceBusSessionMessageActions : Microsoft.Azure.WebJobs.ServiceBus.ServiceBusMessageActions
    {
        protected ServiceBusSessionMessageActions() { }
        public virtual System.DateTimeOffset SessionLockedUntil { get { throw null; } }
        public virtual System.Threading.Tasks.Task<System.BinaryData> GetSessionStateAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual void ReleaseSession() { }
        public virtual System.Threading.Tasks.Task RenewSessionLockAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task SetSessionStateAsync(System.BinaryData sessionState, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SessionMessageProcessor
    {
        protected internal SessionMessageProcessor(Azure.Messaging.ServiceBus.ServiceBusSessionProcessor processor) { }
        protected internal Azure.Messaging.ServiceBus.ServiceBusSessionProcessor Processor { get { throw null; } }
        protected internal virtual System.Threading.Tasks.Task<bool> BeginProcessingMessageAsync(Microsoft.Azure.WebJobs.ServiceBus.ServiceBusSessionMessageActions actions, Azure.Messaging.ServiceBus.ServiceBusReceivedMessage message, System.Threading.CancellationToken cancellationToken) { throw null; }
        protected internal virtual System.Threading.Tasks.Task CompleteProcessingMessageAsync(Microsoft.Azure.WebJobs.ServiceBus.ServiceBusSessionMessageActions actions, Azure.Messaging.ServiceBus.ServiceBusReceivedMessage message, Microsoft.Azure.WebJobs.Host.Executors.FunctionResult result, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
}
namespace Microsoft.Extensions.Hosting
{
    public static partial class ServiceBusHostBuilderExtensions
    {
        public static Microsoft.Azure.WebJobs.IWebJobsBuilder AddServiceBus(this Microsoft.Azure.WebJobs.IWebJobsBuilder builder) { throw null; }
        public static Microsoft.Azure.WebJobs.IWebJobsBuilder AddServiceBus(this Microsoft.Azure.WebJobs.IWebJobsBuilder builder, System.Action<Microsoft.Azure.WebJobs.ServiceBus.ServiceBusOptions> configure) { throw null; }
    }
}
