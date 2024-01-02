# Azure Monitor Distro client library for .NET

The Azure Monitor Distro is a client library that sends telemetry data to Azure Monitor following the OpenTelemetry Specification. This library can be used to instrument your ASP.NET Core applications to collect and send telemetry data to Azure Monitor for analysis and monitoring, powering experiences in Application Insights.

## Getting started

### Prerequisites

- **Azure Subscription:**  To use Azure services, including Azure Monitor Distro, you'll need a subscription.  If you do not have an existing Azure account, you may sign up for a [free trial](https://azure.microsoft.com/free/dotnet/) or use your [Visual Studio Subscription](https://visualstudio.microsoft.com/subscriptions/) benefits when you [create an account](https://azure.microsoft.com/account).
- **Azure Application Insights Connection String:** To send telemetry data to the monitoring service you'll need connection string from Azure Application Insights. If you are not familiar with creating Azure resources, you may wish to follow the step-by-step guide for [Create an Application Insights resource](https://docs.microsoft.com/azure/azure-monitor/app/create-new-resource) and [copy the connection string](https://docs.microsoft.com/azure/azure-monitor/app/sdk-connection-string?tabs=net#find-your-connection-string).
- **ASP.NET Core App:** An ASP.NET Core application is required to instrument it with Azure Monitor Distro. You can either bring your own app or follow the [Get started with ASP.NET Core MVC](https://docs.microsoft.com/aspnet/core/tutorials/first-mvc-app/start-mvc) to create a new one.

### What is Included in the Distro

The Azure Monitor Distro is a distribution of the .NET OpenTelemetry SDK with internally vendored instrumentation libraries, including:

* Traces
  * **ASP.NET Core Instrumentation**: Provides automatic tracing for incoming HTTP requests to ASP.NET Core applications.
  * **HTTP Client Instrumentation**: Provides automatic tracing for outgoing HTTP requests made using [System.Net.Http.HttpClient](https://docs.microsoft.com/dotnet/api/system.net.http.httpclient).
  * **SQL Client Instrumentation** Provides automatic tracing for SQL queries executed using the [Microsoft.Data.SqlClient](https://www.nuget.org/packages/Microsoft.Data.SqlClient) and [System.Data.SqlClient](https://www.nuget.org/packages/System.Data.SqlClient) packages.

* Metrics
  * Provides automatic collection of Application Insights Standard metrics.

* [Logs](https://github.com/open-telemetry/opentelemetry-dotnet/tree/main/docs/logs/getting-started-console)

* [Azure Monitor Exporter](https://www.nuget.org/packages/Azure.Monitor.OpenTelemetry.Exporter/) allows sending traces, metrics, and logs data to Azure Monitor.

### Install the package

#### Latest Version: [![Nuget](https://img.shields.io/nuget/vpre/Azure.Monitor.OpenTelemetry.AspNetCore.svg)](https://www.nuget.org/packages/Azure.Monitor.OpenTelemetry.AspNetCore/)

Install the Azure Monitor Distro for .NET from [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Monitor.OpenTelemetry.AspNetCore
```

#### Nightly builds

Nightly builds are available from this repo's [dev feed](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md#nuget-package-dev-feed).
These are provided without support and are not intended for production workloads.

### Enabling Azure Monitor OpenTelemetry in your application

The following examples demonstrate how to integrate the Azure Monitor Distro into your application.

#### Example 1

To enable Azure Monitor Distro, add `UseAzureMonitor()` to your `Program.cs` file and set the `APPLICATIONINSIGHTS_CONNECTION_STRING` environment variable to the connection string from your Application Insights resource.

```C#
// This method gets called by the runtime. Use this method to add services to the container.
var builder = WebApplication.CreateBuilder(args);

// The following line enables Azure Monitor Distro.
builder.Services.AddOpenTelemetry().UseAzureMonitor();

// This code adds other services for your application.
builder.Services.AddMvc();

var app = builder.Build();
```

#### Example 2

To enable Azure Monitor Distro with a hard-coded connection string, add `UseAzureMonitor()` to your `Program.cs` with the `AzureMonitorOptions` containing the connection string.

```C#
// This method gets called by the runtime. Use this method to add services to the container.
var builder = WebApplication.CreateBuilder(args);

// The following line enables Azure Monitor Distro with hard-coded connection string.
builder.Services.AddOpenTelemetry().UseAzureMonitor(o => o.ConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000");

// This code adds other services for your application.
builder.Services.AddMvc();

var app = builder.Build();
```

Note that in the examples above, `UseAzureMonitor` is added to the `IServiceCollection` in the `Program.cs` file. You can also add it in the `ConfigureServices` method of your `Startup.cs` file.

> **Note**
  > Multiple calls to `AddOpenTelemetry.UseAzureMonitor()` will **NOT** result in multiple providers. Only a single `TracerProvider`, `MeterProvider` and `LoggerProvider` will be created in the target `IServiceCollection`. To establish multiple providers use the `Sdk.CreateTracerProviderBuilder()` and/or `Sdk.CreateMeterProviderBuilder()` and/or `LoggerFactory.CreateLogger` methods with the [Azure Monitor Exporter](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/monitor/Azure.Monitor.OpenTelemetry.Exporter) instead of using Azure Monitor Distro.

### Authenticate the client

Azure Active Directory (AAD) authentication is an optional feature that can be used with Azure Monitor Distro. To enable AAD authentication, set the `Credential` property in `AzureMonitorOptions`. This is made easy with the [Azure Identity library](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity/README.md), which provides support for authenticating Azure SDK clients with their corresponding Azure services.

```C#
// Call UseAzureMonitor and set Credential to authenticate through Active Directory.
builder.Services.AddOpenTelemetry().UseAzureMonitor(o =>
{
    o.ConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000";
    o.Credential = new DefaultAzureCredential();
});
```

With this configuration, the Azure Monitor Distro will use the credentials of the currently logged-in user or of the service principal to authenticate and send telemetry data to Azure Monitor.

Note that the `Credential` property is optional. If it is not set, Azure Monitor Distro will use the Instrumentation Key from the Connection String to send data to Azure Monitor.

### Advanced configuration

#### Customizing Sampling Percentage

When using the Azure Monitor Distro, the sampling percentage for telemetry data is set to 100% (1.0F) by default. For example, let's say you want to set the sampling percentage to 50%. You can achieve this by modifying the code as follows:

``` C#
builder.Services.AddOpenTelemetry().UseAzureMonitor(o =>
{
    o.SamplingRatio = 0.5F;
});
```

#### Adding Custom ActivitySource to Traces

```C#
builder.Services.AddOpenTelemetry().UseAzureMonitor();
builder.Services.ConfigureOpenTelemetryTracerProvider((sp, builder) => builder.AddSource("MyCompany.MyProduct.MyLibrary"));
```

#### Adding Custom Meter to Metrics

```C#
builder.Services.AddOpenTelemetry().UseAzureMonitor();
builder.Services.ConfigureOpenTelemetryMeterProvider((sp, builder) => builder.AddMeter("MyCompany.MyProduct.MyLibrary"));
```

#### Adding Additional Instrumentation

If you need to instrument a library or framework that isn't included in the Azure Monitor Distro, you can add additional instrumentation using the OpenTelemetry Instrumentation packages. For example, to add instrumentation for gRPC clients, you can add the [OpenTelemetry.Instrumentation.GrpcNetClient](https://www.nuget.org/packages/OpenTelemetry.Instrumentation.GrpcNetClient/) package and use the following code:

```C#
builder.Services.AddOpenTelemetry().UseAzureMonitor();
builder.Services.ConfigureOpenTelemetryTracerProvider((sp, builder) => builder.AddGrpcClientInstrumentation());
```

#### Enable Azure SDK Instrumentation

Azure SDK instrumentation is supported under the experimental feature flag which can be enabled using one of the following ways:

* Set the `AZURE_EXPERIMENTAL_ENABLE_ACTIVITY_SOURCE` environment variable to `true`.

* Set the Azure.Experimental.EnableActivitySource context switch to true in your app’s code:
    ```csharp
    AppContext.SetSwitch("Azure.Experimental.EnableActivitySource", true);
    ```

* Add the RuntimeHostConfigurationOption setting to your project file:
    ```csharp
    <ItemGroup>
        <RuntimeHostConfigurationOption Include="Azure.Experimental.EnableActivitySource" Value="true" />
    </ItemGroup>
    ```

#### Adding Another Exporter

Azure Monitor Distro uses the Azure Monitor exporter to send data to Application Insights. However, if you need to send data to other services, including Application Insights, you can add another exporter. For example, to add the Console exporter, you can install the [OpenTelemetry.Exporter.Console](https://www.nuget.org/packages/OpenTelemetry.Exporter.Console) package and use the following code:

```C#
builder.Services.AddOpenTelemetry().UseAzureMonitor();
builder.Services.ConfigureOpenTelemetryMeterProvider((sp, builder) => builder.AddConsoleExporter());
```

#### Adding Custom Resource

To modify the resource, use the following code.

```C#
builder.Services.AddOpenTelemetry().UseAzureMonitor();
builder.Services.ConfigureOpenTelemetryTracerProvider((sp, builder) => builder.ConfigureResource(resourceBuilder => resourceBuilder.AddService("service-name")));
```

It is also possible to configure the `Resource` by using following
environmental variables:

| Environment variable       | Description                                        |
| -------------------------- | -------------------------------------------------- |
| `OTEL_RESOURCE_ATTRIBUTES` | Key-value pairs to be used as resource attributes. See the [Resource SDK specification](https://github.com/open-telemetry/opentelemetry-specification/blob/v1.5.0/specification/resource/sdk.md#specifying-resource-information-via-an-environment-variable) for more details. |
| `OTEL_SERVICE_NAME`        | Sets the value of the `service.name` resource attribute. If `service.name` is also provided in `OTEL_RESOURCE_ATTRIBUTES`, then `OTEL_SERVICE_NAME` takes precedence. |

## Key concepts

The Azure Monitor Distro is a distribution package that facilitates users in sending telemetry data to Azure Monitor. It encompasses the .NET OpenTelemetry SDK and internally vendored instrumentation libraries for ASP.NET Core, HttpClient, and SQLClient, ensuring seamless integration and data collection.

## Examples

Refer to [`Program.cs`](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/monitor/Azure.Monitor.OpenTelemetry.AspNetCore/tests/Azure.Monitor.OpenTelemetry.AspNetCore.Demo/Program.cs) for a complete demo.

## Troubleshooting

The Azure Monitor Distro uses EventSource for its own internal logging. The logs are available to any EventListener by opting into the source named "OpenTelemetry-AzureMonitor-Exporter".

OpenTelemetry also provides it's own [self-diagnostics feature](https://github.com/open-telemetry/opentelemetry-dotnet/blob/main/src/OpenTelemetry/README.md#troubleshooting) to collect internal logs.
An example of this is available in our demo project [here](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/monitor/Azure.Monitor.OpenTelemetry.Exporter/tests/Azure.Monitor.OpenTelemetry.Exporter.Demo/OTEL_DIAGNOSTICS.json).

**Missing Request Telemetry**

If an app has a reference to the [OpenTelemetry.Instrumentation.AspNetCore](https://www.nuget.org/packages/OpenTelemetry.Instrumentation.AspNetCore) package, it could be missing request telemetry. To resolve this issue:

* Either remove the reference to the `OpenTelemetry.Instrumentation.AspNetCore` package (or)
* Add `AddAspNetCoreInstrumentation` to the OpenTelemetry TracerProvider configuration as per the [OpenTelemetry documentation](https://github.com/open-telemetry/opentelemetry-dotnet/tree/main/src/OpenTelemetry.Instrumentation.AspNetCore).

**Few or all Dependency Telemetries are missing**

If an app references the [OpenTelemetry.Instrumentation.Http](https://www.nuget.org/packages/OpenTelemetry.Instrumentation.Http) or [OpenTelemetry.Instrumentation.SqlClient](https://www.nuget.org/packages/OpenTelemetry.Instrumentation.SqlClient) packages, it might be missing dependency telemetry. To resolve:

* Remove the respective package references (or)
* Add `AddHttpClientInstrumentation` or `AddSqlClientInstrumentation` to the TracerProvider configuration. Detailed guidance can be found in the OpenTelemetry documentation for [HTTP](https://github.com/open-telemetry/opentelemetry-dotnet/tree/main/src/OpenTelemetry.Instrumentation.Http) and [SQL Client](https://github.com/open-telemetry/opentelemetry-dotnet/tree/main/src/OpenTelemetry.Instrumentation.SqlClient).

**Note:** If all telemetries are missing or if the above troubleshooting steps do not help, please collect [self-diagnostics logs](https://github.com/open-telemetry/opentelemetry-dotnet/blob/main/src/OpenTelemetry/README.md#troubleshooting).

## Next steps

For more information on Azure SDK, please refer to [this website](https://azure.github.io/azure-sdk/)

## Contributing

See [CONTRIBUTING.md](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md) for details on contribution process.
