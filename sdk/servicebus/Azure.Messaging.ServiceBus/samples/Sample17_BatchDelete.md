# Deleting batches of messages

This sample demonstrates how to delete batches of messages from a Service Bus entity without needing to download them locally by receiving and completing them.  This can be helpful for clearing out the dead-letter queue or removing messages of a certain age which are no longer of interest to applications.

## Purge all messages from an entity

For scenarios when you'd like to delete all messages from an entity, you would use the `PurgeMessagesAsync` method of the `ServiceBusReceiver`.  It is important to be aware that this method may invoke multiple service requests to delete all of the messages and, as a result, may exceed the configured `TryTimeout`.   If you need control over the amount of time the operation takes, it is recommended that you pass a `CancellationToken` with the desired timeout set for cancellation.

Because multiple service requests may be made, it is possible to experience partial success when an exception is encountered.  In this scenario, the method will stop attempting to delete additional messages and will throw the exception.  

It is also important to be aware that if there is a receiver reading the entity when `PurgeAllMessgesAsync` is called, any locked messages will not be deleted.

```C# Snippet:ServiceBusPurgeMessages
string fullyQualifiedNamespace = "<fully_qualified_namespace>";
string queueName = "<queue_name>";
await using ServiceBusClient client = new(fullyQualifiedNamespace, new DefaultAzureCredential());
await using ServiceBusReceiver receiver = client.CreateReceiver(queueName);

// Delete all messages in the queue.
int numberOfMessagesDeleted = await receiver.PurgeMessagesAsync();
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
int numberOfMessagesDeleted = await receiver.PurgeMessagesAsync(deleteBefore);
```

## Delete a batch of old messages

When you wish to only delete some number of messages from the entity, rather than purging all messages, the `DeleteMessagesAsync` method should be used.  This method will invoke a single service operation to request deletion of some number of messages.  Service Bus will choose the oldest messages to delete by considering the enqueued time.  

Note that the service may delete fewer messages than were requested, but will never delete more. It is also important to be aware that if there is a receiver reading the entity when `DeleteMessages` is called, any locked messages will not be deleted.

```C# Snippet:ServiceBusDeleteMessages
string fullyQualifiedNamespace = "<fully_qualified_namespace>";
string queueName = "<queue_name>";
await using ServiceBusClient client = new(fullyQualifiedNamespace, new DefaultAzureCredential());
await using ServiceBusReceiver receiver = client.CreateReceiver(queueName);

// Delete the oldest 50 messages in the queue.
int maxBatchSize = 50;
int numberOfMessagesDeleted = await receiver.DeleteMessagesAsync(maxBatchSize);
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

int numberOfMessagesDeleted = await receiver.DeleteMessagesAsync(maxBatchSize, deleteBefore);
```