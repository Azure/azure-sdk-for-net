
# Mocking Client Types

Event Hubs is built to support unit testing with mocks, as described in the [Azure SDK Design Guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking). This is an important feature of the library that allows developers to write tests that are completely focused on their own application logic, though they depend on the Event Hubs types.

The following examples focus on scenarios likely to occur in applications, and demonstrate how to mock the Event Hubs types typically used in each scenario. The code snippets utilize the mock object framework, Moq, in order to provide practical examples. However, many mocking frameworks exist and can be used with the same approach in mind.

For more general information and examples on mocking with the Azure SDK, please see [Unit testing and mocking with the Azure SDK for .NET](https://learn.microsoft.com/dotnet/azure/sdk/unit-testing-mocking).

## Table of contents

- **Publishing events**
  - [Using the EventHubProducerClient](#publishing-events-with-the-eventhubproducerclient)
  - [Using the EventHubBufferedProducerClient](#publishing-events-using-an-eventhubbufferedproducerclient)
- **Consuming events**
  - [Using the EventHubConsumerClient](#consuming-events-using-an-eventhubconsumerclient)
  - [Using the PartitionReceiver](#consuming-events-using-the-partitionreceiver)
- **Querying metadata**
  - [Using any client type](#querying-metadata-properties-using-the-eventhubproducerclient-eventhubbufferedproducerclient-or-eventhubconsumerclient)

## Publishing events with the `EventHubProducerClient`

When using batches to publish to Event Hubs, the key interactions with the `EventHubProducerClient` are calling `CreateBatchAsync` to create the batch and `SendAsync` to publish it.
 Mocked batches accept a `List<EventData>` that is used as a backing store and can be inspected to verify that the application is adding events to the batch as expected.  The custom `TryAdd` callback can be used to control the decision for whether an event is accepted into the batch or is rejected.

This snippet demonstrates mocking the `EventHubProducerClient`, and creating `EventDataBatch` instances using the `EventHubsModelFactory`.

```C# Snippet:EventHubs_Sample11_MockingEventDataBatch
Mock<EventHubProducerClient> mockProducer = new();

EventHubProducerClient producer = mockProducer.Object;

// This argument sets the value returned by the EventDataBatch when accessing the Size property, it does
// not impact TryAdd on the mocked batch.

long batchSizeInBytes = 500;

// As events are added to the batch they will be added to this list as well. Altering the events in this
// list will not change the events in the batch though, since they are stored inside the batch as well.

List<EventData> backingList = new();

// For illustrative purposes, this is the number of events that the batch will contain, returning false
// from TryAdd for any additional calls.

int batchCountThreshold = 3;

EventDataBatch dataBatchMock = EventHubsModelFactory.EventDataBatch(
        batchSizeBytes : batchSizeInBytes,
        batchEventStore : backingList,
        batchOptions : new CreateBatchOptions(),
        // The model factory allows a custom TryAdd callback, allowing control of what
        // events the batch accepts.
        eventData =>
        {
            int eventCount = backingList.Count;
            return eventCount < batchCountThreshold;
        });

// This sets up a mock of the CreateBatchAsync method, returning the batch that was previously mocked.

mockProducer
    .Setup(p => p.CreateBatchAsync(It.IsAny<CancellationToken>()))
    .ReturnsAsync(dataBatchMock);

// The next part of this snippet illustrates how to create and fill a mocked batch. This would be where
// application methods in which batches are created and filled can be called and tested.

EventDataBatch batch = await producer.CreateBatchAsync();

// This is creating a list of events to use in our test.

List<EventData> sourceEvents = new();

for (int index = 0; index < batchCountThreshold; index++)
{
    var eventData = new EventData($"Sample-Event-{index}");
    sourceEvents.Add(eventData);
}

// Here we are adding events to the batch. They should all be accepted.

foreach (var eventData in sourceEvents)
{
    Assert.True(batch.TryAdd(eventData));
}

// Since there area already batchCountThreshold number of events in the batch, this event will be rejected
// from the batch.

EventData eventData4 = new EventData("Sample-Event-4-will-fail");
Assert.IsFalse(batch.TryAdd(eventData4));

// Here we are mocking the SendAsync method so it will throw an exception if the batch passed into it is
// not the one we are expecting to send.

mockProducer
    .Setup(p => p.SendAsync(
        It.Is<EventDataBatch>(sendBatch => sendBatch != dataBatchMock),
        It.IsAny<CancellationToken>()))
    .Throws(new Exception("The batch published was not the expected batch."));

// For illustrative purposes we are calling SendAsync. This would again be where application methods could be called
// and tested.

await producer.SendAsync(batch);

// This is demonstrating how to verify SendAsync was called once within the mocked producer client.

mockProducer
    .Verify(bp => bp.SendAsync(
        It.IsAny<EventDataBatch>(),
        It.IsAny<CancellationToken>()),
    Times.Once);

// For illustrative purposes, check that the events in the batch match what the application expects to have
// added.

foreach (EventData eventData in backingList)
{
    Assert.IsTrue(sourceEvents.Contains(eventData));
}
Assert.AreEqual(backingList.Count, sourceEvents.Count);
```

## Publishing events using an `EventHubBufferedProducerClient`

The following snippet demonstrates how to mock the `EventHubBufferedProducerClient`. When using the buffered producer to publish events the  key interactions are calls to `EnqueueEventAsync` and/or `EnqueueEventsAsync`. Since the buffered producer implictly batches events passed in, mocking these calls is relatively straightforward.

This snippet also demonstrates testing a send event failed handler. It is guaranteed by the library that the event handlers will be called at the appropriate times while the processor is running; it is recommended that handers be tested by calling them directly, rather than attempting to simulate having the buffered producer invoke them.

```C# Snippet:EventHubs_Sample11_MockingBufferedProducer
Mock<EventHubBufferedProducerClient> bufferedProducerMock = new();

// For this scenario, set up EnqueueEventAsync to always pass and return 1.

bufferedProducerMock
    .Setup(bp => bp.EnqueueEventAsync(
        It.IsAny<EventData>(),
        It.IsAny<CancellationToken>()))
    .ReturnsAsync(1);

EventHubBufferedProducerClient bufferedProducer = bufferedProducerMock.Object;

// The following demonstrates how to use the mocked EnqueueEventAsync. This would be where application-defined
// methods can be called and tested.

// This is an illustrative fail handler that can be added to the mock buffered producer.

Func<SendEventBatchFailedEventArgs, Task> sendFailed = new(async args =>
{
    foreach (EventData eventData in args.EventBatch)
    {
        // Do more complex error handling here...

        Debug.WriteLine($"Publishing failed for the event: {eventData.MessageId}.  Error: '{args.Exception.Message}'");
        await Task.CompletedTask;
    }
});

bufferedProducer.SendEventBatchFailedAsync += sendFailed;

// For illustrative purposes, enqueue a set of events to be published.

int numOfEventsToEnqueue = 15;
using CancellationTokenSource cancellationTokenSource = new();

for (int index = 0; index < numOfEventsToEnqueue; index++)
{
    EventData eventToEnqueue = new($"Event-{index}")
    {
        MessageId = index.ToString()
    };
    await bufferedProducer.EnqueueEventAsync(eventToEnqueue, cancellationTokenSource.Token);
}

// This shows how to verify that EnqueueEventAsync was called the correct number of times,
// with the expected arguments.

for (int index = 0; index < numOfEventsToEnqueue; index++)
{
    bufferedProducerMock
        .Verify(bp => bp.EnqueueEventAsync(
            It.Is<EventData>(e => (e.MessageId == index.ToString())), // Check that enqueue was called on each expected event
            It.IsAny<CancellationToken>()));
}

// The following lines demonstrate how to test a fail handler by calling it directly. Testing fail and success handlers
// does not require mocking.

int numEventsInBatch = 12;
List<EventData> eventsInBatch = new();

for (int index = 0; index < numEventsInBatch; index++)
{
    EventData eventToEnqueue = new($"Event-{index}")
    {
        MessageId = index.ToString()
    };
    await bufferedProducer.EnqueueEventAsync(eventToEnqueue, cancellationTokenSource.Token);
}

SendEventBatchFailedEventArgs args = new SendEventBatchFailedEventArgs(eventsInBatch, new Exception(), "0", default);

// The expected outcome of any application-specific complex processing can be verified here.

Assert.DoesNotThrowAsync(async () => await sendFailed(args));
```

## Consuming events using an `EventHubConsumerClient`

When testing code that is dependent on the `EventHubConsumerClient`, a developer may want to create a known set of expected events to verify that their application consumes them correctly.  Tests can mock `EventData` instances coming from the broker using the `EventHubModelFactory`. These can be used within the consumer client mock to mock returns from `ReadEventsFromPartitionAsync`, which for most applications is the key interaction to test.

This snippet also demonstrates how to mock `LastEnqueuedEventProperties` using the `EventHubsModelFactory`.

```C# Snippet:EventHubs_Sample11_MockingConsumerClient
Mock<EventHubConsumerClient> mockConsumer = new();

// This creates a mock LastEnqueuedEventProperties using the model factory.

LastEnqueuedEventProperties lastEnqueueEventProperties = EventHubsModelFactory.LastEnqueuedEventProperties(
    lastSequenceNumber : 1234,
    lastOffsetString : "234:1:954-2",
    lastEnqueuedTime : DateTimeOffset.Parse("1:24 AM"),
    lastReceivedTime : DateTimeOffset.Parse("1:26 AM"));

// This creates a mock of PartitionContext using the model factory.

PartitionContext partitionContext = EventHubsModelFactory.PartitionContext(
    fullyQualifiedNamespace: "sample-hub.servicebus.windows.net",
    eventHubName: "sample-event-hub",
    consumerGroup: "$Default",
    partitionId : "0",
    lastEnqueuedEventProperties : lastEnqueueEventProperties);

// This is a simple local method that returns an IAsyncEnumerable to use as the return for
// ReadEventsAsync below, since IAsyncEnumerables cannot be created directly.

async IAsyncEnumerable<PartitionEvent> mockReturn()
{
    // This mocks an EventData instance using the model factory. Different arguments can mock different
    // potential outputs from the broker.

    EventData eventData1 = EventHubsModelFactory.EventData(
        eventBody: new BinaryData($"Sample-Event-1"),
        systemProperties: new Dictionary<string, object>(), //arbitrary value
        partitionKey: "sample-key",
        sequenceNumber: 1000,
        offsetString: "1500:44:59492",
        enqueuedTime: DateTimeOffset.Parse("11:36 PM"));

    EventData eventData2 = EventHubsModelFactory.EventData(
        eventBody: new BinaryData($"Sample-Event-2"),
        systemProperties: new Dictionary<string, object>(), //arbitrary value
        partitionKey: "sample-key",
        sequenceNumber: 1000,
        offsetString: "1500:2:1111",
        enqueuedTime: DateTimeOffset.Parse("11:36 PM"));

    // This creates a mock PartitionEvent to return from the consumer client.

    PartitionEvent samplePartitionEvent1 = new(partitionContext, eventData1);
    PartitionEvent samplePartitionEvent2 = new(partitionContext, eventData2);

    // IAsyncEnumerable types can only be returned by async functions, use this no-op await statement to
    // force the method to be async.

    await Task.Yield();

    // Yield statements allow methods to emit multiple outputs. In async methods this can be over time.

    yield return samplePartitionEvent1;
    yield return samplePartitionEvent2;
}

// Use the method to mock a return from the consumer. We are setting up the method to return partition events that
// include the last enqueued event properties if the tracking flag is set in the options.

mockConsumer
    .Setup(c => c.ReadEventsFromPartitionAsync(
        It.IsAny<string>(),
        It.IsAny<EventPosition>(),
        It.Is<ReadEventOptions>(opts => opts.TrackLastEnqueuedEventProperties),
        It.IsAny<CancellationToken>()))
    .Returns(mockReturn());

// This sets up the consumer client to return a mocked set of partition Ids. Since GetPartitionIdsAsync is often
// used in conjunction with ReadEventsFromPartitionAsync, it may be useful for applications to mock both.

string[] consumerPartitions = new string[] { "0", "1" };

mockConsumer
    .Setup(p => p.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
    .ReturnsAsync(consumerPartitions);

// The following demonstrates how to use the mocked methods. This would be where application methods
// can be called and tested.

EventHubConsumerClient consumer = mockConsumer.Object;

using CancellationTokenSource cancellationTokenSource = new();

// Here we are setting the TrackLastEnqueuedEventProperties flag so that the EventHubConsumerClient receives
// LastEnqueuedEventProperties when reading events.

ReadEventOptions options = new()
{
    TrackLastEnqueuedEventProperties = true
};

string firstPartition = (await consumer.GetPartitionIdsAsync(cancellationTokenSource.Token)).First();
EventPosition startingPosition = EventPosition.Earliest;

await foreach (PartitionEvent receivedEvent in consumer.ReadEventsFromPartitionAsync(firstPartition, startingPosition, options, cancellationTokenSource.Token))
{
    // This is where application logic has control of the partition events.
}

// This is where applications can verify that the partition events output by the consumer client were handled as expected.
```

## Consuming events using the `PartitionReceiver`

The sample below illustrates how to mock a `PartitionReceiver`, and set up its `ReceiveBatchAsync` method to return a simple data batch.

Given the purpose of the `PartitionReceiver`, it is anticipated that most applications will have complex code surrounding their receivers, so this snippet is intentionally simple, with the focus being on using the `EventHubsModelFactory` to mock events being returned from the broker.

```C# Snippet:EventHubs_Sample11_PartitionReceiverMock
Mock<PartitionReceiver> mockReceiver = new();

// ReceivedEvents is a list of events to use when mocking ReceiveBatchAsync within the PartitionReceiver.

List<EventData> receivedEvents = new();

for (int index = 0; index < 10; index++)
{
    // Mocking an EventData instance, different arguments can simulate different potential
    // outputs from the broker
    EventData eventData = EventHubsModelFactory.EventData(
        eventBody: new BinaryData($"Sample-Event-{index}"),
        systemProperties: new Dictionary<string, object>(), //arbitrary value
        partitionKey: $"sample-key-{index}",
        sequenceNumber: 1234,
        offsetString: "234:5:93928381.1",
        enqueuedTime: DateTimeOffset.Parse("9:25 AM"));

    receivedEvents.Add(eventData);
}

// This sets up the mock to receive the list of events defined above when ReceiveBatchAsync is called
// on a given partition.

mockReceiver
    .Setup(r => r.ReceiveBatchAsync(
        It.IsAny<int>(),
        It.IsAny<TimeSpan>(),
        It.IsAny<CancellationToken>()))
    .ReturnsAsync(receivedEvents);

// The following demonstrates how to use the mocked methods. This would be where application code utilizing
// the mocked methods could be called and verified.

PartitionReceiver receiver = mockReceiver.Object;

using CancellationTokenSource cancellationTokenSource = new();

IEnumerable<EventData> receivedBatch = await receiver.ReceiveBatchAsync(
    maximumEventCount: 10,
    TimeSpan.FromSeconds(1),
    cancellationTokenSource.Token);
```

## Querying metadata properties using the `EventHubProducerClient`, `EventHubBufferedProducerClient`, or `EventHubConsumerClient`

Many applications make decisions for publishing based on the properties of the Event Hub itself or the properties of its partitions. Both can be mocked using the `EventHubsModelFactory`. The following snippet demonstrates how to mock Event Hub properties for both the `EventHubBufferedProducerClient` and the `EventHubProducerClient`, and how to set up the mocked producer clients to return a cohesive set of values for each of the accompanying getter methods.

These mocked properties can be used to test expected application behavior given a specific set of Event Hub properties. These property types can be mocked in the same way for `EventHubProducerClient`, `EventHubBufferedProducerClient`, and `EventHubConsumerClient`.

```C# Snippet:EventHubs_Sample11_MockingProducerProperties
// The first part of this snippet demonstrates mocking EventHubProperties on an EventHubProducerClient. Properties on
// EventHubBufferedProducerClients and EventHubConsumerClients can be mocked in the same way.

Mock<EventHubProducerClient> mockProducer = new();

// Here we are defining the set of partition identifiers we want for our testing scenario.

List<string> producerPartitions = new() { "0", "1" };

// Using the model factory, this call creates a mock of the EventHubProperties.

EventHubProperties eventHubProperties =
    EventHubsModelFactory.EventHubProperties(
        name: "fakeEventHubName",
        createdOn: DateTimeOffset.UtcNow, // arbitrary value
        partitionIds: producerPartitions.ToArray());

// This sets up GetEventHubPropertiesAsync to return the mocked Event Hub properties above.

mockProducer
    .Setup(p => p.GetEventHubPropertiesAsync(It.IsAny<CancellationToken>()))
    .ReturnsAsync(eventHubProperties);

// This sets up GetPartitionIdsAsync to return the mocked partition Ids above.

mockProducer
    .Setup(p => p.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
    .ReturnsAsync(producerPartitions.ToArray());

EventHubProducerClient producer = mockProducer.Object;

// Here we are demonstrating how to access the mocked EventHubProperties for illustrative purposes.

EventHubProperties properties = await producer.GetEventHubPropertiesAsync();
string eventHubName = properties.Name;
Debug.WriteLine($"Sending Events to: {eventHubName}");

// The second part of this snippet demonstrates mocking PartitionProperties on an EventHubBufferedProducerClient, which
// again can be done in the same way for the EventHubProducerClient and EventHubConsumerClient types.

Mock<EventHubBufferedProducerClient> bufferedProducerMock = new();

// This creates the set of partitions to mock for this test, and mocks the PartitionProperty instances using the model
// factory.

Dictionary<string, PartitionProperties> partitionProperties = new()
{
    // Non-empty partition
    { "0", EventHubsModelFactory.PartitionProperties(
        eventHubName : "eventhub-name",
        partitionId : "0",
        isEmpty : true,
        beginningSequenceNumber: 1000,
        lastSequenceNumber : 1100,
        lastOffsetString : "500:1:7863",
        lastEnqueuedTime : DateTime.UtcNow) },

    // Empty partition
    { "1", EventHubsModelFactory.PartitionProperties(
        eventHubName : "eventhub-name",
        partitionId : "1",
        isEmpty : false,
        beginningSequenceNumber : 2000,
        lastSequenceNumber : 2000,
        lastOffsetString : "760:1:8800",
        lastEnqueuedTime : DateTime.UtcNow) }
};

// This sets up GetPartitionIdsAsync to return the set of partition Ids mocked above.

bufferedProducerMock
    .Setup(p => p.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
    .ReturnsAsync(partitionProperties.Keys.ToArray());

// This sets up GetPartitionPropertiesAsync to return the mocked PartitionProperties for each partition Id input.

foreach (KeyValuePair<string, PartitionProperties> partition in partitionProperties)
{
    bufferedProducerMock
        .Setup(p => p.GetPartitionPropertiesAsync(
            partition.Key,
            It.IsAny<CancellationToken>()))
        .ReturnsAsync(partition.Value);
}

// The next lines demonstrate how to use the mocked partition Ids and PartitionProperties. This would be
// where application code utilizing the mocked methods could be called and verified.

EventHubBufferedProducerClient bufferedProducer = bufferedProducerMock.Object;

using CancellationTokenSource cancellationTokenSource = new();

// This gets all the partition Ids and arbitrarily takes the first partition Id.

string[] partitionIds = await bufferedProducer.GetPartitionIdsAsync(cancellationTokenSource.Token);
string partitionId = partitionIds[0];

// This gets the partition properties for the first partition Id.

PartitionProperties firstPartitionProperties =
    await bufferedProducer.GetPartitionPropertiesAsync(partitionId, cancellationTokenSource.Token);

string isPartitionEmpty = firstPartitionProperties.IsEmpty.ToString();

// The last part of this snippet briefly demonstrates mocking Partition Ids with an EventHubConsumerClient. This
// illustrates how each client can mock properties in the same way.

// This sets up the consumer client to return a mocked set of partition Ids.

Mock<EventHubConsumerClient> mockConsumer = new();

string[] consumerPartitions = new string[] { "0", "1", "2" };

mockConsumer
    .Setup(p => p.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
    .ReturnsAsync(consumerPartitions);
```
