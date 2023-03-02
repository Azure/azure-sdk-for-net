# Azure Monitor Distro client library for .NET

The Azure Monitor Distro is a client library that sends telemetry data to Azure Monitor following the OpenTelemetry Specification. This library can be used to instrument your .NET applications to collect and send telemetry data to Azure Monitor for analysis and monitoring.

## Getting started

### Prerequisites

- **Azure Subscription:**  To use Azure services, including Azure Monitor Exporter for [OpenTelemetry .NET](https://github.com/open-telemetry/opentelemetry-dotnet), you'll need a subscription.  If you do not have an existing Azure account, you may sign up for a [free trial](https://azure.microsoft.com/free/dotnet/) or use your [Visual Studio Subscription](https://visualstudio.microsoft.com/subscriptions/) benefits when you [create an account](https://azure.microsoft.com/account).
- **Azure Application Insights Connection String:** To send telemetry data to the monitoring service you'll need connection string from Azure Application Insights. If you are not familiar with creating Azure resources, you may wish to follow the step-by-step guide for [Create an Application Insights resource](https://docs.microsoft.com/azure/azure-monitor/app/create-new-resource) and [copy the connection string](https://docs.microsoft.com/azure/azure-monitor/app/sdk-connection-string?tabs=net#find-your-connection-string).

### Install the package

Install the Azure Monitor Distro for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Monitor.OpenTelemetry.AspNetCore --prerelease
```

### Authenticate the client

To authenticate the client using Azure Active Directory (AAD), you'll need to set the Credential property in AzureMonitorOpenTelemetryOptions. This is made easy with the [Azure Identity library][identity], which provides support for authenticating Azure SDK clients with their corresponding Azure services.

```C#
// Call AddAzureMonitorOpenTelemetry and set Credential to authenticate through Active Directory.
builder.Services.AddAzureMonitorOpenTelemetry(o =>
{
    o.ConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000";
    o.Credential = new DefaultAzureCredential();
});
```

With this configuration, the Azure Monitor Distro will use the credentials of the currently logged-in user or of the service principal to authenticate and send telemetry data to Azure Monitor.

## Key concepts

The Azure Monitor Distro uses instrumentation libraries from the .NET OpenTelemetry SDK to provide a convenient and easy way to export telemetry data to Azure Monitor.

## Examples

Refer to [`Program.cs`](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/monitor/Azure.Monitor.OpenTelemetry/tests/Azure.Monitor.OpenTelemetry.Demo/Program.cs) for a complete demo.

## Troubleshooting

The Azure Monitor Distro uses EventSource for its own internal logging. The exporter logs are available to any EventListener by opting into the source named "OpenTelemetry-AzureMonitor-Exporter".

OpenTelemetry also provides it's own [self-diagnostics feature](https://github.com/open-telemetry/opentelemetry-dotnet/blob/main/src/OpenTelemetry/README.md#troubleshooting) to collect internal logs.
An example of this is available in our demo project [here](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/monitor/Azure.Monitor.OpenTelemetry.Exporter/tests/Azure.Monitor.OpenTelemetry.Exporter.Demo/OTEL_DIAGNOSTICS.json).


## Next steps

For more information on Azure SDK, please refer to [this website](https://azure.github.io/azure-sdk/)

## Contributing

See [CONTRIBUTING.md](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md) for details on contribution process.

## Release Schedule

This distro is under active development.

The library is not yet _generally available_, and is not officially supported. Future releases will not attempt to maintain backwards compatibility with previous releases. Each beta release includes significant changes to the distro package, making them incompatible with each other.
