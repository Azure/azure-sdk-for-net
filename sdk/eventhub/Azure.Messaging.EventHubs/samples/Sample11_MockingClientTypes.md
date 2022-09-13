
# Mocking Client Types

Event Hubs is built to support unit testing with mocks, as described in the [Azure SDK Design Guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking). This is an important feature of the library that allows developers to write tests that are completely focused on their own application logic, though they depend on the Event Hubs types.


The examples that follow focus on scenarios likely to occur in applications, and demonstrate how to mock the Event Hubs types typically used in each scenario.

## Publishing Events with the `EventHubProducerClient`

When using batches to publish to Event Hubs, the key interactions with the `EventHubProducerClient` are calling `CreateBatchAsync` to create the batch and `SendAsync` to publish it.   Mocked batches accept a `List<EventData>` that is used as a backing store and can be inspected to verify that the application is adding events to the batch as expected.  The custom `TryAdd` callback can be used to control the decision for whether an event is accepted into the batch or is rejected.   

This snippet demonstrates mocking the `EventHubProducerClient` using Moq, and creating `EventDataBatch` instances using the `EventHubsModelFactory`.

```C# Snippet:EventHubs_Sample11_MockingEventDataBatch
Mock<EventHubProducerClient> mockProducer = new Mock<EventHubProducerClient>();

// This sets the value returned by the EventDataBatch when accessing the Size property
// It does not impact TryAdd on the mocked batch
long batchSizeInBytes = 500;

// Events added to the batch will be added here, but altering the events in this list will not change the
List<EventData> backingList = new List<EventData>();

// For illustrative purposes allow the batch to hold 3 events before
// returning false.
int batchCountThreshold = 3;

EventDataBatch dataBatchMock = EventHubsModelFactory.EventDataBatch(
        batchSizeBytes : batchSizeInBytes,
        batchEventStore : backingList,
        batchOptions : new CreateBatchOptions() { },
        // The model factory allows the user to define a custom TryAdd callback, making
        // it easy to test specific scenarios
        eventData =>
        {
            int eventCount = backingList.Count();
            return eventCount < batchCountThreshold;
        });

// Setting up a mock of the CreateBatchAsync method
mockProducer
    .Setup(p => p.CreateBatchAsync(
        It.IsAny<CancellationToken>()))
    .ReturnsAsync(dataBatchMock);

// Mocking the SendAsync method so that it will throw an exception if the batch passed into send is
// not the one we are expecting to send
mockProducer
    .Setup(p => p.SendAsync(
        It.Is<EventDataBatch>(sendBatch => sendBatch != dataBatchMock),
        It.IsAny<CancellationToken>()))
    .Throws(new Exception("The batch published was not the expected batch."));

EventHubProducerClient producer = mockProducer.Object;

// Attempting to add events to the batch
EventDataBatch batch = await producer.CreateBatchAsync();
List<EventData> eventList = new List<EventData>();

for (int i=0; i<4; i++)
{
    var eventData = new EventData(eventBody: new BinaryData($"Sample-Event-{i}"));
    if (batch.TryAdd(eventData))
    {
        // Track all of the events that were successfully added to the batch
        eventList.Add(eventData);
    }
}

// Illustrating the use of the try add callback
EventData eventData4 = new EventData(eventBody: new BinaryData("Sample-Event-4-will-fail"));
Assert.IsFalse(batch.TryAdd(eventData4));

// Call SendAsync
await producer.SendAsync(batch);

// Using the mocked event producer to test that SendAsync was called once
mockProducer
    .Verify(bp => bp.SendAsync(
        It.IsAny<EventDataBatch>(),
        It.IsAny<CancellationToken>()),Times.Once);

// Verify that the events in the batch match what the application expects
foreach (EventData eventData in backingList)
{
    Assert.IsTrue(eventList.Contains(eventData));
}
Assert.AreEqual(backingList.Count, eventList.Count);
```

## Mocking access to the properties of an `EventHubProducerClient`

Many applications make decisions for publishing based on the properties of the Event Hub itself or the properties of its partitions. Both can be mocked using the `EventHubsModelFactory`. The following example demonstrates how to mock an `EventHubProducerClient` that is publishing to an Event Hub with a set of two partitions with different ownership levels.

