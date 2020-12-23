# Guide for migrating to Azure.Messaging.ServiceBus from Microsoft.Azure.ServiceBus

This guide is intended to assist in the migration to version 7 of the Service Bus client library [`Azure.Messaging.ServiceBus`](https://www.nuget.org/packages/Azure.Messaging.ServiceBus/) from version 4 of [`Microsoft.Azure.ServiceBus`](https://www.nuget.org/packages/Microsoft.Azure.ServiceBus/). It will focus on side-by-side comparisons for similar operations between the two packages. 

Familiarity with the `Microsoft.Azure.ServiceBus` library is assumed. For those new to the Service Bus client library for .NET, please refer to the [README](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/servicebus/Azure.Messaging.ServiceBus/README.md) and [Service Bus samples](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/servicebus/Azure.Messaging.ServiceBus/samples) for the `Azure.Messaging.ServiceBus` library rather than this guide.

## Table of contents

- [Migration benefits](#migration-benefits)
- [General changes](#general-changes)
  - [Package and namespaces](#package-and-namespaces)
  - [Client hierarchy](#client-hierarchy)
  - [Client constructors](#client-constructors)
  - [Sending messages](#sending-messages)
  - [Receiving messages](#receiving-messages)
  - [Working with sessions](#working-with-sessions)
- [Known gaps](#known-gaps-from-previous-library)
- [Additional samples](#additional-samples)

## Migration benefits

A natural question to ask when considering whether or not to adopt a new version or library is what the benefits of doing so would be. As Azure has matured and been embraced by a more diverse group of developers, we have been focused on learning the patterns and practices to best support developer productivity and to understand the gaps that the .NET client libraries have.

There were several areas of consistent feedback expressed across the Azure client library ecosystem. One of the most important is that the client libraries for different Azure services have not had a consistent approach to organization, naming, and API structure. Additionally, many developers have felt that the learning curve was difficult, and the APIs did not offer a good, approachable, and consistent onboarding story for those learning Azure or exploring a specific Azure service.

To try and improve the development experience across Azure services, including Service Bus, a set of uniform [design guidelines](https://azure.github.io/azure-sdk/general_introduction.html) was created for all languages to drive a consistent experience with established API patterns for all services. A set of [.NET-specific guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html) was also introduced to ensure that .NET clients have a natural and idiomatic feel that mirrors that of the .NET base class libraries. Further details are available in the guidelines for those interested.

The new Service Bus library `Azure.Messaging.ServiceBus` provides the ability to share in some of the cross-service improvements made to the Azure development experience, such as using the new `Azure.Identity` library to share a single authentication between clients and a unified diagnostics pipeline offering a common view of the activities across each of the client libraries. 

While we believe that there is significant benefit to adopting the new Service Bus library `Azure.Messaging.ServiceBus`, it is important to be aware that the previous two versions `WindowsAzure.ServiceBus` and `Microsoft.Azure.ServiceBus` have not been officially deprecated. They will continue to be supported with security and bug fixes as well as receiving some minor refinements. However, in the near future they will not be under active development and new features are unlikely to be added to them.

## General changes

### Package and namespaces

Package names and the namespace root for the modern Azure client libraries for .NET have changed. Each will follow the pattern `Azure.[Area].[Service]` where the legacy clients followed the pattern `Microsoft.Azure.[Service]`. This provides a quick and accessible means to help understand, at a glance, whether you are using the modern or legacy clients.

In the case of Service Bus, the modern client libraries have packages and namespaces that begin with `Azure.Messaging.ServiceBus` and were released beginning with version 7. The legacy client libraries have packages and namespaces that begin with `Microsoft.Azure.ServiceBus` and a version of 4.x.x or below.

### Client hierarchy

In the interest of simplifying the API surface we've made a single top level client called `ServiceBusClient`, rather than one for each of queue, topic, subscription and session. This acts as the single entry point in contrast with multiple entry points from before. You can create senders and receivers from this client to the queue/topic/subscription/session of your choice and start sending/receiving messages.

#### Approachability
By having a single entry point, the `ServiceBusClient` helps with the discoverability of the API as you can explore all available features through methods from a single client, as opposed to searching through documentation or exploring namespace for the types that you can instantiate. Whether sending or receiving, using sessions or not, you will start your applications by constructing the same client.
 
#### Consistency
We now have methods with similar names, signature and location to create senders and receivers. This provides consistency and predictability on the various features of the library. We have attempted to have the session/non-session usage be as seamless as possible. This allows you to make less changes to your code when you want to move from sessions to non-sessions or the other way around.
 
#### Connection Pooling
By using a single top-level client, we can implicitly share a single AMQP connection for all operations that an application performs. In the previous library `Microsoft.Azure.ServiceBus`, connection sharing was implicit when using the `SessionClient`, but when using other clients, senders or receivers, you would need to explicitly pass in a `ServiceBusConnection` object in order to share a connection. 

By making this connection sharing be implicit to a `ServiceBusClient` instance, we can help ensure that applications will not use multiple connections unless they explicitly opt in by creating multiple `ServiceBusClient` instances. The mental model of 1 client - 1 connection is more intuitive than 1 client/sender/receiver - 1 connection.
 

### Client constructors

While we continue to support connection strings when constructing a client, the main difference is when using Azure Active Directory. We now use the new [Azure.Identity](https://www.nuget.org/packages/Azure.Identity) library to share a single authentication solution between clients of different Azure services.

Authenticate with Active Directory:
```C# Snippet:ServiceBusAuthAAD
// Create a ServiceBusClient that will authenticate through Active Directory
string fullyQualifiedNamespace = "yournamespace.servicebus.windows.net";
ServiceBusClient client = new ServiceBusClient(fullyQualifiedNamespace, new DefaultAzureCredential());
```

Authenticate with connection string:
```C# Snippet:ServiceBusAuthConnString
// Create a ServiceBusClient that will authenticate using a connection string
string connectionString = "<connection_string>";
ServiceBusClient client = new ServiceBusClient(connectionString);
```

### Sending messages

Previously, in `Microsoft.Azure.ServiceBus`, you could send messages either by using a `QueueClient` (or `TopicClient` if you are targetting a topic) or the `MessageSender`.

While the `QueueClient` supported the simple send operation, the `MessageSender` supported that and advanced scenarios like scheduling to send messages at a later time and cancelling such scheduled messages.

```C# 
// create a message to send
Message message = new Message(Encoding.Default.GetBytes("Hello world!"));

// send using the QueueClient
QueueClient queueClient = new QueueClient(connectionString, queueName);
await queueClient.SendAsync(message);

// send using the MessageSender
MessageSender sender = new MessageSender(connectionString, queueName);
await sender.SendAsync(message);
```

Now in `Azure.Messaging.ServiceBus`, we combine all the send related features under a common class `ServiceBusSender` that you can create from the top level client using the `CreateSender()` method. This method takes the queue or topic you want to target. This way, we give you a one stop shop for all your send related needs. 

We continue to support sending bytes in the message. Though, if you are working with strings, you can now create a message directly without having to convert it to bytes first.

```C# Snippet:ServiceBusSendSingleMessage
string connectionString = "<connection_string>";
string queueName = "<queue_name>";
// since ServiceBusClient implements IAsyncDisposable we create it with "await using"
await using var client = new ServiceBusClient(connectionString);

// create the sender
ServiceBusSender sender = client.CreateSender(queueName);

// create a message that we can send. UTF-8 encoding is used when providing a string.
ServiceBusMessage message = new ServiceBusMessage("Hello world!");

// send the message
await sender.SendMessageAsync(message);
```

The feature to send a list of messages in a single call was implemented by batching all the messages into a single AMQP message and sending that to the service.

While we continue to support this feature, it had the potential to fail unexpectedly when the resulting batched AMQP message exceeded the size limit of the sender. To help with this, we now provide a safe way to batch multiple messages to be sent at once using the new `ServiceBusMessageBatch` class.
While the below code sample uses a local queue as the source of messages to be safely batched and sent, your application may use a list or an array of messages that have accumulated from a different part of your code.

```C# Snippet:ServiceBusSendAndReceiveSafeBatch
// add the messages that we plan to send to a local queue
Queue<ServiceBusMessage> messages = new Queue<ServiceBusMessage>();
messages.Enqueue(new ServiceBusMessage("First message"));
messages.Enqueue(new ServiceBusMessage("Second message"));
messages.Enqueue(new ServiceBusMessage("Third message"));

// create a message batch that we can send
// total number of messages to be sent to the Service Bus queue
int messageCount = messages.Count;

// while all messages are not sent to the Service Bus queue
while (messages.Count > 0)
{
    // start a new batch
    using ServiceBusMessageBatch messageBatch = await sender.CreateMessageBatchAsync();

    // add the first message to the batch
    if (messageBatch.TryAddMessage(messages.Peek()))
    {
        // dequeue the message from the .NET queue once the message is added to the batch
        messages.Dequeue();
    }
    else
    {
        // if the first message can't fit, then it is too large for the batch
        throw new Exception($"Message {messageCount - messages.Count} is too large and cannot be sent.");
    }

    // add as many messages as possible to the current batch
    while (messages.Count > 0 && messageBatch.TryAddMessage(messages.Peek()))
    {
        // dequeue the message from the .NET queue as it has been added to the batch
        messages.Dequeue();
    }

    // now, send the batch
    await sender.SendMessagesAsync(messageBatch);

    // if there are any remaining messages in the .NET queue, the while loop repeats
}
```

### Receiving messages

Previously, in `Microsoft.Azure.ServiceBus`, you could receive messages either by using a `QueueClient` (or `SubscriptionClient` if you are targetting a subscription) or the `MessageReceiver`.

While the `QueueClient` supported the simple push model where you could register message and error handlers/callbacks, the `MessageReceiver` provided you with ways to receive messages (both normal and deferred) in batches, settle messages and renew locks.


```C#
// create the QueueClient
QueueClient queueClient = new QueueClient(connectionString, queueName);

// define the message handler
async Task MessageHandler(Message message, CancellationToken token)
{
    // Process the message.
    Console.WriteLine($"Received message with Body:{Encoding.UTF8.GetString(message.Body)}");
}

// define the error handler
Task ErrorHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
{
    Console.WriteLine($"Message handler encountered an exception {exceptionReceivedEventArgs.Exception}.");
    return Task.CompletedTask;
}

// Configure the message handler options with the error handler
var messageHandlerOptions = new MessageHandlerOptions(ErrorHandler);

// Register the message handler and options
queueClient.RegisterMessageHandler(MessageHandler, messageHandlerOptions);

// Or receive using the receiver
var receiver = new MessageReceiver(connectionString, queueName);
var receivedMessage = await receiver.ReceiveAsync();
Console.WriteLine($"Received message with Body:{Encoding.UTF8.GetString(receivedMessage.Body)}");
await receiver.CompleteAsync(receivedMessage);
```

Now in `Azure.Messaging.ServiceBus`, we introduce a dedicated class `ServiceBusProcessor` which takes your message and error handlers to provide you with the same simple way to get started with processing your messages as message handlers in the previous packages, with auto-complete and auto-lock renewal features. This class also provides a graceful shutdown via the `StopProcessingAsync` method which will ensure that no more messages will be received, but at the same time you can continue the processing and settling the messages already in flight.

The concept of a receiver remains for users who need to have a more fine grained control over the receiving and settling messages. The difference is that this is now created from the top-level `ServiceBusClient` via the `CreateReceiver()` method that would take the queue or subscription you want to target. 

Another notable difference from the previous library when it comes to receiving messages, is that the new library uses a separate type for received messages, `ServiceBusReceivedMessage`. This helps reduce the surface area of the sendable messages by excluding properties that are set by the service itself and cannot be set by a user when sending messages. In order to construct a `ServiceBusReceivedMessage` for mocking purposes, use the `ServiceBusModelFactory.ServiceBusReceivedMessage` method. In general, output types that are meant to be constructed only by the library can be created for mocking using the `ServiceBusModelFactory` static class.

```C# Snippet:ServiceBusConfigureProcessor
// create the options to use for configuring the processor
var options = new ServiceBusProcessorOptions
{
    // By default or when AutoCompleteMessages is set to true, the processor will complete the message after executing the message handler
    // Set AutoCompleteMessages to false to [settle messages](https://docs.microsoft.com/en-us/azure/service-bus-messaging/message-transfers-locks-settlement#peeklock) on your own.
    // In both cases, if the message handler throws an exception without settling the message, the processor will abandon the message.
    AutoCompleteMessages = false,

    // I can also allow for multi-threading
    MaxConcurrentCalls = 2
};

// create a processor that we can use to process the messages
await using ServiceBusProcessor processor = client.CreateProcessor(queueName, options);

// configure the message and error handler to use
processor.ProcessMessageAsync += MessageHandler;
processor.ProcessErrorAsync += ErrorHandler;

async Task MessageHandler(ProcessMessageEventArgs args)
{
    string body = args.Message.Body.ToString();
    Console.WriteLine(body);

    // we can evaluate application logic and use that to determine how to settle the message.
    await args.CompleteMessageAsync(args.Message);
}

Task ErrorHandler(ProcessErrorEventArgs args)
{
    // the error source tells me at what point in the processing an error occurred
    Console.WriteLine(args.ErrorSource);
    // the fully qualified namespace is available
    Console.WriteLine(args.FullyQualifiedNamespace);
    // as well as the entity path
    Console.WriteLine(args.EntityPath);
    Console.WriteLine(args.Exception.ToString());
    return Task.CompletedTask;
}

// start processing
await processor.StartProcessingAsync();

// since the processing happens in the background, we add a Conole.ReadKey to allow the processing to continue until a key is pressed.
Console.ReadKey();
```

Or receive using the receiver:
```C# Snippet:ServiceBusReceiveSingleMessage
// create a receiver that we can use to receive the message
ServiceBusReceiver receiver = client.CreateReceiver(queueName);

// the received message is a different type as it contains some service set properties
ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();

// get the message body as a string
string body = receivedMessage.Body.ToString();
Console.WriteLine(body);
```
### Working with sessions

Previously, in `Microsoft.Azure.ServiceBus`, you had the below options to receive messages from a session enabled queue/subscription
- Register message and error handlers using the `QueueClient.RegisterSessionHandler()` method to receive messages from an available set of sessions 
- Use the `SessionClient.AcceptMessageSessionAsync()` method to get an instance of the `MessageSession` class that will be tied to a given sessionId or to the next available session if no sessionId is provided.

While the first option is similar to what you would do in a non-session scenario, the second that allows you finer-grained control is very different from any other pattern used in the library.

Now in `Azure.Messaging.ServiceBus`, we simplfify this by giving session variants of the same methods and classes that are available when working with queues/subscriptions that do not have sessions enabled.

The below code snippet shows you the session variation of the `ServiceBusProcessor`.

```C# Snippet:ServiceBusConfigureSessionProcessor
// create the options to use for configuring the processor
var options = new ServiceBusSessionProcessorOptions
{
    // By default after the message handler returns, the processor will complete the message
    // If I want more fine-grained control over settlement, I can set this to false.
    AutoCompleteMessages = false,

    // I can also allow for processing multiple sessions
    MaxConcurrentSessions = 5,

    // By default or when AutoCompleteMessages is set to true, the processor will complete the message after executing the message handler
    // Set AutoCompleteMessages to false to [settle messages](https://docs.microsoft.com/en-us/azure/service-bus-messaging/message-transfers-locks-settlement#peeklock) on your own.
    // In both cases, if the message handler throws an exception without settling the message, the processor will abandon the message.
    MaxConcurrentCallsPerSession = 2,

    // Processing can be optionally limited to a subset of session Ids.
    SessionIds = { "my-session", "your-session" },
};

// create a session processor that we can use to process the messages
await using ServiceBusSessionProcessor processor = client.CreateSessionProcessor(queueName, options);

// configure the message and error handler to use
processor.ProcessMessageAsync += MessageHandler;
processor.ProcessErrorAsync += ErrorHandler;

async Task MessageHandler(ProcessSessionMessageEventArgs args)
{
    var body = args.Message.Body.ToString();

    // we can evaluate application logic and use that to determine how to settle the message.
    await args.CompleteMessageAsync(args.Message);

    // we can also set arbitrary session state using this receiver
    // the state is specific to the session, and not any particular message
    await args.SetSessionStateAsync(new BinaryData("some state"));
}

Task ErrorHandler(ProcessErrorEventArgs args)
{
    // the error source tells me at what point in the processing an error occurred
    Console.WriteLine(args.ErrorSource);
    // the fully qualified namespace is available
    Console.WriteLine(args.FullyQualifiedNamespace);
    // as well as the entity path
    Console.WriteLine(args.EntityPath);
    Console.WriteLine(args.Exception.ToString());
    return Task.CompletedTask;
}

// start processing
await processor.StartProcessingAsync();

// since the processing happens in the background, we add a Conole.ReadKey to allow the processing to continue until a key is pressed.
Console.ReadKey();
```

The below code snippet shows you the session variation of the receiver. Please note that creating a session receiver is an async operation because the library will need to get a lock on the session by connecting to the service first.

Create a receiver that will receive from the next available session:
```C# Snippet:ServiceBusReceiveNextSession
ServiceBusSessionReceiver receiver = await client.AcceptNextSessionAsync(queueName);

// the received message is a different type as it contains some service set properties
ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();
Console.WriteLine(receivedMessage.SessionId);
```

Create a receiver that will receive from a specific session:
```C# Snippet:ServiceBusReceiveFromSpecificSession
// create a receiver specifying a particular session
ServiceBusSessionReceiver receiver = await client.AcceptSessionAsync(queueName, "Session2");

// the received message is a different type as it contains some service set properties
ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();
Console.WriteLine(receivedMessage.SessionId);
```

## Known Gaps from Previous Library
There are a few features that are yet to be implemented in `Azure.Messaging.ServiceBus`, but were present in the previous library `Microsoft.Azure.ServiceBus`. The plan is to add these features in upcoming releases (unless otherwise noted), but they will not be available in the version 7.0.0:
- **Cross entity transactions** - In the previous library, Microsoft.Azure.ServiceBus, transactions could work across multiple entities by leveraging the [`viaEntityPath`](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/servicebus/Microsoft.Azure.ServiceBus/src/Core/MessageSender.cs#L118) parameter of the `MessageSender` constructor. The service is planning to make backward compatible updates that would make it possible to do cross-entity transactions without specificing a "via" entity. The new library plans to take advantage of this new feature and therefore, the cross entity transactions feature will be available in the upcoming release instead of the current version 7.0.0. Support for this feature can be tracked via https://github.com/Azure/azure-sdk-for-net/issues/17355.
- **Plugins** - In the previous library, Microsoft.Azure.ServiceBus, users could [register plugins](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/servicebus/Microsoft.Azure.ServiceBus/src/QueueClient.cs#L527) that would alter an outgoing message before serialization, or alter an incoming message after being deserialized. These extension points allowed users of the Service Bus library to use common OSS extensions to enhance their applications without having to implement their own logic, and without having to wait for the SDK to explicitly support the needed feature. For instance, one use of the plugin functionality is to implement the [claim-check pattern](https://www.nuget.org/packages/ServiceBus.AttachmentPlugin/) to send and receive messages that exceed the Service Bus message size limits. This feature is not yet supported in the new library but will be added in an upcoming release. Support for this feature can be tracked via https://github.com/Azure/azure-sdk-for-net/issues/12943.
- **AMQP Body Sections** - In the previous library, Microsoft.Azure.ServiceBus, it was possible to read the message body even if it was not stored in the [AMQP data section](https://docs.oasis-open.org/amqp/core/v1.0/os/amqp-core-messaging-v1.0-os.html#type-data) by using the [`GetBody<T>`](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/servicebus/Microsoft.Azure.ServiceBus/src/Extensions/MessageInterOpExtensions.cs#L76) extension method. In the new library, we currently do not expose a way to get the message body if it is not populated in the AMQP data section. We will add support for both setting and retrieving the message body in any of the AMQP body sections in an upcoming release. This includes the [data](https://docs.oasis-open.org/amqp/core/v1.0/os/amqp-core-messaging-v1.0-os.html#type-data), [sequence](https://docs.oasis-open.org/amqp/core/v1.0/os/amqp-core-messaging-v1.0-os.html#type-amqp-sequence), [value](https://docs.oasis-open.org/amqp/core/v1.0/os/amqp-core-messaging-v1.0-os.html#type-amqp-value) body sections. Support for this feature can be tracked via https://github.com/Azure/azure-sdk-for-net/issues/17356.
- **Max receive wait time for Processor** - In the previous library, Microsoft.Azure.ServiceBus, it was possible to configure the maximum amount of time each receive call would wait when receiving a message using the message pump (this is known as the Processor in the new library). This was not included in the GA release of the new library as we were not certain that this configuration option would be needed for users of the processor. Feedback for this feature request can be submitted and tracked via https://github.com/Azure/azure-sdk-for-net/issues/16773.

## Additional samples

More examples can be found at:
- [Service Bus samples](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/servicebus/Azure.Messaging.ServiceBus/samples)
