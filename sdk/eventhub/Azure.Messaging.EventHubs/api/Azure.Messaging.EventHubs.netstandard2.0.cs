namespace Azure.Messaging.EventHubs
{
    public partial class EventData : Azure.Messaging.MessageContent
    {
        public EventData() { }
        public EventData(Azure.Core.Amqp.AmqpAnnotatedMessage amqpMessage) { }
        public EventData(System.BinaryData eventBody) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("The Event Hubs service does not guarantee a numeric offset for all resource configurations.  Please use the overload with a string-based offset instead.", false)]
        protected EventData(System.BinaryData eventBody, System.Collections.Generic.IDictionary<string, object> properties = null, System.Collections.Generic.IReadOnlyDictionary<string, object> systemProperties = null, long sequenceNumber = (long)-9223372036854775808, long offset = (long)-9223372036854775808, System.DateTimeOffset enqueuedTime = default(System.DateTimeOffset), string partitionKey = null) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        protected EventData(System.BinaryData eventBody, System.Collections.Generic.IDictionary<string, object> properties = null, System.Collections.Generic.IReadOnlyDictionary<string, object> systemProperties = null, long sequenceNumber = (long)-9223372036854775808, string offsetString = null, System.DateTimeOffset enqueuedTime = default(System.DateTimeOffset), string partitionKey = null) { }
        public EventData(System.ReadOnlyMemory<byte> eventBody) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("The Event Hubs service does not guarantee a numeric offset for all resource configurations.  Please use the overload with a string-based offset instead.")]
        protected EventData(System.ReadOnlyMemory<byte> eventBody, System.Collections.Generic.IDictionary<string, object> properties = null, System.Collections.Generic.IReadOnlyDictionary<string, object> systemProperties = null, long sequenceNumber = (long)-9223372036854775808, long offset = (long)-9223372036854775808, System.DateTimeOffset enqueuedTime = default(System.DateTimeOffset), string partitionKey = null) { }
        public EventData(string eventBody) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.ReadOnlyMemory<byte> Body { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.IO.Stream BodyAsStream { get { throw null; } }
        public new string ContentType { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        protected override Azure.Core.ContentType? ContentTypeCore { get { throw null; } set { } }
        public string CorrelationId { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override System.BinaryData Data { get { throw null; } set { } }
        public System.DateTimeOffset EnqueuedTime { get { throw null; } }
        public System.BinaryData EventBody { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool IsReadOnly { get { throw null; } }
        public string MessageId { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("The Event Hubs service does not guarantee a numeric offset for all resource configurations.  Please use 'OffsetString' instead.", false)]
        public long Offset { get { throw null; } }
        public string OffsetString { get { throw null; } }
        public string PartitionKey { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, object> Properties { get { throw null; } }
        public long SequenceNumber { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, object> SystemProperties { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public Azure.Core.Amqp.AmqpAnnotatedMessage GetRawAmqpMessage() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public partial class EventHubConnection : System.IAsyncDisposable
    {
        protected EventHubConnection() { }
        public EventHubConnection(string connectionString) { }
        public EventHubConnection(string connectionString, Azure.Messaging.EventHubs.EventHubConnectionOptions connectionOptions) { }
        public EventHubConnection(string connectionString, string eventHubName) { }
        public EventHubConnection(string fullyQualifiedNamespace, string eventHubName, Azure.AzureNamedKeyCredential credential, Azure.Messaging.EventHubs.EventHubConnectionOptions connectionOptions = null) { }
        public EventHubConnection(string fullyQualifiedNamespace, string eventHubName, Azure.AzureSasCredential credential, Azure.Messaging.EventHubs.EventHubConnectionOptions connectionOptions = null) { }
        public EventHubConnection(string fullyQualifiedNamespace, string eventHubName, Azure.Core.TokenCredential credential, Azure.Messaging.EventHubs.EventHubConnectionOptions connectionOptions = null) { }
        public EventHubConnection(string connectionString, string eventHubName, Azure.Messaging.EventHubs.EventHubConnectionOptions connectionOptions) { }
        public string EventHubName { get { throw null; } }
        public string FullyQualifiedNamespace { get { throw null; } }
        public bool IsClosed { get { throw null; } }
        public virtual System.Threading.Tasks.Task CloseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.ValueTask DisposeAsync() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public partial class EventHubConnectionOptions
    {
        public EventHubConnectionOptions() { }
        public System.Net.Security.RemoteCertificateValidationCallback CertificateValidationCallback { get { throw null; } set { } }
        public System.TimeSpan ConnectionIdleTimeout { get { throw null; } set { } }
        public System.Uri CustomEndpointAddress { get { throw null; } set { } }
        public System.Net.IWebProxy Proxy { get { throw null; } set { } }
        public int ReceiveBufferSizeInBytes { get { throw null; } set { } }
        public int SendBufferSizeInBytes { get { throw null; } set { } }
        public Azure.Messaging.EventHubs.EventHubsTransportType TransportType { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public partial class EventHubProperties
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        protected EventHubProperties(string name, System.DateTimeOffset createdOn, string[] partitionIds) { }
        protected internal EventHubProperties(string name, System.DateTimeOffset createdOn, string[] partitionIds, bool isGeoReplicationEnabled) { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public bool IsGeoReplicationEnabled { get { throw null; } }
        public string Name { get { throw null; } }
        public string[] PartitionIds { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public partial class EventHubsConnectionStringProperties
    {
        public EventHubsConnectionStringProperties() { }
        public System.Uri Endpoint { get { throw null; } }
        public string EventHubName { get { throw null; } }
        public string FullyQualifiedNamespace { get { throw null; } }
        public string SharedAccessKey { get { throw null; } }
        public string SharedAccessKeyName { get { throw null; } }
        public string SharedAccessSignature { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static Azure.Messaging.EventHubs.EventHubsConnectionStringProperties Parse(string connectionString) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public partial class EventHubsException : System.Exception
    {
        public EventHubsException(bool isTransient, string eventHubName) { }
        public EventHubsException(bool isTransient, string eventHubName, Azure.Messaging.EventHubs.EventHubsException.FailureReason reason) { }
        public EventHubsException(bool isTransient, string eventHubName, string message) { }
        public EventHubsException(bool isTransient, string eventHubName, string message, Azure.Messaging.EventHubs.EventHubsException.FailureReason reason) { }
        public EventHubsException(bool isTransient, string eventHubName, string message, Azure.Messaging.EventHubs.EventHubsException.FailureReason reason, System.Exception innerException) { }
        public EventHubsException(bool isTransient, string eventHubName, string message, System.Exception innerException) { }
        public EventHubsException(string eventHubName, string message, Azure.Messaging.EventHubs.EventHubsException.FailureReason reason) { }
        public string EventHubName { get { throw null; } }
        public bool IsTransient { get { throw null; } }
        public override string Message { get { throw null; } }
        public Azure.Messaging.EventHubs.EventHubsException.FailureReason Reason { get { throw null; } }
        public override string ToString() { throw null; }
        public enum FailureReason
        {
            GeneralError = 0,
            ClientClosed = 1,
            ConsumerDisconnected = 2,
            ResourceNotFound = 3,
            MessageSizeExceeded = 4,
            QuotaExceeded = 5,
            ServiceBusy = 6,
            ServiceTimeout = 7,
            ServiceCommunicationProblem = 8,
            ProducerDisconnected = 9,
            InvalidClientState = 10,
        }
    }
    public static partial class EventHubsModelFactory
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("The Event Hubs service does not guarantee a numeric offset for all resource configurations.  Please use the overload with a string-based offset instead.", false)]
        public static Azure.Messaging.EventHubs.EventData EventData(System.BinaryData eventBody, System.Collections.Generic.IDictionary<string, object> properties = null, System.Collections.Generic.IReadOnlyDictionary<string, object> systemProperties = null, string partitionKey = null, long sequenceNumber = (long)-9223372036854775808, long offset = (long)-9223372036854775808, System.DateTimeOffset enqueuedTime = default(System.DateTimeOffset)) { throw null; }
        public static Azure.Messaging.EventHubs.EventData EventData(System.BinaryData eventBody, System.Collections.Generic.IDictionary<string, object> properties = null, System.Collections.Generic.IReadOnlyDictionary<string, object> systemProperties = null, string partitionKey = null, long sequenceNumber = (long)-9223372036854775808, string offsetString = null, System.DateTimeOffset enqueuedTime = default(System.DateTimeOffset)) { throw null; }
        public static Azure.Messaging.EventHubs.Producer.EventDataBatch EventDataBatch(long batchSizeBytes, System.Collections.Generic.IList<Azure.Messaging.EventHubs.EventData> batchEventStore, Azure.Messaging.EventHubs.Producer.CreateBatchOptions batchOptions = null, System.Func<Azure.Messaging.EventHubs.EventData, bool> tryAddCallback = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Messaging.EventHubs.EventHubProperties EventHubProperties(string name, System.DateTimeOffset createdOn, string[] partitionIds) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Messaging.EventHubs.EventHubProperties EventHubProperties(string name, System.DateTimeOffset createdOn, string[] partitionIds, bool isGeoReplicationEnabled) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("The Event Hubs service does not guarantee a numeric offset for all resource configurations.  Please use the overload with a string-based offset instead.", false)]
        public static Azure.Messaging.EventHubs.Consumer.LastEnqueuedEventProperties LastEnqueuedEventProperties(long? lastSequenceNumber, long? lastOffset, System.DateTimeOffset? lastEnqueuedTime, System.DateTimeOffset? lastReceivedTime) { throw null; }
        public static Azure.Messaging.EventHubs.Consumer.LastEnqueuedEventProperties LastEnqueuedEventProperties(long? lastSequenceNumber, string lastOffsetString, System.DateTimeOffset? lastEnqueuedTime, System.DateTimeOffset? lastReceivedTime) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Messaging.EventHubs.Consumer.PartitionContext PartitionContext(string partitionId, Azure.Messaging.EventHubs.Consumer.LastEnqueuedEventProperties lastEnqueuedEventProperties = default(Azure.Messaging.EventHubs.Consumer.LastEnqueuedEventProperties)) { throw null; }
        public static Azure.Messaging.EventHubs.Consumer.PartitionContext PartitionContext(string fullyQualifiedNamespace, string eventHubName, string consumerGroup, string partitionId, Azure.Messaging.EventHubs.Consumer.LastEnqueuedEventProperties lastEnqueuedEventProperties = default(Azure.Messaging.EventHubs.Consumer.LastEnqueuedEventProperties)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("The Event Hubs service does not guarantee a numeric offset for all resource configurations.  Please use the overload with a string-based offset instead.", false)]
        public static Azure.Messaging.EventHubs.PartitionProperties PartitionProperties(string eventHubName, string partitionId, bool isEmpty, long beginningSequenceNumber, long lastSequenceNumber, long lastOffset, System.DateTimeOffset lastEnqueuedTime) { throw null; }
        public static Azure.Messaging.EventHubs.PartitionProperties PartitionProperties(string eventHubName, string partitionId, bool isEmpty, long beginningSequenceNumber, long lastSequenceNumber, string lastOffsetString, System.DateTimeOffset lastEnqueuedTime) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Messaging.EventHubs.Producer.PartitionPublishingProperties PartitionPublishingProperties(bool isIdempotentPublishingEnabled, long? producerGroupId, short? ownerLevel, int? lastPublishedSequenceNumber) { throw null; }
    }
    public enum EventHubsRetryMode
    {
        Fixed = 0,
        Exponential = 1,
    }
    public partial class EventHubsRetryOptions
    {
        public EventHubsRetryOptions() { }
        public Azure.Messaging.EventHubs.EventHubsRetryPolicy CustomRetryPolicy { get { throw null; } set { } }
        public System.TimeSpan Delay { get { throw null; } set { } }
        public System.TimeSpan MaximumDelay { get { throw null; } set { } }
        public int MaximumRetries { get { throw null; } set { } }
        public Azure.Messaging.EventHubs.EventHubsRetryMode Mode { get { throw null; } set { } }
        public System.TimeSpan TryTimeout { get { throw null; } set { } }
    }
    public abstract partial class EventHubsRetryPolicy
    {
        protected EventHubsRetryPolicy() { }
        public abstract System.TimeSpan? CalculateRetryDelay(System.Exception lastException, int attemptCount);
        public abstract System.TimeSpan CalculateTryTimeout(int attemptCount);
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public enum EventHubsTransportType
    {
        AmqpTcp = 0,
        AmqpWebSockets = 1,
    }
    public partial class PartitionProperties
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("The Event Hubs service does not guarantee a numeric offset for all resource configurations.  Please use the overload with a string-based offset instead.", false)]
        protected internal PartitionProperties(string eventHubName, string partitionId, bool isEmpty, long beginningSequenceNumber, long lastSequenceNumber, long lastOffset, System.DateTimeOffset lastEnqueuedTime) { }
        protected internal PartitionProperties(string eventHubName, string partitionId, bool isEmpty, long beginningSequenceNumber, long lastSequenceNumber, string lastOffsetString, System.DateTimeOffset lastEnqueuedTime) { }
        public long BeginningSequenceNumber { get { throw null; } }
        public string EventHubName { get { throw null; } }
        public string Id { get { throw null; } }
        public bool IsEmpty { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("The Event Hubs service does not guarantee a numeric offset for all resource configurations.  Please use 'LastEnqueuedOffsetString' instead.", false)]
        public long LastEnqueuedOffset { get { throw null; } }
        public string LastEnqueuedOffsetString { get { throw null; } }
        public long LastEnqueuedSequenceNumber { get { throw null; } }
        public System.DateTimeOffset LastEnqueuedTime { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
}
namespace Azure.Messaging.EventHubs.Consumer
{
    public partial class EventHubConsumerClient : System.IAsyncDisposable
    {
        public const string DefaultConsumerGroupName = "$Default";
        protected EventHubConsumerClient() { }
        public EventHubConsumerClient(string consumerGroup, Azure.Messaging.EventHubs.EventHubConnection connection, Azure.Messaging.EventHubs.Consumer.EventHubConsumerClientOptions clientOptions = null) { }
        public EventHubConsumerClient(string consumerGroup, string connectionString) { }
        public EventHubConsumerClient(string consumerGroup, string connectionString, Azure.Messaging.EventHubs.Consumer.EventHubConsumerClientOptions clientOptions) { }
        public EventHubConsumerClient(string consumerGroup, string connectionString, string eventHubName) { }
        public EventHubConsumerClient(string consumerGroup, string fullyQualifiedNamespace, string eventHubName, Azure.AzureNamedKeyCredential credential, Azure.Messaging.EventHubs.Consumer.EventHubConsumerClientOptions clientOptions = null) { }
        public EventHubConsumerClient(string consumerGroup, string fullyQualifiedNamespace, string eventHubName, Azure.AzureSasCredential credential, Azure.Messaging.EventHubs.Consumer.EventHubConsumerClientOptions clientOptions = null) { }
        public EventHubConsumerClient(string consumerGroup, string fullyQualifiedNamespace, string eventHubName, Azure.Core.TokenCredential credential, Azure.Messaging.EventHubs.Consumer.EventHubConsumerClientOptions clientOptions = null) { }
        public EventHubConsumerClient(string consumerGroup, string connectionString, string eventHubName, Azure.Messaging.EventHubs.Consumer.EventHubConsumerClientOptions clientOptions) { }
        public string ConsumerGroup { get { throw null; } }
        public string EventHubName { get { throw null; } }
        public string FullyQualifiedNamespace { get { throw null; } }
        public string Identifier { get { throw null; } }
        public bool IsClosed { get { throw null; } protected set { } }
        public virtual System.Threading.Tasks.Task CloseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.ValueTask DisposeAsync() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Messaging.EventHubs.EventHubProperties> GetEventHubPropertiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public virtual System.Threading.Tasks.Task<string[]> GetPartitionIdsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Messaging.EventHubs.PartitionProperties> GetPartitionPropertiesAsync(string partitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IAsyncEnumerable<Azure.Messaging.EventHubs.Consumer.PartitionEvent> ReadEventsAsync(Azure.Messaging.EventHubs.Consumer.ReadEventOptions readOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IAsyncEnumerable<Azure.Messaging.EventHubs.Consumer.PartitionEvent> ReadEventsAsync(bool startReadingAtEarliestEvent, Azure.Messaging.EventHubs.Consumer.ReadEventOptions readOptions = null, [System.Runtime.CompilerServices.EnumeratorCancellationAttribute] System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IAsyncEnumerable<Azure.Messaging.EventHubs.Consumer.PartitionEvent> ReadEventsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IAsyncEnumerable<Azure.Messaging.EventHubs.Consumer.PartitionEvent> ReadEventsFromPartitionAsync(string partitionId, Azure.Messaging.EventHubs.Consumer.EventPosition startingPosition, Azure.Messaging.EventHubs.Consumer.ReadEventOptions readOptions, [System.Runtime.CompilerServices.EnumeratorCancellationAttribute] System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IAsyncEnumerable<Azure.Messaging.EventHubs.Consumer.PartitionEvent> ReadEventsFromPartitionAsync(string partitionId, Azure.Messaging.EventHubs.Consumer.EventPosition startingPosition, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public partial class EventHubConsumerClientOptions
    {
        public EventHubConsumerClientOptions() { }
        public Azure.Messaging.EventHubs.EventHubConnectionOptions ConnectionOptions { get { throw null; } set { } }
        public string Identifier { get { throw null; } set { } }
        public Azure.Messaging.EventHubs.EventHubsRetryOptions RetryOptions { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public partial struct EventPosition : System.IEquatable<Azure.Messaging.EventHubs.Consumer.EventPosition>
    {
        private object _dummy;
        private int _dummyPrimitive;
        public static Azure.Messaging.EventHubs.Consumer.EventPosition Earliest { get { throw null; } }
        public static Azure.Messaging.EventHubs.Consumer.EventPosition Latest { get { throw null; } }
        public bool Equals(Azure.Messaging.EventHubs.Consumer.EventPosition other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        public static Azure.Messaging.EventHubs.Consumer.EventPosition FromEnqueuedTime(System.DateTimeOffset enqueuedTime) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("The Event Hubs service does not guarantee a numeric offset for all resource configurations.  Reading events using a numeric offset may not work in all cases going forward. Please use a string-based offset instead.", false)]
        public static Azure.Messaging.EventHubs.Consumer.EventPosition FromOffset(long offset, bool isInclusive = true) { throw null; }
        public static Azure.Messaging.EventHubs.Consumer.EventPosition FromOffset(string offsetString, bool isInclusive = true) { throw null; }
        public static Azure.Messaging.EventHubs.Consumer.EventPosition FromSequenceNumber(long sequenceNumber, bool isInclusive = true) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.EventHubs.Consumer.EventPosition left, Azure.Messaging.EventHubs.Consumer.EventPosition right) { throw null; }
        public static bool operator !=(Azure.Messaging.EventHubs.Consumer.EventPosition left, Azure.Messaging.EventHubs.Consumer.EventPosition right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public partial struct LastEnqueuedEventProperties : System.IEquatable<Azure.Messaging.EventHubs.Consumer.LastEnqueuedEventProperties>
    {
        private object _dummy;
        private int _dummyPrimitive;
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("The Event Hubs service does not guarantee a numeric offset for all resource configurations.  Please use the overload with a string-based offset instead.", false)]
        public LastEnqueuedEventProperties(long? lastSequenceNumber, long lastOffset, System.DateTimeOffset? lastEnqueuedTime, System.DateTimeOffset? lastReceivedTime) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("The Event Hubs service does not guarantee a numeric offset for all resource configurations.  Please use the overload with a string-based offset instead.", false)]
        public LastEnqueuedEventProperties(long? lastSequenceNumber, long? lastOffset, System.DateTimeOffset? lastEnqueuedTime, System.DateTimeOffset? lastReceivedTime) { throw null; }
        public LastEnqueuedEventProperties(long? lastSequenceNumber, string lastOffsetString, System.DateTimeOffset? lastEnqueuedTime, System.DateTimeOffset? lastReceivedTime) { throw null; }
        public System.DateTimeOffset? EnqueuedTime { get { throw null; } }
        public System.DateTimeOffset? LastReceivedTime { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("The Event Hubs service does not guarantee a numeric offset for all resource configurations.  Please use 'OffsetString' instead.", false)]
        public long? Offset { get { throw null; } }
        public string OffsetString { get { throw null; } }
        public long? SequenceNumber { get { throw null; } }
        public bool Equals(Azure.Messaging.EventHubs.Consumer.LastEnqueuedEventProperties other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.EventHubs.Consumer.LastEnqueuedEventProperties left, Azure.Messaging.EventHubs.Consumer.LastEnqueuedEventProperties right) { throw null; }
        public static bool operator !=(Azure.Messaging.EventHubs.Consumer.LastEnqueuedEventProperties left, Azure.Messaging.EventHubs.Consumer.LastEnqueuedEventProperties right) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public partial class PartitionContext
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        protected PartitionContext(string partitionId) { }
        protected internal PartitionContext(string fullyQualifiedNamespace, string eventHubName, string consumerGroup, string partitionId) { }
        public string ConsumerGroup { get { throw null; } }
        public string EventHubName { get { throw null; } }
        public string FullyQualifiedNamespace { get { throw null; } }
        public string PartitionId { get { throw null; } }
        public virtual Azure.Messaging.EventHubs.Consumer.LastEnqueuedEventProperties ReadLastEnqueuedEventProperties() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public partial struct PartitionEvent
    {
        private object _dummy;
        private int _dummyPrimitive;
        public PartitionEvent(Azure.Messaging.EventHubs.Consumer.PartitionContext partition, Azure.Messaging.EventHubs.EventData data) { throw null; }
        public Azure.Messaging.EventHubs.EventData Data { get { throw null; } }
        public Azure.Messaging.EventHubs.Consumer.PartitionContext Partition { get { throw null; } }
    }
    public partial class ReadEventOptions
    {
        public ReadEventOptions() { }
        public int CacheEventCount { get { throw null; } set { } }
        public System.TimeSpan? MaximumWaitTime { get { throw null; } set { } }
        public long? OwnerLevel { get { throw null; } set { } }
        public int PrefetchCount { get { throw null; } set { } }
        public long? PrefetchSizeInBytes { get { throw null; } set { } }
        public bool TrackLastEnqueuedEventProperties { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
}
namespace Azure.Messaging.EventHubs.Primitives
{
    public abstract partial class CheckpointStore
    {
        protected CheckpointStore() { }
        public abstract System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Messaging.EventHubs.Primitives.EventProcessorPartitionOwnership>> ClaimOwnershipAsync(System.Collections.Generic.IEnumerable<Azure.Messaging.EventHubs.Primitives.EventProcessorPartitionOwnership> desiredOwnership, System.Threading.CancellationToken cancellationToken);
        public abstract System.Threading.Tasks.Task<Azure.Messaging.EventHubs.Primitives.EventProcessorCheckpoint> GetCheckpointAsync(string fullyQualifiedNamespace, string eventHubName, string consumerGroup, string partitionId, System.Threading.CancellationToken cancellationToken);
        public abstract System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Messaging.EventHubs.Primitives.EventProcessorPartitionOwnership>> ListOwnershipAsync(string fullyQualifiedNamespace, string eventHubName, string consumerGroup, System.Threading.CancellationToken cancellationToken);
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("The Event Hubs service does not guarantee a numeric offset for all resource configurations.  Checkpoints created from a numeric offset may not work in all cases going forward. Please use a string-based offset via the overload accepting 'CheckpointPosition' instead.", false)]
        public virtual System.Threading.Tasks.Task UpdateCheckpointAsync(string fullyQualifiedNamespace, string eventHubName, string consumerGroup, string partitionId, long offset, long? sequenceNumber, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task UpdateCheckpointAsync(string fullyQualifiedNamespace, string eventHubName, string consumerGroup, string partitionId, string clientIdentifier, Azure.Messaging.EventHubs.Processor.CheckpointPosition startingPosition, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class EventProcessorCheckpoint
    {
        public EventProcessorCheckpoint() { }
        public string ClientIdentifier { get { throw null; } set { } }
        public string ConsumerGroup { get { throw null; } set { } }
        public string EventHubName { get { throw null; } set { } }
        public string FullyQualifiedNamespace { get { throw null; } set { } }
        public System.DateTimeOffset? LastModified { get { throw null; } set { } }
        public string PartitionId { get { throw null; } set { } }
        public Azure.Messaging.EventHubs.Consumer.EventPosition StartingPosition { get { throw null; } set { } }
    }
    public partial class EventProcessorOptions
    {
        public EventProcessorOptions() { }
        public Azure.Messaging.EventHubs.EventHubConnectionOptions ConnectionOptions { get { throw null; } set { } }
        public Azure.Messaging.EventHubs.Consumer.EventPosition DefaultStartingPosition { get { throw null; } set { } }
        public string Identifier { get { throw null; } set { } }
        public Azure.Messaging.EventHubs.Processor.LoadBalancingStrategy LoadBalancingStrategy { get { throw null; } set { } }
        public System.TimeSpan LoadBalancingUpdateInterval { get { throw null; } set { } }
        public System.TimeSpan? MaximumWaitTime { get { throw null; } set { } }
        public System.TimeSpan PartitionOwnershipExpirationInterval { get { throw null; } set { } }
        public int PrefetchCount { get { throw null; } set { } }
        public long? PrefetchSizeInBytes { get { throw null; } set { } }
        public Azure.Messaging.EventHubs.EventHubsRetryOptions RetryOptions { get { throw null; } set { } }
        public bool TrackLastEnqueuedEventProperties { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public partial class EventProcessorPartition
    {
        public EventProcessorPartition() { }
        public string PartitionId { get { throw null; } protected internal set { } }
    }
    public partial class EventProcessorPartitionOwnership
    {
        public EventProcessorPartitionOwnership() { }
        public string ConsumerGroup { get { throw null; } set { } }
        public string EventHubName { get { throw null; } set { } }
        public string FullyQualifiedNamespace { get { throw null; } set { } }
        public System.DateTimeOffset LastModifiedTime { get { throw null; } set { } }
        public string OwnerIdentifier { get { throw null; } set { } }
        public string PartitionId { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public abstract partial class EventProcessor<TPartition> where TPartition : Azure.Messaging.EventHubs.Primitives.EventProcessorPartition, new()
    {
        protected EventProcessor() { }
        protected EventProcessor(int eventBatchMaximumCount, string consumerGroup, string connectionString, Azure.Messaging.EventHubs.Primitives.EventProcessorOptions options = null) { }
        protected EventProcessor(int eventBatchMaximumCount, string consumerGroup, string fullyQualifiedNamespace, string eventHubName, Azure.AzureNamedKeyCredential credential, Azure.Messaging.EventHubs.Primitives.EventProcessorOptions options = null) { }
        protected EventProcessor(int eventBatchMaximumCount, string consumerGroup, string fullyQualifiedNamespace, string eventHubName, Azure.AzureSasCredential credential, Azure.Messaging.EventHubs.Primitives.EventProcessorOptions options = null) { }
        protected EventProcessor(int eventBatchMaximumCount, string consumerGroup, string fullyQualifiedNamespace, string eventHubName, Azure.Core.TokenCredential credential, Azure.Messaging.EventHubs.Primitives.EventProcessorOptions options = null) { }
        protected EventProcessor(int eventBatchMaximumCount, string consumerGroup, string connectionString, string eventHubName, Azure.Messaging.EventHubs.Primitives.EventProcessorOptions options = null) { }
        public string ConsumerGroup { get { throw null; } }
        protected bool EnableBatchTracing { get { throw null; } set { } }
        public string EventHubName { get { throw null; } }
        protected Azure.Messaging.EventHubs.EventHubProperties EventHubProperties { get { throw null; } }
        public string FullyQualifiedNamespace { get { throw null; } }
        public string Identifier { get { throw null; } }
        public bool IsRunning { get { throw null; } protected set { } }
        protected Azure.Messaging.EventHubs.EventHubsRetryPolicy RetryPolicy { get { throw null; } }
        protected abstract System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Messaging.EventHubs.Primitives.EventProcessorPartitionOwnership>> ClaimOwnershipAsync(System.Collections.Generic.IEnumerable<Azure.Messaging.EventHubs.Primitives.EventProcessorPartitionOwnership> desiredOwnership, System.Threading.CancellationToken cancellationToken);
        protected internal virtual Azure.Messaging.EventHubs.EventHubConnection CreateConnection() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        protected virtual System.Threading.Tasks.Task<Azure.Messaging.EventHubs.Primitives.EventProcessorCheckpoint> GetCheckpointAsync(string partitionId, System.Threading.CancellationToken cancellationToken) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        protected virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Messaging.EventHubs.Primitives.EventProcessorCheckpoint>> ListCheckpointsAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        protected abstract System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Messaging.EventHubs.Primitives.EventProcessorPartitionOwnership>> ListOwnershipAsync(System.Threading.CancellationToken cancellationToken);
        protected virtual System.Threading.Tasks.Task<string[]> ListPartitionIdsAsync(Azure.Messaging.EventHubs.EventHubConnection connection, System.Threading.CancellationToken cancellationToken) { throw null; }
        protected virtual System.Threading.Tasks.Task OnInitializingPartitionAsync(TPartition partition, System.Threading.CancellationToken cancellationToken) { throw null; }
        protected virtual System.Threading.Tasks.Task OnPartitionProcessingStoppedAsync(TPartition partition, Azure.Messaging.EventHubs.Processor.ProcessingStoppedReason reason, System.Threading.CancellationToken cancellationToken) { throw null; }
        protected abstract System.Threading.Tasks.Task OnProcessingErrorAsync(System.Exception exception, TPartition partition, string operationDescription, System.Threading.CancellationToken cancellationToken);
        protected abstract System.Threading.Tasks.Task OnProcessingEventBatchAsync(System.Collections.Generic.IEnumerable<Azure.Messaging.EventHubs.EventData> events, TPartition partition, System.Threading.CancellationToken cancellationToken);
        protected virtual Azure.Messaging.EventHubs.Consumer.LastEnqueuedEventProperties ReadLastEnqueuedEventProperties(string partitionId) { throw null; }
        public virtual void StartProcessing(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public virtual System.Threading.Tasks.Task StartProcessingAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual void StopProcessing(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public virtual System.Threading.Tasks.Task StopProcessingAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
        protected virtual System.Threading.Tasks.Task UpdateCheckpointAsync(string partitionId, Azure.Messaging.EventHubs.Processor.CheckpointPosition startingPosition, System.Threading.CancellationToken cancellationToken) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("The Event Hubs service does not guarantee a numeric offset for all resource configurations.  Checkpoints created from a numeric offset may not work in all cases going forward. Please use a string-based offset via the overload accepting 'CheckpointPosition' instead.", false)]
        protected virtual System.Threading.Tasks.Task UpdateCheckpointAsync(string partitionId, long offset, long? sequenceNumber, System.Threading.CancellationToken cancellationToken) { throw null; }
        protected internal virtual System.Threading.Tasks.Task ValidateProcessingPreconditions(System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class PartitionReceiver : System.IAsyncDisposable
    {
        protected PartitionReceiver() { }
        public PartitionReceiver(string consumerGroup, string partitionId, Azure.Messaging.EventHubs.Consumer.EventPosition eventPosition, Azure.Messaging.EventHubs.EventHubConnection connection, Azure.Messaging.EventHubs.Primitives.PartitionReceiverOptions options = null) { }
        public PartitionReceiver(string consumerGroup, string partitionId, Azure.Messaging.EventHubs.Consumer.EventPosition eventPosition, string connectionString, Azure.Messaging.EventHubs.Primitives.PartitionReceiverOptions options = null) { }
        public PartitionReceiver(string consumerGroup, string partitionId, Azure.Messaging.EventHubs.Consumer.EventPosition eventPosition, string fullyQualifiedNamespace, string eventHubName, Azure.AzureNamedKeyCredential credential, Azure.Messaging.EventHubs.Primitives.PartitionReceiverOptions options = null) { }
        public PartitionReceiver(string consumerGroup, string partitionId, Azure.Messaging.EventHubs.Consumer.EventPosition eventPosition, string fullyQualifiedNamespace, string eventHubName, Azure.AzureSasCredential credential, Azure.Messaging.EventHubs.Primitives.PartitionReceiverOptions options = null) { }
        public PartitionReceiver(string consumerGroup, string partitionId, Azure.Messaging.EventHubs.Consumer.EventPosition eventPosition, string fullyQualifiedNamespace, string eventHubName, Azure.Core.TokenCredential credential, Azure.Messaging.EventHubs.Primitives.PartitionReceiverOptions options = null) { }
        public PartitionReceiver(string consumerGroup, string partitionId, Azure.Messaging.EventHubs.Consumer.EventPosition eventPosition, string connectionString, string eventHubName, Azure.Messaging.EventHubs.Primitives.PartitionReceiverOptions options = null) { }
        public string ConsumerGroup { get { throw null; } }
        public string EventHubName { get { throw null; } }
        public string FullyQualifiedNamespace { get { throw null; } }
        public string Identifier { get { throw null; } }
        public Azure.Messaging.EventHubs.Consumer.EventPosition InitialPosition { get { throw null; } }
        public bool IsClosed { get { throw null; } protected set { } }
        public string PartitionId { get { throw null; } }
        public virtual System.Threading.Tasks.Task CloseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.ValueTask DisposeAsync() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Messaging.EventHubs.PartitionProperties> GetPartitionPropertiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Messaging.EventHubs.Consumer.LastEnqueuedEventProperties ReadLastEnqueuedEventProperties() { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Messaging.EventHubs.EventData>> ReceiveBatchAsync(int maximumEventCount, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Messaging.EventHubs.EventData>> ReceiveBatchAsync(int maximumEventCount, System.TimeSpan maximumWaitTime, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public partial class PartitionReceiverOptions
    {
        public PartitionReceiverOptions() { }
        public Azure.Messaging.EventHubs.EventHubConnectionOptions ConnectionOptions { get { throw null; } set { } }
        public System.TimeSpan? DefaultMaximumReceiveWaitTime { get { throw null; } set { } }
        public string Identifier { get { throw null; } set { } }
        public long? OwnerLevel { get { throw null; } set { } }
        public int PrefetchCount { get { throw null; } set { } }
        public long? PrefetchSizeInBytes { get { throw null; } set { } }
        public Azure.Messaging.EventHubs.EventHubsRetryOptions RetryOptions { get { throw null; } set { } }
        public bool TrackLastEnqueuedEventProperties { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public abstract partial class PluggableCheckpointStoreEventProcessor<TPartition> : Azure.Messaging.EventHubs.Primitives.EventProcessor<TPartition> where TPartition : Azure.Messaging.EventHubs.Primitives.EventProcessorPartition, new()
    {
        protected PluggableCheckpointStoreEventProcessor() { }
        protected PluggableCheckpointStoreEventProcessor(Azure.Messaging.EventHubs.Primitives.CheckpointStore checkpointStore, int eventBatchMaximumCount, string consumerGroup, string connectionString, Azure.Messaging.EventHubs.Primitives.EventProcessorOptions options = null) { }
        protected PluggableCheckpointStoreEventProcessor(Azure.Messaging.EventHubs.Primitives.CheckpointStore checkpointStore, int eventBatchMaximumCount, string consumerGroup, string fullyQualifiedNamespace, string eventHubName, Azure.AzureNamedKeyCredential credential, Azure.Messaging.EventHubs.Primitives.EventProcessorOptions options = null) { }
        protected PluggableCheckpointStoreEventProcessor(Azure.Messaging.EventHubs.Primitives.CheckpointStore checkpointStore, int eventBatchMaximumCount, string consumerGroup, string fullyQualifiedNamespace, string eventHubName, Azure.AzureSasCredential credential, Azure.Messaging.EventHubs.Primitives.EventProcessorOptions options = null) { }
        protected PluggableCheckpointStoreEventProcessor(Azure.Messaging.EventHubs.Primitives.CheckpointStore checkpointStore, int eventBatchMaximumCount, string consumerGroup, string fullyQualifiedNamespace, string eventHubName, Azure.Core.TokenCredential credential, Azure.Messaging.EventHubs.Primitives.EventProcessorOptions options = null) { }
        protected PluggableCheckpointStoreEventProcessor(Azure.Messaging.EventHubs.Primitives.CheckpointStore checkpointStore, int eventBatchMaximumCount, string consumerGroup, string connectionString, string eventHubName, Azure.Messaging.EventHubs.Primitives.EventProcessorOptions options = null) { }
        protected override System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Messaging.EventHubs.Primitives.EventProcessorPartitionOwnership>> ClaimOwnershipAsync(System.Collections.Generic.IEnumerable<Azure.Messaging.EventHubs.Primitives.EventProcessorPartitionOwnership> desiredOwnership, System.Threading.CancellationToken cancellationToken) { throw null; }
        protected override System.Threading.Tasks.Task<Azure.Messaging.EventHubs.Primitives.EventProcessorCheckpoint> GetCheckpointAsync(string partitionId, System.Threading.CancellationToken cancellationToken) { throw null; }
        protected override System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Messaging.EventHubs.Primitives.EventProcessorPartitionOwnership>> ListOwnershipAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        protected override System.Threading.Tasks.Task UpdateCheckpointAsync(string partitionId, Azure.Messaging.EventHubs.Processor.CheckpointPosition startingPosition, System.Threading.CancellationToken cancellationToken) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("The Event Hubs service does not guarantee a numeric offset for all resource configurations.  Checkpoints created from a numeric offset may not work in all cases going forward. Please use a string-based offset via the overload accepting 'CheckpointPosition' instead.", false)]
        protected override System.Threading.Tasks.Task UpdateCheckpointAsync(string partitionId, long offset, long? sequenceNumber, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
}
namespace Azure.Messaging.EventHubs.Processor
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public partial struct CheckpointPosition : System.IEquatable<Azure.Messaging.EventHubs.Processor.CheckpointPosition>
    {
        private object _dummy;
        private int _dummyPrimitive;
        public CheckpointPosition() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("The Event Hubs service does not guarantee that a sequence number-only checkpoint can access the event stream for all resource configurations.  Reading events may not work in all cases going forward. Please provide a string-based offset.", false)]
        public CheckpointPosition(long sequenceNumber) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("The Event Hubs service does not guarantee a numeric offset for all resource configurations.  Checkpoints created from a numeric offset may not work in all cases going forward. Please use a string-based offset instead.", false)]
        public CheckpointPosition(long offset, long sequenceNumber = (long)-9223372036854775808) { throw null; }
        public CheckpointPosition(string offsetString, long sequenceNumber = (long)-9223372036854775808) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("The Event Hubs service does not guarantee a numeric offset for all resource configurations.  Please use 'OffsetString' instead.", false)]
        public long Offset { get { throw null; } }
        public string OffsetString { get { throw null; } }
        public long SequenceNumber { get { throw null; } }
        public bool Equals(Azure.Messaging.EventHubs.Processor.CheckpointPosition other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        public static Azure.Messaging.EventHubs.Processor.CheckpointPosition FromEvent(Azure.Messaging.EventHubs.EventData eventData) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.EventHubs.Processor.CheckpointPosition left, Azure.Messaging.EventHubs.Processor.CheckpointPosition right) { throw null; }
        public static bool operator !=(Azure.Messaging.EventHubs.Processor.CheckpointPosition left, Azure.Messaging.EventHubs.Processor.CheckpointPosition right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum LoadBalancingStrategy
    {
        Balanced = 0,
        Greedy = 1,
    }
    public partial class PartitionClosingEventArgs
    {
        public PartitionClosingEventArgs(string partitionId, Azure.Messaging.EventHubs.Processor.ProcessingStoppedReason reason, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public System.Threading.CancellationToken CancellationToken { get { throw null; } }
        public string PartitionId { get { throw null; } }
        public Azure.Messaging.EventHubs.Processor.ProcessingStoppedReason Reason { get { throw null; } }
    }
    public partial class PartitionInitializingEventArgs
    {
        public PartitionInitializingEventArgs(string partitionId, Azure.Messaging.EventHubs.Consumer.EventPosition defaultStartingPosition, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public System.Threading.CancellationToken CancellationToken { get { throw null; } }
        public Azure.Messaging.EventHubs.Consumer.EventPosition DefaultStartingPosition { get { throw null; } set { } }
        public string PartitionId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public partial struct ProcessErrorEventArgs
    {
        private object _dummy;
        private int _dummyPrimitive;
        public ProcessErrorEventArgs(string partitionId, string operation, System.Exception exception, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.CancellationToken CancellationToken { get { throw null; } }
        public System.Exception Exception { get { throw null; } }
        public string Operation { get { throw null; } }
        public string PartitionId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public partial struct ProcessEventArgs
    {
        private object _dummy;
        private int _dummyPrimitive;
        public ProcessEventArgs(Azure.Messaging.EventHubs.Consumer.PartitionContext partition, Azure.Messaging.EventHubs.EventData data, System.Func<System.Threading.CancellationToken, System.Threading.Tasks.Task> updateCheckpointImplementation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.CancellationToken CancellationToken { get { throw null; } }
        public Azure.Messaging.EventHubs.EventData Data { get { throw null; } }
        public bool HasEvent { get { throw null; } }
        public Azure.Messaging.EventHubs.Consumer.PartitionContext Partition { get { throw null; } }
        public System.Threading.Tasks.Task UpdateCheckpointAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public enum ProcessingStoppedReason
    {
        Shutdown = 0,
        OwnershipLost = 1,
    }
}
namespace Azure.Messaging.EventHubs.Producer
{
    public partial class CreateBatchOptions : Azure.Messaging.EventHubs.Producer.SendEventOptions
    {
        public CreateBatchOptions() { }
        public long? MaximumSizeInBytes { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public partial class EnqueueEventOptions : Azure.Messaging.EventHubs.Producer.SendEventOptions
    {
        public EnqueueEventOptions() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public sealed partial class EventDataBatch : System.IDisposable
    {
        internal EventDataBatch() { }
        public int Count { get { throw null; } }
        public long MaximumSizeInBytes { get { throw null; } }
        public long SizeInBytes { get { throw null; } }
        public void Dispose() { }
        public bool TryAdd(Azure.Messaging.EventHubs.EventData eventData) { throw null; }
    }
    public partial class EventHubBufferedProducerClient : System.IAsyncDisposable
    {
        protected EventHubBufferedProducerClient() { }
        public EventHubBufferedProducerClient(Azure.Messaging.EventHubs.EventHubConnection connection, Azure.Messaging.EventHubs.Producer.EventHubBufferedProducerClientOptions clientOptions = null) { }
        public EventHubBufferedProducerClient(string connectionString) { }
        public EventHubBufferedProducerClient(string connectionString, Azure.Messaging.EventHubs.Producer.EventHubBufferedProducerClientOptions clientOptions) { }
        public EventHubBufferedProducerClient(string connectionString, string eventHubName) { }
        public EventHubBufferedProducerClient(string fullyQualifiedNamespace, string eventHubName, Azure.AzureNamedKeyCredential credential, Azure.Messaging.EventHubs.Producer.EventHubBufferedProducerClientOptions clientOptions = null) { }
        public EventHubBufferedProducerClient(string fullyQualifiedNamespace, string eventHubName, Azure.AzureSasCredential credential, Azure.Messaging.EventHubs.Producer.EventHubBufferedProducerClientOptions clientOptions = null) { }
        public EventHubBufferedProducerClient(string fullyQualifiedNamespace, string eventHubName, Azure.Core.TokenCredential credential, Azure.Messaging.EventHubs.Producer.EventHubBufferedProducerClientOptions clientOptions = null) { }
        public EventHubBufferedProducerClient(string connectionString, string eventHubName, Azure.Messaging.EventHubs.Producer.EventHubBufferedProducerClientOptions clientOptions) { }
        public string EventHubName { get { throw null; } }
        public string FullyQualifiedNamespace { get { throw null; } }
        public string Identifier { get { throw null; } }
        public virtual bool IsClosed { get { throw null; } }
        public virtual bool IsPublishing { get { throw null; } }
        public virtual int TotalBufferedEventCount { get { throw null; } }
        public event System.Func<Azure.Messaging.EventHubs.Producer.SendEventBatchFailedEventArgs, System.Threading.Tasks.Task> SendEventBatchFailedAsync { add { } remove { } }
        public event System.Func<Azure.Messaging.EventHubs.Producer.SendEventBatchSucceededEventArgs, System.Threading.Tasks.Task> SendEventBatchSucceededAsync { add { } remove { } }
        public virtual System.Threading.Tasks.Task CloseAsync(bool flush = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.ValueTask DisposeAsync() { throw null; }
        public virtual System.Threading.Tasks.Task<int> EnqueueEventAsync(Azure.Messaging.EventHubs.EventData eventData, Azure.Messaging.EventHubs.Producer.EnqueueEventOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<int> EnqueueEventAsync(Azure.Messaging.EventHubs.EventData eventData, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<int> EnqueueEventsAsync(System.Collections.Generic.IEnumerable<Azure.Messaging.EventHubs.EventData> events, Azure.Messaging.EventHubs.Producer.EnqueueEventOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<int> EnqueueEventsAsync(System.Collections.Generic.IEnumerable<Azure.Messaging.EventHubs.EventData> events, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        public virtual System.Threading.Tasks.Task FlushAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual int GetBufferedEventCount(string partitionId) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Messaging.EventHubs.EventHubProperties> GetEventHubPropertiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public virtual System.Threading.Tasks.Task<string[]> GetPartitionIdsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Messaging.EventHubs.PartitionProperties> GetPartitionPropertiesAsync(string partitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected virtual System.Threading.Tasks.Task<string[]> ListPartitionIdsAsync(Azure.Messaging.EventHubs.Producer.EventHubProducerClient producer, System.Threading.CancellationToken cancellationToken) { throw null; }
        protected virtual System.Threading.Tasks.Task OnSendFailedAsync(System.Collections.Generic.IReadOnlyList<Azure.Messaging.EventHubs.EventData> events, System.Exception exception, string partitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected virtual System.Threading.Tasks.Task OnSendSucceededAsync(System.Collections.Generic.IReadOnlyList<Azure.Messaging.EventHubs.EventData> events, string partitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public partial class EventHubBufferedProducerClientOptions
    {
        public EventHubBufferedProducerClientOptions() { }
        public Azure.Messaging.EventHubs.EventHubConnectionOptions ConnectionOptions { get { throw null; } set { } }
        public bool EnableIdempotentRetries { get { throw null; } set { } }
        public string Identifier { get { throw null; } set { } }
        public int MaximumConcurrentSends { get { throw null; } set { } }
        public int MaximumConcurrentSendsPerPartition { get { throw null; } set { } }
        public int MaximumEventBufferLengthPerPartition { get { throw null; } set { } }
        public System.TimeSpan? MaximumWaitTime { get { throw null; } set { } }
        public Azure.Messaging.EventHubs.EventHubsRetryOptions RetryOptions { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public partial class EventHubProducerClient : System.IAsyncDisposable
    {
        protected EventHubProducerClient() { }
        public EventHubProducerClient(Azure.Messaging.EventHubs.EventHubConnection connection, Azure.Messaging.EventHubs.Producer.EventHubProducerClientOptions clientOptions = null) { }
        public EventHubProducerClient(string connectionString) { }
        public EventHubProducerClient(string connectionString, Azure.Messaging.EventHubs.Producer.EventHubProducerClientOptions clientOptions) { }
        public EventHubProducerClient(string connectionString, string eventHubName) { }
        public EventHubProducerClient(string fullyQualifiedNamespace, string eventHubName, Azure.AzureNamedKeyCredential credential, Azure.Messaging.EventHubs.Producer.EventHubProducerClientOptions clientOptions = null) { }
        public EventHubProducerClient(string fullyQualifiedNamespace, string eventHubName, Azure.AzureSasCredential credential, Azure.Messaging.EventHubs.Producer.EventHubProducerClientOptions clientOptions = null) { }
        public EventHubProducerClient(string fullyQualifiedNamespace, string eventHubName, Azure.Core.TokenCredential credential, Azure.Messaging.EventHubs.Producer.EventHubProducerClientOptions clientOptions = null) { }
        public EventHubProducerClient(string connectionString, string eventHubName, Azure.Messaging.EventHubs.Producer.EventHubProducerClientOptions clientOptions) { }
        public string EventHubName { get { throw null; } }
        public string FullyQualifiedNamespace { get { throw null; } }
        public string Identifier { get { throw null; } }
        public bool IsClosed { get { throw null; } protected set { } }
        public virtual System.Threading.Tasks.Task CloseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.ValueTask<Azure.Messaging.EventHubs.Producer.EventDataBatch> CreateBatchAsync(Azure.Messaging.EventHubs.Producer.CreateBatchOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.ValueTask<Azure.Messaging.EventHubs.Producer.EventDataBatch> CreateBatchAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.ValueTask DisposeAsync() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Messaging.EventHubs.EventHubProperties> GetEventHubPropertiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public virtual System.Threading.Tasks.Task<string[]> GetPartitionIdsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Messaging.EventHubs.PartitionProperties> GetPartitionPropertiesAsync(string partitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        protected internal virtual System.Threading.Tasks.Task<Azure.Messaging.EventHubs.Producer.PartitionPublishingProperties> GetPartitionPublishingPropertiesAsync(string partitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task SendAsync(Azure.Messaging.EventHubs.Producer.EventDataBatch eventBatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task SendAsync(System.Collections.Generic.IEnumerable<Azure.Messaging.EventHubs.EventData> eventBatch, Azure.Messaging.EventHubs.Producer.SendEventOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task SendAsync(System.Collections.Generic.IEnumerable<Azure.Messaging.EventHubs.EventData> eventBatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public partial class EventHubProducerClientOptions
    {
        public EventHubProducerClientOptions() { }
        public Azure.Messaging.EventHubs.EventHubConnectionOptions ConnectionOptions { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        protected internal bool EnableIdempotentPartitions { get { throw null; } set { } }
        public string Identifier { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        protected internal System.Collections.Generic.Dictionary<string, Azure.Messaging.EventHubs.Producer.PartitionPublishingOptions> PartitionOptions { get { throw null; } }
        public Azure.Messaging.EventHubs.EventHubsRetryOptions RetryOptions { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class PartitionPublishingOptions
    {
        public PartitionPublishingOptions() { }
        public short? OwnerLevel { get { throw null; } set { } }
        public long? ProducerGroupId { get { throw null; } set { } }
        public int? StartingSequenceNumber { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class PartitionPublishingProperties
    {
        internal PartitionPublishingProperties() { }
        public bool IsIdempotentPublishingEnabled { get { throw null; } }
        public int? LastPublishedSequenceNumber { get { throw null; } }
        public short? OwnerLevel { get { throw null; } }
        public long? ProducerGroupId { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public partial class SendEventBatchFailedEventArgs : System.EventArgs
    {
        public SendEventBatchFailedEventArgs(System.Collections.Generic.IReadOnlyList<Azure.Messaging.EventHubs.EventData> eventBatch, System.Exception exception, string partitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public System.Threading.CancellationToken CancellationToken { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Messaging.EventHubs.EventData> EventBatch { get { throw null; } }
        public System.Exception Exception { get { throw null; } }
        public string PartitionId { get { throw null; } }
    }
    public partial class SendEventBatchSucceededEventArgs : System.EventArgs
    {
        public SendEventBatchSucceededEventArgs(System.Collections.Generic.IReadOnlyList<Azure.Messaging.EventHubs.EventData> eventBatch, string partitionId, System.Threading.CancellationToken cancellationToken) { }
        public System.Threading.CancellationToken CancellationToken { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Messaging.EventHubs.EventData> EventBatch { get { throw null; } }
        public string PartitionId { get { throw null; } }
    }
    public partial class SendEventOptions
    {
        public SendEventOptions() { }
        public string PartitionId { get { throw null; } set { } }
        public string PartitionKey { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class EventHubClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Messaging.EventHubs.Consumer.EventHubConsumerClient, Azure.Messaging.EventHubs.Consumer.EventHubConsumerClientOptions> AddEventHubConsumerClientWithNamespace<TBuilder>(this TBuilder builder, string consumerGroup, string fullyQualifiedNamespace, string eventHubName) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Messaging.EventHubs.Consumer.EventHubConsumerClient, Azure.Messaging.EventHubs.Consumer.EventHubConsumerClientOptions> AddEventHubConsumerClient<TBuilder>(this TBuilder builder, string consumerGroup, string connectionString) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Messaging.EventHubs.Consumer.EventHubConsumerClient, Azure.Messaging.EventHubs.Consumer.EventHubConsumerClientOptions> AddEventHubConsumerClient<TBuilder>(this TBuilder builder, string consumerGroup, string connectionString, string eventHubName) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Messaging.EventHubs.Consumer.EventHubConsumerClient, Azure.Messaging.EventHubs.Consumer.EventHubConsumerClientOptions> AddEventHubConsumerClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Messaging.EventHubs.Producer.EventHubProducerClient, Azure.Messaging.EventHubs.Producer.EventHubProducerClientOptions> AddEventHubProducerClientWithNamespace<TBuilder>(this TBuilder builder, string fullyQualifiedNamespace, string eventHubName) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Messaging.EventHubs.Producer.EventHubProducerClient, Azure.Messaging.EventHubs.Producer.EventHubProducerClientOptions> AddEventHubProducerClient<TBuilder>(this TBuilder builder, string connectionString) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Messaging.EventHubs.Producer.EventHubProducerClient, Azure.Messaging.EventHubs.Producer.EventHubProducerClientOptions> AddEventHubProducerClient<TBuilder>(this TBuilder builder, string connectionString, string eventHubName) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Messaging.EventHubs.Producer.EventHubProducerClient, Azure.Messaging.EventHubs.Producer.EventHubProducerClientOptions> AddEventHubProducerClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
