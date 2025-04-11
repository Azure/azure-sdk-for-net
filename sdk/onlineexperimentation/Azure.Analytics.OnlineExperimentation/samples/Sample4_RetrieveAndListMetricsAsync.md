# Retrieving and Listing Metrics Asynchronously

This sample demonstrates how to retrieve a specific metric and how to list all metrics in your experimentation workspace using asynchronous operations.

## Retrieving a Single Metric

Get a specific metric by ID to access its properties.

```C# Snippet:OnlineExperimentation_RetrieveMetricAsync
var endpoint = new Uri(Environment.GetEnvironmentVariable("AZURE_ONLINEEXPERIMENTATION_ENDPOINT"));
var client = new OnlineExperimentationClient(endpoint, new DefaultAzureCredential());

// Get a specific metric by ID
var metric = await client.GetMetricAsync("avg_revenue_per_purchase");

// Access metric properties to view or use the metric definition
Console.WriteLine($"Metric ID: {metric.Value.Id}");
Console.WriteLine($"Display name: {metric.Value.DisplayName}");
Console.WriteLine($"Description: {metric.Value.Description}");
Console.WriteLine($"Lifecycle stage: {metric.Value.Lifecycle}");
Console.WriteLine($"Desired direction: {metric.Value.DesiredDirection}");
```

## Listing All Metrics

Retrieve a list of all metrics in the workspace.

```C# Snippet:OnlineExperimentation_ListMetricsAsync
var endpoint = new Uri(Environment.GetEnvironmentVariable("AZURE_ONLINEEXPERIMENTATION_ENDPOINT"));
var client = new OnlineExperimentationClient(endpoint, new DefaultAzureCredential());

// List all metrics in the workspace
Console.WriteLine("Listing all metrics:");
await foreach (var item in client.GetMetricsAsync())
{
    Console.WriteLine($"- {item.Id}: {item.DisplayName}");
}
```
