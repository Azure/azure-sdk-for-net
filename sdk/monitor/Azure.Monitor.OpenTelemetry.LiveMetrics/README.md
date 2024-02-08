# Azure Monitor Live Metrics client library for .NET

The [OpenTelemetry .NET](https://github.com/open-telemetry/opentelemetry-dotnet) compatible processor which sends [telemetry data](https://docs.microsoft.com/azure/azure-monitor/app/data-model) to [Azure Monitor](https://docs.microsoft.com/azure/azure-monitor/app/app-insights-overview) [Live Metrics](https://learn.microsoft.com/azure/azure-monitor/app/live-stream).

## Getting started

### Prerequisites

- **Azure Subscription:**  To use Azure services, including Azure Monitor Exporter for [OpenTelemetry .NET](https://github.com/open-telemetry/opentelemetry-dotnet), you'll need a subscription.  If you do not have an existing Azure account, you may sign up for a [free trial](https://azure.microsoft.com/free/dotnet/) or use your [Visual Studio Subscription](https://visualstudio.microsoft.com/subscriptions/) benefits when you [create an account](https://azure.microsoft.com/account).
- **Azure Application Insights Connection String:** To send telemetry data to the monitoring service you'll need connection string from Azure Application Insights. If you are not familiar with creating Azure resources, you may wish to follow the step-by-step guide for [Create an Application Insights resource](https://docs.microsoft.com/azure/azure-monitor/app/create-new-resource) and [copy the connection string](https://docs.microsoft.com/azure/azure-monitor/app/sdk-connection-string?tabs=net#find-your-connection-string).

### Install the package

Install the Azure Monitor Live Metrics client for OpenTelemetry .NET with [NuGet](https://www.nuget.org/):
```dotnetcli
dotnet add package Azure.Monitor.OpenTelemetry.LiveMetrics --prerelease
```

#### Nightly builds

Nightly builds are available from this repo's [dev feed](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md#nuget-package-dev-feed).
These are provided without support and are not intended for production workloads.

### Add the Live Metrics client

The following examples demonstrate how to add the Live Metrics client to your OpenTelemetry configuration.

```csharp
Sdk.CreateTracerProviderBuilder()
    .AddLiveMetrics(o => o.ConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000")
    .Build();
```

For a complete example see [`Program.cs`](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/monitor/Azure.Monitor.OpenTelemetry.LiveMetrics/tests/Azure.Monitor.OpenTelemetry.LiveMetrics.Demo/Program.cs)

### Authenticate the client

Not available in beta.

## Key concepts

- [Live Metrics: Monitor and diagnose with 1-second latency](https://learn.microsoft.com/azure/azure-monitor/app/live-stream)

## Examples

Refer to [`Program.cs`](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/monitor/Azure.Monitor.OpenTelemetry.LiveMetrics/tests/Azure.Monitor.OpenTelemetry.LiveMetrics.Demo/Program.cs) for a complete demo.

## Troubleshooting

The Live Metrics client uses EventSource for its own internal logging. The logs are available to any EventListener by opting into the source named "OpenTelemetry-AzureMonitor-LiveMetrics".

OpenTelemetry also provides it's own [self-diagnostics feature](https://github.com/open-telemetry/opentelemetry-dotnet/blob/main/src/OpenTelemetry/README.md#troubleshooting) to collect internal logs.

## Next steps

For more information on Azure SDK, please refer to [this website](https://azure.github.io/azure-sdk/)

## Contributing

See [CONTRIBUTING.md](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md) for details on contribution process.

## Release Schedule

This exporter is under active development.

The library is not yet _generally available_, and is not officially supported. Future releases will not attempt to maintain backwards compatibility with previous releases. Each beta release includes significant changes to the exporter package, making them incompatible with each other.
