## Sending and Receiving Session Messages

This sample demonstrates how to send and receive session messages from a session-enabled Service Bus queue.

### Receiving from next available session

Receiving from sessions is performed using the `ServiceBusSessionReceiver`. This type derives from `ServiceBusReceiver` and exposes session-related functionality.

```C# Snippet:ServiceBusSendAndReceiveSessionMessage
string connectionString = "<connection_string>";
string queueName = "<queue_name>";
// since ServiceBusClient implements IAsyncDisposable we create it with "await using"
await using var client = new ServiceBusClient(connectionString);

// create the sender
ServiceBusSender sender = client.CreateSender(queueName);

// create a session message that we can send
ServiceBusMessage message = new ServiceBusMessage(Encoding.UTF8.GetBytes("Hello world!"))
{
    SessionId = "mySessionId"
};

// send the message
await sender.SendMessageAsync(message);

// create a session receiver that we can use to receive the message. Since we don't specify a
// particular session, we will get the next available session from the service.
ServiceBusSessionReceiver receiver = await client.AcceptNextSessionAsync(queueName);

// the received message is a different type as it contains some service set properties
ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();
Console.WriteLine(receivedMessage.SessionId);

// we can also set arbitrary session state using this receiver
// the state is specific to the session, and not any particular message
await receiver.SetSessionStateAsync(new BinaryData("some state"));

// the state can be retrieved for the session as well
BinaryData state = await receiver.GetSessionStateAsync();
```

### Receive from a specific session

```C# Snippet:ServiceBusReceiveFromSpecificSession
// create a receiver specifying a particular session
ServiceBusSessionReceiver receiver = await client.AcceptSessionAsync(queueName, "Session2");

// the received message is a different type as it contains some service set properties
ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();
Console.WriteLine(receivedMessage.SessionId);
```

## Source

To see the full example source, see:

* [Sample03_SendReceiveSessions.cs](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/servicebus/Azure.Messaging.ServiceBus/tests/Samples/Sample03_SendReceiveSessions.cs)
