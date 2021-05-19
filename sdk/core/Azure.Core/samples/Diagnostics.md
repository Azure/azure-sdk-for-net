# Azure SDK diagnostics

**NOTE:** Samples in this file apply only to packages that follow [Azure SDK Design Guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html). Names of such packages usually start with `Azure`. 

## Logging

Azure SDKs produce various log messages that include information about:
1. Requests and reponses
2. Authentication attempts
3. Retries

The simplest way to see the logs is to enable the console logging.

```C# Snippet:ConsoleLogging
// Setup a listener to monitor logged events.
using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger();
```

### Enabling content logging

By default only URI and headers are logged to enable content logging set the `Diagnostics.IsLoggingContentEnabled` client option:

```C# Snippet:LoggingContent
SecretClientOptions options = new SecretClientOptions()
{
    Diagnostics =
    {
        IsLoggingContentEnabled = true
    }
};
```

**NOTE:** The content is logged at the `Verbose` level so you might need to change the listener settings for content logs to appear.

### Changing log level

The `CreateConsoleLogger` method has an optional parameter that specifies a minimum log level to display messages for.

```C# Snippet:ConsoleLoggingLevel
using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger(EventLevel.Warning);
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

### ASP.NET Core applications

If your are using Azure SDK libraries in ASP.NET Core application consider using the `Microsoft.Extensions.Azure` package that provides integration with `Microsoft.Extensions.Logging` library. See [Microsoft.Extensions.Azure readme](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/extensions/Microsoft.Extensions.Azure/README.md) for more details.


### Custom logging callback

The `AzureEventSourceListener` class can also be used with a custom callback that allows log messages to be written to destination of your choice.

```C# Snippet:LoggingCallback
using AzureEventSourceListener listener = new AzureEventSourceListener(
    (e, message) => Console.WriteLine("[{0:HH:mm:ss:fff}][{1}] {2}", DateTimeOffset.Now, e.Level, message),
    level: EventLevel.Verbose);
```

When targeting .NET Standard 2.1, .NET Core 2.2, or newer, you might instead use `e.TimeStamp` to log the time the event was written instead of rendered, like above. It's in UTC format, so if you want to log the local time like in the example call `ToLocaleTime()` first.
For help diagnosing multi-threading issues, you might also log `e.OSThreadId` which is also available on those same targets.

## Distributed tracing

Azure SDKs are instrumented for distributed tracing using ApplicationsInsights or OpenTelemetry.

### ApplicationInsights with Azure Monitor

Application Insights, a feature of Azure Monitor, is an extensible Application Performance Management (APM) service for developers and DevOps professionals. Use it to monitor your live applications. It will automatically detect performance anomalies, and includes powerful analytics tools to help you diagnose issues and to understand what users actually do with your app

If you application already uses ApplicationInsights, automatic collection of Azure SDK traces is supported since version `2.12.0`. 

To setup ApplicationInsights tracking for your application follow the [Start Monitoring Application](https://docs.microsoft.com/azure/azure-monitor/learn/dotnetcore-quick-start) guide.

### OpenTelemetry with Azure Monitor, Zipkin and others

Follow the [OpenTelemetry configuration guide](https://github.com/open-telemetry/opentelemetry-dotnet#configuration-with-microsoftextensionsdependencyinjection) to configure collecting distribute tracing event collection using the OpenTelemetry library.

### Sample
To see an example of distributed tracing in action, take a look at our [sample app](https://github.com/Azure/azure-sdk-for-net/blob/master/samples/linecounter/README.md) that combines several Azure SDKs.

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
