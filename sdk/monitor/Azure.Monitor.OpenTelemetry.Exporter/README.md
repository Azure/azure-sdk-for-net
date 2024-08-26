# Azure Monitor Exporter client library for .NET

The [OpenTelemetry .NET](https://github.com/open-telemetry/opentelemetry-dotnet) exporters which send [telemetry data](https://docs.microsoft.com/azure/azure-monitor/app/data-model) to [Azure Monitor](https://docs.microsoft.com/azure/azure-monitor/app/app-insights-overview) following the [OpenTelemetry Specification](https://github.com/open-telemetry/opentelemetry-specification).

## Getting started

### Prerequisites

- **Azure Subscription:**  To use Azure services, including Azure Monitor Exporter for [OpenTelemetry .NET](https://github.com/open-telemetry/opentelemetry-dotnet), you'll need a subscription.  If you do not have an existing Azure account, you may sign up for a [free trial](https://azure.microsoft.com/free/dotnet/) or use your [Visual Studio Subscription](https://visualstudio.microsoft.com/subscriptions/) benefits when you [create an account](https://azure.microsoft.com/account).
- **Azure Application Insights Connection String:** To send telemetry data to the monitoring service you'll need connection string from Azure Application Insights. If you are not familiar with creating Azure resources, you may wish to follow the step-by-step guide for [Create an Application Insights resource](https://docs.microsoft.com/azure/azure-monitor/app/create-new-resource) and [copy the connection string](https://docs.microsoft.com/azure/azure-monitor/app/sdk-connection-string?tabs=net#find-your-connection-string).

### Migrating from Application Insights SDK

If you are currently using the Application Insights SDK and want to migrate to OpenTelemetry, please follow our [migration guide](https://learn.microsoft.com/azure/azure-monitor/app/opentelemetry-dotnet-migrate?tabs=console). 

### Already using OpenTelemetry?

If you are currently using OpenTelemetry and want to send telemetry data to Azure Monitor, please follow our [getting started guide](https://learn.microsoft.com/azure/azure-monitor/app/opentelemetry-enable?tabs=net).

### Install the package

#### Latest Version: [![Nuget](https://img.shields.io/nuget/vpre/Azure.Monitor.OpenTelemetry.Exporter.svg)](https://www.nuget.org/packages/Azure.Monitor.OpenTelemetry.Exporter/)  

Install the Azure Monitor Exporter for OpenTelemetry .NET with [NuGet](https://www.nuget.org/):
```dotnetcli
dotnet add package Azure.Monitor.OpenTelemetry.Exporter
```

#### Nightly builds

Nightly builds are available from this repo's [dev feed](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md#nuget-package-dev-feed).
These are provided without support and are not intended for production workloads.

### Add the Exporter

The following examples demonstrate how to add the `AzureMonitorExporter` to your OpenTelemetry configuration.

- Traces
    ```csharp
    Sdk.CreateTracerProviderBuilder()
        .AddAzureMonitorTraceExporter(o => o.ConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000")
        .Build();
    ```

  For a complete example see [TraceDemo.cs](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/monitor/Azure.Monitor.OpenTelemetry.Exporter/tests/Azure.Monitor.OpenTelemetry.Exporter.Demo/Traces/TraceDemo.cs).

- Metrics
    ```csharp
    Sdk.CreateMeterProviderBuilder()
        .AddAzureMonitorMetricExporter(o => o.ConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000")
        .Build();
    ```

  For a complete example see [MetricDemo.cs](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/monitor/Azure.Monitor.OpenTelemetry.Exporter/tests/Azure.Monitor.OpenTelemetry.Exporter.Demo/Metrics/MetricDemo.cs).

- Logs
    ```csharp
    LoggerFactory.Create(builder =>
    {
        builder.AddOpenTelemetry(options =>
        {
            options.AddAzureMonitorLogExporter(o => o.ConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000");
        });
    });
    ```

  For a complete example see [LogDemo.cs](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/monitor/Azure.Monitor.OpenTelemetry.Exporter/tests/Azure.Monitor.OpenTelemetry.Exporter.Demo/Logs/LogDemo.cs).

### Authenticate the client

Azure Active Directory (AAD) authentication is an optional feature that can be used with the Azure Monitor Exporter.
This is made easy with the [Azure Identity library](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity/README.md), which provides support for authenticating Azure SDK clients with their corresponding Azure services.

There are two options to enable AAD authentication. Note that if both have been set AzureMonitorExporterOptions will take precedence.

1. Set your `Credential` to the `AzureMonitorExporterOptions`.

    ```csharp
    var credential = new DefaultAzureCredential();

    Sdk.CreateTracerProviderBuilder()
        .AddAzureMonitorTraceExporter(o =>
        {
            o.ConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000";
            o.Credential = credential;
        })
        .Build();
    ```

2. Provide your `Credential` to the AddAzureMonitorExporter method.

    ```csharp
    var credential = new DefaultAzureCredential();

    Sdk.CreateTracerProviderBuilder()
        .AddAzureMonitorTraceExporter(o => o.ConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000", credential)
        .Build();
    ```

## Key concepts

Some key concepts for .NET include:

- [Overview of .NET distributed tracing](https://learn.microsoft.com/dotnet/core/diagnostics/distributed-tracing): 
  Distributed tracing is a diagnostic technique that helps engineers localize failures and performance issues within applications, especially those that may be distributed across multiple machines or processes. 

- [Overview of Logging in .NET](https://learn.microsoft.com/dotnet/core/extensions/logging): 
  .NET supports a logging API that works with a variety of built-in and third-party logging providers.

Some key concepts for Azure Monitor include:

- [IP Addresses used by Azure Monitor](https://docs.microsoft.com/azure/azure-monitor/app/ip-addresses#outgoing-ports):
  This exporter sends traces to the configured Azure Monitor Resource using HTTPS.
  You might need to know IP addresses if the app or infrastructure that you're monitoring is hosted behind a firewall.

Some key concepts for OpenTelemetry include:

- [OpenTelemetry](https://opentelemetry.io/):
  OpenTelemetry is a set of libraries used to collect and export telemetry data
  (metrics, logs, and traces) for analysis in order to understand your software's performance and behavior.

- [Instrumentation](https://github.com/open-telemetry/opentelemetry-specification/blob/master/specification/overview.md#instrumentation-libraries):
  The ability to call the OpenTelemetry API directly by any application is
  facilitated by instrumentation. A library that enables OpenTelemetry observability for another library is called an Instrumentation Library.

- [Tracing Signal](https://github.com/open-telemetry/opentelemetry-specification/blob/main/specification/overview.md#tracing-signal): 
  Trace refers to distributed tracing. It can be thought of as a directed acyclic graph (DAG) of Spans, where the edges between Spans are defined as parent/child relationship.

- [Sampling](https://github.com/open-telemetry/opentelemetry-specification/blob/master/specification/trace/sdk.md#sampling): 
  Sampling is a mechanism to control the noise and overhead introduced by OpenTelemetry by reducing the number of samples of traces collected and sent to the backend.

- [Metric Signal](https://github.com/open-telemetry/opentelemetry-specification/blob/main/specification/overview.md#metric-signal):
  OpenTelemetry allows to record raw measurements or metrics with predefined aggregation and a set of attributes (dimensions).

- [Log Signal](https://github.com/open-telemetry/opentelemetry-specification/blob/main/specification/overview.md#log-signal):
  A recording of an event. Typically the record includes a timestamp indicating when the event happened as well as other data that describes what happened, where it happened, etc.

For more information on the OpenTelemetry project, please review the [OpenTelemetry Specifications](https://github.com/open-telemetry/opentelemetry-specification).

## Examples

Refer to [`Program.cs`](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/monitor/Azure.Monitor.OpenTelemetry.Exporter/tests/Azure.Monitor.OpenTelemetry.Exporter.Demo/Program.cs) for a complete demo.

### Log Scopes

Log [scopes](https://learn.microsoft.com/dotnet/core/extensions/logging#log-scopes) allow you to add additional properties to the logs generated by your application.
Although the Azure Monitor Exporter does support scopes, this feature is off by default in OpenTelemetry.
To leverage log scopes, you must explicitly enable them.

To include the scope with your logs, set `OpenTelemetryLoggerOptions.IncludeScopes` to `true` in your application's configuration:
```csharp
var loggerFactory = LoggerFactory.Create(builder =>
{
    builder.AddOpenTelemetry(options =>
    {
        options.AddAzureMonitorLogExporter(o => o.ConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000");
        options.IncludeScopes = true;
    });
});
```

When using `ILogger` scopes, use a `List<KeyValuePair<string, object?>>` or `IReadOnlyList<KeyValue<string, object?>>` as the state for best performance.
All logs written within the context of the scope will include the specified information.
Azure Monitor will add these scope values to the Log's CustomProperties.
```csharp
List<KeyValuePair<string, object?>> scope =
[
    new("scopeKey", "scopeValue")
];

using (logger.BeginScope(scope))
{
    logger.LogInformation("Example message.");
}
```

In scenarios involving multiple scopes or a single scope with multiple key-value pairs, if duplicate keys are present,
only the first occurrence of the key-value pair from the outermost scope will be recorded.
However, when the same key is utilized both within a logging scope and directly in the log statement, the value specified in the log message template will take precedence.

### Application Insights Custom Events

In general, you should be able to use
[ILogger](https://learn.microsoft.com/dotnet/api/microsoft.extensions.logging.ilogger)
for your logging needs. For users looking to log [Application Insights Custom
Events](https://learn.microsoft.com/azure/azure-monitor/app/api-custom-events-metrics#trackevent),
this can be accomplished by utilizing the `TrackEvent(string name,
IReadOnlyList<KeyValuePair<string, object?>>? attributes = null)` API provided
in the exporter.

To begin, you need to pass an instance of the
[LoggerFactory](https://learn.microsoft.com/dotnet/api/microsoft.extensions.logging.loggerfactory)
class to create an instance of `ApplicationInsightsEventLogger`. This instance
can then be used to invoke the `TrackEvent` method for logging custom events.
Below is an example of how you can implement this:

```csharp
// Example code to log custom events in Application Insights
var loggerFactory = LoggerFactory.Create(builder =>
{
    builder.AddOpenTelemetry(options =>
    {
        options.AddAzureMonitorLogExporter(o => o.ConnectionString =  "InstrumentationKey=00000000-0000-0000-0000-000000000000", credential);
    });
});

var eventLogger = new ApplicationInsightsEventLogger(loggerFactory.CreateLogger<ApplicationInsightsEventLogger>());

// Logging a custom event
eventLogger.TrackEvent("CustomEventName", new List<KeyValuePair<string, object?>>
{
    new KeyValuePair<string, object?>("Key1", "Value1"),
    new KeyValuePair<string, object?>("Key2", 12345)
});
```

> **Note**
  > LoggerFactory instance passed in to the ApplicationInsightsEventLogger must be the same one that is used to configure OpenTelemetry.

`TrackEvent` internally calls the `ILogger.Log` API with the LogLevel set to
`Information`. If you want to disable the collection of custom events, you can
do so by adding a filter in code or via `appsettings.json`, as shown below.

`In code`

```csharp
this.loggerFactory = LoggerFactory.Create(builder =>
{
    // Disable custom event collection.
    builder.AddFilter<OpenTelemetryLoggerProvider>("Azure.Monitor.OpenTelemetry.CustomEvents", LogLevel.None);
    builder.AddOpenTelemetry(options =>
    {
        options.AddAzureMonitorLogExporter(o => o.ConnectionString = connectionString, credential);
    });
});
```

`appsettings.json`

```json
"Logging": {
    "OpenTelemetry": {
        "LogLevel": {
            "Azure.Monitor.OpenTelemetry.CustomEvents": "None"
        }
    }
}
```

## Troubleshooting

The Azure Monitor exporter uses EventSource for its own internal logging. The exporter logs are available to any EventListener by opting into the source named "OpenTelemetry-AzureMonitor-Exporter".

OpenTelemetry also provides it's own [self-diagnostics feature](https://github.com/open-telemetry/opentelemetry-dotnet/blob/main/src/OpenTelemetry/README.md#troubleshooting) to collect internal logs.
An example of this is available in our demo project [here](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/monitor/Azure.Monitor.OpenTelemetry.Exporter/tests/Azure.Monitor.OpenTelemetry.Exporter.Demo/OTEL_DIAGNOSTICS.json).

## Next steps

For more information on Azure SDK, please refer to [this website](https://azure.github.io/azure-sdk/)

## Contributing

See [CONTRIBUTING.md](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md) for details on contribution process.
