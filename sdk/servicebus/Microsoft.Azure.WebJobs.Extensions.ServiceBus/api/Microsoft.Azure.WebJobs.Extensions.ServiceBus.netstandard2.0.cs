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
        public ServiceBusAttribute(string queueOrTopicName) { }
        public ServiceBusAttribute(string queueOrTopicName, Microsoft.Azure.WebJobs.ServiceBus.EntityType entityType) { }
        public string Connection { get { throw null; } set { } }
        public Microsoft.Azure.WebJobs.ServiceBus.EntityType EntityType { get { throw null; } set { } }
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
        public string Connection { get { throw null; } set { } }
        public bool IsSessionsEnabled { get { throw null; } set { } }
        public string QueueName { get { throw null; } }
        public string SubscriptionName { get { throw null; } }
        public string TopicName { get { throw null; } }
    }
}
namespace Microsoft.Azure.WebJobs.ServiceBus
{
    public static partial class Constants
    {
        public const string AzureWebsiteSku = "WEBSITE_SKU";
        public const string DefaultConnectionSettingStringName = "AzureWebJobsServiceBus";
        public const string DefaultConnectionStringName = "ServiceBus";
        public const string DynamicSku = "Dynamic";
        public static Newtonsoft.Json.JsonSerializerSettings JsonSerializerSettings { get { throw null; } }
    }
    public enum EntityType
    {
        Queue = 0,
        Topic = 1,
    }
    public partial class MessageProcessor
    {
        public MessageProcessor(Azure.Messaging.ServiceBus.ServiceBusProcessor processor) { }
        public virtual System.Threading.Tasks.Task<bool> BeginProcessingMessageAsync(Microsoft.Azure.WebJobs.ServiceBus.ServiceBusMessageActions messageActions, Azure.Messaging.ServiceBus.ServiceBusReceivedMessage message, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task CompleteProcessingMessageAsync(Microsoft.Azure.WebJobs.ServiceBus.ServiceBusMessageActions messageActions, Azure.Messaging.ServiceBus.ServiceBusReceivedMessage message, Microsoft.Azure.WebJobs.Host.Executors.FunctionResult result, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class MessagingProvider
    {
        public MessagingProvider(Microsoft.Extensions.Options.IOptions<Microsoft.Azure.WebJobs.ServiceBus.ServiceBusOptions> serviceBusOptions) { }
        public virtual Azure.Messaging.ServiceBus.ServiceBusReceiver CreateBatchMessageReceiver(string entityPath, string connectionString) { throw null; }
        public virtual Azure.Messaging.ServiceBus.ServiceBusClient CreateClient(string connectionString) { throw null; }
        public virtual Microsoft.Azure.WebJobs.ServiceBus.MessageProcessor CreateMessageProcessor(string entityPath, string connectionString) { throw null; }
        public virtual Azure.Messaging.ServiceBus.ServiceBusSender CreateMessageSender(string entityPath, string connectionString) { throw null; }
        public virtual Azure.Messaging.ServiceBus.ServiceBusProcessor CreateProcessor(string entityPath, string connectionString) { throw null; }
        public virtual Microsoft.Azure.WebJobs.ServiceBus.SessionMessageProcessor CreateSessionMessageProcessor(string entityPath, string connectionString) { throw null; }
    }
    public partial class ServiceBusMessageActions
    {
        internal ServiceBusMessageActions() { }
        public virtual System.Threading.Tasks.Task AbandonMessageAsync(Azure.Messaging.ServiceBus.ServiceBusReceivedMessage message, System.Collections.Generic.IDictionary<string, object> propertiesToModify = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task CompleteMessageAsync(Azure.Messaging.ServiceBus.ServiceBusReceivedMessage message, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task DeadLetterMessageAsync(Azure.Messaging.ServiceBus.ServiceBusReceivedMessage message, System.Collections.Generic.IDictionary<string, object> propertiesToModify = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task DeadLetterMessageAsync(Azure.Messaging.ServiceBus.ServiceBusReceivedMessage message, string deadLetterReason, string deadLetterErrorDescription = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task DeferMessageAsync(Azure.Messaging.ServiceBus.ServiceBusReceivedMessage message, System.Collections.Generic.IDictionary<string, object> propertiesToModify = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceBusOptions : Microsoft.Azure.WebJobs.Hosting.IOptionsFormatter
    {
        public ServiceBusOptions() { }
        public bool AutoCompleteMessages { get { throw null; } set { } }
        public string ConnectionString { get { throw null; } set { } }
        public System.Func<Azure.Messaging.ServiceBus.ProcessErrorEventArgs, System.Threading.Tasks.Task> ExceptionHandler { get { throw null; } set { } }
        public System.TimeSpan MaxAutoLockRenewalDuration { get { throw null; } set { } }
        public int MaxConcurrentCalls { get { throw null; } set { } }
        public int MaxConcurrentSessions { get { throw null; } set { } }
        public int MaxMessages { get { throw null; } set { } }
        public int PrefetchCount { get { throw null; } set { } }
        public Azure.Messaging.ServiceBus.ServiceBusRetryOptions RetryOptions { get { throw null; } set { } }
        public System.TimeSpan? SessionIdleTimeout { get { throw null; } set { } }
        public Azure.Messaging.ServiceBus.ServiceBusTransportType TransportType { get { throw null; } set { } }
        public System.Net.IWebProxy WebProxy { get { throw null; } set { } }
        public string Format() { throw null; }
    }
    public partial class ServiceBusSessionMessageActions : Microsoft.Azure.WebJobs.ServiceBus.ServiceBusMessageActions
    {
        internal ServiceBusSessionMessageActions() { }
        public virtual System.Threading.Tasks.Task<System.BinaryData> GetSessionStateAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task SetSessionStateAsync(System.BinaryData sessionState, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceBusWebJobsStartup : Microsoft.Azure.WebJobs.Hosting.IWebJobsStartup
    {
        public ServiceBusWebJobsStartup() { }
        public void Configure(Microsoft.Azure.WebJobs.IWebJobsBuilder builder) { }
    }
    public partial class SessionMessageProcessor
    {
        public SessionMessageProcessor(Azure.Messaging.ServiceBus.ServiceBusSessionProcessor processor) { }
        public virtual System.Threading.Tasks.Task<bool> BeginProcessingMessageAsync(Microsoft.Azure.WebJobs.ServiceBus.ServiceBusSessionMessageActions sessionActions, Azure.Messaging.ServiceBus.ServiceBusReceivedMessage message, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task CompleteProcessingMessageAsync(Microsoft.Azure.WebJobs.ServiceBus.ServiceBusSessionMessageActions sessionActions, Azure.Messaging.ServiceBus.ServiceBusReceivedMessage message, Microsoft.Azure.WebJobs.Host.Executors.FunctionResult result, System.Threading.CancellationToken cancellationToken) { throw null; }
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
