# Publishing Events to an Event Grid Topic

This sample demonstrates how to publish both Event Grid and CloudEvent 1.0 schema events to the Event Grid service. You can publish events from your own application using the `EventGridPublisherClient`.

To begin, create separate custom Event Grid topics accepting events of the Event Grid and CloudEvent 1.0 schema. See the [Prerequisites](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/eventgrid/Azure.Messaging.EventGrid/#prerequisites) section of the README for more instructions on creating custom topics.

## Creating and Authenticating `EventGridPublisherClient`
Once you have your access key and topic endpoint, you can create the publisher client using the `AzureKeyCredential` class as follows:
```C# Snippet:CreateClient
EventGridPublisherClient client = new EventGridPublisherClient(
    new Uri(topicEndpoint),
    new AzureKeyCredential(topicAccessKey));
```

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

## Publishing Events to Azure Event Grid
### Using `EventGridEvent`
After creating the `EventGridPublisherClient` such that the custom topic is configured to accept events of the Event Grid schema, we can now create some events of the `EventGridEvent` type to publish to the topic.

Following that, invoke `SendEvents` or `SendEventsAsync` to publish the events to Azure Event Grid.

Note on `EventGridEvent`: each `EventGridEvent` has a set of required, non-nullable properties, including event data. `EventTime` and `Id` are also required properties that are set by default, but can also be manually set if needed.

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

### Using `CloudEvent`
The process for publishing events of the CloudEvent schema is very similar to that of Event Grid events. Once again, after creating the `EventGridPublisherClient` such that the custom topic is configured to accept events of the CloudEvent 1.0 schema, we can create events of the `CloudEvent` type.

Following that, invoke `SendEvents` or `SendEventsAsync` to publish the events to Azure Event Grid.

Note on `CloudEvent`: each `CloudEvent` has a set of required, non-nullable properties. However, `Data` is *not required*. `Time` and `SpecVersion` are required properties that are set by default, but can also be manually set if needed. `Time` is also set by default, but not required.

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
