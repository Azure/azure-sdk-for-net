# Azure Monitor Query Metrics client library for .NET

The Azure Monitor Query Metrics client library is used to execute read-only queries for metrics across multiple Azure resources in a single request.

[Metrics](https://learn.microsoft.com/azure/azure-monitor/essentials/data-platform-metrics) - Collects numeric data from monitored resources into a time series database. Metrics are numerical values that are collected at regular intervals and describe some aspect of a system at a particular time. Metrics are lightweight and capable of supporting near real-time scenarios, making them useful for alerting and fast detection of issues.

**Resources:**

- [Source code][source]
- [NuGet package][package]
- [API reference documentation][msdocs_apiref]
- [Service documentation][azure_monitor_overview]
- [Change log][changelog]

## Getting started

### Prerequisites

- An [Azure subscription][azure_subscription]
- A [TokenCredential](https://learn.microsoft.com/dotnet/api/azure.core.tokencredential?view=azure-dotnet) implementation, such as an [Azure Identity library credential type](https://learn.microsoft.com/dotnet/api/overview/azure/Identity-readme#credential-classes).
- To query Metrics, you need an Azure resource of any kind (Storage Account, Key Vault, Cosmos DB, etc.).

### Install the package

Install the Azure Monitor Query Metrics client library for .NET with NuGet:

```dotnetcli
dotnet add package Azure.Monitor.Query.Metrics
```

### Authenticate the client

An authenticated client is required to query Metrics. To authenticate, create an instance of a `TokenCredential` class. Pass it to the constructor of the `MetricsClient` class. To satisfy the `TokenCredential` requirement, the following examples use `DefaultAzureCredential` from the `Azure.Identity` package.

For Metrics queries across multiple Azure resources, use the following client:

```C# Snippet:Query_Metrics_CreateMetricsClient
var client = new MetricsClient(
    new Uri("https://<region>.metrics.monitor.azure.com"),
    new DefaultAzureCredential());
```

#### Configure client for Azure sovereign cloud

By default, `MetricsClient` is configured to use the Azure Public Cloud. To use a sovereign cloud instead, set the `Audience` property on the `MetricsClientOptions` class. For example:

```C# Snippet:Query_Metrics_CreateClientsWithOptions
// MetricsClient
var metricsClientOptions = new MetricsClientOptions
{
    Audience = MetricsClientAudience.AzureGovernment
};
var metricsClient = new MetricsClient(
    new Uri("https://usgovvirginia.metrics.monitor.azure.us"),
    new DefaultAzureCredential(),
    metricsClientOptions);
```

### Execute the query

For examples of Metrics queries, see the [Examples](#examples) section.

## Key concepts

### Metrics data structure

Each set of metric values is a time series with the following characteristics:

- The time the value was collected
- The resource associated with the value
- A namespace that acts like a category for the metric
- A metric name
- The value itself
- Some metrics have multiple dimensions as described in multi-dimensional metrics. Custom metrics can have up to 10 dimensions.

### Thread safety

All client instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This design ensures that the recommendation of reusing client instances is always safe, even across threads.

### Additional concepts

<!-- CLIENT COMMON BAR -->
[Client options](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Accessing the response](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#accessing-http-response-details-using-responset) |
[Long-running operations](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#consuming-long-running-operations-using-operationt) |
[Handling failures](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md) |
[Mocking](https://learn.microsoft.com/dotnet/azure/sdk/unit-testing-mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
<!-- CLIENT COMMON BAR -->

## Examples

- [Query metrics for multiple resources](#query-metrics-for-multiple-resources)
  - [Query with options](#query-metrics-with-options)
  - [Query with time range](#query-metrics-with-time-range)
- [Register the client with dependency injection](#register-the-client-with-dependency-injection)

### Query metrics for multiple resources

To query metrics for multiple Azure resources in a single request, use the `MetricsClient.QueryResourcesAsync` method. This method:

- Calls a regional metrics endpoint. You must specify the regional endpoint when creating the client. For example, "https://westus3.metrics.monitor.azure.com".
- Requires that each Azure resource must reside in:
  - The same region as the endpoint specified when creating the client.
  - The same Azure subscription.

Furthermore:

- The user must be authorized to read monitoring data at the Azure subscription level. For example, the [Monitoring Reader role](https://learn.microsoft.com/azure/role-based-access-control/built-in-roles/monitor#monitoring-reader) on the subscription to be queried.
- The metric namespace containing the metrics to be queried must be provided. For a list of metric namespaces, see [Supported metrics and log categories by resource type][metric_namespaces].

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

For an inventory of metrics and dimensions available for each Azure resource type, see [Supported metrics with Azure Monitor](https://learn.microsoft.com/azure/azure-monitor/essentials/metrics-supported).

#### Query metrics with options

The `QueryResourcesAsync` method also accepts a `MetricsQueryResourcesOptions`-typed argument, in which the user can specify extra properties to filter the results. The following example demonstrates the `OrderBy` and `Size` properties:

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

#### Query metrics with time range

The `MetricsQueryResourcesOptions`-typed argument also has a `StartTime` and `EndTime` property to allow for querying a specific time range. If only the `StartTime` is set, the `EndTime` default becomes the current time. When the `EndTime` is specified, the `StartTime` is necessary as well. The following example demonstrates the use of these properties:

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

### Register the client with dependency injection

To register a client with the dependency injection container, invoke the `AddMetricsClient` extension method.

For more information, see [Register client](https://learn.microsoft.com/dotnet/azure/sdk/dependency-injection#register-client).

## Troubleshooting

To diagnose various failure scenarios, see the [troubleshooting guide](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/monitor/Azure.Monitor.Query.Metrics/TROUBLESHOOTING.md).

## Next steps

To learn more about Azure Monitor, see the [Azure Monitor service documentation][azure_monitor_overview].

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately with labels and comments. Follow the instructions provided by the bot. You'll only need to sign the CLA once across all Microsoft repos.

This project has adopted the [Microsoft Open Source Code of Conduct][coc]. For more information, see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com][coc_contact] with any questions or comments.

[azure_monitor_overview]: https://learn.microsoft.com/azure/azure-monitor/overview
[azure_subscription]: https://azure.microsoft.com/free/dotnet/
[changelog]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/monitor/Azure.Monitor.Query.Metrics/CHANGELOG.md
[metric_namespaces]: https://learn.microsoft.com/azure/azure-monitor/reference/supported-metrics/metrics-index#supported-metrics-and-log-categories-by-resource-type
[msdocs_apiref]: https://learn.microsoft.com/dotnet/api/overview/azure/monitor.query.metrics-readme?view=azure-dotnet
[package]: https://www.nuget.org/packages/Azure.Monitor.Query.Metrics
[source]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/monitor/Azure.Monitor.Query.Metrics/src

[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
