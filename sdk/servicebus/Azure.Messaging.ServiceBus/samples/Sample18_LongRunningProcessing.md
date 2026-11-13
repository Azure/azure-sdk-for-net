# Long-running message processing

This sample demonstrates how to process messages that take longer than the lock duration -- minutes to hours per message -- using the `ServiceBusProcessor` with automatic lock renewal and graceful lock-lost handling.

For background on message locks and settlement, see [Transfers, locks, and settlement](https://learn.microsoft.com/azure/service-bus-messaging/message-transfers-locks-settlement).

## Prerequisites

To use the samples, a Service Bus queue or subscription configured with **PeekLock** mode (the default) is required. For best results with long-running workloads, set the lock duration on the queue to 5 minutes (the maximum) to minimize renewal frequency.

## Processing messages with automatic lock renewal

The simplest approach uses the `ServiceBusProcessor` with `MaxAutoLockRenewalDuration` set to cover the longest expected processing time. The client renews the lock in the background while your handler runs.

```C# Snippet:ServiceBusLongRunningProcessing
// The fully qualified Service Bus namespace, which is likely to be similar to
// "{yournamespace}.servicebus.windows.net".
string fullyQualifiedNamespace = "<fully_qualified_namespace>";
string queueName = "<queue_name>";

await using ServiceBusClient client = new(fullyQualifiedNamespace, new DefaultAzureCredential());

await using ServiceBusProcessor processor = client.CreateProcessor(queueName, new ServiceBusProcessorOptions
{
    // The client automatically renews the lock in the background for up to this duration.
    // Set it to at least the longest expected processing time (including any retries or
    // delays in your handler), plus ~25% margin for safety.
    MaxAutoLockRenewalDuration = TimeSpan.FromHours(2),

    // Disable auto-complete so we settle messages explicitly after processing succeeds.
    AutoCompleteMessages = false,

    // Process one message at a time. Increase for higher throughput
    // if the processing is I/O-bound rather than CPU-bound.
    // Note: MaxConcurrentCalls = 1 limits parallelism but does not guarantee
    // ordering. Use sessions if message ordering is required.
    MaxConcurrentCalls = 1
});

// Use try/finally to wire and unwire event handlers explicitly.
// This avoids keeping closures alive beyond the processor's intended lifetime.
try
{
    processor.ProcessMessageAsync += MessageHandler;
    processor.ProcessErrorAsync += ErrorHandler;

    await processor.StartProcessingAsync();

    // Processing runs in the background. Press any key to stop.
    Console.ReadKey();
    await processor.StopProcessingAsync();
}
finally
{
    processor.ProcessMessageAsync -= MessageHandler;
    processor.ProcessErrorAsync -= ErrorHandler;
}

async Task MessageHandler(ProcessMessageEventArgs args)
{
    Console.WriteLine($"Processing message: {args.Message.MessageId}");

    // Simulate long-running work (e.g., video transcoding, report generation).
    await Task.Delay(TimeSpan.FromMinutes(10), args.CancellationToken);

    // Complete the message only after processing succeeds.
    // Because lock loss causes redelivery, ensure your processing logic is
    // idempotent -- it should produce the same result if a message is
    // processed more than once. Common strategies include deduplication checks
    // and upsert semantics. See https://learn.microsoft.com/azure/service-bus-messaging/message-transfers-locks-settlement
    await args.CompleteMessageAsync(args.Message);
    Console.WriteLine($"Completed message: {args.Message.MessageId}");
}

Task ErrorHandler(ProcessErrorEventArgs args)
{
    Console.WriteLine($"Error source: {args.ErrorSource}");
    Console.WriteLine($"Error: {args.Exception}");
    return Task.CompletedTask;
}
```

If the handler throws without settling the message, the processor abandons it automatically, making it available for redelivery.

## Cancelling work when the lock is lost

Lock renewal is a best-effort operation. The lock can be lost due to transient network issues, service updates, or because the processing time exceeded `MaxAutoLockRenewalDuration`. When this happens, any attempt to settle the message will fail.

For long-running jobs, continuing expensive work after the lock is lost wastes resources -- you will not be able to complete the message anyway. The `MessageLockLostAsync` event lets you cancel work immediately. `ProcessLongRunningJobAsync` is defined after the main logic.

```C# Snippet:ServiceBusLongRunningWithLockLostHandler
// The fully qualified Service Bus namespace, which is likely to be similar to
// "{yournamespace}.servicebus.windows.net".
string fullyQualifiedNamespace = "<fully_qualified_namespace>";
string queueName = "<queue_name>";

await using ServiceBusClient client = new(fullyQualifiedNamespace, new DefaultAzureCredential());

await using ServiceBusProcessor processor = client.CreateProcessor(queueName, new ServiceBusProcessorOptions
{
    MaxAutoLockRenewalDuration = TimeSpan.FromHours(2),
    AutoCompleteMessages = false,
});

processor.ProcessErrorAsync += args =>
{
    Console.WriteLine(args.Exception);
    return Task.CompletedTask;
};
processor.ProcessMessageAsync += async args =>
{
    // Create a linked token that cancels both when the processor stops
    // and when the message lock is lost.
    using var cts = CancellationTokenSource.CreateLinkedTokenSource(args.CancellationToken);

    try
    {
        args.MessageLockLostAsync += LockLostHandler;

        // Pass the linked token to your processing logic.
        // When the lock is lost, the token is cancelled and processing stops cleanly.
        await ProcessLongRunningJobAsync(args.Message, cts.Token);

        // If cancellation was requested (lock lost or processor stopping),
        // skip settlement and let the message be redelivered.
        if (cts.IsCancellationRequested)
        {
            Console.WriteLine($"Skipping completion for message {args.Message.MessageId} " +
                              "because processing was cancelled (lock lost or processor stopping). " +
                              "Message will be redelivered.");
            return;
        }

        // Only settle if we still own the lock.
        try
        {
            await args.CompleteMessageAsync(args.Message);
        }
        catch (ServiceBusException ex) when (ex.Reason == ServiceBusFailureReason.MessageLockLost)
        {
            // The lock was lost between finishing processing and settlement.
            Console.WriteLine($"Lock lost while completing message {args.Message.MessageId}. " +
                              "Message will be redelivered.");
        }
    }
    catch (OperationCanceledException) when (cts.IsCancellationRequested)
    {
        // Lock was lost or the processor is stopping.
        // Don't try to settle -- the broker will redeliver after the lock expires.
        Console.WriteLine($"Processing cancelled for message {args.Message.MessageId}. " +
                          "Message will be redelivered.");
    }
    finally
    {
        // Remove the handler to avoid a memory leak.
        args.MessageLockLostAsync -= LockLostHandler;
    }

    Task LockLostHandler(MessageLockLostEventArgs lockLostArgs)
    {
        Console.WriteLine($"Lock lost for message {args.Message.MessageId}: {lockLostArgs.Exception}");
        cts.Cancel();
        return Task.CompletedTask;
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
await processor.StartProcessingAsync();
Console.ReadKey();
await processor.StopProcessingAsync();
```

## Using the receiver instead of the processor

If you need more control over the receive loop, you can use `ServiceBusReceiver` directly. Unlike the processor, the receiver does not renew locks automatically -- you must renew them yourself. The most common approach is by using a background task.

```C# Snippet:ServiceBusLongRunningWithReceiver
// The fully qualified Service Bus namespace, which is likely to be similar to
// "{yournamespace}.servicebus.windows.net".
string fullyQualifiedNamespace = "<fully_qualified_namespace>";
string queueName = "<queue_name>";

await using ServiceBusClient client = new(fullyQualifiedNamespace, new DefaultAzureCredential());

await using ServiceBusReceiver receiver = client.CreateReceiver(queueName);

ServiceBusReceivedMessage message = await receiver.ReceiveMessageAsync();
if (message != null)
{
    using var renewCts = new CancellationTokenSource();
    using var processingCts = new CancellationTokenSource();

    // Renew the lock in the background while processing.
    // If the lock is lost, processingCts is cancelled to stop the work immediately.
    Task renewalTask = RenewLockPeriodicallyAsync(receiver, message, renewCts.Token, processingCts);

    try
    {
        // Pass the processing token so work stops if the lock is lost.
        await ProcessLongRunningJobAsync(message, processingCts.Token);

        // Settlement on success.
        await receiver.CompleteMessageAsync(message);
    }
    catch (OperationCanceledException) when (processingCts.IsCancellationRequested)
    {
        // Processing was cancelled (e.g., lock lost). Don't settle -- the broker will redeliver.
        Console.WriteLine($"Processing cancelled for message {message.MessageId}. " +
                          "Message will be redelivered.");
    }
    catch (ServiceBusException ex) when (ex.Reason == ServiceBusFailureReason.MessageLockLost)
    {
        // Lock was lost during settlement.
        Console.WriteLine($"Lock lost while settling message {message.MessageId}. " +
                          "Message will be redelivered.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Message handling failed: {ex.Message}");

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
    finally
    {
        // Stop the renewal task.
        renewCts.Cancel();
        try { await renewalTask; }
        catch (OperationCanceledException) { }
        catch (ServiceBusException) { }
    }
}

static async Task RenewLockPeriodicallyAsync(
    ServiceBusReceiver receiver,
    ServiceBusReceivedMessage message,
    CancellationToken cancellationToken,
    CancellationTokenSource processingCts)
{
    // Renew the lock before it expires. The delay adapts to the
    // entity's lock duration: wait for (remaining - buffer) where
    // the buffer is the smaller of half the remaining time or a
    // fixed maximum. Short locks renew sooner; long locks renew
    // roughly 20 seconds before expiry.
    TimeSpan maxBuffer = TimeSpan.FromSeconds(20);

    while (!cancellationToken.IsCancellationRequested)
    {
        try
        {
            TimeSpan remaining = message.LockedUntil - DateTimeOffset.UtcNow;
            TimeSpan buffer = remaining / 2 < maxBuffer ? remaining / 2 : maxBuffer;
            TimeSpan delay = remaining - buffer;

            if (delay > TimeSpan.Zero)
            {
                await Task.Delay(delay, cancellationToken);
            }

            await receiver.RenewMessageLockAsync(message, cancellationToken);
            Console.WriteLine($"Renewed lock for message {message.MessageId}");
        }
        catch (ServiceBusException ex) when (ex.Reason == ServiceBusFailureReason.MessageLockLost)
        {
            // Lock was lost -- stop renewing and signal the processing work to stop.
            Console.WriteLine($"Lock lost for message {message.MessageId}. Stopping renewal.");
            processingCts.Cancel();
            break;
        }
        catch (ServiceBusException ex) when (ex.IsTransient)
        {
            // Transient Service Bus error (throttling, network). Log and retry
            // after a brief backoff so renewal can resume if the issue clears.
            Console.WriteLine($"Transient error renewing lock for message {message.MessageId}: {ex.Message}");

            try
            {
                await Task.Delay(TimeSpan.FromSeconds(5), cancellationToken);
            }
            catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
            {
                break;
            }
        }
        catch (ServiceBusException ex)
        {
            // Non-transient Service Bus error (auth, entity disabled). Stop renewing
            // and signal processing to stop so we don't continue with an unreliable lock state.
            Console.WriteLine($"Non-transient error renewing lock for message {message.MessageId}: {ex.Message}");
            processingCts.Cancel();
            break;
        }
        catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
        {
            // Cancellation requested; exit the renewal loop.
            break;
        }
        catch (Exception ex)
        {
            // Unexpected error. Stop renewing and signal processing to stop
            // so we don't continue with an unreliable lock state.
            Console.WriteLine($"Unexpected error renewing lock for message {message.MessageId}: {ex.Message}");
            processingCts.Cancel();
            break;
        }
    }
}
```

> [!NOTE]
> The `ServiceBusProcessor` approach is generally preferred because it handles the receive loop, concurrency, and error routing for you. Use the receiver directly only when you need custom receive timing or batching.
