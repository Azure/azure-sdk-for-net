# .NET Event Hubs Client: Partition Receiver Proposal

The Event Hubs client library offers two primary clients for consuming events, the `EventHubConsumerClient` and `EventProcessorClient`, each designed for slightly different scenarios but unified in their approach to provide a consistent experience for developers starting with the "Hello World" experience and stepping-up to production use.  These clients embrace a common design philosophy in providing developers an experience optimized around ease of use, familiar patterns, and a consistent API across them.

Because of their respective focus, neither is able to fully address advanced scenarios requiring higher throughput nor where customization is desired.

## Things to know before reading

- The names used in this document are intended for illustration only. Some names are not ideal and may not fully conform to guidelines; these will be refined during discussion and board reviews.

- Some details not related to the high-level concept are not illustrated; the scope of this is limited to the high level shape and paradigms for the feature area.

- Fake methods are used to illustrate "something needs to happen, but the details are unimportant."  As a general rule, if an operation is not directly related to one of the Event Hubs types, it can likely be assumed that it is for illustration only.  These methods will most often use ellipses for the parameter list, in order to help differentiate them.

## Target segment: Developers with specialized needs

These are developers working on products which have special needs that are often specialized and do not fit into the majority case for many Event Hubs client library users. While this segment has a much smaller addressable market, those that fall into this segment often drive a large amount of ACR.

These developers are interested in using the low-level components of the Event Hubs client library, focused around client-service communication that they can control and customize to meet their needs. This class of developers are considered advanced users of Event Hubs with a deep understanding of the service, cloud development, and messaging systems. Many are willing to accept the complexity of working with lower-level components for the ability to have more control for their implementation.

## Why this is needed

Because the `EventHubConsumerClient` is not bound to a specific partition, it cannot directly interact with a partition to read events.  In order to read events from a partition, the client needs to spawn a transport consumer to communicate with the service by creating an AMQP link and manage the state for reading from the partition, such as the identifier of partition and the position within the event stream being read.

While it would be possible to add a `ReceiveBatch` method directly on the consumer client, that introduces challenges for providing a clean and understandable API and for managing resource use.  The theoretical `ReceiveBatch` method would have to have a signature similar to `ReceiveBatch(string partition, EventPosition position);`  Calling the method would create an AMQP link if one did not exist for the partition, set the position, and read a batch of events.  

The challenges begin after the first call.  Should a developer invoke the method more than once, they would have to advance the `EventPosition` argument to match the last event read to express the intent of "continue where we left off," otherwise, the existing AMQP link for that partition would have to be closed and a new one created at the desired position.  Ultimately, this places a heavy burden on callers, having to track a virtual checkpoint after each `ReceiveBatch` call or would result in the undesirable behavior of network resources being created/destroyed often.  Should the link not be destroyed within the scope of the call, a measure of non-determinism is introduced in which the developer lacks the ability to express the intent to stop reading from that partition and clean up resources.

