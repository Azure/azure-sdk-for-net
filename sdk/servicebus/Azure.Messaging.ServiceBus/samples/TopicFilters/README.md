---
page_type: sample
languages:
- csharp
products:
- azure
- azure-service-bus
name: Explore topic filters in Azure Service Bus
description: This sample shows how to apply topic filters to subscriptions.
---

# Topic Filters

This sample shows how to apply topic filters to subscriptions. 

## What is a Topic Filter?

[Topic filters](https://learn.microsoft.com/azure/service-bus-messaging/topic-filters), or rules, can be applied to subscriptions to allow subscribers to define which messages they want to receive from a topic. For instance, certain subscribers may only be interested in processing messages that fit a certain pattern. Rather than create separate topics for each type of message, or add filtering client side within the application, an application can use a single topic and add filtering logic in the subcriptions to achieve the same result. This is more efficient than filtering client-side as the messages that don't match the filter do not go over the wire. It is also generally more simple and flexible than creating separate topics for each type of message, as it provides a more decoupled architecture between sender and receiver. To learn more, see the [usage patterns](https://learn.microsoft.com/azure/service-bus-messaging/topic-filters#usage-patterns) section of the topic filters learn.

## Sample Code

The sample implements four scenarios:

* Create a subscription with no filters. Technically, all subscriptions are created with the default `TrueFilter`. In the sample, we remove and re-add this filter to demonstrate that all subscriptions will have this filter by default.

* Create a subscription with a SQL filter against a user-defined property. SQL filters hold a SQL-like conditional expression that is evaluated in the broker against user-defined or system properties. If the expression evaluates to `true`, the message is delivered to the subscription.

* Create a subscription with a SQL filter and SQL action. In this scenario, we define a SQL filter along with a SQL expression that performs an action on the received message, for any messages that makes it through the filter expression. 

* Create a subscription with a Correlation filter. A correlation filter provides a strongly typed model for matching against the properties of a received message. Correlation filters are recommended over SQL filters as they are more efficient.

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
The sample will automatically create the topic and subscriptions for you as well as delete them at the end of the run.

### Use Azure Activity Directory
You can use any of the [authentication mechanisms](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet) that the `DefaultAzureCredential` from the Azure.Identity supports.

To run the sample using Azure Identity:

```dotnetcli
dotnet run -- --namespace <fully qualified namespace>
```
### Use a Service Bus connection string
The other way to run the sample is by specifying an environment variable that contains the connection string for the namespace you wish to use:

```dotnetcli
dotnet run -- --connection-variable <environment variable name>
```


