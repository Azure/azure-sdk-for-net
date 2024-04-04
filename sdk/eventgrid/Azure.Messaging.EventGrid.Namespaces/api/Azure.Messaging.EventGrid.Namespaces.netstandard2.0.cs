namespace Azure.Messaging.EventGrid.Namespaces
{
    public partial class AcknowledgeOptions
    {
        public AcknowledgeOptions(System.Collections.Generic.IEnumerable<string> lockTokens) { }
        public System.Collections.Generic.IList<string> LockTokens { get { throw null; } }
    }
    public partial class AcknowledgeResult
    {
        internal AcknowledgeResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Messaging.EventGrid.Namespaces.FailedLockToken> FailedLockTokens { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SucceededLockTokens { get { throw null; } }
    }
    public partial class BrokerProperties
    {
        internal BrokerProperties() { }
        public int DeliveryCount { get { throw null; } }
        public string LockToken { get { throw null; } }
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
        public virtual Azure.Response<Azure.Messaging.EventGrid.Namespaces.PublishResult> PublishCloudEvent(string topicName, Azure.Messaging.CloudEvent @event, bool binaryMode = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.EventGrid.Namespaces.PublishResult>> PublishCloudEventAsync(string topicName, Azure.Messaging.CloudEvent @event, bool binaryMode = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Messaging.EventGrid.Namespaces.PublishResult> PublishCloudEvents(string topicName, System.Collections.Generic.IEnumerable<Azure.Messaging.CloudEvent> events, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.EventGrid.Namespaces.PublishResult>> PublishCloudEventsAsync(string topicName, System.Collections.Generic.IEnumerable<Azure.Messaging.CloudEvent> events, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class FailedLockToken
    {
        internal FailedLockToken() { }
        public Azure.ResponseError Error { get { throw null; } }
        public string LockToken { get { throw null; } }
    }
    public static partial class MessagingEventGridNamespacesModelFactory
    {
        public static Azure.Messaging.EventGrid.Namespaces.AcknowledgeResult AcknowledgeResult(System.Collections.Generic.IEnumerable<Azure.Messaging.EventGrid.Namespaces.FailedLockToken> failedLockTokens = null, System.Collections.Generic.IEnumerable<string> succeededLockTokens = null) { throw null; }
        public static Azure.Messaging.EventGrid.Namespaces.BrokerProperties BrokerProperties(string lockToken = null, int deliveryCount = 0) { throw null; }
        public static Azure.Messaging.EventGrid.Namespaces.FailedLockToken FailedLockToken(string lockToken = null, Azure.ResponseError error = null) { throw null; }
        public static Azure.Messaging.EventGrid.Namespaces.RejectResult RejectResult(System.Collections.Generic.IEnumerable<Azure.Messaging.EventGrid.Namespaces.FailedLockToken> failedLockTokens = null, System.Collections.Generic.IEnumerable<string> succeededLockTokens = null) { throw null; }
        public static Azure.Messaging.EventGrid.Namespaces.ReleaseResult ReleaseResult(System.Collections.Generic.IEnumerable<Azure.Messaging.EventGrid.Namespaces.FailedLockToken> failedLockTokens = null, System.Collections.Generic.IEnumerable<string> succeededLockTokens = null) { throw null; }
        public static Azure.Messaging.EventGrid.Namespaces.RenewCloudEventLocksResult RenewCloudEventLocksResult(System.Collections.Generic.IEnumerable<Azure.Messaging.EventGrid.Namespaces.FailedLockToken> failedLockTokens = null, System.Collections.Generic.IEnumerable<string> succeededLockTokens = null) { throw null; }
    }
    public partial class PublishResult
    {
        internal PublishResult() { }
    }
    public partial class ReceiveDetails
    {
        internal ReceiveDetails() { }
        public Azure.Messaging.EventGrid.Namespaces.BrokerProperties BrokerProperties { get { throw null; } }
        public Azure.Messaging.CloudEvent Event { get { throw null; } }
    }
    public partial class ReceiveResult
    {
        internal ReceiveResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Messaging.EventGrid.Namespaces.ReceiveDetails> Value { get { throw null; } }
    }
    public partial class RejectOptions
    {
        public RejectOptions(System.Collections.Generic.IEnumerable<string> lockTokens) { }
        public System.Collections.Generic.IList<string> LockTokens { get { throw null; } }
    }
    public partial class RejectResult
    {
        internal RejectResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Messaging.EventGrid.Namespaces.FailedLockToken> FailedLockTokens { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SucceededLockTokens { get { throw null; } }
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
    public partial class ReleaseOptions
    {
        public ReleaseOptions(System.Collections.Generic.IEnumerable<string> lockTokens) { }
        public System.Collections.Generic.IList<string> LockTokens { get { throw null; } }
    }
    public partial class ReleaseResult
    {
        internal ReleaseResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Messaging.EventGrid.Namespaces.FailedLockToken> FailedLockTokens { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SucceededLockTokens { get { throw null; } }
    }
    public partial class RenewCloudEventLocksResult
    {
        internal RenewCloudEventLocksResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Messaging.EventGrid.Namespaces.FailedLockToken> FailedLockTokens { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SucceededLockTokens { get { throw null; } }
    }
    public partial class RenewLockOptions
    {
        public RenewLockOptions(System.Collections.Generic.IEnumerable<string> lockTokens) { }
        public System.Collections.Generic.IList<string> LockTokens { get { throw null; } }
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
