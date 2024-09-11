# Using telemetry with Azure.AI.Inference

In this example we will demonstrate how [OpenTelemetry](https://learn.microsoft.com/dotnet/core/diagnostics/observability-with-otel) library can be leveraged to diagnose the issues in the Chat Completions request.

## Project creation and dependency installation
First, we will create the console application project and add `Azure.AI.Inference` as a dependency. The first command will create the project called `TelemetryDemo.csproj`. The `dotnet add package <…>` command will modify project file and in future we will need to run `dotnet restore` to install all dependencies, if we will remove the installed ones.

```dotnetcli
dotnet new console --name TelemetryDemo --output TelemetryDemo
dotnet add package Azure.AI.Inference --prerelease
```

Now we will need to add the dependencies for OpenTelemetry.

```dotnetcli
dotnet add package OpenTelemetry
dotnet add package OpenTelemetry.Exporter.Console
dotnet add package Azure.Monitor.OpenTelemetry.AspNetCore --prerelease
```

## Create the simple application with telemetry
The `dotnet new` created the project with the single file called Program.cs. Let us edit this file with the IDE of choice.

First we will import open telemetry and Azure.AI.Inference
```c#
//Azure imports
using Azure;
using Azure.AI.Inference;
// Open telemetry imports
using OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Azure.Monitor.OpenTelemetry.Exporter;
using OpenTelemetry.Metrics;
```

Now we will define the `endpoint`, `credential` and `model`. In this example we will take these values from the environment variables.
```c#
var endpoint = new Uri(System.Environment.GetEnvironmentVariable("MODEL_ENDPOINT"));
var credential = new AzureKeyCredential(System.Environment.GetEnvironmentVariable("GITHUB_TOKEN"));
var model = System.Environment.GetEnvironmentVariable("MODEL_NAME");
```

To get the telemetry, we will need to listen for [Activity](https://learn.microsoft.com/dotnet/api/system.diagnostics.activity) and [Meter](https://learn.microsoft.com/dotnet/api/system.diagnostics.metrics.meter)  defined by the constant `OpenTelemetryConstants.ActivityName` from the `Azure.AI.Inference.Telemetry` namespace.
To log metrics and events to [Application Insights](https://learn.microsoft.com/azure/azure-monitor/app/app-insights-overview) we will need to get the connection string. Please open the Azure portal, create the Application Insights resource you wish to use for storing the telemetry. After that open the main page and find the "Connection String". It generally will have the format similar to "InstrumentationKey=xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx;IngestionEndpoint=https://region-x.in.applicationinsights.azure.com/;LiveEndpoint=https://eastus.livediagnostics.monitor.azure.com/;ApplicationId=xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx". In our code we will use the connection string from environment variable.

```c#
var appInsightsConn = System.Environment.GetEnvironmentVariable("APP_INSIGHTS_CONNECTION_STR");
```

To allow telemetry collection we will create the listeners, which will listen to Azure.AI.Inference activity and meters.In the code below we will create `tracerProvider`, which will listen to activity and `meterProvider`, listening to meter. We will add console exporters to both providers with the line `AddConsoleExporter()` and monitor exporter for Application Insights export: `AddAzureMonitorMetricExporter`. 

```c#
using var tracerProvider = Sdk.CreateTracerProviderBuilder()
    .AddSource(ACTIVITY)
    .ConfigureResource(r => r.AddService("MyServiceName"))
    .AddConsoleExporter()
    .AddAzureMonitorTraceExporter(options =>
    {
        options.ConnectionString = appInsightsConn;
    })
    .Build();

using var meterProvider = Sdk.CreateMeterProviderBuilder()
    .AddMeter(ACTIVITY)
    .AddConsoleExporter()
    .AddAzureMonitorMetricExporter(options =>
    {
        options.ConnectionString = appInsightsConn;
    })
    .Build();
```

To export only events, we need to define `tracerProvider`, to export also metrics, we need to we also need to define `meterProvider`. Metrics cannot be exported without events.
After we have initialized the providers, we will use simple completions example from [Sample1](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/ai/Azure.AI.Inference/samples/Sample1_ChatCompletions.md).
```c#
// Set up the parameters.
var client = new ChatCompletionsClient(
    endpoint,
    credential,
    new ChatCompletionsClientOptions());

var requestOptions = new ChatCompletionsOptions()
{
    Messages =
    {
        new ChatRequestSystemMessage("You are a helpful assistant."),
        new ChatRequestUserMessage("What is the capital of France?"),
    },
    Model = model,
    Temperature = 1,
    MaxTokens = 1000
};

// Call the enpoint and output the response.
Response<ChatCompletions> response = client.Complete(requestOptions);
System.Console.WriteLine(response.Value.Choices[0].Message.Content);
```

## Running the application
**IMPORTANT!** To switch on the telemetry we need to set environment variable `AZURE_TRACING_GEN_AI_CONTENT_RECORDING_ENABLED` to "1" or "true". It can be done in IDE or in the console as outlined below.

On Windows CMD
```
set AZURE_TRACING_GEN_AI_CONTENT_RECORDING_ENABLED=1
```

On PowerShell
```
$env:AZURE_TRACING_GEN_AI_CONTENT_RECORDING_ENABLED="1"
```

On Bash
```bash
export AZURE_TRACING_GEN_AI_CONTENT_RECORDING_ENABLED=1
```

Now run the application from IDE, or use
```dotnetcli
dotnet run
```

The Console will show all the exported telemetry along with the response from LLM.

## Getting the telemetry from Application Insights
After we have run the application, we can list all the metrics and events on the Application Insights. On the top panel of Application Insights resource please select "Logs".
To get the metrics run the query.
```
customMetrics
| sort by timestamp desc 
| take 10
```

To get the logged events, run the query against `traces` table.
```
traces
| sort by timestamp desc 
| take 10
```

