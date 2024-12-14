# SetUp

To use these samples, you'll first need to set up resources. See [getting started](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/monitor/Azure.Monitor.Ingestion/README.md#getting-started) for details.

## Upload custom logs

You can create a client and call the client's `Upload` method. Take note of the data ingestion [limits](https://learn.microsoft.com/azure/azure-monitor/service-limits#custom-logs).

```C# Snippet:UploadCustomLogs
var endpoint = new Uri("<data_collection_endpoint_uri>");
var ruleId = "<data_collection_rule_id>";
var streamName = "<stream_name>";

var credential = new DefaultAzureCredential();
LogsIngestionClient client = new(endpoint, credential);

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
Response response = client.Upload(ruleId, streamName, RequestContent.Create(data));
```
