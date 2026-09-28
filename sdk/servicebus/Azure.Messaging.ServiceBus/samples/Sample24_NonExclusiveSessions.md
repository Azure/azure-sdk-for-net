# Taking over a non-exclusive session

This sample shows how a second receiver can cooperatively take over a session while the first receiver still holds its lock, then settle a message received by the first receiver. Use a **Premium** Service Bus namespace and an existing **session-enabled queue** with a lock duration long enough for the work shown here. The namespace's service deployment must also support non-exclusive sessions; being on Premium alone does not guarantee availability. Use Azure.Messaging.ServiceBus 7.21.0-beta.1 or later.

When a deployment does not support this feature, accepting a non-exclusive session can throw `NotSupportedException` (or a service-specific error for an unrecognized rejection). Do not silently fall back to an exclusive session: that changes the takeover behavior. Non-exclusive settlement uses the management link and can have lower throughput than exclusive settlement.

```C# Snippet:ServiceBusTakeOverNonExclusiveSession
string fullyQualifiedNamespace = "<premium_fully_qualified_namespace>";
string queueName = "<session_enabled_queue_name>";
var credential = new DefaultAzureCredential();
await using ServiceBusClient client = new(fullyQualifiedNamespace, credential);
await using ServiceBusSender sender = client.CreateSender(queueName);
string sessionId = Guid.NewGuid().ToString();

await sender.SendMessageAsync(new ServiceBusMessage("work to hand off") { SessionId = sessionId });

// Keep the first receiver open while the second takes over its session.
await using ServiceBusSessionReceiver firstReceiver = await client.AcceptSessionAsync(
    queueName, sessionId,
    new ServiceBusSessionReceiverOptions { EnableNonExclusiveSession = true });

if (firstReceiver.IsSessionExclusive || firstReceiver.SessionLockToken == null)
{
    throw new InvalidOperationException("The service did not grant a non-exclusive session lock.");
}

ServiceBusReceivedMessage message = await firstReceiver.ReceiveMessageAsync(
    maxWaitTime: TimeSpan.FromSeconds(10));
if (message == null)
{
    throw new InvalidOperationException("Timed out waiting for the session message.");
}

Console.WriteLine(message.Body);

// The token is sensitive: share it only with a trusted receiver with Listen rights.
// It is a string on the receiver but a Guid in the takeover options.
Guid lockToken = Guid.Parse(firstReceiver.SessionLockToken);
await using ServiceBusSessionReceiver nextReceiver = await client.AcceptSessionAsync(
    queueName, sessionId,
    new ServiceBusSessionReceiverOptions
    {
        EnableNonExclusiveSession = true,
        SessionLockToken = lockToken
    });

if (nextReceiver.IsSessionExclusive || nextReceiver.SessionLockToken != firstReceiver.SessionLockToken)
{
    throw new InvalidOperationException("The session was not taken over with the expected lock token.");
}

// The replacement link can be ready before its management operations are.
// Wait for the new holder to become active before settling the handed-off message.
using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(30));
while (true)
{
    try
    {
        await nextReceiver.GetSessionStateAsync(timeout.Token);
        break;
    }
    catch (ServiceBusException ex) when (
        ex.Reason == ServiceBusFailureReason.SessionLockLost && !timeout.IsCancellationRequested)
    {
        await Task.Delay(TimeSpan.FromMilliseconds(100), timeout.Token);
    }
}

await nextReceiver.CompleteMessageAsync(message);
```

The first receiver is still open when `nextReceiver` accepts the same session using its lock token. The new holder completes the first receiver's message over the management link. After takeover, the first receiver no longer owns the session; subsequent operations on it can fail with `SessionLockLost`. Treat the token as sensitive and never log it or store it unprotected. For the usual exclusive session flow, see [sending and receiving session messages](Sample03_SendReceiveSessions.md).
