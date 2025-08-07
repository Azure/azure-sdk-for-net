# Sending and receiving messages

This sample demonstrates how to send and receive messages from a Service Bus queue. Once a message is received, you will typically want to settle it. Message settlement is covered in detail in the [Settling Messages samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/servicebus/Azure.Messaging.ServiceBus/samples/Sample02_MessageSettlement.md).

### Send and receive a message using queues

Message sending is performed using the `ServiceBusSender`. Receiving is performed using the `ServiceBusReceiver`.

```C# Snippet:ServiceBusSendAndReceive
string fullyQualifiedNamespace = "<fully_qualified_namespace>";
string queueName = "<queue_name>";

// since ServiceBusClient implements IAsyncDisposable we create it with "await using"
await using ServiceBusClient client = new(fullyQualifiedNamespace, new DefaultAzureCredential());
// create the sender
ServiceBusSender sender = client.CreateSender(queueName);

// create a message that we can send. UTF-8 encoding is used when providing a string.
ServiceBusMessage message = new("Hello world!");

// send the message
await sender.SendMessageAsync(message);

// create a receiver that we can use to receive the message
ServiceBusReceiver receiver = client.CreateReceiver(queueName);

// the received message is a different type as it contains some service set properties
ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();

// get the message body as a string
string body = receivedMessage.Body.ToString();
Console.WriteLine(body);
```

### Send and receive a message using topics and subscriptions

