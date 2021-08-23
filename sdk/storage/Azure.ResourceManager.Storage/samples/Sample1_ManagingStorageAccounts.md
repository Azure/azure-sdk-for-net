# Example: Managing the storage accounts

>Note: Before getting started with the samples, go through the [prerequisites](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/resourcemanager/Azure.ResourceManager#prerequisites).

Namespaces for this example:

```C# Snippet:Managing_StorageAccounts_NameSpaces
using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.ResourceManager.Storage.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;
using Sku = Azure.ResourceManager.Storage.Models.Sku;
```

When you first create your ARM client, choose the subscription you're going to work in. There's a convenient `DefaultSubscription` property that returns the default subscription configured for your user:

```C# Snippet:Readme_DefaultSubscription
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = armClient.DefaultSubscription;
```

This is a scoped operations object, and any operations you perform will be done under that subscription. From this object, you have access to all children via container objects. Or you can access individual children by ID.

```C# Snippet:Readme_GetResourceGroupContainer
string rgName = "myRgName";
Location location = Location.WestUS2;
ResourceGroup resourceGroup = await subscription.GetResourceGroups().CreateOrUpdateAsync(rgName, new ResourceGroupData(location));
```

Now that we have the resource group created, we can manage the storage accounts inside this resource group.

***Create a storage account***

```C# Snippet:Managing_StorageAccounts_CreateStorageAccount
//first we need to define the StorageAccountCreateParameters
Sku sku = new Sku(SkuName.StandardGRS);
Kind kind = Kind.Storage;
string location = "westus2";
StorageAccountCreateParameters parameters = new StorageAccountCreateParameters(sku, kind, location);
//now we can create a storage account with defined account name and parameters
StorageAccountContainer accountContainer = resourceGroup.GetStorageAccounts();
string accountName = "myAccount";
StorageAccountCreateOperation accountCreateOperation = await accountContainer.CreateOrUpdateAsync(accountName, parameters);
StorageAccount storageAccount = await accountCreateOperation.WaitForCompletionAsync();
```

***List all storage accounts***

```C# Snippet:Managing_StorageAccounts_ListStorageAccounts
StorageAccountContainer accountContainer = resourceGroup.GetStorageAccounts();
AsyncPageable<StorageAccount> response = accountContainer.GetAllAsync();
await foreach (StorageAccount storageAccount in response)
{
    Console.WriteLine(storageAccount.Data.Name);
}
```

***Get a storage account***

```C# Snippet:Managing_StorageAccounts_GetStorageAccount
StorageAccountContainer accountContainer = resourceGroup.GetStorageAccounts();
StorageAccount storageAccount = await accountContainer.GetAsync("myAccount");
Console.WriteLine(storageAccount.Data.Name);
```

***Try to get a storage account if it exists***

```C# Snippet:Managing_StorageAccounts_GetStorageAccountIfExists
StorageAccountContainer accountContainer = resourceGroup.GetStorageAccounts();
StorageAccount storageAccount = await accountContainer.GetIfExistsAsync("foo");
if (storageAccount != null)
{
    Console.WriteLine(storageAccount.Data.Name);
}
if (await accountContainer.CheckIfExistsAsync("bar"))
{
    Console.WriteLine("storage account 'bar' exists");
}
```

***Delete a storage account***

```C# Snippet:Managing_StorageAccounts_DeleteStorageAccount
StorageAccountContainer accountContainer = resourceGroup.GetStorageAccounts();
StorageAccount storageAccount = await accountContainer.GetAsync("myAccount");
await storageAccount.DeleteAsync();
```

## Next steps

Take a look at the [Managing Blob Containers](https://github.com/yukun-dong/azure-sdk-for-net/blob/feature/mgmt-track2-storage/sdk/storage/Azure.ResourceManager.Storage/samples/Sample2_ManagingBlobContainers.md) samples.
