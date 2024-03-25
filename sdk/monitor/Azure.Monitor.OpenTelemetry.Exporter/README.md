# Azure Monitor Exporter client library for .NET



The [OpenTelemetry .NET](https://github.com/open-telemetry/opentelemetry-dotnet) exporters which send [telemetry data](https://docs.microsoft.com/azure/azure-monitor/app/data-model) to [Azure Monitor](https://docs.microsoft.com/azure/azure-monitor/app/app-insights-overview) following the [OpenTelemetry Specification](https://github.com/open-telemetry/opentelemetry-specification).

## Getting started

### Prerequisites

- **Azure Subscription:**  To use Azure services, including Azure Monitor Exporter for [OpenTelemetry .NET](https://github.com/open-telemetry/opentelemetry-dotnet), you'll need a subscription.  If you do not have an existing Azure account, you may sign up for a [free trial](https://azure.microsoft.com/free/dotnet/) or use your [Visual Studio Subscription](https://visualstudio.microsoft.com/subscriptions/) benefits when you [create an account](https://azure.microsoft.com/account).
- **Azure Application Insights Connection String:** To send telemetry data to the monitoring service you'll need connection string from Azure Application Insights. If you are not familiar with creating Azure resources, you may wish to follow the step-by-step guide for [Create an Application Insights resource](https://docs.microsoft.com/azure/azure-monitor/app/create-new-resource) and [copy the connection string](https://docs.microsoft.com/azure/azure-monitor/app/sdk-connection-string?tabs=net#find-your-connection-string).

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

## Troubleshooting

The Azure Monitor exporter uses EventSource for its own internal logging. The exporter logs are available to any EventListener by opting into the source named "OpenTelemetry-AzureMonitor-Exporter".

OpenTelemetry also provides it's own [self-diagnostics feature](https://github.com/open-telemetry/opentelemetry-dotnet/blob/main/src/OpenTelemetry/README.md#troubleshooting) to collect internal logs.
An example of this is available in our demo project [here](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/monitor/Azure.Monitor.OpenTelemetry.Exporter/tests/Azure.Monitor.OpenTelemetry.Exporter.Demo/OTEL_DIAGNOSTICS.json).

## Next steps

For more information on Azure SDK, please refer to [this website](https://azure.github.io/azure-sdk/)

## Contributing

See [CONTRIBUTING.md](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md) for details on contribution process.
