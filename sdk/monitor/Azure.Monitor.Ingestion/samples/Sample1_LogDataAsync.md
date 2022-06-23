# <scenario_list>

To use these samples, you'll first need to set up resources. See [getting started](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/monitor/Azure.Monitor.Ingestion/README.md#getting-started) for details.

## <scenario> asynchronously

You can create a client and call the client's `UploadAsync` method. Please note that at this time the upload limit is 1 Mb. Any content uploaded larger than 1 Mb will throw an exception.

```C# Snippet:UploadCustomLogsAsync
var dataCollectionEndpoint = new Uri("...");
var dataCollectionRuleImmutableId = "...";
var streamName = "...";

TokenCredential credential = new DefaultAzureCredential();
LogsIngestionClient client = new(dataCollectionEndpoint, credential);

DateTimeOffset currentTime = DateTimeOffset.UtcNow;

// Use BinaryData to serialize instances of an anonymous type into JSON
BinaryData data = BinaryData.FromObjectAsJson(
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

// Upload our logs
Response response = await client.UploadAsync(dataCollectionRuleImmutableId, streamName, RequestContent.Create(data)).ConfigureAwait(false);
```

To see the full example source files, see:
* [LogDataAsync](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/monitor/Azure.Monitor.Ingestion/tests/Samples/LogDataAndQueryAsync.cs))

<!-- please refer to <https://github.com/Azure/azure-sdk-for-net/main/sdk/template/Azure.Template/samples/Sample1_HelloWorldAsync.md> to write sample readme file. -->