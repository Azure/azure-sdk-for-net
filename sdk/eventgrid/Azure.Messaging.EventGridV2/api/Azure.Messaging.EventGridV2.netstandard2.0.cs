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
        public int DeliveryAttemptCount { get { throw null; } }
        public string LockToken { get { throw null; } }
    }
    public partial class EventGridClient
    {
        protected EventGridClient() { }
        public EventGridClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public EventGridClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.Messaging.EventGrid.Namespaces.EventGridClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response AcknowledgeCloudEvents(string topicName, string eventSubscriptionName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Messaging.EventGrid.Namespaces.AcknowledgeResult> AcknowledgeCloudEvents(string topicName, string eventSubscriptionName, System.Collections.Generic.IEnumerable<string> lockTokens, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AcknowledgeCloudEventsAsync(string topicName, string eventSubscriptionName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.EventGrid.Namespaces.AcknowledgeResult>> AcknowledgeCloudEventsAsync(string topicName, string eventSubscriptionName, System.Collections.Generic.IEnumerable<string> lockTokens, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response PublishCloudEvent(string topicName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Messaging.EventGrid.Namespaces.PublishResult> PublishCloudEvent(string topicName, Azure.Messaging.CloudEvent @event, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PublishCloudEventAsync(string topicName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.EventGrid.Namespaces.PublishResult>> PublishCloudEventAsync(string topicName, Azure.Messaging.CloudEvent @event, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response PublishCloudEvents(string topicName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Messaging.EventGrid.Namespaces.PublishResult> PublishCloudEvents(string topicName, object events, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PublishCloudEventsAsync(string topicName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.EventGrid.Namespaces.PublishResult>> PublishCloudEventsAsync(string topicName, object events, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ReceiveCloudEvents(string topicName, string eventSubscriptionName, int? maxEvents, int? maxWaitTime, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Messaging.EventGrid.Namespaces.ReceiveResult> ReceiveCloudEvents(string topicName, string eventSubscriptionName, int? maxEvents = default(int?), int? maxWaitTime = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ReceiveCloudEventsAsync(string topicName, string eventSubscriptionName, int? maxEvents, int? maxWaitTime, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.EventGrid.Namespaces.ReceiveResult>> ReceiveCloudEventsAsync(string topicName, string eventSubscriptionName, int? maxEvents = default(int?), int? maxWaitTime = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RejectCloudEvents(string topicName, string eventSubscriptionName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Messaging.EventGrid.Namespaces.RejectResult> RejectCloudEvents(string topicName, string eventSubscriptionName, System.Collections.Generic.IEnumerable<string> lockTokens, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RejectCloudEventsAsync(string topicName, string eventSubscriptionName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.EventGrid.Namespaces.RejectResult>> RejectCloudEventsAsync(string topicName, string eventSubscriptionName, System.Collections.Generic.IEnumerable<string> lockTokens, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ReleaseCloudEvents(string topicName, string eventSubscriptionName, Azure.Core.RequestContent content, int? eventDeliveryDelayInSeconds = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Messaging.EventGrid.Namespaces.ReleaseResult> ReleaseCloudEvents(string topicName, string eventSubscriptionName, System.Collections.Generic.IEnumerable<string> lockTokens, int? eventDeliveryDelayInSeconds = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ReleaseCloudEventsAsync(string topicName, string eventSubscriptionName, Azure.Core.RequestContent content, int? eventDeliveryDelayInSeconds = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.EventGrid.Namespaces.ReleaseResult>> ReleaseCloudEventsAsync(string topicName, string eventSubscriptionName, System.Collections.Generic.IEnumerable<string> lockTokens, int? eventDeliveryDelayInSeconds = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EventGridClientOptions : Azure.Core.ClientOptions
    {
        public EventGridClientOptions(Azure.Messaging.EventGrid.Namespaces.EventGridClientOptions.ServiceVersion version = Azure.Messaging.EventGrid.Namespaces.EventGridClientOptions.ServiceVersion.V2023_06_01_Preview) { }
        public enum ServiceVersion
        {
            V2023_06_01_Preview = 1,
        }
    }
    public partial class FailedLockToken
    {
        internal FailedLockToken() { }
        public string ErrorCode { get { throw null; } }
        public string ErrorDescription { get { throw null; } }
        public string LockToken { get { throw null; } }
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
}
