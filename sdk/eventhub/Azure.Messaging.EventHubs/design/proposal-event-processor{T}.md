# .NET Event Hubs Client: Event Processor&lt;T&gt; Proposal

The Event Hubs client library offers two primary clients for consuming events, the `EventHubConsumerClient` and `EventProcessorClient`, each designed for slightly different scenarios but unified in their approach to provide a consistent experience for developers starting with the "Hello World" experience and stepping-up to production use.  These clients embrace a common design philosophy in providing developers an experience optimized around ease of use, familiar patterns, and a consistent API across them.

The `EventProcessorClient` is an opinionated implementation offering a familiar paradigm built on the .NET event handler pattern and striving for consistency with the iterator-based consumption model used by the `EventHubConsumerClient`.  In order to offer API consistency and minimize complexity, it works at a high level of abstraction with separation between its API and the low-level service operations.  The `EventProcessorClient` is fairly rigid, providing a development experience "on rails" with minimal opportunity to customize or opt-into the additional complexity for a "closer to the metal" experience.

## Things to know before reading

- The names used in this document are intended for illustration only. Some names are not ideal and may not fully conform to guidelines; these will be refined during discussion and board reviews.

- Some details not related to the high-level concept are not illustrated; the scope of this is limited to the high level shape and paradigms for the feature area.

- Fake methods are used to illustrate "something needs to happen, but the details are unimportant."  As a general rule, if an operation is not directly related to one of the Event Hubs types, it can likely be assumed that it is for illustration only.  These methods will most often use ellipses for the parameter list, in order to help differentiate them.

## Target segment: Developers with specialized needs

These are developers working on products which have special needs that are often specialized and do not fit into the majority case for many Event Hubs client library users. While this segment has a much smaller addressable market, those that fall into this segment often drive a large amount of ACR.

These developers are interested in using the low-level components of the Event Hubs client library, focused around client-service communication that they can control and customize to meet their needs. This class of developers are considered advanced users of Event Hubs with a deep understanding of the service, cloud development, and messaging systems. Many are willing to accept the complexity of working with lower-level components for the ability to have more control for their implementation.

## Why this is needed

The current `EventProcessorClient` implementation is opinionated and focused on providing a step-up experience for developers used to consuming events from the `EventHubConsumerClient` and its iterator pattern.  In order to reduce complexity, each `EventProcessorClient` is also bound to a specific storage provider whose dependencies are bundled with the processor's package.

To meet its goals `EventProcessorClient` chose to limit flexibility and make use of higher-level patterns to reduce complexity, simplify use, and offer an experience familiar to `EventHubConsumerClient` users.  As a result, it does not address advanced scenarios requiring higher throughput nor where customization is desired.

## Design goals

- Allow developers to create a custom `EventProcessor` by implementing and overriding a base class.  The base should require minimal ceremony and allow for method overrides for functionality rather than making use of higher-level patterns such as event handlers.

- The base class should handle the low-level implementation details, such as ensuring resiliency when reading events and performing collaborative load balancing with other processors working against the same Event Hub and consumer group.

- Work natively with event batches, utilizing the low-level partition receiver to achieve the highest possible throughput and avoid the local caching used by the `EventHubConsumerClient` when surfacing events via its iterators.

- Allow tuning of low-level options for reading events, so that developers can maximize efficiency and throughput for their specific application scenarios.

- Provide a neutral interface for storage operations, allowing developers to utilize whatever underlying storage they prefer, taking responsibility for the persistence of state.

## Key types

### Event Processor<TPartition>

An abstract set of base functionality as a starting point for extension.  Base functionality includes cooperative load balancing, resiliency for service operations, and infrastructure for event processing and error handling.

- Processes events in batches, rather than single events.

- Guarantees that only one event-batch-per-partition is dispatched for processing at one time and manages concurrency to allow multiple partitions to be processing at once.

- Does not impose the higher-level abstractions of the opinionated client; operations are performed by overriding/implementing base class methods rather than using an event-based model. The arguments for these methods are built around the set of lower-level types and do not make use of the `EventArg` abstractions.

- Allows for a custom set of information to be tracked and flow through the infrastructure for custom context associated with a specific partition.

### Event Processor Options 

In addition to the standard connection and retry options, allows configuration of lower-level details such as the batch size and prefetch count for optimal tuning.

### Event Processor Partition

Represents the base for custom partition context types used within the procesor to represent the active partition context for a given operation.

### Event Processor Checkpoint

The representation of the last event seen by a processor for a given Event Hub, consumer group, and partition combination.  This is intended to be a durable representation of state, allowing processing to resume from the next event should partition ownership change or processing restart.

