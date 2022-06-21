# <scenario_list>

To use these samples, you'll first need to set up resources. See [getting started](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/monitor/Azure.Monitor.Ingestion/README.md#getting-started) for details.

## <scenario> asynchronously

You can create a client and call the client's `<operation>` method

```C# Snippet:Azure_Monitor_Ingestion_ScenarioAsync
Uri dataCollectionEndpoint = new Uri("...");
TokenCredential credential = new DefaultAzureCredential();
string workspaceId = "...";
LogsIngestionClient client = new(dataCollectionEndpoint, credential);
LogsQueryClient logsQueryClient = new LogsQueryClient(credential);

DateTimeOffset currentTime = DateTimeOffset.UtcNow;

BinaryData data = BinaryData.FromObjectAsJson(
    // Use an anonymous type to create the payload
    new[] {
        new
        {
            Time = currentTime,
            Computer = "Computer1",
            AdditionalContext = new
            {
                InstanceName = "user1",
                TimeZone = "Pacific Time",
                Level = 4,
                CounterName = "AppMetric1",
                CounterValue = 15.3
            }
        },
        new
        {
            Time = currentTime,
            Computer = "Computer2",
            AdditionalContext = new
            {
                InstanceName = "user2",
                TimeZone = "Central Time",
                Level = 3,
                CounterName = "AppMetric1",
                CounterValue = 23.5
            }
        },
    });

// Make the request
Response response = await client.UploadAsync(TestEnvironment.DCRImmutableId, "Custom-MyTableRawData", RequestContent.Create(data)).ConfigureAwait(false); //takes StreamName not tablename

LogsBatchQuery batch = new LogsBatchQuery();
string countQueryId = batch.AddWorkspaceQuery(
    workspaceId,
    "MyTable_CL | count;",
    new QueryTimeRange(TimeSpan.FromDays(1)));

Response<LogsBatchQueryResultCollection> responseLogsQuery = await logsQueryClient.QueryBatchAsync(batch).ConfigureAwait(false);

Console.WriteLine("Table entry count: " + responseLogsQuery.Value.GetResult<int>(countQueryId).Single());
```

To see the full example source files, see:
* [HelloWorld](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/monitor/Azure.Monitor.Ingestion/tests/Samples/Sample1_HelloWorldAsync.cs))

<!-- please refer to <https://github.com/Azure/azure-sdk-for-net/main/sdk/template/Azure.Template/samples/Sample1_HelloWorldAsync.md> to write sample readme file. -->