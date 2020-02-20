# .NET Event Hubs Client: Skeleton (January, 2020)

This skeleton represents the public API surface of the .NET Event Hubs client libraries in skeletal form, as they were proposed and reviewed for the preview 6 and January 2020 milestone releases.

## Package: Azure.Messaging.EventHubs

### `Azure.Messaging.EventHubs`
```csharp
public class EventHubConnection : IAsyncDisposable 
{
    public bool IsClosed { get; protected set; }
    public string EventHubName { get; }
    public string FullyQualifiedNamespace { get; }
    
    // Basic constructors
    public EventHubConnection(
        string connectionString);
    
    public EventHubConnection(
        string connectionString, 
        EventHubConnectionOptions connectionOptions);
        
    public EventHubConnection(
        string connectionString, 
        string eventHubName);
        
    public EventHubConnection(
        string connectionString, 
        string eventHubName, 
        EventHubConnectionOptions connectionOptions);
    
    // Advanced constructor
    public EventHubConnection(
        string fullyQualifiedNamespace, 
        string eventHubName, 
        TokenCredential credential, 
        EventHubConnectionOptions connectionOptions = null);
    
    // Mocking constructors
    protected EventHubConnection();
    
    public virtual Task CloseAsync(CancellationToken cancellationToken = default);
    public virtual ValueTask DisposeAsync();
}

public class EventHubConnectionOptions 
{
    public IWebProxy Proxy { get; set; }
    public EventHubsTransportType TransportType { get; set; }
}

public class EventData 
{
    // Standard constructor
    public EventData(ReadOnlyMemory<byte> eventBody);
    
    // Mocking constructor
    protected EventData(
        ReadOnlyMemory<byte> eventBody, 
        IDictionary<string, object> properties = null, 
        IReadOnlyDictionary<string, object> systemProperties = null, 
        long? sequenceNumber = default, 
        long? offset = default, 
        DateTimeOffset? enqueuedTime = default, 
        string partitionKey = null);
    
    public ReadOnlyMemory<byte> Body { get; }
    public Stream BodyAsStream { get; }
    public DateTimeOffset EnqueuedTime { get; }
    public long Offset { get; }
    public string PartitionKey { get; }
    public IDictionary<string, object> Properties { get; }
    public long SequenceNumber { get; }
    public IReadOnlyDictionary<string, object> SystemProperties { get; }
}

public class EventHubsException : Exception
{
    public bool IsTransient { get; }
    public FailureReason Reason { get; }
    public string EventHubName { get; }
    public override string Message { get; }
    
    public EventHubsException(
        bool isTransient, 
        string eventHubName);
    
    public EventHubsException(
        bool isTransient, 
        string eventHubName, 
        FailureReason reason);
    
    public EventHubsException(
        bool isTransient, 
        string eventHubName,
        string message);

    public EventHubsException(
        bool isTransient,
        string eventHubName,
        string message,
        FailureReason reason);

    public EventHubsException(
        string eventHubName,
        string message,
        FailureReason reason);

   public EventHubsException(
       bool isTransient,
       string eventHubName,
       string message,
       Exception innerException);

   public EventHubsException(
       bool isTransient,
       string eventHubName,
       string message,
       FailureReason reason,
       Exception innerException);

    public enum FailureReason
    {
        GeneralError,
        ClientClosed,
        ConsumerDisconnected,
        ResourceNotFound,
        MessageSizeExceeded,
        QuotaExceeded,
        ServiceBusy,
        ServiceTimeout,
        ServiceCommunicationProblem
    }
}

public class EventHubProperties 
{
    public DateTimeOffset CreatedOn { get; }
    public string Name { get; }
    public string[] PartitionIds { get; }
        
    protected internal EventHubProperties(
        string name, 
        DateTimeOffset createdOn, 
        string[] partitionIds);
}

public abstract class EventHubsRetryPolicy 
{
    public abstract TimeSpan? CalculateRetryDelay(Exception lastException, int attemptCount);
    public abstract TimeSpan CalculateTryTimeout(int attemptCount);
}

public enum EventHubsRetryMode 
{
    Fixed,
    Exponential
}

public class EventHubsRetryOptions 
{
    public TimeSpan Delay { get; set; }
    public TimeSpan MaximumDelay { get; set; }
    public int MaximumRetries { get; set; }
    public EventHubsRetryMode Mode { get; set; }
    public TimeSpan TryTimeout { get; set; }
    public EventHubsRetryPolicy CustomRetryPolicy { get; set; }
}
    
public enum EventHubsTransportType  
{
    AmqpTcp,
    AmqpWebSockets ,
}

public class PartitionProperties 
{
    public string EventHubName { get; }
    public string PartitionId { get; }
    public bool IsEmpty { get; }
    public long BeginningSequenceNumber { get; }
    public long LastEnqueuedSequenceNumber { get; }
    public long LastEnqueuedOffset { get; }
    public DateTimeOffset LastEnqueuedTime { get; }
    
    protected internal PartitionProperties(
        string eventHubName, 
        string partitionId, 
        bool isEmpty,
        long beginningSequenceNumber, 
        long lastSequenceNumber, 
        long lastOffset, 
        DateTimeOffset lastEnqueuedTime);
}
```