As discussed in the [Key concepts section](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/servicebus/Azure.Messaging.ServiceBus/README.md#key-concepts) of the README, Service Bus supports topics and subscriptions that are useful in pub/sub scenarios. When using topics and subscriptions, each subscription will get its own copy of each message that is delivered to the topic. So completing a message in one subscription won't impact what happens to the message in a different subscription. Another important point about using subscriptions is that messages that were delivered to a topic *before* a subscription resource is created (whether creating resources via portal, the `ServiceBusAdministrationClient`, or the management library) will never get delivered to that subscription. The types that we use to send and receive messages are the same as the types used to send and receive messages using queues. However, the way we construct them is slightly different. When constructing a `ServiceBusSender` we pass the topic name to the `CreateSender` method. When constructing a `ServiceBusReceiver`, we have to pass both the topic name *and* the subscription name.

```C# Snippet:ServiceBusSendAndReceiveTopic
string fullyQualifiedNamespace = "<fully_qualified_namespace>";
string topicName = "<topic_name>";
string subscriptionName = "<subscription_name>";

// since ServiceBusClient implements IAsyncDisposable we create it with "await using"
await using ServiceBusClient client = new(fullyQualifiedNamespace, new DefaultAzureCredential());
// create the sender that we will use to send to our topic
ServiceBusSender sender = client.CreateSender(topicName);

// create a message that we can send. UTF-8 encoding is used when providing a string.
ServiceBusMessage message = new("Hello world!");

// send the message
await sender.SendMessageAsync(message);

// create a receiver for our subscription that we can use to receive the message
ServiceBusReceiver receiver = client.CreateReceiver(topicName, subscriptionName);

// the received message is a different type as it contains some service set properties
ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();

// get the message body as a string
string body = receivedMessage.Body.ToString();
Console.WriteLine(body);
```

### Send and receive a batch of messages

#### Sending a batch of messages

There are two ways of sending several messages at once. The first way uses the `SendMessagesAsync` overload that accepts an IEnumerable of `ServiceBusMessage`. With this method, we will attempt to fit all of the supplied messages in a single message batch that we will send to the service. If the messages are too large to fit in a single batch, the operation will throw an exception.

```C# Snippet:ServiceBusSendAndReceiveBatch
IList<ServiceBusMessage> messages = new List<ServiceBusMessage>
{
    new ServiceBusMessage("First"),
    new ServiceBusMessage("Second")
};
// send the messages
await sender.SendMessagesAsync(messages);
```

The second way of doing this is using safe-batching. With safe-batching, you can create a `ServiceBusMessageBatch` object, which will allow you to attempt to messages one at a time to the batch using TryAdd. If the message cannot fit in the batch, TryAdd will return false.

```C# Snippet:ServiceBusSendAndReceiveSafeBatch
// add the messages that we plan to send to a local queue
Queue<ServiceBusMessage> messages = new();
messages.Enqueue(new ServiceBusMessage("First message"));
messages.Enqueue(new ServiceBusMessage("Second message"));
messages.Enqueue(new ServiceBusMessage("Third message"));

// create a message batch that we can send
// total number of messages to be sent to the Service Bus queue
int messageCount = messages.Count;

// while all messages are not sent to the Service Bus queue
while (messages.Count > 0)
{
    // start a new batch
    using ServiceBusMessageBatch messageBatch = await sender.CreateMessageBatchAsync();

    // add the first message to the batch
    if (messageBatch.TryAddMessage(messages.Peek()))
    {
        // dequeue the message from the .NET queue once the message is added to the batch
        messages.Dequeue();
    }
    else
    {
        // if the first message can't fit, then it is too large for the batch
        throw new Exception($"Message {messageCount - messages.Count} is too large and cannot be sent.");
    }

    // add as many messages as possible to the current batch
    while (messages.Count > 0 && messageBatch.TryAddMessage(messages.Peek()))
    {
        // dequeue the message from the .NET queue as it has been added to the batch
        messages.Dequeue();
    }

    // now, send the batch
    await sender.SendMessagesAsync(messageBatch);

    // if there are any remaining messages in the .NET queue, the while loop repeats
}
```
#### Receiving a batch of messages
```C# Snippet:ServiceBusReceiveBatch
// create a receiver that we can use to receive the messages
ServiceBusReceiver receiver = client.CreateReceiver(queueName);

// the received message is a different type as it contains some service set properties
// a batch of messages (maximum of 2 in this case) are received
IReadOnlyList<ServiceBusReceivedMessage> receivedMessages = await receiver.ReceiveMessagesAsync(maxMessages: 2);

// go through each of the messages received
foreach (ServiceBusReceivedMessage receivedMessage in receivedMessages)
{
    // get the message body as a string
    string body = receivedMessage.Body.ToString();
}
```

## Peeking a message

It's also possible to simply peek a message. Peeking a message does not require the message to be locked. Because the message is not locked to a specific receiver, the message will not be able to be settled. It's also possible that another receiver could lock the message and settle it while you are looking at the peeked message.

```C# Snippet:ServiceBusPeek
ServiceBusReceivedMessage peekedMessage = await receiver.PeekMessageAsync();
```

### Schedule a message

We can schedule a message to be enqueued at a later time. The message won't be able to be received until that time, though it can still be peeked before that. We get back the message sequence number which can be used to cancel the scheduled message.

```C# Snippet:ServiceBusSchedule
long seq = await sender.ScheduleMessageAsync(
    message,
    DateTimeOffset.Now.AddDays(1));
```

You can also schedule a message by setting the `ScheduledEnqueueTime` property on the message and using the `SendMessageAsync` or `SendMessagesAsync` methods. The difference is that you won't get back the sequence number when using these methods so you would need to peek the message to get the sequence number if you wanted to cancel the scheduled message.

### Cancel a scheduled message

Cancelling the scheduled message will delete it from the service.

```C# Snippet:ServiceBusCancelScheduled
await sender.CancelScheduledMessageAsync(seq);
```

### Setting time to live

Message time to live can be configured at the queue or subscription level. By default, it is 14 days. Once this time has passed, the message is considered "expired". You can configure what happens to expired messages at the queue or subscription level. By default, these messages are deleted, but they can also be configured to move to the dead letter queue. More information about message expiry can be found [here](https://learn.microsoft.com/azure/service-bus-messaging/message-expiration). If you want to have an individual message expire before the entity-level configured time, you can set the `TimeToLive` property on the message.

```C# Snippet:ServiceBusMessageTimeToLive
var message = new ServiceBusMessage("Hello world!") { TimeToLive = TimeSpan.FromMinutes(5) };
```
