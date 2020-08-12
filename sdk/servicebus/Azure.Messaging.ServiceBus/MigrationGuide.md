# Guide for migrating to Azure.Messaging.ServiceBus from Microsoft.Azure.ServiceBus

This guide is intended to assist in the migration to version 7 of the Service Bus client library from version 4. It will focus on side-by-side comparisons for similar operations between the v7 package, [`Azure.Messaging.ServiceBus`](https://www.nuget.org/packages/Azure.Messaging.ServiceBus/) and v4 package, [`Microsoft.Azure.ServiceBus`](https://www.nuget.org/packages/Microsoft.Azure.ServiceBus/).

Familiarity with the v4 client library is assumed. For those new to the Service Bus client library for .NET, please refer to the [README](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/servicebus/Azure.Messaging.ServiceBus/README.md) and [Service Bus samples](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/servicebus/Azure.Messaging.ServiceBus/samples) for the v7 library rather than this guide.

## Table of contents

- [Migration benefits](#migration-benefits)
- [General changes](#general-changes)
  - [Package and namespaces](#package-and-namespaces)
  - [Client hierarchy](#client-hierarchy)
  - [Client constructors](#client-constructors)
  - [Sending messages](#sending-messages)
  - [Receiving messages](#receiving-messages)
  - [Working with sessions](#working-with-sessions)
- [Additional samples](#additional-samples)

## Migration benefits

A natural question to ask when considering whether or not to adopt a new version or library is what the benefits of doing so would be. As Azure has matured and been embraced by a more diverse group of developers, we have been focused on learning the patterns and practices to best support developer productivity and to understand the gaps that the .NET client libraries have.

There were several areas of consistent feedback expressed across the Azure client library ecosystem. One of the most important is that the client libraries for different Azure services have not had a consistent approach to organization, naming, and API structure. Additionally, many developers have felt that the learning curve was difficult, and the APIs did not offer a good, approachable, and consistent onboarding story for those learning Azure or exploring a specific Azure service.

To try and improve the development experience across Azure services, including Service Bus, a set of uniform [design guidelines](https://azure.github.io/azure-sdk/general_introduction.html) was created for all languages to drive a consistent experience with established API patterns for all services. A set of [.NET-specific guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html) was also introduced to ensure that .NET clients have a natural and idiomatic feel that mirrors that of the .NET base class libraries. Further details are available in the guidelines for those interested.

The modern Service Bus client library provides the ability to share in some of the cross-service improvements made to the Azure development experience, such as using the new `Azure.Identity` library to share a single authentication between clients and a unified diagnostics pipeline offering a common view of the activities across each of the client libraries. 

While we believe that there is significant benefit to adopting the modern version of the Service Bus library, it is important to be aware that the legacy version has not been officially deprecated. It will continue to be supported with security and bug fixes as well as receiving some minor refinements. However, in the near future it will not be under active development and new features are unlikely to be added.

## General changes

### Package and namespaces

Package names and the namespace root for the modern Azure client libraries for .NET have changed. Each will follow the pattern `Azure.[Area].[Service]` where the legacy clients followed the pattern `Microsoft.Azure.[Service]`. This provides a quick and accessible means to help understand, at a glance, whether you are using the modern or legacy clients.

In the case of Service Bus, the modern client libraries have packages and namespaces that begin with `Azure.Messaging.ServiceBus` and were released beginning with version 7. The legacy client libraries have packages and namespaces that begin with `Microsoft.Azure.ServiceBus` and a version of 4.x.x or below.

### Client hierarchy

In the interest of simplifying the API surface we've made a single top level client called `ServiceBusClient`, rather than one for each of queue, topic, subscription and session. This acts as the single entry point in contrast with six different entry points in the previous library. You can create senders and receivers off of this client to the queue/topic/subscription/session of your choice and start sending/receiving messages.

**Approachability** 
By having a single entry point, the `ServiceBusClient` helps with the discoverability of the API as you can dot into the client and see all the available methods as opposed to searching through documentation or exploring namespace for the types that you can instantiate. Whether sending or receiving, or using sessions or not, users will start their applications by constructing the same client.
 
**Consistency**
Having similar methods to create senders, receivers and receivers for individual sessions on the same client provides consistency and predictability on the various features of the library. We have attempted to have the session/non-session usage be as seamless as possible. This allows users to make less changes to their code when they want to move from sessions to non-sessions or the other way around.
 
**Resource usage**
By using a single top-level client, we can implicitly share a single AMQP connection for all operations that an application performs. In the previous library, connection sharing was implicit when using the `SessionClient`, but when using other clients, users would need to explicitly pass in a `ServiceBusConnection` object in order to share a connection. By making this sharing be implicit to a ServiceBusClient instance, we can help ensure that applications will not use multiple connections unless they explicitly opt in by creating multiple `ServiceBusClient` instances.
 

### Client constructors

While we continue to support connection strings when constructing a client, the main difference is in using Azure Active Directory.
We now use the new `Azure.Identity` library to share a single authentication solution between clients of different Azure services.

```cs
// Create a ServiceBusClient that will authenticate through Active Directory
string fullyQualifiedNamespace = "yournamespace.servicebus.windows.net";
ServiceBusClient client = new ServiceBusClient(fullyQualifiedNamespace, new DefaultAzureCredential());

// Create a ServiceBusClient that will authenticate using a connection string
string connectionString = "Endpoint=sb://yournamespace.servicebus.windows.net/;SharedAccessKeyName=your-key-name;SharedAccessKey=your-key";
ServiceBusClient client = new ServiceBusClient(connectionString);
```

### Sending messages

In v4, you could send messages either by using a `QueueClient` (or `TopicClient` if you are targetting a topic) or the `MessageSender`.
While the `QueueClient` supported the simple send operation, the `MessageSender` supported that and advanced scenarios like scheduling to send messages
at a later time and cancelling such scheduled messages.

```cs
// create a message to send
Message message = new Message(Encoding.Default.GetBytes("Hello world!"));

// send using the QueueClient
QueueClient queueClient = new QueueClient(connectionString, queueName);
await queueClient.SendAsync(message);

// send using the MessageSender
MessageSender sender = new MessageSender(connectionString, queueName);
await sender.SendAsync(message);
```

In v7, we combine all the send related features under a common class `ServiceBusSender` that you can create off of the top level client using the `CreateSender()` method.
This provides a single stop shop for all your send related needs. 

While we continue to support sending bytes in the message, if you are working with strings, you can now create a message directly without having to convert it to bytes first.

```cs
// create the client
var client = new ServiceBusClient(connectionString);

// create the sender
ServiceBusSender sender = client.CreateSender(queueName);

// create a message to send
ServiceBusMessage message = new ServiceBusMessage("Hello world!");

// send the message
await sender.SendMessageAsync(message);
```

While we continue to support sending a list of messages in a single call, this feature has always had the potential to fail unexpectedly when the messages exceeded the size limit of the sender.
To help with this, we now provide a safe way to batch multiple messages to be sent at once using the new `ServiceBusMessageBatch` class.


```cs
ServiceBusMessageBatch messageBatch = await sender.CreateMessageBatchAsync();

for (var i = 0; i < 10; i++)
{
    // create a message
    ServiceBusMessage message = new ServiceBusMessage("Hello world!" + i);

    // Add message the batch
    var tryAddResult = messageBatch.TryAddMessage((message);
    if (!tryAddResult) {
      Console.WriteLine("Failed to add message number " + i);
      break;
    }
}
// send the message batch
await sender.SendMessagesAsync(messageBatch);
```

### Receiving messages

In v4, you could receive messages either by using a `QueueClient` (or `SubscriptionClient` if you are targetting a subscription) or the `MessageReceiver`.

While the `QueueClient` supported the simple push model where you could register message and error handlers/callbacks, the `MessageReceiver` provided you with ways to receive messages (both normal and deferred) in batches, settle messages and renew locks.


```cs
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

In v7, we introduce the concept of a "processor" which takes your message and error handlers to provide you a simple way to get started with processing your messages.
The concept of a "receiver" remains for users who need to have a more fine grained control over the receiving and settling messages.

```cs
// create the ServiceBusClient
var client = new ServiceBusClient(connectionString);

// define the message handler
async Task MessageHandler(ProcessMessageEventArgs args)
{
    Console.WriteLine(args.Message.Body.ToString());
}

// define the error handler
Task ErrorHandler(ProcessErrorEventArgs args)
{
    Console.WriteLine($"Message handler encountered an exception {args.Exception}.");
    return Task.CompletedTask;
}

// create a processor and register handlers that we can use to process the messages
ServiceBusProcessor processor = client.CreateProcessor(queueName);
processor.ProcessMessageAsync += MessageHandler;
processor.ProcessErrorAsync += ErrorHandler;

// start processing
await processor.StartProcessingAsync();

// Or receive using the receiver
var receiver = client.CreateReceiver(queueName);
var receivedMessage = await receiver.ReceiveAsync();
Console.WriteLine($"Received message with Body:{Encoding.UTF8.GetString(receivedMessage.Body)}");
await receiver.CompleteMessageAsync(receivedMessage);

```
### Working with sessions



## Additional samples

More examples can be found at:
- [Service Bus samples](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/servicebus/Azure.Messaging.ServiceBus/samples)
