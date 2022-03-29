# Guide for migrating to Azure.Messaging.EventGrid from Microsoft.Azure.EventGrid

This guide is intended to assist in the migration to `Azure.Messaging.EventGrid` from `Microsoft.Azure.EventGrid`. It will focus on side-by-side comparisons for similar operations between the two packages.

We assume that you are familiar with `Microsoft.Azure.EventGrid`. If not, please refer to the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/eventgrid/Azure.Messaging.EventGrid/README.md) for `Azure.Messaging.EventGrid` rather than this guide.

## Table of contents
- [Migration benefits](#migration-benefits)
  - [Cross Service SDK improvements](#cross-service-sdk-improvements)
  - [New features](#new-features)
- [Important changes](#important-changes)
  - [Package names and namespaces](#package-names-and-namespaces)
  - [Client naming and constructors](#client-naming-and-constructors)
  - [Publishing events to a topic](#publishing-events-to-a-topic)
  - [Deserializing events and data](#deserializing-events-and-data)
- [Additional samples](#additional-samples)

## Migration benefits

As Azure has matured and been embraced by a more diverse group of developers, we have been focused on learning the patterns and practices to best support developer productivity and to understand the gaps that the .NET client libraries have.

There were several areas of consistent feedback expressed across the Azure client library ecosystem. One of the most important is that the client libraries for different Azure services have not had a consistent approach to organization, naming, and API structure. Additionally, many developers have felt that the learning curve was difficult, and the APIs did not offer a good, approachable, and consistent onboarding story for those learning Azure or exploring a specific Azure service.

To improve the development experience across Azure services, a set of uniform [design guidelines](https://azure.github.io/azure-sdk/general_introduction.html) was created for all languages to drive a consistent experience with established API patterns for all services. A set of [.NET design guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html) was also introduced to ensure that .NET clients have a natural and idiomatic feel with respect to the .NET ecosystem. The new Azure.Messaging.EventGrid library follows these guidelines.

### Cross Service SDK improvements

The modern `Azure.Messaging.EventGrid` client library also provides the ability to share in some of the cross-service improvements made to the Azure development experience, such as:

- Using the new Azure.Identity library to share a single authentication approach between clients
- A unified logging and diagnostics pipeline offering a common view of the activities across each of the client libraries

### New features

The new Azure.Messaging.EventGrid library includes several new features:
- Publishing and deserializing [CloudEvents](https://cloudevents.io/) using the Azure.Core `CloudEvent` type
- Methods that allow publishing a single event in addition to lists of events
- Ability to use a custom serializer for the Data of an event
- Ability to publish events with a custom schema
- Generate a shared access signature token using the `EventGridSasBuilder`

## Important changes

### Package names and namespaces

Package names and the namespace root for the modern Azure client libraries for .NET have changed. Each will follow the pattern `Azure.[Area].[Service]` where the legacy clients followed the pattern `Microsoft.Azure.[Service]`. This provides a quick and accessible means to help understand, at a glance, whether you are using the modern or legacy clients.

In the case of Event Grid, the modern client libraries have packages and namespaces that begin with Azure.Messaging.EventGrid and were released beginning with version 4. The legacy client libraries have packages and namespaces that begin with Microsoft.Azure.EventGrid and a version of 3.x.x or below.

### Client naming and constructors

In `Microsoft.Azure.EventGrid`, the `EventGridClient` was instantiated by passing the `TopicCredentials` into the constructor:
```C#
string topicEndpoint = "https://<topic-name>.<region>-1.eventgrid.azure.net/api/events";
string topicKey = "<topic-key>";

TopicCredentials topicCredentials = new TopicCredentials(topicKey);
EventGridClient client = new EventGridClient(topicCredentials);
```

In the `Azure.Messaging.EventGrid` library, the client used to interact with the service was renamed as the `EventGridPublisherClient` to highlight the fact that the client is only used to publish events and does not consume events from the service. The constructor takes the topic endpoint in addition to a credential parameter since a single client will only ever be able to publish to a single topic.
```C# Snippet:CreateClientWithOptions
EventGridPublisherClient client = new EventGridPublisherClient(
    new Uri(topicEndpoint),
    new AzureKeyCredential(topicAccessKey));
```

### Publishing events to a topic

In the `Microsoft.Azure.EventGrid` library, events were published as shown:
```C#
string topicEndpoint = "https://<topic-name>.<region>-1.eventgrid.azure.net/api/events";
string topicHostname = new Uri(topicEndpoint).Host;

List<EventGridEvent> eventsList = new List<EventGridEvent>();
for (int i = 0; i < 1; i++)
{
    eventsList.Add(new EventGridEvent()
    {
        Id = Guid.NewGuid().ToString(),
        EventType = "Contoso.Items.ItemReceivedEvent",
        Data = new ContosoItemReceivedEventData()
        {
            ItemUri = "ContosoSuperItemUri"
        },

        EventTime = DateTime.Now,
        Subject = "Door1",
        DataVersion = "2.0"
    });
}

await client.PublishEventsAsync(topicHostname, eventsList);
```

In `Azure.Messaging.EventGrid`, when publishing events it is no longer necessary to include the topic host name. Instead, this is passed as part of the `Uri` that is provided to the `EventGridPublisherClient` constructor. The `EventGridEvent` type now has a constructor that includes parameters for all required fields of the event grid schema:
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
### Deserializing events and data

In `Microsoft.Azure.EventGrid`, there was the `EventGridSubscriber` type that was used to deserialize events:
```C#
string requestContent = await req.Content.ReadAsStringAsync();

EventGridSubscriber eventGridSubscriber = new EventGridSubscriber();

// Optionally add one or more custom event type mappings
eventGridSubscriber.AddOrUpdateCustomEventMapping("Contoso.Items.ItemReceived", typeof(ContosoItemReceivedEventData));

EventGridEvent[] events = eventGridSubscriber.DeserializeEventGridEvents(requestContent);            
 
foreach (EventGridEvent receivedEvent in events)
{
    if (receivedEvent.Data is SubscriptionValidationEventData)
    {
        SubscriptionValidationEventData eventData = (SubscriptionValidationEventData)receivedEvent.Data;
        log.Info($"Got SubscriptionValidation event data, validationCode: {eventData.ValidationCode},  validationUrl: {eventData.ValidationUrl}, topic: {eventGridEvent.Topic}");
        // Handle subscription validation
    }
    else if (receivedEvent.Data is StorageBlobCreatedEventData)
    {
        StorageBlobCreatedEventData eventData = (StorageBlobCreatedEventData)receivedEvent.Data;
        log.Info($"Got BlobCreated event data, blob URI {eventData.Url}");
        // Handle StorageBlobCreatedEventData
    }
    else if (receivedEvent.Data is ContosoItemReceivedEventData)
    {
        ContosoItemReceivedEventData eventData = (ContosoItemReceivedEventData)receivedEvent.Data;
    }
}
```

In the `Azure.Messaging.EventGrid` library, there is no longer a separate type to deserialize events. Instead, you can use static factory methods on `EventGridEvent` to parse into an array of `EventGridEvents`.
```C# Snippet:EGEventParseJson
// Parse the JSON payload into a list of events
EventGridEvent[] egEvents = EventGridEvent.ParseMany(BinaryData.FromStream(httpContent));
```

You can then iterate through your events and deserialize the data.
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

## Additional samples

More examples can be found at:
- [Event Grid samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventgrid/Azure.Messaging.EventGrid/samples)
