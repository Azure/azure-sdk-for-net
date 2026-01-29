# Guide for migrating from `Azure.Monitor.Query` to `Azure.Monitor.Query.Logs`

This guide assists in migrating querying logs operations in `Azure.Monitor.Query` to the dedicated `Azure.Monitor.Query.Logs` library.

## Table of contents

- [Migration benefits](#migration-benefits)
- [Important changes](#important-changes)
    - [Package names](#package-names)
    - [Client differences](#client-differences)
    - [API changes](#api-changes)
    - [Query logs from workspace](#query-logs-from-workspace)
    - [Query resource logs](#query-resource-logs)
- [Additional samples](#additional-samples)

## Migration benefits

The Azure Monitor Query library for .NET has been modularized to provide more focused functionality. The operations for querying logs have been moved from the combined `Azure.Monitor.Query` package which also included querying metrics to a dedicated `Azure.Monitor.Query.Logs` package. This separation offers several advantages:

- Smaller dependency footprint for applications that only need to query logs 
- More focused API design specific to logs query operations
- Independent versioning allowing logs functionality to evolve separately
- Clearer separation of concerns between logs and metrics operations

## Important changes

### Package names

- Previous package for logs query clients: `Azure.Monitor.Query`
- New package: `Azure.Monitor.Query.Logs`

### Namespaces

The root namespace has changed to `Azure.Monitor.Query.Logs` in the new package.  The namespace hierarchy has otherwise remained unchanged.

### Client differences

`LogsQueryClient` in the `Azure.Monitor.Query` package  has moved to the new `Azure.Monitor.Query.Logs` package in the new `Azure.Monitor.Query.Logs` library. The client names and the client builder name remains the same in both libraries.

### API changes

The following API changes were made between `Azure.Monitor.Query` and `Azure.Monitor.Query.Logs`:

| `Azure.Monitor.Query` | `Azure.Monitor.Query.Logs`                                  | Notes                                           |
|------------------------|-------------------------------------------------------------|-------------------------------------------------|
| `Azure.Monitor.Query.QueryTimeRange ` | `Azure.Monitor.Query.LogsQueryTimeRange ` | Used to specify the time range for logs queries |

Code using the previous `QueryTimeRange` class will need to be updated to use the new `LogsQueryTimeRange` class:

Previous code:
```C#
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

New code:
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

### Query logs from workspace

Previous code:
```C#
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

New code:
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

### Query resource logs

Previous code:
```C#
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

New code:
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

## Additional samples

More examples can be found in the [Azure Monitor Query Logs samples][logs-samples].

<!-- Links -->
[logs-samples]: https://github.com/Azure/azure-sdk-for-java/blob/main/sdk/monitor/Azure.Monitor.Query.Logs/src/README.md#examples