# Exception Handling

This sample covers patterns for handling `ServiceBusException` and its `Reason` property to build resilient applications. The `ServiceBusFailureReason` enum tells you exactly what went wrong, so your code can take the right recovery action instead of applying a generic retry to every error.

## Structured handling with ServiceBusFailureReason

Every `ServiceBusException` includes a `Reason` property of type `ServiceBusFailureReason`. Switching on this value lets you separate transient failures (retry) from permanent failures (fail fast) from lock-related failures (reprocess).

```C# Snippet:ServiceBusStructuredExceptionHandling
string connectionString = "<connection_string>";
string queueName = "<queue_name>";

await using var client = new ServiceBusClient(connectionString);
ServiceBusSender sender = client.CreateSender(queueName);

try
{
    await sender.SendMessageAsync(new ServiceBusMessage("Hello"));
}
catch (ServiceBusException ex) when (ex.Reason == ServiceBusFailureReason.ServiceBusy)
{
    // Transient: the service is temporarily overloaded. Back off and retry.
    Console.WriteLine("Service is busy, retrying after delay...");
    await Task.Delay(TimeSpan.FromSeconds(10));
}
catch (ServiceBusException ex) when (ex.Reason == ServiceBusFailureReason.ServiceTimeout)
{
    // Transient: the operation timed out. Retry with a longer timeout or backoff.
    Console.WriteLine($"Operation timed out: {ex.Message}");
}
catch (ServiceBusException ex) when (ex.Reason == ServiceBusFailureReason.ServiceCommunicationProblem)
{
    // Transient: network-level failure. Check connectivity and retry.
    Console.WriteLine($"Communication problem: {ex.Message}");
}
catch (ServiceBusException ex) when (ex.Reason == ServiceBusFailureReason.QuotaExceeded)
{
    // Capacity: the namespace or entity has hit its size or throughput limit.
    // Do not retry immediately — either wait for space to free up or scale the namespace.
    Console.WriteLine($"Quota exceeded: {ex.Message}");
}
catch (ServiceBusException ex) when (ex.Reason == ServiceBusFailureReason.MessageSizeExceeded)
{
    // Permanent: the message payload is too large for the tier. This will never succeed
    // without reducing the message size or upgrading to Premium.
    Console.WriteLine($"Message too large ({ex.Message}). Reduce payload size.");
}
catch (ServiceBusException ex) when (ex.Reason == ServiceBusFailureReason.MessagingEntityNotFound)
{
    // Permanent: the queue, topic, or subscription does not exist. Check the entity name
    // and ensure it has been provisioned.
    Console.WriteLine($"Entity not found: {ex.Message}");
}
catch (ServiceBusException ex) when (ex.Reason == ServiceBusFailureReason.MessagingEntityDisabled)
{
    // Permanent: the entity is disabled in the portal or via management API.
    Console.WriteLine($"Entity is disabled: {ex.Message}");
}
catch (ServiceBusException ex) when (ex.Reason == ServiceBusFailureReason.MessagingEntityAlreadyExists)
{
    // Permanent: attempted to create an entity that already exists.
    Console.WriteLine($"Entity already exists: {ex.Message}");
}
catch (ServiceBusException ex)
{
    // Catch-all for any other ServiceBusFailureReason (GeneralError, MessageNotFound, etc.).
    Console.WriteLine($"Service Bus error ({ex.Reason}): {ex.Message}");
    Console.WriteLine($"Is transient: {ex.IsTransient}");
}
```

## Handling lock-related failures

When processing messages with peek-lock (the default), the lock can expire if processing takes too long. The two lock-related failure reasons require different recovery strategies.

```C# Snippet:ServiceBusLockExceptionHandling
string connectionString = "<connection_string>";
string queueName = "<queue_name>";

await using var client = new ServiceBusClient(connectionString);
ServiceBusReceiver receiver = client.CreateReceiver(queueName);

ServiceBusReceivedMessage message = await receiver.ReceiveMessageAsync();

try
{
    // Simulate slow processing that might exceed the lock duration.
    await ProcessMessageAsync(message);
    await receiver.CompleteMessageAsync(message);
}
catch (ServiceBusException ex) when (ex.Reason == ServiceBusFailureReason.MessageLockLost)
{
    // The lock on this specific message has expired. Another receiver may
    // pick it up and reprocess it. Do not attempt to complete or abandon —
    // the lock token is no longer valid.
    Console.WriteLine($"Message lock lost for MessageId={message.MessageId}. " +
        "The message will be redelivered.");
}
catch (ServiceBusException ex) when (ex.Reason == ServiceBusFailureReason.SessionLockLost)
{
    // The lock on the entire session has expired. All messages received
    // under this session lock are now invalid. Close the session receiver
    // and re-accept the session to continue processing.
    Console.WriteLine($"Session lock lost for SessionId={message.SessionId}. " +
        "Re-accept the session to continue.");
}
```

