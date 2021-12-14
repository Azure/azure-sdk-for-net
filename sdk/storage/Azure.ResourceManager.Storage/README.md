# Azure Storage Management client library for .NET

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html) which provide a number of core capabilities that are shared amongst all Azure SDKs, including the intuitive Azure Identity library, an HTTP Pipeline with custom policies, error-handling, distributed tracing, and much more.

## Getting started 

### Install the package

Install the Azure Storage management library for .NET with [NuGet](https://www.nuget.org/):

```PowerShell
Install-Package Azure.ResourceManager.Storage -Version 1.0.0-beta.4
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

```C# Snippet:Managing_StorageAccounts_AuthClient
using Azure.Identity;
using Azure.ResourceManager;

ArmClient armClient = new ArmClient(new DefaultAzureCredential());
```

Additional documentation for the `Azure.Identity.DefaultAzureCredential` class can be found in [this document](https://docs.microsoft.com/dotnet/api/azure.identity.defaultazurecredential).

## Key concepts

Key concepts of the Azure .NET SDK can be found [here](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/README.md#key-concepts)

## Examples

### Create a storage account

Before creating a storage account, we need to have a resource group.

```C# Snippet:Managing_StorageAccounts_DefaultSubscription
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
```
```C# Snippet:Managing_StorageAccounts_GetResourceGroupCollection
string rgName = "myRgName";
Location location = Location.WestUS2;
ResourceGroupCreateOrUpdateOperation operation= await subscription.GetResourceGroups().CreateOrUpdateAsync(rgName, new ResourceGroupData(location));
ResourceGroup resourceGroup = operation.Value;
```

Then we can create a storage account inside this resource group.

```C# Snippet:Managing_StorageAccounts_CreateStorageAccount
//first we need to define the StorageAccountCreateParameters
Sku sku = new Sku(SkuName.StandardGRS);
Kind kind = Kind.Storage;
string location = "westus2";
StorageAccountCreateParameters parameters = new StorageAccountCreateParameters(sku, kind, location);
//now we can create a storage account with defined account name and parameters
StorageAccountCollection accountCollection = resourceGroup.GetStorageAccounts();
string accountName = "myAccount";
StorageAccountCreateOperation accountCreateOperation = await accountCollection.CreateOrUpdateAsync(accountName, parameters);
StorageAccount storageAccount = accountCreateOperation.Value;
```

### Get all storage accounts in a resource group

```C# Snippet:Managing_StorageAccounts_ListStorageAccounts
StorageAccountCollection accountCollection = resourceGroup.GetStorageAccounts();
AsyncPageable<StorageAccount> response = accountCollection.GetAllAsync();
await foreach (StorageAccount storageAccount in response)
{
    Console.WriteLine(storageAccount.Id.Name);
}
```

### Get a storage account

```C# Snippet:Managing_StorageAccounts_GetStorageAccount
StorageAccountCollection accountCollection = resourceGroup.GetStorageAccounts();
StorageAccount storageAccount = await accountCollection.GetAsync("myAccount");
Console.WriteLine(storageAccount.Id.Name);
```

### Try to get a storage account if it exists


```C# Snippet:Managing_StorageAccounts_GetStorageAccountIfExists
StorageAccountCollection accountCollection = resourceGroup.GetStorageAccounts();
StorageAccount storageAccount = await accountCollection.GetIfExistsAsync("foo");
if (storageAccount != null)
{
    Console.WriteLine(storageAccount.Id.Name);
}
if (await accountCollection.CheckIfExistsAsync("bar"))
{
    Console.WriteLine("storage account 'bar' exists");
}
```

### Delete a storage account

```C# Snippet:Managing_StorageAccounts_DeleteStorageAccount
StorageAccountCollection accountCollection = resourceGroup.GetStorageAccounts();
StorageAccount storageAccount = await accountCollection.GetAsync("myAccount");
await storageAccount.DeleteAsync();
```

### Add a tag to the storage account

```C# Snippet:Managing_StorageAccounts_AddTagStorageAccount
StorageAccountCollection accountCollection = resourceGroup.GetStorageAccounts();
StorageAccount storageAccount = await accountCollection.GetAsync("myAccount");
// add a tag on this storage account
await storageAccount.AddTagAsync("key", "value");
```

For more detailed examples, take a look at [samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/storage/Azure.ResourceManager.Storage/samples) we have available.

## Troubleshooting

-   If you find a bug or have a suggestion, file an issue via [GitHub issues](https://github.com/Azure/azure-sdk-for-net/issues) and make sure you add the "Preview" label to the issue.
-   If you need help, check [previous
    questions](https://stackoverflow.com/questions/tagged/azure+.net)
    or ask new ones on StackOverflow using azure and .NET tags.
-   If having trouble with authentication, go to [DefaultAzureCredential documentation](https://docs.microsoft.com/dotnet/api/azure.identity.defaultazurecredential?view=azure-dotnet)


## Next steps

### More sample code

- [Managing Blob Containers](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Azure.ResourceManager.Storage/samples/Sample1_ManagingBlobContainers.md)
- [Managing File Shares](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Azure.ResourceManager.Storage/samples/Sample2_ManagingFileShares.md)

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
