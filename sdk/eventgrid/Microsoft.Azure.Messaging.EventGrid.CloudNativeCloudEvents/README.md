# CloudNative CloudEvent support for Azure.Messaging.EventGrid library for .NET

This library can be used to enable publishing CloudNative CloudEvents using the Azure Event Grid library.

## Getting started

### Install the package

Install the client library from [NuGet](https://www.nuget.org/):

```PowerShell
dotnet add package Microsoft.Azure.Messaging.EventGrid.CloudNativeCloudEvents --prerelease
```

### Prerequisites

You must have an [Azure subscription](https://azure.microsoft.com/free/) and an Azure resource group with a custom Event Grid topic or domain. Follow this [step-by-step tutorial](https://docs.microsoft.com/azure/event-grid/custom-event-quickstart-portal) to register the Event Grid resource provider and create Event Grid topics using the [Azure portal](https://portal.azure.com/). There is a [similar tutorial](https://docs.microsoft.com/azure/event-grid/custom-event-quickstart) using [Azure CLI](https://docs.microsoft.com/cli/azure).

### Authenticate the client

In order for the client library to interact with a topic or domain, you will need the `endpoint` of the Event Grid topic and a `credential`, which can be created using the topic's access key.

You can find the endpoint for your Event Grid topic either in the [Azure Portal](https://portal.azure.com/) or by using the [Azure CLI](https://docs.microsoft.com/cli/azure) snippet below.

```bash
az eventgrid topic show --name <your-resource-name> --resource-group <your-resource-group-name> --query "endpoint"
```

The access key can also be found through the [portal](https://docs.microsoft.com/azure/event-grid/get-access-keys), or by using the Azure CLI snippet below:
```bash
az eventgrid topic key list --name <your-resource-name> --resource-group <your-resource-group-name> --query "key1"
```

#### Creating and Authenticating `EventGridPublisherClient`

Once you have your access key and topic endpoint, you can create the publisher client as follows:
```C#
EventGridPublisherClient client = new EventGridPublisherClient(
    new Uri("<endpoint>"),
    new AzureKeyCredential("<access-key>"));
```

## Key concepts

For information about general Event Grid concepts: [Concepts in Azure Event Grid](https://docs.microsoft.com/azure/event-grid/concepts).

For detailed information about the Event Grid client library concepts: [Event Grid Client Library](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventgrid/Azure.Messaging.EventGrid#key-concepts)

## Examples

```C# Snippet:CloudNativePublish
EventGridPublisherClient client = new EventGridPublisherClient(
        new Uri(TestEnvironment.CloudEventTopicHost),
        new AzureKeyCredential(TestEnvironment.CloudEventTopicKey));

var cloudEvent =
    new CloudEvent 
    {
        Type = "record",
        Source = new Uri("http://www.contoso.com"),
        Data = "data"
    };
await client.SendCloudEventAsync(cloudEvent);
```

## Troubleshooting

For troubleshooting information, see the [Event Grid Client Library documentation](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventgrid/Azure.Messaging.EventGrid#troubleshooting).

## Next steps

View more [samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/eventgrid/Microsoft.Azure.Messaging.EventGrid.CloudNativeCloudEvents/tests/Samples) here for common usages of the library.

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][code_of_conduct_faq] or contact opencode@microsoft.com with any additional questions or comments.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Feventgrid%2FMicrosoft.Azure.Messaging.EventGrid.CloudNativeCloudEvents%2FREADME.png)

[code_of_conduct]: https://opensource.microsoft.com/codeofconduct
[code_of_conduct_faq]: https://opensource.microsoft.com/codeofconduct/faq/
