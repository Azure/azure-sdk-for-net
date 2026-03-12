# Exception Handling

This sample covers patterns for handling `ServiceBusException` and its `Reason` property to build resilient applications. The `ServiceBusFailureReason` enum identifies well-known failure categories, so your code can take the right recovery action instead of applying a generic retry to every error.

## Structured handling with ServiceBusFailureReason

Every `ServiceBusException` includes a `Reason` property of type `ServiceBusFailureReason`. Switching on this value lets you separate transient failures (retry) from permanent failures (fail fast) from lock-related failures (let the message be redelivered).

```C# Snippet:ServiceBusStructuredExceptionHandling
string fullyQualifiedNamespace = "<fully_qualified_namespace>";
string queueName = "<queue_name>";

await using var client = new ServiceBusClient(fullyQualifiedNamespace, new DefaultAzureCredential());
ServiceBusSender sender = client.CreateSender(queueName);

try
{
    await sender.SendMessageAsync(new ServiceBusMessage("Hello"));
}
catch (ServiceBusException ex) when (ex.Reason == ServiceBusFailureReason.ServiceBusy)
{
    // Transient: the service is temporarily overloaded. Back off and let the caller decide whether to retry.
    Console.WriteLine("Service is busy, backing off for 10 seconds...");
    await Task.Delay(TimeSpan.FromSeconds(10));
    throw;
}
catch (ServiceBusException ex) when (ex.Reason == ServiceBusFailureReason.ServiceTimeout)
{
    // Transient: the operation timed out. Retry with a longer timeout or backoff.
    Console.WriteLine($"Operation timed out: {ex.Message}");
    throw;
}
catch (ServiceBusException ex) when (ex.Reason == ServiceBusFailureReason.ServiceCommunicationProblem)
{
    // Transient: network-level failure. Check connectivity and retry.
    Console.WriteLine($"Communication problem: {ex.Message}");
    throw;
}
catch (ServiceBusException ex) when (ex.Reason == ServiceBusFailureReason.QuotaExceeded)
{
    // Capacity: the namespace or entity has hit its size or throughput limit.
    // Do not retry immediately — either wait for space to free up or scale the namespace.
    Console.WriteLine($"Quota exceeded: {ex.Message}");
    throw;
}
catch (ServiceBusException ex) when (ex.Reason == ServiceBusFailureReason.MessageSizeExceeded)
{
    // Permanent: the message payload is too large for the tier. This will never succeed
    // without reducing the message size or upgrading to Premium.
    Console.WriteLine($"Message too large ({ex.Message}). Reduce payload size.");
    throw;
}
catch (ServiceBusException ex) when (ex.Reason == ServiceBusFailureReason.MessagingEntityNotFound)
{
    // Permanent: the queue, topic, or subscription does not exist. Check the entity name
    // and ensure it has been provisioned.
    Console.WriteLine($"Entity not found: {ex.Message}");
    throw;
}
catch (ServiceBusException ex) when (ex.Reason == ServiceBusFailureReason.MessagingEntityDisabled)
{
    // Permanent: the entity is disabled in the portal or via management API.
    Console.WriteLine($"Entity is disabled: {ex.Message}");
    throw;
}
catch (ServiceBusException ex) when (ex.Reason == ServiceBusFailureReason.MessagingEntityAlreadyExists)
{
    // Permanent: attempted to create an entity that already exists.
    Console.WriteLine($"Entity already exists: {ex.Message}");
    throw;
}
catch (ServiceBusException ex)
{
    // Catch-all for any other ServiceBusFailureReason (GeneralError, MessageNotFound, etc.).
    Console.WriteLine($"Service Bus error ({ex.Reason}): {ex.Message}");
    Console.WriteLine($"Is transient: {ex.IsTransient}");
    throw;
}
```

Note that `ServiceBusException` does not cover all failure types. Authentication and authorization errors surface as `UnauthorizedAccessException`, and cancellation (e.g., from shutdown tokens) surfaces as `OperationCanceledException`. Add separate catch clauses for these when appropriate.

## Handling lock-related failures

When processing messages with peek-lock (the default), the lock can expire if processing takes too long. The two lock-related failure reasons require different recovery strategies.

```C# Snippet:ServiceBusLockExceptionHandling
string fullyQualifiedNamespace = "<fully_qualified_namespace>";
string queueName = "<queue_name>";

await using var client = new ServiceBusClient(fullyQualifiedNamespace, new DefaultAzureCredential());
ServiceBusReceiver receiver = client.CreateReceiver(queueName);

ServiceBusReceivedMessage message = await receiver.ReceiveMessageAsync();

try
{
    // Simulate slow processing that might exceed the lock duration.
    // ProcessMessageAsync represents your application logic (defined elsewhere).
    await ProcessMessageAsync(message);

    // Ensure processing is idempotent — if the lock expires before settlement,
    // the message will be redelivered and processed again. Common strategies
    // include deduplication checks and upsert semantics.
    // See https://learn.microsoft.com/azure/service-bus-messaging/message-transfers-locks-settlement
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
    //
    // Note: SessionLockLost only applies when using session-enabled receivers
    // (via AcceptNextSessionAsync). It is shown here alongside MessageLockLost
    // for completeness.
    Console.WriteLine($"Session lock lost for SessionId={message.SessionId}. " +
        "Re-accept the session to continue.");
}
```

