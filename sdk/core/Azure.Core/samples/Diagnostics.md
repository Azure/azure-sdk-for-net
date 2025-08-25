# Azure SDK diagnostics

**NOTE:** Samples in this file apply only to packages that follow [Azure SDK Design Guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html). Names of such packages usually start with `Azure`. The samples make use of the `SecretClientOptions` type, but the same functionality is available for any of the `Azure.` packages that contain client options types that derive from [ClientOptions](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/src/ClientOptions.cs), e.g. `BlobClientOptions`, `TextAnalyticsClientOptions`, etc.

## Logging

The Azure SDK libraries produce various log messages that include information about:

1. Requests and responses
2. Authentication attempts
3. Retries

The simplest way to see the logs is to enable the console logging using the [`AzureEventSourceListener`](https://learn.microsoft.com/dotnet/api/azure.core.diagnostics.azureeventsourcelistener?view=azure-dotnet).

```C# Snippet:ConsoleLogging
// Setup a listener to monitor logged events.
using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger();
```

### Azure Event Source Listener lifetime

In order for the `AzureEventSourceListener` to collect logs, it must be in scope and active while the client library is in use.  If the listener is disposed or otherwise out of scope, logs cannot be collected.  Generally, we recommend creating the listener as a top-level member of the class where the Event Hubs client being inspected is used.

### Capture logs to trace

Logging can also be enabled for `Trace` in the same manner as console logging.

```C# Snippet:TraceLogging
// Setup a listener to monitor logged events.
using AzureEventSourceListener listener = AzureEventSourceListener.CreateTraceLogger();
```

### Changing log level

The `CreateConsoleLogger` and `CreateTraceLogger` methods have an optional parameter that specifies a minimum log level to display messages for.

```C# Snippet:LoggingLevel
using AzureEventSourceListener consoleListener = AzureEventSourceListener.CreateConsoleLogger(EventLevel.Warning);
using AzureEventSourceListener traceListener = AzureEventSourceListener.CreateTraceLogger(EventLevel.Informational);
```

### Enabling content logging

By default only URI and headers are logged. To enable content logging, set the logging level to `EventLevel.Verbose` and set the `Diagnostics.IsLoggingContentEnabled` client option:

```C# Snippet:LoggingContent
SecretClientOptions options = new SecretClientOptions()
{
    Diagnostics =
    {
        IsLoggingContentEnabled = true
    }
};
```

### Logging redacted headers and query parameters

Some sensitive headers and query parameters are not logged by default and are displayed as "REDACTED", to include them in logs use the `Diagnostics.LoggedHeaderNames` and `Diagnostics.LoggedQueryParameters` client options.

```C# Snippet:LoggingRedactedHeader
SecretClientOptions options = new SecretClientOptions()
{
    Diagnostics =
    {
        LoggedHeaderNames = { "x-ms-request-id" },
        LoggedQueryParameters = { "api-version" }
    }
};
```

You can also disable redaction completely by adding a `"*"` to collections mentioned above.

```C# Snippet:LoggingRedactedHeaderAll
SecretClientOptions options = new SecretClientOptions()
{
    Diagnostics =
    {
        LoggedHeaderNames = { "*" },
        LoggedQueryParameters = { "*" }
    }
};
```

### Custom logging callback

The `AzureEventSourceListener` class can also be used with a custom callback that allows log messages to be written to destination of your choice.

```C# Snippet:LoggingCallback
using AzureEventSourceListener listener = new AzureEventSourceListener(
    (args, message) => Console.WriteLine("[{0:HH:mm:ss:fff}][{1}] {2}", DateTimeOffset.Now, args.Level, message),
    level: EventLevel.Verbose);
```

When targeting .NET Standard 2.1, .NET Core 2.2, or newer, you might instead use `args.TimeStamp` to log the time the event was written instead of rendered, like above. It's in UTC format, so if you want to log the local time like in the example call `ToLocaleTime()` first.
For help diagnosing multi-threading issues, you might also log `args.OSThreadId` which is also available on those same targets.

More information about the `args` parameter for the callback can be found in the [EventWrittenEventArgs](https://learn.microsoft.com/dotnet/api/system.diagnostics.tracing.eventwritteneventargs) documentation.

### Applying filtering logic

The custom callback can be used with the listener to help filter log messages to reduce volume and noise when troubleshooting.

In the following example, `Verbose` messages for the `Azure-Identity` event source are captured and written to `Trace`.  Log messages for the `Azure-Messaging-EventHubs` event source are filtered to capture only a specific set to aid in debugging publishing, which are then written to the console.

```C# Snippet:LoggingWithFilters
using AzureEventSourceListener listener = new AzureEventSourceListener((args, message) =>
{
    if (args.EventSource.Name.StartsWith("Azure-Identity") && args.Level == EventLevel.Verbose)
    {
        Trace.WriteLine(message);
    }
    else if (args.EventSource.Name.StartsWith("Azure-Messaging-EventHubs"))
    {
        switch (args.EventId)
        {
            case 3:   // Event Publish Start
            case 4:   // Event Publish Complete
            case 5:   // Event Publish Error
                Console.WriteLine(message);
                break;
        }
    }
}, EventLevel.LogAlways);
```

### Capture filtered logs to a file

For scenarios where capturing logs to `Trace` or console isn't ideal, log information can be streamed into a variety of targets, such as Azure Storage, databases, and files for durable persistence.

The following example demonstrates capturing error logs to a text file so that they can be analyzed later, while capturing non-error information to console.  Its important to note that a simple approach is used for illustration.  This form may be helpful for troubleshooting, but a more robust and performant approach is recommended for long-term production use.

```C# Snippet:FileLogging
using Stream stream = new FileStream(
    "<< PATH TO FILE >>",
    FileMode.OpenOrCreate,
    FileAccess.Write,
    FileShare.Read);

using StreamWriter streamWriter = new StreamWriter(stream)
{
    AutoFlush = true
};

using AzureEventSourceListener listener = new AzureEventSourceListener((args, message) =>
{
    if (args.EventSource.Name.StartsWith("Azure-Identity"))
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
```

### Logging in ASP.NET Core applications

If your are using Azure SDK libraries in ASP.NET Core application consider using the `Microsoft.Extensions.Azure` package that provides integration with `Microsoft.Extensions.Logging` library. See [Microsoft.Extensions.Azure readme](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/extensions/Microsoft.Extensions.Azure/README.md) for more details.

## Distributed tracing

Azure client libraries are instrumented for distributed tracing using OpenTelemetry or ApplicationInsights SDK.

Distributed tracing relies on `ActivitySource` and `Activity` primitives defined in .NET. Check out [Adding distributed tracing instrumentation](https://learn.microsoft.com/dotnet/core/diagnostics/distributed-tracing-instrumentation-walkthroughs) guide for more details.

Azure client libraries produce the following kinds of activities:

- *HTTP calls*: every HTTP call originating from an Azure SDK
- *client method calls*: for example, `BlobClient.DownloadTo` or `SecretClient.StartDeleteSecret`.
- *messaging events*: Event Hubs and Service Bus message creation is traced and correlated with its sending, receiving, and processing.

Prior to November 2023, OpenTelemetry support was experimental for all Azure client libraries (see [Enabling experimental tracing features](#enabling-experimental-tracing-features) for the details).
Most of Azure client libraries released in or after November 2023 have OpenTelemetry support enabled by default. Tracing support in messaging libraries (`Azure.Messaging.ServiceBus` and `Azure.Messaging.EventHubs`) remains experimental.

More detailed distributed tracing convention can be found at [Azure SDK semantic conventions](https://github.com/Azure/azure-sdk/blob/main/docs/observability/opentelemetry-conventions.md). Additional attributes emitted by
Azure client libraries in .NET are documented [here](https://github.com/Azure/azure-sdk-for-net/blob/95b7ac20eebea0c13eab4a9bed0ee3ae1908d2bd/sdk/core/Azure.Core/samples/OpenTelemetrySemanticConventions.md).

### OpenTelemetry configuration

OpenTelemetry relies on `ActivitySource` to collect distributed traces.
Follow the [OpenTelemetry configuration guide](https://opentelemetry.io/docs/instrumentation/net/getting-started/#instrumentation) to configure collection and exporting pipeline.

Your observability vendor may enable Azure SDK activities by default. For example, stable Azure SDK instrumentations are enabled by [Azure Monitor OpenTelemetry Distro](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/monitor/Azure.Monitor.OpenTelemetry.AspNetCore/README.md#enable-azure-sdk-instrumentation).

If your observability vendor does not enable Azure SDK instrumentation, your can enable it manually:

```csharp
builder.Services.AddOpenTelemetry()
    .WithTracing(tracerProviderBuilder => tracerProviderBuilder
        .AddSource("Azure.*")
        .AddOtlpExporter())
```

_Note: check out [Enable experimental tracing features](#enabling-experimental-tracing-features) in case you're using one of the messaging libraries._

By calling into `AddSource("Azure.*")` we're telling OpenTelemetry SDK to listen to all sources which name starts with `Azure.`.

Azure SDK `ActivitySource` names match `{root library namespace}.{client name}` pattern. For example, Azure Blob Storage creates multiple `ActivitySource`s such as `Azure.Storage.Blobs.BlobContainerClient`, `Azure.Storage.Blobs.BlobClient`, or `Azure.Storage.Blobs.BlobServiceClient`.
Even though you might enable them one-by-one, it's recommended to enable all clients in a specific namespace.

For example, by calling `AddSource("Azure.Storage.Blobs.*")` we can enable distributed tracing for all clients in `Azure.Storage.Blobs` namespace and `"Azure.Storage.*"` would enable tracing for `Azure.Storage.Queues`, `Azure.Storage.Files.Shares`, and other Azure Storage libraries.

### Avoiding double-collection of HTTP activities

_Note: if you use Azure Monitor Distro for ASP.NET Core, you may skip this section. The distro configures telemetry collection preventing duplication._

Azure SDK traces all HTTP calls using `Azure.Core.Http` source. If you enable it along with generic HTTP client instrumentation such as `OpenTelemetry.Instrumentation.Http`, it would lead to double-collection of HTTP calls originating from Azure client libraries.

Unlike generic HTTP activities, Azure SDK HTTP activities include Azure-specific attributes such as request identifiers usually passed to and from Azure services in `x-ms-client-request-id`, `x-ms-request-id` or similar request and response headers. This data may be important when correlating client and server telemetry or creating support tickets.

To avoid double-collection you may either:
- enrich generic HTTP client activities with Azure request identifiers and disable Azure SDK HTTP activities.
- filter out duplicated generic HTTP client activities.

#### Enriching generic HTTP activities with Azure request identifiers

For example, you can do it with the following code snippet on .NET Core.

```csharp
// Messaging libraries still require feature flag.
AppContext.SetSwitch("Azure.Experimental.EnableActivitySource", true)

builder.Services.AddOpenTelemetry()
    .WithTracing(tracerProviderBuilder => tracerProviderBuilder
        .AddSource("Azure.Storage.*")
        .AddSource("Azure.Messaging.*")
        .AddHttpClientInstrumentation(o => {
            o.EnrichWithHttpResponseMessage = (activity, response) =>
            {
                if (response.RequestMessage.Headers.TryGetValues("x-ms-client-request-id", out var clientRequestId))
                {
                    activity.SetTag("az.client_request_id", clientRequestId);
                }
                if (response.Headers.TryGetValues("x-ms-request-id", out var requestId))
                {
                    activity.SetTag("az.service_request_id", requestId);
                }
            };
        })
        ...)
```

Here we enabled tracing for storage and messaging groups and also enabled HTTP client instrumentation providing hooks to collect request id headers. It's recommended to use provided attribute names to stay consistent with Azure SDK behavior.

_Note: request identifiers are also stamped on HTTP logs emitted by `Azure.Core`. If you collect such logs, or record request identifiers using other means, you might not need to record them on traces as well._

#### Filtering out duplicated HTTP client activities

Another approach would be to filter out generic HTTP client activities:

```csharp
.WithTracing(tracerProviderBuilder => tracerProviderBuilder
    .AddSource("Azure.*")
    .AddHttpClientInstrumentation(o => {
        o.FilterHttpRequestMessage = (_) => Activity.Current?.Parent?.Source?.Name != "Azure.Core.Http";
    })
    ...)
```

Here we enabled all `Azure.*` sources, but added filter to drop HTTP client activities that would be duplicates of `Azure` activities.

_Note: filtering does not prevent new activity from being created and new [`traceparent`](https://www.w3.org/TR/trace-context/#traceparent-header) from being generated._

## HTTP metrics

Azure client libraries do not collect HTTP-level metrics. Please use metrics coming from .NET platform and/or generic HTTP client instrumentation.

## Azure Monitor

Application Insights, a feature of Azure Monitor, is an extensible Application Performance Management (APM) service for developers and DevOps professionals. Use it to monitor your live applications. It will automatically detect performance anomalies, and includes powerful analytics tools to help you diagnose issues and to understand what users actually do with your app.

To setup Azure Monitor for your application follow the [Start Monitoring Application](https://learn.microsoft.com/azure/azure-monitor/app/opentelemetry-enable?tabs=aspnetcore) guide.

If your application uses ApplicationInsights SDK (classic), automatic collection of Azure SDK traces is supported since version `2.12.0` ([Microsoft.ApplicationInsights on NuGet](https://www.nuget.org/packages/Microsoft.ApplicationInsights/)).

### Sample

To see an example of distributed tracing in action, take a look at our [sample app](https://github.com/Azure/azure-sdk-for-net/blob/main/samples/linecounter/README.md) that combines several Azure client libraries.

### Enabling experimental tracing features

Certain tracing features remain experimental and still need to be enabled explicitly. Check out [Azure SDK semantic conventions](https://github.com/Azure/azure-sdk/blob/main/docs/observability/opentelemetry-conventions.md) to see which conventions are considered experimental.

The shape of experimental Activities may change in the future without notice. This includes:
- the kinds of operations that are tracked
- relationships between telemetry spans
- attributes attached to telemetry spans

ActivitySource support can be enabled through either of these three steps:

- Set the `AZURE_EXPERIMENTAL_ENABLE_ACTIVITY_SOURCE` environment variable to `true`.
- Set the `Azure.Experimental.EnableActivitySource` context switch to true in your application code:

```C#
AppContext.SetSwitch("Azure.Experimental.EnableActivitySource", true);
```

- Add the `RuntimeHostConfigurationOption` setting to your `.csproj`.

```xml
 <ItemGroup>
    <RuntimeHostConfigurationOption Include="Azure.Experimental.EnableActivitySource" Value="true" />
  </ItemGroup>
```

### Consume activities with `ActivityListener`

While it's common to use OpenTelemetry to record and export activities, it's also possible to consume them in your application with `ActivityListener`.
You'll need `System.Diagnostics.DiagnosticSource` package with version `6.0` or later consume Azure SDK Activities.

```xml
 <ItemGroup>
    <PackageReference Include="System.Diagnostics.DiagnosticSource" Version="6.0.1" />
  </ItemGroup>
```

The following sample shows how `ActivityListener` can be used to listen to Azure SDK Activities.

```C# Snippet:ActivitySourceListen
using ActivityListener listener = new ActivityListener()
{
    ShouldListenTo = a => a.Name.StartsWith("Azure"),
    Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllData,
    SampleUsingParentId = (ref ActivityCreationOptions<string> _) => ActivitySamplingResult.AllData,
    ActivityStarted = activity => Console.WriteLine("Start: " + activity.DisplayName),
    ActivityStopped = activity => Console.WriteLine("Stop: " + activity.DisplayName)
};
ActivitySource.AddActivityListener(listener);

var secretClient = new SecretClient(new Uri("https://example.com"), new DefaultAzureCredential());
secretClient.GetSecret("<secret-name>");
```

## Setting `x-ms-client-request-id` value sent with requests

By default `x-ms-client-request-id` header gets a unique value per client method call. If you would like to use a specific value for a set of requests use the `HttpPipeline.CreateClientRequestIdScope` method.

```C# Snippet:ClientRequestId
var secretClient = new SecretClient(new Uri("http://example.com"), new DefaultAzureCredential());

using (HttpPipeline.CreateClientRequestIdScope("<custom-client-request-id>"))
{
    // The HTTP request resulting from the client call would have x-ms-client-request-id value set to <custom-client-request-id>
    secretClient.GetSecret("<secret-name>");
}
```
