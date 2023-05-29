# Azure SDK diagnostics

**NOTE:** Samples in this file apply only to packages that follow [Azure SDK Design Guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html). Names of such packages usually start with `Azure`. The samples make use of the `SecretClientOptions` type, but the same functionality is available for any of the `Azure.` packages that contain client options types that derive from [ClientOptions](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/src/ClientOptions.cs), e.g. `BlobClientOptions`, `TextAnalyticsClientOptions`, etc.

## Logging

The Azure SDK libraries produce various log messages that include information about:

1. Requests and responses
2. Authentication attempts
3. Retries

The simplest way to see the logs is to enable the console logging using the [`AzureEventSourceListener`](https://docs.microsoft.com/dotnet/api/azure.core.diagnostics.azureeventsourcelistener?view=azure-dotnet).

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

By default only URI and headers are logged. To enable content logging, set the `Diagnostics.IsLoggingContentEnabled` client option:

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

More information about the `args` parameter for the callback can be found in the [EventWrittenEventArgs](https://docs.microsoft.com/dotnet/api/system.diagnostics.tracing.eventwritteneventargs) documentation.

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

## ActivitySource support

Azure SDKs released after October 2021 include experimental support for ActivitySource, which is a simplified way to create and listen to activities added in .NET 5.
Azure SDKs produce the following kinds of Activities:

- *HTTP calls*: every HTTP call originating from Azure SDKs
- *client method calls*: for example, `BlobClient.DownloadTo` or `SecretClient.StartDeleteSecret`.
- *messaging events*: Event Hubs and Service Bus message creation is traced and correlated with its sending, receiving, and processing.

Because `ActivitySource` support is experimental, the shape of Activities may change in the future without notice.  This includes:

- the kinds of operations that are tracked
- relationships between telemetry spans
- attributes attached to telemetry spans

More detailed distributed tracing convention can be found at https://github.com/Azure/azure-sdk/blob/main/docs/tracing/distributed-tracing-conventions.yml .

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

You'll need `System.Diagnostics.DiagnosticSource` package with version `5.0` or later consume Azure SDK Activities.

```xml
 <ItemGroup>
    <PackageReference Include="System.Diagnostics.DiagnosticSource" Version="5.0.1" />
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

## Distributed tracing

Azure SDKs are instrumented for distributed tracing using ApplicationsInsights or OpenTelemetry.

### ApplicationInsights with Azure Monitor

Application Insights, a feature of Azure Monitor, is an extensible Application Performance Management (APM) service for developers and DevOps professionals. Use it to monitor your live applications. It will automatically detect performance anomalies, and includes powerful analytics tools to help you diagnose issues and to understand what users actually do with your app

If your application already uses ApplicationInsights, automatic collection of Azure SDK traces is supported since version `2.12.0` ([Microsoft.ApplicationInsights on NuGet](https://www.nuget.org/packages/Microsoft.ApplicationInsights/)).

To setup ApplicationInsights tracking for your application follow the [Start Monitoring Application](https://docs.microsoft.com/azure/azure-monitor/learn/dotnetcore-quick-start) guide.

### OpenTelemetry with Azure Monitor, Zipkin and others

OpenTelemetry relies on ActivitySource to collect distributed traces. Follow steps in [ActivitySource support](#activitysource-support) section before proceeding to OpenTelemetry configuration.

Follow the [OpenTelemetry configuration guide](https://github.com/open-telemetry/opentelemetry-dotnet#configuration-with-microsoftextensionsdependencyinjection) to configure collecting distribute tracing event collection using the OpenTelemetry library.

### Sample

To see an example of distributed tracing in action, take a look at our [sample app](https://github.com/Azure/azure-sdk-for-net/blob/main/samples/linecounter/README.md) that combines several Azure SDKs.

## Setting x-ms-client-request-id value sent with requests

By default x-ms-client-request-id header gets a unique value per client method call. If you would like to use a specific value for a set of requests use the `HttpPipeline.CreateClientRequestIdScope` method.

```C# Snippet:ClientRequestId
var secretClient = new SecretClient(new Uri("http://example.com"), new DefaultAzureCredential());

using (HttpPipeline.CreateClientRequestIdScope("<custom-client-request-id>"))
{
    // The HTTP request resulting from the client call would have x-ms-client-request-id value set to <custom-client-request-id>
    secretClient.GetSecret("<secret-name>");
}
```
