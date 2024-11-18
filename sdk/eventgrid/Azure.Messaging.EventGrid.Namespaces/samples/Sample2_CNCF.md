# Using the Cloud Native CloudEvent type

It is possible to publish and receive the CloudNative CloudEvent type found in the [CloudNative.CloudEvents library](https://www.nuget.org/packages/CloudNative.CloudEvents) using the Azure Event Grid Namespaces client library.
First we create a `CloudEvent` object and publish it to the namespace topic using the `EventGridSenderClient`.

```C# Snippet:SendCNCFEvent
var evt = new CloudNative.CloudEvents.CloudEvent
{
    Source = new Uri("http://localHost"),
    Type = "type",
    Data = new TestModel { Name = "Bob", Age = 18 },
    Id = Recording.Random.NewGuid().ToString()
};
var jsonFormatter = new JsonEventFormatter();
var sender = new EventGridSenderClient(new Uri(namespaceTopicHost), topicName, new AzureKeyCredential(namespaceKey));
await sender.SendEventAsync(RequestContent.Create(jsonFormatter.EncodeStructuredModeMessage(evt, out _)));
```

Next, we receive the events using the `EventGridReceiverClient`.

```C# Snippet:ReceiveCNCFEvent
var receiver = new EventGridReceiverClient(new Uri(namespaceTopicHost), topicName, subscriptionName, new AzureKeyCredential(namespaceKey));
Response response = await receiver.ReceiveAsync(maxEvents: 1, maxWaitTime: TimeSpan.FromSeconds(10), new RequestContext());

var eventResponse = response.Content.ToDynamicFromJson(JsonPropertyNames.CamelCase).Value[0];
var receivedCloudEvent = jsonFormatter.DecodeStructuredModeMessage(
    Encoding.UTF8.GetBytes(eventResponse.Event.ToString()),
    new ContentType("application/cloudevents+json"),
    null);
```

Finally, we acknowledge the event using the lock token.

```C# Snippet:AcknowledgeCNCFEvent
AcknowledgeResult acknowledgeResult = await receiver.AcknowledgeAsync(new string[] { eventResponse.BrokerProperties.LockToken.ToString() });
```
