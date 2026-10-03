# Deleting batches of messages

This sample demonstrates how to delete batches of messages from a Service Bus entity without receiving and completing each message. This can be helpful for clearing a dead-letter queue or removing messages that are no longer needed.

## Purge all messages from an entity

Use `PurgeMessagesAsync` to delete all eligible messages from an entity. The method can send multiple service requests. Pass a `CancellationToken` when the application needs to limit the total operation time.

If a request fails after it is sent, some messages might already be removed. Check the entity before starting another purge.

Locked, deferred, and scheduled messages remain in the entity. Batch delete and purge currently aren't supported when partitioning is enabled.

```C# Snippet:ServiceBusPurgeMessages
string fullyQualifiedNamespace = "<fully_qualified_namespace>";
string queueName = "<queue_name>";
await using ServiceBusClient client = new(fullyQualifiedNamespace, new DefaultAzureCredential());
await using ServiceBusReceiver receiver = client.CreateReceiver(queueName);

// Delete all eligible messages in 500-message batches.
PurgeMessagesResult result = await receiver.PurgeMessagesAsync();
Console.WriteLine($"The service purged {result.DeletedCount} messages.");
```

## Use a larger purge batch on Premium

The default batch size is 500 messages. Premium supports up to 4,000 messages per request. Purge records its start time and leaves messages that arrive later in the entity.

```C# Snippet:ServiceBusPurgeMessagesWithPremiumBatchSize
string fullyQualifiedNamespace = "<fully_qualified_namespace>";
string queueName = "<queue_name>";
await using ServiceBusClient client = new(fullyQualifiedNamespace, new DefaultAzureCredential());
int maxMessagesPerBatch = 4000;
await using ServiceBusReceiver receiver = client.CreateReceiver(queueName);

DateTimeOffset enqueueTimeThreshold = DateTimeOffset.UtcNow;

// Premium supports up to 4,000 messages per request.
PurgeMessagesResult result = await receiver.PurgeMessagesAsync(maxMessagesPerBatch, enqueueTimeThreshold);
Console.WriteLine($"Purged {result.DeletedCount} messages enqueued before {enqueueTimeThreshold:O}.");
```

## Purge one session

Accept a named session to remove messages from that session. Messages in other sessions remain.

```C# Snippet:ServiceBusPurgeMessagesFromSession
string fullyQualifiedNamespace = "<fully_qualified_namespace>";
string queueName = "<queue_name>";
string sessionId = "<session_id>";
await using ServiceBusClient client = new(fullyQualifiedNamespace, new DefaultAzureCredential());
await using ServiceBusSessionReceiver sessionReceiver = await client.AcceptSessionAsync(queueName, sessionId);
PurgeMessagesResult result = await sessionReceiver.PurgeMessagesAsync();
Console.WriteLine($"Removed {result.DeletedCount} messages from session {sessionId}.");
```

## Purge all messages enqueued before a specific date

For scenarios where you would like to delete all messages enqueued before a given date, `PurgeMessagesAsync` accepts an optional parameter to specify the cut-off point.

```C# Snippet:ServiceBusPurgeMessagesByDate
string fullyQualifiedNamespace = "<fully_qualified_namespace>";
string queueName = "<queue_name>";;
await using ServiceBusClient client = new(fullyQualifiedNamespace, new DefaultAzureCredential());
await using ServiceBusReceiver receiver = client.CreateReceiver(queueName);

// Delete all messages in the queue that were enqueued more than a year ago.
DateTimeOffset deleteBefore = DateTimeOffset.UtcNow.AddYears(-1);
long numberOfMessagesDeleted = (await receiver.PurgeMessagesAsync(deleteBefore)).DeletedCount;
```

## Delete a batch of old messages

When you wish to only delete some number of messages from the entity, rather than purging all messages, the `DeleteMessagesAsync` method should be used.  This method will invoke a single service operation to request deletion of some number of messages.  Service Bus will choose the oldest messages to delete by considering the enqueued time.  

The returned count can be lower than the requested count, especially when messages are large. Locked messages remain in the entity.

```C# Snippet:ServiceBusDeleteMessages
string fullyQualifiedNamespace = "<fully_qualified_namespace>";
string queueName = "<queue_name>";
await using ServiceBusClient client = new(fullyQualifiedNamespace, new DefaultAzureCredential());
await using ServiceBusReceiver receiver = client.CreateReceiver(queueName);

// Large messages can cause the returned count to be lower than the requested count.
int requestedCount = 50;
DeleteMessagesResult result = await receiver.DeleteMessagesAsync(requestedCount);
Console.WriteLine($"Requested {requestedCount}; the service deleted {result.DeletedCount}.");
```

## Delete a batch of messages enqueued before a specific date

When you wish to delete the oldest messages in the entity but restrict it to only those enqueued before a given date, `DeleteMessagesAsync` accepts an optional parameter to specify the cut-off point.

```C# Snippet:ServiceBusDeleteMessagesByDate
string fullyQualifiedNamespace = "<fully_qualified_namespace>";
string queueName = "<queue_name>";
await using ServiceBusClient client = new(fullyQualifiedNamespace, new DefaultAzureCredential());
await using ServiceBusReceiver receiver = client.CreateReceiver(queueName);

// Delete the oldest 50 messages in the queue which were enqueued
// more than a month ago.
int maxBatchSize = 50;
DateTimeOffset deleteBefore = DateTimeOffset.UtcNow.AddMonths(-1);

int numberOfMessagesDeleted = (await receiver.DeleteMessagesAsync(maxBatchSize, deleteBefore)).DeletedCount;
```