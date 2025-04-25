# Azure WebJobs EventGrid client library for .NET

This extension provides functionality for receiving Event Grid webhook calls in Azure Functions, allowing you to easily write functions that respond to any event published to Event Grid.

## Getting started

### Install the package

Install the Event Grid extension with [NuGet][nuget]:

```dotnetcli
dotnet add package Microsoft.Azure.WebJobs.Extensions.EventGrid
```

### Prerequisites

You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/) and an Azure resource group with a custom Event Grid topic or domain. Follow this [step-by-step tutorial](https://learn.microsoft.com/azure/event-grid/custom-event-quickstart-portal) to register the Event Grid resource provider and create Event Grid topics using the [Azure portal](https://portal.azure.com/). There is a [similar tutorial](https://learn.microsoft.com/azure/event-grid/custom-event-quickstart) using [Azure CLI](https://learn.microsoft.com/cli/azure).

### Authenticate the Client

In order for the extension publish events, you will need the `endpoint` of the Event Grid topic and a `credential`, which can be created using the topic's access key.

You can find the endpoint for your Event Grid topic either in the [Azure Portal](https://portal.azure.com/) or by using the [Azure CLI](https://learn.microsoft.com/cli/azure) snippet below.

```bash
az eventgrid topic show --name <your-resource-name> --resource-group <your-resource-group-name> --query "endpoint"
```

The access key can also be found through the [portal](https://learn.microsoft.com/azure/event-grid/get-access-keys), or by using the Azure CLI snippet below:
```bash
az eventgrid topic key list --name <your-resource-name> --resource-group <your-resource-group-name> --query "key1"
```

## Key concepts

### Using Event Grid output binding

Please follow the [binding tutorial](https://learn.microsoft.com/azure/azure-functions/functions-bindings-event-grid-trigger?tabs) to learn about using this extension for publishing EventGrid events.

### Using Event Grid trigger

Please follow the [tutorial](https://learn.microsoft.com/azure/azure-functions/functions-bindings-event-grid-trigger?tabs=csharp) to learn about triggering an Azure Function when an event is published.

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

It is also possible to use Azure Identity with the output binding. To do so, set the `Connection` property to the name of your app setting that contains your Event Grid Topic endpoint along with a set of optional Identity information that is described in detail [here](https://learn.microsoft.com/azure/azure-functions/functions-reference?tabs=blob#configure-an-identity-based-connection). When setting the `Connection` property, the `TopicEndpointUri` and `TopicKeySetting` properties should NOT be set.

```C# Snippet:CloudEventBindingFunctionWithIdentity
public static class CloudEventOutputBindingWithIdentityFunction
{
    [FunctionName("CloudEventOutputBindingWithIdentityFunction")]
    public static async Task<IActionResult> RunAsync(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
        [EventGrid(Connection = "MyConnection")] IAsyncCollector<CloudEvent> eventCollector)
    {
        CloudEvent e = new CloudEvent("IncomingRequest", "IncomingRequest", await req.ReadAsStringAsync());
        await eventCollector.AddAsync(e);
        return new OkResult();
    }
}
```

For local development, use the `local.settings.json` file to store the connection information:
```json
{
  "Values": {
    "myConnection__topicEndpointUri": "{topicEndpointUri}"
  }
}
```

When deployed, use the [application settings](https://learn.microsoft.com/azure/azure-functions/functions-how-to-use-azure-function-app-settings) to store this information.

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

It is also possible to bind to an array of events. This is useful if you have [batching enabled](https://learn.microsoft.com/azure/event-grid/delivery-and-retry#output-batching) for your Event Grid Subscription.

```C# Snippet:EventGridEventBatchTriggerFunction
public static class EventGridEventBatchTriggerFunction
{
    [FunctionName("EventGridEventBatchTriggerFunction")]
    public static void Run(
        ILogger logger,
        [EventGridTrigger] EventGridEvent[] events)
    {
        foreach (EventGridEvent eventGridEvent in events)
        {
            logger.LogInformation("Event received {type} {subject}", eventGridEvent.EventType, eventGridEvent.Subject);
        }
    }
}
```

Similarly, for subscriptions configured with the CloudEvent schema:

```C# Snippet:CloudEventBatchTriggerFunction
public static class CloudEventBatchTriggerFunction
{
    [FunctionName("CloudEventBatchTriggerFunction")]
    public static void Run(
        ILogger logger,
        [EventGridTrigger] CloudEvent[] events)
    {
        foreach (CloudEvent cloudEvent in events)
        {
            logger.LogInformation("Event received {type} {subject}", cloudEvent.Type, cloudEvent.Subject);
        }
    }
}
```

## Troubleshooting

Please refer to [Monitor Azure Functions](https://learn.microsoft.com/azure/azure-functions/functions-monitoring) for troubleshooting guidance.

## Next steps

Read the [introduction to Azure Function](https://learn.microsoft.com/azure/azure-functions/functions-overview) or [creating an Azure Function guide](https://learn.microsoft.com/azure/azure-functions/functions-create-first-azure-function).

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

<!-- LINKS -->
[source]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/search/Microsoft.Azure.WebJobs.Extensions.EventGrid/src
[package]: https://www.nuget.org/packages/Microsoft.Azure.WebJobs.Extensions.EventGrid/
[docs]: https://learn.microsoft.com/dotnet/api/Microsoft.Azure.WebJobs.Extensions.EventGrid
[nuget]: https://www.nuget.org/

[contrib]: https://github.com/Azure/azure-sdk-for-net/tree/main/CONTRIBUTING.md
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
