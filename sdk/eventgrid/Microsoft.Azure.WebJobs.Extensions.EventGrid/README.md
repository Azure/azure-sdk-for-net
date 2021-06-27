# Azure WebJobs EventGrid client library for .NET

This extension provides functionality for receiving Event Grid webhook calls in Azure Functions, allowing you to easily write functions that respond to any event published to Event Grid.

## Getting started

### Install the package

Install the Event Grid extension with [NuGet][nuget]:

```Powershell
dotnet add package Microsoft.Azure.WebJobs.Extensions.EventGrid
```

### Prerequisites

You must have an [Azure subscription](https://azure.microsoft.com/free/) and an Azure resource group with a custom Event Grid topic or domain. Follow this [step-by-step tutorial](https://docs.microsoft.com/azure/event-grid/custom-event-quickstart-portal) to register the Event Grid resource provider and create Event Grid topics using the [Azure portal](https://portal.azure.com/). There is a [similar tutorial](https://docs.microsoft.com/azure/event-grid/custom-event-quickstart) using [Azure CLI](https://docs.microsoft.com/cli/azure).

### Authenticate the Client

In order for the extension publish events, you will need the `endpoint` of the Event Grid topic and a `credential`, which can be created using the topic's access key.

You can find the endpoint for your Event Grid topic either in the [Azure Portal](https://portal.azure.com/) or by using the [Azure CLI](https://docs.microsoft.com/cli/azure) snippet below.

```bash
az eventgrid topic show --name <your-resource-name> --resource-group <your-resource-group-name> --query "endpoint"
```

The access key can also be found through the [portal](https://docs.microsoft.com/azure/event-grid/get-access-keys), or by using the Azure CLI snippet below:
```bash
az eventgrid topic key list --name <your-resource-name> --resource-group <your-resource-group-name> --query "key1"
```

## Key concepts

### Using Event Grid output binding

Please follow the [binding tutorial](https://docs.microsoft.com/azure/azure-functions/functions-bindings-event-grid-trigger?tabs) to learn about using this extension for publishing EventGrid events.

### Using Event Grid trigger

Please follow the [tutorial](https://docs.microsoft.com/azure/azure-functions/functions-bindings-event-grid-trigger?tabs=csharp) to learn about triggering an Azure Function when an event is published.

## Examples

### Functions that uses Event Grid output binding

If you are using the EventGrid schema for your topic, you can output EventGridEvents.

```C# Snippet:EventGridEventBindingFunction
public static class EventGridEventBindingFunction
{
    [FunctionName("EventGridEventBindingFunction")]
    public static async Task<IActionResult> RunAsync(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
        [EventGrid(TopicEndpointUri = "EventGridEndpoint", TopicKeySetting = "EventGridKey")] IAsyncCollector<EventGridEvent> eventCollector)
    {
        EventGridEvent e = new EventGridEvent(await req.ReadAsStringAsync(), "IncomingRequest", "IncomingRequest", "1.0.0");
        await eventCollector.AddAsync(e);
        return new OkResult();
    }
}
```

If you are using the CloudEvent schema for your topic, you can output CloudEvents.
```C# Snippet:CloudEventBindingFunction
public static class CloudEventBindingFunction
{
    [FunctionName("CloudEventBindingFunction")]
    public static async Task<IActionResult> RunAsync(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
        [EventGrid(TopicEndpointUri = "EventGridEndpoint", TopicKeySetting = "EventGridKey")] IAsyncCollector<CloudEvent> eventCollector)
    {
        CloudEvent e = new CloudEvent("IncomingRequest", "IncomingRequest", await req.ReadAsStringAsync());
        await eventCollector.AddAsync(e);
        return new OkResult();
    }
}
```

You can also output a string or JObject and the extension will attempt to parse into the correct strongly typed event.

### Functions that uses Event Grid trigger
You can also create a function that will be executed whenever an event is delivered to your topic. Depending on the schema you have selected for your Azure Function event subscription, you can bind to either `EventGridEvent` or `CloudEvent`:

```C# Snippet:EventGridEventTriggerFunction
public static class EventGridEventTriggerFunction
{
    [FunctionName("EventGridEventTriggerFunction")]
    public static void Run(
        ILogger logger,
        [EventGridTrigger] EventGridEvent e)
    {
        logger.LogInformation("Event received {type} {subject}", e.EventType, e.Subject);
    }
}
```

And if your subscription is configured with the CloudEvent schema:
```C# Snippet:CloudEventTriggerFunction
public static class CloudEventTriggerFunction
{
    [FunctionName("CloudEventTriggerFunction")]
    public static void Run(
        ILogger logger,
        [EventGridTrigger] CloudEvent e)
    {
        logger.LogInformation("Event received {type} {subject}", e.Type, e.Subject);
    }
}
```
Note that creating a subscription of type Azure Function with the CloudEvent schema is not yet supported. Instead, you can select an Endpoint Type of Web Hook and use your function URL as the endpoint. The function URL can be found by going to the Code + Test blade of your function, and clicking the Get function URL button.


## Troubleshooting

Please refer to [Monitor Azure Functions](https://docs.microsoft.com/azure/azure-functions/functions-monitoring) for troubleshooting guidance.

## Next steps

Read the [introduction to Azure Function](https://docs.microsoft.com/azure/azure-functions/functions-overview) or [creating an Azure Function guide](https://docs.microsoft.com/azure/azure-functions/functions-create-first-azure-function).

## Contributing

See our [CONTRIBUTING.md][contrib] for details on building,
testing, and contributing to this library.

This project welcomes contributions and suggestions.  Most contributions require
you to agree to a Contributor License Agreement (CLA) declaring that you have
the right to, and actually do, grant us the rights to use your contribution. For
details, visit [cla.microsoft.com][cla].

This project has adopted the [Microsoft Open Source Code of Conduct][coc].
For more information see the [Code of Conduct FAQ][coc_faq]
or contact [opencode@microsoft.com][coc_contact] with any
additional questions or comments.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fsearch%2FMicrosoft.Azure.WebJobs.Extensions.EventGrid%2FREADME.png)

<!-- LINKS -->
[source]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/search/Microsoft.Azure.WebJobs.Extensions.EventGrid/src
[package]: https://www.nuget.org/packages/Microsoft.Azure.WebJobs.Extensions.EventGrid/
[docs]: https://docs.microsoft.com/dotnet/api/Microsoft.Azure.WebJobs.Extensions.EventGrid
[nuget]: https://www.nuget.org/

[contrib]: https://github.com/Azure/azure-sdk-for-net/tree/main/CONTRIBUTING.md
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
