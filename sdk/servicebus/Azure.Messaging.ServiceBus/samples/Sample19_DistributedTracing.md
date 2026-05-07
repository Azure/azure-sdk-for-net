# Distributed tracing

This sample demonstrates how to observe Service Bus operations using the built-in distributed tracing instrumentation. The `Azure.Messaging.ServiceBus` client library emits [Activity](https://learn.microsoft.com/dotnet/api/system.diagnostics.activity) events for every operation, so you can monitor latency, trace message flow across services, and diagnose failures in production.

For background on how Service Bus propagates trace context, see [Distributed tracing and correlation through Service Bus messaging](https://learn.microsoft.com/azure/service-bus-messaging/service-bus-end-to-end-tracing).

## Automatic tracing with OpenTelemetry

The `Azure.Messaging.ServiceBus` client library is instrumented for distributed tracing using [OpenTelemetry](https://opentelemetry.io/docs/languages/dotnet/) or the Application Insights SDK. Both approaches collect traces with no per-call code changes.

> **Experimental:** OpenTelemetry support in `Azure.Messaging.ServiceBus` remains experimental. You must opt in by setting the `AZURE_EXPERIMENTAL_ENABLE_ACTIVITY_SOURCE` environment variable to `true` or the `Azure.Experimental.EnableActivitySource` [AppContext](https://learn.microsoft.com/dotnet/api/system.appcontext) switch. See [Enabling experimental tracing features](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md#enabling-experimental-tracing-features) for details.

This section shows OpenTelemetry configuration. For the Application Insights approach, see [Automatic tracing with Application Insights](#automatic-tracing-with-application-insights) below.

```C# Snippet:ServiceBusOpenTelemetrySetup
// Enable the experimental OpenTelemetry support in Azure SDK client libraries.
AppContext.SetSwitch("Azure.Experimental.EnableActivitySource", true);

// Configure the OpenTelemetry tracer provider to listen to the Azure.Messaging.ServiceBus source.
using TracerProvider tracerProvider = Sdk.CreateTracerProviderBuilder()
    .AddSource("Azure.Messaging.ServiceBus.*")
    .AddConsoleExporter()
    .Build();

// The fully qualified Service Bus namespace. This is likely to be similar to
// {yournamespace}.servicebus.windows.net.
string fullyQualifiedNamespace = "<fully_qualified_namespace>";
DefaultAzureCredential credential = new();
await using ServiceBusClient client = new(fullyQualifiedNamespace, credential);

ServiceBusSender sender = client.CreateSender("<queue-name>");
await sender.SendMessageAsync(new ServiceBusMessage("Hello with tracing!"));
// The send operation is automatically captured as a span by OpenTelemetry.
```

When the processor handles a message, the client library creates a `Process` activity that is automatically linked to the `Send` activity on the producer side via the `Diagnostic-Id` message property. This gives you end-to-end visibility from sender to receiver.

```C# Snippet:ServiceBusOpenTelemetryProcessor
AppContext.SetSwitch("Azure.Experimental.EnableActivitySource", true);

using TracerProvider tracerProvider = Sdk.CreateTracerProviderBuilder()
    .AddSource("Azure.Messaging.ServiceBus.*")
    .AddConsoleExporter()
    .Build();

// The fully qualified Service Bus namespace. This is likely to be similar to
// {yournamespace}.servicebus.windows.net.
string fullyQualifiedNamespace = "<fully_qualified_namespace>";
DefaultAzureCredential credential = new();
await using ServiceBusClient client = new(fullyQualifiedNamespace, credential);

await using ServiceBusProcessor processor = client.CreateProcessor("<queue-name>");

async Task MessageHandler(ProcessMessageEventArgs args)
{
    // This handler runs inside an Activity that is correlated
    // with the sender's Activity through the Diagnostic-Id property.
    Console.WriteLine($"Processing message: {args.Message.Body}");
    Console.WriteLine($"Activity.Current: {Activity.Current?.Id}");

    await args.CompleteMessageAsync(args.Message);
}

Task ErrorHandler(ProcessErrorEventArgs args)
{
    Console.WriteLine($"Error: {args.Exception}");
    return Task.CompletedTask;
}

try
{
    processor.ProcessMessageAsync += MessageHandler;
    processor.ProcessErrorAsync += ErrorHandler;

    await processor.StartProcessingAsync();
    Console.ReadKey();
    await processor.StopProcessingAsync();
}
finally
{
    processor.ProcessMessageAsync -= MessageHandler;
    processor.ProcessErrorAsync -= ErrorHandler;
}
```

To export traces to Azure Monitor (Application Insights) instead of the console, replace `AddConsoleExporter()` with the Azure Monitor exporter:

```C# Snippet:ServiceBusOpenTelemetryAzureMonitor
using TracerProvider tracerProvider = Sdk.CreateTracerProviderBuilder()
    .AddSource("Azure.Messaging.ServiceBus.*")
    .AddAzureMonitorTraceExporter(options =>
    {
        options.ConnectionString = "<application-insights-connection-string>";
    })
    .Build();
```

## Automatic tracing with Application Insights

If you use the [Application Insights SDK](https://learn.microsoft.com/azure/azure-monitor/app/app-insights-overview) and the `ServiceBusProcessor`, send and process operations are tracked and correlated automatically — no extra code required.

For finer-grained control — for example, to add custom telemetry or explicitly set the parent context — you can start a request telemetry operation manually within the processor callback:

```C# Snippet:ServiceBusAppInsightsManualProcessing
async Task ProcessAsync(ProcessMessageEventArgs args)
{
    ServiceBusReceivedMessage message = args.Message;
    if (message.ApplicationProperties.TryGetValue("Diagnostic-Id", out var objectId)
        && objectId is string diagnosticId)
    {
        var activity = new Activity("MyApp.ProcessMessage");
        activity.SetParentId(diagnosticId);

        using var operation = telemetryClient.StartOperation<RequestTelemetry>(activity);
        try
        {
            // Your message processing logic here.
            telemetryClient.TrackTrace($"Processing message {message.MessageId}");
            await args.CompleteMessageAsync(message);
        }
        catch (Exception ex)
        {
            telemetryClient.TrackException(ex);
            operation.Telemetry.Success = false;
            throw;
        }
    }
}
```

## Listening to DiagnosticSource events directly

If you do not use OpenTelemetry or Application Insights, you can subscribe to Service Bus diagnostic events directly using `DiagnosticListener`. This gives you full control over which events to capture and how to record them.

The Service Bus client emits events on the `Azure.Messaging.ServiceBus` diagnostic source. Each operation produces a `Start` and `Stop` event, and `Activity.Current` carries the trace context. The `Subscribe` methods require an `IObserver<T>` implementation — the following helper adapts a callback:

```C# Snippet:ServiceBusCallbackObserverHelper
private sealed class CallbackObserver<T> : IObserver<T>
{
    private readonly Action<T> _onNext;
    public CallbackObserver(Action<T> onNext) => _onNext = onNext;
    public void OnNext(T value) => _onNext(value);
    public void OnCompleted() { }
    public void OnError(Exception error) { }
}
```

```C# Snippet:ServiceBusDiagnosticListener
IDisposable innerSubscription = null;
IDisposable outerSubscription = DiagnosticListener.AllListeners.Subscribe(
    new CallbackObserver<DiagnosticListener>(listener =>
    {
        if (listener.Name == "Azure.Messaging.ServiceBus")
        {
            innerSubscription = listener.Subscribe(
                new CallbackObserver<KeyValuePair<string, object>>(evnt =>
                {
                    // Log the operation when it completes.
                    if (evnt.Key.EndsWith("Stop"))
                    {
                        Activity currentActivity = Activity.Current;
                        Console.WriteLine(
                            $"Operation {currentActivity.OperationName} completed " +
                            $"in {currentActivity.Duration.TotalMilliseconds:F1}ms " +
                            $"[Id={currentActivity.Id}]");
                    }
                }));
        }
    }));

try
{
    // Use the Service Bus client as normal — diagnostic events are emitted automatically.
    // The fully qualified Service Bus namespace. This is likely to be similar to
    // {yournamespace}.servicebus.windows.net.
    string fullyQualifiedNamespace = "<fully_qualified_namespace>";
    DefaultAzureCredential credential = new();
    await using ServiceBusClient client = new(fullyQualifiedNamespace, credential);

    ServiceBusSender sender = client.CreateSender("<queue-name>");
    await sender.SendMessageAsync(new ServiceBusMessage("Traced message"));
}
finally
{
    innerSubscription?.Dispose();
    outerSubscription?.Dispose();
}
```

## Filtering diagnostic events

You can reduce overhead by subscribing only to the operations you care about. Use the `isEnabled` callback to filter by operation name or entity. This prevents `Activity` creation for non-matching operations.

```C# Snippet:ServiceBusDiagnosticFiltering
innerSubscription = listener.Subscribe(
    new CallbackObserver<KeyValuePair<string, object>>(evnt =>
    {
        if (evnt.Key.EndsWith("Stop"))
        {
            Activity currentActivity = Activity.Current;
            Console.WriteLine(
                $"{currentActivity.OperationName}: {currentActivity.Duration.TotalMilliseconds:F1}ms");
        }
    }),
    (eventName, _, _) =>
    {
        // Only listen to send and process operations.
        return eventName.StartsWith("ServiceBusSender.Send")
            || eventName.StartsWith("ServiceBusProcessor.ProcessMessage");
    });
```

## Instrumented operations

The following operations emit diagnostic activities:

| Operation | Source API |
|-----------|-----------|
| `ServiceBusSender.Send` | `SendMessageAsync`, `SendMessagesAsync` |
| `ServiceBusSender.Schedule` | `ScheduleMessageAsync`, `ScheduleMessagesAsync` |
| `ServiceBusSender.Cancel` | `CancelScheduledMessageAsync`, `CancelScheduledMessagesAsync` |
| `ServiceBusReceiver.Receive` | `ReceiveMessageAsync`, `ReceiveMessagesAsync` |
| `ServiceBusReceiver.ReceiveDeferred` | `ReceiveDeferredMessageAsync`, `ReceiveDeferredMessagesAsync` |
| `ServiceBusReceiver.Peek` | `PeekMessageAsync`, `PeekMessagesAsync` |
| `ServiceBusReceiver.Abandon` | `AbandonMessageAsync` |
| `ServiceBusReceiver.Complete` | `CompleteMessageAsync` |
| `ServiceBusReceiver.DeadLetter` | `DeadLetterMessageAsync` |
| `ServiceBusReceiver.Defer` | `DeferMessageAsync` |
| `ServiceBusReceiver.Delete` | `DeleteMessagesAsync` |
| `ServiceBusReceiver.Purge` | `PurgeMessagesAsync` |
| `ServiceBusReceiver.RenewMessageLock` | `RenewMessageLockAsync` |
| `ServiceBusSessionReceiver.RenewSessionLock` | `RenewSessionLockAsync` |
| `ServiceBusSessionReceiver.GetSessionState` | `GetSessionStateAsync` |
| `ServiceBusSessionReceiver.SetSessionState` | `SetSessionStateAsync` |
| `ServiceBusProcessor.ProcessMessage` | Callback on `ProcessMessageAsync` |
| `ServiceBusSessionProcessor.ProcessSessionMessage` | Callback on `ProcessMessageAsync` |
| `ServiceBusRuleManager.CreateRule` | `CreateRuleAsync` |
| `ServiceBusRuleManager.DeleteRule` | `DeleteRuleAsync` |
| `ServiceBusRuleManager.GetRules` | `GetRulesAsync` |

For more details on the Azure SDK distributed tracing conventions, see [Diagnostics samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md).
