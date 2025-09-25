# Sample using `Telemetry` in Azure.AI.Projects

This sample demonstrates how to enable various tracing methods

## Prerequisites

- Install the Azure.AI.Projects package.
- Install the Azure.Monitor.OpenTelemetry.Exporter package.
- Set the following environment variables:
  - `PROJECT_ENDPOINT`: The Azure AI Project endpoint, as found in the overview page of your Azure AI Foundry project.

### Tracing

You can add an Application Insights Azure resource to your Azure AI Foundry project. See the Tracing tab in your AI Foundry project. If one was enabled, you use the Application Insights connection string, configure your Project, and observe the full execution path through Azure Monitor.

This sample shows the basics of enabling OpenTelemetry support in your application, using the Application Insights resource associated with your account. For full details on monitoring using Azure Monitor/OpenTelemetry, please refer to the corresponding [Azure documentation](https://learn.microsoft.com/en-us/azure/azure-monitor/app/opentelemetry-enable?tabs=net).

#### Tracing to Azure Monitor

To connect to your Project's Application Insights instance, set the `APPLICATIONINSIGHTS_CONNECTION_STRING` environment variable to point to your resource. This can be retrieved from the project client as follows (async option also available):

```C# Snippet:AI_Projects_TelemetryExampleSync
var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());

Console.WriteLine("Get the Application Insights connection string.");
var connectionString = projectClient.Telemetry.GetApplicationInsightsConnectionString();

Console.WriteLine("Assign the retrieved string to the required environment variable.");
Environment.SetEnvironmentVariable("APPLICATIONINSIGHTS_CONNECTION_STRING", connectionString);
```

Here is an example how to set up tracing to Azure monitor using Azure.Monitor.OpenTelemetry.Exporter:

```C# Snippet:AI_Projects_TelemetrySetupTracingToAzureMonitor
// Create a new tracer provider builder and add an Azure Monitor trace exporter to the tracer provider builder.
// It is important to keep the TracerProvider instance active throughout the process lifetime.
// See https://github.com/open-telemetry/opentelemetry-dotnet/tree/main/docs/trace#tracerprovider-management
var tracerProvider = OpenTelemetry.Sdk.CreateTracerProviderBuilder()
    .AddAzureMonitorTraceExporter();

// Add an Azure Monitor metric exporter to the metrics provider builder.
// It is important to keep the MetricsProvider instance active throughout the process lifetime.
// See https://github.com/open-telemetry/opentelemetry-dotnet/tree/main/docs/metrics#meterprovider-management
var metricsProvider = OpenTelemetry.Sdk.CreateMeterProviderBuilder()
    .AddAzureMonitorMetricExporter();

// Create a new logger factory.
// It is important to keep the LoggerFactory instance active throughout the process lifetime.
// See https://github.com/open-telemetry/opentelemetry-dotnet/tree/main/docs/logs#logger-management
var loggerFactory = LoggerFactory.Create(builder =>
{
    builder.AddOpenTelemetry(logging =>
    {
        logging.AddAzureMonitorLogExporter();
    });
});
```

For more details and full configuration options, please refer to the corresponding [Azure documentation](https://learn.microsoft.com/en-us/azure/azure-monitor/app/opentelemetry-enable?tabs=net).
