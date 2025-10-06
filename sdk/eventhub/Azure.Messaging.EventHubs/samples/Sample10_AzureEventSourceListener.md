# Capturing Event Hubs logs using the AzureEventSourceListener

The Event Hubs client library is instrumented using the .NET [`EventSource`](https://learn.microsoft.com/dotnet/api/system.diagnostics.tracing.eventsource) mechanism for logging. When instrumenting or diagnosing issues with applications that consume the library, it is often helpful to have access to the Event Hubs logs.  The following scenarios demonstrate how to use the [`AzureEventSourceListener`](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md#logging) from the `Azure.Core` package to capture logs emitted by the Event Hubs client library.

## Table of contents

- [Azure Event Source Listener lifetime](#azure-event-source-listener-lifetime)
- [Capture all events and write them in to the console](#capture-all-events-and-write-them-in-to-the-console)
- [Capture all events and write them to `Trace`](#capture-all-events-and-write-them-to-trace)
- [Apply filtering logic to logs](#apply-filtering-logic-to-logs)
- [Capture filtered logs to a file](#capture-filtered-logs-to-a-file)
- [Finding the desired events](#finding-the-desired-events)
    - [Event Source: "Azure-Messaging-EventHubs"](#event-source-azure-messaging-eventhubs)
    - [Event Source: "Azure-Messaging-EventHubs-Processor-EventProcessorClient"](#event-source-azure-messaging-eventhubs-processor-eventprocessorclient)
    - [Event Source: "Azure-Messaging-EventHubs-Processor-BlobEventStore"](#event-source-azure-messaging-eventhubs-processor-blobeventstore)
    - [Event Source: "Azure-Messaging-EventHubs-Processor-PartitionLoadBalancer"](#event-source-azure-messaging-eventhubs-processor-partitionloadbalancer)

## Azure Event Source Listener lifetime

In order for the `AzureEventSourceListener` to collect logs, it must be in scope and active while the client library is in use.  If the listener is disposed or otherwise out of scope, logs cannot be collected.  Generally, we recommend creating the listener as a top-level member of the class where the Event Hubs client being inspected is used.

## Capture all events and write them in to the console

The following snippet demonstrates an example of capturing all log information from every [Azure SDK for .NET](https://github.com/Azure/azure-sdk-for-net) library in use and displaying it directly in the Console.  Calling the `AzureEventSourceListener.CreateConsoleLogger` factory method with other levels, such as `Critical`, `Error`, `Warning`, or `Informational` will help to filter out unwanted events.

**Note:** The Event Hubs client library emits a large amount of logs.  Capturing the full set of `Verbose` or `Informational` logs is not recommended for production applications unless troubleshooting a specific issue or storing gigabytes of log data is not a concern.

This example captures all Azure SDK logs from any client library in use, writing them to the standard `Console` output stream.

```C# Snippet:EventHubs_Sample10_ConsoleListener
var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var credential = new DefaultAzureCredential();

var producer = new EventHubProducerClient(
    fullyQualifiedNamespace,
    eventHubName,
    credential);

using AzureEventSourceListener consoleListener = AzureEventSourceListener.CreateConsoleLogger(EventLevel.LogAlways);

try
{
    var events = new[]
    {
        new EventData("EventOne"),
        new EventData("EventTwo")
    };

    await producer.SendAsync(events);
}
finally
{
    await producer.CloseAsync();
}
```

## Capture all events and write them to `Trace`

Similar to the previous example, this snippet captures all logs, but writes them to [`Trace`](https://learn.microsoft.com/dotnet/api/system.diagnostics.trace) output.   This approach may be desirable for applications that do not have the `Console` available.

```C# Snippet:EventHubs_Sample10_TraceListener
var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var credential = new DefaultAzureCredential();

var producer = new EventHubProducerClient(
    fullyQualifiedNamespace,
    eventHubName,
    credential);

using AzureEventSourceListener traceListener = AzureEventSourceListener.CreateTraceLogger(EventLevel.LogAlways);

try
{
    var events = new[]
    {
        new EventData("EventOne"),
        new EventData("EventTwo")
    };

    await producer.SendAsync(events);
}
finally
{
    await producer.CloseAsync();
}
```

## Apply filtering logic to logs

This examples demonstrates using a callback with the listener to allow custom logic, such as filtering, of the log messages.  This can help to reduce log spam when troubleshooting by capturing just the log entries that are helpful.

In the snippet below, the `Verbose` messages for the `Azure-Identity` event source are captured and written to `Trace` output.  Log messages for the `Azure-Messaging-EventHubs` event source are filtered to capture only a specific set to aid in debugging publishing, which are then written to the standard `Console` output.

More information about the `args` parameter for the callback can be found in the [EventWrittenEventArgs](https://learn.microsoft.com/dotnet/api/system.diagnostics.tracing.eventwritteneventargs) documentation..

```C# Snippet:EventHubs_Sample10_CustomListenerWithFilter
var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var credential = new DefaultAzureCredential();

var producer = new EventHubProducerClient(
    fullyQualifiedNamespace,
    eventHubName,
    credential);

using AzureEventSourceListener customListener = new AzureEventSourceListener((args, message) =>
{
    if (args.EventSource.Name.StartsWith("Azure-Identity") && args.Level == EventLevel.Verbose)
    {
        Trace.WriteLine(message);
    }
    else if (args.EventSource.Name.StartsWith("Azure-Messaging-EventHubs"))
    {
        switch (args.EventId)
        {
            case 3:   // Publish Start
            case 4:   // Publish Complete
            case 5:   // Publish Error
                Console.WriteLine(message);
                break;
        }
    }
}, EventLevel.LogAlways);

try
{
    var events = new[]
    {
        new EventData("EventOne"),
        new EventData("EventTwo")
    };

    await producer.SendAsync(events);
}
finally
{
    await producer.CloseAsync();
}
```

## Capture filtered logs to a file

For scenarios where capturing logs to `Trace` or `Console` outputs isn't ideal, log information can be streamed into a variety of targets, such as Azure Storage, databases, and files for durable persistence.    This example demonstrates capturing error logs to a text file so that they can be analyzed later, while capturing non-error information to `Console` output.

```C# Snippet:EventHubs_Sample10_CustomListenerWithFile
var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var credential = new DefaultAzureCredential();

using Stream stream = new FileStream("<< PATH TO THE FILE >>", FileMode.OpenOrCreate, FileAccess.Write);

var producer = new EventHubProducerClient(
    fullyQualifiedNamespace,
    eventHubName,
    credential);

using StreamWriter streamWriter = new StreamWriter(stream)
{
    AutoFlush = true
};

using AzureEventSourceListener customListener = new AzureEventSourceListener((args, message) =>
{
    if (args.EventSource.Name.StartsWith("Azure-Messaging-EventHubs"))
    {
        switch (args.Level)
        {
            case EventLevel.Error:
                streamWriter.Write(message);
                break;
            default:
                Console.WriteLine(message);
                break;
        }
    }
}, EventLevel.LogAlways);

try
{
    var events = new[]
    {
        new EventData("EventOne"),
        new EventData("EventTwo")
    };

    await producer.SendAsync(events);
}
finally
{
    await producer.CloseAsync();
}
```

## Finding the desired events

The Event Hubs client library logs using several event sources for different areas of functionality.  Each event source contains multiple log events, with most grouped into logical sets that follow the pattern:

- `{ Operation Name }Start`
- `{ Operation Name }Error`
- `{ Operation Name }Complete`

Each operation will always emit its "Start" and "Complete" log events, and will only emit its "Error" event as needed.  For AMQP operations, the "Complete" event will detail the number of retries that were used for that operation.

Unfortunately, there is currently way to easily view all of the log events offered.  To discover the available log events, inspecting the associated source code is the best option.

### Event Source: "Azure-Messaging-EventHubs"

This source contains log events for the core Event Hubs operations and client types. This includes the majority of event processor operations. _([source](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/eventhub/Azure.Messaging.EventHubs/src/Diagnostics/EventHubsEventSource.cs))_

### Event Source: "Azure-Messaging-EventHubs-Processor-EventProcessorClient"

This source contains log events specific to the `EventProcessorClient`, focused mainly on interations with the various event handlers.  Information for the core processor operations is emitted by "Azure-Messaging-EventHubs".  _([source](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/eventhub/Azure.Messaging.EventHubs.Processor/src/Diagnostics/EventProcessorClientEventSource.cs))_

### Event Source: "Azure-Messaging-EventHubs-Processor-BlobEventStore"

This source contains log events specific to the interactions between the `EventProcessorClient` and Azure Blob Storage  _([source](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/eventhub/Azure.Messaging.EventHubs.Processor/src/Diagnostics/BlobEventStoreEventSource.cs))_

### Event Source: "Azure-Messaging-EventHubs-Processor-PartitionLoadBalancer"

This source contains log events specific to the load balancing activities of event processor types, including ownership and partition theft decisions. _([source](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/eventhub/Azure.Messaging.EventHubs.Shared/src/Diagnostics/PartitionLoadBalancerEventSource.cs))_
