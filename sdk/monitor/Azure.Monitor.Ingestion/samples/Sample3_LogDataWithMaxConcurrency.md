# SetUp

To use these samples, you'll first need to set up resources. See [getting started](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/monitor/Azure.Monitor.Ingestion/README.md#getting-started) for details.

## Upload custom logs with max concurrency

You can create a client and call the client's `Upload` method. Take note of the data ingestion [limits](https://learn.microsoft.com/azure/azure-monitor/service-limits#custom-logs). To upload multiple log requests in parallel, set the `UploadLogsOptions.MaxConcurrency` property.

```C# Snippet:UploadWithMaxConcurrency
var endpoint = new Uri("<data_collection_endpoint_uri>");
var ruleId = "<data_collection_rule_id>";
var streamName = "<stream_name>";

var credential = new DefaultAzureCredential();
var client = new LogsIngestionClient(endpoint, credential);

DateTimeOffset currentTime = DateTimeOffset.UtcNow;

var entries = new List<object>();
for (int i = 0; i < 100; i++)
{
    entries.Add(
        new {
            Time = currentTime,
            Computer = "Computer" + i.ToString(),
            AdditionalContext = i
        }
    );
}
// Set concurrency in LogsUploadOptions
var options = new LogsUploadOptions
{
    MaxConcurrency = 10
};

// Upload our logs
Response response = client.Upload(ruleId, streamName, entries, options);
```
