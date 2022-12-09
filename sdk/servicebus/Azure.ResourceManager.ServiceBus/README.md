# Azure Service Bus Management client library for .NET

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html) which provide a number of core capabilities that are shared amongst all Azure SDKs, including the intuitive Azure Identity library, an HTTP Pipeline with custom policies, error-handling, distributed tracing, and much more.

## Getting started 

### Install the package

Install the Azure Service Bus management library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.ResourceManager.ServiceBus
```

### Prerequisites
Set up a way to authenticate to Azure with Azure Identity.

Some options are:
- Through the [Azure CLI Login](https://docs.microsoft.com/cli/azure/authenticate-azure-cli).
- Via [Visual Studio](https://docs.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet#authenticating-via-visual-studio).
- Setting [Environment Variables](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/docs/AuthUsingEnvironmentVariables.md).

More information and different authentication approaches using Azure Identity can be found in [this document](https://docs.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).

### Authenticate the Client

The default option to create an authenticated client is to use `DefaultAzureCredential`. Since all management APIs go through the same endpoint, in order to interact with resources, only one top-level `ArmClient` has to be created.

To authenticate to Azure and create an `ArmClient`, do the following:

```C# Snippet:Managing_ServiceBus_AuthClient_Usings
using Azure.Identity;
```

```C# Snippet:Managing_ServiceBus_AuthClient
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
```

Additional documentation for the `Azure.Identity.DefaultAzureCredential` class can be found in [this document](https://docs.microsoft.com/dotnet/api/azure.identity.defaultazurecredential).

## Key concepts

Key concepts of the Azure .NET SDK can be found [here](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/README.md#key-concepts)


## Documentation

Documentation is available to help you learn how to use this package

- [Quickstart](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/dev/mgmt_quickstart.md)
- [API References](https://docs.microsoft.com/dotnet/api/?view=azure-dotnet)
- [Authentication](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md)

## Examples

### Create a namespace

Before creating a namespace, we need to have a resource group.

```C# Snippet:Managing_ServiceBusNamespaces_GetSubscription
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
```
```C# Snippet:Managing_ServiceBusNamespaces_CreateResourceGroup
string rgName = "myRgName";
AzureLocation location = AzureLocation.WestUS2;
ArmOperation<ResourceGroupResource> operation = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(location));
ResourceGroupResource resourceGroup = operation.Value;
```

Then we can create a namespace inside this resource group.

```C# Snippet:Managing_ServiceBusNamespaces_CreateNamespace
string namespaceName = "myNamespace";
ServiceBusNamespaceCollection namespaceCollection = resourceGroup.GetServiceBusNamespaces();
AzureLocation location = AzureLocation.EastUS2;
ServiceBusNamespaceResource serviceBusNamespace = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, new ServiceBusNamespaceData(location))).Value;
```

### Get all namespaces in a resource group

```C# Snippet:Managing_ServiceBusNamespaces_ListNamespaces
ServiceBusNamespaceCollection namespaceCollection = resourceGroup.GetServiceBusNamespaces();
await foreach (ServiceBusNamespaceResource serviceBusNamespace in namespaceCollection.GetAllAsync())
{
    Console.WriteLine(serviceBusNamespace.Id.Name);
}
```

### Get a namespace

```C# Snippet:Managing_ServiceBusNamespaces_GetNamespace
ServiceBusNamespaceCollection namespaceCollection = resourceGroup.GetServiceBusNamespaces();
ServiceBusNamespaceResource serviceBusNamespace = await namespaceCollection.GetAsync("myNamespace");
Console.WriteLine(serviceBusNamespace.Id.Name);
```

### Delete a namespace
```C# Snippet:Managing_ServiceBusNamespaces_DeleteNamespace
ServiceBusNamespaceCollection namespaceCollection = resourceGroup.GetServiceBusNamespaces();
ServiceBusNamespaceResource serviceBusNamespace = await namespaceCollection.GetAsync("myNamespace");
await serviceBusNamespace.DeleteAsync(WaitUntil.Completed);
```


For more detailed examples, take a look at [samples](https://github.com/yukun-dong/azure-sdk-for-net/tree/track2-servicebus/sdk/servicebus/Azure.ResourceManager.ServiceBus/samples) we have available.

## Troubleshooting

-   File an issue via [Github
    Issues](https://github.com/Azure/azure-sdk-for-net/issues)
-   Check [previous
    questions](https://stackoverflow.com/questions/tagged/azure+.net)
    or ask new ones on Stack Overflow using azure and .net tags.


## Next steps

For more information on Azure SDK, please refer to [this website](https://azure.github.io/azure-sdk/)

## Contributing

For details on contributing to this repository, see the [contributing
guide][cg].

This project welcomes contributions and suggestions. Most contributions
require you to agree to a Contributor License Agreement (CLA) declaring
that you have the right to, and actually do, grant us the rights to use
your contribution. For details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine
whether you need to provide a CLA and decorate the PR appropriately
(e.g., label, comment). Simply follow the instructions provided by the
bot. You will only need to do this once across all repositories using
our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][coc]. For
more information see the [Code of Conduct FAQ][coc_faq] or contact
<opencode@microsoft.com> with any additional questions or comments.

<!-- LINKS -->
[cg]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/docs/CONTRIBUTING.md
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/