### Partition Ownership

Denotes that a specific Event Processor owns the responsibility of processing the partition for a given Event Hub and consumer group.  Ownership may change as processing work is balanced among active processors for the Event Hub and consumer group combination.

## Usage examples

### Create a minimal custom processor

```csharp
public class CustomProcessor : EventProcessor<EventProcessorPartition>
{
    // Local event processing
    protected override async Task OnProcessingEventBatchAsync(IEnumerable<EventData> events, EventProcessorPartition partition, CancellationToken cancellationToken = default)
    {
        await DoSomethingWithEvents(events).ConfigureAwait(false);
        Log.Information($"Received event batch for partition: { partition.PartitionId }");
    }
    
    protected override Task OnProcessingErrorAsync(Exception exception, EventProcessorPartition partition, string operationDescription, CancellationToken cancellationToken = default)
    {
        Log.Error(exception, $"Error occured for partition: { partition.PartitionId } during { operationDescription }.");
        return Task.CompletedTask;
    }
    
    // Storage integration
    protected override Task<IEnumerable<EventProcessorCheckpoint>> ListCheckpointsAsync(CancellationToken cancellationToken) =>
        CustomStorage.GetCheckpointsAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup);
    
    protected override Task<IEnumerable<EventProcessorPartitionOwnership>> ListOwnershipAsync(CancellationToken cancellationToken) =>
        CustomStorage.GetOwnershipAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup, Identifier);
    
    protected override Task<IEnumerable<EventProcessorPartitionOwnership>> ClaimOwnershipAsync(IEnumerable<EventProcessorPartitionOwnership> desiredOwnership, CancellationToken cancellationToken) =>
        CustomStorage.TryUpdateOwnershipAsync(desiredOwnership);
}
```

### Create a custom processor with custom partition context

```csharp
public class CustomPartition : EventProcessorPartition
{
    public int ClientSecret { get; }
}

public class CustomProcessor : EventProcessor<CustomPartition>
{
    // Initialize processing for the partition, including creating its context.
    protected override Task OnPartitionInitializingAsync(CustomPartition partition, CancellationToken cancellationToken)
    {
        partition.ClientSecret = partition.PartitionId.GetHashCode();
        return Task.CompletedTask;
    }
    
    // Local event processing
    protected override async Task OnProcessingEventBatchAsync(IEnumerable<EventData> events, CustomPartition partition, CancellationToken cancellationToken = default)
    {
        await DoSomethingWithEvents(events).ConfigureAwait(false);
        Log.Information($"Received event batch for partition: { partition.PartitionId }");
    }
    
    protected override Task OnProcessingErrorAsync(Exception exception, CustomPartition partition, string operationDescription, CancellationToken cancellationToken = default)
    {
        Log.Error(exception, $"Error occured for partition: { partition.PartitionId } during { operationDescription }.");
        return Task.CompletedTask;
    }
    
    // Storage integration
    protected override Task<IEnumerable<EventProcessorCheckpoint>> ListCheckpointsAsync(CancellationToken cancellationToken) =>
        CustomStorage.GetCheckpointsAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup);
    
    protected override Task<IEnumerable<EventProcessorPartitionOwnership>> ListOwnershipAsync(CancellationToken cancellationToken) =>
        CustomStorage.GetOwnershipAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup, Identifier);
    
    protected override Task<IEnumerable<EventProcessorPartitionOwnership>> ClaimOwnershipAsync(IEnumerable<EventProcessorPartitionOwnership> desiredOwnership, CancellationToken cancellationToken) =>
        CustomStorage.TryUpdateOwnershipAsync(desiredOwnership);
}
```

### Create a processor and perform basic event processing

```csharp
public class CustomProcessor : EventProcessor<EventProcessorPartition> 
{
    // ... implementation
}

// Create the processor
var processor = new CustomProcessor(
    100, 
    EventHubConsumerClient.DefaultConsumerGroupName,
    "somenamespace.thing.servicebus.net",
    "myAwesomeHub",
    new DefaultAzureCredential());
    
// Processing for events and errors is defined as part
// of the custom processor class.  There are no handlers
// to hook up here.

await processor.StartProcessingEventsAsync();

// Developer code can continue to perform actions;
// processing is taking place in the background.

using var cancellationSource = new TokenCancellationSource();
cancellationSource.CancelAfter(Timespan.FromMinutes(5));

try
{
    await Task.Delay(Timeout.Infinite, cancellationSource.Token);
}
catch (TaskCanceledException)
{
    // Expected; no action is necessary.
}

await processor.StopProcessingAsync();
```

