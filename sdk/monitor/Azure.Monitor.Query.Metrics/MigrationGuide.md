# Guide for migrating from `Azure.Monitor.Query` to `Azure.Monitor.Query.Metrics`

This guide assists in migrating querying metrics operations in `Azure.Monitor.Query` to the dedicated `Azure.Monitor.Query.Metrics` library.

## Table of contents

- [Migration benefits](#migration-benefits)
- [Important changes](#important-changes)
    - [Package names](#package-names)
    - [Client differences](#client-differences)
    - [API changes](#api-changes)
    - [Query metrics from workspace](#query-metrics-from-workspace)
    - [Query resource metrics](#query-resource-metrics)
- [Additional samples](#additional-samples)

## Migration benefits

The Azure Monitor Query library for .NET has been modularized to provide more focused functionality. The operations for querying metrics have been moved from the combined `Azure.Monitor.Query` package which also included querying metrics to a dedicated `Azure.Monitor.Query.Metrics` package. This separation offers several advantages:

- Smaller dependency footprint for applications that only need to query metrics 
- More focused API design specific to metrics query operations
- Independent versioning allowing metrics functionality to evolve separately
- Clearer separation of concerns between metrics and metrics operations

## Important changes

### Package names

- Previous package for metrics query clients: `Azure.Monitor.Query`
- New package: `Azure.Monitor.Query.Metrics`

### Namespaces

The root namespace has changed to `Azure.Monitor.Query.Metrics` in the new package.  The namespace hierarchy has otherwise remained unchanged.

### Client differences

`MetricsQueryClient` in the `Azure.Monitor.Query` package  has moved to the new `Azure.Monitor.Query.Metrics` package in the new `Azure.Monitor.Query.Metrics` library. The client names and the client builder name remains the same in both libraries.

### API changes

The following API changes were made between `Azure.Monitor.Query` and `Azure.Monitor.Query.Metrics`:

| `Azure.Monitor.Query` | `Azure.Monitor.Query.Metrics`                                  | Notes                                           |
|------------------------|-------------------------------------------------------------|-------------------------------------------------|
| `Azure.Monitor.Query.QueryTimeRange ` | `Azure.Monitor.Query.Metrics.MetricsQueryTimeRange ` | Used to specify the time range for metrics queries |

It is recommended that code using the previous `QueryTimeRange` class be updated to make use of the `StartTime` and `EndTime` members directly available on `QueryMetricsResources`

Previous code:
```C#
string resourceId =
    "/subscriptions/<id>/resourceGroups/<rg-name>/providers/<source>/storageAccounts/<resource-name-1>";
var client = new MetricsClient(
    new Uri("https://<region>.metrics.monitor.azure.com"),
    new DefaultAzureCredential());
    
var timeRange = new QueryTimeRange(
    start: Recording.UtcNow.Subtract(TimeSpan.FromHours(4)),
    duration: TimeSpan.FromHours(4));
    
var options = new MetricsQueryResourcesOptions
{
    TimeRange = timeRange,
    OrderBy = "sum asc",
    Size = 10
};

Response<MetricsQueryResourcesResult> result = await client.QueryResourcesAsync(
    resourceIds: new List<ResourceIdentifier> { new ResourceIdentifier(resourceId) },
    metricNames: new List<string> { "Ingress" },
    metricNamespace: "Microsoft.Storage/storageAccounts",
    options).ConfigureAwait(false);

MetricsQueryResourcesResult metricsQueryResults = result.Value;
foreach (MetricsQueryResult value in metricsQueryResults.Values)
{
    Console.WriteLine(value.Metrics.Count);
}
```

New code:
```C# Snippet:Query_Metrics_QueryResourcesMetricsWithOptionsStartTimeEndTime
string resourceId =
    "/subscriptions/<id>/resourceGroups/<rg-name>/providers/<source>/storageAccounts/<resource-name-1>";
var client = new MetricsClient(
    new Uri("https://<region>.metrics.monitor.azure.com"),
    new DefaultAzureCredential());
var options = new MetricsQueryResourcesOptions
{
    StartTime = DateTimeOffset.Now.AddHours(-4),
    EndTime = DateTimeOffset.Now.AddHours(-1),
    OrderBy = "sum asc",
    Size = 10
};

Response<MetricsQueryResourcesResult> result = await client.QueryResourcesAsync(
    resourceIds: new List<ResourceIdentifier> { new ResourceIdentifier(resourceId) },
    metricNames: new List<string> { "Ingress" },
    metricNamespace: "Microsoft.Storage/storageAccounts",
    options).ConfigureAwait(false);

MetricsQueryResourcesResult metricsQueryResults = result.Value;
foreach (MetricsQueryResult value in metricsQueryResults.Values)
{
    Console.WriteLine(value.Metrics.Count);
}
```

### Query metrics for multiple resources

Previous code:
```C# Snippet:QueryResourcesMetrics
string resourceId =
    "/subscriptions/<id>/resourceGroups/<rg-name>/providers/<source>/storageAccounts/<resource-name-1>";
var client = new MetricsClient(
    new Uri("https://<region>.metrics.monitor.azure.com"),
    new DefaultAzureCredential());
Response<MetricsQueryResourcesResult> result = await client.QueryResourcesAsync(
    resourceIds: new List<ResourceIdentifier> { new ResourceIdentifier(resourceId) },
    metricNames: new List<string> { "Ingress" },
    metricNamespace: "Microsoft.Storage/storageAccounts").ConfigureAwait(false);

MetricsQueryResourcesResult metricsQueryResults = result.Value;
foreach (MetricsQueryResult value in metricsQueryResults.Values)
{
    Console.WriteLine(value.Metrics.Count);
}
```

New code:
```C# Snippet:Query_Metrics_QueryResourcesMetrics
string resourceId =
    "/subscriptions/<id>/resourceGroups/<rg-name>/providers/<source>/storageAccounts/<resource-name-1>";
var client = new MetricsClient(
    new Uri("https://<region>.metrics.monitor.azure.com"),
    new DefaultAzureCredential());
Response<MetricsQueryResourcesResult> result = await client.QueryResourcesAsync(
    resourceIds: new List<ResourceIdentifier> { new ResourceIdentifier(resourceId) },
    metricNames: new List<string> { "Ingress" },
    metricNamespace: "Microsoft.Storage/storageAccounts").ConfigureAwait(false);

MetricsQueryResourcesResult metricsQueryResults = result.Value;
foreach (MetricsQueryResult value in metricsQueryResults.Values)
{
    Console.WriteLine(value.Metrics.Count);
}
```

#### Query metrics with options

Previous code:

```C# Snippet:QueryResourcesMetricsWithOptions
string resourceId =
    "/subscriptions/<id>/resourceGroups/<rg-name>/providers/<source>/storageAccounts/<resource-name-1>";
var client = new MetricsClient(
    new Uri("https://<region>.metrics.monitor.azure.com"),
    new DefaultAzureCredential());
var options = new MetricsQueryResourcesOptions
{
    OrderBy = "sum asc",
    Size = 10
};

Response<MetricsQueryResourcesResult> result = await client.QueryResourcesAsync(
    resourceIds: new List<ResourceIdentifier> { new ResourceIdentifier(resourceId) },
    metricNames: new List<string> { "Ingress" },
    metricNamespace: "Microsoft.Storage/storageAccounts",
    options).ConfigureAwait(false);

MetricsQueryResourcesResult metricsQueryResults = result.Value;
foreach (MetricsQueryResult value in metricsQueryResults.Values)
{
    Console.WriteLine(value.Metrics.Count);
}
```

New code:

```C# Snippet:Query_Metrics_QueryResourcesMetricsWithOptions
string resourceId =
    "/subscriptions/<id>/resourceGroups/<rg-name>/providers/<source>/storageAccounts/<resource-name-1>";
var client = new MetricsClient(
    new Uri("https://<region>.metrics.monitor.azure.com"),
    new DefaultAzureCredential());
var options = new MetricsQueryResourcesOptions
{
    OrderBy = "sum asc",
    Size = 10
};

Response<MetricsQueryResourcesResult> result = await client.QueryResourcesAsync(
    resourceIds: new List<ResourceIdentifier> { new ResourceIdentifier(resourceId) },
    metricNames: new List<string> { "Ingress" },
    metricNamespace: "Microsoft.Storage/storageAccounts",
    options).ConfigureAwait(false);

MetricsQueryResourcesResult metricsQueryResults = result.Value;
foreach (MetricsQueryResult value in metricsQueryResults.Values)
{
    Console.WriteLine(value.Metrics.Count);
}
```

## Additional samples

More examples can be found in the [Azure Monitor Query Metrics samples][metrics-samples].

<!-- Links -->
[metrics-samples]: https://github.com/Azure/azure-sdk-for-java/blob/main/sdk/monitor/Azure.Monitor.Query.Metrics/src/samples/README.md