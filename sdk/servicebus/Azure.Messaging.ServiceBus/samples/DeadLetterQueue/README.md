---
page_type: sample
languages:
- csharp
products:
- azure
- azure-service-bus
name: Explore deadlettering in Azure Service Bus
description: This sample shows how to move messages to the Dead-letter queue, how to retrieve messages from it, and resubmit corrected message back into the main queue.
---

# Dead-Letter Queues

This sample shows how to move messages to the Dead-letter queue, how to retrieve
messages from it, and resubmit corrected message back into the main queue.

## What is a Dead-Letter Queue?

All Service Bus Queues and Subscriptions have a secondary sub-queue, called the
*dead-letter queue* (DLQ).

This sub-queue does not need to be explicitly created and cannot be deleted or
otherwise managed independent of the main entity. The purpose of the Dead-Letter
Queue (DLQ) is accept and hold messages that cannot be delivered to any receiver
or messages that could not be processed. Read more about Dead-Letter Queues [in
the product documentation.][1]

## Sample Code

The sample implements two scenarios:

* Send a message and then retrierve and abandon the message until the maximum
  delivery count is exhausted and the message is automatically dead-lettered.

* Send a set of messages, and explicitly dead-letter messages that do not match
  a certain criterion and would therefore not be processed correctly. The messages
  are then picked up from the dead-letter queue, are automatically corrected, and
  resubmitted.

The sample code is further documented inline in the `Program.cs` C# file.

## Prerequisites
In order to run the sample, you will need a Service Bus Namespace. For more information on getting setup see the [Getting Started](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/servicebus/Azure.Messaging.ServiceBus#getting-started) section of the Service Bus library Readme. Once you have a Service Bus Namespace, you will need to create a queue that can be used for the sample. 

## Building the Sample

To build the sample:

1. Install [.NET 5.0](https://dot.net) or newer.

2. Run in the project directory:

   ```dotnetcli
   dotnet build
   ```

## Running the Sample

You can either run the executable you just build, or build and run the project at the same time. There are two ways to authenticate in the sample.

### Use Azure Activity Directory
You can use any of the [authentication mechanisms](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet) that the `DefaultAzureCredential` from the Azure.Identity supports.

To run the sample using Azure Identity:

```dotnetcli
dotnet run -- --namespace <fully qualified namespace> --queue <queue name>
```
### Use a Service Bus connection string
The other way to run the sample is by specifying an environment variable that contains the connection string for the namespace you wish to use:

```dotnetcli
dotnet run -- --connection-variable <environment variable name> --queue <queue name>
```


