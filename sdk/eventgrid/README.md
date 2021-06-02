# Azure Event Grid libraries for .NET

Azure Event Grid allows you to build applications with event-based architectures. The Event Grid service fully manages all routing of events from any source, to any destination, for any application. Azure service events and custom events can be published directly to the service, where the events can then be filtered and sent to various recipients, such as built-in handlers or custom webhooks. To learn more about Azure Event Grid: [What is Event Grid?](https://docs.microsoft.com/azure/event-grid/overview)

## Libraries for data access

The current generation of the Azure Event Grid client library uses the package name `Azure.Messaging.EventGrid`.  Microsoft recommends using `Azure.Messaging.EventGrid` for new applications.  If you are unable to upgrade existing applications, then Microsoft recommends using version 3.2 or higher of the previous package, `Microsoft.Azure.EventGrid`.

### `Azure.Messaging.EventGrid`

This package is the current generation client library and is of the Azure SDK for .NET. The source code is available on [GitHub](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/eventgrid/Azure.Messaging.EventGrid).

Use the following packages to publish and consume events from Event Grid:

| Nuget Package | Reference | Samples |
|--------------------------------------|---------------------------------------------------------------|-------------------------------------------------------------------------------|
| [Azure.Messaging.EventGrid](https://www.nuget.org/packages/Azure.Messaging.EventGrid)  |  [API Reference for Azure.Messaging.EventGrid](https://docs.microsoft.com/dotnet/api/azure.messaging.eventgrid?view=azure-dotnet)  |  [Samples for Azure.Messaging.EventGrid](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/eventgrid/Azure.Messaging.EventGrid/samples) |

### `Microsoft.Azure.EventGrid`

The source code for the previous generation client library, `Microsoft.Azure.EventGrid` is available on [GitHub](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/eventgrid/Microsoft.Azure.EventGrid).

Use the following legacy packages to publish and consume events from Event Grid:

| Nuget Package | Reference | Samples |
|--------------------------------------|---------------------------------------------------------------|-------------------------------------------------------------------------------|
| [Microsoft.Azure.EventGrid](https://www.nuget.org/packages/Microsoft.Azure.EventGrid)  |  [API Reference for Microsoft.Azure.EventGrid](https://docs.microsoft.com/dotnet/api/microsoft.azure.eventgrid?view=azure-dotnet)  |  [Samples for Azure.Messaging.EventGrid](https://github.com/Azure-Samples/event-grid-dotnet-publish-consume-events/tree/master/)  |

## Libraries for resource management

Use the following library to work with the Azure Event Grid resource provider:

| Nuget Package | Reference |
|--------------------------------------|---------------------------------------------------------------|
| [Microsoft.Azure.Management.EventGrid](https://www.nuget.org/packages/Microsoft.Azure.Management.EventGrid)  | [API Reference for Microsoft.Azure.Management.EventGrid](https://docs.microsoft.com/dotnet/api/overview/azure/eventgrid/management?view=azure-dotnet)  |