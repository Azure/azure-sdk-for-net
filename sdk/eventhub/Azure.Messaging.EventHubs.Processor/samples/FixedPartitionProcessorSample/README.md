# Fixed Partition Event Hub Processor

This sample could be useful to anyone wanting to implement a custom Event Hub processor to meet a unqiue set of requirements. In this specific case, this processor was designed to meet the following requirements:

- __Fixed Number of Partitions__. This processor allows you to specify the number of partitions that each consumer will process. It will not attempt to take ownership of any additional partitions, leaving those for other consumers. In cases where the reassignment of partitions would be problematic, this can be important.

- __Batching__. In some cases, such as writing records to a database, it may be significantly more performant to write records in batches rather than one at a time.

- __Lazy Checkpointing__. If a solution already has a way to address duplicate events, it may be more efficient to checkpoint less frequently. In this case, the processor will checkpoint every few seconds instead of on every event or batch.

- __Dedicated Ownership__. Unlike the EventProcessorClient, this processor does not allow other consumers to steal partitions. If a consumer stores content in memory, stealing partitions may be very disruptive.

## Get This Sample Running

This sample consists of two projects:

- __library__: This is the implementation of the FixedPartitionEventHubProcessor.
- __client__: This is a sample client that uses the library.

To run this sample, you will need to create an Event Hub and a Storage Account in Azure.

Then create an `appsettings.json` file in the client project with the following contents:

```json
{
    "STORAGE_CONNSTRING": "DefaultEndpointsProtocol=https;AccountName=???;AccountKey=???;EndpointSuffix=core.windows.net",
    "STORAGE_CONTAINER_NAME": "???",
    "INBOUND_EVENTHUB_CONNSTRING": "Endpoint=sb://???.servicebus.windows.net/;SharedAccessKeyName=???;SharedAccessKey=???;EntityPath=???",
    "INBOUND_EVENTHUB_CONSUMER_GROUP": "???",
    "ASSIGN_TO_X_PARTITIONS": "32"
}
```

You should set STORAGE_CONNSTRING and INBOUND_EVENTHUB_CONNSTRING as appropriate. Please note that the INBOUND_EVENTHUB_CONNSTRING must specify an EntityPath (the name of the Event Hub in this namespace). You need to create a container in the Storage Account and set STORAGE_CONTAINER_NAME equal to the name of that container. You need to create a consumer group in the Event Hub or use $Default for INBOUND_EVENTHUB_CONSUMER_GROUP.

If you are running a single copy of this consumer client locally, you probably want to set ASSIGN_TO_X_PARTITIONS to the number of partitions in your Event Hub. If you are running multiple copies of this consumer client, you want to set ASSIGN_TO_X_PARTITIONS to the number of partitions in your Event Hub divided by the number of copies of the consumer client you are running.

You can run the client project from the command line by typing:

```bash
dotnet run
```

## How It Works

The FixedPartitionEventHubProcessor is a wrapper around the EventProcessor primitive class. At startup, it will create a number of 0-byte blobs equal to the number of partitions in the Event Hub. Then every 1 second, it will do the following:

- __Assign__: If the processor owns less than ASSIGN_TO_X_PARTITIONS partitions, it will read the list of blobs, shuffle the list, and attempt to gain an exclusive lease on a blob. It will attempt each blob (in order), until it successfully gains a lease on a blob for LEASE_FOR_X_SEC seconds. In this way, no more than 1 partition will be assigned to the processor per second. You can add custom code by adding an OnAssignedAsync event handler.

- __Renew__: The processor will look at the partitions it owns, if any are that are have been leased longer than RENEW_EVERY_X_SEC seconds, the processor will attempt to renew the lease for LEASE_FOR_X_SEC seconds. Gernerally, you want RENEW_EVERY_X_SEC to allow for 3 renewals (so LEASE_FOR_X_SEC should be at least 3 times RENEW_EVERY_X_SEC). If checkpointing, the processor will also write the offset of the partition into the associated blob. Therefore, RENEW_EVERY_X_SEC doubles as the frequency for checkpointing. You can add custom code by adding an OnRenewedAsync event handler.

- __Release__: If the processor has any leases for longer than LEASE_FOR_X_SEC, it will release ownership of those partitions. You can add custom code by adding an OnReleasedAsync event handler.

For any partitions that are leased, it will continuously check those partitions for events and release them in batches of 1 to INBOUND_EVENTHUB_MAX_BATCH_SIZE events. Those batches are raised to any OnBatchAsync event handlers.

Finally, if there are errors trying to read events from any partitions, those exceptions will be raised to any OnErrorAsync event handlers.

While the processor will catch unhandled exceptions, you should use try...catch in your event handlers to catch any exceptions that occur in your code.

## How To Use It

Please take a look at the Consumer.cs class in the client sample for a full implementation.

You can obtain a FixedPartitionEventHubProcessor by calling the static GetOrCreateAsync method on the FixedPartitionEventHubProcessorFactory class. You must specify the EventPosition to start reading from if no checkpoints are available and whether or not you want to checkpoint.

```csharp
this.processor = await this.factory.GetOrCreateAsync(EventPosition.Earliest, shouldCheckpoint: true);
```

You may also add any event handlers you wish. None are required, although logically you should at least implement OnBatchAsync.

```csharp
this.processor.OnAssignedAsync += this.OnAssignedAsync;
this.processor.OnRenewedAsync += this.OnRenewedAsync;
this.processor.OnReleasedAsync += this.OnReleasedAsync;
this.processor.OnBatchAsync += this.OnBatchAsync;
this.processor.OnErrorAsync += this.OnErrorAsync;
```

You can start processing by calling StartProcessingAsync. This will return immediately and processing will continue on a background thread. You can cancel processing by cancelling the token, though calling `StopProcessingAsync()` is preferred.

```csharp
await this.processor.StartProcessingAsync(cancellationToken);
```

You can stop processing by calling StopProcessingAsync. This will wait for any in-progress processing to complete before returning.

```csharp
await this.processor.StopProcessingAsync();
```
