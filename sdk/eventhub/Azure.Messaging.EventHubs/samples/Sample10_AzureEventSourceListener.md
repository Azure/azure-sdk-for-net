# Capturing Event Hubs logs using AzureEventSourceListener class

The Event Hubs client library is instrumented using the .NET `EventSource` mechanism for logging. When instrumenting or diagnosing issues with applications that consume the library, it is often helpful to have access to the Event Hubs logs.

Following samples demonstrate how to use `AzureEventSourceListener` class in order to capture client libraries' emitted logs.

## Capture ALL Events and display them in the Console

Below snippet demonstrate an example of capturing ALL Log Level Information from ALL [Azure SDK for .NET](https://github.com/Azure/azure-sdk-for-net) libraries and displaying it directly in the Console.

Calling `CreateConsoleLogger` factory method with other levels, such as `Critical`, `Error`, `Warning`, `Informational` or `Verbose` will filter out unnecessary events.

This example might be suitable for the small Console Applications.

```C# Snippet:EventHubs_Sample10_ConsoleListener

var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";

using AzureEventSourceListener consoleListener = AzureEventSourceListener.CreateConsoleLogger(EventLevel.LogAlways);

EventHubProducerClient producer = new EventHubProducerClient(connectionString, eventHubName);

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

## Capture ALL Events and display them in the Trace

Very much similar to the previous example, this sample displays information in the Trace - therefore might be more appropriate for the other types of Applications than `Console`.

```C# Snippet:EventHubs_Sample10_TraceListener
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";

using AzureEventSourceListener traceListener = AzureEventSourceListener.CreateTraceLogger(EventLevel.LogAlways);

EventHubProducerClient producer = new EventHubProducerClient(connectionString, eventHubName);

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

## Capture filtered Log Events

Below snippet demonstrate usage of the callback method capturing all Log Level Events with custom filtering in the method's body.

The `Azure-Identity` (`Verbose` only) logs displayed in the `Trace` output and the `Azure-Messaging-EventHubs` events with the Ids 3 (Publish Start), 4 (Publish Complete) and 5 (Publish Error) in the `Console`.

More information about the `args` parameter's properties can be found in the [EventWrittenEventArgs Class](https://docs.microsoft.com/dotnet/api/system.diagnostics.tracing.eventwritteneventargs?view=net-5.0).

```C# Snippet:EventHubs_Sample10_CustomListenerWithFilter
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";

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

EventHubsConnectionStringProperties connectionStringProperties = EventHubsConnectionStringProperties.Parse(connectionString);

TokenCredential credential = new DefaultAzureCredential();

var producer = new EventHubProducerClient(
    connectionStringProperties.FullyQualifiedNamespace,
    connectionStringProperties.EventHubName ?? eventHubName,
    credential);

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

## Capture filtered Log Events into the file

When there is no access to `Trace` and `Console` outputs, e.g. in the production environment, logs can be streamed into the various storage resources such as Databases, Storage Blobs, Files, etc.

Below sample demonstrates capturing and appending client library's logging information into the File.

```C# Snippet:EventHubs_Sample10_CustomListenerWithFile
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";

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

EventHubProducerClient producer = new EventHubProducerClient(connectionString, eventHubName);

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
