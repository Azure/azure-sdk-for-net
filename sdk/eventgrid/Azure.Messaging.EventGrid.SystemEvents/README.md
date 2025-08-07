# Azure Event Grid System Events client library for .NET

Azure Event Grid allows you to build applications with event-based architectures. The Event Grid service fully manages all routing of events from any source to any destination, for any application. Azure service events and custom events can be published directly to the service, where the events can then be filtered and sent to various recipients, such as built-in handlers or custom webhooks. To learn more about Azure Event Grid: [What is Event Grid?](https://learn.microsoft.com/azure/event-grid/overview)

Use the client library for Azure Event Grid System Events to:
- Deserialize Event Grid system events into strongly typed models.

  [Source code](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/eventgrid/Azure.Messaging.EventGrid.SystemEvents/src) | [Package (NuGet)](https://www.nuget.org/packages/Azure.Messaging.EventGrid.SystemEvents/) | [API reference documentation](https://learn.microsoft.com/dotnet/api/overview/azure/messaging.eventgrid-readme?view=azure-dotnet) | [Product documentation](https://learn.microsoft.com/azure/event-grid/pull-delivery-overview)

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/ ):

```dotnetcli
dotnet add package Azure.Messaging.EventGrid.SystemEvents
```

### Prerequisites

You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/) and an Azure resource group with a custom Event Grid topic or domain. Follow this [step-by-step tutorial](https://learn.microsoft.com/azure/event-grid/custom-event-quickstart-portal) to register the Event Grid resource provider and create Event Grid topics using the [Azure portal](https://portal.azure.com/). There is a [similar tutorial](https://learn.microsoft.com/azure/event-grid/custom-event-quickstart) using [Azure CLI](https://learn.microsoft.com/cli/azure).

### Receiving and Deserializing Events

There are several different Azure services that act as [event handlers](https://learn.microsoft.com/azure/event-grid/event-handlers).

Note: if using Webhooks for event delivery of the *Event Grid schema*, Event Grid requires you to prove ownership of your Webhook endpoint before it starts delivering events to that endpoint. At the time of event subscription creation, Event Grid sends a subscription validation event to your endpoint, as seen below. Learn more about completing the handshake here: [Webhook event delivery](https://learn.microsoft.com/azure/event-grid/webhook-event-delivery). For the *CloudEvents schema*, the service validates the connection using the HTTP options method. Learn more here: [CloudEvents validation](https://github.com/cloudevents/spec/blob/v1.0/http-webhook.md#4-abuse-protection).

Once events are delivered to the event handler, we can deserialize the JSON payload into a list of events.

```C# Snippet:SystemEventsCloudEventParseJson
var bytes = await httpContent.ReadAsByteArrayAsync();
// Parse the JSON payload into a list of events
CloudEvent[] cloudEvents = CloudEvent.ParseMany(new BinaryData(bytes));
```
#### Deserializing event data

##### Deserializing using `ToObjectFromJson<T>()`:

From here, one can access the event data by deserializing to a specific type by calling `ToObjectFromJson<T>()` on the `Data` property. In order to deserialize to the correct type, the `Type` property helps distinguish between different events. Custom event data should be deserialized using the generic method `ToObjectFromJson<T>()`. There is also an extension method `ToObject<T>()` that accepts a custom `ObjectSerializer` to deserialize the event data.

```C# Snippet:SystemEventsDeserializePayloadUsingGenericGetData
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

##### Deserializing using `TryGetSystemEventData()`:

If expecting mostly system events, it may be cleaner to switch on `TryGetSystemEventData()` and use pattern matching to act on the individual events. If an event is not a system event, the method will return false and the out parameter will be null.

*As a caveat, if you are using a custom event type with an EventType value that later gets added as a system event by the service and SDK, the return value of `TryGetSystemEventData` would change from `false` to `true`. This could come up if you are pre-emptively creating your own custom events for events that are already being sent by the service, but have not yet been added to the SDK. In this case, it is better to use the generic `ToObjectFromJson<T>` method on the `Data` property so that your code flow doesn't change automatically after upgrading (of course, you may still want to modify your code to consume the newly released system event model as opposed to your custom model).*

```C# Snippet:SystemEventsDeserializePayloadUsingTryGetSystemEventData
foreach (CloudEvent cloudEvent in cloudEvents)
{
    // If the event is a system event, TryGetSystemEventData will return the deserialized system event
    if (cloudEvent.TryGetSystemEventData(out object systemEvent))
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
                Console.WriteLine(cloudEvent.Type);
                // we can get the raw Json for the event using Data
                Console.WriteLine(cloudEvent.Data.ToString());
                break;
        }
    }
    else
    {
        switch (cloudEvent.Type)
        {
            case "MyApp.Models.CustomEventType":
                TestPayload deserializedEventData = cloudEvent.Data.ToObjectFromJson<TestPayload>();
                Console.WriteLine(deserializedEventData.Name);
                break;
            // Handle any other custom event type
            default:
                Console.Write(cloudEvent.Type);
                Console.WriteLine(cloudEvent.Data.ToString());
                break;
        }
    }
}
```

## Key concepts

### Thread safety

We guarantee that all client instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This ensures that the recommendation of reusing client instances is always safe, even across threads.

### Additional concepts
<!-- CLIENT COMMON BAR -->
[Client options](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Accessing the response](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#accessing-http-response-details-using-responset) |
[Long-running operations](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#consuming-long-running-operations-using-operationt) |
[Handling failures](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md) |
[Mocking](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
<!-- CLIENT COMMON BAR -->

## Examples

You can familiarize yourself with different APIs using [Samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventgrid/Azure.Messaging.EventGrid.Namespaces/samples).

## Troubleshooting

Describe common errors and exceptions, how to "unpack" them if necessary, and include guidance for graceful handling and recovery.

Provide information to help developers avoid throttling or other service-enforced errors they might encounter. For example, provide guidance and examples for using retry or connection policies in the API.

If the package or a related package supports it, include tips for logging or enabling instrumentation to help them debug their code.

## Next steps

View more https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/eventgrid/Azure.Messaging.EventGrid.Namespaces/samples here for common usages of the Event Grid client library: [Event Grid Samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/eventgrid/Azure.Messaging.EventGrid.Namespaces/samples).

## Contributing

This project welcomes contributions and suggestions.
Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution.
For details, visit [Contributor License Agreements](https://opensource.microsoft.com/cla/).

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment).
Simply follow the instructions provided by the bot.
You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

<!-- LINKS -->
[style-guide-msft]: https://learn.microsoft.com/style-guide/capitalization
[style-guide-cloud]: https://aka.ms/azsdk/cloud-style-guide
