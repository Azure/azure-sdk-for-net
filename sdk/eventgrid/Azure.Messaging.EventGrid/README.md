# Azure Event Grid client library for .NET

Azure Event Grid allows you to easily build applications with event-based architectures. The Event Grid service fully manages all routing of events from any source, to any destination, for any application. Azure service events and custom events can be published directly to the service, where the events can then be filtered and sent to various recipients, such as built-in handlers or custom webhooks. To learn more about Azure Event Grid: [What is Event Grid?](https://learn.microsoft.com/azure/event-grid/overview)

Use the client library for Azure Event Grid to:
- Publish events to the Event Grid service using the Event Grid Event, Cloud Event 1.0, or custom schemas
- Consume events that have been delivered to event handlers
- Generate SAS tokens to authenticate the client publishing events to Azure Event Grid topics

  [Source code](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventgrid/Azure.Messaging.EventGrid/src) | [Package (NuGet)](https://www.nuget.org/packages/Azure.Messaging.EventGrid/) | [API reference documentation](https://learn.microsoft.com/dotnet/api/azure.messaging.eventgrid) | [Product documentation](https://learn.microsoft.com/azure/event-grid/) | [Samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/eventgrid/Azure.Messaging.EventGrid/samples) | [Migration guide](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/eventgrid/Azure.Messaging.EventGrid/MigrationGuide.md)

## Getting started

### Install the package

Install the client library from [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Messaging.EventGrid
```

### Prerequisites

You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/) and an Azure resource group with a custom Event Grid topic or domain. Follow this [step-by-step tutorial](https://learn.microsoft.com/azure/event-grid/custom-event-quickstart-portal) to register the Event Grid resource provider and create Event Grid topics using the [Azure portal](https://portal.azure.com/). There is a [similar tutorial](https://learn.microsoft.com/azure/event-grid/custom-event-quickstart) using [Azure CLI](https://learn.microsoft.com/cli/azure).

### Authenticate the Client

In order for the client library to interact with a topic or domain, you will need the `endpoint` of the Event Grid topic and a `credential`, which can be created using the topic's access key.

You can find the endpoint for your Event Grid topic either in the [Azure Portal](https://portal.azure.com/) or by using the [Azure CLI](https://learn.microsoft.com/cli/azure) snippet below.

```bash
az eventgrid topic show --name <your-resource-name> --resource-group <your-resource-group-name> --query "endpoint"
```

The access key can also be found through the [portal](https://learn.microsoft.com/azure/event-grid/get-access-keys), or by using the Azure CLI snippet below:
```bash
az eventgrid topic key list --name <your-resource-name> --resource-group <your-resource-group-name> --query "key1"
```

#### Authenticate using Topic Access Key

Once you have your access key and topic endpoint, you can create the publisher client as follows:
```C#
EventGridPublisherClient client = new EventGridPublisherClient(
    new Uri("<endpoint>"),
    new AzureKeyCredential("<access-key>"));
```

#### Authenticate using Shared Access Signature

Event Grid also supports authenticating with a shared access signature which allows for providing access to a resource that expires by a certain time without sharing your access key.
Generally, the workflow would be that one application would generate the SAS string and hand off the string to another application that would consume the string.
Generate the SAS:
```C# Snippet:GenerateSas
var builder = new EventGridSasBuilder(new Uri(topicEndpoint), DateTimeOffset.Now.AddHours(1));
var keyCredential = new AzureKeyCredential(topicAccessKey);
string sasToken = builder.GenerateSas(keyCredential);
```

Here is how it would be used from the consumer's perspective:
```C# Snippet:AuthenticateWithSas
var sasCredential = new AzureSasCredential(sasToken);
EventGridPublisherClient client = new EventGridPublisherClient(
    new Uri(topicEndpoint),
    sasCredential);
```

`EventGridPublisherClient` also accepts a set of configuring options through `EventGridPublisherClientOptions`. For example, you can specify a custom serializer that will be used to serialize the event data to JSON.

#### Authenticate using Microsoft Entra ID

Azure Event Grid provides integration with Microsoft Entra ID for identity-based authentication of requests. With Azure AD, you can use role-based access control (RBAC) to grant access to your Azure Event Grid resources to users, groups, or applications. The [Azure Identity library](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity/README.md) provides easy Microsoft Entra ID support for authentication.

To send events to a topic or domain using Microsoft Entra ID, the authenticated identity should have the "EventGrid Data Sender" role assigned.

```C# Snippet:EventGridAAD
EventGridPublisherClient client = new EventGridPublisherClient(
    new Uri(topicEndpoint),
    new DefaultAzureCredential());
```

## Key concepts

For information about general Event Grid concepts: [Concepts in Azure Event Grid](https://learn.microsoft.com/azure/event-grid/concepts).

### EventGridPublisherClient
A **publisher** sends events to the Event Grid service. Microsoft publishes events for several Azure services. You can publish events from your own application using the `EventGridPublisherClient`.

### Event schemas
An **event** is the smallest amount of information that fully describes something that happened in the system. Event Grid supports multiple schemas for encoding events. When a custom topic or domain is created, you specify the schema that will be used when publishing events.

#### Event Grid schema
While you may configure your topic to use a custom schema, it is more common to use the already-defined Event Grid schema. See the specifications and requirements [here](https://learn.microsoft.com/azure/event-grid/event-schema).

#### CloudEvents v1.0 schema
Another option is to use the CloudEvents v1.0 schema. [CloudEvents](https://cloudevents.io/) is a Cloud Native Computing Foundation project which produces a specification for describing event data in a common way. The service summary of CloudEvents can be found [here](https://learn.microsoft.com/azure/event-grid/cloud-event-schema).

Regardless of what schema your topic or domain is configured to use, `EventGridPublisherClient` will be used to publish events to it. Use the `SendEvents` or `SendEventsAsync` method for publishing.

### Event delivery
Events delivered to consumers by Event Grid are *delivered as JSON*. Depending on the type of consumer being delivered to, the Event Grid service may deliver one or more events as part of a single payload. Handling events will be different based on which schema the event was delivered as. However, the general pattern will remain the same:
- Parse events from JSON into individual events. Based on the event schema (Event Grid or CloudEvents), you can now access basic information about the event on the envelope (properties that are present for all events, like event time and type).
- Deserialize the event data. Given an `EventGridEvent` or `CloudEvent`, the user can attempt to access the event payload, or data, by deserializing to a specific type. You can supply a custom serializer at this point to correctly decode the data.

### Thread safety
We guarantee that all client instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This ensures that the recommendation of reusing client instances is always safe, even across threads.

### Additional concepts
<!-- CLIENT COMMON BAR -->
[Client options](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Accessing the response](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#accessing-http-response-details-using-responset) |
[Long-running operations](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#consuming-long-running-operations-using-operationt) |
[Handling failures](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md) |
[Mocking](https://learn.microsoft.com/dotnet/azure/sdk/unit-testing-mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
<!-- CLIENT COMMON BAR -->

## Examples
* [Publish Event Grid events to an Event Grid Topic](#publish-event-grid-events-to-an-event-grid-topic)
* [Publish CloudEvents to an Event Grid Topic](#publish-cloudevents-to-an-event-grid-topic)
* [Publish Event Grid events to an Event Grid Domain](#publish-event-grid-events-to-an-event-grid-domain)
* [Receiving and Deserializing Events](#receiving-and-deserializing-events)

### Publish Event Grid events to an Event Grid Topic
Publishing events to Event Grid is performed using the `EventGridPublisherClient`. Use the provided `SendEvent`/`SendEventAsync` method to publish a single event to the topic.
```C# Snippet:SendSingleEGEventToTopic
// Add EventGridEvents to a list to publish to the topic
EventGridEvent egEvent =
    new EventGridEvent(
        "ExampleEventSubject",
        "Example.EventType",
        "1.0",
        "This is the event data");

// Send the event
await client.SendEventAsync(egEvent);
```

To publish a batch of events, use the `SendEvents`/`SendEventsAsync` method.
```C# Snippet:SendEGEventsToTopic
// Example of a custom ObjectSerializer used to serialize the event payload to JSON
var myCustomDataSerializer = new JsonObjectSerializer(
    new JsonSerializerOptions()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    });

// Add EventGridEvents to a list to publish to the topic
List<EventGridEvent> eventsList = new List<EventGridEvent>
{
    // EventGridEvent with custom model serialized to JSON
    new EventGridEvent(
        "ExampleEventSubject",
        "Example.EventType",
        "1.0",
        new CustomModel() { A = 5, B = true }),

    // EventGridEvent with custom model serialized to JSON using a custom serializer
    new EventGridEvent(
        "ExampleEventSubject",
        "Example.EventType",
        "1.0",
        myCustomDataSerializer.Serialize(new CustomModel() { A = 5, B = true })),
};

// Send the events
await client.SendEventsAsync(eventsList);
```
### Publish CloudEvents to an Event Grid Topic
Publishing events to Event Grid is performed using the `EventGridPublisherClient`. Use the provided `SendEvents`/`SendEventsAsync` method to publish events to the topic.
```C# Snippet:SendCloudEventsToTopic
// Example of a custom ObjectSerializer used to serialize the event payload to JSON
var myCustomDataSerializer = new JsonObjectSerializer(
    new JsonSerializerOptions()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    });

// Add CloudEvents to a list to publish to the topic
List<CloudEvent> eventsList = new List<CloudEvent>
{
    // CloudEvent with custom model serialized to JSON
    new CloudEvent(
        "/cloudevents/example/source",
        "Example.EventType",
        new CustomModel() { A = 5, B = true }),

    // CloudEvent with custom model serialized to JSON using a custom serializer
    new CloudEvent(
        "/cloudevents/example/source",
        "Example.EventType",
        myCustomDataSerializer.Serialize(new CustomModel() { A = 5, B = true }),
        "application/json"),

    // CloudEvents also supports sending binary-valued data
    new CloudEvent(
        "/cloudevents/example/binarydata",
        "Example.EventType",
        new BinaryData(Encoding.UTF8.GetBytes("This is treated as binary data")),
        "application/octet-stream")};

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
        "ExampleEventSubject",
        "Example.EventType",
        "1.0",
        "This is the event data")
    {
        Topic = "MyTopic"
    }
};

