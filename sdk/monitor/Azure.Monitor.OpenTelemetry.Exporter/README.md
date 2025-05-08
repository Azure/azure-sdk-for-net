# Azure Monitor Exporter client library for .NET

The [OpenTelemetry .NET](https://github.com/open-telemetry/opentelemetry-dotnet) exporters which send [telemetry data](https://learn.microsoft.com/azure/azure-monitor/app/data-model) to [Azure Monitor](https://learn.microsoft.com/azure/azure-monitor/app/app-insights-overview) following the [OpenTelemetry Specification](https://github.com/open-telemetry/opentelemetry-specification).

## Getting started

### Prerequisites

- **Azure Subscription:**  To use Azure services, including Azure Monitor Exporter for [OpenTelemetry .NET](https://github.com/open-telemetry/opentelemetry-dotnet), you'll need a subscription.  If you do not have an existing Azure account, you may sign up for a [free trial](https://azure.microsoft.com/free/dotnet/) or use your [Visual Studio Subscription](https://visualstudio.microsoft.com/subscriptions/) benefits when you [create an account](https://azure.microsoft.com/account).
- **Azure Application Insights Connection String:** To send telemetry data to the monitoring service you'll need connection string from Azure Application Insights. If you are not familiar with creating Azure resources, you may wish to follow the step-by-step guide for [Create an Application Insights resource](https://learn.microsoft.com/azure/azure-monitor/app/create-new-resource) and [copy the connection string](https://learn.microsoft.com/azure/azure-monitor/app/sdk-connection-string?tabs=net#find-your-connection-string).

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

### Add the Exporter (per signal)

The following examples demonstrate how to add the `AzureMonitorExporter` to your OpenTelemetry configuration.

It's important to keep the `TracerProvider`, `MeterProvider`, and `LoggerFactory` instances active throughout the process lifetime. These must be properly disposed when your application is shutting down to flush any remaining telemetry items.

- Traces
    ```csharp
    var tracerProvider = Sdk.CreateTracerProviderBuilder()
        .AddAzureMonitorTraceExporter(options => options.ConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000")
        .Build();
    ```

  For a complete example see [TraceDemo.cs](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/monitor/Azure.Monitor.OpenTelemetry.Exporter/tests/Azure.Monitor.OpenTelemetry.Exporter.Demo/Traces/TraceDemo.cs).

- Metrics
    ```csharp
    var meterProvider = Sdk.CreateMeterProviderBuilder()
        .AddAzureMonitorMetricExporter(options => options.ConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000")
        .Build();
    ```

  For a complete example see [MetricDemo.cs](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/monitor/Azure.Monitor.OpenTelemetry.Exporter/tests/Azure.Monitor.OpenTelemetry.Exporter.Demo/Metrics/MetricDemo.cs).

- Logs
    ```csharp
    var loggerFactory = LoggerFactory.Create(builder =>
    {
        builder.AddOpenTelemetry(logging =>
        {
            logging.AddAzureMonitorLogExporter(options => options.ConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000");
        });
    });
    ```

  For a complete example see [LogDemo.cs](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/monitor/Azure.Monitor.OpenTelemetry.Exporter/tests/Azure.Monitor.OpenTelemetry.Exporter.Demo/Logs/LogDemo.cs).

### Add the Exporter for all signals

Starting with the `1.4.0-beta.3` version you can use the cross-cutting `UseAzureMonitorExporter` extension to simplify registration of the OTLP exporter for all signals (traces, metrics, and logs).

> [!NOTE]
> The cross cutting extension is currently only available when using the `AddOpenTelemetry` extension in the
  [OpenTelemetry.Extensions.Hosting](https://www.nuget.org/packages/OpenTelemetry.Extensions.Hosting) package.

The following example demonstrates how to add the `AzureMonitorExporter` to your OpenTelemetry configuration by using a single API.
To use this API, you need to add OpenTelemetry to a `ServiceCollection`.
This approach will also enable LiveMetrics.
LiveMetrics can be disabled by setting `options.EnableLiveMetrics = false`.

```csharp
appBuilder.Services.AddOpenTelemetry()
    .UseAzureMonitorExporter(options => {
        options.ConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000";
    });
```

### Authenticate the client

Azure Active Directory (AAD) authentication is an optional feature that can be used with the Azure Monitor Exporter.
This is made easy with the [Azure Identity library](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity/README.md), which provides support for authenticating Azure SDK clients with their corresponding Azure services.

There are two options to enable AAD authentication. Note that if both have been set AzureMonitorExporterOptions will take precedence.

1. Set your `Credential` to the `AzureMonitorExporterOptions`.

    ```csharp
    var credential = new DefaultAzureCredential();

    var tracerProvider = Sdk.CreateTracerProviderBuilder()
        .AddAzureMonitorTraceExporter(options =>
        {
            options.ConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000";
            options.Credential = credential;
        })
        .Build();
    ```

2. Provide your `Credential` to the AddAzureMonitorExporter method.

    ```csharp
    var credential = new DefaultAzureCredential();

    var tracerProvider = Sdk.CreateTracerProviderBuilder()
        .AddAzureMonitorTraceExporter(options => options.ConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000", credential)
        .Build();
    ```

## Key concepts

Some key concepts for .NET include:

- [Overview of .NET distributed tracing](https://learn.microsoft.com/dotnet/core/diagnostics/distributed-tracing):
  Distributed tracing is a diagnostic technique that helps engineers localize failures and performance issues within applications, especially those that may be distributed across multiple machines or processes.

- [Overview of Logging in .NET](https://learn.microsoft.com/dotnet/core/extensions/logging):
  .NET supports a logging API that works with a variety of built-in and third-party logging providers.

Some key concepts for Azure Monitor include:

- [IP Addresses used by Azure Monitor](https://learn.microsoft.com/azure/azure-monitor/app/ip-addresses#outgoing-ports):
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
    builder.AddOpenTelemetry(logging =>
    {
        logging.AddAzureMonitorLogExporter(options => options.ConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000");
        logging.IncludeScopes = true;
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

### CustomEvents

Azure Monitor relies on OpenTelemetry's Log Signal to create CustomEvents.
For .NET, users will use ILogger and place an attribute named `"microsoft.custom_event.name"` in the message template.
Severity and CategoryName are not recorded in the CustomEvent.

#### via ILogger.Log methods

To send a CustomEvent via ILogger, include the `"microsoft.custom_event.name"` attribute in the message template.

Note: This example shows `LogInformation`, but any Log method can be used.
Severity is not recorded, but depending on your configuration it may be filtered out.
Users should take care to select a severity for CustomEvents that is not filtered out by their configuration.

```csharp
var loggerFactory = LoggerFactory.Create(builder =>
{
    builder.AddOpenTelemetry(logging =>
    {
        logging.AddAzureMonitorLogExporter();
    });
});

var logger = loggerFactory.CreateLogger(logCategoryName);
logger.LogInformation("{microsoft.custom_event.name} {key1} {key2}", "MyCustomEventName", "value1", "value2");
```

This example generates a CustomEvent structured like this:

```json
{
    "name": "Event",
    "data": {
        "baseType": "EventData",
        "baseData": {
            "name": "MyCustomEventName",
            "properties": {
                "key1": "value1",
                "key2": "value2"
            }
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

## AOT (Ahead-of-Time) Support

This library supports usage in .NET applications compiled with [AOT (Ahead-of-Time) compilation](https://learn.microsoft.com/dotnet/core/deploying/native-aot/).
All core features of the Azure Monitor Exporter are compatible with AOT, including telemetry export for traces, metrics, and logs.

**Important:**  
While AOT is supported, automatic configuration binding from `appsettings.json` or other `IConfiguration` sources is **not** supported in AOT-compiled applications.
This is due to .NET limitations on reflection-based binding APIs (such as `ConfigurationBinder.Bind` and `Get<T>()`) in AOT scenarios.  
  
**Workaround:**  
In AOT scenarios, you can configure the Azure Monitor Exporter using one of the following approaches:

- **Environment Variable:** Set the `APPLICATIONINSIGHTS_CONNECTION_STRING` environment variable to configure the connection string.

- **Programmatic Configuration:** Set the `AzureMonitorExporterOptions` directly in your application code:
    ```csharp
    builder.Services.AddOpenTelemetry()
        .UseAzureMonitorExporter(options =>
        {
            options.ConnectionString = "<your-connection-string>";
            // Set other options as needed
        });
    ```
