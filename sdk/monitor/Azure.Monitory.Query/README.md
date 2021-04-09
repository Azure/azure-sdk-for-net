# Azure Monitor Query client library for .NET

TODO


## Samples

### Query logs

You can query logs using the `LogsClient.QueryAsync`. The result would be returned as a table with a collection of rows:

```C# Snippet:QueryLogsAsTable
LogsClient client = new LogsClient(new DefaultAzureCredential());
string workspaceId = "<workspace_id>";
Response<LogsQueryResult> response = await client.QueryAsync(workspaceId, "AzureActivity | top 10 by TimeGenerated");

LogsQueryResultTable table = response.Value.PrimaryTable;

foreach (var row in table.Rows)
{
    Console.WriteLine(row["OperationName"] + " " + row["ResourceGroup"]);
}
```

### Query logs as model

You can map query results to a model using the `LogsClient.QueryAsync<T>` method.

```C# Snippet:QueryLogsAsModelsModel
public class MyLogEntryModel
{
    public string ResourceGroup { get; set; }
    public string Count { get; set; }
}
```

```C# Snippet:QueryLogsAsModels
LogsClient client = new LogsClient(new DefaultAzureCredential());
string workspaceId = "<workspace_id>";

// Query TOP 10 resource groups by event count
Response<IReadOnlyList<MyLogEntryModel>> response = await client.QueryAsync<MyLogEntryModel>(workspaceId,
    "AzureActivity | summarize Count = count() by ResourceGroup | top 10 by Count");

foreach (var logEntryModel in response.Value)
{
    Console.WriteLine($"{logEntryModel.ResourceGroup} had {logEntryModel.Count} events");
}
```

### Query logs as primitive

If your query return a single column (or a single value) of a primitive type you can use `LogsClient.QueryAsync<T>` overload to deserialize it:

```C# Snippet:QueryLogsAsPrimitive
LogsClient client = new LogsClient(new DefaultAzureCredential());
string workspaceId = "<workspace_id>";

// Query TOP 10 resource groups by event count
Response<IReadOnlyList<string>> response = await client.QueryAsync<string>(workspaceId,
    "AzureActivity | summarize Count = count() by ResourceGroup | top 10 by Count | project ResourceGroup");

foreach (var resourceGroup in response.Value)
{
    Console.WriteLine(resourceGroup);
}
```

### Batch query

You can execute multiple queries in on request using the `LogsClient.CreateBatchQuery`:

```C# Snippet:BatchQuery
LogsClient client = new LogsClient(new DefaultAzureCredential());
string workspaceId = "<workspace_id>";

// Query TOP 10 resource groups by event count
// And total event count
LogsBatchQuery batch = client.CreateBatchQuery();
string countQueryId = batch.AddQuery(workspaceId, "AzureActivity | count");
string topQueryId = batch.AddQuery(workspaceId, "AzureActivity | summarize Count = count() by ResourceGroup | top 10 by Count");

Response<LogsBatchQueryResult> response = await batch.SubmitAsync();

var count = response.Value.GetResult<int>(countQueryId).Single();
var topEntries = response.Value.GetResult<MyLogEntryModel>(topQueryId);

Console.WriteLine($"AzureActivity has total {count} events");
foreach (var logEntryModel in topEntries)
{
    Console.WriteLine($"{logEntryModel.ResourceGroup} had {logEntryModel.Count} events");
}
```

### Query dynamic table 

You can also dynamically inspect the list of columns. The following example prints the result of the query as a table:

```C# Snippet:QueryLogsPrintTable
LogsClient client = new LogsClient(new DefaultAzureCredential());
string workspaceId = "<workspace_id>";
Response<LogsQueryResult> response = await client.QueryAsync(workspaceId, "AzureActivity | top 10 by TimeGenerated");

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