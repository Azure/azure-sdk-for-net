# Azure Service Bus client library for .NET

Azure Service Bus allows you to build applications that take advantage of asynchronous messaging patterns using a highly-reliable service to broker messages between producers and consumers. Azure Service Bus provides flexible, brokered messaging between client and server, along with structured first-in, first-out (FIFO) messaging, and publish/subscribe capabilities with complex routing. If you would like to know more about Azure Service Bus, you may wish to review: [What is Azure Service Bus?](https://docs.microsoft.com/azure/service-bus-messaging/service-bus-messaging-overview)

Use the client library for Azure Service Bus to:

- Transfer business data: leverage messaging for durable exchange of information, such as sales or purchase orders, journals, or inventory movements.

- Decouple applications: improve reliability and scalability of applications and services, relieving senders and receivers of the need to be online at the same time.

- Control how messages are processed: support traditional competing consumers for messages using queues or allow each consumer their own instance of a message using topics and subscriptions.

- Implement complex workflows: message sessions support scenarios that require message ordering or message deferral.

[Source code](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/servicebus/Azure.Messaging.ServiceBus/src) | [Package (NuGet)](https://www.nuget.org/packages/Azure.Messaging.ServiceBus/) | [API reference documentation](https://docs.microsoft.com/dotnet/api/azure.messaging.servicebus?view=azure-dotnet) | [Product documentation](https://docs.microsoft.com/azure/service-bus/) | [Migration guide](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/servicebus/Azure.Messaging.ServiceBus/MigrationGuide.md)

## Getting started

### Prerequisites

- **Microsoft Azure Subscription:** To use Azure services, including Azure Service Bus, you'll need a subscription. If you do not have an existing Azure account, you may sign up for a free trial or use your MSDN subscriber benefits when you [create an account](https://account.windowsazure.com/Home/Index).

- **Service Bus namespace:** To interact with Azure Service Bus, you'll also need to have a namespace available. If you are not familiar with creating Azure resources, you may wish to follow the step-by-step guide for [creating a Service Bus namespace using the Azure portal](https://docs.microsoft.com/azure/service-bus-messaging/service-bus-create-namespace-portal). There, you can also find detailed instructions for using the Azure CLI, Azure PowerShell, or Azure Resource Manager (ARM) templates to create a Service bus entity.

- **C# 8.0:** The Azure Service Bus client library makes use of new features that were introduced in C# 8.0.  In order to take advantage of the C# 8.0 syntax, it is recommended that you compile using the [.NET Core SDK](https://dotnet.microsoft.com/download) 3.0 or higher with a [language version](https://docs.microsoft.com/dotnet/csharp/language-reference/configure-language-version#override-a-default) of `latest`.  It is also possible to compile with the .NET Core SDK 2.1.x using a language version of `preview`.  Visual Studio users wishing to take advantage of the C# 8.0 syntax will need to use Visual Studio 2019 or later.  Visual Studio 2019, including the free Community edition, can be downloaded [here](https://visualstudio.microsoft.com).

  You can still use the library with previous C# language versions, but will need to manage asynchronous enumerable and asynchronous disposable members manually rather than benefiting from the new syntax.  You may still target any framework version supported by your .NET Core SDK, including earlier versions of .NET Core or the .NET framework.  For more information, see: [how to specify target frameworks](https://docs.microsoft.com/dotnet/standard/frameworks#how-to-specify-target-frameworks).  

  **Important Note:** In order to build or run the [examples](#examples) and the [samples](#next-steps) without modification, use of C# 8.0 is mandatory.  You can still run the samples if you decide to tweak them for other language versions.

To quickly create the needed Service Bus resources in Azure and to receive a connection string for them, you can deploy our sample template by clicking:

[![](http://azuredeploy.net/deploybutton.png)](https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2FAzure%2Fazure-sdk-for-net%2Fmaster%2Fsdk%2Fservicebus%2FAzure.Messaging.ServiceBus%2Fassets%2Fsamples-azure-deploy.json)

### Install the package

Install the Azure Service Bus client library for .NET with [NuGet](https://www.nuget.org/):

```PowerShell
dotnet add package Azure.Messaging.ServiceBus --version 7.0.0
```

### Authenticate the client

For the Service Bus client library to interact with a queue or topic, it will need to understand how to connect and authorize with it.  The easiest means for doing so is to use a connection string, which is created automatically when creating a Service Bus namespace.  If you aren't familiar with shared access policies in Azure, you may wish to follow the step-by-step guide to [get a Service Bus connection string](https://docs.microsoft.com/azure/service-bus-messaging/service-bus-quickstart-topics-subscriptions-portal#get-the-connection-string).

Once you have a connection string, you can authenticate your client with it.

```C# Snippet:ServiceBusAuthConnString
// Create a ServiceBusClient that will authenticate using a connection string
string connectionString = "<connection_string>";
ServiceBusClient client = new ServiceBusClient(connectionString);
```

To see how to authenticate using Azure.Identity, view this [example](#authenticating-with-azureidentity).

## Key concepts

Once you've initialized a `ServiceBusClient`, you can interact with the primary resource types within a Service Bus Namespace, of which multiple can exist and on which actual message transmission takes place, the namespace often serving as an application container:

* [Queue](https://docs.microsoft.com/azure/service-bus-messaging/service-bus-messaging-overview#queues): Allows for Sending and Receiving of messages. Often used for point-to-point communication.

* [Topic](https://docs.microsoft.com/azure/service-bus-messaging/service-bus-messaging-overview#topics): As opposed to Queues, Topics are better suited to publish/subscribe scenarios. A topic can be sent to, but requires a subscription, of which there can be multiple in parallel, to consume from.

* [Subscription](https://docs.microsoft.com/azure/service-bus-messaging/service-bus-queues-topics-subscriptions#topics-and-subscriptions): The mechanism to consume from a Topic. Each subscription is independent, and receives a copy of each message sent to the topic. Rules and Filters can be used to tailor which messages are received by a specific subscription.

For more information about these resources, see [What is Azure Service Bus?](https://docs.microsoft.com/azure/service-bus-messaging/service-bus-messaging-overview).

To interact with these resources, one should be familiar with the following SDK concepts:

- A [Service Bus client](https://docs.microsoft.com/dotnet/api/azure.messaging.servicebus.servicebusclient?view=azure-dotnet-preview) is the primary interface for developers interacting with the Service Bus client library. It serves as the gateway from which all interaction with the library will occur.

- A [Service Bus sender](https://docs.microsoft.com/dotnet/api/azure.messaging.servicebus.servicebussender?view=azure-dotnet-preview) is scoped to a particular queue or topic, and is created using the Service Bus client. The sender allows you to send messages to a queue or topic. It also allows for scheduling messages to be available for delivery at a specified date.

- A [Service Bus receiver](https://docs.microsoft.com/dotnet/api/azure.messaging.servicebus.servicebusreceiver?view=azure-dotnet-preview) is scoped to a particular queue or subscription, and is created using the Service Bus client. The receiver allows you to receive messages from a queue or subscription. It also allows the messages to be settled after receiving them. There are four ways of settling messages:
  * Complete - causes the message to be deleted from the queue or topic.
  * Abandon - releases the receiver's lock on the message allowing for the message to be received by other receivers.
  * Defer - defers the message from being received by normal means. In order to receive deferred messages, the sequence number of the message needs to be retained.
  * DeadLetter - moves the message to the Dead Letter queue. This will prevent the message from being received again. In order to receive messages from the Dead Letter queue, a receiver scoped to the Dead Letter queue is needed.

- A [Service Bus session receiver](https://docs.microsoft.com/dotnet/api/azure.messaging.servicebus.servicebussessionreceiver?view=azure-dotnet-preview) is scoped to a particular session-enabled queue or subscription, and is created using the Service Bus client. The session receiver is almost identical to the standard receiver, with the difference being that session management operations are exposed which only apply to session-enabled entities. These operations include getting and setting session state, as well as renewing session locks.

- A [Service Bus processor](https://docs.microsoft.com/dotnet/api/azure.messaging.servicebus.servicebusprocessor?view=azure-dotnet-preview) is scoped to a particular queue or subscription, and is created using the Service Bus client. The `ServiceBusProcessor` can be thought of as an abstraction around a set of receivers. It uses a callback model to allow code to be specified when a message is received and when an exception occurs. It offers automatic completion of processed messages, automatic message lock renewal, and concurrent execution of user specified event handlers. Because of its feature set, it should be the go to tool for writing applications that receive from Service Bus entities. The ServiceBusReceiver is recommended for more complex scenarios in which the processor is not able to provide the fine-grained control that one can expect when using the ServiceBusReceiver directly.

- A [Service Bus session processor](https://docs.microsoft.com/dotnet/api/azure.messaging.servicebus.servicebussessionprocessor?view=azure-dotnet-preview) is scoped to a particular session-enabled queue or subscription, and is created using the Service Bus client. The session processor is almost identical to the standard processor, with the difference being that session management operations are exposed which only apply to session-enabled entities.

For more concepts and deeper discussion, see: [Service Bus Advanced Features](https://docs.microsoft.com/azure/service-bus-messaging/service-bus-messaging-overview#advanced-features).

## Examples

* [Send and receive a message](#send-and-receive-a-message)
* [Send and receive a batch of messages](#send-and-receive-a-batch-of-messages)
* [Complete a message](#complete-a-message)
* [Abandon a message](#abandon-a-message)
* [Defer a message](#defer-a-message)
* [Dead letter a message](#dead-letter-a-message)
* [Using the processor](#using-the-processor)
* [Authenticating with Azure.Identity](#authenticating-with-azureidentity)
* [Working with sessions](#working-with-sessions)
* [More samples](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/servicebus/Azure.Messaging.ServiceBus/samples/README.md)

### Send and receive a message

Message sending is performed using the `ServiceBusSender`. Receiving is performed using the `ServiceBusReceiver`.

```C# Snippet:ServiceBusSendAndReceive
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

// create a receiver that we can use to receive the message
ServiceBusReceiver receiver = client.CreateReceiver(queueName);

// the received message is a different type as it contains some service set properties
ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();

// get the message body as a string
string body = receivedMessage.Body.ToString();
Console.WriteLine(body);
```

### Send and receive a batch of messages

There are two ways of sending several messages at once. The first way of doing this uses safe-batching. With safe-batching, you can create a `ServiceBusMessageBatch` object, which will allow you to attempt to add messages one at a time to the batch using the `TryAdd` method. If the message cannot fit in the batch, `TryAdd` will return false.

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

The second way uses the `SendMessagesAsync` overload that accepts an IEnumerable of `ServiceBusMessage`. With this method, we will attempt to fit all of the supplied messages in a single message batch that we will send to the service. If the messages are too large to fit in a single batch, the operation will throw an exception.

```C# Snippet:ServiceBusSendAndReceiveBatch
IList<ServiceBusMessage> messages = new List<ServiceBusMessage>();
messages.Add(new ServiceBusMessage("First"));
messages.Add(new ServiceBusMessage("Second"));
// send the messages
await sender.SendMessagesAsync(messages);
```

### Complete a message

In order to remove a message from a queue or subscription, we can call the `CompleteAsync` method.

```C# Snippet:ServiceBusCompleteMessage
string connectionString = "<connection_string>";
string queueName = "<queue_name>";
// since ServiceBusClient implements IAsyncDisposable we create it with "await using"
await using var client = new ServiceBusClient(connectionString);

// create the sender
ServiceBusSender sender = client.CreateSender(queueName);

// create a message that we can send
ServiceBusMessage message = new ServiceBusMessage("Hello world!");

// send the message
await sender.SendMessageAsync(message);

// create a receiver that we can use to receive and settle the message
ServiceBusReceiver receiver = client.CreateReceiver(queueName);

// the received message is a different type as it contains some service set properties
ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();

// complete the message, thereby deleting it from the service
await receiver.CompleteMessageAsync(receivedMessage);
```

### Abandon a message

Abandoning a message releases our receiver's lock, which allows the message to be received by this or other receivers.

```C# Snippet:ServiceBusAbandonMessage
ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();

// abandon the message, thereby releasing the lock and allowing it to be received again by this or other receivers
await receiver.AbandonMessageAsync(receivedMessage);
```

### Defer a message

Deferring a message will prevent it from being received again using the `ReceiveMessageAsync` or `ReceiveMessagesAsync` methods. Instead, there are separate methods, `ReceiveDeferredMessageAsync` and `ReceiveDeferredMessagesAsync` for receiving deferred messages.

```C# Snippet:ServiceBusDeferMessage
ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();

// defer the message, thereby preventing the message from being received again without using
// the received deferred message API.
await receiver.DeferMessageAsync(receivedMessage);

// receive the deferred message by specifying the service set sequence number of the original
// received message
ServiceBusReceivedMessage deferredMessage = await receiver.ReceiveDeferredMessageAsync(receivedMessage.SequenceNumber);
```

### Dead letter a message

Dead lettering a message is similar to deferring with one main difference being that messages will be automatically dead lettered by the service after they have been received a certain number of times. Applications can choose to manually dead letter messages based on their requirements. When a message is dead lettered it is actually moved to a subqueue of the original queue.

```C# Snippet:ServiceBusDeadLetterMessage
ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();

// dead-letter the message, thereby preventing the message from being received again without receiving from the dead letter queue.
await receiver.DeadLetterMessageAsync(receivedMessage);

// receive the dead lettered message with receiver scoped to the dead letter queue.
ServiceBusReceiver dlqReceiver = client.CreateReceiver(queueName, new ServiceBusReceiverOptions
{
    SubQueue = SubQueue.DeadLetter
});
ServiceBusReceivedMessage dlqMessage = await dlqReceiver.ReceiveMessageAsync();
```

### Using the Processor

The `ServiceBusProcessor` can be thought of as an abstraction around a set of receivers. It uses a callback model to allow code to be specified when a message is received and when an exception occurs. It offers automatic completion of processed messages, automatic message lock renewal, and concurrent execution of user specified event handlers. Because of its feature set, it should be the go to tool for writing applications that receive from Service Bus entities. The ServiceBusReceiver is recommended for more complex scenarios in which the processor is not able to provide the fine-grained control that one can expect when using the ServiceBusReceiver directly.

```C# Snippet:ServiceBusProcessMessages
string connectionString = "<connection_string>";
string queueName = "<queue_name>";
// since ServiceBusClient implements IAsyncDisposable we create it with "await using"
await using var client = new ServiceBusClient(connectionString);

// create the sender
ServiceBusSender sender = client.CreateSender(queueName);

// create a set of messages that we can send
ServiceBusMessage[] messages = new ServiceBusMessage[]
{
    new ServiceBusMessage("First"),
    new ServiceBusMessage("Second")
};

// send the message batch
await sender.SendMessagesAsync(messages);

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

### Authenticating with Azure.Identity

The [Azure Identity library](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/identity/Azure.Identity/README.md) provides easy Azure Active Directory support for authentication.

```C# Snippet:ServiceBusAuthAAD
// Create a ServiceBusClient that will authenticate through Active Directory
string fullyQualifiedNamespace = "yournamespace.servicebus.windows.net";
ServiceBusClient client = new ServiceBusClient(fullyQualifiedNamespace, new DefaultAzureCredential());
```

### Working with Sessions

[Sessions](https://docs.microsoft.com/azure/service-bus-messaging/message-sessions) provide a mechanism for grouping related messages. In order to use sessions, you need to be working with a session-enabled entity.

- [Sending and receiving session messages](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/servicebus/Azure.Messaging.ServiceBus/samples/Sample03_SendReceiveSessions.md)
- [Using the session processor](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/servicebus/Azure.Messaging.ServiceBus/samples/Sample05_SessionProcessor.md)

## Troubleshooting

### Exception handling

#### Service Bus Exception

A `ServiceBusException` is triggered when an operation specific to Service Bus has encountered an issue, including both errors within the service and specific to the client.  The exception includes some contextual information to assist in understanding the context of the error and its relative severity.  These are:

- `IsTransient` : This identifies whether or not the exception is considered recoverable.  In the case where it was deemed transient, the appropriate retry policy has already been applied and retries were unsuccessful.

- `Reason` : Provides a set of well-known reasons for the failure that help to categorize and clarify the root cause.  These are intended to allow for applying exception filtering and other logic where inspecting the text of an exception message wouldn't be ideal.   Some key failure reasons are:

  - **Service Timeout** : This indicates that the Service Bus service did not respond to an operation within the expected amount of time.  This may have been caused by a transient network issue or service problem.  The Service Bus service may or may not have successfully completed the request; the status is not known.  It is recommended to attempt to verify the current state and retry if necessary.

  - **Message Lock Lost** : This can occur if the processing takes longer than the lock duration specified at the entity level for a message. If this error occurs consistently, it may be worth increasing the message lock duration. Otherwise, callers can renew the message lock while they are processing the message to ensure that this error doesn't occur.

  - **Messaging Entity Not Found**: A Service Bus resource, such as a queue, topic, or subscription could not be found by the Service Bus service. This may indicate that it has been deleted from the service or that there is an issue with the Service Bus service itself.

Reacting to a specific failure reason for the `ServiceBusException` can be accomplished in several ways, such as by applying an exception filter clause as part of the `catch` block:

```C# Snippet:ServiceBusExceptionFailureReasonUsage
try
{
    // Receive messages using the receiver client
}
catch (ServiceBusException ex) when
    (ex.Reason == ServiceBusFailureReason.ServiceTimeout)
{
    // Take action based on a service timeout
}
```

#### Other exceptions

For detailed information about the failures represented by the `ServiceBusException` and other exceptions that may occur, please refer to [Service Bus messaging exceptions](https://docs.microsoft.com/azure/service-bus-messaging/service-bus-messaging-exceptions).

### Logging and diagnostics

The Service Bus client library is fully instrumented for logging information at various levels of detail using the .NET `EventSource` to emit information.  Logging is performed for each operation and follows the pattern of marking the starting point of the operation and either it's completion or exceptions encountered.  Additional information that may offer insight is also logged in the context of the associated operation.

The Service Bus client logs are available to any `EventListener` by opting into the source named "Azure-Messaging-ServiceBus" or opting into all sources that have the trait "AzureEventSource".  To make capturing logs from the Azure client libraries easier, the `Azure.Core` library used by Service Bus offers an `AzureEventSourceListener`.  More information can be found in the [Azure.Core Diagnostics sample](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/samples/Diagnostics.md#logging).

The Service Bus client library is also instrumented for distributed tracing using Application Insights or OpenTelemetry.  More information can be found in the [Azure.Core Diagnostics sample](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/samples/Diagnostics.md#distributed-tracing).

## Next steps

Beyond the introductory scenarios discussed, the Azure Service Bus client library offers support for additional scenarios to help take advantage of the full feature set of the Azure Service Bus service. In order to help explore some of these scenarios, the Service Bus client library offers a project of samples to serve as an illustration for common scenarios. Please see the [samples README](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/servicebus/Azure.Messaging.ServiceBus/samples/README.md) for details.

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit https://cla.microsoft.com.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

Please see our [contributing guide](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/servicebus/Azure.Messaging.ServiceBus/CONTRIBUTING.md) for more information.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fservicebus%2FAzure.Messaging.ServiceBus%2FREADME.png)
