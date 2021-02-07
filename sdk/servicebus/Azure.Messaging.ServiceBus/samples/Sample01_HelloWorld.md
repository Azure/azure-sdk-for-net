# Sending and Receiving Messages

This sample demonstrates how to send and receive messages from a Service Bus queue.

### Send and receive a message

Message sending is performed using the `ServiceBusSender`. Receiving is performed using the `ServiceBusReceiver`.

```C# Snippet:ServiceBusSendAndReceive
string connectionString = "<connection_string>";
string queueName = "<queue_name>";
// since ServiceBusClient implements IAsyncDisposable we create it with "await using"
await using var client = new ServiceBusClient(connectionString);

// create the sender
ServiceBusSender sender = client.CreateSender(queueName);

// create a message that we can send. UTF-8 encoding is used when providing a string.
ServiceBusMessage message = new ServiceBusMessage("Hello world!");

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

### Send and receive a batch of messages

There are two ways of sending several messages at once. The first way uses the `SendMessagesAsync` overload that accepts an IEnumerable of `ServiceBusMessage`. With this method, we will attempt to fit all of the supplied messages in a single message batch that we will send to the service. If the messages are too large to fit in a single batch, the operation will throw an exception.

```C# Snippet:ServiceBusSendAndReceiveBatch
IList<ServiceBusMessage> messages = new List<ServiceBusMessage>();
messages.Add(new ServiceBusMessage("First"));
messages.Add(new ServiceBusMessage("Second"));
// send the messages
await sender.SendMessagesAsync(messages);
```

The second way of doing this is using safe-batching. With safe-batching, you can create a `ServiceBusMessageBatch` object, which will allow you to attempt to messages one at a time to the batch using TryAdd. If the message cannot fit in the batch, TryAdd will return false.

```C# Snippet:ServiceBusSendAndReceiveSafeBatch
// add the messages that we plan to send to a local queue
Queue<ServiceBusMessage> messages = new Queue<ServiceBusMessage>();
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

## Peeking a message

It's also possible to simply peek a message. Peeking a message does not require the message to be locked.

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

### Cancel a scheduled message

Cancelling the scheduled message will delete it from the service.

```C# Snippet:ServiceBusCancelScheduled
await sender.CancelScheduledMessageAsync(seq);
```

## Source

To see the full example source, see:

* [Sample1_HelloWorld.cs](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/servicebus/Azure.Messaging.ServiceBus/tests/Samples/Sample01_HelloWorld.cs)
