# <scenario_list>

To use these samples, you'll first need to set up resources. See [getting started](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/monitor/Azure.Monitor.Ingestion/README.md#getting-started) for details.

## <scenario>

You can verify that your data has been uploaded correctly by using the [Azure.Monitor.Query](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/monitor/Azure.Monitor.Query/README.md#install-the-package) library. Please run the [Upload custom logs](#upload-custom-logs) sample first before verifying the logs. 

```C# Snippet:VerifyLogs
var workspaceId = "...";
string tableName = "...";

TokenCredential credential = new DefaultAzureCredential();

LogsQueryClient logsQueryClient = new(credential);
LogsBatchQuery batch = new();
string query = tableName + " | count;";
string countQueryId = batch.AddWorkspaceQuery(
    workspaceId,
    query,
    new QueryTimeRange(TimeSpan.FromDays(1)));

Response<LogsBatchQueryResultCollection> queryResponse = logsQueryClient.QueryBatch(batch);

Console.WriteLine("Table entry count: " + queryResponse.Value.GetResult<int>(countQueryId).Single());
```

To see the full example source files, see:
* [Query](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/monitor/Azure.Monitor.Ingestion/tests/Samples/LogDataAndQuery.cs))

<!-- please refer to <https://github.com/Azure/azure-sdk-for-net/main/sdk/template/Azure.Template/samples/Sample1_HelloWorld.md> to write sample readme file. -->