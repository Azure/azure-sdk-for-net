# Guide for migrating to Azure.Messaging.ServiceBus from WindowsAzure.ServiceBus

This guide is intended to assist in the migration to version 7 of the Service Bus client library [`Azure.Messaging.ServiceBus`](https://www.nuget.org/packages/Azure.Messaging.ServiceBus/) from [`WindowsAzure.ServiceBus`](https://www.nuget.org/packages/WindowsAzure.ServiceBus/). It will focus on side-by-side comparisons for similar operations between the two packages.

We assume that you are familiar with the `WindowsAzure.ServiceBus` library. If not, please refer to the [README for Azure.Messaging.ServiceBus](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/servicebus/Azure.Messaging.ServiceBus/README.md) and [Service Bus samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/servicebus/Azure.Messaging.ServiceBus/samples) rather than this guide.

## Table of contents

- [Guide for migrating to Azure.Messaging.ServiceBus from WindowsAzure.ServiceBus](#guide-for-migrating-to-azuremessagingservicebus-from-windowsazureservicebus)
  - [Table of contents](#table-of-contents)
  - [Migration benefits](#migration-benefits)
    - [Cross-service SDK improvements](#cross-service-sdk-improvements)
    - [New features](#new-features)
  - [General changes](#general-changes)
    - [Package and namespaces](#package-and-namespaces)
    - [Client hierarchy](#client-hierarchy)
      - [Approachability](#approachability)
      - [Consistency](#consistency)
      - [Connection Pooling](#connection-pooling)
    - [Default transport type](#default-transport-type)
    - [BrokeredMessage changed to Message](#brokeredmessage-changed-to-message)
    - [Client constructors](#client-constructors)
      - [Service Bus client](#service-bus-client)
      - [Administration client](#administration-client)
    - [Sending messages](#sending-messages)
    - [Receiving messages](#receiving-messages)
    - [Dead letter messages](#dead-letter-messages)
    - [Working with sessions](#working-with-sessions)
    - [Cross-entity transactions](#cross-entity-transactions)
    - [Distributed tracing](#distributed-tracing)
  - [Plugins](#plugins)
  - [Additional samples](#additional-samples)
  - [Frequently asked questions](#frequently-asked-questions)

## Migration benefits

As Azure has matured and been embraced by a more diverse group of developers, we have been focused on learning the patterns and practices to best support developer productivity and to understand the gaps that the .NET client libraries have.

There were several areas of consistent feedback expressed across the Azure client library ecosystem. One of the most important is that the client libraries for different Azure services have not had a consistent approach to organization, naming, and API structure. Additionally, many developers have felt that the learning curve was difficult, and the APIs did not offer a good, approachable, and consistent onboarding story for those learning Azure or exploring a specific Azure service.

To improve the development experience across Azure services, including Service Bus, a set of uniform [design guidelines](https://azure.github.io/azure-sdk/general_introduction.html) was created for all languages to drive a consistent experience with established API patterns for all services. A set of [.NET-specific guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html) was also introduced to ensure that .NET clients have a natural and idiomatic feel that mirrors that of the .NET base class libraries. The new `Azure.Messaging.ServiceBus` library follows these guidelines.

While we believe that there is significant benefit to adopting the new Service Bus library `Azure.Messaging.ServiceBus`, it is important to be aware of the status of the older versions:

- `WindowsAzure.ServiceBus` has not been officially deprecated and will continue to be supported with security and bug fixes as well as receiving some minor refinements. However, in the near future it will not be under active development and new features are unlikely to be added.

- `Microsoft.Azure.ServiceBus` has been officially deprecated. While this package will continue to receive critical bug fixes, we strongly encourage you to upgrade.

### Cross Service SDK improvements

The modern Service Bus client library also provides the ability to share in some of the cross-service improvements made to the Azure development experience, such as

- Using the new Azure.Identity library to share a single authentication approach between clients
- A unified logging and diagnostics pipeline offering a common view of the activities across each of the client libraries

### New features

We have a variety of new features in the version 7 of the Service Bus library.

- Ability to create a batch of messages with the smarter `ServiceBusSender.CreateMessageBatch()` and `ServiceBusMessageBatch.TryAddMessage()` APIs. This will help you manage the messages to be sent in the most optimal way.
- Ability to process messages continuously from a given set of sessions. Previously, when registering a session message handler, it was not possible to restrict to a specific session or a specific set of sessions. This is now possible when using the `ServiceBusSessionProcessor`.
- Azure Service Bus follows the AMQP protocol and as such the Service Bus message is converted to an AMQP message when sent to the service. In the new library, you now have the ability to write and read the entire AMQP message along with its header, footer, properties, and annotations instead of just the properties that were exposed before. This is helpful if you are an advanced user and want to make use of the full might of AMQP message format.
- The APIs to schedule the sending of a message at a later time and the ones to cancel such scheduled messages now work for batches of messages as well.

## General changes

### Package and namespaces

Package names and the namespace root for the modern Azure client libraries for .NET have changed. Each will follow the pattern `Azure.[Area].[Service]` where the legacy clients followed the pattern `Microsoft.Azure.[Service]`. This provides a quick and accessible means to help understand, at a glance, whether you are using the modern or legacy clients.

In the case of Service Bus, the modern client library has package name and namespace `Azure.Messaging.ServiceBus` and was released beginning with version 7. The legacy client library has package and namespace `Microsoft.ServiceBus.Messaging`.

### Client hierarchy

In the interest of simplifying the API surface we've made a single top level client called `ServiceBusClient`, rather than one for each of queue, topic, subscription and session. This acts as the single entry point in contrast with multiple entry points from before. You can create senders and receivers from this client to the queue/topic/subscription/session of your choice and start sending/receiving messages.

#### Approachability

By having a single entry point, the `ServiceBusClient` helps with the discoverability of the API as you can explore all available features through methods from a single client, as opposed to searching through documentation or exploring namespace for the types that you can instantiate. Whether sending or receiving, using sessions or not, you will start your applications by constructing the same client.

#### Consistency

We now have methods with similar names, signature and location to create senders and receivers. This provides consistency and predictability on the various features of the library. We have attempted to have the session/non-session usage be as seamless as possible. This allows you to make less changes to your code when you want to move from sessions to non-sessions or the other way around.

#### Connection Pooling

By using a single top-level client, we can implicitly share a single AMQP connection for all operations that an application performs. By making this connection sharing be implicit to a `ServiceBusClient` instance, we can help ensure that applications will not use multiple connections unless they explicitly opt in by creating multiple `ServiceBusClient` instances. The mental model of 1 client - 1 connection is more intuitive than 1 client/sender/receiver - 1 connection.

### Default transport type

The default transport type in `Azure.Messaging.ServiceBus` is AMQP. The new library no longer supports SBMP, and as such you will need to migrate to AMQP. The behavioral differences have been described in [Use legacy WindowsAzure.ServiceBus .NET framework library with AMQP 1.0](https://learn.microsoft.com/azure/service-bus-messaging/service-bus-amqp-dotnet). It is possible to use AMQP with WebSockets over port 443 by setting the [TransportType](https://learn.microsoft.com/dotnet/api/azure.messaging.servicebus.servicebusclientoptions.transporttype?view=azure-dotnet#azure-messaging-servicebus-servicebusclientoptions-transporttype) on the options used when creating your `ServiceBusClient`.

### BrokeredMessage changed to Message

The object which used to represent a message has been changed from `BrokeredMessage` to `ServiceBusMessage`. Convenience methods like `CompleteAsync`, `AbandonAsync`, and `DeadLetterAsync` which were called on `BrokeredMessage` directly are now found on the `ServiceBusReceiver` or `ServiceBusProcessor` from which the message was read.


### Client constructors

#### Service Bus client

While we continue to support connection strings when constructing a client, the main difference is when using Azure Active Directory. We now use the new [Azure.Identity](https://www.nuget.org/packages/Azure.Identity) library to share a single authentication solution between clients of different Azure services.

Authenticate with Active Directory:

```C# Snippet:ServiceBusAuthAAD
// Create a ServiceBusClient that will authenticate through Active Directory
string fullyQualifiedNamespace = "yournamespace.servicebus.windows.net";
await using ServiceBusClient client = new(fullyQualifiedNamespace, new DefaultAzureCredential());
```

Authenticate with connection string:

```C# Snippet:ServiceBusAuthConnString
// Create a ServiceBusClient that will authenticate using a connection string
string connectionString = "<connection_string>";
await using ServiceBusClient client = new(connectionString);
```

#### Administration client

The `ServiceBusAdministrationClient` replaces the `NamespaceManager` from `WindowsAzure.ServiceBus`. For example usage please see the sample for [CRUD operations using the `ServiceBusAdministrationClient`](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/servicebus/Azure.Messaging.ServiceBus/samples/Sample07_CrudOperations.md).

Authenticate with Active Directory:

```C# Snippet:ServiceBusAdministrationClientAAD
// Create a ServiceBusAdministrationClient that will authenticate using default credentials
string fullyQualifiedNamespace = "yournamespace.servicebus.windows.net";
ServiceBusAdministrationClient client = new(fullyQualifiedNamespace, new DefaultAzureCredential());
```

Authenticate with connection string:

```C# Snippet:ServiceBusAdministrationClientConnectionString
// Create a ServiceBusAdministrationClient that will authenticate using a connection string
string connectionString = "<connection_string>";
ServiceBusAdministrationClient client = new(connectionString);
```

### Sending messages

In `WindowsAzure.ServiceBus`, you could send messages by using a `QueueClient`, `TopicClient`, or `MessageSender`.



```C#
// create a message to send
BrokeredMessage message = new BrokeredMessage("Hello world!");


// send using the QueueClient
QueueClient queueClient = QueueClient.CreateFromConnectionString(connectionString, queueName);
await queueClient.SendAsync(message);

// send using the MessageSender
var messagingFactory = MessagingFactory.CreateFromConnectionString(connectionString);
var sender = await messagingFactory.CreateMessageSenderAsync(queueName);
await sender.SendAsync(message);
```

In `Azure.Messaging.ServiceBus`, all of the send-related features are combined in a common class, `ServiceBusSender`, that is created  by calling `CreateSender` on your `ServiceBusClient`. This method takes the queue or topic you want to send to and creates a sender for that specific entity.


The feature to send a list of messages in a single call was implemented by batching all the messages into a single AMQP message and sending that to the service.

While we continue to support this feature, it had the potential to fail unexpectedly when the resulting batched AMQP message exceeded the size limit of the sender. To help with this, we now provide a safe way to batch multiple messages to be sent at once using the new `ServiceBusMessageBatch` class.  The batch allows you to measure your message with the `TryAdd` method, returning `false` when a message is too large to fit in the batch. It is important to note that it is no longer supported to batch messages together which are bound for multiple partitions.

```C# Snippet:ServiceBusSendAndReceiveSafeBatch
// add the messages that we plan to send to a local queue
Queue<ServiceBusMessage> messages = new();
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

In `WindowsAzure.ServiceBus`, you could receive messages by using a `QueueClient`, `SubscriptionClient`, or `MessageReceiver`.


```C#
// receive using the QueueClient
QueueClient queueClient = new QueueClient(connectionString, queueName);
BrokeredMessage receivedMessage = await queueClient.ReceiveAsync();
Console.WriteLine($"Received message with Body:{receivedMessage.GetBody<String>()}");
await receivedMessage.CompleteAsync();

// Or receive using the receiver
var messagingFactory = MessagingFactory.CreateFromConnectionString(connectionString);
var receiver = await receiverFactory.CreateMessageReceiverAsync(queueName, ReceiveMode.PeekLock);
BrokeredMessage receivedMessage = await receiver.ReceiveAsync();
Console.WriteLine($"Received message with Body:{receivedMessage.GetBody<String>()}");
await receivedMessage.CompleteAsync();
```

In `Azure.Messaging.ServiceBus`, we introduced `ServiceBusProcessor` which uses a push-based approach to deliver messages to event handlers that you provide while managing locks, message completion, concurrency, and resiliency.  The processor also provides a graceful shutdown via the `StopProcessingAsync` method which will ensure that no more messages will be received, but at the same time you can continue the processing and settling the messages already in flight.

The concept of a receiver remains for users who need to have a more fine-grained control over the reading and settling messages. The difference is that this is now created from the top-level `ServiceBusClient` via the `CreateReceiver` method taking the queue or subscription you want to read from and creating a receiver specific to that entity.

Another notable difference from `WindowsAzure.ServiceBus` when it comes to receiving messages, is that `Azure.Messaging.ServiceBus` uses a separate type for received messages, `ServiceBusReceivedMessage`. This helps reduce the surface area of the sendable messages by excluding properties that are owned by the service  and cannot be set when sending messages. 

 To support testing, the `ServiceBusModelFactory.ServiceBusReceivedMessage` method can be used to mock a message received from Service Bus. In general, all types that are meant to be created only by the library can be created for mocking using the `ServiceBusModelFactory` static class.

```C# Snippet:ServiceBusConfigureProcessor
// create the options to use for configuring the processor
ServiceBusProcessorOptions options = new()
{
    // By default or when AutoCompleteMessages is set to true, the processor will complete the message after executing the message handler
    // Set AutoCompleteMessages to false to [settle messages](https://learn.microsoft.com/azure/service-bus-messaging/message-transfers-locks-settlement#peeklock) on your own.
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

// since the processing happens in the background, we add a Console.ReadKey to allow the processing to continue until a key is pressed.
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

### Dead letter messages

There are a few notable differences in `Azure.Messaging.ServiceBus` when it comes to moving messages to the dead letter queue. We now offer a dedicated method where you can pass the reason and error description as parameters when moving messages to the dead letter queue. Additionally, we now expose the `ServiceBusReceivedMessage.DeadLetterReason` and `ServiceBusReceivedMessage.DeadLetterErrorDescription` as top-level properties on the received message.
Another notable difference is that when receiving from the dead letter queue, you will need to set the SubQueue option of the `ServiceBusReceiverOptions` to `SubQueue.DeadLetter`.

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

### Working with sessions

In `WindowsAzure.ServiceBus`, you to receive messages from a session-enabled queue/subscription you would register a message using the `QueueClient.RegisterSessionHandler` method to receive messages from an available set of sessions.


In `Azure.Messaging.ServiceBus`, we simplify this by giving session-aware variants of the same methods and classes that are available when working with queues/subscriptions that do not have sessions enabled.

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
    // Set AutoCompleteMessages to false to [settle messages](https://learn.microsoft.com/azure/service-bus-messaging/message-transfers-locks-settlement#peeklock) on your own.
    // In both cases, if the message handler throws an exception without settling the message, the processor will abandon the message.
    MaxConcurrentCallsPerSession = 2,

    // Processing can be optionally limited to a subset of session Ids.
    SessionIds = { "my-session", "your-session" },
};

// create a session processor that we can use to process the messages
await using ServiceBusSessionProcessor processor = client.CreateSessionProcessor(queueName, options);

// configure the message and error event handler to use - these event handlers are required
processor.ProcessMessageAsync += MessageHandler;
processor.ProcessErrorAsync += ErrorHandler;

// configure optional event handlers that will be executed when a session starts processing and stops processing
// NOTE: The SessionInitializingAsync event is raised when the processor obtains a lock for a session. This does not mean the session was
// never processed before by this or any other ServiceBusSessionProcessor instances. Similarly, the SessionClosingAsync
// event is raised when no more messages are available for the session being processed subject to the SessionIdleTimeout
// in the ServiceBusSessionProcessorOptions. If additional messages are sent for that session later, the SessionInitializingAsync and SessionClosingAsync
// events would be raised again.

processor.SessionInitializingAsync += SessionInitializingHandler;
processor.SessionClosingAsync += SessionClosingHandler;

async Task MessageHandler(ProcessSessionMessageEventArgs args)
{
    var body = args.Message.Body.ToString();

    // we can evaluate application logic and use that to determine how to settle the message.
    await args.CompleteMessageAsync(args.Message);

    // we can also set arbitrary session state using this receiver
    // the state is specific to the session, and not any particular message
    await args.SetSessionStateAsync(new BinaryData("Some state specific to this session when processing a message."));
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

async Task SessionInitializingHandler(ProcessSessionEventArgs args)
{
    await args.SetSessionStateAsync(new BinaryData("Some state specific to this session when the session is opened for processing."));
}

async Task SessionClosingHandler(ProcessSessionEventArgs args)
{
    // We may want to clear the session state when no more messages are available for the session or when some known terminal message
    // has been received. This is entirely dependent on the application scenario.
    BinaryData sessionState = await args.GetSessionStateAsync();
    if (sessionState.ToString() ==
        "Some state that indicates the final message was received for the session")
    {
        await args.SetSessionStateAsync(null);
    }
}

// start processing
await processor.StartProcessingAsync();

// since the processing happens in the background, we add a Console.ReadKey to allow the processing to continue until a key is pressed.
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

### Cross-entity transactions


In `WindowsAzure.ServiceBus`, when performing a transaction that spanned multiple queues, topics, or subscriptions you would need to use the `ViaPartitionKey` option

in the `MessageSender`.

In `Azure.Messaging.ServiceBus`, the `EnableCrossEntityTransactions` property on `ServiceBusClientOptions` serves this purpose. When setting this property to `true`, the first operation that occurs using any senders or receivers created from the client implicitly becomes the send-via entity. Because of this, subsequent operations must either be by senders, or if they are by receivers, the receiver must be receiving from the send-via entity. For this reason, it probably makes more sense to have your first operation be a receive rather than a send when setting this property.

The below code snippet shows you how to perform cross-entity transactions.

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

### Distributed tracing

In `WindowsAzure.ServiceBus`, the library would automatically flow [activity baggage](https://learn.microsoft.com/dotnet/api/system.diagnostics.activity.baggage) via the `Correlation-Context` entry of the `BrokeredMessage.Properties` dictionary. This would allow senders and receivers to correlate any information that was added to an Activity's baggage by an application.

In `Azure.Messaging.ServiceBus`, activity baggage is not currently flowed through the message. Instead, when using the [experimental OpenTelemetry support](https://devblogs.microsoft.com/azure-sdk/introducing-experimental-opentelemetry-support-in-the-azure-sdk-for-net/), `tracestate` can be used to correlate the [Activity.TraceStateString](https://learn.microsoft.com/dotnet/api/system.diagnostics.activity.tracestatestring) between senders, receivers, and processors. The `tracestate` entry is populated in the `ServiceBusMessage.ApplicationProperties` if the enclosing Activity has a non-null `TraceStateString`. In the future, we plan to add additional support for propagating context between senders, receivers, and processors. More details about tracing support in the `Azure.Messaging.ServiceBus` library can be found in the [troubleshooting guide](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/servicebus/Azure.Messaging.ServiceBus/TROUBLESHOOTING.md#distributed-tracing).


## Plugins

With `Azure.Messaging.ServiceBus`, you can extend the various types, allowing users of the Service Bus library to use common OSS extensions to enhance their applications without having to implement their own logic, and without having to wait for the SDK to explicitly support the needed feature, as demonstrated in the [extensibility sample](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/servicebus/Azure.Messaging.ServiceBus/samples/Sample09_Extensibility.md). We also have a [dedicated sample](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/servicebus/Azure.Messaging.ServiceBus/samples/Sample10_ClaimCheck.md) that demonstrates using the claim check pattern in the new library. 

## Additional samples

More examples can be found at:

- [Service Bus samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/servicebus/Azure.Messaging.ServiceBus/samples)

## Frequently asked questions

**Why doesn't `Azure.Messaging.ServiceBus` support batch settlement of messages?**

Batch settlement of messages is not implemented in the `Azure.Messaging.ServiceBus` client library because there is no support for batch operations in Service Bus itself; previous Service Bus packages provided a client-side only implementation similar to:

```C# Snippet:MigrationGuideBatchMessageSettlement
var tasks = new List<Task>();

foreach (ServiceBusReceivedMessage message in messages)
{
    tasks.Add(receiver.CompleteMessageAsync(message));
}

await Task.WhenAll(tasks);
```

For `Azure.Messaging.ServiceBus`, we felt that the client-side approach would introduce complexity and confusion around error scenarios due to the potential for partial success.  It also may hide a performance bottleneck, which we would like to avoid.  Since this pattern is fairly straight-forward to implement, we felt it was better applied in the application than hidden within the Azure SDK.
