
# Mocking Client Types
Event Hubs is built to be entirely mockable, an important feature that allows for testing the library. The following snippets demonstrate how to mock each client type and relevant data types.

## `EventHubProducerClient`

### Testing Batching logic
Say you have an application that needs to send large events often. You have logic to shrink events that are too large to fit in a batch. One way to test this method is to mock the `EventHubProducerClient` and `EventDataBatch` types 

```C# Snippet:EventHubs_Sample11_Validating
// Define the custom TryAdd callback to return false for any bodies
// larger than 5
var emptyBatch = EventHubsModelFactory.EventDataBatch(
    90,
    new List<EventData>(),
    new CreateBatchOptions() { MaximumSizeInBytes = 100 },
    eventData =>
    {
        return eventData.EventBody.ToString().Length > 5;
    });

// Create a mock of the EventHubProducerClient
var mockProducer = new Mock<EventHubProducerClient>();
mockProducer.Setup(p => p.CreateBatchAsync(It.IsAny<CancellationToken>())).ReturnsAsync(emptyBatch);
var producer = mockProducer.Object;

// Attempt to add an event with a string body larger than 5
var largeEvent = new EventData(new BinaryData("Large Event"));

using (var eventBatch = await producer.CreateBatchAsync())
{
    var wasAdded = eventBatch.TryAdd(largeEvent);
    if (!wasAdded)
    {
        // Validate the application-defined EventShrinker method
        var smallerEvent = EventShrinker(largeEvent);
        Assert.IsTrue(eventBatch.TryAdd(smallerEvent));
    }
}
```

Mocking EventHubProducer client - 

## `EventHubConsumerClient`


## `EventProcessorClient`


## `EventProcessor<TPartition>`