```C# Snippet:EventHubs_Sample11_MockingEventHubProperties
// Create a mock of the EventHubProducerClient
Mock<EventHubProducerClient> mockProducer = new Mock<EventHubProducerClient>();

// Define the set of partitions and publishing properties to use for testing
Dictionary<string, PartitionPublishingProperties> partitions = new Dictionary<string, PartitionPublishingProperties>()
{
    // Partition with PartitionId 0
    { "0", EventHubsModelFactory.PartitionPublishingProperties(
        isIdempotentPublishingEnabled : false,
        producerGroupId : null,
        ownerLevel : null, // Has no reader ownership - anyone can read
        lastPublishedSequenceNumber: null) },

    // Partition with PartitionId 1
    { "1", EventHubsModelFactory.PartitionPublishingProperties(
        isIdempotentPublishingEnabled : false,
        producerGroupId : null,
        ownerLevel : 42, // Reader ownership is high - exclusive reader
        lastPublishedSequenceNumber : null) }
};

// Mock the EventHubProperties using the model factory
EventHubProperties eventHubProperties =
    EventHubsModelFactory.EventHubProperties(
        name : "fakeEventHubName",
        createdOn : DateTimeOffset.UtcNow, // arbitrary value
        partitionIds : partitions.Keys.ToArray());

// Setting up to return the mocked properties
mockProducer.Setup(p => p.GetEventHubPropertiesAsync(
    It.IsAny<CancellationToken>()))
    .ReturnsAsync(eventHubProperties);

// Setting up to return the mocked partition ids
mockProducer.Setup(p => p.GetPartitionIdsAsync(
    It.IsAny<CancellationToken>()))
    .ReturnsAsync(partitions.Keys.ToArray());

foreach (var partition in partitions)
{
    // Setting up to return the mocked properties for each partition input
    mockProducer.Setup(p => p.GetPartitionPublishingPropertiesAsync(
    partition.Key,
    It.IsAny<CancellationToken>()))
    .ReturnsAsync(partition.Value);
}

EventHubProducerClient producer = mockProducer.Object;
```

## Mocking access to the properties of an `EventHubConsumerClient`

When testing code that is dependent on the `EventHubConsumerClient`, an application may want to determine a representative set of events, event properties, and contexts that their application could potentially see. Tests can mock each data type, and then set up the consumer client to output these representative scenarios, verifying the resulting behavior is as expected.

```C# Snippet:EventHubs_Sample11_MockingConsumerClient
// Create a mock of the EventHubConsumerClient
Mock<EventHubConsumerClient> mockConsumer = new Mock<EventHubConsumerClient>();

var receivedEvents = new List<EventData>();
var cancellationTokenSource = new CancellationTokenSource();

// Create a mock of LastEnqueuedEventProperties using the model factory, these can
// be set depending on the scenario that is important for the application
var lastEnqueueEventProperties = EventHubsModelFactory.LastEnqueuedEventProperties(
    lastSequenceNumber : default,
    lastOffset : default,
    lastEnqueuedTime : default,
    lastReceivedTime : default);

// Create a mock of PartitionContext using the model factory
var partitionContext = EventHubsModelFactory.PartitionContext(
    partitionId : "0",
    lastEnqueuedEventProperties : lastEnqueueEventProperties);

// Mock an EventData instance, different arguments can simulate different potential
// outputs from the broker
var eventData = EventHubsModelFactory.EventData(
    eventBody : new BinaryData("Sample-Event"),
    systemProperties : default,
    partitionKey : default,
    sequenceNumber : default,
    offset : default,
    enqueuedTime : default);

// Create a mock of a partition event
var samplePartitionEvent = new PartitionEvent(partitionContext, eventData);
var partitionEventList = new List<PartitionEvent>(new PartitionEvent[] { samplePartitionEvent });

// Define a simple local method that returns an IAsyncEnumerable to use as the return for
// ReadEventsAsync below
async IAsyncEnumerable<PartitionEvent> mockReturn(PartitionEvent samplePartitionEvent)
{
    await Task.CompletedTask;
    yield return samplePartitionEvent;
}

// Use this PartitionEvent to mock a return from the consumer, because ReadEvents returns an IAsyncEnumerable a separate
// method is needed to properly set up this method
mockConsumer.Setup(
    c => c.ReadEventsAsync(
    It.IsAny<CancellationToken>()))
    .Returns(mockReturn(samplePartitionEvent));

var consumer = mockConsumer.Object;
```