### Create a processor with custom options

```csharp
public class CustomProcessor : EventProcessor<EventProcessorPartition>
{
    // ... implementation
}

var options = new EventProcessorOptions
{
    Identifier = "RedFive",
    PrefetchCount = 300,
    TrackLastEnqueuedEventProperties = true
};

// Specify the default starting position when no checkpoint was found.
//
// Overriding the default starting position for specific partitions can be achieved by 
// returning the desired location when ListCheckpointsAsync is called.
options.DefaultStartingPosition = EventPosition.Latest;

// Create the processor
var processor = new CustomProcessor(
    100, 
    EventHubConsumerClient.DefaultConsumerGroupName,
    "somenamespace.thing.servicebus.net",
    "myAwesomeHub",
    new DefaultAzureCredential(),
    options);
```

### Create a minimal custom processor with in-memory storage

```csharp
public class CustomProcessor : EventProcessor<EventProcessorPartition>
{
    private InMemoryStorage Storage { get; } = new InMemoryStorage();
    
    // Local event processing
    protected override async Task OnProcessingEventBatchAsync(IEnumerable<EventData> events, EventProcessorPartition partition, CancellationToken cancellationToken = default)
    {
        var checkpointEvent = events.Last();
        
        await DoSomethingWithEvents(events).ConfigureAwait(false);
        await Storage.CreateCheckpointAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup, partition.PartitionId, checkpointEvent.Offset, checkpointEvent.SequenceNumber).ConfigureAwait(false);
        Log.Information($"Received event batch for partition: { partition.PartitionId }");
    }
    
    protected override Task OnProcessingErrorAsync(Exception exception, EventProcessorPartition partition, string operationDescription, CancellationToken cancellationToken = default)
    {
        Log.Error(exception, $"Error occured for partition: { partition.PartitionId } during { operationDescription }.");
        return Task.CompletedTask;
    }
    
    // Storage integration
    protected override Task<IEnumerable<EventProcessorCheckpoint>> ListCheckpointsAsync(CancellationToken cancellationToken) =>
        Storage.GetCheckpointsAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup);
    
    protected override Task<IEnumerable<EventProcessorPartitionOwnership>> ListOwnershipAsync(CancellationToken cancellationToken) =>
        Storage.GetOwnershipAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup, Identifier);
    
    protected override Task<IEnumerable<EventProcessorPartitionOwnership>> ClaimOwnershipAsync(IEnumerable<EventProcessorPartitionOwnership> desiredOwnership, CancellationToken cancellationToken) =>
        Storage.TryClaimOwnershipAsync(desiredOwnership);
}

public class InMemoryStorage
{
    private ConcurrentDictionary<string, ConcurrentDictionary<string, EventProcessorCheckpoint>> Checkpoints { get; } = new ConcurrentDictionary<string, ConcurrentDictionary<string, EventProcessorCheckpoint>>();
    private ConcurrentDictionary<string, ConcurrentDictionary<string, EventProcessorPartitionOwnership>> Ownership { get; } = new ConcurrentDictionary<string, ConcurrentDictionary<string, EventProcessorPartitionOwnership>>();

    public Task CreateCheckpointAsync(
        string fullyQualifiedNamespace,
        string eventHubName,
        string consumerGroup,
        string partitionId,
        long? offset,
        long? sequenceNumber)
    {
        var key = CreateKey(fullyQualifiedNamespace, eventHubName, consumerGroup);
        var checkpoints = Checkpoints.GetOrAdd(key, newKey => new ConcurrentDictionary<string, EventProcessorCheckpoint>());
        
        var partitionCheckpoint = checkpoints.GetOrAdd(partitionId, new EventProcessorCheckpoint
        {
            FullyQualifiedNamespace = fullyQualifiedNamespace,
            EventHubName = eventHubName, 
            ConsumerGroup = consumerGroup,
            PartitionId = partitionId
        });
        
        if (offset.HasValue)
        {
            partitionCheckpoint.StartingPosition = EventPosition.FromOffset(offset.Value, false);
        }
        else
        {
            partitionCheckpoint.StartingPosition = EventPosition.FromSequenceNumber(sequenceNumber.Value, false);
        }
        
        return Task.CompletedTask;
    }

    public Task<IEnumerable<EventProcessorCheckpoint>> GetCheckpointsAsync(
        string fullyQualifiedNamespace,
        string eventHubName,
        string consumerGroup)
    {
        var key = CreateKey(fullyQualifiedNamespace, eventHubName, consumerGroup);
        var checkpoints = Checkpoints.GetOrAdd(key, newKey => new ConcurrentDictionary<string, EventProcessorCheckpoint>());
        return Task.FromResult((IEnumerable<EventProcessorCheckpoint>)checkpoints.Values);
    }

    public Task<IEnumerable<EventProcessorPartitionOwnership>> GetOwnershipAsync(
        string fullyQualifiedNamespace,
        string eventHubName,
        string consumerGroup)
    {
        var key = CreateKey(fullyQualifiedNamespace, eventHubName, consumerGroup);
        var ownership = Ownership.GetOrAdd(key, newKey => new ConcurrentDictionary<string, EventProcessorPartitionOwnership>());
        return Task.FromResult(ownership.Values.Where(item => item.OwnerIdentifier != identifier));
    }
    
    public Task<IEnumerable<EventProcessorPartitionOwnership>> TryClaimOwnershipAsync(
        IEnumerable<EventProcessorPartitionOwnership> desiredOwnership)
    {
        if (desiredOwnership == null)
        {
            return Task.FromResult(Enumerable.Empty<EventProcessorPartitionOwnership>());
        }
        
        var claimedOwnership = new List<EventProcessorPartitionOwnership>();

        foreach (var claim in desiredOwnership)
        {
            var key = CreateKey(claim.FullyQualifiedNamespace, claim.EventHubName, claim.ConsumerGroup);
            var claimedPartitions = Ownership.GetOrAdd(key, newKey => new ConcurrentDictionary<string, EventProcessorPartitionOwnership>());
            var nextVersion = new Version(Guid.NewGuid().ToString());

            var ownership = claimedPartitions.AddOrUpdate(claim.PartitionId,
                partitionId => new EventProcessorPartitionOwnership
                (
                    claim.FullyQualifiedNamespace,
                    claim.EventHubName,
                    claim.ConsumerGroup,
                    claim.OwnerIdentifier,
                    claim.PartitionId,
                    claim.LastModifiedTime,
                    nextVersion
                ),                
                (partitionId, existingOwnership) => 
                {
                    if (!string.Equals(existingOwnership.Version, claim.Version, StringComparison.OrdinalIgnoreCase))
                    {
                        return existingOwnership;
                    }

                    return new EventProcessorPartitionOwnership
                    (
                        claim.FullyQualifiedNamespace,
                        claim.EventHubName,
                        claim.ConsumerGroup,
                        claim.OwnerIdentifier,
                        claim.PartitionId,
                        claim.LastModifiedTime, 
                        nextVersion
                    );
                }
            );
                        
            if (ownership.Version == nextVersion)
            {
                claimedOwnership.Add(ownership);
            }
        }

        return Task.FromResult((IEnumerable<EventProcessorPartitionOwnership>)claimedOwnership);
    }

    private string CreateKey(
        string fullyQualifiedNamespace,
        string eventHubName,
        string consumerGroup) => $"{ fullyQualifiedNamespace }/{ eventHubName }/{ consumerGroup }";
}
```

