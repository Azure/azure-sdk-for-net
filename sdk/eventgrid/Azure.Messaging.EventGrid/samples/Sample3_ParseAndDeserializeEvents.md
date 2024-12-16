# Deserializing Events Delivered to Event Handlers

This sample will demonstrate how to deserialize events that have been delivered to event handlers. There are several different Azure services that act as [event handlers](https://learn.microsoft.com/azure/event-grid/event-handlers). Regardless of the event handler, however, events are always sent as UTF-8 encoded JSON.

Note: if using Webhooks for event delivery of the *Event Grid schema*, Event Grid requires you to prove ownership of your Webhook endpoint before it starts delivering events to that endpoint. At the time of event subscription creation, Event Grid sends a subscription validation event to your endpoint, as seen below. Learn more about completing the handshake here: [Webhook event delivery](https://learn.microsoft.com/azure/event-grid/webhook-event-delivery). For the *CloudEvents schema*, the service validates the connection using the HTTP options method. Learn more here: [CloudEvents validation](https://github.com/cloudevents/spec/blob/v1.0/http-webhook.md#4-abuse-protection).

Handling events will be different based on which schema the event was delivered as. However, the general pattern will remain the same:
- Parse events from JSON into individual events. Based on the event schema (Event Grid or CloudEvents 1.0), you can now access basic information about the event on the envelope (properties that are present for all events, like event time and type).
- Deserialize the event data. Given an `EventGridEvent` or `CloudEvent`, the user can attempt to access the event payload, or data, by deserializing to a specific type. You can supply a custom serializer at this point to correctly decode the data.

## Parse Events from JSON payload
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
### Deserializing event data
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
