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

## Source

To see the full example source, see:

* [Sample06_Transactions.cs](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/servicebus/Azure.Messaging.ServiceBus/tests/Samples/Sample06_Transactions.cs)
