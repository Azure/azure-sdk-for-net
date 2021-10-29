# Azure Event Hubs Management client library for .NET

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html) which provide a number of core capabilities that are shared amongst all Azure SDKs, including the intuitive Azure Identity library, an HTTP Pipeline with custom policies, error-handling, distributed tracing, and much more.

## Getting started 

### Install the package

Install the Azure EventHubs management library for .NET with [NuGet](https://www.nuget.org/):

```PowerShell
Install-Package Azure.ResourceManager.EventHubs -Version 1.0.0-beta.1
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

```C# Snippet:Managing_Namespaces_AuthClient
using Azure.Identity;

ArmClient armClient = new ArmClient(new DefaultAzureCredential());
```

Additional documentation for the `Azure.Identity.DefaultAzureCredential` class can be found in [this document](https://docs.microsoft.com/dotnet/api/azure.identity.defaultazurecredential).

## Key concepts

Key concepts of the Azure .NET SDK can be found [here](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/README.md#key-concepts)

## Examples

### Create a namespace

Before creating a namespace, we need to have a resource group.

```C# Snippet:Managing_Namespaces_CreateResourceGroup
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
string rgName = "myRgName";
Location location = Location.WestUS2;
ResourceGroupCreateOrUpdateOperation operation = await subscription.GetResourceGroups().CreateOrUpdateAsync(rgName, new ResourceGroupData(location));
ResourceGroup resourceGroup = operation.Value;
```

Then we can create a namespace inside this resource group.

```C# Snippet:Managing_Namespaces_CreateNamespace
string namespaceName = "myNamespace";
EventHubNamespaceCollection namespaceCollection = resourceGroup.GetEventHubNamespaces();
Location location = Location.EastUS2;
EventHubNamespace eventHubNamespace = (await namespaceCollection.CreateOrUpdateAsync(namespaceName, new EventHubNamespaceData(location))).Value;
```

### Get all namespaces in a resource group

```C# Snippet:Managing_Namespaces_ListNamespaces
EventHubNamespaceCollection namespaceCollection = resourceGroup.GetEventHubNamespaces();
await foreach (EventHubNamespace eventHubNamespace in namespaceCollection.GetAllAsync())
{
    Console.WriteLine(eventHubNamespace.Id.Name);
}
```

### Get a namespace

```C# Snippet:Managing_Namespaces_GetNamespace
EventHubNamespaceCollection namespaceCollection = resourceGroup.GetEventHubNamespaces();
EventHubNamespace eventHubNamespace = await namespaceCollection.GetAsync("myNamespace");
Console.WriteLine(eventHubNamespace.Id.Name);
```

### Try to get a namespace if it exists


```C# Snippet:Managing_Namespaces_GetNamespaceIfExists
EventHubNamespaceCollection namespaceCollection = resourceGroup.GetEventHubNamespaces();
EventHubNamespace eventHubNamespace = await namespaceCollection.GetIfExistsAsync("foo");
if (eventHubNamespace != null)
{
    Console.WriteLine("namespace 'foo' exists");
}
if (await namespaceCollection.CheckIfExistsAsync("bar"))
{
    Console.WriteLine("namespace 'bar' exists");
}
```

### Delete a namespace
```C# Snippet:Managing_Namespaces_DeleteNamespace
EventHubNamespaceCollection namespaceCollection = resourceGroup.GetEventHubNamespaces();
EventHubNamespace eventHubNamespace = await namespaceCollection.GetAsync("myNamespace");
await eventHubNamespace.DeleteAsync();
```

### Add a tag to the namespace

```C# Snippet:Managing_Namespaces_AddTag
EventHubNamespaceCollection namespaceCollection = resourceGroup.GetEventHubNamespaces();
EventHubNamespace eventHubNamespace = await namespaceCollection.GetAsync("myNamespace");
await eventHubNamespace.AddTagAsync("key","value");
```

For more detailed examples, take a look at [samples](https://github.com/yukun-dong/azure-sdk-for-net/tree/eventhub-2018-01-preview/sdk/eventhub/Azure.ResourceManager.EventHubs/samples) we have available.

## Troubleshooting

-   If you find a bug or have a suggestion, file an issue via [GitHub issues](https://github.com/Azure/azure-sdk-for-net/issues) and make sure you add the "Preview" label to the issue.
-   If you need help, check [previous
    questions](https://stackoverflow.com/questions/tagged/azure+.net)
    or ask new ones on StackOverflow using azure and .NET tags.
-   If having trouble with authentication, go to [DefaultAzureCredential documentation](https://docs.microsoft.com/dotnet/api/azure.identity.defaultazurecredential?view=azure-dotnet)


## Next steps

### More sample code

- [Managing EventHubs](https://github.com/yukun-dong/azure-sdk-for-net/blob/eventhub-2018-01-preview/sdk/eventhub/Azure.ResourceManager.EventHubs/samples/Sample1_ManagingEventHubs.md)

### Additional Documentation

For more information on Azure SDK, please refer to [this website](https://azure.github.io/azure-sdk/).

## Contributing

For details on contributing to this repository, see the contributing
guide.

This project welcomes contributions and suggestions. Most contributions
require you to agree to a Contributor License Agreement (CLA) declaring
that you have the right to, and actually do, grant us the rights to use
your contribution. For details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine
whether you need to provide a CLA and decorate the PR appropriately
(e.g., label, comment). Simply follow the instructions provided by the
bot. You will only need to do this once across all repositories using
our CLA.

This project has adopted the Microsoft Open Source Code of Conduct. For
more information see the Code of Conduct FAQ or contact
<opencode@microsoft.com> with any additional questions or comments.

<!-- LINKS -->
[style-guide-msft]: https://docs.microsoft.com/style-guide/capitalization
[style-guide-cloud]: https://aka.ms/azsdk/cloud-style-guide

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Ftemplate%2FAzure.Template%2FREADME.png)