To avoid lock expiration in the first place:
- **Use the processor**: `ServiceBusProcessor` automatically renews message locks via `MaxAutoLockRenewalDuration`.
- **Keep processing fast**: if processing takes longer than the lock duration (default 30 seconds for queues), either increase the lock duration on the entity or use auto-lock renewal.
- **Use `MaxAutoLockRenewalDuration`**: set this on `ServiceBusProcessorOptions` or call receiver-level lock renewal for long-running work.

## Error handling in the processor

The `ServiceBusProcessor` invokes `ProcessErrorAsync` for infrastructure-level errors (connection failures, authorization issues) that are not tied to a specific message. Message-level errors should be handled inside `ProcessMessageAsync`.

```C# Snippet:ServiceBusProcessorErrorHandler
string connectionString = "<connection_string>";
string queueName = "<queue_name>";

await using var client = new ServiceBusClient(connectionString);

ServiceBusProcessor processor = client.CreateProcessor(queueName, new ServiceBusProcessorOptions
{
    MaxConcurrentCalls = 5,
    AutoCompleteMessages = false
});

processor.ProcessMessageAsync += async args =>
{
    try
    {
        await ProcessMessageAsync(args.Message);
        await args.CompleteMessageAsync(args.Message);
    }
    catch (ServiceBusException ex) when (ex.Reason == ServiceBusFailureReason.MessageLockLost)
    {
        // Lock expired during processing. The message will be redelivered.
        // Log and move on — do not try to complete or abandon.
        Console.WriteLine($"Lock lost for {args.Message.MessageId}, will be redelivered.");
    }
    catch (Exception ex)
    {
        // Application-level failure. Abandon the message so it can be retried
        // (up to the entity's MaxDeliveryCount).
        Console.WriteLine($"Processing failed: {ex.Message}");
        await args.AbandonMessageAsync(args.Message);
    }
};

processor.ProcessErrorAsync += args =>
{
    // Infrastructure-level errors: connection drops, auth failures, etc.
    Console.WriteLine($"Error source: {args.ErrorSource}");
    Console.WriteLine($"Entity path: {args.EntityPath}");
    Console.WriteLine($"Namespace: {args.FullyQualifiedNamespace}");

    if (args.Exception is ServiceBusException sbEx)
    {
        Console.WriteLine($"Reason: {sbEx.Reason}, IsTransient: {sbEx.IsTransient}");

        if (sbEx.IsTransient)
        {
            // The processor retries automatically for transient errors.
            Console.WriteLine("Transient error — processor will retry automatically.");
        }
    }
    else
    {
        Console.WriteLine($"Non-ServiceBus exception: {args.Exception}");
    }

    return Task.CompletedTask;
};

await processor.StartProcessingAsync();

// Let the processor run. It handles retries internally for transient errors.
await Task.Delay(TimeSpan.FromMinutes(5));
await processor.StopProcessingAsync();
```

## Using IsTransient for retry decisions

The `ServiceBusException.IsTransient` property indicates whether the error is expected to resolve on its own. Use it as a quick check when you don't need reason-specific logic.

```C# Snippet:ServiceBusRetryWithIsTransient
int maxRetries = 3;
int attempt = 0;

while (attempt < maxRetries)
{
    try
    {
        await sender.SendMessageAsync(new ServiceBusMessage("Retry example"));
        break; // Success — exit the loop.
    }
    catch (ServiceBusException ex) when (ex.IsTransient)
    {
        attempt++;
        Console.WriteLine($"Transient error (attempt {attempt}/{maxRetries}): {ex.Message}");
        await Task.Delay(TimeSpan.FromSeconds(Math.Pow(2, attempt))); // Exponential backoff.
    }
    catch (ServiceBusException ex)
    {
        // Non-transient — retrying won't help.
        Console.WriteLine($"Permanent error ({ex.Reason}): {ex.Message}");
        throw;
    }
}
```

Note that the `ServiceBusClient` already has built-in retry logic (configurable via `ServiceBusClientOptions.RetryOptions`). Manual retry loops are only needed when you want application-level retry behavior beyond what the client provides — for example, recreating senders after a connection reset or implementing circuit-breaker patterns.

## ServiceBusFailureReason reference

| Reason | Transient | Recovery |
|--------|-----------|----------|
| `GeneralError` | Depends | Inspect the exception message for details |
| `MessagingEntityNotFound` | No | Verify entity name and provisioning |
| `MessageLockLost` | No | Message will be redelivered; do not settle |
| `MessageNotFound` | No | The message was already settled or expired |
| `MessageSizeExceeded` | No | Reduce payload or upgrade to Premium tier |
| `MessagingEntityDisabled` | No | Re-enable the entity in the portal |
| `QuotaExceeded` | No | Free space or scale the namespace |
| `ServiceBusy` | Yes | Back off and retry |
| `ServiceTimeout` | Yes | Retry; consider increasing operation timeout |
| `ServiceCommunicationProblem` | Yes | Check network connectivity and retry |
| `SessionCannotBeLocked` | No | Session is locked by another receiver |
| `SessionLockLost` | No | Re-accept the session to continue |
| `MessagingEntityAlreadyExists` | No | Entity already exists; skip creation |
