# Azure Event Grid client library for .NET

Azure Event Grid allows you to easily build applications with event-based architectures. The Event Grid service fully manages all routing of events from any source, to any destination, for any application. Azure service events and custom events can be published directly to the service, where the events can then be filtered and sent to various recipients, such as built-in handlers or custom webhooks. To learn more about Azure Event Grid: [What is Event Grid?](https://docs.microsoft.com/azure/event-grid/overview)

Use the client library for Azure Event Grid to:
- Publish events to the Event Grid service using the Event Grid Event, Cloud Event 1.0, or custom schemas
- Consume events that have been delivered to event handlers
- Generate SAS tokens to authenticate the client publishing events to Azure Event Grid topics

  [Source code](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/eventgrid/Azure.Messaging.EventGrid/src) | [Package (NuGet)](https://www.nuget.org/packages/Azure.Messaging.EventGrid/) | [API reference documentation](https://azure.github.io/azure-sdk-for-net/eventgrid.html) | [Product documentation](https://docs.microsoft.com/azure/event-grid/) | [Samples](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventgrid/Azure.Messaging.EventGrid/samples)

## Getting started

### Install the package

Install the client library from [NuGet](https://www.nuget.org/):

```PowerShell
dotnet add package Azure.Messaging.EventGrid --version 4.0.0-beta.4
```

### Prerequisites

You must have an [Azure subscription](https://azure.microsoft.com/free/) and an Azure resource group with a custom Event Grid topic or domain. Follow this [step-by-step tutorial](https://docs.microsoft.com/azure/event-grid/custom-event-quickstart-portal) to register the Event Grid resource provider and create Event Grid topics using the [Azure portal](https://portal.azure.com/). There is a [similar tutorial](https://docs.microsoft.com/azure/event-grid/custom-event-quickstart) using [Azure CLI](https://docs.microsoft.com/cli/azure).

### Authenticate the Client

In order for the client library to interact with a topic or domain, you will need the `endpoint` of the Event Grid topic and a `credential`, which can be created using the topic's access key.

You can find the endpoint for your Event Grid topic either in the [Azure Portal](https://portal.azure.com/) or by using the [Azure CLI](https://docs.microsoft.com/cli/azure) snippet below.

```bash
az eventgrid topic show --name <your-resource-name> --resource-group <your-resource-group-name> --query "endpoint"
```

The access key can also be found through the [portal](https://docs.microsoft.com/azure/event-grid/get-access-keys), or by using the Azure CLI snippet below:
```bash
az eventgrid topic key list --name <your-resource-name> --resource-group <your-resource-group-name> --query "key1"
```

#### Creating and Authenticating `EventGridPublisherClient`

Once you have your access key and topic endpoint, you can create the publisher client as follows:
```C#
EventGridPublisherClient client = new EventGridPublisherClient(
    new Uri("<endpoint>"),
    new AzureKeyCredential("<access-key>"));
```
You can also create a **Shared Access Signature** to authenticate the client using the same access key. The signature can be generated using the endpoint, access key, and the time at which the signature becomes invalid for authentication. Create the client using the `EventGridSharedAccessSignatureCredential` type:
```C#
string sasToken = EventGridPublisherClient.BuildSharedAccessSignature(
    new Uri("<endpoint>"),
    DateTimeOffset.UtcNow.AddMinutes(60),
    new AzureKeyCredential("<access-key>"));

EventGridPublisherClient client = new EventGridPublisherClient(
    new Uri("<endpoint>"),
    new EventGridSharedAccessSignatureCredential(sasToken));
```

`EventGridPublisherClient` also accepts a set of configuring options through `EventGridPublisherClientOptions`. For example, you can specify a custom serializer that will be used to serialize the event data to JSON.

## Key concepts

For information about general Event Grid concepts: [Concepts in Azure Event Grid](https://docs.microsoft.com/azure/event-grid/concepts).

### EventGridPublisherClient
A **publisher** sends events to the Event Grid service. Microsoft publishes events for several Azure services. You can publish events from your own application using the `EventGridPublisherClient`.

### Event schemas
An **event** is the smallest amount of information that fully describes something that happened in the system. Event Grid supports multiple schemas for encoding events. When a custom topic or domain is created, you specify the schema that will be used when publishing events.

#### Event Grid schema
While you may configure your topic to use a custom schema, it is more common to use the already-defined Event Grid schema. See the specifications and requirements [here](https://docs.microsoft.com/azure/event-grid/event-schema).

#### CloudEvents v1.0 schema
Another option is to use the CloudEvents v1.0 schema. [CloudEvents](https://cloudevents.io/) is a Cloud Native Computing Foundation project which produces a specification for describing event data in a common way. The service summary of CloudEvents can be found [here](https://docs.microsoft.com/azure/event-grid/cloud-event-schema).

Regardless of what schema your topic or domain is configured to use, `EventGridPublisherClient` will be used to publish events to it. Use the `SendEvents` or `SendEventsAsync` method for publishing.

### Event delivery
Events delivered to consumers by Event Grid are *delivered as JSON*. Depending on the type of consumer being delivered to, the Event Grid service may deliver one or more events as part of a single payload. Handling events will be different based on which schema the event was delivered as. However, the general pattern will remain the same:
- Parse events from JSON into individual events. Based on the event schema (Event Grid or CloudEvents), you can now access basic information about the event on the envelope (properties that are present for all events, like event time and type).
- Deserialize the event data. Given an `EventGridEvent` or `CloudEvent`, the user can attempt to access the event payload, or data, by deserializing to a specific type. You can supply a custom serializer at this point to correctly decode the data.

## Examples
* [Publish Event Grid events to an Event Grid Topic](#publish-event-grid-events-to-an-event-grid-topic)
* [Publish CloudEvents to an Event Grid Topic](#publish-cloudevents-to-an-event-grid-topic)
* [Publish Event Grid events to an Event Grid Domain](#publish-event-grid-events-to-an-event-grid-domain)
* [Receiving and Deserializing Events](#receiving-and-deserializing-events)

### Publish Event Grid events to an Event Grid Topic
Publishing events to Event Grid is performed using the `EventGridPublisherClient`. Use the provided `SendEvents`/`SendEventsAsync` method to publish events to the topic.
```C# Snippet:SendEGEventsToTopic
// Add EventGridEvents to a list to publish to the topic
List<EventGridEvent> eventsList = new List<EventGridEvent>
{
    new EventGridEvent(
        "This is the event data",
        "ExampleEventSubject",
        "Example.EventType",
        "1.0")
};

// Send the events
await client.SendEventsAsync(eventsList);
```
### Publish CloudEvents to an Event Grid Topic
Publishing events to Event Grid is performed using the `EventGridPublisherClient`. Use the provided `SendEvents`/`SendEventsAsync` method to publish events to the topic.
```C# Snippet:SendCloudEventsToTopic
// Add CloudEvents to a list to publish to the topic
List<CloudEvent> eventsList = new List<CloudEvent>
{
    // CloudEvent with populated data
    new CloudEvent(
        "/cloudevents/example/source",
        "Example.EventType",
        "This is the event data"),

    // CloudEvents also supports sending binary-valued data
    new CloudEvent(
        "/cloudevents/example/binarydata",
        "Example.EventType",
        new BinaryData("This is binary data"),
        "example/binary")};

// Send the events
await client.SendEventsAsync(eventsList);
```

### Publish Event Grid events to an Event Grid Domain
An **event domain** is a management tool for large numbers of Event Grid topics related to the same application. You can think of it as a meta-topic that can have thousands of individual topics. When you create an event domain, you're given a publishing endpoint similar to if you had created a topic in Event Grid.

To publish events to any topic in an Event Domain, push the events to the domain's endpoint the same way you would for a custom topic. The only difference is that you must specify the topic you'd like the event to be delivered to.
```C# Snippet:SendEventsToDomain
// Add EventGridEvents to a list to publish to the domain
// Don't forget to specify the topic you want the event to be delivered to!
List<EventGridEvent> eventsList = new List<EventGridEvent>
{
    new EventGridEvent(
        "This is the event data",
        "ExampleEventSubject",
        "Example.EventType",
        "1.0")
    {
        Topic = "MyTopic"
    }
};

// Send the events
await client.SendEventsAsync(eventsList);
```

### Receiving and Deserializing Events
There are several different Azure services that act as [event handlers](https://docs.microsoft.com/azure/event-grid/event-handlers).

Note: if using Webhooks for event delivery of the *Event Grid schema*, Event Grid requires you to prove ownership of your Webhook endpoint before it starts delivering events to that endpoint. At the time of event subscription creation, Event Grid sends a subscription validation event to your endpoint, as seen below. Learn more about completing the handshake here: [Webhook event delivery](https://docs.microsoft.com/azure/event-grid/webhook-event-delivery). For the *CloudEvents schema*, the service validates the connection using the HTTP options method. Learn more here: [CloudEvents validation](https://github.com/cloudevents/spec/blob/v1.0/http-webhook.md#4-abuse-protection).

Once events are delivered to the event handler, parse the JSON payload into list of events.

Using `EventGridEvent`:
```C# Snippet:EGEventParseJson
// Parse the JSON payload into a list of events using EventGridEvent.Parse
EventGridEvent[] egEvents = EventGridEvent.Parse(jsonPayloadSampleOne);
```

Using `CloudEvent`:
```C# Snippet:CloudEventParseJson
// Parse the JSON payload into a list of events using CloudEvent.Parse
CloudEvent[] cloudEvents = CloudEvent.Parse(jsonPayloadSampleTwo);
```
From here, one can access the event data by deserializing to a specific type using `GetData<T>()` and passing in a custom serializer if necessary. Below is an example calling `GetData<T>()` using CloudEvents. In order to deserialize to the correct type, the `EventType` property (`Type` for CloudEvents) helps distinguish between different events.
```C# Snippet:DeserializePayloadUsingGenericGetData
foreach (CloudEvent cloudEvent in cloudEvents)
{
    switch (cloudEvent.Type)
    {
        case "Contoso.Items.ItemReceived":
            // By default, GetData uses JsonObjectSerializer to deserialize the payload
            ContosoItemReceivedEventData itemReceived = cloudEvent.GetData<ContosoItemReceivedEventData>();
            Console.WriteLine(itemReceived.ItemSku);
            break;
        case "MyApp.Models.CustomEventType":
            // One can also specify a custom ObjectSerializer as needed to deserialize the payload correctly
            TestPayload testPayload = await cloudEvent.GetDataAsync<TestPayload>(myCustomSerializer);
            Console.WriteLine(testPayload.Name);
            break;
        case "Microsoft.Storage.BlobDeleted":
            // Example for deserializing system events using GetData<T>
            StorageBlobDeletedEventData blobDeleted = cloudEvent.GetData<StorageBlobDeletedEventData>();
            Console.WriteLine(blobDeleted.BlobType);
            break;
    }
}
```
Below is an example using the `IsSystemEvent` property along with `AsSystemEventData()` to deserialize system events. 
```C# Snippet:DeserializePayloadUsingAsSystemEventData
foreach (EventGridEvent egEvent in egEvents)
{
    // If the event is a system event, AsSystemEventData() should return the correct system event type
    if (egEvent.IsSystemEvent)
    {
        switch (egEvent.AsSystemEventData())
        {
            case SubscriptionValidationEventData subscriptionValidated:
                Console.WriteLine(subscriptionValidated.ValidationCode);
                break;
            case StorageBlobCreatedEventData blobCreated:
                Console.WriteLine(blobCreated.BlobType);
                break;
            // Handle any other system event type
            default:
                Console.WriteLine(egEvent.EventType);
                // we can get the raw Json for the event using GetData()
                Console.WriteLine(egEvent.GetData().ToString());
                break;
        }
    }
    else
    {
        switch (egEvent.EventType)
        {
            case "MyApp.Models.CustomEventType":
                TestPayload deserializedEventData = egEvent.GetData<TestPayload>();
                Console.WriteLine(deserializedEventData.Name);
                break;
            // Handle any other custom event type
            default:
                Console.Write(egEvent.EventType);
                Console.WriteLine(egEvent.GetData().ToString());
                break;
        }
    }
}
```

## Troubleshooting

### Service Responses
`SendEvents()` returns an HTTP response code from the service. A `RequestFailedException` is thrown as a service response for any unsuccessful requests. The exception contains information about what response code was returned from the service.

### Deserializing Event Data
- If the event data is not valid JSON, a `JsonException` will be thrown during `Parse`.
- An `InvalidOperationException` will be thrown during `GetData<T>()` if a custom serializer is passed into `GetData<T>()` with non-serialized event data (for example, if the event was created by the user and not created by parsing from JSON).

### Setting up console logging
You can also easily [enable console logging](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/samples/Diagnostics.md#logging) if you want to dig deeper into the requests you're making against the service.

### Distributed Tracing
The Event Grid library supports distributing tracing out of the box. In order to adhere to the CloudEvents specification's [guidance](https://github.com/cloudevents/spec/blob/master/extensions/distributed-tracing.md) on distributing tracing, the library will set the `traceparent` and `tracestate` on the [ExtensionAttributes](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventgrid/Azure.Messaging.EventGrid/src/Customization/CloudEvent.cs#L126) of a `CloudEvent` when distributed tracing is enabled. To learn more about how to enable distributed tracing in your application, take a look at the Azure SDK [distributed tracing documentation](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/samples/Diagnostics.md#Distributed-tracing).

## Next steps

View more https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventgrid/Azure.Messaging.EventGrid/samples here for common usages of the Event Grid client library: [Event Grid Samples](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventgrid/Azure.Messaging.EventGrid/samples).

## Contributing

This project welcomes contributions and suggestions.
Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution.
For details, visit <https://cla.microsoft.com.>

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment).
Simply follow the instructions provided by the bot.
You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Ftemplate%2FAzure.Template%2FREADME.png)
