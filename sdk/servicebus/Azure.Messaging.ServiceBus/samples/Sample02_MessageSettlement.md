# Settling messages

This sample demonstrates how to [settle](https://learn.microsoft.com/azure/service-bus-messaging/message-transfers-locks-settlement#settling-receive-operations)
received messages. Message settlement can only be used when using a receiver in [PeekLock](https://learn.microsoft.com/azure/service-bus-messaging/message-transfers-locks-settlement#peeklock)
 mode, which is the default behavior. In order for the settlement operation to be successful, the message must be locked. By default, received messages will be locked for 30 seconds. This can be configured via the portal or when creating the queue or subscription using the `ServiceBusAdministrationClient` or by using the [Azure Resource Manager library](https://www.nuget.org/packages/Azure.ResourceManager.ServiceBus). Additionally, it is possible to extend the lock for an already received message by using the `RenewMessageLockAsync` method.

## Completing a message

```C# Snippet:ServiceBusCompleteMessage
string fullyQualifiedNamespace = "<fully_qualified_namespace>";
string queueName = "<queue_name>";

// since ServiceBusClient implements IAsyncDisposable we create it with "await using"
await using ServiceBusClient client = new(fullyQualifiedNamespace, new DefaultAzureCredential());
// create the sender
ServiceBusSender sender = client.CreateSender(queueName);

// create a message that we can send
ServiceBusMessage message = new("Hello world!");

// send the message
await sender.SendMessageAsync(message);

// create a receiver that we can use to receive and settle the message
ServiceBusReceiver receiver = client.CreateReceiver(queueName);

// the received message is a different type as it contains some service set properties
ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();

// complete the message, thereby deleting it from the service
await receiver.CompleteMessageAsync(receivedMessage);
```

## Abandon a message

```C# Snippet:ServiceBusAbandonMessage
ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();

// abandon the message, thereby releasing the lock and allowing it to be received again by this or other receivers
await receiver.AbandonMessageAsync(receivedMessage);
```

## Defer a message

```C# Snippet:ServiceBusDeferMessage
ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();

// defer the message, thereby preventing the message from being received again without using
// the received deferred message API.
await receiver.DeferMessageAsync(receivedMessage);

// receive the deferred message by specifying the service set sequence number of the original
// received message
ServiceBusReceivedMessage deferredMessage = await receiver.ReceiveDeferredMessageAsync(receivedMessage.SequenceNumber);
```

## Dead letter a message

```C# Snippet:ServiceBusDeadLetterMessage
ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();

// Dead-letter the message, thereby preventing the message from being received again without receiving from the dead letter queue.
// We can optionally pass a dead letter reason and dead letter description to further describe the reason for dead-lettering the message.
await receiver.DeadLetterMessageAsync(receivedMessage, "sample reason", "sample description");

// receive the dead lettered message with receiver scoped to the dead letter queue.
ServiceBusReceiver dlqReceiver = client.CreateReceiver(queueName, new ServiceBusReceiverOptions
{
    SubQueue = SubQueue.DeadLetter
});
ServiceBusReceivedMessage dlqMessage = await dlqReceiver.ReceiveMessageAsync();

// The reason and the description that we specified when dead-lettering the message will be available in the received dead letter message.
string reason = dlqMessage.DeadLetterReason;
string description = dlqMessage.DeadLetterErrorDescription;
```

## Renew the lock for a message and then complete it

```C# Snippet:ServiceBusRenewMessageLockAndComplete
ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();

// If we know that we are going to be processing the message for a long time, we can extend the lock for the message
// by the configured LockDuration (by default, 30 seconds).
await receiver.RenewMessageLockAsync(receivedMessage);

// simulate some processing of the message
await Task.Delay(TimeSpan.FromSeconds(10));

// complete the message, thereby deleting it from the service
await receiver.CompleteMessageAsync(receivedMessage);
```
