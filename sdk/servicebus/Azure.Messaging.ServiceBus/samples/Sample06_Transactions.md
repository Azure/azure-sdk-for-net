## Working with transactions

This sample demonstrates how to use [transactions](https://docs.microsoft.com/azure/service-bus-messaging/service-bus-transactions) with Service Bus. Transactions allow you to group operations together so that either all of them complete or none of them do. If any part of the transaction fails, the service will rollback the parts that succeeded on your behalf. You also can use familiar .NET semantics to complete or rollback the transaction using [TransactionScope](https://docs.microsoft.com/dotnet/api/system.transactions.transactionscope?view=netcore-3.1).

### Sending and completing a message in a transaction on the same entity

```C# Snippet:ServiceBusTransactionalSend
string connectionString = "<connection_string>";
string queueName = "<queue_name>";
// since ServiceBusClient implements IAsyncDisposable we create it with "await using"
await using var client = new ServiceBusClient(connectionString);
ServiceBusSender sender = client.CreateSender(queueName);

await sender.SendMessageAsync(new ServiceBusMessage(Encoding.UTF8.GetBytes("First")));
ServiceBusReceiver receiver = client.CreateReceiver(queueName);
ServiceBusReceivedMessage firstMessage = await receiver.ReceiveMessageAsync();
using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
{
    await sender.SendMessageAsync(new ServiceBusMessage(Encoding.UTF8.GetBytes("Second")));
    await receiver.CompleteMessageAsync(firstMessage);
    ts.Complete();
}
```

### Setting session state within a transaction

```C# Snippet:ServiceBusTransactionalSetSessionState
string connectionString = "<connection_string>";
string queueName = "<queue_name>";
// since ServiceBusClient implements IAsyncDisposable we create it with "await using"
await using var client = new ServiceBusClient(connectionString);
ServiceBusSender sender = client.CreateSender(queueName);

await sender.SendMessageAsync(new ServiceBusMessage("my message") { SessionId = "sessionId" });
ServiceBusSessionReceiver receiver = await client.AcceptNextSessionAsync(queueName);
ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();

var state = Encoding.UTF8.GetBytes("some state");
using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
{
    await receiver.CompleteMessageAsync(receivedMessage);
    await receiver.SetSessionStateAsync(new BinaryData(state));
    ts.Complete();
}
```

### Transactions across entities
In the previous version of the library, when attempting to perform transactions that spanned multiple entities, it was necessary to configure your senders so that they would send-via the other entity in the transaction. With updates to the service, the new library introduces the concept of transaction groups to handle cross entity transactions. When creating senders and receivers that should be part of a cross-entity transaction, you can specify the same `TransactionGroup` string in the options as shown below. 

There are a few caveats when working with transaction groups: 
The first entity that performs an operation becomes the implicit send-via entity. This means that subsequent entities that perform their first operation need to either be senders, or if they are receivers they need to be on the same entity as the initial send-via entity. For instance, if you have SenderA and ReceiverB that are part of the same transaction group, you would need to receive first with ReceiverB to allow this to work. If you first used SenderA to send to Queue A, and then attempted to receive from Queue B, an `InvalidOperationException` would be thrown. You could still add a ReceiverA to the same transaction group after initially sending to SenderA, since they are both using the same queue. This would be useful if you also had a SenderB that you want to include as part of the transaction group (otherwise there would be no need to use transaction groups as you would be dealing with only one entity).

```C# Snippet:ServiceBusTransactionGroup
// the first sender won't be part of our transaction group
ServiceBusSender senderA = client.CreateSender(queueA.QueueName);

string transactionGroup = "myTxn";

ServiceBusReceiver receiverA = client.CreateReceiver(queueA.QueueName, new ServiceBusReceiverOptions
{
    TransactionGroup = transactionGroup
});
ServiceBusSender senderB = client.CreateSender(queueB.QueueName, new ServiceBusSenderOptions
{
    TransactionGroup = transactionGroup
});
ServiceBusSender senderC = client.CreateSender(topicC.TopicName, new ServiceBusSenderOptions
{
    TransactionGroup = transactionGroup
});

var message = new ServiceBusMessage();

await senderA.SendMessageAsync(message);

// since the first operation for any members of the transaction group occurs on QueueA, this becomes the implicit send-via
// entity
ServiceBusReceivedMessage receivedMessage = await receiverA.ReceiveMessageAsync();

using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
{
    await receiverA.CompleteMessageAsync(receivedMessage);
    await senderB.SendMessageAsync(message);
    await senderC.SendMessageAsync(message);
    ts.Complete();
}
```

## Source

To see the full example source, see:

* [Sample06_Transactions.cs](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/servicebus/Azure.Messaging.ServiceBus/tests/Samples/Sample06_Transactions.cs)
