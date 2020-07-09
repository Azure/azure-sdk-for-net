# Guide for migrating to Azure.Messaging.ServiceBus from Microsoft.Azure.ServiceBus

This guide is intended to assist in the migration to version 7 of the Service Bus client library from version 4. It will focus on side-by-side comparisons for similar operations between the v7 package, [`Azure.Messaging.ServiceBus`](https://www.nuget.org/packages/Azure.Messaging.ServiceBus/) and v4 package, [`Microsoft.Azure.ServiceBus`](https://www.nuget.org/packages/Microsoft.Azure.ServiceBus/).

Familiarity with the v4 client library is assumed. For those new to the Service Bus client library for .NET, please refer to the [README](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/servicebus/Azure.Messaging.ServiceBus/README.md) and [Service Bus samples](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/servicebus/Azure.Messaging.ServiceBus/samples) for the v7 library rather than this guide.

## Table of contents

- [Migration benefits](#migration-benefits)
- [General changes](#general-changes)
  - [Package and namespaces](#package-and-namespaces)
  - [Client hierarchy](#client-hierarchy)
  - [Client constructors](#client-constructors)
  - [Creating sender and receiver](#creating-sender-and-receiver)
  - [Sending messages](#sending-messages)
  - [Receiving messages](#receiving-messages)
  - [Working with sessions](#working-with-sessions)
- [Migration samples](#migration-samples)
  - [Sending and receiving a message](#sending-and-receiving-a-message)
  - [Sending and receiving a batch of messages](#sending-and-receiving-a-batch-of-messages)
- [Additional samples](#additional-samples)

## Migration benefits

A natural question to ask when considering whether or not to adopt a new version or library is what the benefits of doing so would be. As Azure has matured and been embraced by a more diverse group of developers, we have been focused on learning the patterns and practices to best support developer productivity and to understand the gaps that the .NET client libraries have.

There were several areas of consistent feedback expressed across the Azure client library ecosystem. One of the most important is that the client libraries for different Azure services have not had a consistent approach to organization, naming, and API structure. Additionally, many developers have felt that the learning curve was difficult, and the APIs did not offer a good, approachable, and consistent onboarding story for those learning Azure or exploring a specific Azure service.

To try and improve the development experience across Azure services, including Service Bus, a set of uniform [design guidelines](https://azure.github.io/azure-sdk/general_introduction.html) was created for all languages to drive a consistent experience with established API patterns for all services. A set of [.NET-specific guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html) was also introduced to ensure that .NET clients have a natural and idiomatic feel that mirrors that of the .NET base class libraries. Further details are available in the guidelines for those interested.

The modern Service Bus client library provides the ability to share in some of the cross-service improvements made to the Azure development experience, such as using the new `Azure.Identity` library to share a single authentication between clients and a unified diagnostics pipeline offering a common view of the activities across each of the client libraries. 

While we believe that there is significant benefit to adopting the modern version of the Service Bus library, it is important to be aware that the legacy version has not been officially deprecated. It will continue to be supported with security and bug fixes as well as receiving some minor refinements. However, in the near future it will not be under active development and new features are unlikely to be added. There is no guarantee of feature parity between the modern and legacy client library versions.

## General changes

### Package and namespaces

Package names and the namespace root for the modern Azure client libraries for .NET have changed. Each will follow the pattern `Azure.[Area].[Service]` where the legacy clients followed the pattern `Microsoft.Azure.[Service]`. This provides a quick and accessible means to help understand, at a glance, whether you are using the modern or legacy clients.

In the case of Service Bus, the modern client libraries have packages and namespaces that begin with `Azure.Messaging.ServiceBus` and were released beginning with version 7. The legacy client libraries have packages and namespaces that begin with `Microsoft.Azure.ServiceBus` and a version of 4.x.x or below.

### Client hierarchy

In the interest of simplifying the API surface we've made a single top level client called `ServiceBusClient`, rather than one for each of queue, topic and subscription:

### Client constructors

| In v4                                                 | Equivalent in v7                                                | Sample |
|-------------------------------------------------------|-----------------------------------------------------------------|--------|
| `new QueueClient()` or `new TopicClient()` or `new SubscriptionClient()` or `new SessionClient()`  | `new ServiceBusClient()`                      | [Authenticate with connection string](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/servicebus/Azure.Messaging.ServiceBus/tests/Samples/Sample01_HelloWorld.cs#L177) |
| `new QueueClient(..., ITokenProvider)` or `new TopicClient(..., ITokenProvider)` or `new SubscriptionClient(..., ITokenProvider)` or `new SessionClient(..., ITokenProvider)`  | `new ServiceBusClient(..., TokenCredential)` | [Authenticate with client secret credential](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/servicebus/Azure.Messaging.ServiceBus/tests/Samples/Sample01_HelloWorld.cs#L165)

### Creating sender and receiver

| In v4                                                 | Equivalent in v7                                                | Sample |
|-------------------------------------------------------|-----------------------------------------------------------------|--------|
`new MessageSender()`   | `ServiceBusClient.CreateSender()`                     | [Create the sender](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/servicebus/Azure.Messaging.ServiceBus/samples/Sample01_HelloWorld.md) |
`new MessageReceiver()`   | `ServiceBusClient.CreateReceiver()`                     | [Create the receiver](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/servicebus/Azure.Messaging.ServiceBus/samples/Sample01_HelloWorld.md) |
`new MessageReceiver()`   | `ServiceBusClient.CreateProcessor()`                     | [Create the processor](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/servicebus/Azure.Messaging.ServiceBus/samples/Sample04_Processor.md) |
| `SessionClient.AcceptMessageSessionAsync()`  | `ServiceBusClient.CreateSessionReceiverAsync()` | [Create the session receiver](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/servicebus/Azure.Messaging.ServiceBus/samples/Sample03_SendReceiveSessions.md)
| `SessionClient.AcceptMessageSessionAsync()`  | `ServiceBusClient.CreateSessionProcessor()` | [Create the session processor](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/servicebus/Azure.Messaging.ServiceBus/samples/Sample05_SessionProcessor.md)

### Sending messages

The v4 client allowed for sending a single message or a list of messages, which had the potential to fail unexpectedly if the maximum allowable size was exceeded. v7 aims to prevent this by allowing you to first create a batch of messages using `CreateMessageBatchAsync` and then attempt to add messages to that using `TryAddMessage()`. If the batch accepts a message, you can be confident that it will not violate size constraints when calling Send to send the batch. v7 still allows sending a single message and sending an `IEnumerable` of messages, though using the `IEnumerable` overload has the same risks as V4.

| In v4                                          | Equivalent in v7                                                 | Sample |
|------------------------------------------------|------------------------------------------------------------------|--------|
| `QueueClient.SendAsync(Message)` or `MessageSender.SendAsync(Message)`                          | `ServiceBusSender.SendMessageAsync(ServiceBusMessage)`                               | [Send a message](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/servicebus/Azure.Messaging.ServiceBus/samples/Sample01_HelloWorld.md#sending-and-receiving-a-message) |
| `QueueClient.SendAsync(IList<Message>)` or `MessageSender.SendAsync(IList<Message>)`                          | `messageBatch = ServiceBusSender.CreateMessageBatchAsync()` `messageBatch.TryAddMessage(ServiceBusMessage)` `ServiceBusSender.SendMessagesAsync(messageBatch)` or `ServiceBusSender.SendMessagesAsync(IEnumerable<ServiceBusMessage>)`                              | [Send a batch of messages](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/servicebus/Azure.Messaging.ServiceBus/samples/Sample01_HelloWorld.md#sending-and-receiving-a-batch-of-messages) |

### Receiving messages 

| In v4                                          | Equivalent in v7                                                 | Sample |
|------------------------------------------------|------------------------------------------------------------------|--------|
| `MessageReceiver.ReceiveAsync()`                      | `ServiceBusReceiver.ReceiveMessageAsync()`                               | [Receive a message](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/servicebus/Azure.Messaging.ServiceBus/samples/Sample01_HelloWorld.md#sending-and-receiving-a-message) |
| `MessageReceiver.ReceiveAsync()`                      | `ServiceBusReceiver.ReceiveMessagesAsync()`                               | [Receive a batch of messages](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/servicebus/Azure.Messaging.ServiceBus/samples/Sample01_HelloWorld.md#sending-and-receiving-a-batch-of-messages) |
| `QueueClient.RegisterMessageHandler()` or   `MessageReceiver.RegisterMessageHandler()`                    | `ServiceBusProcessor.ProcessMessageAsync += MessageHandler` `ServiceBusProcessor.ProcessErrorAsync += ErrorHandler` `ServiceBusProcessor.StartProcessingAsync()`                               | [Receive messages using processor](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/servicebus/Azure.Messaging.ServiceBus/samples/Sample04_Processor.md) |

### Working with sessions 

| In v4                                          | Equivalent in v7                                                 | Sample |
|------------------------------------------------|------------------------------------------------------------------|--------|
| `MessageSender.SendAsync(new Message{SessionId = "sessionId"})`                      | `ServiceBusSender.SendMessageAsync(new ServiceBusMessage{SessionId = "sessionId"})`                               | [Send a message to session](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/servicebus/Azure.Messaging.ServiceBus/samples/Sample03_SendReceiveSessions.md) |
| `IMessageSession.ReceiveAsync()`                      | `ServiceBusSessionReceiver.ReceiveMessageAsync()`                               | [Receive a message from session](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/servicebus/Azure.Messaging.ServiceBus/samples/Sample03_SendReceiveSessions.md) |
| `IMessageSession.RegisterMessageHandler()`                    | `ServiceBusSessionProcessor.ProcessMessageAsync += MessageHandler` `ServiceBusSessionProcessor.ProcessErrorAsync += ErrorHandler` `ServiceBusSessionProcessor.StartProcessingAsync()`                               | [Receive messages from session processor](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/servicebus/Azure.Messaging.ServiceBus/samples/Sample05_SessionProcessor.md) |

## Migration samples

### Sending and receiving a message

In v4, `QueueClient`/`MessageSender`/`MessageReceiver` would be created directly, after which user would call `SendAsync()` method via `QueueClient`/`MessageSender` to send a message and `ReceiveAsync()` method via `MessageReceiver` to receive a message.

In v7, user would initialize the `ServiceBusClient` and call `CreateSender()` method to create a `ServiceBusSender` and `CreateReceiver()` method to create a `ServiceBusReceiver`. To send a message, user would call `SendMessageAsync()` via `ServiceBusSender` and to receive a message, user would call `ReceiveMessageAsync()` via `ServiceBusReceiver`.

In v4:

```csharp
string connectionString = "<connection_string>";
string entityPath = "<queue_name>";
// create the sender
MessageSender sender = new MessageSender(connectionString, entityPath);

// create a message that we can send
Message message = new Message(Encoding.Default.GetBytes("Hello world!"));

// send a message
await sender.SendAsync(message);

// create a receiver that we can use to receive the message
MessageReceiver receiver = new MessageReceiver(connectionString, entityPath);

// received a message
Message receivedMessage = await receiver.ReceiveAsync();

// get the message body as a string
string body = Encoding.Default.GetString(receivedMessage.Body.ToArray());
Console.WriteLine(body);

// Close the sender
await sender.CloseAsync();

// Close the receiver
await receiver.CloseAsync();
```

In v7:

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

### Sending and receiving a batch of messages

In v4, `QueueClient`/`MessageSender`/`MessageReceiver` would be created directly, after which user would call `SendAsync()` method via `QueueClient`/`MessageSender` to send a batch of messages and `ReceiveAsync()` method via `MessageReceiver` to receive a batch of messages.

In v7, user would initialize the `ServiceBusClient` and call `CreateSender()` method to create a `ServiceBusSender` and 
`CreateReceiver()` method to create a `ServiceBusReceiver`. There are two ways of sending several messages at once. 

The first way uses the `SendMessagesAsync`overload that accepts an IEnumerable of `ServiceBusMessage`. With this method, we will 
attempt to fit all of the supplied messages in a single message batch that we will send to the service. If the messages are 
too large to fit in a single batch, the operation will throw an exception. 

The second way of doing this is using safe-batching. With safe-batching, you can create a `ServiceBusMessageBatch` object, 
which will allow you to attempt to add messages one at a time to the batch using the `TryAddMessage` method. If the message cannot 
fit in the batch, `TryAddMessage` will return false. If the `ServiceBusMessageBatch` accepts a message, user can be confident that 
it will not violate size constraints when calling `SendMessagesAsync()` via `ServiceBusSender`. To receive a set of messages, a
user would call `ReceiveMessagesAsync()` method via `ServiceBusReceiver`. 

In v4:

```csharp
string connectionString = "<connection_string>";
string entityPath = "<queue_name>";
// create the sender
MessageSender sender = new MessageSender(connectionString, entityPath);

// create a list of messages that we can send
var messagesToSend = new List<Message>();

for (var i = 0; i < 10; i++)
{
    Message message = new Message(Encoding.UTF8.GetBytes("Hello World" + i));
    messagesToSend.Add(message);
}

// send a list of messages
await sender.SendAsync(messagesToSend);

// create a receiver that we can use to receive the messages
MessageReceiver receiver = new MessageReceiver(connectionString, entityPath);

// received a list of messages
IList<Message> receivedMessages = await receiver.ReceiveAsync(maxMessageCount: 10);

foreach (Message receivedMessage in receivedMessages)
{
    // get the message body as a string
    string body = Encoding.Default.GetString(receivedMessage.Body.ToArray());
    Console.WriteLine(body);
}

// Close the sender
await sender.CloseAsync();

// Close the receiver
await receiver.CloseAsync();
```

In v7:
```C# Snippet:ServiceBusInitializeSend
string connectionString = "<connection_string>";
string queueName = "<queue_name>";
// since ServiceBusClient implements IAsyncDisposable we create it with "await using"
await using var client = new ServiceBusClient(connectionString);

// create the sender
ServiceBusSender sender = client.CreateSender(queueName);
IList<ServiceBusMessage> messages = new List<ServiceBusMessage>();
messages.Add(new ServiceBusMessage(Encoding.UTF8.GetBytes("First")));
messages.Add(new ServiceBusMessage(Encoding.UTF8.GetBytes("Second")));
// send the messages
await sender.SendMessagesAsync(messages);
```

Or using the safe-batching feature:

```C# Snippet:ServiceBusSendAndReceiveSafeBatch
ServiceBusMessageBatch messageBatch = await sender.CreateMessageBatchAsync();
messageBatch.TryAddMessage(new ServiceBusMessage(Encoding.UTF8.GetBytes("First")));
messageBatch.TryAddMessage(new ServiceBusMessage(Encoding.UTF8.GetBytes("Second")));

// send the message batch
await sender.SendMessagesAsync(messageBatch);
```

And to receive a batch:
```C# Snippet:ServiceBusReceiveBatch
// create a receiver that we can use to receive the messages
ServiceBusReceiver receiver = client.CreateReceiver(queueName);

// the received message is a different type as it contains some service set properties
IReadOnlyList<ServiceBusReceivedMessage> receivedMessages = await receiver.ReceiveMessagesAsync(maxMessages: 2);

foreach (ServiceBusReceivedMessage receivedMessage in receivedMessages)
{
    // get the message body as a string
    string body = receivedMessage.Body.ToString();
    Console.WriteLine(body);
}
```

## Additional samples

More examples can be found at:
- [Service Bus samples](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/servicebus/Azure.Messaging.ServiceBus/samples)
