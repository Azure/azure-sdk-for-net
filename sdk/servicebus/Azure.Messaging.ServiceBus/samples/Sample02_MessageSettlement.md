# Settling Messages

This sample demonstrates how to [settle](https://docs.microsoft.com/azure/service-bus-messaging/message-transfers-locks-settlement#settling-receive-operations) received messages. Message settlement can only be used when using a receiver in [PeekLock](https://docs.microsoft.com/azure/service-bus-messaging/message-transfers-locks-settlement#peeklock) mode, which is the default behavior.

## Completing a message

```C# Snippet:ServiceBusCompleteMessage
string connectionString = "<connection_string>";
string queueName = "<queue_name>";
// since ServiceBusClient implements IAsyncDisposable we create it with "await using"
await using var client = new ServiceBusClient(connectionString);

// create the sender
ServiceBusSender sender = client.CreateSender(queueName);

// create a message that we can send
ServiceBusMessage message = new ServiceBusMessage("Hello world!");

// send the message
await sender.SendMessageAsync(message);

// create a receiver that we can use to receive and settle the message
ServiceBusReceiver receiver = client.CreateReceiver(queueName);

// the received message is a different type as it contains some service set properties
ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();

// complete the message, thereby deleting it from the service
await receiver.CompleteMessageAsync(receivedMessage);
```

### Abandon a message

```C# Snippet:ServiceBusAbandonMessage
ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();

// abandon the message, thereby releasing the lock and allowing it to be received again by this or other receivers
await receiver.AbandonMessageAsync(receivedMessage);
```

### Defer a message

```C# Snippet:ServiceBusDeferMessage
ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();

// defer the message, thereby preventing the message from being received again without using
// the received deferred message API.
await receiver.DeferMessageAsync(receivedMessage);

// receive the deferred message by specifying the service set sequence number of the original
// received message
ServiceBusReceivedMessage deferredMessage = await receiver.ReceiveDeferredMessageAsync(receivedMessage.SequenceNumber);
```

### Dead letter a message

```C# Snippet:ServiceBusDeadLetterMessage
ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();

// dead-letter the message, thereby preventing the message from being received again without receiving from the dead letter queue.
await receiver.DeadLetterMessageAsync(receivedMessage);

// receive the dead lettered message with receiver scoped to the dead letter queue.
ServiceBusReceiver dlqReceiver = client.CreateReceiver(queueName, new ServiceBusReceiverOptions
{
    SubQueue = SubQueue.DeadLetter
});
ServiceBusReceivedMessage dlqMessage = await dlqReceiver.ReceiveMessageAsync();
```

## Source

To see the full example source, see:

* [Sample02_MessageSettlement.cs](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/servicebus/Azure.Messaging.ServiceBus/tests/Samples/Sample02_MessageSettlement.cs)
