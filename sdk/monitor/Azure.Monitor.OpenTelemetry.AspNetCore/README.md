# Azure Monitor Distro client library for .NET

The Azure Monitor Distro is a client library that sends telemetry data to Azure Monitor following the OpenTelemetry Specification. This library can be used to instrument your ASP.NET Core applications to collect and send telemetry data to Azure Monitor for analysis and monitoring, powering experiences in Application Insights.

## Getting started

### Prerequisites

- **Azure Subscription:**  To use Azure services, including Azure Monitor Distro, you'll need a subscription.  If you do not have an existing Azure account, you may sign up for a [free trial](https://azure.microsoft.com/free/dotnet/) or use your [Visual Studio Subscription](https://visualstudio.microsoft.com/subscriptions/) benefits when you [create an account](https://azure.microsoft.com/account).
- **Azure Application Insights Connection String:** To send telemetry data to the monitoring service you'll need connection string from Azure Application Insights. If you are not familiar with creating Azure resources, you may wish to follow the step-by-step guide for [Create an Application Insights resource](https://learn.microsoft.com/azure/azure-monitor/app/create-new-resource) and [copy the connection string](https://learn.microsoft.com/azure/azure-monitor/app/sdk-connection-string?tabs=net#find-your-connection-string).
- **ASP.NET Core App:** An ASP.NET Core application is required to instrument it with Azure Monitor Distro. You can either bring your own app or follow the [Get started with ASP.NET Core MVC](https://learn.microsoft.com/aspnet/core/tutorials/first-mvc-app/start-mvc) to create a new one.

### What is Included in the Distro

The Azure Monitor Distro is a distribution of the .NET OpenTelemetry SDK with instrumentation libraries, including:

* Traces
  * **ASP.NET Core Instrumentation**: Provides automatic tracing for incoming HTTP requests to ASP.NET Core applications.
  * **HTTP Client Instrumentation**: Provides automatic tracing for outgoing HTTP requests made using [System.Net.Http.HttpClient](https://learn.microsoft.com/dotnet/api/system.net.http.httpclient).
  * **SQL Client Instrumentation** Provides automatic tracing for SQL queries executed using the [Microsoft.Data.SqlClient](https://www.nuget.org/packages/Microsoft.Data.SqlClient) and [System.Data.SqlClient](https://www.nuget.org/packages/System.Data.SqlClient) packages. (While the OpenTelemetry SqlClient instrumentation remains in its beta phase, we have taken the step to vendor it and include it in our Distro)

* Metrics
  * **Application Insights Standard Metrics**: Provides automatic collection of Application Insights Standard metrics.
  * **ASP.NET Core and HTTP Client Metrics Instrumentation**: Our distro will selectively enable metrics collection based on the .NET runtime version.
	* **.NET 8.0 and above**: Utilizes built-in Metrics `Microsoft.AspNetCore.Hosting` and `System.Net.Http` from .NET.
      For a detailed list of metrics produced, refer to the [Microsoft.AspNetCore.Hosting](https://learn.microsoft.com/en-in/dotnet/core/diagnostics/built-in-metrics-aspnetcore#microsoftaspnetcorehosting)
      and [System.Net.Http](https://learn.microsoft.com/en-in/dotnet/core/diagnostics/built-in-metrics-system-net#systemnethttp) metrics documentation.
	* **.NET 7.0 and below**: Falls back to ASP.NET Core Instrumentation and HTTP Client Instrumentation.
      For a detailed list of metrics produced, refer to the [ASP.NET Core Instrumentation](https://github.com/open-telemetry/opentelemetry-dotnet-contrib/tree/main/src/OpenTelemetry.Instrumentation.AspNetCore/README.md#list-of-metrics-produced)
      and [HTTP Client Instrumentation](https://github.com/open-telemetry/opentelemetry-dotnet-contrib/blob/main/src/OpenTelemetry.Instrumentation.Http/README.md#list-of-metrics-produced) documentation.

* [Logs](https://github.com/open-telemetry/opentelemetry-dotnet/tree/main/docs/logs/getting-started-console)
  * Logs created with `Microsoft.Extensions.Logging`. See [Logging in .NET Core and ASP.NET Core](https://learn.microsoft.com/aspnet/core/fundamentals/logging) for more details on how to create and configure logging.
  * [Azure SDK logs](https://learn.microsoft.com/dotnet/azure/sdk/logging) are recorded as a subset of `Microsoft.Extensions.Logging`

* Resource Detectors
  * **AppServiceResourceDetector**: Adds resource attributes for the applications running in Azure App Service.
  * **AzureVMResourceDetector**: Adds resource attributes for the applications running in an Azure Virtual Machine.
  * **AzureContainerAppsResourceDetector**: Adds resource attributes for the applications running in Azure Container Apps.

   **Note**: The detectors are part of the [OpenTelemetry.ResourceDetectors.Azure](https://github.com/open-telemetry/opentelemetry-dotnet-contrib/tree/main/src/OpenTelemetry.Resources.Azure) package. While this package is currently in its beta phase, we have chosen to vendor in the code for these detectors to include them in our Distro. Please be aware that resource attributes are only used to set the cloud role and role instance. All other resource attributes are ignored.

* [Live Metrics](https://learn.microsoft.com/azure/azure-monitor/app/live-stream)
  * Integrated support for live metrics enabling real-time monitoring of application performance.

* [Azure Monitor Exporter](https://www.nuget.org/packages/Azure.Monitor.OpenTelemetry.Exporter/) allows sending traces, metrics, and logs data to Azure Monitor.

### Migrating from Application Insights SDK?

If you are currently using the Application Insights SDK and want to migrate to OpenTelemetry, please follow our [migration guide](https://learn.microsoft.com/azure/azure-monitor/app/opentelemetry-dotnet-migrate?tabs=aspnetcore).

### Already using OpenTelemetry?

If you are currently using OpenTelemetry and want to send telemetry data to Azure Monitor, please follow our [getting started guide](https://learn.microsoft.com/azure/azure-monitor/app/opentelemetry-enable?tabs=aspnetcore).

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
builder.Services.AddOpenTelemetry().UseAzureMonitor(options =>
{
    options.ConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000";
    options.Credential = new DefaultAzureCredential();
});
```

With this configuration, the Azure Monitor Distro will use the credentials of the currently logged-in user or of the service principal to authenticate and send telemetry data to Azure Monitor.

Note that the `Credential` property is optional. If it is not set, Azure Monitor Distro will use the Instrumentation Key from the Connection String to send data to Azure Monitor.

### Advanced configuration

#### Customizing Sampling Percentage

When using the Azure Monitor Distro, the sampling percentage for telemetry data is set to 100% (1.0F) by default. For example, let's say you want to set the sampling percentage to 50%. You can achieve this by modifying the code as follows:

``` C#
builder.Services.AddOpenTelemetry().UseAzureMonitor(options =>
{
    options.SamplingRatio = 0.5F;
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

#### Customizing Instrumentation Libraries

The Azure Monitor Distro includes .NET OpenTelemetry instrumentation for [ASP.NET Core](https://www.nuget.org/packages/OpenTelemetry.Instrumentation.AspNetCore/), [HttpClient](https://www.nuget.org/packages/OpenTelemetry.Instrumentation.Http/), and [SQLClient](https://www.nuget.org/packages/OpenTelemetry.Instrumentation.SqlClient).
You can customize these included instrumentations or manually add additional instrumentation on your own using the OpenTelemetry API.

Here are some examples of how to customize the instrumentation:

##### Customizing AspNetCoreTraceInstrumentationOptions

```C#
builder.Services.AddOpenTelemetry().UseAzureMonitor();
builder.Services.Configure<AspNetCoreTraceInstrumentationOptions>(options =>
{
    options.RecordException = true;
    options.Filter = (httpContext) =>
    {
        // only collect telemetry about HTTP GET requests
        return HttpMethods.IsGet(httpContext.Request.Method);
    };
});
```

##### Customizing HttpClientTraceInstrumentationOptions

```C#
builder.Services.AddOpenTelemetry().UseAzureMonitor();
builder.Services.Configure<HttpClientTraceInstrumentationOptions>(options =>
{
    options.RecordException = true;
    options.FilterHttpRequestMessage = (httpRequestMessage) =>
    {
        // only collect telemetry about HTTP GET requests
        return HttpMethods.IsGet(httpRequestMessage.Method.Method);
    };
});
```

##### Customizing SqlClientInstrumentationOptions

While the [SQLClient](https://www.nuget.org/packages/OpenTelemetry.Instrumentation.SqlClient) instrumentation is still in beta, we have vendored it within our package.
Once it reaches a stable release, it will be included as a standard package reference.
Until then, for customization of the SQLClient instrumentation, manually add the OpenTelemetry.Instrumentation.SqlClient package reference to your project and utilize its public API.

```
dotnet add package --prerelease OpenTelemetry.Instrumentation.SqlClient
```

```C#
builder.Services.AddOpenTelemetry().UseAzureMonitor().WithTracing(tracing =>
{
    tracing.AddSqlClientInstrumentation(options =>
    {
        options.SetDbStatementForStoredProcedure = false;
    });
});
```

#### Disable Live Metrics

By default, the Live Metrics feature is enabled in the Azure Monitor Distro. This feature allows for real-time monitoring of application performance, providing immediate insights into your application's operations. However, there may be scenarios where you prefer to disable this feature, such as to optimize resource usage or in environments where real-time monitoring is not a requirement.

To disable Live Metrics, you can set the `EnableLiveMetrics` property to `false` in the `AzureMonitorOptions`. Here's an example of how to disable Live Metrics:

```C#
// Disable Live Metrics by setting EnableLiveMetrics to false in the UseAzureMonitor configuration.
builder.Services.AddOpenTelemetry().UseAzureMonitor(options =>
{
    options.ConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000";
    options.EnableLiveMetrics = false;
});
```

#### Drop a Metrics Instrument

The Azure Monitor Distro enables metric collection and collects several metrics by default.
If you want to exclude specific instruments from being collected in your application's telemetry use the following code snippet:

```C#
builder.Services.ConfigureOpenTelemetryMeterProvider(metrics =>
    metrics.AddView(instrumentName: "http.server.active_requests", MetricStreamConfiguration.Drop)
    );
```

Refer to [Drop an instrument](https://github.com/open-telemetry/opentelemetry-dotnet/tree/main/docs/metrics/customizing-the-sdk#drop-an-instrument) for more examples.

## Key concepts

The Azure Monitor Distro is a distribution package that facilitates users in sending telemetry data to Azure Monitor. It encompasses the .NET OpenTelemetry SDK and instrumentation libraries for ASP.NET Core, HttpClient, and SQLClient, ensuring seamless integration and data collection.

## Examples

Refer to [`Program.cs`](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/monitor/Azure.Monitor.OpenTelemetry.AspNetCore/tests/Azure.Monitor.OpenTelemetry.AspNetCore.Demo/Program.cs) for a complete demo.

### Log Scopes

Log [scopes](https://learn.microsoft.com/dotnet/core/extensions/logging#log-scopes) allow you to add additional properties to the logs generated by your application.
Although the Azure Monitor Distro does support scopes, this feature is off by default in OpenTelemetry.
To leverage log scopes, you must explicitly enable them.

To include the scope with your logs, set `OpenTelemetryLoggerOptions.IncludeScopes` to `true` in your application's configuration:
```csharp
builder.Services.Configure<OpenTelemetryLoggerOptions>((loggingOptions) =>
{
    loggingOptions.IncludeScopes = true;
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
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenTelemetry().UseAzureMonitor();

var app = builder.Build();

app.Logger.LogInformation("{microsoft.custom_event.name} {key1} {key2}", "MyCustomEventName", "value1", "value2");
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

The Azure Monitor Distro uses EventSource for its own internal logging. The logs are available to any EventListener by opting into the source named "OpenTelemetry-AzureMonitor-Exporter".

OpenTelemetry also provides it's own [self-diagnostics feature](https://github.com/open-telemetry/opentelemetry-dotnet/blob/main/src/OpenTelemetry/README.md#troubleshooting) to collect internal logs.
An example of this is available in our demo project [here](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/monitor/Azure.Monitor.OpenTelemetry.Exporter/tests/Azure.Monitor.OpenTelemetry.Exporter.Demo/OTEL_DIAGNOSTICS.json).

**Missing Request Telemetry**

If an app has a reference to the [OpenTelemetry.Instrumentation.AspNetCore](https://www.nuget.org/packages/OpenTelemetry.Instrumentation.AspNetCore) package, it could be missing request telemetry. To resolve this issue:

* Either remove the reference to the `OpenTelemetry.Instrumentation.AspNetCore` package (or)
* Add `AddAspNetCoreInstrumentation` to the OpenTelemetry TracerProvider configuration as per the [OpenTelemetry documentation](https://github.com/open-telemetry/opentelemetry-dotnet-contrib/tree/main/src/OpenTelemetry.Instrumentation.AspNetCore).

**Few or all Dependency Telemetries are missing**

If an app references the [OpenTelemetry.Instrumentation.Http](https://www.nuget.org/packages/OpenTelemetry.Instrumentation.Http) or [OpenTelemetry.Instrumentation.SqlClient](https://www.nuget.org/packages/OpenTelemetry.Instrumentation.SqlClient) packages, it might be missing dependency telemetry. To resolve:

* Remove the respective package references (or)
* Add `AddHttpClientInstrumentation` or `AddSqlClientInstrumentation` to the TracerProvider configuration. Detailed guidance can be found in the OpenTelemetry documentation for [HTTP](https://github.com/open-telemetry/opentelemetry-dotnet-contrib/tree/main/src/OpenTelemetry.Instrumentation.Http) and [SQL Client](https://github.com/open-telemetry/opentelemetry-dotnet-contrib/tree/main/src/OpenTelemetry.Instrumentation.SqlClient).

**Note:** If all telemetries are missing or if the above troubleshooting steps do not help, please collect [self-diagnostics logs](https://github.com/open-telemetry/opentelemetry-dotnet/blob/main/src/OpenTelemetry/README.md#troubleshooting).

## Next steps

For more information on Azure SDK, please refer to [this website](https://azure.github.io/azure-sdk/)

## Contributing

See [CONTRIBUTING.md](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md) for details on contribution process.
