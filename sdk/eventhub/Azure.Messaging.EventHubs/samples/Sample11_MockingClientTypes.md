
# Mocking Client Types
Event Hubs is built to be entirely mockable. This is an important feature of the library that allows developers to write tests that are completely focused on their own application logic, even if they are dependent on the Event Hubs types.

The following snippets demonstrate how to mock each client type and relevant data types. 

Another important focus of this document is guidance on abstracting . The Event Hubs library has an extensive test suite that verifies all types, clients, and methods work as specified. Each scenario also discusses how to leverage these guarantees provided by our library so that tests can just focus on what an application has layered on top.

## Mocking `EventDataBatch`, `EventData`, and `EventHubProducerClient`

When using batches to send to Event Hubs, many applications have specific needs for creating batches and preparing to send them. When testing, applications only need to focus their testing on the creation of batches, and the call to send. Once any of the send methods found with the `EventHubProducerClient` are called it can be assumed that the library will perform as expected.

The following snippet demonstrates how to mock an `EventHubProducerClient` using Moq, and `EventDataBatch` and `EventData` instances using the `EventHubsModelFactory`. Mocked data batches can be used to test that an application is adding events to the batch properly. The custom `TryAdd` callback can be used to test all code paths for adding events to the batch. The mocked `EventHubProducerClient` can be used to verify that `SendAsync` was called, as demonstrated below.

```C# Snippet:EventHubs_Sample11_MockingEventDataBatch
var mockProducer = new Mock<EventHubProducerClient>();

var createBatchOptions = new CreateBatchOptions() { MaximumSizeInBytes = 516 };
var batchSizeInBytes = 500;

var mockedDataBatch = EventHubsModelFactory.EventDataBatch(
        46,
        new List<EventData>(),
        new CreateBatchOptions() { },
        // The model factory allows the user to define a custom TryAdd callback, making
        // it easy to test specific scenarios
        eventData =>
        {
            return eventData.Body.Length > createBatchOptions.MaximumSizeInBytes - batchSizeInBytes;
        });

// Setting up a mock of the CreateBatchAsync method
mockProducer.Setup(p => p.CreateBatchAsync(
    It.IsAny<CancellationToken>()))
    .ReturnsAsync(mockedDataBatch);

// Mocking the SendAsync method so that it will always pass
mockProducer.Setup(p => p.SendAsync(
    It.IsAny<EventDataBatch>(),
    It.IsAny<CancellationToken>()))
    .Returns(Task.CompletedTask);

var producer = mockProducer.Object;

// Mocking EventData instances for send
var eventDataBody = new BinaryData("Sample large event body");
var eventData = EventHubsModelFactory.EventData(eventDataBody);

// Using the mocked event producer to test that SendAsync was never called
mockProducer.Verify(bp =>
bp.SendAsync(
    It.IsAny<EventDataBatch>(),
    It.IsAny<CancellationToken>()),Times.Never);
```

## Mocking `EventHubProducerClient`, `PartitionPublishingProperties` and `EventHubProperties`

Many applications make decisions for publishing based on the properties of the Event Hub itself or the properties of its partitions. Both can be mocked using the `EventHubsModelFactory`. The following example demonstrates how to mock an `EventHubProducerClient` that is publishing to an Event Hub with a set of two partitions with different ownership levels.

```C# Snippet:EventHubs_Sample11_MockingEventHubProperties
var mockProducer = new Mock<EventHubProducerClient>();

// Define the set of partitions and publishing properties to use for testing
var partitions = new Dictionary<string, PartitionPublishingProperties>()
{
    // Has no reader ownership - no OwnerLevel
    { "0", EventHubsModelFactory.PartitionPublishingProperties(false, null, null, null) },
    // Has an exclusive reader - OwnerLevel is high
    { "1", EventHubsModelFactory.PartitionPublishingProperties(false, null, 42, null) }
};

// Mock the EventHubProperties using the model factory
var eventHubProperties =
    EventHubsModelFactory.EventHubProperties(
        "fakeEventHubName", // arbitrary value
        DateTimeOffset.UtcNow, // arbitrary value
        partitions.Keys.ToArray());

// Mocking GetEventHubPropertiesAsync, GetPartitionIdsAsync and GetPartitionPublishingPropertiesAsync
// (for each partition), using the partitions and properties defined above
mockProducer.Setup(p => p.GetEventHubPropertiesAsync(
    It.IsAny<CancellationToken>()))
    .ReturnsAsync(eventHubProperties);

mockProducer.Setup(p => p.GetPartitionIdsAsync(
    It.IsAny<CancellationToken>()))
    .ReturnsAsync(partitions.Keys.ToArray());

foreach (var partition in partitions)
{
    mockProducer.Setup(p => p.GetPartitionPublishingPropertiesAsync(
    partition.Key,
    It.IsAny<CancellationToken>()))
    .ReturnsAsync(partition.Value);
}

var producer = mockProducer.Object;
```

## Mocking `EventHubConsumerClient`, `LastEnqueuedEventProperties`, and `PartitionContext`

When testing code that is dependent on the `EventHubConsumerClient`, an application only needs to determine a representative set of events, event properties, and contexts that their application will see. Tests can mock each data type, and then set up the consumer client to output representative scenarios.

```C# Snippet:EventHubs_Sample11_MockingConsumerClient
// Create a mock of the EventHubConsumerClient
var mockConsumer = new Mock<EventHubConsumerClient>();
var receivedEvents = new List<EventData>();
var cancellationTokenSource = new CancellationTokenSource();

// Create a mock of LastEnqueuedEventProperties using the model factory
var lastEnqueueEventProperties = EventHubsModelFactory.LastEnqueuedEventProperties(
    default,
    default,
    default, // TODO
    default);

// Create a mock of PartitionContext using the model factory
var partitionContext = EventHubsModelFactory.PartitionContext(
    "0",
    lastEnqueueEventProperties);

var eventData = EventHubsModelFactory.EventData(new BinaryData("Sample-Event"));

// Create a mock of a partition event using the PartitionContext and EventData
// instances created above
var samplePartitionEvent = new PartitionEvent(partitionContext, eventData);
var partitionEventList = new List<PartitionEvent>();
partitionEventList.Add(samplePartitionEvent);

// Use this PartitionEvent to mock a return from the consumer
mockConsumer.Setup(c =>
c.ReadEventsAsync(
    It.IsAny<CancellationToken>()))
    .Returns((IAsyncEnumerable<PartitionEvent>)partitionEventList);

var consumer = mockConsumer.Object;
```

## Mocking `PartitionReceiver`

The sample below illustrates how to mock a `PartitionReceiver`, and set up its `ReceiveBatchAsync` method to return an empty batch.

```C# Snippet:EventHubs_Sample11_PartitionReceiverMock
// Create a mock of the PartitionReceiver
var mockReceiver = new Mock<PartitionReceiver>();
var emptyEventBatch = new List<EventData>();

// Setup the mock to receive an empty batch when ReceiveBatchAsync is called
mockReceiver.Setup(
    r => r.ReceiveBatchAsync(
        It.IsAny<int>(),
        It.IsAny<TimeSpan>(),
        It.IsAny<CancellationToken>()))
    .ReturnsAsync(emptyEventBatch);

var receiver = mockReceiver.Object;
```

## Mocking `EventHubBufferedProducerClient` and `EventData`

The following snippet demonstrates how to mock the `EventHubBufferedProducerClient`. In this scenario, the failed handler decides to add events to the end of the queue after failing to send. A test could then verify that `EnqueueEventAsync` was called to make sure that their failed handler was working as expected.

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





