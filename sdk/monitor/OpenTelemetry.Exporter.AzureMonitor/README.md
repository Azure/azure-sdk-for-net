# Azure Monitor Exporter client library for .NET

The [OpenTelemetry .NET](https://github.com/open-telemetry/opentelemetry-dotnet) exporters which send [telemetry data](https://docs.microsoft.com/en-us/azure/azure-monitor/app/data-model) to the [Azure Monitor Platform](https://docs.microsoft.com/en-us/azure/azure-monitor/app/app-insights-overview) following the [OpenTelemetry Specification](https://github.com/open-telemetry/opentelemetry-specification).

## Getting started

### Prerequisites

- **Azure Subscription:**  To use Azure services, including Azure Monitor Exporter for [OpenTelemetry .NET](https://github.com/open-telemetry/opentelemetry-dotnet), you'll need a subscription.  If you do not have an existing Azure account, you may sign up for a [free trial](https://azure.microsoft.com/free) or use your [Visual Studio Subscription](https://visualstudio.microsoft.com/subscriptions/) benefits when you [create an account](https://account.windowsazure.com/Home/Index).
- **Azure Application Insights Connection String:** To send telemetry data to the monitoring service you'll need connection string from Azure Application Insights. If you are not familiar with creating Azure resources, you may wish to follow the step-by-step guide for [Create an Application Insights resource](https://docs.microsoft.com/en-us/azure/azure-monitor/app/create-new-resource) and [copy the connection string](https://docs.microsoft.com/en-us/azure/azure-monitor/app/sdk-connection-string?tabs=net#finding-my-connection-string).

### Install the package

Install the Azure Monitor Exporter for OpenTelemetry .NET with NuGet:

```shell
dotnet add package OpenTelemetry.Exporter.AzureMonitor
```

### Authenticate the client

For the exporter to send data to Azure Monitor use a connection string, which is created automatically when creating an Application Insights resource.

## Key concepts

This exporter sends traces to the configured Azure Monitor Resource using HTTP. IP address used by the Azure Monitor is documented in [IP addresses used by Application Insights and Log Analytics](https://docs.microsoft.com/en-us/azure/azure-monitor/app/ip-addresses#outgoing-ports).

## Examples

Refer to [`DemoTrace.cs`](tests/OpenTelemetry.Exporter.AzureMonitor.Demo.Tracing/DemoTrace.cs) for a complete demo.

```csharp
OpenTelemetry.Sdk.CreateTracerProviderBuilder()
    .SetResource(resource)
    .AddSource("Samples.SampleClient")
    .AddAzureMonitorTraceExporter(o => {
        o.ConnectionString = $"InstrumentationKey=Ikey;";
    })
    .Build();
```

## Troubleshooting

This exporter is fully instrumented for logging information at various levels of detail using the .NET EventSource to emit information. Logging is performed for each operation and follows the pattern of marking the starting point of the operation, it's completion, and any exceptions encountered. Additional information that may offer insight is also logged in the context of the associated operation.

The exporter logs are available to any EventListener by opting into the source named "OpenTelemetry-TraceExporter-AzureMonitor".

## Next steps

For more information on Azure SDK, please refer to [this website](https://azure.github.io/azure-sdk/)

## Contributing

See [CONTRIBUTING.md](https://github.com/Azure/azure-sdk-for-net/blob/master/CONTRIBUTING.md) for details on contribution process.