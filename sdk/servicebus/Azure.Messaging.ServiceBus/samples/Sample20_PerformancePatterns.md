# Performance Patterns

This sample covers techniques for optimizing throughput and latency when sending and receiving messages with `Azure.Messaging.ServiceBus`. These patterns apply to high-volume scenarios where default configuration may not be sufficient.

## Concurrent sends with Task.WhenAll

When sending a large number of individual messages, overlapping the send operations with `Task.WhenAll` significantly reduces total elapsed time compared to sending sequentially.

```C# Snippet:ServiceBusConcurrentSends
string fullyQualifiedNamespace = "<fully_qualified_namespace>";
string queueName = "<queue_name>";

await using var client = new ServiceBusClient(fullyQualifiedNamespace, new DefaultAzureCredential());
await using ServiceBusSender sender = client.CreateSender(queueName);

var messages = new List<ServiceBusMessage>();
for (int i = 0; i < 100; i++)
{
    messages.Add(new ServiceBusMessage($"Message {i}"));
}

// Send all messages concurrently. Each SendMessageAsync call initiates
// an independent AMQP transfer, and Task.WhenAll waits for all of them.
IEnumerable<Task> sendTasks = messages.Select(m => sender.SendMessageAsync(m));
await Task.WhenAll(sendTasks);
```

## Throttled concurrent sends with SemaphoreSlim

Unbounded concurrency can overwhelm the connection or hit service throttling limits. A `SemaphoreSlim` limits the number of in-flight send operations while still overlapping them.

```C# Snippet:ServiceBusThrottledConcurrentSends
string fullyQualifiedNamespace = "<fully_qualified_namespace>";
string queueName = "<queue_name>";

await using var client = new ServiceBusClient(fullyQualifiedNamespace, new DefaultAzureCredential());
await using ServiceBusSender sender = client.CreateSender(queueName);

var messages = new List<ServiceBusMessage>();
for (int i = 0; i < 1000; i++)
{
    messages.Add(new ServiceBusMessage($"Message {i}"));
}

// Limit to 10 concurrent sends to avoid overwhelming the connection.
using var semaphore = new SemaphoreSlim(10);
var tasks = new List<Task>();

async Task SendAsync(ServiceBusMessage msg)
{
    await semaphore.WaitAsync();
    try
    {
        await sender.SendMessageAsync(msg);
    }
    finally
    {
        semaphore.Release();
    }
}

foreach (ServiceBusMessage message in messages)
{
    tasks.Add(SendAsync(message));
}

await Task.WhenAll(tasks);
```

The concurrency limit should match the application's tolerance for connection load. A value of 10 is a reasonable starting point; increase or decrease based on observed throughput and error rates.

## Batch sending with CreateMessageBatchAsync

Sending messages in batches amortizes the AMQP overhead across multiple messages in a single transfer. `CreateMessageBatchAsync` creates a batch that respects the service's maximum message size for the entity. This is the most effective way to send large volumes of messages.

```C# Snippet:ServiceBusBatchSend
string fullyQualifiedNamespace = "<fully_qualified_namespace>";
string queueName = "<queue_name>";

await using var client = new ServiceBusClient(fullyQualifiedNamespace, new DefaultAzureCredential());
await using ServiceBusSender sender = client.CreateSender(queueName);

var messages = new Queue<ServiceBusMessage>();
for (int i = 0; i < 1000; i++)
{
    messages.Enqueue(new ServiceBusMessage($"Message {i}"));
}

// Send in batches that respect the service's maximum message size.
while (messages.Count > 0)
{
    using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();

    while (messages.Count > 0 && batch.TryAddMessage(messages.Peek()))
    {
        messages.Dequeue();
    }

    if (batch.Count == 0)
    {
        throw new InvalidOperationException("Message too large for an empty batch.");
    }

    await sender.SendMessagesAsync(batch);
}
```

Batching is more efficient than sending individual messages concurrently because it reduces the number of AMQP transfers. For messages with variable sizes, the batch automatically handles the size calculation.

