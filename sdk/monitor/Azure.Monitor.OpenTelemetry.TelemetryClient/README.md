# Azure Monitor Telemetry client library for .NET

## Getting started

### Prerequisites

- **Azure Subscription:**  To use Azure services, including Azure Monitor Exporter for [OpenTelemetry .NET](https://github.com/open-telemetry/opentelemetry-dotnet), you'll need a subscription.  If you do not have an existing Azure account, you may sign up for a [free trial](https://azure.microsoft.com/free/dotnet/) or use your [Visual Studio Subscription](https://visualstudio.microsoft.com/subscriptions/) benefits when you [create an account](https://azure.microsoft.com/account).
- **Azure Application Insights Connection String:** To send telemetry data to the monitoring service you'll need connection string from Azure Application Insights. If you are not familiar with creating Azure resources, you may wish to follow the step-by-step guide for [Create an Application Insights resource](https://learn.microsoft.com/azure/azure-monitor/app/create-new-resource) and [copy the connection string](https://learn.microsoft.com/azure/azure-monitor/app/sdk-connection-string?tabs=net#find-your-connection-string).

### Install the package

#### Latest Version: [![Nuget](https://img.shields.io/nuget/vpre/Azure.Monitor.OpenTelemetry.TelemetryClient.svg)](https://www.nuget.org/packages/Azure.Monitor.OpenTelemetry.TelemetryClient/)

Install the Azure Monitor Exporter for OpenTelemetry .NET with [NuGet](https://www.nuget.org/):
```dotnetcli
dotnet add package Azure.Monitor.OpenTelemetry.TelemetryClient
```

## Migration from Application Insights for .NET

### How to migrate

To migrate from [the telemetry client of Application Insights for .NET](https://learn.microsoft.com/en-us/previous-versions/azure/azure-monitor/app/console):

1) Swap out the `Microsoft.ApplicationInsights` package for `Azure.Monitor.OpenTelemetry.TelemetryClient`.

2) Replace the `Microsoft.ApplicationInsights` namespace import with `Azure.Monitor.OpenTelemetry.TelemetryClient`

The API surface is similar to the one in Application Insights for .NET, so you can use the same methods to track requests, dependencies, traces, exceptions, events and metrics.

### Telemetry data differences

There are certain differences in the telemetry data sent to Application Insights.

#### TrackTrace methods

 * **TrackTrace(string message)**

   Additional data within the `traces` Kusto table:
   * The `customDimension` column contains the entry `{"CategoryName":"ApplicationInsightsLogger"}`
   * The severity level is set to `1` (Information) in the `severityLevel` column

* **TrackTrace(string message, SeverityLevel severityLevel)**

  Within the `traces` Kusto table:
    * The `customDimension` column contains the entry `{"CategoryName":"ApplicationInsightsLogger"}`

* **TrackTrace(string message, IDictionary<string, string> properties)**

  Additional data within the `traces` Kusto table:
    * The `customDimension` column contains the entry `{"CategoryName":"ApplicationInsightsLogger"}`

* **TrackTrace(string message, SeverityLevel severityLevel, IDictionary<string, string> properties)**

  Additional data within the `traces` Kusto table:
    * The `customDimension` column contains the entry `{"CategoryName":"ApplicationInsightsLogger"}`

#### TrackException methods

* **void TrackException(Exception? exception, IDictionary<string, string> properties = null!)**

  Additional data within the `exceptions` Kusto table:
    * The severity level is set to `3` (Error) in the `severityLevel` column
    * The problem id is set with the exception name in the `problemId` column
    * The `customDimension` column contains an `OriginalFormat` entry with the exception message value
    * The `customDimension` column contains the entry `{"CategoryName":"ApplicationInsightsLogger"}`

#### TrackRequest methods

* **TrackRequest(string name, DateTimeOffset startTime, TimeSpan duration, string responseCode, bool success)**

  Additional data within the `requests` Kusto table:
    * The `customDimension` column contains the entry `"_MS.ProcessedByMetricExtractors": "(Name: X,Ver:'1.1')"`

#### TrackDependency methods

* **TrackDependency(string? dependencyTypeName, string target, string dependencyName, string data, DateTimeOffset startTime, TimeSpan duration, string resultCode, bool success)**
  and **void TrackDependency(string? dependencyTypeName, string dependencyName, string data, DateTimeOffset startTime, TimeSpan duration, bool success)**
    * If the dependency type is `SQL` (case insensitive)
      * The dependency type sent to Application Insights is `SQL` for the `mssql` (Microsoft SQL Server) `target` parameter. This limitation could be addressed if needed.
      * The `resultCode` method argument is sent to Application Insights.
    * If the dependency type is `HTTP` (case insensitive)
      * The `dependencyName` method argument should contain the HTTP method (GET, POST, ...) to allow the method to work correctly
      * The dependency name sent to Application Insights is based on the `data` and `dependencyName` method arguments. For example,
        if the `data` argument is `https://api.example.com/api/orders` and the `dependencyName` argument is `"GET order`,
        the dependency name sent to Application Insights will be `GET /api/orders` (concatenation of the HTTP method and the path
        without the domain name).
    * If the dependency type is not `SQL` or `HTTP` (case insensitive)
      * Only the `data` and `target` method arguments are sent to Application Insights.
    * The `customDimension` column contains the entry `"_MS.ProcessedByMetricExtractors": "(Name: X,Ver:'1.1')"`


#### Nightly builds

Nightly builds are available from this repo's [dev feed](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md#nuget-package-dev-feed).
These are provided without support and are not intended for production workloads.

### Authenticate the client

## Key concepts

## Examples

    ```csharp
	var configuration = new() { ConnectionString = "InstrumentationKey=..." };

	TelemetryClient telemetryClient = new TelemetryClient(configuration);
	telemetryClient.TrackTrace("My Application Insights trace");
	telemetryClient.Flush();
	```

## Troubleshooting

## Next steps

For more information on Azure SDK, please refer to [this website](https://azure.github.io/azure-sdk/)

## Contributing