// Send the events
await client.SendEventsAsync(eventsList);
```

For sending CloudEvents, the CloudEvent source is used as the domain topic:
```C# Snippet:SendCloudEventsToDomain
List<CloudEvent> eventsList = new List<CloudEvent>();

for (int i = 0; i < 10; i++)
{
    CloudEvent cloudEvent = new CloudEvent(
        // the source is mapped to the domain topic
        $"Subject-{i}",
        "Microsoft.MockPublisher.TestEvent",
        "hello")
    {
        Id = $"event-{i}",
        Time = DateTimeOffset.Now
    };
    eventsList.Add(cloudEvent);
}

await client.SendEventsAsync(eventsList);
```

### Receiving and Deserializing Events
There are several different Azure services that act as [event handlers](https://learn.microsoft.com/azure/event-grid/event-handlers).

Note: if using Webhooks for event delivery of the *Event Grid schema*, Event Grid requires you to prove ownership of your Webhook endpoint before it starts delivering events to that endpoint. At the time of event subscription creation, Event Grid sends a subscription validation event to your endpoint, as seen below. Learn more about completing the handshake here: [Webhook event delivery](https://learn.microsoft.com/azure/event-grid/webhook-event-delivery). For the *CloudEvents schema*, the service validates the connection using the HTTP options method. Learn more here: [CloudEvents validation](https://github.com/cloudevents/spec/blob/v1.0/http-webhook.md#4-abuse-protection).

Once events are delivered to the event handler, we can deserialize the JSON payload into a list of events.

Using `EventGridEvent`:
```C# Snippet:EGEventParseJson
// Parse the JSON payload into a list of events
EventGridEvent[] egEvents = EventGridEvent.ParseMany(BinaryData.FromStream(httpContent));
```

Using `CloudEvent`:
```C# Snippet:CloudEventParseJson
var bytes = await httpContent.ReadAsByteArrayAsync();
// Parse the JSON payload into a list of events
CloudEvent[] cloudEvents = CloudEvent.ParseMany(new BinaryData(bytes));
```
#### Deserializing event data
From here, one can access the event data by deserializing to a specific type by calling `ToObjectFromJson<T>()` on the `Data` property. In order to deserialize to the correct type, the `EventType` property (`Type` for CloudEvents) helps distinguish between different events. Custom event data should be deserialized using the generic method `ToObjectFromJson<T>()`. There is also an extension method `ToObject<T>()` that accepts a custom `ObjectSerializer` to deserialize the event data.

```C# Snippet:DeserializePayloadUsingGenericGetData
foreach (CloudEvent cloudEvent in cloudEvents)
{
    switch (cloudEvent.Type)
    {
        case "Contoso.Items.ItemReceived":
            // By default, ToObjectFromJson<T> uses System.Text.Json to deserialize the payload
            ContosoItemReceivedEventData itemReceived = cloudEvent.Data.ToObjectFromJson<ContosoItemReceivedEventData>();
            Console.WriteLine(itemReceived.ItemSku);
            break;
        case "MyApp.Models.CustomEventType":
            // One can also specify a custom ObjectSerializer as needed to deserialize the payload correctly
            TestPayload testPayload = cloudEvent.Data.ToObject<TestPayload>(myCustomSerializer);
            Console.WriteLine(testPayload.Name);
            break;
        case SystemEventNames.StorageBlobDeleted:
            // Example for deserializing system events using ToObjectFromJson<T>
            StorageBlobDeletedEventData blobDeleted = cloudEvent.Data.ToObjectFromJson<StorageBlobDeletedEventData>();
            Console.WriteLine(blobDeleted.BlobType);
            break;
    }
}
```

Using `TryGetSystemEventData()`:

If expecting mostly system events, it may be cleaner to switch on `TryGetSystemEventData()` and use pattern matching to act on the individual events. If an event is not a system event, the method will return false and the out parameter will be null.

*As a caveat, if you are using a custom event type with an EventType value that later gets added as a system event by the service and SDK, the return value of `TryGetSystemEventData` would change from `false` to `true`. This could come up if you are pre-emptively creating your own custom events for events that are already being sent by the service, but have not yet been added to the SDK. In this case, it is better to use the generic `ToObjectFromJson<T>` method on the `Data` property so that your code flow doesn't change automatically after upgrading (of course, you may still want to modify your code to consume the newly released system event model as opposed to your custom model).*

```C# Snippet:DeserializePayloadUsingAsSystemEventData
foreach (EventGridEvent egEvent in egEvents)
{
    // If the event is a system event, TryGetSystemEventData will return the deserialized system event
    if (egEvent.TryGetSystemEventData(out object systemEvent))
    {
        switch (systemEvent)
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
                // we can get the raw Json for the event using Data
                Console.WriteLine(egEvent.Data.ToString());
                break;
        }
    }
    else
    {
        switch (egEvent.EventType)
        {
            case "MyApp.Models.CustomEventType":
                TestPayload deserializedEventData = egEvent.Data.ToObjectFromJson<TestPayload>();
                Console.WriteLine(deserializedEventData.Name);
                break;
            // Handle any other custom event type
            default:
                Console.Write(egEvent.EventType);
                Console.WriteLine(egEvent.Data.ToString());
                break;
        }
    }
}
```

## Troubleshooting

### Service Responses
`SendEvents()` returns an HTTP response code from the service. A `RequestFailedException` is thrown as a service response for any unsuccessful requests. The exception contains information about what response code was returned from the service.

### Deserializing Event Data
- If the event data is not valid JSON, a `JsonException` will be thrown when calling `Parse` or `ParseMany`.
- If the event schema does not correspond to the type being deserialized to (e.g. calling `CloudEvent.Parse` on an EventGridSchema event), an `ArgumentException` is thrown.
- If `Parse` is called on data that contains multiple events, an `ArgumentException` is thrown. `ParseMany` should be used here instead.

### Setting up console logging
You can also easily [enable console logging](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md#logging) if you want to dig deeper into the requests you're making against the service.

### Distributed Tracing
The Event Grid library supports distributing tracing out of the box. In order to adhere to the CloudEvents specification's [guidance](https://github.com/cloudevents/spec/blob/v1.0.1/extensions/distributed-tracing.md) on distributing tracing, the library will set the `traceparent` and `tracestate` on the `ExtensionAttributes` of a `CloudEvent` when distributed tracing is enabled. To learn more about how to enable distributed tracing in your application, take a look at the Azure SDK [distributed tracing documentation](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md#Distributed-tracing).

### Event Grid on Kubernetes
This library has been tested and validated on Kubernetes using Azure Arc.

## Next steps

View more https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/eventgrid/Azure.Messaging.EventGrid/samples here for common usages of the Event Grid client library: [Event Grid Samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/eventgrid/Azure.Messaging.EventGrid/samples).

## Contributing

This project welcomes contributions and suggestions.
Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution.
For details, visit [Contributor License Agreements](https://opensource.microsoft.com/cla/).

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment).
Simply follow the instructions provided by the bot.
You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.
