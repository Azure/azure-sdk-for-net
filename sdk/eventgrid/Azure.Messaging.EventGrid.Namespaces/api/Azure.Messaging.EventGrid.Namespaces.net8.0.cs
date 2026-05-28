namespace Azure.Messaging.EventGrid.Namespaces
{
    public partial class AcknowledgeResult : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.Namespaces.AcknowledgeResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.AcknowledgeResult>
    {
        internal AcknowledgeResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Messaging.EventGrid.Namespaces.FailedLockToken> FailedLockTokens { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SucceededLockTokens { get { throw null; } }
        protected virtual Azure.Messaging.EventGrid.Namespaces.AcknowledgeResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Messaging.EventGrid.Namespaces.AcknowledgeResult (Azure.Response result) { throw null; }
        public static implicit operator Azure.Core.RequestContent (Azure.Messaging.EventGrid.Namespaces.AcknowledgeResult acknowledgeResult) { throw null; }
        protected virtual Azure.Messaging.EventGrid.Namespaces.AcknowledgeResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Messaging.EventGrid.Namespaces.AcknowledgeResult System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.Namespaces.AcknowledgeResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.Namespaces.AcknowledgeResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.Namespaces.AcknowledgeResult System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.AcknowledgeResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.AcknowledgeResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.AcknowledgeResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureMessagingEventGridNamespacesContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureMessagingEventGridNamespacesContext() { }
        public static Azure.Messaging.EventGrid.Namespaces.AzureMessagingEventGridNamespacesContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class BrokerProperties : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.Namespaces.BrokerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.BrokerProperties>
    {
        internal BrokerProperties() { }
        public int DeliveryCount { get { throw null; } }
        public string LockToken { get { throw null; } }
        protected virtual Azure.Messaging.EventGrid.Namespaces.BrokerProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Messaging.EventGrid.Namespaces.BrokerProperties (Azure.Response result) { throw null; }
        public static implicit operator Azure.Core.RequestContent (Azure.Messaging.EventGrid.Namespaces.BrokerProperties brokerProperties) { throw null; }
        protected virtual Azure.Messaging.EventGrid.Namespaces.BrokerProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Messaging.EventGrid.Namespaces.BrokerProperties System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.Namespaces.BrokerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.Namespaces.BrokerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.Namespaces.BrokerProperties System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.BrokerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.BrokerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.BrokerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class EventGridNamespacesModelFactory
    {
        public static Azure.Messaging.EventGrid.Namespaces.AcknowledgeResult AcknowledgeResult(System.Collections.Generic.IEnumerable<Azure.Messaging.EventGrid.Namespaces.FailedLockToken> failedLockTokens = null, System.Collections.Generic.IEnumerable<string> succeededLockTokens = null) { throw null; }
        public static Azure.Messaging.EventGrid.Namespaces.BrokerProperties BrokerProperties(string lockToken = null, int deliveryCount = 0) { throw null; }
        public static Azure.Messaging.EventGrid.Namespaces.FailedLockToken FailedLockToken(string lockToken = null, Azure.ResponseError error = null) { throw null; }
        public static Azure.Messaging.EventGrid.Namespaces.ReceiveDetails ReceiveDetails(Azure.Messaging.EventGrid.Namespaces.BrokerProperties brokerProperties = null, Azure.Messaging.CloudEvent @event = null) { throw null; }
        public static Azure.Messaging.EventGrid.Namespaces.ReceiveResult ReceiveResult(System.Collections.Generic.IEnumerable<Azure.Messaging.EventGrid.Namespaces.ReceiveDetails> details = null) { throw null; }
        public static Azure.Messaging.EventGrid.Namespaces.RejectResult RejectResult(System.Collections.Generic.IEnumerable<Azure.Messaging.EventGrid.Namespaces.FailedLockToken> failedLockTokens = null, System.Collections.Generic.IEnumerable<string> succeededLockTokens = null) { throw null; }
        public static Azure.Messaging.EventGrid.Namespaces.ReleaseResult ReleaseResult(System.Collections.Generic.IEnumerable<Azure.Messaging.EventGrid.Namespaces.FailedLockToken> failedLockTokens = null, System.Collections.Generic.IEnumerable<string> succeededLockTokens = null) { throw null; }
        public static Azure.Messaging.EventGrid.Namespaces.RenewLocksResult RenewLocksResult(System.Collections.Generic.IEnumerable<Azure.Messaging.EventGrid.Namespaces.FailedLockToken> failedLockTokens = null, System.Collections.Generic.IEnumerable<string> succeededLockTokens = null) { throw null; }
    }
    public partial class EventGridReceiverClient
    {
        protected EventGridReceiverClient() { }
        public EventGridReceiverClient(System.Uri endpoint, string topicName, string subscriptionName, Azure.AzureKeyCredential credential) { }
        public EventGridReceiverClient(System.Uri endpoint, string topicName, string subscriptionName, Azure.AzureKeyCredential credential, Azure.Messaging.EventGrid.Namespaces.EventGridReceiverClientOptions options) { }
        public EventGridReceiverClient(System.Uri endpoint, string topicName, string subscriptionName, Azure.Core.TokenCredential credential) { }
        public EventGridReceiverClient(System.Uri endpoint, string topicName, string subscriptionName, Azure.Core.TokenCredential credential, Azure.Messaging.EventGrid.Namespaces.EventGridReceiverClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response Acknowledge(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Messaging.EventGrid.Namespaces.AcknowledgeResult> Acknowledge(System.Collections.Generic.IEnumerable<string> lockTokens, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response> AcknowledgeAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.EventGrid.Namespaces.AcknowledgeResult>> AcknowledgeAsync(System.Collections.Generic.IEnumerable<string> lockTokens, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response Receive(int? maxEvents, System.TimeSpan? maxWaitTime, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Messaging.EventGrid.Namespaces.ReceiveResult> Receive(int? maxEvents = default(int?), System.TimeSpan? maxWaitTime = default(System.TimeSpan?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response> ReceiveAsync(int? maxEvents, System.TimeSpan? maxWaitTime, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.EventGrid.Namespaces.ReceiveResult>> ReceiveAsync(int? maxEvents = default(int?), System.TimeSpan? maxWaitTime = default(System.TimeSpan?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response Reject(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Messaging.EventGrid.Namespaces.RejectResult> Reject(System.Collections.Generic.IEnumerable<string> lockTokens, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response> RejectAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.EventGrid.Namespaces.RejectResult>> RejectAsync(System.Collections.Generic.IEnumerable<string> lockTokens, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response Release(Azure.Core.RequestContent content, string releaseDelayInSeconds = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Messaging.EventGrid.Namespaces.ReleaseResult> Release(System.Collections.Generic.IEnumerable<string> lockTokens, Azure.Messaging.EventGrid.Namespaces.ReleaseDelay? delay = default(Azure.Messaging.EventGrid.Namespaces.ReleaseDelay?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response> ReleaseAsync(Azure.Core.RequestContent content, string releaseDelayInSeconds = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.EventGrid.Namespaces.ReleaseResult>> ReleaseAsync(System.Collections.Generic.IEnumerable<string> lockTokens, Azure.Messaging.EventGrid.Namespaces.ReleaseDelay? delay = default(Azure.Messaging.EventGrid.Namespaces.ReleaseDelay?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response RenewLocks(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Messaging.EventGrid.Namespaces.RenewLocksResult> RenewLocks(System.Collections.Generic.IEnumerable<string> lockTokens, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response> RenewLocksAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.EventGrid.Namespaces.RenewLocksResult>> RenewLocksAsync(System.Collections.Generic.IEnumerable<string> lockTokens, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EventGridReceiverClientOptions : Azure.Core.ClientOptions
    {
        public EventGridReceiverClientOptions(Azure.Messaging.EventGrid.Namespaces.EventGridReceiverClientOptions.ServiceVersion version = Azure.Messaging.EventGrid.Namespaces.EventGridReceiverClientOptions.ServiceVersion.V2024_06_01) { }
        public enum ServiceVersion
        {
            V2023_11_01 = 1,
            V2024_06_01 = 2,
        }
    }
    public partial class EventGridSenderClient
    {
        protected EventGridSenderClient() { }
        public EventGridSenderClient(System.Uri endpoint, string topicName, Azure.AzureKeyCredential credential) { }
        public EventGridSenderClient(System.Uri endpoint, string topicName, Azure.AzureKeyCredential credential, Azure.Messaging.EventGrid.Namespaces.EventGridSenderClientOptions options) { }
        public EventGridSenderClient(System.Uri endpoint, string topicName, Azure.Core.TokenCredential credential) { }
        public EventGridSenderClient(System.Uri endpoint, string topicName, Azure.Core.TokenCredential credential, Azure.Messaging.EventGrid.Namespaces.EventGridSenderClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response Send(Azure.Messaging.CloudEvent cloudEvent, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Send(System.Collections.Generic.IEnumerable<Azure.Messaging.CloudEvent> cloudEvents, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SendAsync(Azure.Messaging.CloudEvent cloudEvent, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SendAsync(System.Collections.Generic.IEnumerable<Azure.Messaging.CloudEvent> cloudEvents, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response SendEvent(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response> SendEventAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response SendEvents(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response> SendEventsAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class EventGridSenderClientOptions : Azure.Core.ClientOptions
    {
        public EventGridSenderClientOptions(Azure.Messaging.EventGrid.Namespaces.EventGridSenderClientOptions.ServiceVersion version = Azure.Messaging.EventGrid.Namespaces.EventGridSenderClientOptions.ServiceVersion.V2024_06_01) { }
        public enum ServiceVersion
        {
            V2023_11_01 = 1,
            V2024_06_01 = 2,
        }
    }
    public partial class FailedLockToken : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.Namespaces.FailedLockToken>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.FailedLockToken>
    {
        internal FailedLockToken() { }
        public Azure.ResponseError Error { get { throw null; } }
        public string LockToken { get { throw null; } }
        protected virtual Azure.Messaging.EventGrid.Namespaces.FailedLockToken JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Messaging.EventGrid.Namespaces.FailedLockToken (Azure.Response result) { throw null; }
        public static implicit operator Azure.Core.RequestContent (Azure.Messaging.EventGrid.Namespaces.FailedLockToken failedLockToken) { throw null; }
        protected virtual Azure.Messaging.EventGrid.Namespaces.FailedLockToken PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Messaging.EventGrid.Namespaces.FailedLockToken System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.Namespaces.FailedLockToken>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.Namespaces.FailedLockToken>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.Namespaces.FailedLockToken System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.FailedLockToken>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.FailedLockToken>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.FailedLockToken>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReceiveDetails : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.Namespaces.ReceiveDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.ReceiveDetails>
    {
        internal ReceiveDetails() { }
        public Azure.Messaging.EventGrid.Namespaces.BrokerProperties BrokerProperties { get { throw null; } }
        public Azure.Messaging.CloudEvent Event { get { throw null; } }
        protected virtual Azure.Messaging.EventGrid.Namespaces.ReceiveDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Messaging.EventGrid.Namespaces.ReceiveDetails (Azure.Response result) { throw null; }
        public static implicit operator Azure.Core.RequestContent (Azure.Messaging.EventGrid.Namespaces.ReceiveDetails receiveDetails) { throw null; }
        protected virtual Azure.Messaging.EventGrid.Namespaces.ReceiveDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Messaging.EventGrid.Namespaces.ReceiveDetails System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.Namespaces.ReceiveDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.Namespaces.ReceiveDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.Namespaces.ReceiveDetails System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.ReceiveDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.ReceiveDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.ReceiveDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReceiveResult : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.Namespaces.ReceiveResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.ReceiveResult>
    {
        internal ReceiveResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Messaging.EventGrid.Namespaces.ReceiveDetails> Details { get { throw null; } }
        protected virtual Azure.Messaging.EventGrid.Namespaces.ReceiveResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Messaging.EventGrid.Namespaces.ReceiveResult (Azure.Response result) { throw null; }
        public static implicit operator Azure.Core.RequestContent (Azure.Messaging.EventGrid.Namespaces.ReceiveResult receiveResult) { throw null; }
        protected virtual Azure.Messaging.EventGrid.Namespaces.ReceiveResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Messaging.EventGrid.Namespaces.ReceiveResult System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.Namespaces.ReceiveResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.Namespaces.ReceiveResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.Namespaces.ReceiveResult System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.ReceiveResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.ReceiveResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.ReceiveResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RejectResult : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.Namespaces.RejectResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.RejectResult>
    {
        internal RejectResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Messaging.EventGrid.Namespaces.FailedLockToken> FailedLockTokens { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SucceededLockTokens { get { throw null; } }
        protected virtual Azure.Messaging.EventGrid.Namespaces.RejectResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Messaging.EventGrid.Namespaces.RejectResult (Azure.Response result) { throw null; }
        public static implicit operator Azure.Core.RequestContent (Azure.Messaging.EventGrid.Namespaces.RejectResult rejectResult) { throw null; }
        protected virtual Azure.Messaging.EventGrid.Namespaces.RejectResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Messaging.EventGrid.Namespaces.RejectResult System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.Namespaces.RejectResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.Namespaces.RejectResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.Namespaces.RejectResult System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.RejectResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.RejectResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.RejectResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReleaseDelay : System.IEquatable<Azure.Messaging.EventGrid.Namespaces.ReleaseDelay>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReleaseDelay(string value) { throw null; }
        public static Azure.Messaging.EventGrid.Namespaces.ReleaseDelay NoDelay { get { throw null; } }
        public static Azure.Messaging.EventGrid.Namespaces.ReleaseDelay OneHour { get { throw null; } }
        public static Azure.Messaging.EventGrid.Namespaces.ReleaseDelay OneMinute { get { throw null; } }
        public static Azure.Messaging.EventGrid.Namespaces.ReleaseDelay TenMinutes { get { throw null; } }
        public static Azure.Messaging.EventGrid.Namespaces.ReleaseDelay TenSeconds { get { throw null; } }
        public bool Equals(Azure.Messaging.EventGrid.Namespaces.ReleaseDelay other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.EventGrid.Namespaces.ReleaseDelay left, Azure.Messaging.EventGrid.Namespaces.ReleaseDelay right) { throw null; }
        public static implicit operator Azure.Messaging.EventGrid.Namespaces.ReleaseDelay (string value) { throw null; }
        public static implicit operator Azure.Messaging.EventGrid.Namespaces.ReleaseDelay? (string value) { throw null; }
        public static bool operator !=(Azure.Messaging.EventGrid.Namespaces.ReleaseDelay left, Azure.Messaging.EventGrid.Namespaces.ReleaseDelay right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ReleaseResult : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.Namespaces.ReleaseResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.ReleaseResult>
    {
        internal ReleaseResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Messaging.EventGrid.Namespaces.FailedLockToken> FailedLockTokens { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SucceededLockTokens { get { throw null; } }
        protected virtual Azure.Messaging.EventGrid.Namespaces.ReleaseResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Messaging.EventGrid.Namespaces.ReleaseResult (Azure.Response result) { throw null; }
        public static implicit operator Azure.Core.RequestContent (Azure.Messaging.EventGrid.Namespaces.ReleaseResult releaseResult) { throw null; }
        protected virtual Azure.Messaging.EventGrid.Namespaces.ReleaseResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Messaging.EventGrid.Namespaces.ReleaseResult System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.Namespaces.ReleaseResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.Namespaces.ReleaseResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.Namespaces.ReleaseResult System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.ReleaseResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.ReleaseResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.ReleaseResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RenewLocksResult : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.Namespaces.RenewLocksResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.RenewLocksResult>
    {
        internal RenewLocksResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Messaging.EventGrid.Namespaces.FailedLockToken> FailedLockTokens { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SucceededLockTokens { get { throw null; } }
        protected virtual Azure.Messaging.EventGrid.Namespaces.RenewLocksResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Messaging.EventGrid.Namespaces.RenewLocksResult (Azure.Response result) { throw null; }
        public static implicit operator Azure.Core.RequestContent (Azure.Messaging.EventGrid.Namespaces.RenewLocksResult renewLocksResult) { throw null; }
        protected virtual Azure.Messaging.EventGrid.Namespaces.RenewLocksResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Messaging.EventGrid.Namespaces.RenewLocksResult System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.Namespaces.RenewLocksResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.Namespaces.RenewLocksResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.Namespaces.RenewLocksResult System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.RenewLocksResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.RenewLocksResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.Namespaces.RenewLocksResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class EventGridNamespacesClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Messaging.EventGrid.Namespaces.EventGridReceiverClient, Azure.Messaging.EventGrid.Namespaces.EventGridReceiverClientOptions> AddEventGridReceiverClient<TBuilder>(this TBuilder builder, System.Uri endpoint, string topicName, string subscriptionName) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Messaging.EventGrid.Namespaces.EventGridReceiverClient, Azure.Messaging.EventGrid.Namespaces.EventGridReceiverClientOptions> AddEventGridReceiverClient<TBuilder>(this TBuilder builder, System.Uri endpoint, string topicName, string subscriptionName, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        [System.Diagnostics.CodeAnalysis.RequiresDynamicCodeAttribute("Binding strongly typed objects to configuration values requires generating dynamic code at runtime, for example instantiating generic types. Use the Configuration Binder Source Generator (EnableConfigurationBindingGenerator=true) instead.")]
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Messaging.EventGrid.Namespaces.EventGridReceiverClient, Azure.Messaging.EventGrid.Namespaces.EventGridReceiverClientOptions> AddEventGridReceiverClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Messaging.EventGrid.Namespaces.EventGridSenderClient, Azure.Messaging.EventGrid.Namespaces.EventGridSenderClientOptions> AddEventGridSenderClient<TBuilder>(this TBuilder builder, System.Uri endpoint, string topicName) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Messaging.EventGrid.Namespaces.EventGridSenderClient, Azure.Messaging.EventGrid.Namespaces.EventGridSenderClientOptions> AddEventGridSenderClient<TBuilder>(this TBuilder builder, System.Uri endpoint, string topicName, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        [System.Diagnostics.CodeAnalysis.RequiresDynamicCodeAttribute("Binding strongly typed objects to configuration values requires generating dynamic code at runtime, for example instantiating generic types. Use the Configuration Binder Source Generator (EnableConfigurationBindingGenerator=true) instead.")]
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Messaging.EventGrid.Namespaces.EventGridSenderClient, Azure.Messaging.EventGrid.Namespaces.EventGridSenderClientOptions> AddEventGridSenderClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
