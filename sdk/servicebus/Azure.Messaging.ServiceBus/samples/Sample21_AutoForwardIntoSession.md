# Autoforwarding into a session-enabled queue

This sample demonstrates how to autoforward messages from a topic subscription into a **session-enabled** queue while preserving the session and message order. This is useful when you want to fan messages out through a topic but have each consumer read an ordered, per-session stream from a queue - keeping the messages in the queue's own storage instead of the topic. For concepts, see the [autoforwarding](https://learn.microsoft.com/azure/service-bus-messaging/service-bus-auto-forwarding) and [message sessions](https://learn.microsoft.com/azure/service-bus-messaging/message-sessions) documentation.

## How it works

A session-enabled entity can't be the *source* of autoforwarding (a single entity can't have both session support and `ForwardTo` set), but a session-enabled queue *can* be an autoforwarding *destination*. The pattern is:

- The **destination** is a session-enabled queue. Consumers read it with a `ServiceBusSessionReceiver`, which delivers each session's messages in order even when messages for different sessions are interleaved on the topic. (The destination can also be a topic that has session-enabled subscriptions.)
- The **source** is a topic with a regular (non-session) subscription whose `ForwardTo` points at the queue. The subscription is only a conduit - nothing consumes it directly - so it doesn't need sessions enabled itself. Enable `SupportOrdering` on the topic to guarantee that messages reach the subscription in the order they were sent; it defaults to `false`.
- Every message must carry a `SessionId`. The session ID is preserved across the forward, and a message without one is dead-lettered on the subscription (a session-enabled entity only accepts messages that have a session ID).

With `SupportOrdering` enabled and non-partitioned entities, the topic delivers to the subscription in send order, autoforwarding preserves that order into the destination, and the session receiver delivers each session's messages in order - so the per-session order is preserved end to end. Ordering isn't guaranteed if either entity is partitioned.

```C# Snippet:ServiceBusAutoForwardIntoSessionQueue
string fullyQualifiedNamespace = "<fully_qualified_namespace>";
string topicName = "<topic_name>";
string subscriptionName = "<subscription_name>";
string queueName = "<session_queue_name>";

var adminClient = new ServiceBusAdministrationClient(fullyQualifiedNamespace, new DefaultAzureCredential());
await using var client = new ServiceBusClient(fullyQualifiedNamespace, new DefaultAzureCredential());
// The destination is a session-enabled queue. Consumers read it with a
// session receiver, which gives them per-session FIFO ordering and lets
// the messages live in the queue's own storage instead of the topic.
await adminClient.CreateQueueAsync(new CreateQueueOptions(queueName)
{
    RequiresSession = true
});

// The source is a topic with a regular (non-session) subscription that
// auto-forwards into the session queue. The subscription is only a
// conduit - nothing consumes it directly - so it does not need sessions
// enabled, and a single entity cannot have both RequiresSession and
// ForwardTo set. SupportOrdering must be enabled on the topic to
// guarantee that messages reach the subscription in the order they were
// sent; it defaults to false.
await adminClient.CreateTopicAsync(new CreateTopicOptions(topicName)
{
    SupportOrdering = true
});
await adminClient.CreateSubscriptionAsync(new CreateSubscriptionOptions(topicName, subscriptionName)
{
    ForwardTo = queueName
});

// Send interleaved messages for two sessions. Every message must carry a
// SessionId: the session ID is preserved across the auto-forward, and a
// message without one is dead-lettered on the subscription because a
// session-enabled entity only accepts messages that have a session ID.
ServiceBusSender sender = client.CreateSender(topicName);
string[] sessionIds = { "session-1", "session-2" };
var messages = new List<ServiceBusMessage>();
for (int i = 0; i < 3; i++)
{
    foreach (string sessionId in sessionIds)
    {
        messages.Add(new ServiceBusMessage($"message-{i}")
        {
            SessionId = sessionId
        });
    }
}
await sender.SendMessagesAsync(messages);

// Receive each session on its own session receiver. The receiver holds an
// exclusive lock on one session and delivers that session's messages in
// order, even though the two sessions were interleaved on the topic. Each
// ReceiveMessageAsync call waits up to maxWaitTime for the next message
// (the forward is asynchronous); the loop ends when a call returns null.
var received = new List<ServiceBusReceivedMessage>();
foreach (string sessionId in sessionIds)
{
    await using ServiceBusSessionReceiver receiver = await client.AcceptSessionAsync(queueName, sessionId);
    for (int i = 0; i < 3; i++)
    {
        ServiceBusReceivedMessage message = await receiver.ReceiveMessageAsync(maxWaitTime: TimeSpan.FromSeconds(10));
        if (message == null)
        {
            break;
        }

        Console.WriteLine($"{message.SessionId}: {message.Body}");
        await receiver.CompleteMessageAsync(message);
        received.Add(message);
    }
}
```

## Next steps

Take a look at the [session send and receive sample](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/servicebus/Azure.Messaging.ServiceBus/samples/Sample03_SendReceiveSessions.md) and the [CRUD operations sample](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/servicebus/Azure.Messaging.ServiceBus/samples/Sample07_CrudOperations.md) to learn more about sessions and administration operations.
