# Azure Event Grid libraries for .NET

Azure Event Grid allows you to build applications with event-based architectures. The Event Grid service fully manages all routing of events from any source, to any destination, for any application. Azure service events and custom events can be published directly to the service, where the events can then be filtered and sent to various recipients, such as built-in handlers or custom webhooks. To learn more about Azure Event Grid: [What is Event Grid?](https://learn.microsoft.com/azure/event-grid/overview)

## Libraries for data access

The current generation of the Azure Event Grid client library uses the package name `Azure.Messaging.EventGrid`.  Microsoft recommends using `Azure.Messaging.EventGrid` for new applications.  If you are unable to upgrade existing applications, then Microsoft recommends using version 3.2 or higher of the previous package, `Microsoft.Azure.EventGrid`.

### `Azure.Messaging.EventGrid`

This package is the current generation client library and is of the Azure SDK for .NET. The source code is available on [GitHub](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventgrid/Azure.Messaging.EventGrid).

Use the following packages to publish and consume events from Event Grid:

| Nuget Package | Reference | Samples |
|--------------------------------------|---------------------------------------------------------------|-------------------------------------------------------------------------------|
| [Azure.Messaging.EventGrid](https://www.nuget.org/packages/Azure.Messaging.EventGrid)  |  [API Reference for Azure.Messaging.EventGrid](https://learn.microsoft.com/dotnet/api/azure.messaging.eventgrid?view=azure-dotnet)  |  [Samples for Azure.Messaging.EventGrid](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventgrid/Azure.Messaging.EventGrid/samples) |

### `Microsoft.Azure.EventGrid`

Use the following legacy packages to publish and consume events from Event Grid:

| Nuget Package | Reference | Samples |
|--------------------------------------|---------------------------------------------------------------|-------------------------------------------------------------------------------|
| [Microsoft.Azure.EventGrid](https://www.nuget.org/packages/Microsoft.Azure.EventGrid)  |  [API Reference for Microsoft.Azure.EventGrid](https://learn.microsoft.com/dotnet/api/microsoft.azure.eventgrid?view=azure-dotnet)  |  [Samples for Azure.Messaging.EventGrid](https://github.com/Azure-Samples/event-grid-dotnet-publish-consume-events/tree/master/)  |

## Libraries for resource management

Use the following library to work with the Azure Event Grid resource provider:

| Nuget Package | Reference |
|--------------------------------------|---------------------------------------------------------------|
| [Azure.ResourceManager.EventGrid](https://www.nuget.org/packages/Azure.ResourceManager.EventGrid)  | [API Reference for Azure.ResourceManager.EventGrid](https://learn.microsoft.com/dotnet/api/azure.resourcemanager.eventgrid?view=azure-dotnet)  |
