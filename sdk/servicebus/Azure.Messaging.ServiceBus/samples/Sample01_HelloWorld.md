# Sending and Receiving Messages

This sample demonstrates how to send and receive messages from a Service Bus queue.

### Send and receive a message

Message sending is performed using the `ServiceBusSender`. Receiving is performed using the 
`ServiceBusReceiver`.

```C# Snippet:ServiceBusSendAndReceive
string connectionString = "<connection_string>";
string queueName = "<queue_name>";
// since ServiceBusClient implements IAsyncDisposable we create it with "await using"
await using var client = new ServiceBusClient(connectionString);

// create the sender
ServiceBusSender sender = client.CreateSender(queueName);

// create a message that we can send
ServiceBusMessage message = new ServiceBusMessage(Encoding.UTF8.GetBytes("Hello world!"));

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

There are two ways of sending several messages at once. The first way uses the `SendMessagesAsync`
overload that accepts an IEnumerable of `ServiceBusMessage`. With this method, we will attempt to fit all of
the supplied messages in a single message batch that we will send to the service. If the messages are too large
to fit in a single batch, the operation will throw an exception.

```C# Snippet:ServiceBusSendAndReceiveBatch
IList<ServiceBusMessage> messages = new List<ServiceBusMessage>();
messages.Add(new ServiceBusMessage(Encoding.UTF8.GetBytes("First")));
messages.Add(new ServiceBusMessage(Encoding.UTF8.GetBytes("Second")));
// send the messages
await sender.SendMessagesAsync(messages);
```
The second way of doing this is using safe-batching. With safe-batching, you can create a `ServiceBusMessageBatch` object,
which will allow you to attempt to messages one at a time to the batch using TryAdd. If the message cannot fit in the batch,
TryAdd will return false.

```C# Snippet:ServiceBusSendAndReceiveSafeBatch
ServiceBusMessageBatch messageBatch = await sender.CreateMessageBatchAsync();
messageBatch.TryAddMessage(new ServiceBusMessage(Encoding.UTF8.GetBytes("First")));
messageBatch.TryAddMessage(new ServiceBusMessage(Encoding.UTF8.GetBytes("Second")));

// send the message batch
await sender.SendMessagesAsync(messageBatch);
```

## Peeking a message

It's also possible to simply peek a message. Peeking a message does not require the message to be locked.

```C# Snippet:ServiceBusPeek
ServiceBusReceivedMessage peekedMessage = await receiver.PeekMessageAsync();
```

### Schedule a message

We can schedule a message to be enqueued at a later time. The message won't be able to be received
until that time, though it can still be peeked before that. We get back the message sequence number
which can be used to cancel the scheduled message.

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

* [Sample1_HelloWorld.cs](../tests/Samples/Sample01_HelloWorld.cs)
