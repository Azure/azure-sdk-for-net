# <scenario_list>

To use these samples, you'll first need to set up resources. See [getting started](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/monitor/Azure.Monitor.Ingestion/README.md#getting-started) for details.

## <scenario> asynchronously

You can create a client and call the client's `UploadAsync` method

```C# Snippet:UploadCustomLogsAsync
Uri dataCollectionEndpoint = new Uri("...");
TokenCredential credential = new DefaultAzureCredential();
string dcrImmutableId = "...";
string streamName = "...";
LogsIngestionClient client = new(dataCollectionEndpoint, credential);

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
Response response = await client.UploadAsync(dcrImmutableId, streamName, RequestContent.Create(data)).ConfigureAwait(false);
```

To see the full example source files, see:
* [HelloWorld](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/monitor/Azure.Monitor.Ingestion/tests/Samples/Sample1_HelloWorldAsync.cs))

<!-- please refer to <https://github.com/Azure/azure-sdk-for-net/main/sdk/template/Azure.Template/samples/Sample1_HelloWorldAsync.md> to write sample readme file. -->