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
        public Azure.Core.ObjectSerializer Serializer { get { throw null; } set { } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AppAction : System.IEquatable<Azure.Messaging.EventGrid.Models.AppAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AppAction(string value) { throw null; }
        public static Azure.Messaging.EventGrid.Models.AppAction ChangedAppSettings { get { throw null; } }
        public static Azure.Messaging.EventGrid.Models.AppAction Completed { get { throw null; } }
        public static Azure.Messaging.EventGrid.Models.AppAction Failed { get { throw null; } }
        public static Azure.Messaging.EventGrid.Models.AppAction Restarted { get { throw null; } }
        public static Azure.Messaging.EventGrid.Models.AppAction Started { get { throw null; } }
        public static Azure.Messaging.EventGrid.Models.AppAction Stopped { get { throw null; } }
        public bool Equals(Azure.Messaging.EventGrid.Models.AppAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.EventGrid.Models.AppAction left, Azure.Messaging.EventGrid.Models.AppAction right) { throw null; }
        public static implicit operator Azure.Messaging.EventGrid.Models.AppAction (string value) { throw null; }
        public static bool operator !=(Azure.Messaging.EventGrid.Models.AppAction left, Azure.Messaging.EventGrid.Models.AppAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AsyncStatus : System.IEquatable<Azure.Messaging.EventGrid.Models.AsyncStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AsyncStatus(string value) { throw null; }
        public static Azure.Messaging.EventGrid.Models.AsyncStatus Completed { get { throw null; } }
        public static Azure.Messaging.EventGrid.Models.AsyncStatus Failed { get { throw null; } }
        public static Azure.Messaging.EventGrid.Models.AsyncStatus Started { get { throw null; } }
        public bool Equals(Azure.Messaging.EventGrid.Models.AsyncStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.EventGrid.Models.AsyncStatus left, Azure.Messaging.EventGrid.Models.AsyncStatus right) { throw null; }
        public static implicit operator Azure.Messaging.EventGrid.Models.AsyncStatus (string value) { throw null; }
        public static bool operator !=(Azure.Messaging.EventGrid.Models.AsyncStatus left, Azure.Messaging.EventGrid.Models.AsyncStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
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
    public enum MediaJobErrorCategory
    {
        Service = 0,
        Download = 1,
        Upload = 2,
        Configuration = 3,
        Content = 4,
    }
    public enum MediaJobErrorCode
    {
        ServiceError = 0,
        ServiceTransientError = 1,
        DownloadNotAccessible = 2,
        DownloadTransientError = 3,
        UploadNotAccessible = 4,
        UploadTransientError = 5,
        ConfigurationUnsupported = 6,
        ContentMalformed = 7,
        ContentUnsupported = 8,
    }
    public enum MediaJobRetry
    {
        DoNotRetry = 0,
        MayRetry = 1,
    }
    public enum MediaJobState
    {
        Canceled = 0,
        Canceling = 1,
        Error = 2,
        Finished = 3,
        Processing = 4,
        Queued = 5,
        Scheduled = 6,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StampKind : System.IEquatable<Azure.Messaging.EventGrid.Models.StampKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StampKind(string value) { throw null; }
        public static Azure.Messaging.EventGrid.Models.StampKind AseV1 { get { throw null; } }
        public static Azure.Messaging.EventGrid.Models.StampKind AseV2 { get { throw null; } }
        public static Azure.Messaging.EventGrid.Models.StampKind Public { get { throw null; } }
        public bool Equals(Azure.Messaging.EventGrid.Models.StampKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.EventGrid.Models.StampKind left, Azure.Messaging.EventGrid.Models.StampKind right) { throw null; }
        public static implicit operator Azure.Messaging.EventGrid.Models.StampKind (string value) { throw null; }
        public static bool operator !=(Azure.Messaging.EventGrid.Models.StampKind left, Azure.Messaging.EventGrid.Models.StampKind right) { throw null; }
        public override string ToString() { throw null; }
    }
}
