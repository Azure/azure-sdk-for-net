# Capturing Event Hubs logs using the AzureEventSourceListener

The Event Hubs client library is instrumented using the .NET [`EventSource`](https://docs.microsoft.com/dotnet/api/system.diagnostics.tracing.eventsource) mechanism for logging. When instrumenting or diagnosing issues with applications that consume the library, it is often helpful to have access to the Event Hubs logs.  The following scenarios demonstrate how to use the [`AzureEventSourceListener`](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md#logging) from the `Azure.Core` package to capture logs emitted by the Event Hubs client library.

## Capture ALL events and write them in to the console

The following snippet demonstrates an example of capturing ALL Log Level Information from ALL [Azure SDK for .NET](https://github.com/Azure/azure-sdk-for-net) libraries and displaying it directly in the Console.  Calling the `AzureEventSourceListener.CreateConsoleLogger` factory method with other levels, such as `Critical`, `Error`, `Warning`, or `Informational` will help to filter out unwanted events.

**Note:** The Event Hubs client library emits a large amount of logs.  Capturing the full set of `Verbose` or `Informational` logs is not recommended for production applications unless troubleshooting a specific issue or storing gigabytes of log data is not a concern.

This example captures all Azure SDK logs from any client library in use, writing them to the standard `Console` output stream.

```C# Snippet:EventHubs_Sample10_ConsoleListener
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var producer = new EventHubProducerClient(connectionString, eventHubName);

using AzureEventSourceListener consoleListener = AzureEventSourceListener.CreateConsoleLogger(EventLevel.LogAlways);

try
{
    using var eventBatch = await producer.CreateBatchAsync();
    var eventData = new EventData("This is an event body");

    if (!eventBatch.TryAdd(eventData))
    {
        throw new Exception($"The event could not be added.");
    }
}
finally
{
    await producer.CloseAsync();
}
```

## Capture ALL events and write them to `Trace`

Similar to the previous example, this snippet captures all logs, but writes them to [`Trace`](https://docs.microsoft.com/dotnet/api/system.diagnostics.trace) output.   This approach may be desirable for applications that do not have the `Console` available.

```C# Snippet:EventHubs_Sample10_TraceListener
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var producer = new EventHubProducerClient(connectionString, eventHubName);

using AzureEventSourceListener traceListener = AzureEventSourceListener.CreateTraceLogger(EventLevel.LogAlways);

try
{
    using var eventBatch = await producer.CreateBatchAsync();
    var eventData = new EventData("This is an event body");

    if (!eventBatch.TryAdd(eventData))
    {
        throw new Exception($"The event could not be added.");
    }
}
finally
{
    await producer.CloseAsync();
}
```

## Apply filtering logic to logs

This examples demonstrates using a callback with the listener to allow custom logic, such as filtering, of the log messages.  This can help to reduce log spam when troubleshooting by capturing just the log entries that are helpful.   

In the snippet below, the `Verbose` messages for the `Azure-Identity` event source are captured and written to `Trace` output.  Log messages for the `Azure-Messaging-EventHubs` event source are filtered to capture only a specific set to aid in debugging publishing, which are then written to the standard `Console` output.

More information about the `args` parameter for the callback can be found in the [EventWrittenEventArgs](https://docs.microsoft.com/dotnet/api/system.diagnostics.tracing.eventwritteneventargs) documentation..

```C# Snippet:EventHubs_Sample10_CustomListenerWithFilter
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var producer = new EventHubProducerClient(connectionString, eventHubName);

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
    using var eventBatch = await producer.CreateBatchAsync();
    var eventData = new EventData("This is an event body");

    if (!eventBatch.TryAdd(eventData))
    {
        throw new Exception($"The event could not be added.");
    }
}
finally
{
    await producer.CloseAsync();
}
```

## Capture filtered logs to a file

For scenarios where capturing logs to `Trace` or `Console` outputs isn't ideal, log information can be streamed into a variety of targets, such as Azure Storage, databases, and files for durable persistence.    This example demonstrates capturing error logs to a text file so that they can be analyzed later, while capturing non-error information to `Console` output.  

```C# Snippet:EventHubs_Sample10_CustomListenerWithFile
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var producer = new EventHubProducerClient(connectionString, eventHubName);

using Stream stream = new FileStream("<< PATH TO THE FILE >>", FileMode.OpenOrCreate, FileAccess.Write);

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
    using var eventBatch = await producer.CreateBatchAsync();
    var eventData = new EventData("This is an event body");

    if (!eventBatch.TryAdd(eventData))
    {
        throw new Exception($"The event could not be added.");
    }
}
finally
{
    await producer.CloseAsync();
}
```
