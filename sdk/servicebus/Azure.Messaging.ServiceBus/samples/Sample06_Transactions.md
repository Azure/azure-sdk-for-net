# Working with transactions

This sample demonstrates how to use [transactions](https://learn.microsoft.com/azure/service-bus-messaging/service-bus-transactions) with Service Bus. Transactions allow you to group operations together so that either all of them complete or none of them do. If any part of the transaction fails, the service will rollback the parts that succeeded on your behalf. You also can use familiar .NET semantics to complete or rollback the transaction using [TransactionScope](https://learn.microsoft.com/dotnet/api/system.transactions.transactionscope?view=netcore-3.1).

## Sending and completing a message in a transaction on the same entity

```C# Snippet:ServiceBusTransactionalSend
string fullyQualifiedNamespace = "<fully_qualified_namespace>";
string queueName = "<queue_name>";
// since ServiceBusClient implements IAsyncDisposable we create it with "await using"
await using ServiceBusClient client = new(fullyQualifiedNamespace, new DefaultAzureCredential());
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

## Setting session state within a transaction

```C# Snippet:ServiceBusTransactionalSetSessionState
string fullyQualifiedNamespace = "<fully_qualified_namespace>";
string queueName = "<queue_name>";
// since ServiceBusClient implements IAsyncDisposable we create it with "await using"
await using ServiceBusClient client = new(fullyQualifiedNamespace, new DefaultAzureCredential());
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

## Transactions across entities

When creating senders and receivers that should be part of a cross-entity transaction, you can set the `EnableCrossEntityTransaction` property of the `ServiceBusClientOptions` as shown below. When using cross-entity transactions, the first entity that an operation occurs on becomes the entity through which all subsequent sends will be routed through. This enables the service to perform a transaction that is meant to span multiple entities. This means that subsequent entities that perform their first operation need to either be senders, or if they are receivers they need to be on the same entity as the initial entity through which all sends are routed through (otherwise the service would not be able to ensure that the transaction is committed because it cannot route a receive operation through a different entity). For instance, if you have SenderA and ReceiverB that are created from a client with cross-entity transactions enabled, you would need to receive first with ReceiverB to allow this to work. If you first used SenderA to send to QueueA, and then attempted to receive from QueueB, an `InvalidOperationException` would be thrown. You could still receive from a ReceiverA after initially sending to SenderA, since they are both using the same queue. This would be useful if you also had a SenderB that you want to include as part of the transaction (otherwise there would be no need to use cross-entity transactions as you would be dealing with only one entity).

```C# Snippet:ServiceBusCrossEntityTransaction
string fullyQualifiedNamespace = "<fully_qualified_namespace>";
ServiceBusClientOptions options = new(){ EnableCrossEntityTransactions = true };
await using ServiceBusClient client = new ServiceBusClient(fullyQualifiedNamespace, new DefaultAzureCredential(), options);

ServiceBusReceiver receiverA = client.CreateReceiver("queueA");
ServiceBusSender senderB = client.CreateSender("queueB");
ServiceBusSender senderC = client.CreateSender("topicC");

ServiceBusReceivedMessage receivedMessage = await receiverA.ReceiveMessageAsync();

using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
{
    await receiverA.CompleteMessageAsync(receivedMessage);
    await senderB.SendMessageAsync(new ServiceBusMessage());
    await senderC.SendMessageAsync(new ServiceBusMessage());
    ts.Complete();
}
```
In the following snippet, we will look at an incorrect ordering that would cause an `InvalidOperationException` to be thrown.
Bad:
```C# Snippet:ServiceBusCrossEntityTransactionWrongOrder
string fullyQualifiedNamespace = "<fully_qualified_namespace>";
ServiceBusClientOptions options = new(){ EnableCrossEntityTransactions = true };
await using ServiceBusClient client = new(fullyQualifiedNamespace, new DefaultAzureCredential(), options);

ServiceBusReceiver receiverA = client.CreateReceiver("queueA");
ServiceBusSender senderB = client.CreateSender("queueB");
ServiceBusSender senderC = client.CreateSender("topicC");

// SenderB becomes the entity through which subsequent "sends" are routed through, since it is the first
// entity on which an operation is performed with the cross-entity transaction client.
await senderB.SendMessageAsync(new ServiceBusMessage());

ServiceBusReceivedMessage receivedMessage = await receiverA.ReceiveMessageAsync();

using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
{
    // This will throw an InvalidOperationException because a "receive" cannot be
    // routed through a different entity.
    await receiverA.CompleteMessageAsync(receivedMessage);
    await senderB.SendMessageAsync(new ServiceBusMessage());
    await senderC.SendMessageAsync(new ServiceBusMessage());
    ts.Complete();
}
```
