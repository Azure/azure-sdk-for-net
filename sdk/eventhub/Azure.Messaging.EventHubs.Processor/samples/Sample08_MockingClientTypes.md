# Mocking Client Types

Event Hubs is built to support unit testing with mocks, as described in the [Azure SDK Design Guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking). This is an important feature of the library that allows developers to write tests that are completely focused on their own application logic, though they depend on the Event Hubs types.

For a more detailed description of mocking the set of Event Hubs client types see TODO INSERT LINK TO OTHER SAMPLE ONCE MERGED.

## Application-defined handlers

Interacting with an `EventHubProcessorClient` in an application is done through various handler methods. The Event Hubs library guarantees that each of these handlers will be called at the appropriate times while the processor is running. Therefore, it is recommended that handers be tested by calling them directly, rather than attempting to simulate having the processor producer invoke them.

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
partitionId: "0");

// Here we are mocking an event data instance using the model factory.

EventData eventData = EventHubsModelFactory.EventData(
    eventBody: new BinaryData("Sample-Event"),
    systemProperties: new Dictionary<string, object>(), //arbitrary value
    partitionKey: "sample-key",
    sequenceNumber: 1000,
    offset: 1500,
    enqueuedTime: DateTimeOffset.Parse("11:36 PM"));

// This creates a new instance of ProcessEventArgs to pass into the handler directly.

ProcessEventArgs processEventArgs = new(
    partition: partitionContext,
    data: eventData,
    updateCheckpointImplementation: async (CancellationToken ct) => await Task.CompletedTask); // arbitrary value

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