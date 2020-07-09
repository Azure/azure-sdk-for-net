namespace Azure.Messaging.EventGrid
{
    public partial class EventGridClient
    {
        protected EventGridClient() { }
        public EventGridClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public EventGridClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.Messaging.EventGrid.EventGridClientOptions options) { }
        public EventGridClient(System.Uri endpoint, Azure.Messaging.EventGrid.SharedAccessSignatureCredential credential) { }
        public EventGridClient(System.Uri endpoint, Azure.Messaging.EventGrid.SharedAccessSignatureCredential credential, Azure.Messaging.EventGrid.EventGridClientOptions options) { }
        public string BuildSharedAccessSignature(System.DateTimeOffset expirationUtc) { throw null; }
        public virtual Azure.Response PublishCloudEvents(System.Collections.Generic.IEnumerable<Azure.Messaging.EventGrid.Models.CloudEvent> events, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PublishCloudEventsAsync(System.Collections.Generic.IEnumerable<Azure.Messaging.EventGrid.Models.CloudEvent> events, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response PublishCustomEvents(System.Collections.Generic.IEnumerable<object> events, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PublishCustomEventsAsync(System.Collections.Generic.IEnumerable<object> events, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response PublishEvents(System.Collections.Generic.IEnumerable<Azure.Messaging.EventGrid.Models.EventGridEvent> events, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PublishEventsAsync(System.Collections.Generic.IEnumerable<Azure.Messaging.EventGrid.Models.EventGridEvent> events, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EventGridClientOptions : Azure.Core.ClientOptions
    {
        public EventGridClientOptions(Azure.Messaging.EventGrid.EventGridClientOptions.ServiceVersion version = Azure.Messaging.EventGrid.EventGridClientOptions.ServiceVersion.V2018_01_01) { }
        public enum ServiceVersion
        {
            V2018_01_01 = 1,
        }
    }
    public partial class SharedAccessSignatureCredential
    {
        public SharedAccessSignatureCredential(string signature) { }
        public string Signature { get { throw null; } }
    }
}
namespace Azure.Messaging.EventGrid.Models
{
    public partial class CloudEvent
    {
        public CloudEvent(string id, string source, string type, string specversion) { }
        public object Data { get { throw null; } set { } }
        public string Datacontenttype { get { throw null; } set { } }
        public string Dataschema { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public string Source { get { throw null; } }
        public string Specversion { get { throw null; } }
        public string Subject { get { throw null; } set { } }
        public System.DateTimeOffset? Time { get { throw null; } set { } }
        public string Type { get { throw null; } }
    }
    public partial class EventGridEvent
    {
        public EventGridEvent(string id, string subject, object data, string eventType, System.DateTimeOffset eventTime, string dataVersion) { }
        public object Data { get { throw null; } }
        public string DataVersion { get { throw null; } }
        public System.DateTimeOffset EventTime { get { throw null; } }
        public string EventType { get { throw null; } }
        public string Id { get { throw null; } }
        public string MetadataVersion { get { throw null; } }
        public string Subject { get { throw null; } }
        public string Topic { get { throw null; } set { } }
    }
}
