# Cross Receiver Message Settlement

The message settlement APIs on the `ServiceBusReceiver` require passing in the
`ServiceBusReceivedMessage`. This can be limiting for scenarios in which the message needs to be persisted and then
settled across process boundaries. There are two strategies that can be used for settling a message with a different
receiver. The recommended strategy depends on the specific application scenario.

## Storing the entire `ServiceBusReceivedMessage`

If it is necessary to store the entire message and then rehydrate it in another process, use the following strategy.
First we can get the raw AMQP message bytes and lock token as shown below:  
*Note: The lock token is not
actually part of the AMQP message so it needs to stored separately from the AMQP bytes.*

```C# Snippet:ServiceBusWriteReceivedMessage
var client1 = new ServiceBusClient(connectionString);
ServiceBusSender sender = client1.CreateSender(queueName);

var message = new ServiceBusMessage("some message");
await sender.SendMessageAsync(message);

ServiceBusReceiver receiver1 = client1.CreateReceiver(queueName);
ServiceBusReceivedMessage receivedMessage = await receiver1.ReceiveMessageAsync();
ReadOnlyMemory<byte> amqpMessageBytes = receivedMessage.GetRawAmqpMessage().ToBytes().ToMemory();
ReadOnlyMemory<byte> lockTokenBytes = Guid.Parse(receivedMessage.LockToken).ToByteArray();
```

In order to rehydrate the message in another process, we would do the following:

```C# Snippet:ServiceBusReadReceivedMessage
AmqpAnnotatedMessage amqpMessage = AmqpAnnotatedMessage.FromBytes(new BinaryData(amqpMessageBytes));
ServiceBusReceivedMessage rehydratedMessage = ServiceBusReceivedMessage.FromAmqpMessage(amqpMessage, new BinaryData(lockTokenBytes));

var client2 = new ServiceBusClient(connectionString);
ServiceBusReceiver receiver2 = client2.CreateReceiver(queueName);
await receiver2.CompleteMessageAsync(rehydratedMessage);
```

## Storing only the lock token

If the entire message is not needed when settling the message in a different process, you can simply preserve the
lock token. In the example below, we store off the lock token using its GUID bytes. You can also simply store a
string if that is easier for your scenario.

```C# Snippet:ServiceBusWriteReceivedMessageLockToken
var client1 = new ServiceBusClient(connectionString);
ServiceBusSender sender = client1.CreateSender(queueName);

var message = new ServiceBusMessage("some message");
await sender.SendMessageAsync(message);

ServiceBusReceiver receiver1 = client1.CreateReceiver(queueName);
ServiceBusReceivedMessage receivedMessage = await receiver1.ReceiveMessageAsync();
ReadOnlyMemory<byte> lockTokenBytes = Guid.Parse(receivedMessage.LockToken).ToByteArray();
```

In order to rehydrate the message in another process using the lock token, we would do the following:  
*Note: Because we only stored the lock token, when we rehydrate the message all of the properties of the
`ServiceBusReceivedMessage` other than `LockToken` will have default values.*

```C# Snippet:ServiceBusReadReceivedMessageLockToken
ServiceBusReceivedMessage rehydratedMessage = ServiceBusModelFactory.ServiceBusReceivedMessage(lockTokenGuid: new Guid(lockTokenBytes.ToArray()));

var client2 = new ServiceBusClient(connectionString);
ServiceBusReceiver receiver2 = client2.CreateReceiver(queueName);
await receiver2.CompleteMessageAsync(rehydratedMessage);
```
