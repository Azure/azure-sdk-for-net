# Azure Event Hubs libraries for .NET

Azure Event Hubs is a highly scalable publish-subscribe service that can ingest millions of events per second and stream them to multiple consumers. This lets you process and analyze the massive amounts of data produced by your connected devices and applications. Once Event Hubs has collected the data, you can retrieve, transform, and store it by using any real-time analytics provider or with batching/storage adapters.  If you would like to know more about Azure Event Hubs, you may wish to review: [What is Event Hubs](https://docs.microsoft.com/azure/event-hubs/event-hubs-about).

## Libraries for data access

The current generation of the Azure Event Hubs client library uses versions 5.0.1 and above.  Microsoft recommends using version 5.2 or higher for new applications.  If you are unable to existing applications to version 5.x, then Microsoft recommends using version 4.1 or higher.

### Version 5.x

The version 5.x client libraries are part of the Azure SDK for .NET. The source code for the Azure Event Hubs client libraries is available on [GitHub](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/eventhub).

Use the following packages to publish and consume events from Event Hubs:

| Nuget Package | Reference | Samples |
|--------------------------------------|---------------------------------------------------------------|-------------------------------------------------------------------------------|
| [Azure.Messaging.EventHubs](https://www.nuget.org/packages/Azure.Messaging.EventHubs)  |  [API Reference for Azure.Messaging.EventHubs](https://docs.microsoft.com/dotnet/api/azure.messaging.eventhubs?view=azure-dotnet)  |  [Samples for Azure.Messaging.EventHubs](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/eventhub/Azure.Messaging.EventHubs/samples)  |
| [Azure.Messaging.EventHubs.Processor](https://www.nuget.org/packages/Azure.Messaging.EventHubs.Processor)  |  [API Reference for Azure.Messaging.EventHubs.Processor](https://docs.microsoft.com/dotnet/api/azure.messaging.eventhubs?view=azure-dotnet)  |  [Samples for Azure.Messaging.EventHubs.Processor](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/eventhub/Azure.Messaging.EventHubs.Processor/samples)  |

### Version 4.x

The source code for version 4.x of the Azure Event Hubs client libraries is available on [GitHub](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/eventhub).

Use the following legacy packages to publish and consume events from Event Hubs:

| Nuget Package | Reference | Samples |
|--------------------------------------|---------------------------------------------------------------|-------------------------------------------------------------------------------|
| [Microsoft.Azure.EventHubs](https://www.nuget.org/packages/Microsoft.Azure.EventHubs)  |  [API Reference for Microsoft.Azure.EventHubs](https://docs.microsoft.com/dotnet/api/overview/azure/eventhubs/v4?view=azure-dotnet)  |  [Samples for Azure.Messaging.EventHubs](https://github.com/Azure/azure-event-hubs/tree/master/samples/DotNet/)  |
| [Microsoft.Azure.EventHubs.Processor](https://www.nuget.org/packages/Microsoft.Azure.EventHubs.Processor)  |  [API Reference for Microsoft.Azure.EventHubs.Processor](https://docs.microsoft.com/dotnet/api/microsoft.azure.eventhubs.processor?view=azure-dotnet)  |  [Samples for Azure.Messaging.EventHubs.Processor](https://github.com/Azure/azure-event-hubs/tree/master/samples/DotNet/)  |

## Libraries for resource management

Use the following library to work with the Azure Event Hubs resource provider:

| Nuget Package | Reference |
|--------------------------------------|---------------------------------------------------------------|
| [Azure.ResourceManager.EventHubs](https://www.nuget.org/packages/Azure.ResourceManager.EventHubs)  | [API Reference for Azure.ResourceManager.EventHubs](https://docs.microsoft.com/dotnet/api/overview/azure/eventhubs/management?view=azure-dotnet)  |