namespace Azure.Messaging.EventGrid.Namespaces
{
    public partial class AcknowledgeOptions : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.Namespaces.AcknowledgeOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.AcknowledgeOptions>
    {
        public AcknowledgeOptions(System.Collections.Generic.IEnumerable<string> lockTokens) { }
        public System.Collections.Generic.IList<string> LockTokens { get { throw null; } }
        Azure.Messaging.EventGrid.Namespaces.AcknowledgeOptions System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.Namespaces.AcknowledgeOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.Namespaces.AcknowledgeOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.Namespaces.AcknowledgeOptions System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.AcknowledgeOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.AcknowledgeOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.AcknowledgeOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AcknowledgeResult : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.Namespaces.AcknowledgeResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.AcknowledgeResult>
    {
        internal AcknowledgeResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Messaging.EventGrid.Namespaces.FailedLockToken> FailedLockTokens { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SucceededLockTokens { get { throw null; } }
        Azure.Messaging.EventGrid.Namespaces.AcknowledgeResult System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.Namespaces.AcknowledgeResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.Namespaces.AcknowledgeResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.Namespaces.AcknowledgeResult System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.AcknowledgeResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.AcknowledgeResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.AcknowledgeResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BrokerProperties : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.Namespaces.BrokerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.BrokerProperties>
    {
        internal BrokerProperties() { }
        public int DeliveryCount { get { throw null; } }
        public string LockToken { get { throw null; } }
        Azure.Messaging.EventGrid.Namespaces.BrokerProperties System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.Namespaces.BrokerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.Namespaces.BrokerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.Namespaces.BrokerProperties System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.BrokerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.BrokerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.BrokerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EventGridClient
    {
        protected EventGridClient() { }
        public EventGridClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public EventGridClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.Messaging.EventGrid.Namespaces.EventGridClientOptions options) { }
        public EventGridClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public EventGridClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Messaging.EventGrid.Namespaces.EventGridClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response AcknowledgeCloudEvents(string topicName, string eventSubscriptionName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Messaging.EventGrid.Namespaces.AcknowledgeResult> AcknowledgeCloudEvents(string topicName, string eventSubscriptionName, Azure.Messaging.EventGrid.Namespaces.AcknowledgeOptions acknowledgeOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AcknowledgeCloudEventsAsync(string topicName, string eventSubscriptionName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.EventGrid.Namespaces.AcknowledgeResult>> AcknowledgeCloudEventsAsync(string topicName, string eventSubscriptionName, Azure.Messaging.EventGrid.Namespaces.AcknowledgeOptions acknowledgeOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response PublishCloudEvent(string topicName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response PublishCloudEvent(string topicName, Azure.Messaging.CloudEvent cloudEvent, bool binaryMode = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PublishCloudEventAsync(string topicName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PublishCloudEventAsync(string topicName, Azure.Messaging.CloudEvent cloudEvent, bool binaryMode = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response PublishCloudEvents(string topicName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response PublishCloudEvents(string topicName, System.Collections.Generic.IEnumerable<Azure.Messaging.CloudEvent> events, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PublishCloudEventsAsync(string topicName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PublishCloudEventsAsync(string topicName, System.Collections.Generic.IEnumerable<Azure.Messaging.CloudEvent> events, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ReceiveCloudEvents(string topicName, string eventSubscriptionName, int? maxEvents, System.TimeSpan? maxWaitTime, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Messaging.EventGrid.Namespaces.ReceiveResult> ReceiveCloudEvents(string topicName, string eventSubscriptionName, int? maxEvents = default(int?), System.TimeSpan? maxWaitTime = default(System.TimeSpan?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ReceiveCloudEventsAsync(string topicName, string eventSubscriptionName, int? maxEvents, System.TimeSpan? maxWaitTime, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.EventGrid.Namespaces.ReceiveResult>> ReceiveCloudEventsAsync(string topicName, string eventSubscriptionName, int? maxEvents = default(int?), System.TimeSpan? maxWaitTime = default(System.TimeSpan?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RejectCloudEvents(string topicName, string eventSubscriptionName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Messaging.EventGrid.Namespaces.RejectResult> RejectCloudEvents(string topicName, string eventSubscriptionName, Azure.Messaging.EventGrid.Namespaces.RejectOptions rejectOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RejectCloudEventsAsync(string topicName, string eventSubscriptionName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.EventGrid.Namespaces.RejectResult>> RejectCloudEventsAsync(string topicName, string eventSubscriptionName, Azure.Messaging.EventGrid.Namespaces.RejectOptions rejectOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ReleaseCloudEvents(string topicName, string eventSubscriptionName, Azure.Core.RequestContent content, int? releaseDelayInSeconds = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Messaging.EventGrid.Namespaces.ReleaseResult> ReleaseCloudEvents(string topicName, string eventSubscriptionName, Azure.Messaging.EventGrid.Namespaces.ReleaseOptions releaseOptions, Azure.Messaging.EventGrid.Namespaces.ReleaseDelay? releaseDelayInSeconds = default(Azure.Messaging.EventGrid.Namespaces.ReleaseDelay?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ReleaseCloudEventsAsync(string topicName, string eventSubscriptionName, Azure.Core.RequestContent content, int? releaseDelayInSeconds = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.EventGrid.Namespaces.ReleaseResult>> ReleaseCloudEventsAsync(string topicName, string eventSubscriptionName, Azure.Messaging.EventGrid.Namespaces.ReleaseOptions releaseOptions, Azure.Messaging.EventGrid.Namespaces.ReleaseDelay? releaseDelayInSeconds = default(Azure.Messaging.EventGrid.Namespaces.ReleaseDelay?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RenewCloudEventLocks(string topicName, string eventSubscriptionName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Messaging.EventGrid.Namespaces.RenewCloudEventLocksResult> RenewCloudEventLocks(string topicName, string eventSubscriptionName, Azure.Messaging.EventGrid.Namespaces.RenewLockOptions renewLockOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RenewCloudEventLocksAsync(string topicName, string eventSubscriptionName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.EventGrid.Namespaces.RenewCloudEventLocksResult>> RenewCloudEventLocksAsync(string topicName, string eventSubscriptionName, Azure.Messaging.EventGrid.Namespaces.RenewLockOptions renewLockOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EventGridClientOptions : Azure.Core.ClientOptions
    {
        public EventGridClientOptions(Azure.Messaging.EventGrid.Namespaces.EventGridClientOptions.ServiceVersion version = Azure.Messaging.EventGrid.Namespaces.EventGridClientOptions.ServiceVersion.V2023_10_01_Preview) { }
        public enum ServiceVersion
        {
            V2023_11_01 = 1,
            V2023_06_01_Preview = 2,
            V2023_10_01_Preview = 3,
        }
    }
    public partial class FailedLockToken : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.Namespaces.FailedLockToken>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.FailedLockToken>
    {
        internal FailedLockToken() { }
        public Azure.ResponseError Error { get { throw null; } }
        public string LockToken { get { throw null; } }
        Azure.Messaging.EventGrid.Namespaces.FailedLockToken System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.Namespaces.FailedLockToken>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.Namespaces.FailedLockToken>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.Namespaces.FailedLockToken System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.FailedLockToken>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.FailedLockToken>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.FailedLockToken>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class MessagingEventGridNamespacesModelFactory
    {
        public static Azure.Messaging.EventGrid.Namespaces.AcknowledgeResult AcknowledgeResult(System.Collections.Generic.IEnumerable<Azure.Messaging.EventGrid.Namespaces.FailedLockToken> failedLockTokens = null, System.Collections.Generic.IEnumerable<string> succeededLockTokens = null) { throw null; }
        public static Azure.Messaging.EventGrid.Namespaces.BrokerProperties BrokerProperties(string lockToken = null, int deliveryCount = 0) { throw null; }
        public static Azure.Messaging.EventGrid.Namespaces.FailedLockToken FailedLockToken(string lockToken = null, Azure.ResponseError error = null) { throw null; }
        public static Azure.Messaging.EventGrid.Namespaces.ReceiveDetails ReceiveDetails(Azure.Messaging.EventGrid.Namespaces.BrokerProperties brokerProperties = null, Azure.Messaging.CloudEvent @event = null) { throw null; }
        public static Azure.Messaging.EventGrid.Namespaces.ReceiveResult ReceiveResult(System.Collections.Generic.IEnumerable<Azure.Messaging.EventGrid.Namespaces.ReceiveDetails> value = null) { throw null; }
        public static Azure.Messaging.EventGrid.Namespaces.RejectResult RejectResult(System.Collections.Generic.IEnumerable<Azure.Messaging.EventGrid.Namespaces.FailedLockToken> failedLockTokens = null, System.Collections.Generic.IEnumerable<string> succeededLockTokens = null) { throw null; }
        public static Azure.Messaging.EventGrid.Namespaces.ReleaseResult ReleaseResult(System.Collections.Generic.IEnumerable<Azure.Messaging.EventGrid.Namespaces.FailedLockToken> failedLockTokens = null, System.Collections.Generic.IEnumerable<string> succeededLockTokens = null) { throw null; }
        public static Azure.Messaging.EventGrid.Namespaces.RenewCloudEventLocksResult RenewCloudEventLocksResult(System.Collections.Generic.IEnumerable<Azure.Messaging.EventGrid.Namespaces.FailedLockToken> failedLockTokens = null, System.Collections.Generic.IEnumerable<string> succeededLockTokens = null) { throw null; }
    }
    public partial class ReceiveDetails : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.Namespaces.ReceiveDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.ReceiveDetails>
    {
        internal ReceiveDetails() { }
        public Azure.Messaging.EventGrid.Namespaces.BrokerProperties BrokerProperties { get { throw null; } }
        public Azure.Messaging.CloudEvent Event { get { throw null; } }
        Azure.Messaging.EventGrid.Namespaces.ReceiveDetails System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.Namespaces.ReceiveDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.Namespaces.ReceiveDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.Namespaces.ReceiveDetails System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.ReceiveDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.ReceiveDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.ReceiveDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReceiveResult : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.Namespaces.ReceiveResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.ReceiveResult>
    {
        internal ReceiveResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Messaging.EventGrid.Namespaces.ReceiveDetails> Value { get { throw null; } }
        Azure.Messaging.EventGrid.Namespaces.ReceiveResult System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.Namespaces.ReceiveResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.Namespaces.ReceiveResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.Namespaces.ReceiveResult System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.ReceiveResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.ReceiveResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.ReceiveResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RejectOptions : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.Namespaces.RejectOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.RejectOptions>
    {
        public RejectOptions(System.Collections.Generic.IEnumerable<string> lockTokens) { }
        public System.Collections.Generic.IList<string> LockTokens { get { throw null; } }
        Azure.Messaging.EventGrid.Namespaces.RejectOptions System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.Namespaces.RejectOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.Namespaces.RejectOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.Namespaces.RejectOptions System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.RejectOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.RejectOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.RejectOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RejectResult : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.Namespaces.RejectResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.RejectResult>
    {
        internal RejectResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Messaging.EventGrid.Namespaces.FailedLockToken> FailedLockTokens { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SucceededLockTokens { get { throw null; } }
        Azure.Messaging.EventGrid.Namespaces.RejectResult System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.Namespaces.RejectResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.Namespaces.RejectResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.Namespaces.RejectResult System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.RejectResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.RejectResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.RejectResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReleaseDelay : System.IEquatable<Azure.Messaging.EventGrid.Namespaces.ReleaseDelay>
    {
        private readonly int _dummyPrimitive;
        public ReleaseDelay(int value) { throw null; }
        public static Azure.Messaging.EventGrid.Namespaces.ReleaseDelay By0Seconds { get { throw null; } }
        public static Azure.Messaging.EventGrid.Namespaces.ReleaseDelay By10Seconds { get { throw null; } }
        public static Azure.Messaging.EventGrid.Namespaces.ReleaseDelay By3600Seconds { get { throw null; } }
        public static Azure.Messaging.EventGrid.Namespaces.ReleaseDelay By600Seconds { get { throw null; } }
        public static Azure.Messaging.EventGrid.Namespaces.ReleaseDelay By60Seconds { get { throw null; } }
        public bool Equals(Azure.Messaging.EventGrid.Namespaces.ReleaseDelay other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.EventGrid.Namespaces.ReleaseDelay left, Azure.Messaging.EventGrid.Namespaces.ReleaseDelay right) { throw null; }
        public static implicit operator Azure.Messaging.EventGrid.Namespaces.ReleaseDelay (int value) { throw null; }
        public static bool operator !=(Azure.Messaging.EventGrid.Namespaces.ReleaseDelay left, Azure.Messaging.EventGrid.Namespaces.ReleaseDelay right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ReleaseOptions : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.Namespaces.ReleaseOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.ReleaseOptions>
    {
        public ReleaseOptions(System.Collections.Generic.IEnumerable<string> lockTokens) { }
        public System.Collections.Generic.IList<string> LockTokens { get { throw null; } }
        Azure.Messaging.EventGrid.Namespaces.ReleaseOptions System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.Namespaces.ReleaseOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.Namespaces.ReleaseOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.Namespaces.ReleaseOptions System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.ReleaseOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.ReleaseOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.ReleaseOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReleaseResult : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.Namespaces.ReleaseResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.ReleaseResult>
    {
        internal ReleaseResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Messaging.EventGrid.Namespaces.FailedLockToken> FailedLockTokens { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SucceededLockTokens { get { throw null; } }
        Azure.Messaging.EventGrid.Namespaces.ReleaseResult System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.Namespaces.ReleaseResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.Namespaces.ReleaseResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.Namespaces.ReleaseResult System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.ReleaseResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.ReleaseResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.ReleaseResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RenewCloudEventLocksResult : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.Namespaces.RenewCloudEventLocksResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.RenewCloudEventLocksResult>
    {
        internal RenewCloudEventLocksResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Messaging.EventGrid.Namespaces.FailedLockToken> FailedLockTokens { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SucceededLockTokens { get { throw null; } }
        Azure.Messaging.EventGrid.Namespaces.RenewCloudEventLocksResult System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.Namespaces.RenewCloudEventLocksResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.Namespaces.RenewCloudEventLocksResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.Namespaces.RenewCloudEventLocksResult System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.RenewCloudEventLocksResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.RenewCloudEventLocksResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.RenewCloudEventLocksResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RenewLockOptions : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.Namespaces.RenewLockOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.RenewLockOptions>
    {
        public RenewLockOptions(System.Collections.Generic.IEnumerable<string> lockTokens) { }
        public System.Collections.Generic.IList<string> LockTokens { get { throw null; } }
        Azure.Messaging.EventGrid.Namespaces.RenewLockOptions System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.Namespaces.RenewLockOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.Namespaces.RenewLockOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.Namespaces.RenewLockOptions System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.RenewLockOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.RenewLockOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.RenewLockOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class MessagingEventGridNamespacesClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Messaging.EventGrid.Namespaces.EventGridClient, Azure.Messaging.EventGrid.Namespaces.EventGridClientOptions> AddEventGridClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Messaging.EventGrid.Namespaces.EventGridClient, Azure.Messaging.EventGrid.Namespaces.EventGridClientOptions> AddEventGridClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Messaging.EventGrid.Namespaces.EventGridClient, Azure.Messaging.EventGrid.Namespaces.EventGridClientOptions> AddEventGridClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
