# Azure Monitor Distro client library for .NET

The Azure Monitor Distro is a client library that sends telemetry data to Azure Monitor following the OpenTelemetry Specification. This library can be used to instrument your ASP.NET Core applications to collect and send telemetry data to Azure Monitor for analysis and monitoring, powering experiences in Application Insights.

## Getting started

### Prerequisites

- **Azure Subscription:**  To use Azure services, including Azure Monitor Distro, you'll need a subscription.  If you do not have an existing Azure account, you may sign up for a [free trial](https://azure.microsoft.com/free/dotnet/) or use your [Visual Studio Subscription](https://visualstudio.microsoft.com/subscriptions/) benefits when you [create an account](https://azure.microsoft.com/account).
- **Azure Application Insights Connection String:** To send telemetry data to the monitoring service you'll need connection string from Azure Application Insights. If you are not familiar with creating Azure resources, you may wish to follow the step-by-step guide for [Create an Application Insights resource](https://docs.microsoft.com/azure/azure-monitor/app/create-new-resource) and [copy the connection string](https://docs.microsoft.com/azure/azure-monitor/app/sdk-connection-string?tabs=net#find-your-connection-string).
- **ASP.NET Core App:** An ASP.NET Core application is required to instrument it with Azure Monitor Distro. You can either bring your own app or follow the [Get started with ASP.NET Core MVC](https://docs.microsoft.com/aspnet/core/tutorials/first-mvc-app/start-mvc) to create a new one.

### Install the package

Install the Azure Monitor Distro for .NET from [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Monitor.OpenTelemetry --prerelease
```

#### Nightly builds

Nightly builds are available from this repo's [dev feed](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md#nuget-package-dev-feed).
These are provided without support and are not intended for production workloads.

### Enabling Azure Monitor OpenTelemetry in your application

The following examples demonstrate how to integrate the Azure Monitor OpenTelemetry Distro into your application.

#### Example 1

To enable Azure Monitor OpenTelemetry Distro, add `AddAzureMonitor()` to your `Program.cs` file and set the `APPLICATIONINSIGHTS_CONNECTION_STRING` environment variable to the connection string from your Application Insights resource.

```C#
// This method gets called by the runtime. Use this method to add services to the container.
var builder = WebApplication.CreateBuilder(args);

// The following line enables Azure Monitor OpenTelemetry Distro.
builder.Services.AddAzureMonitor();

// This code adds other services for your application.
builder.Services.AddMvc();

var app = builder.Build();
```

#### Example 2

To enable Azure Monitor OpenTelemetry Distro with a hard-coded connection string, add `AddAzureMonitor()` to your `Program.cs` with the `AzureMonitorOptions` containing the connection string.

```C#
// This method gets called by the runtime. Use this method to add services to the container.
var builder = WebApplication.CreateBuilder(args);

// The following line enables Azure Monitor OpenTelemetry Distro with hard-coded connection string.
builder.Services.AddAzureMonitor(o => o.ConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000");

// This code adds other services for your application.
builder.Services.AddMvc();

var app = builder.Build();
```

Note that in the examples above, `AddAzureMonitor` is added to the `IServiceCollection` in the `Program.cs` file. You can also add it in the `ConfigureServices` method of your `Startup.cs` file.

### Authenticate the client

Azure Active Directory (AAD) authentication is an optional feature that can be used with Application Insights. To enable AAD authentication, set the `Credential` property in `AzureMonitorOptions`. This is made easy with the [Azure Identity library][identity], which provides support for authenticating Azure SDK clients with their corresponding Azure services.

```C#
// Call AddAzureMonitor and set Credential to authenticate through Active Directory.
builder.Services.AddAzureMonitor(o =>
{
    o.ConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000";
    o.Credential = new DefaultAzureCredential();
});
```

With this configuration, the Azure Monitor Distro will use the credentials of the currently logged-in user or of the service principal to authenticate and send telemetry data to Azure Monitor.

Note that the `Credential` property is optional. If it is not set, Azure Monitor OpenTelemetry Distro will use the Instrumentation Key from the Connection String to send data to Application Insights resource.

## Key concepts

The Azure Monitor Distro uses instrumentation libraries from the .NET OpenTelemetry SDK to provide a convenient and easy way to export telemetry data to Azure Monitor.

## Examples

Refer to [`Program.cs`](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/monitor/Azure.Monitor.OpenTelemetry/tests/Azure.Monitor.OpenTelemetry.Demo/Program.cs) for a complete demo.

## Troubleshooting

The Azure Monitor Distro uses EventSource for its own internal logging. The logs are available to any EventListener by opting into the source named "OpenTelemetry-AzureMonitor-Exporter".

OpenTelemetry also provides it's own [self-diagnostics feature](https://github.com/open-telemetry/opentelemetry-dotnet/blob/main/src/OpenTelemetry/README.md#troubleshooting) to collect internal logs.
An example of this is available in our demo project [here](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/monitor/Azure.Monitor.OpenTelemetry.Exporter/tests/Azure.Monitor.OpenTelemetry.Exporter.Demo/OTEL_DIAGNOSTICS.json).


## Next steps

For more information on Azure SDK, please refer to [this website](https://azure.github.io/azure-sdk/)

## Contributing

See [CONTRIBUTING.md](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md) for details on contribution process.

## Release Schedule

This distro is under active development.

The library is not yet _generally available_, and is not officially supported. Future releases will not attempt to maintain backwards compatibility with previous releases. Each beta release includes significant changes to the distro package, making them incompatible with each other.