### `Azure.Messaging.EventHubs.Consumer`
```csharp
public class EventHubConsumerClient : IAsyncDisposable 
{
    public const string DefaultConsumerGroupName = "$Default";
    
    public bool IsClosed { get; protected set; }
    public string FullyQualifiedNamespace { get; }
    public string EventHubName { get; }
    public string ConsumerGroup { get; }
        
    // Basic constructors
    public EventHubConsumerClient(
        string consumerGroup, 
        string connectionString);
    
    public EventHubConsumerClient(
        string consumerGroup, 
        string connectionString, 
        EventHubConsumerClientOptions clientOptions);
        
    public EventHubConsumerClient(
        string consumerGroup, 
        string connectionString,
        string eventHubName);
        
    public EventHubConsumerClient(
        string consumerGroup, 
        string connectionString,
        string eventHubName, 
        EventHubConsumerClientOptions clientOptions);
        
    // Advanced constructors
    public EventHubConsumerClient(
        string consumerGroup, 
        string fullyQualifiedNamespace, 
        string eventHubName, 
        TokenCredential credential, 
        EventHubConsumerClientOptions clientOptions = null);
    
    public EventHubConsumerClient(
        string consumerGroup, 
        EventHubConnection connection, 
        EventHubConsumerClientOptions clientOptions = null);
        
    // Mocking constructors
    protected EventHubConsumerClient();
    
    public virtual Task CloseAsync(CancellationToken cancellationToken = default(CancellationToken));
    public virtual ValueTask DisposeAsync();
    
    public virtual Task<EventHubProperties> GetEventHubPropertiesAsync(CancellationToken cancellationToken = default);
    public virtual Task<string[]> GetPartitionIdsAsync(CancellationToken cancellationToken = default);
    public virtual Task<PartitionProperties> GetPartitionPropertiesAsync(string partitionId, CancellationToken cancellationToken = default);
    
    public virtual IAsyncEnumerable<PartitionEvent> ReadEventsAsync(CancellationToken cancellationToken = default);
    public virtual IAsyncEnumerable<PartitionEvent> ReadEventsAsync(ReadEventOptions readOptions, CancellationToken cancellationToken = default);
    public virtual IAsyncEnumerable<PartitionEvent> ReadEventsAsync(bool startReadingAtEarliestEvent, ReadEventOptions readOptions = default, CancellationToken cancellationaToken = default);
    
    public virtual IAsyncEnumerable<PartitionEvent> ReadEventsFromPartitionAsync(string partitionId, EventPosition startingPosition, CancellationToken cancellationToken = default);
    public virtual IAsyncEnumerable<PartitionEvent> ReadEventsFromPartitionAsync(string partitionId, EventPosition startingPosition, ReadEventOptions readOptions, CancellationToken cancellationToken = default);
}

public class EventHubConsumerClientOptions 
{
    public EventHubConnectionOptions ConnectionOptions { get; set; }
    public EventHubsRetryOptions RetryOptions { get; set; }
}

public struct EventPosition : IEquatable<EventPosition>
{
    public static EventPosition Earliest { get; }
    public static EventPosition Latest { get; }
    
    public static EventPosition FromEnqueuedTime(DateTimeOffset enqueuedTime);
    public static EventPosition FromOffset(long offset, bool isInclusive = true);
    public static EventPosition FromSequenceNumber(long sequenceNumber, bool isInclusive = true);
    
    public bool Equals(EventPosition other);
    public static bool operator ==(EventPosition first, EventPosition second);
    public static bool operator !=(EventPosition first, EventPosition second);
}

public struct LastEnqueuedEventProperties 
{
    public long? Offset { get; }
    public long? SequenceNumber { get; }
    public DateTimeOffset? EnqueuedTime { get; }
    public DateTimeOffset? LastReceivedTime { get; }
    
    public LastEnqueuedEventProperties(
        long? sequenceNumber, 
        long? offset, 
        DateTimeOffset? enqueuedTime, 
        DateTimeOffset? lastReceivedTime);
}

public class PartitionContext
{
    public string PartitionId { get; }
    public virtual LastEnqueuedEventProperties ReadLastEnqueuedEventProperties();
    
    // Mocking constructor
    protected internal PartitionContext(string partitionId);
}

public struct PartitionEvent
{
    public PartitionContext Partition { get; }
    public EventData Data { get; }
    
    public PartitionEvent(
        PartitionContext partition,
        EventData data);
}

public class ReadEventOptions 
{
    public TimeSpan? MaximumWaitTime { get; set; }
    public long? OwnerLevel { get; set; }
    public bool TrackLastEnqueuedEventProperties { get; set; }
}
```

