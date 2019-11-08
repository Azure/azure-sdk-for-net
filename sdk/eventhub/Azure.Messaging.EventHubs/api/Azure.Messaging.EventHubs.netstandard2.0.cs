namespace Azure.Messaging.EventHubs
{
    public partial class BatchOptions : Azure.Messaging.EventHubs.SendOptions
    {
        public BatchOptions() { }
        public long? MaximumSizeInBytes { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public partial class EventData
    {
        public EventData(System.ReadOnlyMemory<byte> eventBody) { }
        protected EventData(System.ReadOnlyMemory<byte> eventBody, System.Collections.Generic.IDictionary<string, object> properties = null, System.Collections.Generic.IReadOnlyDictionary<string, object> systemProperties = null, long? sequenceNumber = default(long?), long? offset = default(long?), System.DateTimeOffset? enqueuedTime = default(System.DateTimeOffset?), string partitionKey = null) { }
        public System.ReadOnlyMemory<byte> Body { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.IO.Stream BodyAsStream { get { throw null; } }
        public System.DateTimeOffset? EnqueuedTime { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public long? Offset { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string PartitionKey { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.Collections.Generic.IDictionary<string, object> Properties { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public long? SequenceNumber { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, object> SystemProperties { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
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
    public partial class EventHubConnection : System.IAsyncDisposable
    {
        protected EventHubConnection() { }
        public EventHubConnection(string connectionString) { }
        public EventHubConnection(string connectionString, Azure.Messaging.EventHubs.EventHubConnectionOptions connectionOptions) { }
        public EventHubConnection(string connectionString, string eventHubName) { }
        public EventHubConnection(string fullyQualifiedNamespace, string eventHubName, Azure.Core.TokenCredential credential, Azure.Messaging.EventHubs.EventHubConnectionOptions connectionOptions = null) { }
        public EventHubConnection(string connectionString, string eventHubName, Azure.Messaging.EventHubs.EventHubConnectionOptions connectionOptions) { }
        public bool Closed { get { throw null; } }
        public string EventHubName { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string FullyQualifiedNamespace { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public virtual void Close(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
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
        public System.Net.IWebProxy Proxy { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public Azure.Messaging.EventHubs.TransportType TransportType { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public partial class EventHubConsumerClient : System.IAsyncDisposable
    {
        public const string DefaultConsumerGroupName = "$Default";
        protected EventHubConsumerClient() { }
        public EventHubConsumerClient(string consumerGroup, string partitionId, Azure.Messaging.EventHubs.EventPosition eventPosition, Azure.Messaging.EventHubs.EventHubConnection connection, Azure.Messaging.EventHubs.EventHubConsumerClientOptions consumerOptions = null) { }
        public EventHubConsumerClient(string consumerGroup, string partitionId, Azure.Messaging.EventHubs.EventPosition eventPosition, string connectionString) { }
        public EventHubConsumerClient(string consumerGroup, string partitionId, Azure.Messaging.EventHubs.EventPosition eventPosition, string connectionString, Azure.Messaging.EventHubs.EventHubConsumerClientOptions consumerOptions) { }
        public EventHubConsumerClient(string consumerGroup, string partitionId, Azure.Messaging.EventHubs.EventPosition eventPosition, string connectionString, string eventHubName) { }
        public EventHubConsumerClient(string consumerGroup, string partitionId, Azure.Messaging.EventHubs.EventPosition eventPosition, string fullyQualifiedNamespace, string eventHubName, Azure.Core.TokenCredential credential, Azure.Messaging.EventHubs.EventHubConsumerClientOptions consumerOptions = null) { }
        public EventHubConsumerClient(string consumerGroup, string partitionId, Azure.Messaging.EventHubs.EventPosition eventPosition, string connectionString, string eventHubName, Azure.Messaging.EventHubs.EventHubConsumerClientOptions consumerOptions) { }
        public bool Closed { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] protected set { } }
        public string ConsumerGroup { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string EventHubName { get { throw null; } }
        public string FullyQualifiedNamespace { get { throw null; } }
        public string Identifier { get { throw null; } }
        public long? OwnerLevel { get { throw null; } }
        public string PartitionId { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public Azure.Messaging.EventHubs.EventPosition StartingPosition { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public virtual void Close(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public virtual System.Threading.Tasks.Task CloseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.ValueTask DisposeAsync() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Messaging.EventHubs.Metadata.EventHubProperties> GetEventHubPropertiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public virtual System.Threading.Tasks.Task<string[]> GetPartitionIdsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Messaging.EventHubs.Metadata.PartitionProperties> GetPartitionPropertiesAsync(string partitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Collections.Generic.IAsyncEnumerable<Azure.Messaging.EventHubs.PartitionEvent> ReadEventsFromPartitionAsync(string partitionId, Azure.Messaging.EventHubs.EventPosition startingPosition, System.TimeSpan? maximumWaitTime, [System.Runtime.CompilerServices.EnumeratorCancellationAttribute] System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IAsyncEnumerable<Azure.Messaging.EventHubs.PartitionEvent> ReadEventsFromPartitionAsync(string partitionId, Azure.Messaging.EventHubs.EventPosition startingPosition, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Messaging.EventHubs.Metadata.LastEnqueuedEventProperties ReadLastEnqueuedEventInformation() { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Messaging.EventHubs.EventData>> ReceiveAsync(int maximumMessageCount, System.TimeSpan? maximumWaitTime = default(System.TimeSpan?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public partial class EventHubConsumerClientOptions
    {
        public EventHubConsumerClientOptions() { }
        public Azure.Messaging.EventHubs.EventHubConnectionOptions ConnectionOptions { get { throw null; } set { } }
        public string Identifier { get { throw null; } set { } }
        public long? OwnerLevel { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public int PrefetchCount { get { throw null; } set { } }
        public Azure.Messaging.EventHubs.RetryOptions RetryOptions { get { throw null; } set { } }
        public bool TrackLastEnqueuedEventInformation { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
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
        public EventHubProducerClient(Azure.Messaging.EventHubs.EventHubConnection connection, Azure.Messaging.EventHubs.EventHubProducerClientOptions producerOptions = null) { }
        public EventHubProducerClient(string connectionString) { }
        public EventHubProducerClient(string connectionString, Azure.Messaging.EventHubs.EventHubProducerClientOptions producerOptions) { }
        public EventHubProducerClient(string connectionString, string eventHubName) { }
        public EventHubProducerClient(string fullyQualifiedNamespace, string eventHubName, Azure.Core.TokenCredential credential, Azure.Messaging.EventHubs.EventHubProducerClientOptions producerOptions = null) { }
        public EventHubProducerClient(string connectionString, string eventHubName, Azure.Messaging.EventHubs.EventHubProducerClientOptions producerOptions) { }
        public bool Closed { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] protected set { } }
        public string EventHubName { get { throw null; } }
        public string FullyQualifiedNamespace { get { throw null; } }
        public string PartitionId { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public virtual void Close(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public virtual System.Threading.Tasks.Task CloseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.ValueTask<Azure.Messaging.EventHubs.EventDataBatch> CreateBatchAsync(Azure.Messaging.EventHubs.BatchOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.ValueTask<Azure.Messaging.EventHubs.EventDataBatch> CreateBatchAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.ValueTask DisposeAsync() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Messaging.EventHubs.Metadata.EventHubProperties> GetEventHubPropertiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public virtual System.Threading.Tasks.Task<string[]> GetPartitionIdsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Messaging.EventHubs.Metadata.PartitionProperties> GetPartitionPropertiesAsync(string partitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task SendAsync(Azure.Messaging.EventHubs.EventData eventData, Azure.Messaging.EventHubs.SendOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task SendAsync(Azure.Messaging.EventHubs.EventData eventData, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task SendAsync(Azure.Messaging.EventHubs.EventDataBatch eventBatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task SendAsync(System.Collections.Generic.IEnumerable<Azure.Messaging.EventHubs.EventData> events, Azure.Messaging.EventHubs.SendOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task SendAsync(System.Collections.Generic.IEnumerable<Azure.Messaging.EventHubs.EventData> events, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public partial class EventHubProducerClientOptions
    {
        public EventHubProducerClientOptions() { }
        public Azure.Messaging.EventHubs.EventHubConnectionOptions ConnectionOptions { get { throw null; } set { } }
        public string PartitionId { get { throw null; } set { } }
        public Azure.Messaging.EventHubs.RetryOptions RetryOptions { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
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
    public sealed partial class EventPosition
    {
        public EventPosition() { }
        public static Azure.Messaging.EventHubs.EventPosition Earliest { get { throw null; } }
        public static Azure.Messaging.EventHubs.EventPosition Latest { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        public static Azure.Messaging.EventHubs.EventPosition FromEnqueuedTime(System.DateTimeOffset enqueuedTime) { throw null; }
        public static Azure.Messaging.EventHubs.EventPosition FromOffset(long offset) { throw null; }
        public static Azure.Messaging.EventHubs.EventPosition FromSequenceNumber(long sequenceNumber, bool isInclusive = false) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public partial class EventProcessorClient : System.IAsyncDisposable
    {
        protected EventProcessorClient() { }
        protected internal EventProcessorClient(string consumerGroup, Azure.Messaging.EventHubs.Processor.PartitionManager partitionManager, Azure.Messaging.EventHubs.EventHubConnection connection, Azure.Messaging.EventHubs.EventProcessorClientOptions processorOptions) { }
        public EventProcessorClient(string consumerGroup, Azure.Messaging.EventHubs.Processor.PartitionManager partitionManager, string connectionString) { }
        public EventProcessorClient(string consumerGroup, Azure.Messaging.EventHubs.Processor.PartitionManager partitionManager, string connectionString, Azure.Messaging.EventHubs.EventProcessorClientOptions processorOptions) { }
        public EventProcessorClient(string consumerGroup, Azure.Messaging.EventHubs.Processor.PartitionManager partitionManager, string connectionString, string eventHubName) { }
        public EventProcessorClient(string consumerGroup, Azure.Messaging.EventHubs.Processor.PartitionManager partitionManager, string fullyQualifiedNamespace, string eventHubName, Azure.Core.TokenCredential credential, Azure.Messaging.EventHubs.EventProcessorClientOptions processorOptions = null) { }
        public EventProcessorClient(string consumerGroup, Azure.Messaging.EventHubs.Processor.PartitionManager partitionManager, string connectionString, string eventHubName, Azure.Messaging.EventHubs.EventProcessorClientOptions processorOptions) { }
        public bool Closed { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] protected set { } }
        public string ConsumerGroup { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string EventHubName { get { throw null; } }
        public string FullyQualifiedNamespace { get { throw null; } }
        public string Identifier { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.Func<Azure.Messaging.EventHubs.Processor.InitializePartitionProcessingContext, System.Threading.Tasks.Task> InitializeProcessingForPartitionAsync { get { throw null; } set { } }
        protected virtual System.TimeSpan LoadBalanceUpdate { get { throw null; } }
        protected virtual System.TimeSpan OwnershipExpiration { get { throw null; } }
        public System.Func<Azure.Messaging.EventHubs.Processor.EventProcessorEvent, System.Threading.Tasks.Task> ProcessEventAsync { get { throw null; } set { } }
        public System.Func<Azure.Messaging.EventHubs.Processor.ProcessorErrorContext, System.Threading.Tasks.Task> ProcessExceptionAsync { get { throw null; } set { } }
        public System.Func<Azure.Messaging.EventHubs.Processor.PartitionProcessingStoppedContext, System.Threading.Tasks.Task> ProcessingForPartitionStoppedAsync { get { throw null; } set { } }
        public virtual void Close(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public virtual System.Threading.Tasks.Task CloseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.ValueTask DisposeAsync() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public virtual System.Threading.Tasks.Task StartAsync() { throw null; }
        public virtual System.Threading.Tasks.Task StopAsync() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
        protected internal virtual System.Threading.Tasks.Task UpdateCheckpointAsync(Azure.Messaging.EventHubs.EventData eventData, Azure.Messaging.EventHubs.PartitionContext context) { throw null; }
    }
    public partial class EventProcessorClientOptions
    {
        public EventProcessorClientOptions() { }
        public Azure.Messaging.EventHubs.EventHubConnectionOptions ConnectionOptions { get { throw null; } set { } }
        public System.TimeSpan? MaximumReceiveWaitTime { get { throw null; } set { } }
        public Azure.Messaging.EventHubs.RetryOptions RetryOptions { get { throw null; } set { } }
        public bool TrackLastEnqueuedEventInformation { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public partial class PartitionContext
    {
        protected internal PartitionContext(string eventHubName, string partitionId) { }
        public string EventHubName { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string PartitionId { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public virtual Azure.Messaging.EventHubs.Metadata.LastEnqueuedEventProperties ReadLastEnqueuedEventInformation() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public partial struct PartitionEvent
    {
        private object _dummy;
        private int _dummyPrimitive;
        public PartitionEvent(Azure.Messaging.EventHubs.PartitionContext partitionContext, Azure.Messaging.EventHubs.EventData eventData) { throw null; }
        public Azure.Messaging.EventHubs.PartitionContext Context { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public Azure.Messaging.EventHubs.EventData Data { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    public enum RetryMode
    {
        Fixed = 0,
        Exponential = 1,
    }
    public partial class RetryOptions
    {
        public RetryOptions() { }
        public Azure.Messaging.EventHubs.EventHubsRetryPolicy CustomRetryPolicy { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public System.TimeSpan Delay { get { throw null; } set { } }
        public System.TimeSpan MaximumDelay { get { throw null; } set { } }
        public int MaximumRetries { get { throw null; } set { } }
        public Azure.Messaging.EventHubs.RetryMode Mode { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public System.TimeSpan TryTimeout { get { throw null; } set { } }
    }
    public partial class SendOptions
    {
        public SendOptions() { }
        public string PartitionKey { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public enum TransportType
    {
        AmqpTcp = 0,
        AmqpWebSockets = 1,
    }
}
namespace Azure.Messaging.EventHubs.Authorization
{
    public sealed partial class EventHubSharedKeyCredential : Azure.Core.TokenCredential
    {
        public EventHubSharedKeyCredential(string sharedAccessKeyName, string sharedAccessKey) { }
        public string SharedAccessKeyName { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public override Azure.Core.AccessToken GetToken(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Core.AccessToken> GetTokenAsync(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
}
namespace Azure.Messaging.EventHubs.Errors
{
    public sealed partial class ConsumerDisconnectedException : Azure.Messaging.EventHubs.Errors.EventHubsException
    {
        internal ConsumerDisconnectedException() { }
    }
    public sealed partial class EventHubsClientClosedException : Azure.Messaging.EventHubs.Errors.EventHubsException
    {
        internal EventHubsClientClosedException() { }
    }
    public sealed partial class EventHubsCommunicationException : Azure.Messaging.EventHubs.Errors.EventHubsException
    {
        internal EventHubsCommunicationException() { }
    }
    public partial class EventHubsException : System.Exception
    {
        internal EventHubsException() { }
        public bool IsTransient { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public override string Message { get { throw null; } }
        public string ResourceName { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    public sealed partial class EventHubsResourceNotFoundException : Azure.Messaging.EventHubs.Errors.EventHubsException
    {
        internal EventHubsResourceNotFoundException() { }
    }
    public sealed partial class EventHubsTimeoutException : Azure.Messaging.EventHubs.Errors.EventHubsException
    {
        internal EventHubsTimeoutException() { }
    }
    public sealed partial class MessageSizeExceededException : Azure.Messaging.EventHubs.Errors.EventHubsException
    {
        internal MessageSizeExceededException() { }
    }
    public sealed partial class QuotaExceededException : Azure.Messaging.EventHubs.Errors.EventHubsException
    {
        internal QuotaExceededException() { }
    }
    public sealed partial class ServiceBusyException : Azure.Messaging.EventHubs.Errors.EventHubsException
    {
        internal ServiceBusyException() { }
    }
}
namespace Azure.Messaging.EventHubs.Metadata
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public partial struct EventHubProperties
    {
        private object _dummy;
        private int _dummyPrimitive;
        public EventHubProperties(string name, System.DateTimeOffset createdAt, string[] partitionIds) { throw null; }
        public System.DateTimeOffset CreatedAt { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string Name { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string[] PartitionIds { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public partial struct LastEnqueuedEventProperties
    {
        private object _dummy;
        private int _dummyPrimitive;
        public LastEnqueuedEventProperties(string eventHubName, string partitionId, long? lastSequenceNumber, long? lastOffset, System.DateTimeOffset? lastEnqueuedTime, System.DateTimeOffset? lastReceivedTime) { throw null; }
        public string EventHubName { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.DateTimeOffset? InformationReceived { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public long? LastEnqueuedOffset { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public long? LastEnqueuedSequenceNumber { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.DateTimeOffset? LastEnqueuedTime { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string PartitionId { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public partial struct PartitionProperties
    {
        private object _dummy;
        private int _dummyPrimitive;
        public PartitionProperties(string eventHubName, string partitionId, bool isEmpty, long beginningSequenceNumber, long lastSequenceNumber, long lastOffset, System.DateTimeOffset lastEnqueuedTime) { throw null; }
        public long BeginningSequenceNumber { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string EventHubName { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string Id { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public bool IsEmpty { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public long LastEnqueuedOffset { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public long LastEnqueuedSequenceNumber { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.DateTimeOffset LastEnqueuedTime { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
}
namespace Azure.Messaging.EventHubs.Processor
{
    public partial class Checkpoint
    {
        protected internal Checkpoint(string fullyQualifiedNamespace, string eventHubName, string consumerGroup, string ownerIdentifier, string partitionId, long offset, long sequenceNumber) { }
        public string ConsumerGroup { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string EventHubName { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string FullyQualifiedNamespace { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public long Offset { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string OwnerIdentifier { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string PartitionId { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public long SequenceNumber { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public partial struct EventProcessorEvent
    {
        private object _dummy;
        private int _dummyPrimitive;
        public EventProcessorEvent(Azure.Messaging.EventHubs.PartitionContext partitionContext, Azure.Messaging.EventHubs.EventData eventData, System.Func<Azure.Messaging.EventHubs.EventData, Azure.Messaging.EventHubs.PartitionContext, System.Threading.Tasks.Task> onUpdateCheckpoint) { throw null; }
        public Azure.Messaging.EventHubs.PartitionContext Context { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public Azure.Messaging.EventHubs.EventData Data { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.Threading.Tasks.Task UpdateCheckpointAsync(Azure.Messaging.EventHubs.EventData eventData) { throw null; }
    }
    public partial class InitializePartitionProcessingContext
    {
        protected internal InitializePartitionProcessingContext(Azure.Messaging.EventHubs.PartitionContext partitionContext) { }
        public Azure.Messaging.EventHubs.PartitionContext Context { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public Azure.Messaging.EventHubs.EventPosition DefaultStartingPosition { get { throw null; } set { } }
    }
    public sealed partial class InMemoryPartitionManager : Azure.Messaging.EventHubs.Processor.PartitionManager
    {
        public InMemoryPartitionManager(System.Action<string> logger = null) { }
        public override System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Messaging.EventHubs.Processor.PartitionOwnership>> ClaimOwnershipAsync(System.Collections.Generic.IEnumerable<Azure.Messaging.EventHubs.Processor.PartitionOwnership> partitionOwnership) { throw null; }
        public override System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Messaging.EventHubs.Processor.PartitionOwnership>> ListOwnershipAsync(string fullyQualifiedNamespace, string eventHubName, string consumerGroup) { throw null; }
        public override System.Threading.Tasks.Task UpdateCheckpointAsync(Azure.Messaging.EventHubs.Processor.Checkpoint checkpoint) { throw null; }
    }
    public abstract partial class PartitionManager
    {
        protected PartitionManager() { }
        public abstract System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Messaging.EventHubs.Processor.PartitionOwnership>> ClaimOwnershipAsync(System.Collections.Generic.IEnumerable<Azure.Messaging.EventHubs.Processor.PartitionOwnership> partitionOwnership);
        public abstract System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Messaging.EventHubs.Processor.PartitionOwnership>> ListOwnershipAsync(string fullyQualifiedNamespace, string eventHubName, string consumerGroup);
        public abstract System.Threading.Tasks.Task UpdateCheckpointAsync(Azure.Messaging.EventHubs.Processor.Checkpoint checkpoint);
    }
    public partial class PartitionOwnership
    {
        protected internal PartitionOwnership(string fullyQualifiedNamespace, string eventHubName, string consumerGroup, string ownerIdentifier, string partitionId, long? offset = default(long?), long? sequenceNumber = default(long?), System.DateTimeOffset? lastModifiedTime = default(System.DateTimeOffset?), string eTag = null) { }
        public string ConsumerGroup { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string ETag { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string EventHubName { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string FullyQualifiedNamespace { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.DateTimeOffset? LastModifiedTime { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public long? Offset { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string OwnerIdentifier { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string PartitionId { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public long? SequenceNumber { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
    }
    public partial class PartitionProcessingStoppedContext
    {
        protected internal PartitionProcessingStoppedContext(Azure.Messaging.EventHubs.PartitionContext partitionContext, Azure.Messaging.EventHubs.Processor.ProcessingStoppedReason reason) { }
        public Azure.Messaging.EventHubs.PartitionContext Context { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public Azure.Messaging.EventHubs.Processor.ProcessingStoppedReason Reason { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    public enum ProcessingStoppedReason
    {
        Unknown = 0,
        Shutdown = 1,
        OwnershipLost = 2,
        Exception = 3,
    }
    public partial class ProcessorErrorContext
    {
        protected internal ProcessorErrorContext(string partitionId, System.Exception exception) { }
        public string PartitionId { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.Exception ProcessorException { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class EventHubClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Messaging.EventHubs.EventHubConsumerClient, Azure.Messaging.EventHubs.EventHubConsumerClientOptions> AddEventHubConsumerClientWithNamespace<TBuilder>(this TBuilder builder, string consumerGroup, string partitionId, Azure.Messaging.EventHubs.EventPosition startingPosition, string fullyQualifiedNamespace, string eventHubName) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Messaging.EventHubs.EventHubConsumerClient, Azure.Messaging.EventHubs.EventHubConsumerClientOptions> AddEventHubConsumerClient<TBuilder>(this TBuilder builder, string consumerGroup, string partitionId, Azure.Messaging.EventHubs.EventPosition startingPosition, string connectionString) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Messaging.EventHubs.EventHubConsumerClient, Azure.Messaging.EventHubs.EventHubConsumerClientOptions> AddEventHubConsumerClient<TBuilder>(this TBuilder builder, string consumerGroup, string partitionId, Azure.Messaging.EventHubs.EventPosition startingPosition, string connectionString, string eventHubName) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Messaging.EventHubs.EventHubConsumerClient, Azure.Messaging.EventHubs.EventHubConsumerClientOptions> AddEventHubConsumerClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Messaging.EventHubs.EventHubProducerClient, Azure.Messaging.EventHubs.EventHubProducerClientOptions> AddEventHubProducerClientWithNamespace<TBuilder>(this TBuilder builder, string fullyQualifiedNamespace, string eventHubName) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Messaging.EventHubs.EventHubProducerClient, Azure.Messaging.EventHubs.EventHubProducerClientOptions> AddEventHubProducerClient<TBuilder>(this TBuilder builder, string connectionString) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Messaging.EventHubs.EventHubProducerClient, Azure.Messaging.EventHubs.EventHubProducerClientOptions> AddEventHubProducerClient<TBuilder>(this TBuilder builder, string connectionString, string eventHubName) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Messaging.EventHubs.EventHubProducerClient, Azure.Messaging.EventHubs.EventHubProducerClientOptions> AddEventHubProducerClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
