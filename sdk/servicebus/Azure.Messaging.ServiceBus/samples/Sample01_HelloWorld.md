# Sending and Receiving Messages

This sample demonstrates how to send and receive messages from a Service Bus queue.

## Sending and receiving a message

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
ServiceBusMessage message = new ServiceBusMessage(Encoding.Default.GetBytes("Hello world!"));

// send the message
await sender.SendAsync(message);

// create a receiver that we can use to receive the message
ServiceBusReceiver receiver = client.CreateReceiver(queueName);

// the received message is a different type as it contains some service set properties
ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveAsync();

// get the message body as a string
string body = Encoding.Default.GetString(receivedMessage.Body.ToArray());
Console.WriteLine(body);
```

### Sending and receiving a batch of messages

We can send several messages at once using a `ServiceBusMessageBatch`. 

```C# Snippet:ServiceBusSendAndReceiveBatch
string connectionString = "<connection_string>";
string queueName = "<queue_name>";
// since ServiceBusClient implements IAsyncDisposable we create it with "await using"
await using var client = new ServiceBusClient(connectionString);

// create the sender
ServiceBusSender sender = client.CreateSender(queueName);

// create a message batch that we can send
ServiceBusMessageBatch messageBatch = await sender.CreateBatchAsync();
messageBatch.TryAdd(new ServiceBusMessage(Encoding.UTF8.GetBytes("First")));
messageBatch.TryAdd(new ServiceBusMessage(Encoding.UTF8.GetBytes("Second")));

// send the message batch
await sender.SendBatchAsync(messageBatch);

// create a receiver that we can use to receive the messages
ServiceBusReceiver receiver = client.CreateReceiver(queueName);

// the received message is a different type as it contains some service set properties
IList<ServiceBusReceivedMessage> receivedMessages = await receiver.ReceiveBatchAsync(maxMessages: 2);

foreach (ServiceBusReceivedMessage receivedMessage in receivedMessages)
{
    // get the message body as a string
    string body = Encoding.Default.GetString(receivedMessage.Body.ToArray());
    Console.WriteLine(body);
}
```

## Peeking a message

It's also possible to simply peek a message. Peeking a message does not require the message to be locked.

```C# Snippet:ServiceBusPeek
ServiceBusReceivedMessage peekedMessage = await receiver.PeekAsync();
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