### `Azure.Messaging.EventHubs.Producer`
```csharp
public class EventHubProducerClient : IAsyncDisposable 
{
    public bool IsClosed { get; protected set; }
    public virtual string EventHubName { get; }
    public virtual string FullyQualifiedNamespace { get; }
    
    // Basic constructors
    public EventHubProducerClient(string connectionString);
        
    public EventHubProducerClient(
        string connectionString, 
        EventHubProducerClientOptions clientOptions);
        
    public EventHubProducerClient(
        string connectionString, 
        string eventHubName);
        
    public EventHubProducerClient(
        string connectionString, 
        string eventHubName, 
        EventHubProducerClientOptions clientOptions);
    
    // Advanced constructors
    public EventHubProducerClient(
        string fullyQualifiedNamespace, 
        string eventHubName, 
        TokenCredential credential, 
        EventHubProducerClientOptions clientOptions = null);
        
    public EventHubProducerClient(
        EventHubConnection connection, 
        EventHubProducerClientOptions clientOptions = null);
    
    // Mocking constructors
    protected EventHubProducerClient();
    
    public virtual Task CloseAsync(CancellationToken cancellationToken = default);
    public virtual ValueTask DisposeAsync();
    
    public virtual Task<EventHubProperties> GetEventHubPropertiesAsync(CancellationToken cancellationToken = default);
    public virtual Task<string[]> GetPartitionIdsAsync(CancellationToken cancellationToken = default);
    public virtual Task<PartitionProperties> GetPartitionPropertiesAsync(string partitionId, CancellationToken cancellationToken = default);
    
    public virtual ValueTask<EventDataBatch> CreateBatchAsync(CreateBatchOptions options, CancellationToken cancellationToken = default);
    public virtual ValueTask<EventDataBatch> CreateBatchAsync(CancellationToken cancellationToken = default);
    
    public virtual Task SendAsync(EventDataBatch eventBatch, CancellationToken cancellationToken = default);
}

public class EventHubProducerClientOptions 
{
    public EventHubConnectionOptions ConnectionOptions { get; set; }
    public EventHubsRetryOptions RetryOptions { get; set; }
}

public class CreateBatchOptions
{
    public long? MaximumSizeInBytes { get; set; }
    public string PartitionId { get; set; }
    public string PartitionKey { get; set; }
}

public sealed class EventDataBatch : IDisposable 
{
    public int Count { get; }
    public long MaximumSizeInBytes { get; }
    public long SizeInBytes { get; }
    public void Dispose();
    public bool TryAdd(EventData eventData);
}
```