## API skeleton

### `Azure.Messaging.EventHubs.Primitives`

```csharp
public abstract class EventProcessor<TPartition> where TPartition : EventProcessorPartition, new()
{
    public string FullyQualifiedNamespace { get; }
    public string EventHubName { get; }
    public string ConsumerGroup { get; }
    public string Identifier { get; protected set; }
    public bool IsRunning { get; protected set; }
    protected EventHubsRetryPolicy RetryPolicy { get; }
    
    protected EventProcessor(
        int eventBatchMaximumCount,
        string consumerGroup, 
        string connectionString, 
        EventProcessorOptions options = default);
        
    protected EventProcessor(
        int eventBatchMaximumCount,
        string consumerGroup, 
        string connectionString, 
        string eventHubName, 
        EventProcessorOptions options = default);
    
    protected EventProcessor(
        int eventBatchMaximumCount,
        string consumerGroup,  
        string fullyQualifiedNamespace, 
        string eventHubName, 
        TokenCredential credential, 
        EventProcessorOptions options = default);
    
    // Optional extension points (core)
    public virtual Task StartProcessingAsync(CancellationToken cancellationToken = default);
    public virtual void StartProcessing(CancellationToken cancellationToken = default);
    public virtual Task StopProcessingAsync(CancellationToken cancellationToken = default);
    public virtual void StopProcessing(CancellationToken cancellationToken = default);
    protected virtual EventHubConnection CreateConnection();
    
    protected virtual Task OnInitializingPartitionAsync(TPartition partition, CancellationToken cancellationToken);
    protected virtual Task OnPartitionProcessingStoppedAsync(TPartition partition, ProcessingStoppedReason reason, CancellationToken cancellationToken);
    
    // Required extension points (core)
    protected abstract Task OnProcessingEventBatchAsync(IEnumerable<EventData> events, TPartition partition, CancellationToken cancellationToken);
    protected abstract Task OnProcessingErrorAsync(Exception exception, TPartition partition, string operationDescription, CancellationToken cancellationToken);
    
    // Required extension points (storage operations)
    protected abstract Task<IEnumerable<EventProcessorCheckpoint>> ListCheckpointsAsync(CancellationToken cancellationToken);
    protected abstract Task<IEnumerable<EventProcessorPartitionOwnership>> ListOwnershipAsync(CancellationToken cancellationToken);
    protected abstract Task<IEnumerable<EventProcessorPartitionOwnership>> ClaimOwnershipAsync(IEnumerable<EventProcessorPartitionOwnership> desiredOwnership, CancellationToken cancellationToken);
    
    // Infrastructure
    protected internal virtual CreateConnection();
    protected virtual LastEnqueuedEventProperties ReadLastEnqueuedEventProperties(string partitionId);
}

public class EventProcessorOptions 
{
    public EventHubConnectionOptions ConnectionOptions { get; set; }
    public EventHubsRetryOptions RetryOptions { get; set; }
    public string Identifier { get; set; }
    public int PrefetchCount { get; set; } 
    public bool TrackLastEnqueuedEventProperties { get; set; }
    public TimeSpan? MaximumWaitTime { get; set; } = TimeSpan.FromSeconds(60);
    public EventPosition DefaultStartingPosition { get; set; } = EventPosition.Earliest;
    public TimeSpan LoadBalancingUpdateInterval { get; set; } = TimeSpan.FromSeconds(10);
    public TimeSpan PartitionOwnershipExpirationInterval { get; set; } = TimeSpan.FromSeconds(30);
}

public class EventProcessorPartition
{
    public string PartitionId { get; internal set; }
}

public class EventProcessorCheckpoint
{
    public string FullyQualifiedNamespace { get; set; }
    public string EventHubName { get; set; }
    public string ConsumerGroup { get; set; }
    public string PartitionId { get; set; }
    public EventPosition StartingPosition { get; set; }
}

public class EventProcessorPartitionOwnership
{
    public string FullyQualifiedNamespace { get; set; }
    public string EventHubName { get; set; }
    public string ConsumerGroup { get; set; }
    public string OwnerIdentifier { get; set; }
    public string PartitionId { get; set; }
    public string Version { get; set; }
    public DateTimeOffset LastModifiedTime { get; set; }
}
```