## Mocking `PartitionReceiver`

The sample below illustrates how to mock a `PartitionReceiver`, and set up its `ReceiveBatchAsync` method to return an empty batch. Mocked partition receivers can be set up for more complex scenarios using `SetUp(...).CallBack(...)` as well.

```C# Snippet:EventHubs_Sample11_PartitionReceiverMock
// Create a mock of the PartitionReceiver
var mockReceiver = new Mock<PartitionReceiver>();

// This sets the value returned by the EventDataBatch when accessing the Size property
// It does not impact TryAdd on the mocked batch
var batchSizeInBytes = 500;

// Events added to the batch will be added here, but altering the events in this list will not change the
// events in the batch, since they are stored inside the batch as well
var backingList = new List<EventData>();

var maximumEventCount = 10;

// Create a mock of an EventDataBatch for the receiver to return
var dataBatchMock = EventHubsModelFactory.EventDataBatch(
        batchSizeBytes: batchSizeInBytes,
        batchEventStore: backingList,
        batchOptions: new CreateBatchOptions() { },
        // The model factory allows the user to define a custom TryAdd callback, making
        // it easy to test specific scenarios
        eventData =>
        {
            var numElements = backingList.Count();
            return numElements < maximumEventCount;
        });

// Adding events to the batch
for (var i=0; i < 10; i++)
{
    // Mocking an EventData instance, different arguments can simulate different potential
    // outputs from the broker
    var eventData = EventHubsModelFactory.EventData(
        eventBody: new BinaryData($"Sample-Event-{i}"),
        systemProperties: default,
        partitionKey: "0",
        sequenceNumber: default,
        offset: default,
        enqueuedTime: default);

    Assert.IsTrue(dataBatchMock.TryAdd(eventData));
}

// Setup the mock to receive the mocked data batch when ReceiveBatchAsync is called
// on a given partition
mockReceiver.Setup(
    r => r.ReceiveBatchAsync(
        It.IsAny<int>(),
        It.IsAny<TimeSpan>(),
        It.IsAny<CancellationToken>()))
    .ReturnsAsync(backingList.ToArray());

var receiver = mockReceiver.Object;

var cancellationTokenSource = new CancellationTokenSource();

var receivedBatch = await receiver.ReceiveBatchAsync(
    maximumEventCount: maximumEventCount,
    TimeSpan.FromSeconds(1),
    cancellationTokenSource.Token);
```

## Mocking `EventHubBufferedProducerClient` and `EventData`

The following snippet demonstrates how to mock the `EventHubBufferedProducerClient`. In this scenario, the failed handler decides to add events to the end of the queue after failing to send. A test could then verify that `EnqueueEventAsync` was called to make sure that their failed handler was working as expected.

A mock of the `EventHubBufferedProducer` client could also be used in the same way as the `EventHubProducerClient` mock in the first scenario in this document, by verifying that `EnqueueEventAsync` or its variations are called with the expected arguments. As emphasized throughout this document, testing code that uses the `EventHubBufferedProducer` client should focus on the code written in the actual application, not the functionality of the buffered producer itself. 

```C# Snippet:EventHubs_Sample11_MockingBufferedProducer
// Create a mock buffered producer
var bufferedProducerMock = new Mock<EventHubBufferedProducerClient>();

// Define a failed handler for the mock
var sendFailed = new Func<SendEventBatchFailedEventArgs, Task>(async args =>
{
    foreach (var eventData in args.EventBatch)
    {
        if (eventData.Body.Length != 0)
        {
            await bufferedProducerMock.Object.EnqueueEventAsync(eventData);
        }
    }
});

// Create a mock event to fail send
var eventToEnqueue = EventHubsModelFactory.EventData(new BinaryData("Sample-Event"));
var eventList = new List<EventData>();
eventList.Add(eventToEnqueue);

// Create a set of args to send to the SendEventBatchFailedAsync handler
var args = new SendEventBatchFailedEventArgs(eventList, new Exception(), "0", default);

// Setup EnqueueEventAsync to always pass and return 1
bufferedProducerMock.Setup(bp => bp.EnqueueEventAsync(
    It.IsAny<EventData>(),
    It.IsAny<CancellationToken>())).ReturnsAsync(1);

// Set up EnqueueEventsAsync to fail and call the defined fail handler using the
// above created args
bufferedProducerMock.Setup(bp => bp.EnqueueEventsAsync(
    It.IsAny<List<EventData>>(),
    It.IsAny<CancellationToken>())).Callback(() => sendFailed(args));

var bufferedProducer = bufferedProducerMock.Object;

bufferedProducer.SendEventBatchFailedAsync += sendFailed;
```