To avoid lock expiration in the first place:
- **Use the processor**: `ServiceBusProcessor` automatically renews message locks via `MaxAutoLockRenewalDuration`.
- **Keep processing fast**: if processing takes longer than the lock duration configured for the queue or subscription, either increase the lock duration on the entity or use auto-lock renewal.
- **Use `MaxAutoLockRenewalDuration`**: set this to at least the longest expected processing time (including retries or delays in your handler), plus ~25% margin. Set this on `ServiceBusProcessorOptions` or call receiver-level lock renewal for long-running work.

## Error handling in the processor

The `ServiceBusProcessor` invokes `ProcessErrorAsync` for errors that occur outside your message handler — including connection failures, authorization issues, auto-lock-renewal failures, and auto-complete/abandon failures. Check `args.ErrorSource` to distinguish the origin. Message-level errors from your own processing logic should be handled inside `ProcessMessageAsync`.

```C# Snippet:ServiceBusProcessorErrorHandler
string fullyQualifiedNamespace = "<fully_qualified_namespace>";
string queueName = "<queue_name>";

await using var client = new ServiceBusClient(fullyQualifiedNamespace, new DefaultAzureCredential());

await using ServiceBusProcessor processor = client.CreateProcessor(queueName, new ServiceBusProcessorOptions
{
    MaxConcurrentCalls = 5,
    AutoCompleteMessages = false
});

// configure the message and error handler to use
processor.ProcessMessageAsync += MessageHandler;
processor.ProcessErrorAsync += ErrorHandler;

async Task MessageHandler(ProcessMessageEventArgs args)
{
    try
    {
        await ProcessMessageAsync(args.Message);
    }
    catch (Exception ex)
    {
        // Application-level processing failure. Abandon the message so it
        // can be retried (up to the entity's MaxDeliveryCount).
        Console.WriteLine($"Processing failed: {ex.Message}");

        try
        {
            await args.AbandonMessageAsync(args.Message);
        }
        catch (ServiceBusException abandonEx)
        {
            Console.WriteLine($"Abandon failed for {args.Message.MessageId}: {abandonEx.Message}");
        }

        return;
    }

    // Processing succeeded — settle the message.
    // Because lock loss causes redelivery, ensure your processing logic is
    // idempotent — it should produce the same result if a message is processed
    // more than once. Common strategies include deduplication checks and upsert
    // semantics.
    // See https://learn.microsoft.com/azure/service-bus-messaging/message-transfers-locks-settlement
    try
    {
        await args.CompleteMessageAsync(args.Message);
    }
    catch (ServiceBusException ex) when (ex.Reason == ServiceBusFailureReason.MessageLockLost)
    {
        // Lock expired before settlement. The message will be redelivered.
        Console.WriteLine($"Lock lost for {args.Message.MessageId}, will be redelivered.");
    }
    catch (ServiceBusException ex)
    {
        // Settlement failed for another reason — log for diagnostics.
        Console.WriteLine($"Settlement failed for {args.Message.MessageId} ({ex.Reason}): {ex.Message}");
    }
}

Task ErrorHandler(ProcessErrorEventArgs args)
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
}

await processor.StartProcessingAsync();

// Let the processor run. It handles retries internally for transient errors.
await Task.Delay(TimeSpan.FromMinutes(5));
await processor.StopProcessingAsync();
```

## Using IsTransient for retry decisions

The `ServiceBusClient` retries transient errors automatically (default: 3 retries with exponential backoff, configurable via `ServiceBusClientOptions.RetryOptions`). The following manual retry loop is only needed for application-level patterns the built-in retry cannot handle — for example, recreating senders after a connection reset or implementing circuit-breaker logic.

```C# Snippet:ServiceBusRetryWithIsTransient
string fullyQualifiedNamespace = "<fully_qualified_namespace>";
string queueName = "<queue_name>";

await using var client = new ServiceBusClient(fullyQualifiedNamespace, new DefaultAzureCredential());
ServiceBusSender sender = client.CreateSender(queueName);

int maxAttempts = 3;
int attempt = 0;

while (attempt < maxAttempts)
{
    try
    {
        await sender.SendMessageAsync(new ServiceBusMessage("Retry example"));
        break; // Success — exit the loop.
    }
    catch (ServiceBusException ex) when (ex.IsTransient)
    {
        attempt++;
        Console.WriteLine($"Transient error (attempt {attempt}/{maxAttempts}): {ex.Message}");

        if (attempt == maxAttempts)
        {
            Console.WriteLine("Max attempts reached. Giving up.");
            throw;
        }

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
| `ServiceBusy` | Yes | Back off and rethrow; see [Using IsTransient for retry decisions](#using-istransient-for-retry-decisions) below |
| `ServiceTimeout` | Yes | Log and rethrow; see [Using IsTransient for retry decisions](#using-istransient-for-retry-decisions) below |
| `ServiceCommunicationProblem` | Yes | Check network connectivity and rethrow; see [Using IsTransient for retry decisions](#using-istransient-for-retry-decisions) below |
| `SessionCannotBeLocked` | No | Session is locked by another receiver |
| `SessionLockLost` | No | Re-accept the session to continue |
| `MessagingEntityAlreadyExists` | No | Entity already exists; skip creation |
