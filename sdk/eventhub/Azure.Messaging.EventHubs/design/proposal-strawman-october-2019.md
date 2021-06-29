# Event Hubs Client: October Strawman (Preview 5)

This design is focused on the fifth preview of the track two Event Hubs client library, and limits the scope of discussion to those areas with active development for that preview. For wider context and more general discussion of the design goals for the track two Event Hubs client, please see:

- [Azure SDK Design Guidelines](https://azure.github.io/azure-sdk/general_introduction.html)
- [.NET Design Guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html#general-azure-sdk-library-design)

## Things to know before reading

- The names used in this document are intended for illustration only.  Some names are not ideal and may not fully conform to guidelines; these will be refined during prototyping and board reviews.

- The API details attempt to convey the high level concept; not every overload is shown and some details may be glossed over.  The full details for these can be seen in the API skeleton.

- Some details not related to the high-level concept are not illustrated; the scope of this is limited to the high level shape and paradigms for the current preview.

- Fake methods are used to illustrate "something needs to happen, but the details are unimportant."  As a general rule, if an operation is not directly related to one of  the Event Hubs types, it can likely be assumed that that it is for illustration only.  These methods will most often use elipses for the parameter list, in order to help differentiate them.

## Target customer segments

### Developers new to Azure and/or Event Hubs

These are developers who are new to Azure or the Event Hubs service, exploring either for personal growth or to evaluate the use of Event Hubs in the context of a product.  They may or may not have cloud experience in general and are likely to be unfamiliar with the Azure portal, common Azure nomenclature, and common Azure concepts such as how access control works.

These developers may or may not have experience within the messaging space with competing products such as Kafa or Kinesis.  They may not be familiar with common messaging concepts such as persistent event streams, partitions, consumer groups, and hashing keys.

#### Scenario category

- Hello World

#### Key concerns

- Finding a friendly experience for onboarding, including the initial setup of Azure resources.

- Seeing immediate and easy feedback for their efforts; the developer loop for experimenting should be approachable and developers should see "something" happen between their code and the Azure services.

- Encouraging good practices and patterns in a simple way; they should be able to "step up" to more complex and real-world scenarios by building on what they've learned through experimentation.  This is likely to require new techniques and add complexity, but there should be a feel familiar to what has been learned during "Hello World"

### Developers building products using Event Hubs

These are developers who are working to build products which use Event Hubs.  They may have a good deal of knowledge about Azure, Event Hubs, messaging systems, and cloud-development or be less familiar and building on knowledge learned from exploration.

These developers are interested in building for a production environment.  They are looking to follow the recommended practices and patterns that best allow them to build products and are likely to take advantage of the abstractions provided by the Event Hubs client library.  Many are willing to accept a degree of additional complexity and accept the trade-offs that the libary types offer in order to build on an established foundation.

#### Scenario category

- Real World

#### Key concerns

- Following good practices and patterns in their implementation; building "the right way" for production using an established foundation that guides them into the "pit of success."

- Beginning in a straight-forward manner so that their efforts can be concentrated on their applicaiton and not on the Event Hubs client library.

- Being able to scale out/up as their needs require as their product matures.

### Developers with advanced needs

These are developers are working on products which have special needs that are often advanced and do not fit into the majority case for many Event Hubs client library users.  While this segment has a much smaller addressable market, those that fall into this segment often drive a large amount of ACR.

These developers are interested in using the low-level components of the Event Hubs client library, focused around client-service communication, in flexible ways that they can customize to meet their needs.  The developers in this segement are considered avanced users of Event Hubs with a deep understanding of the service, cloud development, and messaging systems.  Many are willing to accept the complexity of working with lower-level components for the ability to have more control for their implementaiton.

#### Scenario category

- Custom and Special Needs

#### Key concerns

- Using the client library as an abstraction for service communication; they desire control over the client-server interaction without having to handle protocol-level conserns.

- Gaining access to types that are "close to the metal", allowing a high level of understanding and control over when service communication happens and the parameters of how.

- Support for natively batched operations when consuming, trading simplicity and alignment with the iterator approach for efficiency.

- Being able to build on lower-level components without the need to adopt the higher level abstractions; these developers are not always willing to accept the trade-offs offered by the Event Hubs client library's higher level abstraction, as they have different needs than the majority user.

## Key types

### Event Hub Producer Client

- The main interface for publishing events to the Event Hubs service, with a goal of being highly discoverable. 

- Not bound to a specific partition; can be used to publish events for automatic partition routing, using a partition hash key to influence routing, or to a specific partition.

- Can be used to query metadata about the Event Hub and its partition.

### Event Hub Consumer Client

- One of the interfaces for consuming events from the Event Hubs service, with a goal of being highly discoverable. 

- Not bound to a specific partition; can be used to consume events across all partitions of an Event Hub or from a single partition.

- Offers the "Hello World" consumer experience for reading events using an iterator (via `ReadEvents` and `ReadEventsFromPartition`) in an isolated manner, with no responsibility for load balancing or checkpoint storage.

- Can be used to query metadata about the Event Hub and its partition.

### Event Processor Client

- Intended to be the focal point for the "Real World" experience of consuming events from the Event Hubs service.

- Works cooperatively with other instances to share and balance responsibility for reading events from the partitions of an Event Hub.

- Supports durable storage for checkpoints by integrating with a concrete storage instance.  The initial processor will be based on Azure Storage Blobs.

- Allows reading events from all partitions that it is responsible for, using a push-based approach to ensure events for a partition are processed in the order they were received and enable concurrent processing of partitions.

- Offers events to allow developers to be notified and participate in initialization and shutdown.

- Does not allow creation from an existing connection; the consumer is free to manage connections in the manner it believes best - such as using one-per-partition or a pooled approach, as has been discussed.

### Partition Event

- A representation of the components needed for processing an event for a given partition.

- Exposes the `EventData` that was received from the Event Hub so that it may be processed.

- Exposes the `PartitionContext` that identifies the partition from which the `EventData` was received.

- Offers a method to create/update a checkpoint based on the event for the associated partition.

### Event Hub Connection

- Represents a single connection to the Event Hubs service for a specific Event Hub.

- May be used to create a producer or a consumer, ensuring that developers have transparency into the number of connections used and have control over their re-use.

- Created implicitly by a producer or consumer when not provided at construction.

- May be closed/disposed, which closes all types sharing the connection.

### Event Processor Client Base

- Represents a base-level type for cooperative event processing, providing functionality for load balancing and dispatching events for processing. 

- Does not offer the higher-level abstractions of the opinionated client; operations are performed by overriding/implementing base class methods rather than using an event-based model.  The arguments for these methods are built around the set of lower-level types and do not make use of the `EventArg` abstractions.

- Exposes events in batches, rather than single events; the batch size and prefetch count support configuration in order to allow for optimal tuning.

- Guarantees that only one event-batch-per-partition is dispatched for processing at one time and manages concurrency to allow multiple partitions to be processing at once.

- Abstract; meant to be extended by developers with advanced customization needs.

## Publishing scenarios 

### Create a Producer Client

```csharp
// Event Hub connection string
var connectionString = "<< EVENT HUB CONNECTION STRING FROM PORTAL >>";
var producer = new EventHubProducerClient(connectionString);

// Namespace connection string and Event Hub name
var connectionString = "<< NAMESPACE CONNECTION STRING FROM PORTAL >>";
var producer = new EventHubProducerClient(connectionString, "Event Hub Name");

// Expanded form
var fqNamespace = "Fully Qualified Event Hubs Namespace";
var hub = "Event Hub Name";
var tokenCredential = GetCredentialFromIdentityClient(...);
var producer = new EventHubProducerClient(fqNamespace, hub, tokenCredential);

// Existing connection
var connection = new EventHubsConnection(...);
var producer = new EventHubProducerClient(connection);
```

### Send with Automatic partition routing

```csharp
var producer = BuildProducerClient(...);

var batch = await producer.CreateBatchAsync();
AddEventsToBatch(batch);

await producer.SendAsync(batch);
```

### Send using a partition key

```csharp
var producer = BuildProducerClient(...);

var batchOptions = new BatchOptions { PartitionKey = "myKey" };
var batch = await producer.CreateBatchAsync(batchOptions);
AddEventsToBatch(batch);

await producer.SendAsync(batch);
```

### Send to a specific partition

```csharp
var producer = BuildProducerClient(...);

var batchOptions = new BatchOptions { PartitionId = "1" };
var batch = await producer.CreateBatchAsync(batchOptions);
AddEventsToBatch(batch);

await producer.SendAsync(batch);
```

### Send using a shared connection

```csharp
var connection = new EventHubsConnection(...);
var first = new EventProducerClient(connection);
var second = new EventProducerClient(connection);

var firstBatch = await first.CreateBatchAsync();
var secondBatch = await second.CreateBatchAsync();
AddEventsToBatch(firstBatch);
AddEventsToBatch(secondBatch);

await first.SendAsync(firstBatch);
await second.SendAsync(secondBatch);
```

## Consuming scenarios: Hello World

### Create a Consumer Client

```csharp
// Event Hub connection string
var connectionString = "<< EVENT HUB CONNECTION STRING FROM PORTAL >>";
var consumerGroup = "$DEFAULT";
var consumer = new EventHubConsumerClient(consuconnectionString, consumerGroup);

// Namespace connection string and Event Hub name
var connectionString = "<< NAMESPACE CONNECTION STRING FROM PORTAL >>";
var consumerGroup = "$DEFAULT";
var consumer = new EventHubConsumerClient(connectionString, "Event Hub Name", consumerGroup);

// Expanded form
var fqNamespace = "Fully Qualified Event Hubs Namespace";
var hub = "Event Hub Name";
var tokenCredential = GetCredentialFromIdentityClient(...);
var consumerGroup = "$DEFAULT";
var consumer = new EventHubConsumerClient(fqNamespace, hub, tokenCredential, consumerGroup);

// Existing connection
var connection = new EventHubsConnection(...);
var consumerGroup = "$DEFAULT";
var consumer = new EventHubConsumerClient(connection, consumerGroup);
```

### Consume events from all partitions

```csharp
var consumer = BuildConsumerClient(...);

using var cancellationSource = new CancellationTokenSource();

// As this is intended for ease of immediate feedback while exploring Event Hubs, 
// this will defaut to EventPosition.Earliest and allow EventPosition.Latest.  
//
// In order to discourage use in real-world production scenarios, no option is
// offered to set the position on individual partitions.
await foreach (var partitionEvent in consumer.ReadEvents(cancellationSource.Token))
{
    var partitionId = partitionEvent.Partition.Id;
    var eventData = partitionEvent.Data;
    
    await DoSomethingWithEventAsync(partitionId, eventData.Body);
}
```

### Consume Events from a specific partition

```csharp
var consumer = BuildConsumerClient(...);
var interestedPartitionId = "0";

using var cancellationSource = new CancellationTokenSource();

await foreach (var partitionEvent in consumer.ReadEventsFromPartition(interestedPartitionId, EventPosition.Earliest, cancellationSource.Token))
{
    var eventData = partitionEvent.Data;
    await DoSomethingWithEventAsync(interestedPartitionId, eventData.Body);
}
```

## Consuming scenarios: Real World

### Create an Event Processor Client

```csharp
// Event Hub connection string
var connectionString = "<< EVENT HUB CONNECTION STRING FROM PORTAL >>";
var consumerGroup = "$DEFAULT";
var checkpointStore = new BlobContainerClient(...);
var consumer = new EventProcessorClient(checkpointStore, consumerGroup, connectionString);

// Namespace connection string and Event Hub name
var connectionString = "<< NAMESPACE CONNECTION STRING FROM PORTAL >>";
var consumerGroup = "$DEFAULT";
var checkpointStore = new BlobContainerClient(...);
var consumer = new EventProcessorClient(checkpointStore, consumerGroup, connectionString, "Event Hub Name");

// Expanded form
var fqNamespace = "Fully Qualified Event Hubs Namespace";
var hub = "Event Hub Name";
var tokenCredential = GetCredentialFromIdentityClient(...);
var consumerGroup = "$DEFAULT";
var checkpointStore = new BlobContainerClient(...);
var consumer = new EventProcessorClient(checkpointStore, consumerGroup, fqNamespace, hub, tokenCredential);

// Do not allow existing connection, as the consumer is free to manage connections
// as it believes is best.
```

### Consume events (basic)

```csharp
var processorClient = BuildEventProcessorClient(...);
var receiveCount = 0;

using var cancellationSource = new CancellationTokenSource();

// This handler must be registered to start processing.  Without it, an InvalidOperationException
// is thrown.
processorClient.ProcessEventAsync = async (processingEventArgs) =>
{
    var partitionId = processingEventArgs.Partition.Id;
    var eventData = processingEventArgs.Data;
    
    ++receiveCount;
    await DoSomethingWithEventAsync(partitionId, eventData.Body);
    
    if (ShouldCheckpoint(receiveCount))
    {
        await processingEventArgs.UopdateCheckpointAsync();
    }
}

// This handler must be registered to start processing.  Without it, an InvalidOperationException
// is thrown.
processorClient.ProcessErrorAsync = async (processingErrorEventArgs) => ...

await processorClient.StartProcessingEventsAsync(cancellationSource.Token);

// =========================
// Developer code can continue to operate here; processing is taking place
// in the background.
// =========================

// Callers are responsible for blocking if they wish to do so.
while (!stopProcessing)
{
    await Task.Delay(someInterval);
}
```

### Stop consuming events 

```csharp
var processorClient = BuildEventProcessorClient(...);

processorClient.ProcessEventAsync = async (processingEventArgs) => ...
processorClient.ProcessErrorAsync = async (processingErrorEventArgs) => ...

await processorClient.StartProcessingEventsAsync();

// =========================
// Developer code can continue to operate here; processing is taking place
// in the background.
// =========================

await processorClient.StopProcessingAsync();
```

### Participate in initialization and completion for partitions

```csharp
var processorClient = BuildEventProcessorClient(...);

// This handler is optional and won't prevent processing if not supplied.
processorClient.InitializingPartitionAsync  = async (initializingPartitionEventArgs) =>
{
    initializingPartitionEventArgs.DefaultStartingPosition = EventPosition.Earliest;
    await Log($"Initializing partition: { initializingPartitionEventArgs.PartitionId }");
}

// This handler is optional and won't prevent processing if not supplied.
processorClient.ClosingPartitionAsync  = async (closingPartitionEventArgs) =>
{
    await Log($"Processing stopped for partition: { closingPartitionEventArgs.PartitionId }");
    await Log($"Processing stopped because: { closingPartitionEventArgs.Reason.ToString() }");
}

// Begin processing
eventProcessor.ProcessEventAsync = async (processingEventArgs) => ...
processorClient.ProcessErrorAsync = async (processingErrorEventArgs) => ...

await processorClient.StartProcessingEventsAsync();
```

### Handle exceptions from the processor client (not user-provided code)

```csharp
var processorClient = BuildEventProcessorClient(...);

processorClient.ProcessErrorAsync = async (processingErrorEventArgs) =>
{
    await Log($"Exception for partition: { processingErrorEventArgs.PartitionId }, while: { processingErrorEventArgs.Operation }");
}

eventProcessor.ProcessEventAsync = async (processingEventArgs) => ...
await processorClient.StartProcessingEventsAsync();
```

## Consuming scenarios: Advanced or special needs

### Consume events from all Partitions with a wait time restriction

```csharp
var consumer = BuildConsumerClient(...);

var options = new ReadEventOptions
{
    MaximumWaitTime = TimeSpan.FromSeconds(30)
};

using var cancellationSource = new CancellationTokenSource();

await foreach (var partitionEvent in consumer.ReadEvents(options, cancellationSource.Token))
{
    if (partitionEvent == null)
    {
        // No events were available in the requested time period.  Control 
        // is returned to develper code, allowing logic for "no events", trouble 
        // detection, and an opportunity to exit the loop and stop processing.
        var shouldStop = ReportNoEvents();
        
        if (shouldStop)
        {
            break;
        }
    }
    else
    {
        var partitionId = partitionEvent.PartitionContext.Id;
        var eventData = partitionEvent.Data;
        DoSomethingWithEvent(partitionId, eventData.Body);
    }
}
```

### Consume Events from a specific partition with a wait time restriction

```csharp
var consumer = BuildConsumerClient(...);
var partitionId = "0";

var options = new ReadEventOptions
{
    MaximumWaitTime = TimeSpan.FromSeconds(30)
};

using var cancellationSource = new CancellationTokenSource();
using var source = consumer.ReadEventsFromPartition(partitionId, EventPosition.FromOffset(3), options, cancellationSource.Token);

await foreach (var partitionEvent in source)
{
    if (partitionEvent == null)
    {
        // No events were available in the requested time period.  Control 
        // is returned to develper code, allowing logic for "no events", trouble 
        // detection, and an opportunity to exit the loop and stop processing.
        var shouldStop = ReportNoEvents();
        
        if (shouldStop)
        {
            break;
        }
    }
    else
    {
        var eventData = partitionEvent.Data;
        DoSomethingWithEvent(partitionId, eventData.Body);
    }
}
```

## Namespace organization

### Package: Azure.Messaging.EventHubs

#### `Azure.Messaging.EventHubs`
```csharp
public class EventHubConnection {}
public class EventHubConnectionOptions {}
public class EventData {}
public class EventHubsException {}
public class EventHubProperties {}
public class EventHubsRetryPolicy {}
public enum EventHubsRetryMode {}
public class EventHubsRetryOptions {}
public class EventHubsSharedKeyCredential {}
public enum EventHubsTransportType {}
public class PartitionProperties {}
```

#### `Azure.Messaging.EventHubs.Producer`
```csharp
public class EventHubProducerClient {}
public class EventHubProducerClientOptions {}
public class CreateBatchOptions {}
public class EventDataBatch {}
```

### `Azure.Messaging.EventHubs.Consumer`
```csharp
public class EventHubConsumerClient {}
public class EventHubConsumerClientOptions {}
public class ReadEventOptions {}
public struct EventPosition {}
public class PartitionContext {}
public class PartitionEvent {}
public struct LastEnqueuedEventProperties {}
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