# Azure Monitor Query client library for .NET

The Azure Monitor Query client library is used to execute read-only queries against [Azure Monitor][azure_monitor_overview]'s two data platforms:

- [Logs](https://learn.microsoft.com/azure/azure-monitor/logs/data-platform-logs) - Collects and organizes log and performance data from monitored resources. Data from different sources such as platform logs from Azure services, log and performance data from virtual machines agents, and usage and performance data from apps can be consolidated into a single [Azure Log Analytics workspace](https://learn.microsoft.com/azure/azure-monitor/logs/data-platform-logs#log-analytics-and-workspaces). The various data types can be analyzed together using the [Kusto Query Language][kusto_query_language].
- [Metrics](https://learn.microsoft.com/azure/azure-monitor/essentials/data-platform-metrics) - Collects numeric data from monitored resources into a time series database. Metrics are numerical values that are collected at regular intervals and describe some aspect of a system at a particular time. Metrics are lightweight and capable of supporting near real-time scenarios, making them useful for alerting and fast detection of issues.

**Resources:**

- [Source code][source]
- [NuGet package][package]
- [API reference documentation][msdocs_apiref]
- [Service documentation][azure_monitor_overview]
- [Change log][changelog]
- [Migration guide from Application Insights][migration_guide_app_insights]
- [Migration guide from Operational Insights][migration_guide_opp_insights]

## Getting started

### Prerequisites

- An [Azure subscription][azure_subscription]
- A [TokenCredential](https://learn.microsoft.com/dotnet/api/azure.core.tokencredential?view=azure-dotnet) implementation, such as an [Azure Identity library credential type](https://learn.microsoft.com/dotnet/api/overview/azure/Identity-readme#credential-classes).
- To query Logs, you need one of the following things:
  - An [Azure Log Analytics workspace][azure_monitor_create_using_portal]
  - An Azure resource of any kind (Storage Account, Key Vault, Cosmos DB, etc.)
- To query Metrics, you need an Azure resource of any kind (Storage Account, Key Vault, Cosmos DB, etc.).

### Install the package

Install the Azure Monitor Query client library for .NET with NuGet:

```dotnetcli
dotnet add package Azure.Monitor.Query
```

### Authenticate the client

An authenticated client is required to query Logs or Metrics. To authenticate, create an instance of a `TokenCredential` class. Pass it to the constructor of the `LogsQueryClient` or `MetricsQueryClient` class.

To authenticate, the following examples use `DefaultAzureCredential` from the `Azure.Identity` package:

```C# Snippet:CreateLogsClient
var client = new LogsQueryClient(new DefaultAzureCredential());
```

```C# Snippet:CreateMetricsClient
var client = new MetricsQueryClient(new DefaultAzureCredential());
```

### Execute the query

For examples of Logs and Metrics queries, see the [Examples](#examples) section.

## Key concepts

### Logs query rate limits and throttling

The Log Analytics service applies throttling when the request rate is too high. Limits, such as the maximum number of rows returned, are also applied on the Kusto queries. For more information, see [Query API](https://learn.microsoft.com/azure/azure-monitor/service-limits#la-query-api).

### Metrics data structure

Each set of metric values is a time series with the following characteristics:

- The time the value was collected
- The resource associated with the value
- A namespace that acts like a category for the metric
- A metric name
- The value itself
- Some metrics may have multiple dimensions as described in multi-dimensional metrics. Custom metrics can have up to 10 dimensions.

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

- [Logs query](#logs-query)
  - [Handle logs query response](#handle-logs-query-response)
  - [Map logs query results to a model](#map-logs-query-results-to-a-model)
  - [Map logs query results to a primitive](#map-logs-query-results-to-a-primitive)
  - [Print logs query results as a table](#print-logs-query-results-as-a-table)
- [Batch logs query](#batch-logs-query)
- [Advanced logs query scenarios](#advanced-logs-query-scenarios)
  - [Set logs query timeout](#set-logs-query-timeout)
  - [Query multiple workspaces](#query-multiple-workspaces)
  - [Include statistics](#include-statistics)
  - [Include visualization](#include-visualization)
- [Metrics query](#metrics-query)
  - [Handle metrics query response](#handle-metrics-query-response)
  - [Query metrics with options](#query-metrics-with-options)
  - [Get metrics namespaces](#get-metrics-namespaces)
  - [Split a metric by dimension](#split-a-metric-by-dimension)
- [Register the client with dependency injection](#register-the-client-with-dependency-injection)

### Logs query

You can query logs by workspace ID or resource ID. The result is returned as a table with a collection of rows.

**Workspace-centric logs query**

To query by workspace ID, use the [LogsQueryClient.QueryWorkspaceAsync](https://learn.microsoft.com/dotnet/api/azure.monitor.query.logsqueryclient.queryworkspaceasync) method:

```C# Snippet:QueryLogsAsTable
string workspaceId = "<workspace_id>";
var client = new LogsQueryClient(new DefaultAzureCredential());

Response<LogsQueryResult> result = await client.QueryWorkspaceAsync(
    workspaceId,
    "AzureActivity | top 10 by TimeGenerated",
    new QueryTimeRange(TimeSpan.FromDays(1)));

LogsTable table = result.Value.Table;

foreach (var row in table.Rows)
{
    Console.WriteLine($"{row["OperationName"]} {row["ResourceGroup"]}");
}
```

**Resource-centric logs query**

To query by resource ID, use the [LogsQueryClient.QueryResourceAsync](https://learn.microsoft.com/dotnet/api/azure.monitor.query.logsqueryclient.queryresourceasync) method.

To find the resource ID:

1. Navigate to your resource's page in the Azure portal.
1. From the **Overview** blade, select the **JSON View** link.
1. In the resulting JSON, copy the value of the `id` property.

```C# Snippet:QueryResource
var client = new LogsQueryClient(new DefaultAzureCredential());

string resourceId = "/subscriptions/<subscription_id>/resourceGroups/<resource_group_name>/providers/<resource_provider>/<resource>";
string tableName = "<table_name>";
Response<LogsQueryResult> results = await client.QueryResourceAsync(
    new ResourceIdentifier(resourceId),
    $"{tableName} | distinct * | project TimeGenerated",
    new QueryTimeRange(TimeSpan.FromDays(7)));

LogsTable resultTable = results.Value.Table;
foreach (LogsTableRow row in resultTable.Rows)
{
    Console.WriteLine($"{row["OperationName"]} {row["ResourceGroup"]}");
}

foreach (LogsTableColumn columns in resultTable.Columns)
{
    Console.WriteLine("Name: " + columns.Name + " Type: " + columns.Type);
}
```

#### Handle logs query response

The `QueryWorkspace` method returns the `LogsQueryResult`, while the `QueryBatch` method returns the `LogsBatchQueryResult`. Here's a hierarchy of the response:

```
LogsQueryResult
|---Error
|---Status
|---Table
    |---Name
    |---Columns (list of `LogsTableColumn` objects)
        |---Name
        |---Type
    |---Rows (list of `LogsTableRows` objects)
        |---Count
|---AllTables (list of `LogsTable` objects)
```

#### Map logs query results to a model

You can map logs query results to a model using the `LogsQueryClient.QueryWorkspaceAsync<T>` method:

```C# Snippet:QueryLogsAsModelsModel
public class MyLogEntryModel
{
    public string ResourceGroup { get; set; }
    public int Count { get; set; }
}
```

```C# Snippet:QueryLogsAsModels
var client = new LogsQueryClient(new DefaultAzureCredential());
string workspaceId = "<workspace_id>";

// Query TOP 10 resource groups by event count
Response<IReadOnlyList<MyLogEntryModel>> response = await client.QueryWorkspaceAsync<MyLogEntryModel>(
    workspaceId,
    "AzureActivity | summarize Count = count() by ResourceGroup | top 10 by Count",
    new QueryTimeRange(TimeSpan.FromDays(1)));

foreach (var logEntryModel in response.Value)
{
    Console.WriteLine($"{logEntryModel.ResourceGroup} had {logEntryModel.Count} events");
}
```

#### Map logs query results to a primitive

If your query returns a single column (or a single value) of a primitive type, use the `LogsQueryClient.QueryWorkspaceAsync<T>` overload to deserialize it:

```C# Snippet:QueryLogsAsPrimitive
string workspaceId = "<workspace_id>";

var client = new LogsQueryClient(new DefaultAzureCredential());

// Query TOP 10 resource groups by event count
Response<IReadOnlyList<string>> response = await client.QueryWorkspaceAsync<string>(
    workspaceId,
    "AzureActivity | summarize Count = count() by ResourceGroup | top 10 by Count | project ResourceGroup",
    new QueryTimeRange(TimeSpan.FromDays(1)));

foreach (var resourceGroup in response.Value)
{
    Console.WriteLine(resourceGroup);
}
```

#### Print logs query results as a table

You can also dynamically inspect the list of columns. The following example prints the query result as a table:

```C# Snippet:QueryLogsPrintTable
string workspaceId = "<workspace_id>";

var client = new LogsQueryClient(new DefaultAzureCredential());
Response<LogsQueryResult> response = await client.QueryWorkspaceAsync(
    workspaceId,
    "AzureActivity | top 10 by TimeGenerated",
    new QueryTimeRange(TimeSpan.FromDays(1)));

LogsTable table = response.Value.Table;

foreach (var column in table.Columns)
{
    Console.Write(column.Name + ";");
}

Console.WriteLine();

var columnCount = table.Columns.Count;
foreach (var row in table.Rows)
{
    for (int i = 0; i < columnCount; i++)
    {
        Console.Write(row[i] + ";");
    }

    Console.WriteLine();
}
```

### Batch logs query

You can execute multiple logs queries in a single request using the `LogsQueryClient.QueryBatchAsync` method:

```C# Snippet:BatchQuery
string workspaceId = "<workspace_id>";

var client = new LogsQueryClient(new DefaultAzureCredential());

// Query TOP 10 resource groups by event count
// And total event count
var batch = new LogsBatchQuery();

string countQueryId = batch.AddWorkspaceQuery(
    workspaceId,
    "AzureActivity | count",
    new QueryTimeRange(TimeSpan.FromDays(1)));
string topQueryId = batch.AddWorkspaceQuery(
    workspaceId,
    "AzureActivity | summarize Count = count() by ResourceGroup | top 10 by Count",
    new QueryTimeRange(TimeSpan.FromDays(1)));

Response<LogsBatchQueryResultCollection> response = await client.QueryBatchAsync(batch);

var count = response.Value.GetResult<int>(countQueryId).Single();
var topEntries = response.Value.GetResult<MyLogEntryModel>(topQueryId);

Console.WriteLine($"AzureActivity has total {count} events");
foreach (var logEntryModel in topEntries)
{
    Console.WriteLine($"{logEntryModel.ResourceGroup} had {logEntryModel.Count} events");
}
```

### Advanced logs query scenarios

#### Set logs query timeout

Some logs queries take longer than 3 minutes to execute. The default server timeout is 3 minutes. You can increase the server timeout to a maximum of 10 minutes. In the following example, the `LogsQueryOptions` object's `ServerTimeout` property is used to set the server timeout to 10 minutes:

```C# Snippet:QueryLogsWithTimeout
string workspaceId = "<workspace_id>";

var client = new LogsQueryClient(new DefaultAzureCredential());

// Query TOP 10 resource groups by event count
Response<IReadOnlyList<string>> response = await client.QueryWorkspaceAsync<string>(
    workspaceId,
    @"AzureActivity
        | summarize Count = count() by ResourceGroup
        | top 10 by Count
        | project ResourceGroup",
    new QueryTimeRange(TimeSpan.FromDays(1)),
    new LogsQueryOptions
    {
        ServerTimeout = TimeSpan.FromMinutes(10)
    });

foreach (var resourceGroup in response.Value)
{
    Console.WriteLine(resourceGroup);
}
```

#### Query multiple workspaces

To run the same logs query against multiple workspaces, use the `LogsQueryOptions.AdditionalWorkspaces` property:

```C# Snippet:QueryLogsWithAdditionalWorkspace
string workspaceId = "<workspace_id>";
string additionalWorkspaceId = "<additional_workspace_id>";

var client = new LogsQueryClient(new DefaultAzureCredential());

// Query TOP 10 resource groups by event count
Response<IReadOnlyList<string>> response = await client.QueryWorkspaceAsync<string>(
    workspaceId,
    @"AzureActivity
        | summarize Count = count() by ResourceGroup
        | top 10 by Count
        | project ResourceGroup",
    new QueryTimeRange(TimeSpan.FromDays(1)),
    new LogsQueryOptions
    {
        AdditionalWorkspaces = { additionalWorkspaceId }
    });

foreach (var resourceGroup in response.Value)
{
    Console.WriteLine(resourceGroup);
}
```

#### Include statistics

To get logs query execution statistics, such as CPU and memory consumption:

1. Set the `LogsQueryOptions.IncludeStatistics` property to `true`.
2. Invoke the `GetStatistics` method on the `LogsQueryResult` object.

The following example prints the query execution time:

```C# Snippet:QueryLogsWithStatistics
string workspaceId = "<workspace_id>";
var client = new LogsQueryClient(new DefaultAzureCredential());

Response<LogsQueryResult> response = await client.QueryWorkspaceAsync(
    workspaceId,
    "AzureActivity | top 10 by TimeGenerated",
    new QueryTimeRange(TimeSpan.FromDays(1)),
    new LogsQueryOptions
    {
        IncludeStatistics = true,
    });

BinaryData stats = response.Value.GetStatistics();
using var statsDoc = JsonDocument.Parse(stats);
var queryStats = statsDoc.RootElement.GetProperty("query");
Console.WriteLine(queryStats.GetProperty("executionTime").GetDouble());
```

Because the structure of the statistics payload varies by query, a `BinaryData` return type is used. It contains the raw JSON response. The statistics are found within the `query` property of the JSON. For example:

```json
{
  "query": {
    "executionTime": 0.0156478,
    "resourceUsage": {...},
    "inputDatasetStatistics": {...},
    "datasetStatistics": [{...}]
  }
}
```

#### Include visualization

To get visualization data for logs queries using the [render operator](https://learn.microsoft.com/azure/data-explorer/kusto/query/renderoperator?pivots=azuremonitor):

1. Set the `LogsQueryOptions.IncludeVisualization` property to `true`.
2. Invoke the `GetVisualization` method on the `LogsQueryResult` object.

For example:

```C# Snippet:QueryLogsWithVisualization
string workspaceId = "<workspace_id>";
var client = new LogsQueryClient(new DefaultAzureCredential());

Response<LogsQueryResult> response = await client.QueryWorkspaceAsync(
    workspaceId,
    @"StormEvents
        | summarize event_count = count() by State
        | where event_count > 10
        | project State, event_count
        | render columnchart",
    new QueryTimeRange(TimeSpan.FromDays(1)),
    new LogsQueryOptions
    {
        IncludeVisualization = true,
    });

BinaryData viz = response.Value.GetVisualization();
using var vizDoc = JsonDocument.Parse(viz);
var queryViz = vizDoc.RootElement.GetProperty("visualization");
Console.WriteLine(queryViz.GetString());
```

Because the structure of the visualization payload varies by query, a `BinaryData` return type is used. It contains the raw JSON response. For example:

```json
{
  "visualization": "columnchart",
  "title": null,
  "accumulate": false,
  "isQuerySorted": false,
  "kind": null,
  "legend": null,
  "series": null,
  "yMin": "",
  "yMax": "",
  "xAxis": null,
  "xColumn": null,
  "xTitle": null,
  "yAxis": null,
  "yColumns": null,
  "ySplit": null,
  "yTitle": null,
  "anomalyColumns": null
}
```

### Metrics query

You can query metrics on an Azure resource using the `MetricsQueryClient.QueryResourceAsync` method. For each requested metric, a set of aggregated values is returned inside the `TimeSeries` collection.

A resource ID is required to query metrics. To find the resource ID:

1. Navigate to your resource's page in the Azure portal.
2. From the **Overview** blade, select the **JSON View** link.
3. In the resulting JSON, copy the value of the `id` property.

```C# Snippet:QueryMetrics
string resourceId =
    "/subscriptions/<subscription_id>/resourceGroups/<resource_group_name>/providers/<resource_provider>/<resource>";
var client = new MetricsQueryClient(new DefaultAzureCredential());

Response<MetricsQueryResult> results = await client.QueryResourceAsync(
    resourceId,
    new[] { "AvailabilityRate_Query", "Query Count" }
);

foreach (MetricResult metric in results.Value.Metrics)
{
    Console.WriteLine(metric.Name);
    foreach (MetricTimeSeriesElement element in metric.TimeSeries)
    {
        Console.WriteLine("Dimensions: " + string.Join(",", element.Metadata));

        foreach (MetricValue value in element.Values)
        {
            Console.WriteLine(value);
        }
    }
}
```

#### Handle metrics query response

The metrics query API returns a `MetricsQueryResult` object. The `MetricsQueryResult` object contains properties such as a list of `MetricResult`-typed objects, `Cost`, `Namespace`, `ResourceRegion`, `TimeSpan`, and `Interval`. The `MetricResult` objects list can be accessed using the `metrics` param. Each `MetricResult` object in this list contains a list of `MetricTimeSeriesElement` objects. Each `MetricTimeSeriesElement` object contains `Metadata` and `Values` properties.

Here's a hierarchy of the response:

```
MetricsQueryResult
|---Cost
|---Granularity
|---Namespace
|---ResourceRegion
|---TimeSpan
|---Metrics (list of `MetricResult` objects)
    |---Id
    |---ResourceType
    |---Name
    |---Description
    |---Error
    |---Unit
    |---TimeSeries (list of `MetricTimeSeriesElement` objects)
        |---Metadata
        |---Values
```

#### Query metrics with options

A `MetricsQueryOptions` object may be used to support more granular metrics queries. Consider the following example, which queries an Azure Key Vault resource named *TestVault*. The resource's "Vault requests availability" metric is requested, as indicated by metric ID "Availability". Additionally, the "Avg" aggregation type is included.

```C# Snippet:QueryMetricsWithAggregations
string resourceId =
    "/subscriptions/<subscription_id>/resourceGroups/<resource_group_name>/providers/Microsoft.KeyVault/vaults/TestVault";
string[] metricNames = new[] { "Availability" };
var client = new MetricsQueryClient(new DefaultAzureCredential());

Response<MetricsQueryResult> result = await client.QueryResourceAsync(
    resourceId,
    metricNames,
    new MetricsQueryOptions
    {
        Aggregations =
        {
            MetricAggregationType.Average,
        }
    });

MetricResult metric = result.Value.Metrics[0];

foreach (MetricTimeSeriesElement element in metric.TimeSeries)
{
    foreach (MetricValue value in element.Values)
    {
        // Prints a line that looks like the following:
        // 6/21/2022 12:29:00 AM +00:00 : 100
        Console.WriteLine($"{value.TimeStamp} : {value.Average}");
    }
}
```

#### Get metrics namespaces

To programmatically retrieve metrics namespaces, use the following code:
    
```C# Snippet:GetMetricsNamespaces
string resourceId =
    "/subscriptions/<subscription_id>/resourceGroups/<resource_group_name>/providers/Microsoft.Web/sites/TestWebApp";
var client = new MetricsQueryClient(new DefaultAzureCredential());
AsyncPageable<MetricNamespace> metricNamespaces = client.GetMetricNamespacesAsync(resourceId);

await foreach (var metricNamespace in metricNamespaces)
{
    Console.WriteLine($"Metric namespace = {metricNamespace.Name}");
}
```

#### Split a metric by dimension

The [MetricsQueryOptions.Filter](https://learn.microsoft.com/dotnet/api/azure.monitor.query.metricsqueryoptions.filter?view=azure-dotnet#azure-monitor-query-metricsqueryoptions-filter) property can be used for [splitting a metric](https://learn.microsoft.com/azure/azure-monitor/essentials/metrics-charts#metric-splitting) by a dimension when its filter value is set to an asterisk. Consider the following example for an App Service resource named *TestWebApp*. The code queries the resource's `Http2xx` metric and splits it by the `Instance` dimension.

```C# Snippet:QueryMetricsWithSplitting
string resourceId =
    "/subscriptions/<subscription_id>/resourceGroups/<resource_group_name>/providers/Microsoft.Web/sites/TestWebApp";
string[] metricNames = new[] { "Http2xx" };
// Use of asterisk in filter value enables splitting on Instance dimension.
string filter = "Instance eq '*'";
var client = new MetricsQueryClient(new DefaultAzureCredential());
var options = new MetricsQueryOptions
{
    Aggregations =
    {
        MetricAggregationType.Average,
    },
    Filter = filter,
    TimeRange = TimeSpan.FromDays(2),
};
Response<MetricsQueryResult> result = await client.QueryResourceAsync(
    resourceId,
    metricNames,
    options);

foreach (MetricResult metric in result.Value.Metrics)
{
    foreach (MetricTimeSeriesElement element in metric.TimeSeries)
    {
        foreach (MetricValue value in element.Values)
        {
            // Prints a line that looks like the following:
            // Thursday, May 4, 2023 9:42:00 PM, webwk000002, Http2xx, 1
            Console.WriteLine(
                $"{value.TimeStamp:F}, {element.Metadata["Instance"]}, {metric.Name}, {value.Average}");
        }
    }
}
```

#### Metrics batch query

A user can also query metrics from multiple resources at once using the `QueryBatch` method of `MetricsBatchQueryClient`. This uses a different API than the `MetricsQueryClient` and requires that a user pass in a regional endpoint when instantiating the client (for example, "https://westus3.metrics.monitor.azure.com").

Note, each resource must be in the same region as the endpoint passed in when instantiating the client, and each resource must be in the same Azure subscription. Furthermore, the metric namespace that contains the metrics to be queried must also be passed. A list of metric namespaces can be found [here][metric_namespaces].

```C# Snippet:QueryBatchMetrics
string resourceId =
    "/subscriptions/<id>/resourceGroups/<rg-name>/providers/<source>/storageAccounts/<resource-name-1>";
MetricsBatchQueryClient client = new MetricsBatchQueryClient(new Uri("https://metrics.monitor.azure.com/.default"), new DefaultAzureCredential());
Response<MetricsBatchResult> metricsResultsResponse = await client.QueryBatchAsync(
    resourceIds: new List<string> { resourceId },
    metricNames: new List<string> { "Ingress" },
    metricNamespace: "Microsoft.Storage/storageAccounts").ConfigureAwait(false);

MetricsBatchResult metricsQueryResults = metricsResultsResponse.Value;
foreach (var value in metricsQueryResults.Values)
{
    Console.WriteLine(value.Interval);
}
```

For an inventory of metrics and dimensions available for each Azure resource type, see [Supported metrics with Azure Monitor](https://learn.microsoft.com/azure/azure-monitor/essentials/metrics-supported).

#### Register the client with dependency injection

To register `LogsQueryClient` with the dependency injection (DI) container, invoke the `AddLogsQueryClient` method. To register `MetricsQueryClient` with the dependency injection (DI) container, invoke the `AddMetricsQueryClient` method. For more information, see [Register client](https://learn.microsoft.com/dotnet/azure/sdk/dependency-injection#register-client).

## Troubleshooting

To diagnose various failure scenarios, see the [troubleshooting guide](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/monitor/Azure.Monitor.Query/TROUBLESHOOTING.md).

## Next steps

To learn more about Azure Monitor, see the [Azure Monitor service documentation][azure_monitor_overview].

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately with labels and comments. Follow the instructions provided by the bot. You'll only need to sign the CLA once across all Microsoft repos.

This project has adopted the [Microsoft Open Source Code of Conduct][coc]. For more information, see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com][coc_contact] with any questions or comments.

[azure_monitor_create_using_portal]: https://learn.microsoft.com/azure/azure-monitor/logs/quick-create-workspace
[azure_monitor_overview]: https://learn.microsoft.com/azure/azure-monitor/overview
[azure_subscription]: https://azure.microsoft.com/free/dotnet/
[changelog]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/monitor/Azure.Monitor.Query/CHANGELOG.md
[kusto_query_language]: https://learn.microsoft.com/azure/data-explorer/kusto/query/
[migration_guide_app_insights]: https://aka.ms/azsdk/net/migrate/ai-monitor-query
[migration_guide_opp_insights]: https://aka.ms/azsdk/net/migrate/monitor-query
[msdocs_apiref]: https://learn.microsoft.com/dotnet/api/overview/azure/monitor.query-readme?view=azure-dotnet
[package]: https://www.nuget.org/packages/Azure.Monitor.Query
[source]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/monitor/Azure.Monitor.Query/src
[metric_namespaces]: https://learn.microsoft.com/azure/azure-monitor/reference/supported-metrics/metrics-index#metrics-by-resource-provider

[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fmonitor%2FAzure.Monitor.Query%2FREADME.png)
