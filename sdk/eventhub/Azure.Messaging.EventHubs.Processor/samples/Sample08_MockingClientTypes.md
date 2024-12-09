# Mocking Client Types

Event Hubs is built to support unit testing with mocks, as described in the [Azure SDK Design Guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking). This is an important feature of the library that allows developers to write tests that are completely focused on their own application logic, though they depend on the Event Hubs types.

For a more detailed description of mocking the set of Event Hubs client types see the [Event Hubs mocking client types sample](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample11_MockingClientTypes.md).

## Table of contents

- [Testing event handlers](#application-defined-handlers)
- [Simulating the EventProcessorClient running](#simulating-the-eventprocessorclient-running)

## Application-defined handlers

Interacting with an `EventHubProcessorClient` in an application is done through various handler methods. The Event Hubs library guarantees that each of these handlers will be called at the appropriate times while the processor is running. Therefore, it is recommended that handlers be tested by calling them directly, rather than attempting to simulate having the processor producer invoke them.

The most common of these handlers are the process event and process error handlers. The necessary inputs to these handlers can be mocked using the `EventHubsModelFactory` and passed into their respective handler definitions, this is demonstrated below.

```C# Snippet:EventHubs_Sample08_CallingHandlersDirectly
// This process event handler is for illustrative purposes only.

Task processEventHandler(ProcessEventArgs args)
{
    // Application-defined code here

    return Task.CompletedTask;
}

// This process error handler is for illustrative purposes only.

Task processErrorHandler(ProcessErrorEventArgs args)
{
    // Application-defined code here

    return Task.CompletedTask;
}

// Here we are mocking a partition context using the model factory.

PartitionContext partitionContext = EventHubsModelFactory.PartitionContext(
    fullyQualifiedNamespace: "sample-hub.servicebus.windows.net",
    eventHubName: "sample-hub",
    consumerGroup: "$Default",
    partitionId: "0");

// Here we are mocking an event data instance with broker-owned properties populated.

EventData eventData = EventHubsModelFactory.EventData(
    eventBody: new BinaryData("Sample-Event"),
    systemProperties: new Dictionary<string, object>(), //arbitrary value
    partitionKey: "sample-key",
    sequenceNumber: 1000,
    offsetString: "1500:1:3344.1",
    enqueuedTime: DateTimeOffset.Parse("11:36 PM"));

// This creates a new instance of ProcessEventArgs to pass into the handler directly.

ProcessEventArgs processEventArgs = new(
    partition: partitionContext,
    data: eventData,
    updateCheckpointImplementation: _ => Task.CompletedTask); // arbitrary value

// Here is where the application defined handler code can be tested and validated.

Assert.DoesNotThrowAsync(async () => await processEventHandler(processEventArgs));

// This creates a new instance of ProcessErrorEventArgs to pass into the handler directly.

ProcessErrorEventArgs processErrorEventArgs = new(
    partitionId: "sample-partition-id",
    operation: "sample-operation",
    exception: new Exception("sample-exception"));

// Here is where the application defined handler code can be tested and validated.

Assert.DoesNotThrowAsync(async () => await processErrorHandler(processErrorEventArgs));
```
## Simulating the EventProcessorClient running

While calling the handler methods directly is recommended for testing their logic, there may be times where it is desirable to test how an application interacts with the `EventHubProcessorClient` more generally, such as to start and stop processing.  For these scenarios, it may be helpful to mock the `StartProcessingAsync` and `StopProcessingAsync` methods and simulate dispatching events or exceptions.  This allows for testing application logic while simulating normal behavior of the processor.

This can be accomplished by using at timer to call handler methods when the `EventProcessorClient` is started and to cease doing so when the processor is stopped.  The necessary inputs to these handlers can be mocked using the `EventHubsModelFactory`.  The example below demonstrates a timer dispatching events to the handler for processing while the processor is "running".

```C# Snippet:EventHubs_Sample08_CallingHandlersOnAnInterval
// This handler is for illustrative purposes only.

Task processEventHandler(ProcessEventArgs args)
{
    // Application-defined code here

    return Task.CompletedTask;
}

// This function simulates a random event being emitted for processing.

Random rng = new();
string[] partitions = new[] { "0", "1", "2", "3" };

TimerCallback dispatchEvent = async _ =>
{
    string partition = partitions[rng.Next(0, partitions.Length - 1)];

    PartitionContext partitionContext = EventHubsModelFactory.PartitionContext(
        fullyQualifiedNamespace: "sample-hub.servicebus.windows.net",
        eventHubName: "sample-hub",
        consumerGroup: "$Default",
        partitionId: partition);

    EventData eventData = EventHubsModelFactory.EventData(
        eventBody: new BinaryData("Sample-Event"),
        systemProperties: new Dictionary<string, object>(), //arbitrary value
        partitionKey: "sample-key",
        sequenceNumber: 1000,
        offsetString: "1500:1:1111",
        enqueuedTime: DateTimeOffset.Parse("11:36 PM"));

    ProcessEventArgs eventArgs = new(
        partition: partitionContext,
        data: eventData,
        updateCheckpointImplementation: _ => Task.CompletedTask);

    await processEventHandler(eventArgs);
};

// Create a timer that runs once-a-second when started and, otherwise, sits idle.

Timer eventDispatchTimer = new(
    dispatchEvent,
    null,
    Timeout.Infinite,
    Timeout.Infinite);

void startTimer() =>
    eventDispatchTimer.Change(0, (int)TimeSpan.FromSeconds(1).TotalMilliseconds);

void stopTimer() =>
    eventDispatchTimer.Change(Timeout.Infinite, Timeout.Infinite);

// Create a mock of the processor that dispatches events on when StartProcessingAsync
// is called and does so until StopProcessingAsync is called.

Mock<EventProcessorClient> mockProcessor = new Mock<EventProcessorClient>();

mockProcessor
    .Setup(processor => processor.StartProcessingAsync(It.IsAny<CancellationToken>()))
    .Returns(Task.CompletedTask)
    .Callback(startTimer);

mockProcessor
    .Setup(processor => processor.StopProcessingAsync(It.IsAny<CancellationToken>()))
    .Returns(Task.CompletedTask)
    .Callback(stopTimer);

// Start the processor.

await mockProcessor.Object.StartProcessingAsync();

// << ... Application Testing Here ... >>

// Stop the processor.

await mockProcessor.Object.StopProcessingAsync();
```