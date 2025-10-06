# Using Earlier Versions of C# and Visual Studio

The Azure Event Hubs client library makes use of new features that were introduced in C# 8.0.  In order to take advantage of the C# 8.0 syntax, it is recommended that you compile using the [.NET Core SDK](https://dotnet.microsoft.com/download) 3.0 or higher with a [language version](https://learn.microsoft.com/dotnet/csharp/language-reference/configure-language-version#override-a-default) of `latest`.  It is also possible to compile with the .NET Core SDK 2.1.x using a language version of `preview`.

  Visual Studio users wishing to take full advantage of the C# 8.0 syntax will need to use Visual Studio 2019 or later.  Visual Studio 2019, including the free Community edition, can be downloaded [here](https://visualstudio.microsoft.com).  Users of Visual Studio 2017 can take advantage of the C# 8 syntax by making use of the [Microsoft.Net.Compilers NuGet package](https://www.nuget.org/packages/Microsoft.Net.Compilers/) and setting the language version, though the editing experience may not be ideal.

  You can still use the Event Hubs client library with previous C# language versions, by managing asynchronous enumerable and asynchronous disposable members manually rather than benefiting from the new syntax.  You may still target any framework version that can consume a `netstandard2.0` package, including earlier versions of .NET Core or the .NET framework.  For more information, see the [.NET Standard](https://learn.microsoft.com/dotnet/standard/net-standard) documentation and [how to specify target frameworks](https://learn.microsoft.com/dotnet/standard/frameworks#how-to-specify-target-frameworks).

  ## Table of contents

- [Publish a batch of events using C# 7](#publish-a-batch-of-events-using-c-7)
- [Read events from all partitions using C# 7](#read-events-from-all-partitions-using-c-7)

## Publish a batch of events using C# 7

This example illustrates publishing a batch with a single event, allowing the Event Hubs service to assign the partition to which it will be published. For more information on publishing, see: [Sample04_PublishingEvents](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample04_PublishingEvents.md).

```C# Snippet:EventHubs_Sample07_Publish
var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var credential = new DefaultAzureCredential();

var producer = new EventHubProducerClient(
    fullyQualifiedNamespace,
    eventHubName,
    credential);

try
{
    using (var eventBatch = await producer.CreateBatchAsync())
    {
      var eventBody = new BinaryData("This is an event body");
      var eventData = new EventData(eventBody);

      if (!eventBatch.TryAdd(eventData))
      {
          throw new Exception($"The event could not be added.");
      }
    }
}
finally
{
    await producer.CloseAsync();
}
```

## Read events from all partitions using C# 7

The `ReadEventsAsync` method of the `EventHubConsumerClient` allows events to be read from each partition for prototyping and exploring, but is not a recommended approach for production scenarios.  For reading events from all partitions in a production scenario, we strongly recommend using the [EventProcessorClient](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventhub/Azure.Messaging.EventHubs.Processor/samples) from the [Azure.Messaging.EventHubs.Processor](https://www.nuget.org/packages/Azure.Messaging.EventHubs.Processor) package.

This example illustrates reading either 50 events or stopping after 30 seconds has elapsed, whichever occurs first.  For more information on publishing, see:  [Sample05_ReadingEvents](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample05_ReadingEvents.md).

  ```C# Snippet:EventHubs_Sample07_ReadAllPartitions
var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var credential = new DefaultAzureCredential();
var consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;

var consumer = new EventHubConsumerClient(
    consumerGroup,
    fullyQualifiedNamespace,
    eventHubName,
    credential);

try
{
    using (CancellationTokenSource cancellationSource = new CancellationTokenSource())
    {
        cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

        int eventsRead = 0;
        int maximumEvents = 50;

        IAsyncEnumerator<PartitionEvent> iterator =
            consumer.ReadEventsAsync(cancellationSource.Token).GetAsyncEnumerator();

        try
        {
            while (await iterator.MoveNextAsync())
            {
                PartitionEvent partitionEvent = iterator.Current;
                string readFromPartition = partitionEvent.Partition.PartitionId;
                byte[] eventBodyBytes = partitionEvent.Data.EventBody.ToArray();

                Debug.WriteLine($"Read event of length { eventBodyBytes.Length } from { readFromPartition }");
                eventsRead++;

                if (eventsRead >= maximumEvents)
                {
                    break;
                }
            }
        }
        catch (TaskCanceledException)
        {
            // This is expected if the cancellation token is
            // signaled.
        }
        finally
        {
            await iterator.DisposeAsync();
        }
    }
}
finally
{
    await consumer.CloseAsync();
}
```



