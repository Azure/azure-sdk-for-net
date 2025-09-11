# Sample using `Telemetry` in Azure.AI.Projects

This sample demonstrates how to use the synchronous and asynchronous `Telemetry` methods.

## Prerequisites

- Install the Azure.AI.Projects package.
- Set the following environment variables:
  - `PROJECT_ENDPOINT`: The Azure AI Project endpoint, as found in the overview page of your Azure AI Foundry project.

## Synchronous Sample

```C# Snippet:AI_Projects_TelemetryExampleSync
var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());

Console.WriteLine("Get the Application Insights connection string.");
var connectionString = projectClient.Telemetry.GetApplicationInsightsConnectionString();
Console.WriteLine($"Connection string: {connectionString}");
```

## Asynchronous Sample
```C# Snippet:AI_Projects_TelemetryExampleAsync
var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());

Console.WriteLine("Get the Application Insights connection string.");
var connectionString = await projectClient.Telemetry.GetApplicationInsightsConnectionStringAsync();
Console.WriteLine($"Connection string: {connectionString}");
```
