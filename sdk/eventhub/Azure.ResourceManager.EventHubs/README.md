# Microsoft Azure Event Hubs management client library for .NET

Microsoft Azure Elastic SAN is a cloud-native service that offers a scalable, cost-effective, high-performance, and comprehensive storage solution for a range of compute options. Get the same simplified management experience in the cloud as with your on-premises storage area network (SAN). Gain higher resiliency and minimize downtime with rapid provisioning.

This library supports managing Microsoft Azure Event resources.

This library follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

## Getting started 

### Install the package

Install the Microsoft Azure Event Hubs management library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.ResourceManager.EventHubs
```

### Prerequisites

* You must have an [Microsoft Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the Client

The default option to create an authenticated client is to use `DefaultAzureCredential`. Since all management APIs go through the same endpoint, in order to interact with resources, only one top-level `ArmClient` has to be created.

To authenticate to Azure and create an `ArmClient`, do the following code:

```C# Snippet:Managing_Namespaces_AuthClient_Usings
using Azure.Identity;
```
```C# Snippet:Managing_Namespaces_AuthClient
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
```

More documentation for the `Azure.Identity.DefaultAzureCredential` class can be found in [this document](https://learn.microsoft.com/dotnet/api/azure.identity.defaultazurecredential).

## Key concepts

Key concepts of the Azure .NET SDK can be found [here](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/README.md#key-concepts)

## Examples

### Create a namespace

Before creating a namespace, we need to have a resource group.

```C# Snippet:Managing_Namespaces_CreateResourceGroup
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
string rgName = "myRgName";
AzureLocation location = AzureLocation.WestUS2;
ArmOperation<ResourceGroupResource> operation = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(location));
ResourceGroupResource resourceGroup = operation.Value;
```

Then we can create a namespace inside this resource group.

```C# Snippet:Managing_Namespaces_CreateNamespace
string namespaceName = "myNamespace";
EventHubsNamespaceCollection namespaceCollection = resourceGroup.GetEventHubsNamespaces();
AzureLocation location = AzureLocation.EastUS2;
EventHubsNamespaceResource eventHubNamespace = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, new EventHubsNamespaceData(location))).Value;
```

### Get all namespaces in a resource group

```C# Snippet:Managing_Namespaces_ListNamespaces
EventHubsNamespaceCollection namespaceCollection = resourceGroup.GetEventHubsNamespaces();
await foreach (EventHubsNamespaceResource eventHubNamespace in namespaceCollection.GetAllAsync())
{
    Console.WriteLine(eventHubNamespace.Id.Name);
}
```

### Get a namespace

```C# Snippet:Managing_Namespaces_GetNamespace
EventHubsNamespaceCollection namespaceCollection = resourceGroup.GetEventHubsNamespaces();
EventHubsNamespaceResource eventHubNamespace = await namespaceCollection.GetAsync("myNamespace");
Console.WriteLine(eventHubNamespace.Id.Name);
```

### Delete a namespace
```C# Snippet:Managing_Namespaces_DeleteNamespace
EventHubsNamespaceCollection namespaceCollection = resourceGroup.GetEventHubsNamespaces();
EventHubsNamespaceResource eventHubNamespace = await namespaceCollection.GetAsync("myNamespace");
await eventHubNamespace.DeleteAsync(WaitUntil.Completed);
```

### Add a tag to the namespace

```C# Snippet:Managing_Namespaces_AddTag
EventHubsNamespaceCollection namespaceCollection = resourceGroup.GetEventHubsNamespaces();
EventHubsNamespaceResource eventHubNamespace = await namespaceCollection.GetAsync("myNamespace");
await eventHubNamespace.AddTagAsync("key","value");
```

For more detailed examples, take a look at [samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventhub/Azure.ResourceManager.EventHubs/samples) we have available.

## Troubleshooting

-   File an issue via [GitHub Issues](https://github.com/Azure/azure-sdk-for-net/issues).
-   Check [previous questions](https://stackoverflow.com/questions/tagged/azure+.net) or ask new ones on Stack Overflow using Azure and .NET tags.

## Next steps

### More sample code

- [Managing EventHubs](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/eventhub/Azure.ResourceManager.EventHubs/samples/Sample1_ManagingEventHubs.md)

### More Documentation

For more information on Microsoft Azure SDK, see [this website](https://azure.github.io/azure-sdk/).

## Contributing

For details on contributing to this repository, see the [contributing
guide][cg].

This project welcomes contributions and suggestions. Most contributions
require you to agree to a Contributor License Agreement (CLA) declaring
that you have the right to, and actually do, grant us the rights to use
your contribution. For details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine
whether you need to provide a CLA and decorate the PR appropriately
(for example, label, comment). Follow the instructions provided by the
bot. You'll only need to do this action once across all repositories
using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][coc]. For
more information, see the [Code of Conduct FAQ][coc_faq] or contact
<opencode@microsoft.com> with any other questions or comments.

<!-- LINKS -->
[cg]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/docs/CONTRIBUTING.md
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