### `Azure.Messaging.EventHubs.Processor`
```csharp
public struct ProcessEventArgs 
{
    public bool HasEvent { get; }
    public PartitionContext Partition { get; }
    public EventData Data { get; }
    public CancellationToken CancellationToken { get; }
    
    public ProcessEventArgs(
        PartitionContext partition,
        EventData data,
        Func<Task> updateCheckpointImplementation,
        CancellationToken cancellationToken = default);
    
    public Task UpdateCheckpointAsync(CancellationToken cancellationToken = default);
}

public class PartitionInitializingEventArgs
{
    public string PartitionId { get; }
    public EventPosition DefaultStartingPosition { get; set; }
    public CancellationToken CancellationToken { get; }
    
    public PartitionInitializingEventArgs(
        string partitionId,
        EventPosition defaultStartingPosition,
        CancellationToken cancellationToken = default);
}

public class PartitionClosingEventArgs 
{
    public string PartitionId { get; }
    public ProcessingStoppedReason Reason { get; }
    public CancellationToken CancellationToken { get; }
    
    public PartitionClosingEventArgs(
        string partitionId,
        ProcessingStoppedReason reason,
        CancellationToken cancellationToken = default);
}

public struct ProcessErrorEventArgs
{
    public string PartitionId { get; }
    public string Operation { get; }
    public Exception Exception { get; }
    public CancellationToken CancellationToken { get; }
    
    public ProcessErrorEventArgs(
        string partitionId,
        string operation,
        Exception exception,
        CancellationToken cancellationToken = default);
}

public enum ProcessingStoppedReason 
{
    Shutdown,
    OwnershipLost
}
```

## Package: Azure.Messaging.EventHubs.Processor

### `Azure.Messaging.EventHubs.Processor`
```csharp
public class EventProcessorClient
{
    public string FullyQualifiedNamespace { get; }
    public string EventHubName { get; }
    public string ConsumerGroup { get; }
    public bool IsRunning { get; protected set; }
    public string Identifier { get; }
    
    // Optional events
    public event Func<PartitionInitializingEventArgs, Task> PartitionInitializingAsync;
    public event Func<PartitionClosingEventArgs, Task> PartitionClosingAsync;

    // Required events
    public event Func<ProcessArgs, Task> ProcessEventAsync;
    public event Func<ProcessErrorEventArgs, Task> ProcessErrorAsync;
    
    // Basic constructors
    public EventProcessorClient(
        BlobContainerClient checkpointStore,
        string consumerGroup, 
        string connectionString);
        
    public EventProcessorClient(
        BlobContainerClient checkpointStore,
        string consumerGroup, 
        string connectionString, 
        EventProcessorClientOptions clientOptions);
        
    public EventProcessorClient(
        BlobContainerClient checkpointStore,
        string consumerGroup, 
        string connectionString, 
        string eventHubName);
        
    public EventProcessorClient(
        BlobContainerClient checkpointStore,
        string consumerGroup, 
        string connectionString, 
        string eventHubName, 
        EventProcessorClientOptions clientOptions);
    
    // Advanced constructors
    public EventProcessorClient(
        BlobContainerClient checkpointStore,
        string consumerGroup,  
        string fullyQualifiedNamespace, 
        string eventHubName, 
        TokenCredential credential, 
        EventProcessorClientOptions clientOptions = null);
    
    // Mocking constructors
    protected EventProcessorClient();
    
    // Behaviors
    public virtual Task StartProcessingAsync(CancellationToken pcancellationToken = default);
    public virtual void StartProcessing(CancellationToken cancellationToken = default);
    public virtual Task StopProcessingAsync(CancellationToken cancellationToken = default);
    public virtual void StopProcessing(CancellationToken cancellationToken = default);
}

public class EventProcessorClientOptions 
{
    public string Identifier { get; set; }
    public bool TrackLastEnqueuedEventProperties { get; set; }
    public TimeSpan? MaximumWaitTime { get; set; }
    public EventHubConnectionOptions ConnectionOptions { get; set; }
    public EventHubsRetryOptions RetryOptions { get; set; }
}
```