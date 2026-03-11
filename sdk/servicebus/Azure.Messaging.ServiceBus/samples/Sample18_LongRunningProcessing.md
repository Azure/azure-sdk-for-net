# Long-running message processing

This sample demonstrates how to process messages that take longer than the lock duration -- minutes to hours per message -- using the `ServiceBusProcessor` with automatic lock renewal and graceful lock-lost handling.

For background on message locks and settlement, see [Transfers, locks, and settlement](https://learn.microsoft.com/azure/service-bus-messaging/message-transfers-locks-settlement).

## Prerequisites

To use the samples, a Service Bus queue or subscription configured with **PeekLock** mode (the default) is required. For best results with long-running workloads, set the lock duration on the queue to 5 minutes (the maximum) to minimize renewal frequency.

## Processing messages with automatic lock renewal

The simplest approach uses the `ServiceBusProcessor` with `MaxAutoLockRenewalDuration` set to cover the longest expected processing time. The SDK renews the lock in the background while your handler runs.

```C# Snippet:ServiceBusLongRunningProcessing
string fullyQualifiedNamespace = "<fully_qualified_namespace>";
string queueName = "<queue_name>";

await using ServiceBusClient client = new(fullyQualifiedNamespace, new DefaultAzureCredential());

await using ServiceBusProcessor processor = client.CreateProcessor(queueName, new ServiceBusProcessorOptions
{
    // The SDK renews the lock in the background for up to this duration.
    // Set it to at least the longest expected processing time, with some margin.
    MaxAutoLockRenewalDuration = TimeSpan.FromHours(2),

    // Disable auto-complete so we settle messages explicitly after processing succeeds.
    AutoCompleteMessages = false,

    // Process one message at a time. Increase for higher throughput
    // if the processing is I/O-bound rather than CPU-bound.
    MaxConcurrentCalls = 1
});

processor.ProcessMessageAsync += async args =>
{
    Console.WriteLine($"Processing message: {args.Message.MessageId}");

    // Simulate long-running work (e.g., video transcoding, report generation).
    await Task.Delay(TimeSpan.FromMinutes(10), args.CancellationToken);

    // Complete the message only after processing succeeds.
    await args.CompleteMessageAsync(args.Message);
    Console.WriteLine($"Completed message: {args.Message.MessageId}");
};

processor.ProcessErrorAsync += args =>
{
    Console.WriteLine($"Error source: {args.ErrorSource}");
    Console.WriteLine($"Error: {args.Exception}");
    return Task.CompletedTask;
};

await processor.StartProcessingAsync();

// Processing runs in the background. Press any key to stop.
Console.ReadKey();
await processor.StopProcessingAsync();
```

If the handler throws without settling the message, the processor abandons it automatically, making it available for redelivery.

## Cancelling work when the lock is lost

Lock renewal is a best-effort operation. The lock can be lost due to transient network issues, service updates, or because the processing time exceeded `MaxAutoLockRenewalDuration`. When this happens, any attempt to settle the message will fail.

For long-running jobs, continuing expensive work after the lock is lost wastes resources -- you will not be able to complete the message anyway. The `MessageLockLostAsync` event lets you cancel work immediately.

```C# Snippet:ServiceBusLongRunningWithLockLostHandler
processor.ProcessMessageAsync += async args =>
{
    // Create a linked token that cancels both when the processor stops
    // and when the message lock is lost.
    using var cts = CancellationTokenSource.CreateLinkedTokenSource(args.CancellationToken);

    try
    {
        args.MessageLockLostAsync += lockLostArgs =>
        {
            Console.WriteLine($"Lock lost for message {args.Message.MessageId}: {lockLostArgs.Exception}");
            cts.Cancel();
            return Task.CompletedTask;
        };

        // Pass the linked token to your processing logic.
        // When the lock is lost, the token is cancelled and processing stops cleanly.
        await ProcessLongRunningJobAsync(args.Message, cts.Token);

        // Only settle if we still own the lock.
        await args.CompleteMessageAsync(args.Message);
    }
    catch (OperationCanceledException) when (cts.IsCancellationRequested)
    {
        // Lock was lost or the processor is stopping.
        // Don't try to settle -- the broker will redeliver after the lock expires.
        Console.WriteLine($"Processing cancelled for message {args.Message.MessageId}. " +
                          "Message will be redelivered.");
    }
};

static async Task ProcessLongRunningJobAsync(ServiceBusReceivedMessage message, CancellationToken cancellationToken)
{
    // Your processing logic here. Check the token periodically
    // (or use it with async APIs) so cancellation is responsive.
    for (int step = 0; step < 100; step++)
    {
        cancellationToken.ThrowIfCancellationRequested();

        // Simulate a processing step.
        await Task.Delay(TimeSpan.FromSeconds(5), cancellationToken);
        Console.WriteLine($"  Step {step + 1}/100 for message {message.MessageId}");
    }
}
```

## Using the receiver instead of the processor

If you need more control over the receive loop, you can use `ServiceBusReceiver` directly. Automatic lock renewal is configured through `ServiceBusReceiverOptions.MaxAutoLockRenewalDuration`.

```C# Snippet:ServiceBusLongRunningWithReceiver
await using ServiceBusClient client = new(fullyQualifiedNamespace, new DefaultAzureCredential());

ServiceBusReceiver receiver = client.CreateReceiver(queueName, new ServiceBusReceiverOptions
{
    // Enable automatic lock renewal for up to 1 hour.
    MaxAutoLockRenewalDuration = TimeSpan.FromHours(1)
});

ServiceBusReceivedMessage message = await receiver.ReceiveMessageAsync();
if (message != null)
{
    try
    {
        // Process the message. The lock is renewed automatically in the background.
        await ProcessLongRunningJobAsync(message, CancellationToken.None);

        // Settlement on success.
        await receiver.CompleteMessageAsync(message);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Processing failed: {ex.Message}");

        try
        {
            // Abandon so the message is available for redelivery immediately.
            await receiver.AbandonMessageAsync(message);
        }
        catch (ServiceBusException sbEx) when (sbEx.Reason == ServiceBusFailureReason.MessageLockLost)
        {
            // Lock was lost -- the broker will redeliver automatically after it expires.
            Console.WriteLine("Could not abandon message because the lock was lost.");
        }
    }
}
```

> [!NOTE]
> The `ServiceBusProcessor` approach is generally preferred because it handles the receive loop, concurrency, and error routing for you. Use the receiver directly only when you need custom receive timing or batching.

> [!IMPORTANT]
> **Idempotency.** Because lock loss causes redelivery, your processing logic should be idempotent -- producing the same result if the same message is processed more than once. Common strategies include checking whether the job has already completed before starting work, and using upsert semantics for writes. See [Transfers, locks, and settlement](https://learn.microsoft.com/azure/service-bus-messaging/message-transfers-locks-settlement) for details.
