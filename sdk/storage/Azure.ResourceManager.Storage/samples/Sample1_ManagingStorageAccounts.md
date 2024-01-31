# Example: Managing the Storage Accounts

>Note: Before getting started with the samples, go through the [prerequisites](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/resourcemanager/Azure.ResourceManager#prerequisites).

Namespaces for this example:

```C# Snippet:Managing_StorageAccounts_NameSpaces
using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.ResourceManager.Storage.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using Azure.Core;
```

### Create a storage account

Before creating a storage account, we need to have a resource group.

```C# Snippet:Managing_StorageAccounts_DefaultSubscription
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
```
```C# Snippet:Managing_StorageAccounts_GetResourceGroupCollection
string rgName = "myRgName";
AzureLocation location = AzureLocation.WestUS2;
ArmOperation<ResourceGroupResource> operation = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(location));
ResourceGroupResource resourceGroup = operation.Value;
```

Then we can create a storage account inside this resource group.

```C# Snippet:Managing_StorageAccounts_CreateStorageAccount
//first we need to define the StorageAccountCreateParameters
StorageSku sku = new StorageSku(StorageSkuName.StandardGrs);
StorageKind kind = StorageKind.Storage;
string location = "westus2";
StorageAccountCreateOrUpdateContent parameters = new StorageAccountCreateOrUpdateContent(sku, kind, location);
//now we can create a storage account with defined account name and parameters
StorageAccountCollection accountCollection = resourceGroup.GetStorageAccounts();
string accountName = "myAccount";
ArmOperation<StorageAccountResource> accountCreateOperation = await accountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters);
StorageAccountResource storageAccount = accountCreateOperation.Value;
```

### Get keys on a storage account

```C# Snippet:Managing_StorageAccounts_GetKeys
await foreach (StorageAccountKey key in storageAccount.GetKeysAsync())
{
    Console.WriteLine(key.Value);
}
```

### Get all storage accounts in a resource group

```C# Snippet:Managing_StorageAccounts_ListStorageAccounts
StorageAccountCollection accountCollection = resourceGroup.GetStorageAccounts();
AsyncPageable<StorageAccountResource> response = accountCollection.GetAllAsync();
await foreach (StorageAccountResource storageAccount in response)
{
    Console.WriteLine(storageAccount.Id.Name);
}
```

### Get a storage account

```C# Snippet:Managing_StorageAccounts_GetStorageAccount
StorageAccountCollection accountCollection = resourceGroup.GetStorageAccounts();
StorageAccountResource storageAccount = await accountCollection.GetAsync("myAccount");
Console.WriteLine(storageAccount.Id.Name);
```

### Delete a storage account

```C# Snippet:Managing_StorageAccounts_DeleteStorageAccount
StorageAccountCollection accountCollection = resourceGroup.GetStorageAccounts();
StorageAccountResource storageAccount = await accountCollection.GetAsync("myAccount");
await storageAccount.DeleteAsync(WaitUntil.Completed);
```

### Add a tag to the storage account

```C# Snippet:Managing_StorageAccounts_AddTagStorageAccount
StorageAccountCollection accountCollection = resourceGroup.GetStorageAccounts();
StorageAccountResource storageAccount = await accountCollection.GetAsync("myAccount");
// add a tag on this storage account
await storageAccount.AddTagAsync("key", "value");
```

## Next steps

Take a look at the [Managing Blob Containers](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Azure.ResourceManager.Storage/samples/Sample2_ManagingBlobContainers.md) samples.