For more context and examples, please refer to the [addendum](#addendum-why-this-is-needed-by-example).

## High level scenarios

### A multiplayer game can issue rewards in real-time

A popular multiplayer game powers its experience through an ecosystem of services, each responsible for different aspects of game play and player experience.  As part of their operation, the services communicate with each other as well as integrate with other downstream systems.  Azure Event Hubs is used as a means of passive coordination to avoid direct calls within the ecosystem.

An important part of the game experience is for players to receive toast notifications in-game when they receive an award for game activities, such as achieving a specific number of head shots or finding a hidden part of the map.  These notifications are triggered by events which are sent to a specific partition of an Event Hub, are read by a dedicated consumer for that partition.  Once read, the consumer activates the service entity dedicated to the associated match-in-progress.

When the reward notification is received, the service entity responsible for the match-in-progress stops reading and processing other types of events.  It is important for it to be in a ready state, available and waiting for the game client to poll for information, since polling can only happen at limited intervals of the game loop.  

As a cost-control mechanism, the game and player services are hosted in a densely packed manner; resource utilization for the host environment is intended to run high and is managed cooperatively by the hosted services.  Each service must be mindful of background activities and use of machine and network resources in order to ensure that the services are responsive and performant as a whole.

### An interactive streaming media platform can degrade gracefully

As e-sports continue to grow in popularity, many of the high-profile multiplayer games are now sponsoring tournaments and companion applications to watch them streaming.  One such game offers a companion application across different platforms and consumer devices, such as game consoles, PCs, tablets, and mobile phones.  Processing power, memory, and network bandwidth are expected to  differ and the application must degrade gracefully when necessary.

The presentation for matches is a combination of streaming video from the competitors and overlays from the production crew.  Each of these is sent to the application individually, with the client responsible for assembling them for the final presentation.  The video stream is sent via direct socket connection in response to an application request.  Overlay data is communicated passively using an Event Hub with each partition carrying a specific class of information.

To provide the best user experience, the application must prioritize video availability and quality.  The ability for a user to watch a match in real-time, with smooth and even video and audio is essential.  When resources are constrained, the application will compensate by progressively trimming back the experience. To that end, awareness and control over network and resource use is critical for the application to have. 

First, the application will only read higher priority overlay data from the Event Hub partition.  Next, the application will cease reading any overlay data.  Finally, the quality of video will be downgraded.  These mitigations are applied dynamically and the application will endeavor to provide the full experience as constraints allow.

### Manufacturing device upgrade coordination

A large manufacturer makes use of a local Azure Stack instance to provide an Event Hubs service within its onsite network.  The devices on the manufacturing floor are Wi-Fi enabled and make use of events to coordinate with the manufacturing ecosystem.  One important activity that devices coordinate through Event Hubs is firmware upgrades.  It is important that upgrades be performed as efficiently as possible in order to keep manufacturing at optimal levels and not negatively impact production.

The process begins with an event being sent to a specific partition which indicates that a firmware upgrade is available for a class of machines.  When one of the machines reads this event, it begins a process of trying to reach distributed consensus for whether or not it may take itself out of service to apply the upgrade.

When consensus is reached, the machine will attempt to optimize download of the new firmware; during this time, bandwidth use is important to conserve and should be dedicated to the download.  The machine stops reading from Event Hubs, other than a single partition used to communicate an abort signal if the upgrade should be cancelled.  This partition is polled on a fixed interval while downloading and then at specific points of the firmware upgrade process where it is safe to rollback.

## Design goals

- Allow developers to create a scope with well-defined lifespan in which they can read event batches from a partition in a stateful manner and with predictable resource use.

- Ensure that developers are in control over creating and disposing of the scope and that resources needed for reading event batches are deterministically disposed along with the scope.

- Allow for creating multiple readers for the same partition concurrently, with each able to read from a different place in the event stream and operate independently.

- Follow conventions used for reading events using the `EventConsumerClient` and familiar for those using its iterator pattern.

## Key types

### Partition Receiver

The focal point for low-level receiving of events from a specific Event Hub partition; a thin wrapper over the underlying consumer.

- Provides a pull-based mechanism for batched events.

- Service communication and network activities are deterministic and associated with an on-demand request; no background operations are taking place.

### Partition Receiver Options

In addition to the standard connection and retry options, exposes a set of the low-level details for service communication, such as allowing the prefetch count to be tuned.

## Usage examples

### Creating a receiver

```csharp
// Event Hub connection string
var connectionString = "<< EVENT HUB CONNECTION STRING FROM PORTAL >>";
var consumerGroup = "$DEFAULT";
var partitionId = "0";
var initialPosition = EventPosition.FromOffset(123);
var consumer = new PartitionReceiver(consumerGroup, partitionId, initialPosition, connectionString);

// Namespace connection string and Event Hub name
var connectionString = "<< NAMESPACE CONNECTION STRING FROM PORTAL >>";
var hub = "Event Hub Name";
var consumerGroup = "$DEFAULT";
var partitionId = "0";
var initialPosition = EventPosition.FromOffset(123);
var consumer = new PartitionReceiver(consumerGroup, partitionId, initialPosition, connectionString, hub);

// Expanded form
var fqNamespace = "Fully Qualified Event Hubs Namespace";
var hub = "Event Hub Name";
var tokenCredential = GetCredentialFromIdentityClient(...);
var consumerGroup = "$DEFAULT";
var partitionId = "0";
var initialPosition = EventPosition.FromOffset(123);
var consumer = new PartitionReceiver(consumerGroup, partitionId, initialPosition, fqNamespace, hub, tokenCredential);

// Existing connection
var connection = new EventHubsConnection(...);
var consumerGroup = "$DEFAULT";
var partitionId = "0";
var initialPosition = EventPosition.FromOffset(123);
var consumer = new PartitionReceiver(consumerGroup, partitionId, initialPosition, connection);
```

### Consuming events from a partition

```csharp
using var cancellationSource = new CancellationTokenSource();
var maximumWaitTime = TimeSpan.FromSeconds(5);

await using var partitionReceiver = BuildReceiver(...);

while (!cancellationSource.IsCancellationRequested)
{
    // Request a batch of 100 events, waiting up to 5 seconds.  The returned batch may contain 
    // 0 - 100 events, depending on availability in the partition.
    var batch = await partitionReceiver.ReceiveBatchAsync(100, maximumWaitTime, cancellationSource.Token);
    await ProcessEventBatch(batch, cancellationSource.Token);
}
```

## API skeleton

### `Azure.Messaging.EventHubs.Specialized`
```csharp
public class PartitionReceiver : IAsyncDisposable 
{
    public bool IsClosed { get; protected set; }
    public string FullyQualifiedNamespace { get; }
    public string EventHubName { get; }
    public string ConsumerGroup { get; }
    public string PartitionId { get; }
    public EventPosition InitialPosition { get; }
    
    public PartitionReceiver(
        string consumerGroup, 
        string partitionId,
        EventPosition eventPosition,
        string connectionString, 
        PartitionReceiverOptions options = default);
        
    public PartitionReceiver(
        string consumerGroup, 
        string partitionId,
        EventPosition eventPosition,
        string connectionString,
        string eventHubName, 
        PartitionReceiverOptions options = default);
        
    public PartitionReceiver(
        string consumerGroup, 
        string partitionId,
        EventPosition eventPosition,
        string fullyQualifiedNamespace, 
        string eventHubName, 
        TokenCredential credential, 
        PartitionReceiverOptions options = default);
    
    public PartitionReceiver(
        string consumerGroup, 
        string partitionId,
        EventPosition eventPosition,
        EventHubConnection connection, 
        PartitionReceiverOptions options = default);
        
    // Mocking constructor
    protected PartitionReceiver();
    
    public virtual ValueTask DisposeAsync();
    public virtual CloseAsync(CancellationToken cancellationToken = default);
    
    public virtual Task<PartitionProperties> GetPartitionPropertiesAsync(CancellationToken cancellationToken = default);
    public virtual LastEnqueuedEventProperties ReadLastEnqueuedEventProperties();
    
    public virtual Task<IEnumerable<EventData>> ReceiveBatchAsync(int maximumEventCount, TimeSpan maximumWaitTime, CancellationToken cancellationToken = default);
    public virtual Task<IEnumerable<EventData>> ReceiveBatchAsync(int maximumEventCount, CancellationToken cancellationToken = default);
}

public class PartitionReceiverOptions 
{
    public EventHubConnectionOptions ConnectionOptions { get; set; }
    public EventHubsRetryOptions RetryOptions { get; set; }
    public long? OwnerLevel { get; set; }
    public int PrefetchCount { get; set; } = 300
    public bool TrackLastEnqueuedEventProperties { get; set; } = false
    public TimeSpan? DefaultMaximumReceiveWaitTime { get; set; } = TimeSpan.FromSeconds(60)
}
```

## Alternatives for consideration

If a new stand-alone type is not desired, creation of a partition receiver type could be delegated to the existing `EventHubConsumerClient`.  Because the consumer client is not bound to a specific partition, attempting to have a `Receive` call directly on that client would be confusing and awkward; instead, a dedicated scope would be used to allow developers to understand the context of the calls and reason about when an AMQP link was opened/closed.

### Consuming events from a partition _(alternate approach)_

```csharp
var partitionId = "0";
var initialPosition = EventPosition.Earliest;
var options = new PartitionReceiverOptions { PrefetchCount = 500 };
var maximumWaitTime = TimeSpan.FromSeconds(5);

using var cancellationSource = new CancellationTokenSource();

await using var consumer = BuildConsumerClient(...);
await using var receiver = consumer.CreatePartitionReceiver(partitionId, initialPosition, options);

while (!cancellationSource.IsCancellationRequested)
{
    // Request a batch of 100 events, waiting up to 5 seconds.  The returned batch may contain 
    // 0 - 100 events, depending on availability in the partition.
    var batch = await receiver.ReceiveBatchAsync(100, maximumWaitTime, cancellationSource.Token);
    await ProcessEventBatch(batch, cancellationSource.Token);
}
```

### API skeleton _(alternate approach)_

#### `Azure.Messaging.EventHubs.Consumer`

```csharp
public class EventHubConsumerClient : IAsyncDisposable 
{
    // ... SNIP ...
    
    public PartitionReceiver CreatePartitionReceiver(
        string partitionId,
        EventPosition eventPosition,
        PartitionReceiverOptions receiverOptions = default);
    
    // ... SNIP ...
}

public class PartitionReceiver : IAsyncDisposable 
{
    public bool IsClosed { get; protected set; }
    public string FullyQualifiedNamespace { get; }
    public string EventHubName { get; }
    public string ConsumerGroup { get; }
    public string PartitionId { get; }
    public EventPosition InitialPosition { get; }
        
    // Mocking constructors
    protected PartitionReceiver();
    
    protected PartitionReceiver(
        string fullyQualifiedNamespace,
        string eventHubName,
        string consumerGroup,
        string partitionId,
        EventPosition initialPosition);
    
    public virtual Task CloseAsync(CancellationToken cancellationToken = default);
    public virtual ValueTask DisposeAsync();
    
    public virtual Task<IEnumerable<EventData>> ReceiveBatchAsync(int maximumMessageCount, TimeSpan maximumWaitTime, CancellationToken cancellationToken = default);
    public virtual Task<IEnumerable<EventData>> ReceiveBatchAsync(int maximumMessageCount, CancellationToken cancellationToken = default);
    public virtual LastEnqueuedEventProperties ReadLastEnqueuedEventInformation();
}

public class PartitionReceiverOptions 
{
    public EventHubConnectionOptions ConnectionOptions { get; set; }
    public EventHubsRetryOptions RetryOptions { get; set; }
    public int PrefetchCount { get; set; } 
    public TimeSpan DefaultMaximumReceiveWaitTime { get; set; }
    public bool TrackLastEnqueuedEventInformation { get; set; }
    public long? OwnerLevel { get; set; }
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
public class PartitionOwnership {}
public class PartitionReceiver {}
public class PartitionReceiverOptions {}
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
public class PartitionContex {}
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

#### `Azure.Messaging.EventHubs.Processor`
```csharp
public struct ProcessEventArgs {} 
public class PartitionInitializingEventArgs {}
public class PartitionClosingEventArgs {} 
public struct ProcessErrorEventArgs {}
public enum ProcessingStoppedReason {}
```

### Package: Azure.Messaging.EventHubs.Processor

#### `Azure.Messaging.EventHubs.Processor`
```csharp
public class EventProcessorClient {}
public class EventProcessorClientOptions {}
```

## Addendum: Why this is needed, by example

Were a method for receiving batches to be added directly to the `EventHubConsumerClient`, it would be necessary for it to specify information about the partition, consumer group, and location in the event stream for which events would be read, since the client itself is not bound to a specific partition or consumer group context.  The signature of the method would likely look similar to:

```csharp
Task<IEnumerable<EventData>> ReceiveBatchAsync(
    string consumerGroup,
    string partitionId,
    EventPosition initialPosition,
    int batchSize
    TimeSpan maximumWaitTime,
    CancellationToken cancellationToken = default);
```

The expected usage for a developer who wished to read a batch of events from the first partition of `SomeHub`, in the context of the default consumer group, and starting with an event at the offset of 123 would be:

```csharp
var connectionString = "<< SOME CONNECTION STRING >>";
var eventHubName = "SomeHub";

await using var consumer = new EventHubConsumerClient(connectionString, eventHubName);

var consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;
var partition = (await consumer.GetPartitionIdsAsync()).First();
var position = EventPosition.FromOffset(123);
var batchSize = 100;
var waitTime = TimeSpan.FromSeconds(2);

var eventBatch = await consumer.ReceiveBatchAsync(consumerGroup, partition, position, batchSize, waitTime);
```

This first call seems reasonable and approachable.  However, subsequent calls become difficult for the developer to express their intent in a clear manner and for the client to efficiently manage resources.  To understand, consider that when this method is called, the consumer client will need to:

- Establish an AMQP connection to the Event Hub, if no other operation was performed previously
- Create an AMQP link to the desired partition and with the requested position in the event stream
- Initiate a request to read the batch of events  

At the end of the call, there remains an AMQP link open that is now pointed at the event that was last received.  For example, if all of the requested events were available then the position currently points to the event that is in position `offset(123) + batchSize + 1`.

When the `ReceiveBatchAsync` method is next invoked, determining the intent of the caller becomes difficult.  Consider the following snippet:

```csharp
using var cancellation = new CancellationTokenSource();
cancellation.CancelAfter(TimeSpan.FromMinutes(10));

await using var consumer = new EventHubConsumerClient(...);

var consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;
var partition = (await consumer.GetPartitionIdsAsync()).First();
var position = EventPosition.FromOffset(123);
var batchSize = 100;
var waitTime = TimeSpan.FromSeconds(2);

IEnumerable<EventData> eventBatch;

while (!cancellation.IsCancellationRequested)
{
    eventBatch = await consumer.ReceiveBatchAsync(consumerGroup, partition, position, batchSize, waitTime, cancellation.Token);
    await DoSomethingWithEventsAsync(eventBatch, cancellation.Token);
}
```

This seems like a reasonable pattern.  However, notice that the `position` specified for the call refers to `offset(123)` which was used to establish the service link.  The expectation on subsequent calls in the loop is not "please reset to the position" but rather "give me the next set of events in sequence."  

The client is then forced to try and infer the intent based on a heuristic such as "if a link is already open to the requested partition and used the specified position as its starting point, then deliver the next set of events rather than creating a new link."  Again this seems to be reasonable, if potentially a confusing set of semantics for those using the client.

At the same time, the client is also attempting to manage the lifespan of the AMQP link and determine when it should be closed.  Consider the preceding snippet again, though this time assume that `DoSomethingWithEventsAsync` is a long running call and takes minutes to complete.  During that time, the client reached the time period where it believes the link is abandoned and, if so, disposes of the AMQP link.  The next time that the method is called in the loop, the client has to recreate the link and treats it as a request to start at `offset(123)` again.  

Worse still would be the case where the client may or may not timeout and close the link, giving the caller an unclear set of results that can't be deterministically understood.  As a mitigation to that scenario, it may be tempting to revise the loop to something like:

```csharp
using var cancellation = new CancellationTokenSource();
cancellation.CancelAfter(TimeSpan.FromMinutes(10));

await using var consumer = new EventHubConsumerClient(...);

var consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;
var partition = (await consumer.GetPartitionIdsAsync()).First();
var position = EventPosition.FromOffset(123);
var batchSize = 100;
var waitTime = TimeSpan.FromSeconds(2);

IEnumerable<EventData> eventBatch;

while (!cancellation.IsCancellationRequested)
{
    eventBatch = await consumer.ReceiveBatchAsync(consumerGroup, partition, position, batchSize, waitTime, cancellation.Token);
    position = eventBatch.Last().Offset;
    
    await DoSomethingWithEventsAsync(eventBatch, cancellation.Token);
}
```

In this case, the client now becomes responsible for determining if the caller's intent is to continue communicating using the AMQP link created for `offset(123)` if it is available or requesting to open a new link to the partition starting at a different position.  To mitigate this, the client could impose a limit of having only a single AMQP link to a given partition.  This mitigation would open additional questions, such as:

- How is a developer using the client to know whether or not there is an AMQP link open which is dedicated to a specific partition and, if so, what its position is?  
- How can a developer request to close that link and establish a new one, should it be needed?  

Ultimately, it is believed that the difficulty of use continues to build and semantics become harder to reason about as scenarios become more advanced and complex.  Encapsulating the receiver operations into a discrete scope that developers can explicitly create and destroy provides the necessary isolation that allows for local state, providing operations that are more deterministic and semantics which are more easily understood.