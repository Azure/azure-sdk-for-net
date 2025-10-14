# Azure Monitor Query Logs client library for .NET

The Azure Monitor Query Logs client library is used to execute read-only queries against [Azure Monitor Logs](https://learn.microsoft.com/azure/azure-monitor/logs/data-platform-logs).

[Source code](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/monitor/Azure.Monitor.Query.Logs/src) | [Package (NuGet)](https://www.nuget.org/packages/Azure.Monitor.Query.Logs) | [API reference documentation](https://learn.microsoft.com/dotnet/api/overview/azure/monitor.query.logs-readme) | [Product documentation](https://learn.microsoft.com/azure/azure-monitor/) | [Samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/monitor/Azure.Monitor.Query.Logs/tests/LogsQueryClientSamples.cs)

## Getting started

### Prerequisites

- An [Azure subscription][azure_subscription]
- A [TokenCredential](https://learn.microsoft.com/dotnet/api/azure.core.tokencredential?view=azure-dotnet) implementation, such as an [Azure Identity library credential type](https://learn.microsoft.com/dotnet/api/overview/azure/Identity-readme#credential-classes).
- An [Azure Log Analytics workspace][azure_monitor_create_using_portal]
- An Azure resource of any kind (Storage Account, Key Vault, Cosmos DB, etc.)

### Install the package

Install the Azure Monitor Query Logs client library for .NET with NuGet:

```dotnetcli
dotnet add package Azure.Monitor.Query.Logs
```

### Authenticate the client

An authenticated `LogsQueryClient` is required to query logs. To authenticate, you'll pass an instance of a `TokenCredential` to the constructor when creating your client. For example, the following illustration uses `DefaultAzureCredential` for authentication.

#### Client for Logs queries

```C# Snippet:QueryLogs_CreateLogsClient
var client = new LogsQueryClient(new DefaultAzureCredential());
```

#### Configure the client for an Azure sovereign cloud

By default, the client is configured to use the Azure Public Cloud. To use a sovereign cloud instead, set the `Audience` property on the appropriate `Options`-suffixed class. For example:

```C# Snippet:QueryLogs_CreateClientsWithOptions
// LogsQueryClient - by default, Azure Public Cloud is used
var logsQueryClient = new LogsQueryClient(
    new DefaultAzureCredential());

// LogsQueryClient With Audience Set
var logsQueryClientOptions = new LogsQueryClientOptions
{
    Audience = LogsQueryAudience.AzureChina
};

var logsQueryClientChina = new LogsQueryClient(
    new DefaultAzureCredential(),
    logsQueryClientOptions);
```

### Execute the query

For examples of Logs and Metrics queries, see the [Examples](#examples) section.

## Key concepts

### Logs query rate limits and throttling

The Log Analytics service applies throttling when the request rate is too high. Limits, such as the maximum number of rows returned, are also applied on the Kusto queries. For more information, see [Query API](https://learn.microsoft.com/azure/azure-monitor/service-limits#la-query-api).

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
  - [Workspace-centric logs query](#workspace-centric-logs-query)
  - [Resource-centric logs query](#resource-centric-logs-query)
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
- [Register the client with dependency injection](#register-the-client-with-dependency-injection)

### Logs query

You can query logs by Log Analytics workspace ID or Azure resource ID. The result is returned as a table with a collection of rows.

#### Workspace-centric logs query

To query by workspace ID, use the [LogsQueryClient.QueryWorkspaceAsync](https://learn.microsoft.com/dotnet/api/azure.monitor.query.logs.logsqueryclient.queryworkspaceasync) method:

```C# Snippet:QueryLogs_QueryLogsAsTable
string workspaceId = "<workspace_id>";
var client = new LogsQueryClient(new DefaultAzureCredential());

Response<LogsQueryResult> result = await client.QueryWorkspaceAsync(
    workspaceId,
    "AzureActivity | top 10 by TimeGenerated",
    new LogsQueryTimeRange(TimeSpan.FromDays(1)));

LogsTable table = result.Value.Table;

foreach (var row in table.Rows)
{
    Console.WriteLine($"{row["OperationName"]} {row["ResourceGroup"]}");
}
```

#### Resource-centric logs query

To query by resource ID, use the [LogsQueryClient.QueryResourceAsync](https://learn.microsoft.com/dotnet/api/azure.monitor.query.logsqueryclient.queryresourceasync) method.

To find the resource ID:

1. Navigate to your resource's page in the Azure portal.
1. From the **Overview** blade, select the **JSON View** link.
1. In the resulting JSON, copy the value of the `id` property.

```C# Snippet:QueryLogs_QueryResource
var client = new LogsQueryClient(new DefaultAzureCredential());

string resourceId = "/subscriptions/<subscription_id>/resourceGroups/<resource_group_name>/providers/<resource_provider>/<resource>";
string tableName = "<table_name>";
Response<LogsQueryResult> results = await client.QueryResourceAsync(
    new ResourceIdentifier(resourceId),
    $"{tableName} | distinct * | project TimeGenerated",
    new LogsQueryTimeRange(TimeSpan.FromDays(7)));

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

```C# Snippet:QueryLogs_QueryLogsAsModelsModel
public class MyLogEntryModel
{
    public string ResourceGroup { get; set; }
    public int Count { get; set; }
}
```

```C# Snippet:QueryLogs_QueryLogsAsModels
var client = new LogsQueryClient(new DefaultAzureCredential());
string workspaceId = "<workspace_id>";

// Query TOP 10 resource groups by event count
Response<IReadOnlyList<MyLogEntryModel>> response = await client.QueryWorkspaceAsync<MyLogEntryModel>(
    workspaceId,
    "AzureActivity | summarize Count = count() by ResourceGroup | top 10 by Count",
    new LogsQueryTimeRange(TimeSpan.FromDays(1)));

foreach (var logEntryModel in response.Value)
{
    Console.WriteLine($"{logEntryModel.ResourceGroup} had {logEntryModel.Count} events");
}
```

#### Map logs query results to a primitive

If your query returns a single column (or a single value) of a primitive type, use the `LogsQueryClient.QueryWorkspaceAsync<T>` overload to deserialize it:

```C# Snippet:QueryLogs_QueryLogsAsPrimitive
string workspaceId = "<workspace_id>";

var client = new LogsQueryClient(new DefaultAzureCredential());

// Query TOP 10 resource groups by event count
Response<IReadOnlyList<string>> response = await client.QueryWorkspaceAsync<string>(
    workspaceId,
    "AzureActivity | summarize Count = count() by ResourceGroup | top 10 by Count | project ResourceGroup",
    new LogsQueryTimeRange(TimeSpan.FromDays(1)));

foreach (var resourceGroup in response.Value)
{
    Console.WriteLine(resourceGroup);
}
```

#### Print logs query results as a table

You can also dynamically inspect the list of columns. The following example prints the query result as a table:

```C# Snippet:QueryLogs_QueryLogsPrintTable
string workspaceId = "<workspace_id>";

var client = new LogsQueryClient(new DefaultAzureCredential());
Response<LogsQueryResult> response = await client.QueryWorkspaceAsync(
    workspaceId,
    "AzureActivity | top 10 by TimeGenerated",
    new LogsQueryTimeRange(TimeSpan.FromDays(1)));

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

```C# Snippet:QueryLogs_BatchQuery
string workspaceId = "<workspace_id>";

var client = new LogsQueryClient(new DefaultAzureCredential());

// Query TOP 10 resource groups by event count
// And total event count
var batch = new LogsBatchQuery();

string countQueryId = batch.AddWorkspaceQuery(
    workspaceId,
    "AzureActivity | count",
    new LogsQueryTimeRange(TimeSpan.FromDays(1)));
string topQueryId = batch.AddWorkspaceQuery(
    workspaceId,
    "AzureActivity | summarize Count = count() by ResourceGroup | top 10 by Count",
    new LogsQueryTimeRange(TimeSpan.FromDays(1)));

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

```C# Snippet:QueryLogs_QueryLogsWithTimeout
string workspaceId = "<workspace_id>";

var client = new LogsQueryClient(new DefaultAzureCredential());

// Query TOP 10 resource groups by event count
Response<IReadOnlyList<string>> response = await client.QueryWorkspaceAsync<string>(
    workspaceId,
    @"AzureActivity
        | summarize Count = count() by ResourceGroup
        | top 10 by Count
        | project ResourceGroup",
    new LogsQueryTimeRange(TimeSpan.FromDays(1)),
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

```C# Snippet:QueryLogs_QueryLogsWithAdditionalWorkspace
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
    new LogsQueryTimeRange(TimeSpan.FromDays(1)),
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

```C# Snippet:QueryLogs_QueryLogsWithStatistics
string workspaceId = "<workspace_id>";
var client = new LogsQueryClient(new DefaultAzureCredential());

Response<LogsQueryResult> response = await client.QueryWorkspaceAsync(
    workspaceId,
    "AzureActivity | top 10 by TimeGenerated",
    new LogsQueryTimeRange(TimeSpan.FromDays(1)),
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

```C# Snippet:QueryLogs_QueryLogsWithVisualization
string workspaceId = "<workspace_id>";
var client = new LogsQueryClient(new DefaultAzureCredential());

Response<LogsQueryResult> response = await client.QueryWorkspaceAsync(
    workspaceId,
    @"StormEvents
        | summarize event_count = count() by State
        | where event_count > 10
        | project State, event_count
        | render columnchart",
    new LogsQueryTimeRange(TimeSpan.FromDays(1)),
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

#### Register the client with dependency injection

To register a client with the dependency injection container, invoke [AddLogsQueryClient](https://learn.microsoft.com/dotnet/api/microsoft.extensions.azure.logsqueryclientbuilderextensions?view=azure-dotnet).  For more information, see [Register client](https://learn.microsoft.com/dotnet/azure/sdk/dependency-injection#register-client).

## Troubleshooting

To diagnose various failure scenarios, see the [troubleshooting guide](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/monitor/Azure.Monitor.Query.Logs/TROUBLESHOOTING.md).

## Next steps

To learn more about Azure Monitor, see the [Azure Monitor service documentation][azure_monitor_overview].

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately with labels and comments. Follow the instructions provided by the bot. You'll only need to sign the CLA once across all Microsoft repos.

This project has adopted the [Microsoft Open Source Code of Conduct][coc]. For more information, see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com][coc_contact] with any questions or comments.

[azure_monitor_create_using_portal]: https://learn.microsoft.com/azure/azure-monitor/logs/quick-create-workspace
[azure_monitor_overview]: https://learn.microsoft.com/azure/azure-monitor/overview
[azure_subscription]: https://azure.microsoft.com/free/dotnet/
[changelog]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/monitor/Azure.Monitor.Query.Logs/CHANGELOG.md
[kusto_query_language]: https://learn.microsoft.com/azure/data-explorer/kusto/query/
[msdocs_apiref]: https://learn.microsoft.com/dotnet/api/overview/azure/monitor.query-readme?view=azure-dotnet
[package]: https://www.nuget.org/packages/Azure.Monitor.Query.Logs
[source]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/monitor/Azure.Monitor.Query.Logs/src

[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
