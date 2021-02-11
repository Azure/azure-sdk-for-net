# Publishing Events to an Event Grid Topic

This sample demonstrates how to publish both Event Grid and CloudEvent 1.0 schema events to the Event Grid service. You can publish events from your own application using the `EventGridPublisherClient`.

To begin, create separate custom Event Grid topics accepting events of the Event Grid and CloudEvent 1.0 schema. See the [Prerequisites](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventgrid/Azure.Messaging.EventGrid/#prerequisites) section of the README for more instructions on creating custom topics.

## Creating and Authenticating `EventGridPublisherClient`
Once you have your access key and topic endpoint, you can create the publisher client using the `AzureKeyCredential` class as follows:
```C# Snippet:CreateClient
EventGridPublisherClient client = new EventGridPublisherClient(
    new Uri(topicEndpoint),
    new AzureKeyCredential(topicAccessKey));
```
`EventGridPublisherClient` also accepts a set of configuring options through `EventGridPublisherClientOptions`. For example, specifying a custom serializer used to serialize the event data to JSON:

```C# Snippet:CreateClientWithOptions
EventGridPublisherClientOptions clientOptions = new EventGridPublisherClientOptions()
{
    Serializer = myCustomDataSerializer
};

EventGridPublisherClient client = new EventGridPublisherClient(
    new Uri(topicEndpoint),
    new AzureKeyCredential(topicAccessKey),
    clientOptions);
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
// Add EventGridEvents to a list to publish to the topic
List<EventGridEvent> eventsList = new List<EventGridEvent>
{
    new EventGridEvent(
        "ExampleEventSubject",
        "Example.EventType",
        "1.0",
        "This is the event data")
};

// Send the events
await client.SendEventsAsync(eventsList);
```

### Using `CloudEvent`
The process for publishing events of the CloudEvent schema is very similar to that of Event Grid events. Once again, after creating the `EventGridPublisherClient` such that the custom topic is configured to accept events of the CloudEvent 1.0 schema, we can create events of the `CloudEvent` type.

Following that, invoke `SendEvents` or `SendEventsAsync` to publish the events to Azure Event Grid.

Note on `CloudEvent`: each `CloudEvent` has a set of required, non-nullable properties. However, `Data` is *not required*. `Time` and `SpecVersion` are required properties that are set by default, but can also be manually set if needed. `Time` is also set by default, but not required.

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
        Encoding.UTF8.GetBytes("This is binary data"),
        "example/binary")};

// Send the events
await client.SendEventsAsync(eventsList);
```

## Source

To view the full example source, see:
- [Sample1_SendEventsToTopicAndDomain.cs](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventgrid/Azure.Messaging.EventGrid/tests/Samples/Sample1_SendEventsToTopicAndDomain.cs)
