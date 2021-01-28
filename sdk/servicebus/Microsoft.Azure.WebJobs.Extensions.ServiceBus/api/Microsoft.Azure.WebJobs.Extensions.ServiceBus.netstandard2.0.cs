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
    public partial class BatchOptions
    {
        public BatchOptions() { }
        public bool AutoComplete { get { throw null; } set { } }
        public int MaxMessageCount { get { throw null; } set { } }
        public System.TimeSpan OperationTimeout { get { throw null; } set { } }
    }
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
        public MessageProcessor(Microsoft.Azure.ServiceBus.Core.MessageReceiver messageReceiver, Microsoft.Azure.ServiceBus.MessageHandlerOptions messageOptions) { }
        public Microsoft.Azure.ServiceBus.MessageHandlerOptions MessageOptions { get { throw null; } }
        protected Microsoft.Azure.ServiceBus.Core.MessageReceiver MessageReceiver { get { throw null; } set { } }
        public virtual System.Threading.Tasks.Task<bool> BeginProcessingMessageAsync(Microsoft.Azure.ServiceBus.Message message, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task CompleteProcessingMessageAsync(Microsoft.Azure.ServiceBus.Message message, Microsoft.Azure.WebJobs.Host.Executors.FunctionResult result, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class MessagingProvider
    {
        public MessagingProvider(Microsoft.Extensions.Options.IOptions<Microsoft.Azure.WebJobs.ServiceBus.ServiceBusOptions> serviceBusOptions) { }
        public virtual Microsoft.Azure.ServiceBus.ClientEntity CreateClientEntity(string entityPath, string connectionString) { throw null; }
        public virtual Microsoft.Azure.WebJobs.ServiceBus.MessageProcessor CreateMessageProcessor(string entityPath, string connectionString) { throw null; }
        public virtual Microsoft.Azure.ServiceBus.Core.MessageReceiver CreateMessageReceiver(string entityPath, string connectionString) { throw null; }
        public virtual Microsoft.Azure.ServiceBus.Core.MessageSender CreateMessageSender(string entityPath, string connectionString) { throw null; }
        public virtual Microsoft.Azure.ServiceBus.SessionClient CreateSessionClient(string entityPath, string connectionString) { throw null; }
        public virtual Microsoft.Azure.WebJobs.ServiceBus.SessionMessageProcessor CreateSessionMessageProcessor(string entityPath, string connectionString) { throw null; }
    }
    public partial class ServiceBusOptions : Microsoft.Azure.WebJobs.Hosting.IOptionsFormatter
    {
        public ServiceBusOptions() { }
        public Microsoft.Azure.WebJobs.ServiceBus.BatchOptions BatchOptions { get { throw null; } set { } }
        public string ConnectionString { get { throw null; } set { } }
        public Microsoft.Azure.ServiceBus.MessageHandlerOptions MessageHandlerOptions { get { throw null; } set { } }
        public int PrefetchCount { get { throw null; } set { } }
        public Microsoft.Azure.ServiceBus.SessionHandlerOptions SessionHandlerOptions { get { throw null; } set { } }
        public string Format() { throw null; }
    }
    public partial class ServiceBusWebJobsStartup : Microsoft.Azure.WebJobs.Hosting.IWebJobsStartup
    {
        public ServiceBusWebJobsStartup() { }
        public void Configure(Microsoft.Azure.WebJobs.IWebJobsBuilder builder) { }
    }
    public partial class SessionMessageProcessor
    {
        public SessionMessageProcessor(Microsoft.Azure.ServiceBus.ClientEntity clientEntity, Microsoft.Azure.ServiceBus.SessionHandlerOptions sessionHandlerOptions) { }
        protected Microsoft.Azure.ServiceBus.ClientEntity ClientEntity { get { throw null; } set { } }
        public Microsoft.Azure.ServiceBus.SessionHandlerOptions SessionHandlerOptions { get { throw null; } }
        public virtual System.Threading.Tasks.Task<bool> BeginProcessingMessageAsync(Microsoft.Azure.ServiceBus.IMessageSession session, Microsoft.Azure.ServiceBus.Message message, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task CompleteProcessingMessageAsync(Microsoft.Azure.ServiceBus.IMessageSession session, Microsoft.Azure.ServiceBus.Message message, Microsoft.Azure.WebJobs.Host.Executors.FunctionResult result, System.Threading.CancellationToken cancellationToken) { throw null; }
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