## Mocking `EventHubBufferedProducerClient` and `PartitionProperties`

Mocking the `PartitionProperties` class is very similar to the `PartitionPublishingProperties` above. The snippet below demonstrates how an application could set up a specific set of properties, and then test different code paths that depend on it. It can be done in the same way for the `EventHubProducerClient` as well.

```C# Snippet:EventHubs_Sample11_BufferedProducerPartitionProps
// Create the buffered producer mock
var bufferedProducerMock = new Mock<EventHubBufferedProducerClient>();

// Define the partitions and their properties
var partitions = new Dictionary<string, PartitionProperties>()
{
    // Non-empty partition
    { "0", EventHubsModelFactory.PartitionProperties(
        eventHubName : "eventhub-name",
        partitionId : "0",
        isEmpty : true,
        beginningSequenceNumber: 1000,
        lastSequenceNumber : 1100,
        lastOffset : 500,
        lastEnqueuedTime : DateTime.UtcNow) },

    // Empty partition
    { "1", EventHubsModelFactory.PartitionProperties(
        eventHubName : "eventhub-name",
        partitionId : "1",
        isEmpty : false,
        beginningSequenceNumber : 2000,
        lastSequenceNumber : 2000,
        lastOffset : 760,
        lastEnqueuedTime : DateTime.UtcNow) }
};

// Set up partition Ids
bufferedProducerMock.Setup(
    p => p.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
    .ReturnsAsync(partitions.Keys.ToArray());

// Set up partition properties
foreach (var partition in partitions)
{
    bufferedProducerMock.Setup(
    p => p.GetPartitionPropertiesAsync(
        partition.Key,
        It.IsAny<CancellationToken>()))
        .ReturnsAsync(partition.Value);
}
```

## Mocking a custom event processor using `EventProcessor<Partition>` 

When implementing a custom event processor built on top of the `EventProcessor`, mocking can be used to test the implementation of each of the application defined methods.

An application may define as custom processor like below. More information about custom processors can be found in the [documentation](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample08_CustomEventProcessor.md#extending-eventprocessortpartition).

```C# Snippet:EventHubs_Sample11_CustomEventProcessor
internal class CustomProcessor : EventProcessor<EventProcessorPartition>
```

One can write a testable class on top, that exposes the set of protected override methods that the application has written.

```C# Snippet:EventHubs_Sample11_TestCustomEventProcessor
internal class TestableCustomProcessor : CustomProcessor
```

When testing each method, the focus is again just on the application-defined code, not the functionality defined through the `EventProcessor` implementation.

```C# Snippet:EventHubs_Sample11_MockingEventProcessor
// TestableCustomProcessor is a wrapper class around a CustomProcessor class that exposes
// protected methods so that they can be tested
var eventProcessorMock =
    new Mock<TestableCustomProcessor>(
        5, //eventBatchMaximumCount
        "consumerGroup",
        "namespace",
        "eventHub",
        Mock.Of<TokenCredential>(),
        new EventProcessorOptions())
    { CallBase = true };

var eventList = new List<EventData>()
{
    new EventData(new BinaryData("Sample-Event-1")),
    new EventData(new BinaryData("Sample-Event-2")),
    new EventData(new BinaryData("Sample-Event-3"))
};

var eventProcessor = eventProcessorMock.Object;

// Call the wrapper method in order to reach proctected method within a custom processor
// Using It.Is allows the test to set the PartitionId value, even though the setter is protected
await eventProcessor.TestOnProcessingEventBatchAsync(eventList, new EventProcessorPartition());
```







