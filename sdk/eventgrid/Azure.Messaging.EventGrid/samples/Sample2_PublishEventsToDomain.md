# Publishing Events to an Event Grid Domain

This sample demonstrates how to publish Event Grid schema events to an Event Grid domain. You can publish events from your own application using the `EventGridPublisherClient`.

## Create an Event Grid Domain

To begin, create an Event Grid domain that accepts events of the Event Grid schema. An *event domain* is a management tool for large numbers of Event Grid topics related to the same application. You can think of it as a meta-topic that can have thousands of individual topics.

See the this [step-by-step tutorial](https://learn.microsoft.com/azure/event-grid/custom-event-quickstart-portal#create-a-custom-topic) for instructions on creating custom topics using Azure Portal; however, instead of searching for "Event Grid Topics", search for "Event Grid Domains". When you create an event domain, you're given a publishing endpoint and access key similar to if you had created a topic in Event Grid.

## Create and Authenticate `EventGridPublisherClient`

If you have not created an `EventGridPublisherClient`, refer to the sample [Publish Events To Topic](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/eventgrid/Azure.Messaging.EventGrid/samples/Sample1_PublishEventsToTopic.md) for more information on creating and authenticating the client. An example is shown below:
```C# Snippet:CreateDomainClient
// Create the publisher client using an AzureKeyCredential
// Domain should be configured to accept events of the Event Grid schema
EventGridPublisherClient client = new EventGridPublisherClient(
    new Uri(domainEndpoint),
    new AzureKeyCredential(domainAccessKey));
```

## Publish Events to Azure Event Grid
To publish events to any topic in an Event Domain, push the events to the domain's endpoint the same way you would for a custom topic. The only difference is that you must specify the topic you'd like the event to be delivered to. Invoke `SendEvents` or `SendEventsAsync` to publish events to the service.

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
