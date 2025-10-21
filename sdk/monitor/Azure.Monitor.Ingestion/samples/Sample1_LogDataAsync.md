# SetUp

To use these samples, you'll first need to set up resources. See [getting started](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/monitor/Azure.Monitor.Ingestion/README.md#getting-started) for details.

## Upload custom logs asynchronously

You can create a client and call the client's `UploadAsync` method. Take note of the data ingestion [limits](https://learn.microsoft.com/azure/azure-monitor/service-limits#custom-logs).  When uploading custom logs as an `IEnumerable` of an application model type, the `LogsIngestionClient` will perform serialization on your behalf, using either the [ObjectSerializer](https://learn.microsoft.com/dotnet/api/azure.core.serialization.objectserializer?view=azure-dotnet) registered with your `LogsUploadOptions` or the serializer used by [BinaryData.FromObjectAsJson](https://learn.microsoft.com/dotnet/api/system.binarydata.fromobjectasjson). Both approaches use a serialization path that is not compatible with [ahead-of-time compilation (AOT)](https://learn.microsoft.com/dotnet/core/deploying/native-aot).

```C# Snippet:UploadCustomLogsAsync
var endpoint = new Uri("<data_collection_endpoint>");
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
Response response = await client.UploadAsync(
    ruleId,
    streamName,
    RequestContent.Create(data)).ConfigureAwait(false);
```

## Upload custom logs asynchronously (AOT)

To upload custom logs in an AOT environment, your application must take ownership of serialization and use the `LogsIngestionClient.Upload` or `LogsIngestionClient.UploadAsync` overload that accepts an `IEnumerable<BinaryData>`.   

For example, if you have the following custom type and AOT serialization context:
```C# Snippet:IngestionAotSerializationTypes
public record Person(string Name, string Department, int EmployeeNumber)
{
}

[JsonSerializable(typeof(Person))]
public partial class ExampleDeserializationContext : JsonSerializerContext
{
}
```

The Ingestion upload is identical, other than serializing prior to the call:
```C# Snippet:UploadLogDataIEnumerableAsyncAot
var endpoint = new Uri("<data_collection_endpoint_uri>");
var ruleId = "<data_collection_rule_id>";
var streamName = "<stream_name>";

var credential = new DefaultAzureCredential();
LogsIngestionClient client = new(endpoint, credential);

DateTimeOffset currentTime = DateTimeOffset.UtcNow;

var entries = new List<BinaryData>();
for (int i = 0; i < 100; i++)
{
    entries.Add(BinaryData.FromBytes(
        JsonSerializer.SerializeToUtf8Bytes(new Person($"Person{i}", "Department{i}", i))));
}

// Upload our logs
Response response = await client.UploadAsync(ruleId, streamName, entries).ConfigureAwait(false);
```
