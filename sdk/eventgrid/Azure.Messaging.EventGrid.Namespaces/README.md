# Azure Event Grid client library for .NET

Azure Event Grid allows you to easily build applications with event-based architectures. The Event Grid service fully manages all routing of events from any source, to any destination, for any application. Azure service events and custom events can be published directly to the service, where the events can then be filtered and sent to various recipients, such as built-in handlers or custom webhooks. To learn more about Azure Event Grid: [What is Event Grid?](https://learn.microsoft.com/azure/event-grid/overview)

Use the client library for Azure Event Grid to:
- Publish events to Event Grid topics using the Cloud Event schema
- Consume and settle events

  [Source code](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/eventgrid/Azure.Messaging.EventGrid.Namespaces/src) | [Package (NuGet)](https://www.nuget.org/packages) | [API reference documentation](https://learn.microsoft.com/dotnet/api/overview/azure/messaging.eventgrid-readme?view=azure-dotnet) | [Product documentation](https://learn.microsoft.com/azure/event-grid/pull-delivery-overview) | [Samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventgrid/Azure.Messaging.EventGrid.Namespaces/samples)

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/ ):

```dotnetcli
dotnet add package Azure.Messaging.EventGrid.Namespaces
```

### Prerequisites

You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/) and an Azure resource group with a custom Event Grid topic or domain. Follow this [step-by-step tutorial](https://learn.microsoft.com/azure/event-grid/custom-event-quickstart-portal) to register the Event Grid resource provider and create Event Grid topics using the [Azure portal](https://portal.azure.com/). There is a [similar tutorial](https://learn.microsoft.com/azure/event-grid/custom-event-quickstart) using [Azure CLI](https://learn.microsoft.com/cli/azure).

### Authenticate the client

In order for the client library to interact with a topic or domain, you will need the `endpoint` of the Event Grid topic and a `credential`, which can be created using the topic's access key.

You can find the endpoint for your Event Grid topic either in the [Azure Portal](https://portal.azure.com/) or by using the [Azure CLI](https://learn.microsoft.com/cli/azure) snippet below.

```bash
az eventgrid topic show --name <your-resource-name> --resource-group <your-resource-group-name> --query "endpoint"
```

The access key can also be found through the [portal](https://learn.microsoft.com/azure/event-grid/get-access-keys), or by using the Azure CLI snippet below:
```bash
az eventgrid topic key list --name <your-resource-name> --resource-group <your-resource-group-name> --query "key1"
```

#### Authenticate using Topic Access Key

Once you have your access key and topic endpoint, you can create the publisher client as follows:
```C# Snippet:CreateNamespaceClient
// Construct the client using an Endpoint for a namespace as well as the shared access key
var senderClient = new EventGridSenderClient(new Uri(namespaceTopicHost), topicName, new AzureKeyCredential(namespaceKey));
```

#### Authenticate using an Entra ID

Azure Event Grid provides integration with Entra ID for identity-based authentication of requests. With Entra ID, you can use role-based access control (RBAC) to grant access to your Azure Event Grid resources to users, groups, or applications. The [Azure Identity library](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity/README.md) provides easy Azure Active Directory support for authentication.

To send events to a topic or domain using Azure Active Directory, the authenticated identity should have the "EventGrid Data Sender" role assigned.

```C# Snippet:CreateNamespaceClientAAD
// Construct the sender client using an Endpoint for a namespace as well as the DefaultAzureCredential
var senderClient = new EventGridSenderClient(new Uri(namespaceTopicHost), topicName, new DefaultAzureCredential());
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
