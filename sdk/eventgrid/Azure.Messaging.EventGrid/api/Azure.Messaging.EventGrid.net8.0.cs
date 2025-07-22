namespace Azure.Messaging.EventGrid
{
    public partial class AzureMessagingEventGridContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureMessagingEventGridContext() { }
        public static Azure.Messaging.EventGrid.AzureMessagingEventGridContext Default { get { throw null; } }
    }
    public partial class EventGridEvent
    {
        public EventGridEvent(string subject, string eventType, string dataVersion, System.BinaryData data) { }
        public EventGridEvent(string subject, string eventType, string dataVersion, object data, System.Type dataSerializationType = null) { }
        public System.BinaryData Data { get { throw null; } set { } }
        public string DataVersion { get { throw null; } set { } }
        public System.DateTimeOffset EventTime { get { throw null; } set { } }
        public string EventType { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public string Subject { get { throw null; } set { } }
        public string Topic { get { throw null; } set { } }
        public static Azure.Messaging.EventGrid.EventGridEvent Parse(System.BinaryData json) { throw null; }
        public static Azure.Messaging.EventGrid.EventGridEvent[] ParseMany(System.BinaryData json) { throw null; }
        public bool TryGetSystemEventData(out object eventData) { throw null; }
    }
    public partial class EventGridPublisherClient
    {
        protected EventGridPublisherClient() { }
        public EventGridPublisherClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public EventGridPublisherClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.Messaging.EventGrid.EventGridPublisherClientOptions options) { }
        public EventGridPublisherClient(System.Uri endpoint, Azure.AzureSasCredential credential, Azure.Messaging.EventGrid.EventGridPublisherClientOptions options = null) { }
        public EventGridPublisherClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Messaging.EventGrid.EventGridPublisherClientOptions options = null) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response SendEncodedCloudEvents(System.ReadOnlyMemory<byte> cloudEvents, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response> SendEncodedCloudEventsAsync(System.ReadOnlyMemory<byte> cloudEvents, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SendEvent(Azure.Messaging.CloudEvent cloudEvent, string channelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SendEvent(Azure.Messaging.CloudEvent cloudEvent, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SendEvent(Azure.Messaging.EventGrid.EventGridEvent eventGridEvent, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SendEvent(System.BinaryData customEvent, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SendEventAsync(Azure.Messaging.CloudEvent cloudEvent, string channelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SendEventAsync(Azure.Messaging.CloudEvent cloudEvent, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SendEventAsync(Azure.Messaging.EventGrid.EventGridEvent eventGridEvent, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SendEventAsync(System.BinaryData customEvent, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SendEvents(System.Collections.Generic.IEnumerable<Azure.Messaging.CloudEvent> cloudEvents, string channelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SendEvents(System.Collections.Generic.IEnumerable<Azure.Messaging.CloudEvent> cloudEvents, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SendEvents(System.Collections.Generic.IEnumerable<Azure.Messaging.EventGrid.EventGridEvent> eventGridEvents, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SendEvents(System.Collections.Generic.IEnumerable<System.BinaryData> customEvents, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SendEventsAsync(System.Collections.Generic.IEnumerable<Azure.Messaging.CloudEvent> cloudEvents, string channelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SendEventsAsync(System.Collections.Generic.IEnumerable<Azure.Messaging.CloudEvent> cloudEvents, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SendEventsAsync(System.Collections.Generic.IEnumerable<Azure.Messaging.EventGrid.EventGridEvent> eventGridEvents, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SendEventsAsync(System.Collections.Generic.IEnumerable<System.BinaryData> customEvents, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EventGridPublisherClientOptions : Azure.Core.ClientOptions
    {
        public EventGridPublisherClientOptions(Azure.Messaging.EventGrid.EventGridPublisherClientOptions.ServiceVersion version = Azure.Messaging.EventGrid.EventGridPublisherClientOptions.ServiceVersion.V2018_01_01) { }
        public enum ServiceVersion
        {
            V2018_01_01 = 1,
        }
    }
    public partial class EventGridSasBuilder
    {
        public EventGridSasBuilder(System.Uri endpoint, System.DateTimeOffset expiresOn) { }
        public Azure.Messaging.EventGrid.EventGridPublisherClientOptions.ServiceVersion ApiVersion { get { throw null; } set { } }
        public System.Uri Endpoint { get { throw null; } set { } }
        public System.DateTimeOffset ExpiresOn { get { throw null; } set { } }
        public string GenerateSas(Azure.AzureKeyCredential key) { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class EventGridPublisherClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Messaging.EventGrid.EventGridPublisherClient, Azure.Messaging.EventGrid.EventGridPublisherClientOptions> AddEventGridPublisherClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Messaging.EventGrid.EventGridPublisherClient, Azure.Messaging.EventGrid.EventGridPublisherClientOptions> AddEventGridPublisherClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Messaging.EventGrid.EventGridPublisherClient, Azure.Messaging.EventGrid.EventGridPublisherClientOptions> AddEventGridPublisherClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureSasCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        [System.Diagnostics.CodeAnalysis.RequiresDynamicCodeAttribute("Binding strongly typed objects to configuration values requires generating dynamic code at runtime, for example instantiating generic types. Use the Configuration Binder Source Generator (EnableConfigurationBindingGenerator=true) instead.")]
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Messaging.EventGrid.EventGridPublisherClient, Azure.Messaging.EventGrid.EventGridPublisherClientOptions> AddEventGridPublisherClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
