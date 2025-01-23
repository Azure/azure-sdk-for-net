# Sending and receiving session messages

This sample demonstrates how to send and receive session messages from a session-enabled Service Bus queues. For concepts related to sessions, please refer to the [Service Bus sessions documentation](https://learn.microsoft.com/azure/service-bus-messaging/message-sessions).

## Receiving from next available session

Receiving from sessions is performed using the `ServiceBusSessionReceiver`. This type derives from `ServiceBusReceiver` and exposes session-related functionality.

```C# Snippet:ServiceBusSendAndReceiveSessionMessage
string fullyQualifiedNamespace = "<fully_qualified_namespace>";
string queueName = "<queue_name>";

// since ServiceBusClient implements IAsyncDisposable we create it with "await using"
await using ServiceBusClient client = new(fullyQualifiedNamespace, new DefaultAzureCredential());

// create the sender
ServiceBusSender sender = client.CreateSender(queueName);

// create a session message that we can send
ServiceBusMessage message = new(Encoding.UTF8.GetBytes("Hello world!"))
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

## Receive from a specific session

```C# Snippet:ServiceBusReceiveFromSpecificSession
// create a receiver specifying a particular session
ServiceBusSessionReceiver receiver = await client.AcceptSessionAsync(queueName, "Session2");

// the received message is a different type as it contains some service set properties
ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();
Console.WriteLine(receivedMessage.SessionId);
```

## Settling session messages

Settling session messages works in much the same way as settling non-session messages. The main difference is that the `ServiceBusSessionReceiver` type is used to settle the messages as opposed to the `ServiceBusReceiver` type. Additionally, session messages are not locked at the message level, but rather at the session level. Similar to how you can extend the message lock for an individual non-session messages, you can extend the session lock for a session which will prevent other consumers from receiving any messages from the session.

```C# Snippet:ServiceBusRenewSessionLockAndComplete
ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();

// If we know that we are going to be processing the session for a long time, we can extend the lock for the session
// by the configured LockDuration (by default, 30 seconds).
await receiver.RenewSessionLockAsync();

// simulate some processing of the message
await Task.Delay(TimeSpan.FromSeconds(10));

// complete the message, thereby deleting it from the service
await receiver.CompleteMessageAsync(receivedMessage);
```
