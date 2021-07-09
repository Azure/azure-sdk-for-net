# Azure Monitor Query client library for .NET

The `Azure.Monitor.Query` package provides the ability to query the following Azure Monitor data sources:

- [Azure Monitor Logs](https://docs.microsoft.com/azure/azure-monitor/logs/data-platform-logs) - Collects and organizes log and performance data from monitored resources. Data from different sources such as platform logs from Azure services, log and performance data from virtual machines agents, and usage and performance data from apps can be consolidated into a single workspace. The various data types can be analyzed together using the [Kusto Query Language](https://docs.microsoft.com/azure/data-explorer/kusto/query).
- [Azure Monitor Metrics](https://docs.microsoft.com/azure/azure-monitor/essentials/data-platform-metrics) - Collects numeric data from monitored resources into a time series database. Metrics are numerical values that are collected at regular intervals and describe some aspect of a system at a particular time. Metrics in Azure Monitor are lightweight and capable of supporting near real-time scenarios, making them particularly useful for alerting and fast detection of issues.

[Source code][query_client_src] | [Package (NuGet)][query_client_nuget_package]

## Getting started

### Install the package

Install the Azure Monitor Query client library for .NET with [NuGet][query_client_nuget_package]:

```
dotnet add package Azure.Monitor.Query --prerelease
```

### Prerequisites

- An [Azure subscription][azure_sub].
- To query logs, you need an existing Log Analytics workspace. You can create it with one of the following approaches:
  - [Azure Portal](https://docs.microsoft.com/azure/azure-monitor/logs/quick-create-workspace)
  - [Azure CLI](https://docs.microsoft.com/azure/azure-monitor/logs/quick-create-workspace-cli)
  - [PowerShell](https://docs.microsoft.com/azure/azure-monitor/logs/powershell-workspace-configuration)
- To query metrics, all you need is an Azure resource of any kind (Storage Account, Key Vault, Cosmos DB, etc.).

### Authenticate the client

To interact with the Azure Monitor service, create an instance of a [TokenCredential](https://docs.microsoft.com/dotnet/api/azure.core.tokencredential?view=azure-dotnet) class. Pass it to the constructor of your `LogsQueryClient` or `MetricsQueryClient` class.

## Key concepts

- `LogsQueryClient` - Client that provides methods to query logs from Azure Monitor Logs.
- `MetricsQueryClient` - Client that provides methods to query metrics from Azure Monitor Metrics.

### Thread safety

All client instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This ensures that the recommendation of reusing client instances is always safe, even across threads.

### Additional concepts

<!-- CLIENT COMMON BAR -->
[Client options](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Accessing the response](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#accessing-http-response-details-using-responset) |
[Long-running operations](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#consuming-long-running-operations-using-operationt) |
[Handling failures](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md) |
[Mocking](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
<!-- CLIENT COMMON BAR -->

## Examples

- [Query logs](#query-logs)
- [Query logs as model](#query-logs-as-model)
- [Query logs as primitive](#query-logs-as-primitive)
- [Batch query](#batch-query)
- [Query dynamic table](#query-dynamic-table)
- [Increase query timeout](#increase-query-timeout)

### Query logs

You can query logs using the `LogsQueryClient.QueryAsync` method. The result is returned as a table with a collection of rows:

```C# Snippet:QueryLogsAsTable
string workspaceId = "<workspace_id>";
var client = new LogsQueryClient(new DefaultAzureCredential());
Response<LogsQueryResult> response = await client.QueryAsync(
    workspaceId,
    "AzureActivity | top 10 by TimeGenerated",
    new DateTimeRange(TimeSpan.FromDays(1)));

LogsQueryResultTable table = response.Value.PrimaryTable;

foreach (var row in table.Rows)
{
    Console.WriteLine(row["OperationName"] + " " + row["ResourceGroup"]);
}
```

### Query logs as model

You can map query results to a model using the `LogsQueryClient.QueryAsync<T>` method.

```C# Snippet:QueryLogsAsModelsModel
public class MyLogEntryModel
{
    public string ResourceGroup { get; set; }
    public int Count { get; set; }
}
```

```C# Snippet:QueryLogsAsModels
var client = new LogsQueryClient(TestEnvironment.LogsEndpoint, new DefaultAzureCredential());
string workspaceId = "<workspace_id>";

// Query TOP 10 resource groups by event count
Response<IReadOnlyList<MyLogEntryModel>> response = await client.QueryAsync<MyLogEntryModel>(
    workspaceId,
    "AzureActivity | summarize Count = count() by ResourceGroup | top 10 by Count",
    new DateTimeRange(TimeSpan.FromDays(1)));

foreach (var logEntryModel in response.Value)
{
    Console.WriteLine($"{logEntryModel.ResourceGroup} had {logEntryModel.Count} events");
}
```

### Query logs as primitive

If your query returns a single column (or a single value) of a primitive type, use the `LogsQueryClient.QueryAsync<T>` overload to deserialize it:

```C# Snippet:QueryLogsAsPrimitive
string workspaceId = "<workspace_id>";

var client = new LogsQueryClient(new DefaultAzureCredential());

// Query TOP 10 resource groups by event count
Response<IReadOnlyList<string>> response = await client.QueryAsync<string>(
    workspaceId,
    "AzureActivity | summarize Count = count() by ResourceGroup | top 10 by Count | project ResourceGroup",
    new DateTimeRange(TimeSpan.FromDays(1)));

foreach (var resourceGroup in response.Value)
{
    Console.WriteLine(resourceGroup);
}
```

### Batch query

You can execute multiple queries in a single request using the `LogsQueryClient.CreateBatchQuery` method:

```C# Snippet:BatchQuery
string workspaceId = "<workspace_id>";

var client = new LogsQueryClient(new DefaultAzureCredential());

// Query TOP 10 resource groups by event count
// And total event count
var batch = new LogsBatchQuery();

string countQueryId = batch.AddQuery(
    workspaceId,
    "AzureActivity | count",
    new DateTimeRange(TimeSpan.FromDays(1)));
string topQueryId = batch.AddQuery(
    workspaceId,
    "AzureActivity | summarize Count = count() by ResourceGroup | top 10 by Count",
    new DateTimeRange(TimeSpan.FromDays(1)));

Response<LogsBatchQueryResults> response = await client.QueryBatchAsync(batch);

var count = response.Value.GetResult<int>(countQueryId).Single();
var topEntries = response.Value.GetResult<MyLogEntryModel>(topQueryId);

Console.WriteLine($"AzureActivity has total {count} events");
foreach (var logEntryModel in topEntries)
{
    Console.WriteLine($"{logEntryModel.ResourceGroup} had {logEntryModel.Count} events");
}
```

### Query dynamic table

You can also dynamically inspect the list of columns. The following example prints the query result as a table:

```C# Snippet:QueryLogsPrintTable
string workspaceId = "<workspace_id>";

var client = new LogsQueryClient(new DefaultAzureCredential());
Response<LogsQueryResult> response = await client.QueryAsync(
    workspaceId,
    "AzureActivity | top 10 by TimeGenerated",
    new DateTimeRange(TimeSpan.FromDays(1)));

LogsQueryResultTable table = response.Value.PrimaryTable;

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

### Increase query timeout

Some Logs queries take longer than 3 minutes to execute. The default server timeout is 3 minutes. You can increase the server timeout to a maximum of 10 minutes. In the following example, the `LogsQueryOptions` object's `ServerTimeout` property is used to set the server timeout to 10 minutes:

```C# Snippet:QueryLogsWithTimeout
string workspaceId = "<workspace_id>";

var client = new LogsQueryClient(new DefaultAzureCredential());

// Query TOP 10 resource groups by event count
Response<IReadOnlyList<int>> response = await client.QueryAsync<int>(
    workspaceId,
    "AzureActivity | summarize count()",
    new DateTimeRange(TimeSpan.FromDays(1)),
    options: new LogsQueryOptions
    {
        ServerTimeout = TimeSpan.FromMinutes(10)
    });

foreach (var resourceGroup in response.Value)
{
    Console.WriteLine(resourceGroup);
}
```

### Query metrics

You can query metrics using the `MetricsQueryClient.QueryAsync` method. For every requested metric, a set of aggregated values is returned inside the `TimeSeries` collection.

A resource ID is required to query metrics. To find the resource ID:

1. Navigate to your resource's page in the Azure portal.
2. From the **Overview** blade, select the **JSON View** link.
3. In the resulting JSON, copy the value of the `id` property.

```C# Snippet:QueryMetrics
string resourceId =
    "/subscriptions/<subscription_id>/resourceGroups/<resource_group_name>/providers/Microsoft.OperationalInsights/workspaces/<workspace_name>";

var metricsClient = new MetricsQueryClient(new DefaultAzureCredential());

Response<MetricQueryResult> results = await metricsClient.QueryAsync(
    resourceId,
    new[] {"Microsoft.OperationalInsights/workspaces"}
);

foreach (var metric in results.Value.Metrics)
{
    Console.WriteLine(metric.Name);
    foreach (var element in metric.TimeSeries)
    {
        Console.WriteLine("Dimensions: " + string.Join(",", element.Metadata));

        foreach (var metricValue in element.Data)
        {
            Console.WriteLine(metricValue);
        }
    }
}
```

## Troubleshooting

### General

When you interact with the Azure Monitor Query client library using the .NET SDK, errors returned by the service correspond to the same HTTP status codes returned for [REST API][monitor_rest_api] requests.

For example, if you submit an invalid query, an HTTP 400 error is returned, indicating "Bad Request".

```C# Snippet:BadRequest
string workspaceId = "<workspace_id>";

var client = new LogsQueryClient(new DefaultAzureCredential());

try
{
    await client.QueryAsync(
        workspaceId, "My Not So Valid Query", new DateTimeRange(TimeSpan.FromDays(1)));
}
catch (Exception e)
{
    Console.WriteLine(e);
}
```

The exception also contains some additional information like the full error content.

```
Azure.RequestFailedException : The request had some invalid properties
Status: 400 (Bad Request)
ErrorCode: BadArgumentError

Content:
{"error":{"message":"The request had some invalid properties","code":"BadArgumentError","correlationId":"34f5f93a-6007-48a4-904f-487ca4e62a82","innererror":{"code":"SyntaxError","message":"A recognition error occurred in the query.","innererror":{"code":"SYN0002","message":"Query could not be parsed at 'Not' on line [1,3]","line":1,"pos":3,"token":"Not"}}}}
```

### Setting up console logging

The simplest way to see the logs is to enable the console logging. To create an Azure SDK log listener that outputs messages to the console, use the [AzureEventSourceListener.CreateConsoleLogger](https://docs.microsoft.com/dotnet/api/azure.core.diagnostics.azureeventsourcelistener.createconsolelogger?view=azure-dotnet) method:

```C#
// Set up a listener to monitor logged events.
using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger();
```

To learn more about other logging mechanisms, see [here][logging].

## Next steps

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

This project has adopted the [Microsoft Open Source Code of Conduct][coc]. For more information see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com][coc_contact] with any additional questions or comments.

[query_client_src]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/monitor/Azure.Monitor.Query/src
[query_client_nuget_package]: https://www.nuget.org/packages?q=Azure.Monitor.Query
[monitor_rest_api]: https://docs.microsoft.com/rest/api/monitor/
[azure_cli]: https://docs.microsoft.com/cli/azure
[azure_sub]: https://azure.microsoft.com/free/dotnet/
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
[logging]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fmonitor%2FAzure.Monitor.Query%2FREADME.png)