## Tuning MaxConcurrentCalls on the processor

The `ServiceBusProcessor` processes messages concurrently up to the value of `MaxConcurrentCalls`. The default is 1, which means messages are processed one at a time. Increasing this value allows the processor to handle multiple messages in parallel, but does not guarantee message ordering. For ordered processing, use [sessions](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/servicebus/Azure.Messaging.ServiceBus/samples/Sample03_SendReceiveSessions.md).

```C# Snippet:ServiceBusProcessorMaxConcurrentCalls
string fullyQualifiedNamespace = "<fully_qualified_namespace>";
string queueName = "<queue_name>";

await using var client = new ServiceBusClient(fullyQualifiedNamespace, new DefaultAzureCredential());

await using ServiceBusProcessor processor = client.CreateProcessor(queueName, new ServiceBusProcessorOptions
{
    // Process up to 20 messages concurrently. Tune this based on
    // the processing time per message and the desired throughput.
    MaxConcurrentCalls = 20,

    // AutoCompleteMessages is true by default. Messages are completed
    // automatically after the handler returns without throwing.
    AutoCompleteMessages = true
});

processor.ProcessMessageAsync += async args =>
{
    Console.WriteLine($"Received: {args.Message.Body}");

    // Simulate work. With MaxConcurrentCalls = 20, up to 20 of these
    // run in parallel.
    await Task.Delay(TimeSpan.FromMilliseconds(100), args.CancellationToken);
};

processor.ProcessErrorAsync += args =>
{
    Console.WriteLine($"Error: {args.Exception.Message}");
    return Task.CompletedTask;
};

await processor.StartProcessingAsync();

try
{
    // Let the processor run for a while, then stop.
    await Task.Delay(TimeSpan.FromSeconds(30));
}
finally
{
    await processor.StopProcessingAsync();
}
```

General guidance for `MaxConcurrentCalls`:
- **I/O-bound handlers** (database writes, HTTP calls): start with 20 and increase.
- **CPU-bound handlers**: keep at or below `Environment.ProcessorCount`.
- **Ordering**: Setting `MaxConcurrentCalls` to 1 ensures one message is processed at a time, but Service Bus does not guarantee FIFO delivery order on non-session queues. Use sessions if strict ordering is required.
- **Session processor**: For `ServiceBusSessionProcessor`, use `MaxConcurrentSessions` to control how many sessions are processed in parallel and `MaxConcurrentCallsPerSession` to control concurrency within each session.

## Using PrefetchCount to reduce latency

Prefetching allows the client to fetch messages in the background before the application calls `ReceiveMessageAsync`. This hides the round-trip latency of individual receive operations.

```C# Snippet:ServiceBusPrefetchCount
string fullyQualifiedNamespace = "<fully_qualified_namespace>";
string queueName = "<queue_name>";

await using var client = new ServiceBusClient(fullyQualifiedNamespace, new DefaultAzureCredential());


// Prefetch 50 messages. The client fetches the next batch in the
// background while the application processes the current messages.
await using ServiceBusReceiver receiver = client.CreateReceiver(queueName, new ServiceBusReceiverOptions
{
    PrefetchCount = 50
});

// Each call returns immediately from the local buffer if messages
// have been prefetched, avoiding a network round-trip.
for (int i = 0; i < 200; i++)
{
    ServiceBusReceivedMessage message = await receiver.ReceiveMessageAsync(TimeSpan.FromSeconds(5));
    if (message == null)
    {
        break;
    }

    Console.WriteLine($"Received: {message.Body}");

    // Completing removes the message from the queue. If the lock expired
    // while in the prefetch buffer, this call throws and the message is
    // redelivered — ensure processing logic is idempotent.
    await receiver.CompleteMessageAsync(message);
}
```

Prefetching also works with the processor:

```C# Snippet:ServiceBusProcessorPrefetchCount
string fullyQualifiedNamespace = "<fully_qualified_namespace>";
string queueName = "<queue_name>";

await using var client = new ServiceBusClient(fullyQualifiedNamespace, new DefaultAzureCredential());

await using ServiceBusProcessor processor = client.CreateProcessor(queueName, new ServiceBusProcessorOptions
{
    MaxConcurrentCalls = 20,
    PrefetchCount = 100
});

processor.ProcessMessageAsync += async args =>
{
    Console.WriteLine($"Received: {args.Message.Body}");
    await Task.Delay(TimeSpan.FromMilliseconds(100), args.CancellationToken);
};

processor.ProcessErrorAsync += args =>
{
    Console.WriteLine($"Error: {args.Exception.Message}");
    return Task.CompletedTask;
};

await processor.StartProcessingAsync();

try
{
    await Task.Delay(TimeSpan.FromSeconds(30));
}
finally
{
    await processor.StopProcessingAsync();
}
```

Guidelines for `PrefetchCount`:
- Set it to roughly **0.25–0.5 seconds worth of messages**. If each message takes 50 ms to process with `MaxConcurrentCalls = 20`, the effective rate is 400 messages/second, so a `PrefetchCount` of 100–200 (approximately 0.25–0.5 seconds of work) is reasonable.
- Higher values consume more memory and risk message lock expiration if processing is slow. If messages sit in the prefetch buffer longer than the lock duration, they will be abandoned and redelivered.
- Set to 0 (the default) when messages are large or processing time is unpredictable.

## Choosing the right Service Bus tier

Performance tuning works best when the tier matches the workload. The key differences that affect throughput:

| Feature | Standard | Premium |
|---------|----------|---------|
| Throughput | Shared, variable | Dedicated, predictable |
| Message size limit | 256 KB | 100 MB |
| Messaging Units | N/A | 1, 2, 4, 8, 16 (scale up/down) |
| Network isolation | No | VNet, Private Link |

For high-throughput or latency-sensitive workloads, Premium tier with multiple Messaging Units provides consistent performance without throttling from other tenants.

## Combining patterns for high throughput

For maximum throughput, combine concurrent processing with prefetching:

```C# Snippet:ServiceBusHighThroughputProcessor
string fullyQualifiedNamespace = "<fully_qualified_namespace>";
string queueName = "<queue_name>";

await using var client = new ServiceBusClient(fullyQualifiedNamespace, new DefaultAzureCredential());

await using ServiceBusProcessor processor = client.CreateProcessor(queueName, new ServiceBusProcessorOptions
{
    // High concurrency for I/O-bound processing.
    MaxConcurrentCalls = 50,

    // Aggressive prefetch to keep the pipeline full.
    PrefetchCount = 200,

    // Extend auto-lock renewal for long processing times.
    MaxAutoLockRenewalDuration = TimeSpan.FromMinutes(10)
});

processor.ProcessMessageAsync += async args =>
{
    // Process the message. With these settings, up to 50 messages
    // are processed concurrently, and the prefetch buffer keeps
    // the pipeline saturated.
    Console.WriteLine($"Processing: {args.Message.MessageId}");
    await Task.Delay(TimeSpan.FromMilliseconds(50), args.CancellationToken);
};

processor.ProcessErrorAsync += args =>
{
    Console.WriteLine($"Error: {args.Exception.Message}");
    return Task.CompletedTask;
};

await processor.StartProcessingAsync();

try
{
    // Let the processor run, then stop when done.
    await Task.Delay(TimeSpan.FromSeconds(30));
}
finally
{
    await processor.StopProcessingAsync();
}
```

When tuning, monitor these indicators:
- **Throttling errors** (`ServiceBusException` with `Reason == ServiceBusFailureReason.ServiceBusy`): reduce concurrency or move to Premium tier.
- **Lock expiration** (messages redelivered after processing): increase `MaxAutoLockRenewalDuration` or reduce `PrefetchCount`.
- **Memory pressure**: reduce `PrefetchCount` if messages are large.
