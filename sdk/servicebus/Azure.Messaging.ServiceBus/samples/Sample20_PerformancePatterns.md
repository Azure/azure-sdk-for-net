# Performance Patterns

This sample covers techniques for optimizing throughput and latency when sending and receiving messages with `Azure.Messaging.ServiceBus`. These patterns apply to high-volume scenarios where default configuration may not be sufficient.

## Batch sending with CreateMessageBatchAsync

The single most effective way to improve send throughput is to use dense batches. Sending messages in batches amortizes the AMQP overhead across multiple messages in a single transfer, dramatically reducing the number of network round-trips compared to sending messages individually. `CreateMessageBatchAsync` creates a batch that respects the service's maximum message size for the entity, so you never risk exceeding the size limit.

```C# Snippet:ServiceBusBatchSend
// The fully qualified Service Bus namespace, which is likely to be similar to
// "{yournamespace}.servicebus.windows.net".
string fullyQualifiedNamespace = "<fully_qualified_namespace>";
string queueName = "<queue_name>";

await using var client = new ServiceBusClient(fullyQualifiedNamespace, new DefaultAzureCredential());
await using ServiceBusSender sender = client.CreateSender(queueName);

// The Queue is used here for illustration. In practice, you can
// build the batch incrementally — there is no need to buffer all
// messages up front before batching.
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

Always prefer batching over sending messages one at a time. Individual sends — even when issued concurrently — require a separate AMQP transfer per message, which is significantly less efficient than packing multiple messages into a single transfer. For messages with variable sizes, the batch automatically handles the size calculation and ensures the service limit is never exceeded.

## Concurrent sends with Task.WhenAll

When batch sending is not practical (for example, when messages are produced one at a time by an upstream source), overlapping individual send operations with `Task.WhenAll` reduces total elapsed time compared to sending sequentially.

> **Ordering**: Concurrent sends do **not** preserve the order in which `SendMessageAsync` calls are made. If message ordering matters, use [sessions](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/servicebus/Azure.Messaging.ServiceBus/samples/Sample03_SendReceiveSessions.md) or send sequentially within a single batch.

```C# Snippet:ServiceBusConcurrentSends
// The fully qualified Service Bus namespace, which is likely to be similar to
// "{yournamespace}.servicebus.windows.net".
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

Note that this pattern sends each message as a separate AMQP transfer, which has higher overhead than batch sending. Use `CreateMessageBatchAsync` when possible and reserve concurrent individual sends for cases where messages cannot be batched ahead of time.

## Tuning MaxConcurrentCalls on the processor

The `ServiceBusProcessor` processes messages concurrently up to the value of `MaxConcurrentCalls`. The default is 1, which means messages are processed one at a time. Increasing this value allows the processor to handle multiple messages in parallel, but does not guarantee message ordering. For ordered processing, use [sessions](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/servicebus/Azure.Messaging.ServiceBus/samples/Sample03_SendReceiveSessions.md).

> **Thread pool contention**: A large number of concurrent tasks — whether I/O-bound or CPU-bound — can cause thread pool contention where some tasks stall unpredictably because the scheduler does not guarantee fairness. This is one of the most common sources of issues customers encounter with the processor.

This example assumes the queue already contains messages. For sending messages, see [Sample01_SendReceive](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/servicebus/Azure.Messaging.ServiceBus/samples/Sample01_SendReceive.md).