## Namespace organization

### Package: Azure.Messaging.EventHubs

#### `Azure.Messaging.EventHubs.Primitives`
```csharp
public class EventProcessor<TPartition> {}
public class EventProcessorOptions {}
public class EventProcessorCheckpoint {}
public class EventProcessorPartition {}
public class EventProcessorPartitionOwnership {}
public class PartitionReceiver {}
public class PartitionReceiverOptions {}
```

#### `Azure.Messaging.EventHubs.Processor`
```csharp
public struct ProcessEventArgs {} 
public class PartitionInitializingEventArgs {}
public class PartitionClosingEventArgs {} 
public struct ProcessErrorEventArgs {}
public enum ProcessingStoppedReason {}
```

#### `Azure.Messaging.EventHubs`
```csharp
public class EventHubConnection {}
public class EventHubConnectionOptions {}
public class EventData {}
public class EventHubsException {}
public class EventHubProperties {}
public abstract class EventHubsRetryPolicy {}
public enum EventHubsRetryMode {}
public class EventHubsRetryOptions {}
public enum EventHubsTransportType {}
public class PartitionProperties {}
```

#### `Azure.Messaging.EventHubs.Consumer`
```csharp
public class EventHubConsumerClient {}
public class EventHubConsumerClientOptions {}
public struct EventPosition {}
public struct LastEnqueuedEventProperties {}
public class PartitionContext {}
public struct PartitionEvent {}
public class ReadEventOptions {}
```

#### `Azure.Messaging.EventHubs.Producer`
```csharp
public class EventHubProducerClient {}
public class EventHubProducerClientOptions {}
public class CreateBatchOptions {}
public sealed class EventDataBatch {}
```

### Package: Azure.Messaging.EventHubs.Processor

#### `Azure.Messaging.EventHubs.Processor`
```csharp
public class EventProcessorClient {}
public class EventProcessorClientOptions {}
```