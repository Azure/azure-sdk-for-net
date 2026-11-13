# SetUp

To use these samples, you'll first need to set up resources. See [getting started](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/monitor/Azure.Monitor.Ingestion/README.md#getting-started) for details.

## Verify logs asynchronously

You can verify that your data has been uploaded correctly by using the [Azure.Monitor.Query.Logs](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/monitor/Azure.Monitor.Query.Logs/README.md#install-the-package) library. Run the [Upload custom logs](#upload-custom-logs) sample first before verifying the logs.

```C# Snippet:VerifyLogsAsync
var workspaceId = "<log_analytics_workspace_id>";
var tableName = "<table_name>";

var credential = new DefaultAzureCredential();
LogsQueryClient logsQueryClient = new(credential);

LogsBatchQuery batch = new();
string query = tableName + " | Count;";
string countQueryId = batch.AddWorkspaceQuery(
    workspaceId,
    query,
    new LogsQueryTimeRange(TimeSpan.FromDays(1)));

Response<LogsBatchQueryResultCollection> queryResponse =
    await logsQueryClient.QueryBatchAsync(batch).ConfigureAwait(false);

Console.WriteLine("Table entry count: " +
    queryResponse.Value.GetResult<int>(countQueryId).Single());
```