```C# Snippet:ServiceBusProcessorMaxConcurrentCalls
// The fully qualified Service Bus namespace, which is likely to be similar to
// "{yournamespace}.servicebus.windows.net".
string fullyQualifiedNamespace = "<fully_qualified_namespace>";
string queueName = "<queue_name>";

await using var client = new ServiceBusClient(fullyQualifiedNamespace, new DefaultAzureCredential());

await using ServiceBusProcessor processor = client.CreateProcessor(queueName, new ServiceBusProcessorOptions
{
    // Start with a value close to the processor count and tune based on
    // testing. High ratios of concurrent tasks to processors cause thread
    // pool contention and unpredictable stalls.
    MaxConcurrentCalls = Environment.ProcessorCount,

    // AutoCompleteMessages is true by default. Messages are completed
    // automatically after the handler returns without throwing.
    AutoCompleteMessages = true
});

processor.ProcessMessageAsync += async args =>
{
    Console.WriteLine($"Received: {args.Message.Body}");

    // Simulate work.
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
- **Start conservatively**: begin at no more than 1.5× `Environment.ProcessorCount` and test thoroughly. Success varies significantly by workload, message size, host conditions, and what else is running on the machine.
- **I/O-bound and CPU-bound handlers alike** can cause thread pool contention at high concurrency. Even I/O-bound handlers that appear lightweight can starve the thread pool when many tasks compete for scheduling.
- **Ordering**: Setting `MaxConcurrentCalls` to 1 limits processing to one message at a time, but Service Bus does not guarantee FIFO delivery order on non-session queues. Use sessions if strict ordering is required.
- **Session processor**: For `ServiceBusSessionProcessor`, use `MaxConcurrentSessions` to control how many sessions are processed in parallel and `MaxConcurrentCallsPerSession` to control concurrency within each session.

## Using PrefetchCount to reduce latency

Prefetching allows the client to fetch messages in the background before the application calls `ReceiveMessageAsync`. This hides the round-trip latency of individual receive operations.

> **Lock expiration risk**: Thread pool contention tends to hit harder with prefetch enabled. Messages sit in the local buffer while waiting for a processing slot, and if contention causes unpredictable stalls, message locks can expire before your code even sees the message. The message is then redelivered, wasting the processing attempt. Keep `MaxConcurrentCalls` aligned with your processor count and test thoroughly to avoid this.

This example assumes the queue already contains messages. For sending messages, see [Sample01_SendReceive](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/servicebus/Azure.Messaging.ServiceBus/samples/Sample01_SendReceive.md).

```C# Snippet:ServiceBusPrefetchCount
// The fully qualified Service Bus namespace, which is likely to be similar to
// "{yournamespace}.servicebus.windows.net".
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

Prefetching also works with the processor. When combining prefetch with the processor, keep `MaxConcurrentCalls` aligned with the processor count to reduce the risk of thread pool contention and lock expiration. This example assumes the queue already contains messages.

```C# Snippet:ServiceBusProcessorPrefetchCount
// The fully qualified Service Bus namespace, which is likely to be similar to
// "{yournamespace}.servicebus.windows.net".
string fullyQualifiedNamespace = "<fully_qualified_namespace>";
string queueName = "<queue_name>";

await using var client = new ServiceBusClient(fullyQualifiedNamespace, new DefaultAzureCredential());

await using ServiceBusProcessor processor = client.CreateProcessor(queueName, new ServiceBusProcessorOptions
{
    MaxConcurrentCalls = Environment.ProcessorCount,
    PrefetchCount = Environment.ProcessorCount * 3
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
- Keep the value proportional to `MaxConcurrentCalls`. A ratio of roughly 2–3× `MaxConcurrentCalls` provides a buffer without excessive risk of lock expiration.
- Higher values consume more memory and increase the risk of message lock expiration if processing stalls. If messages sit in the prefetch buffer longer than the lock duration, they are abandoned and redelivered.
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

Concurrent processing and prefetching can be combined, but the right values depend entirely on your specific workload, message sizes, host resources, and what else is running on the machine. The following example is a starting point — not a recommendation. Test and tune thoroughly in your environment before using these values in production. This example assumes the queue already contains messages.

```C# Snippet:ServiceBusHighThroughputProcessor
// The fully qualified Service Bus namespace, which is likely to be similar to
// "{yournamespace}.servicebus.windows.net".
string fullyQualifiedNamespace = "<fully_qualified_namespace>";
string queueName = "<queue_name>";

await using var client = new ServiceBusClient(fullyQualifiedNamespace, new DefaultAzureCredential());

await using ServiceBusProcessor processor = client.CreateProcessor(queueName, new ServiceBusProcessorOptions
{
    // Start with a value close to the processor count. Increase only
    // after testing confirms the host can sustain the concurrency without
    // thread pool contention or lock expiration.
    MaxConcurrentCalls = Environment.ProcessorCount * 2,

    // Keep prefetch proportional to concurrent calls.
    PrefetchCount = Environment.ProcessorCount * 4,

    // Extend auto-lock renewal for long processing times.
    MaxAutoLockRenewalDuration = TimeSpan.FromMinutes(10)
});

processor.ProcessMessageAsync += async args =>
{
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
    await Task.Delay(TimeSpan.FromSeconds(30));
}
finally
{
    await processor.StopProcessingAsync();
}
```

When tuning, monitor these indicators:
- **Throttling errors** (`ServiceBusException` with `Reason == ServiceBusFailureReason.ServiceBusy`): reduce concurrency or move to Premium tier.
- **Lock expiration** (messages redelivered after processing): reduce `PrefetchCount` and `MaxConcurrentCalls`, or increase `MaxAutoLockRenewalDuration`.
- **Thread pool starvation** (random tasks stalling or timing out): reduce `MaxConcurrentCalls` closer to `Environment.ProcessorCount`.
- **Memory pressure**: reduce `PrefetchCount` if messages are large.
