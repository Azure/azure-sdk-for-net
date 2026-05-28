# Example: Managing the Blob Containers

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

When you first create your ARM client, choose the subscription you're going to work in. There's a convenient `DefaultSubscription` property that returns the default subscription configured for your user:

```C# Snippet:Managing_StorageAccounts_DefaultSubscription
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
```

This is a scoped operations object, and any operations you perform will be done under that subscription. From this object, you have access to all children via collection objects. Or you can access individual children by ID.

```C# Snippet:Managing_StorageAccounts_GetResourceGroupCollection
string rgName = "myRgName";
AzureLocation location = AzureLocation.WestUS2;
ArmOperation<ResourceGroupResource> operation = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(location));
ResourceGroupResource resourceGroup = operation.Value;
```

After we have the resource group created, we can create a storage account

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


Then we need to get the blob service, which is a singleton resource and the name is "default"

```C# Snippet:Managing_BlobContainers_GetBlobService
BlobServiceResource blobService = storageAccount.GetBlobService();
```


Now that we have the blob service, we can manage the blob containers inside this storage account.

***Create a blob container***

```C# Snippet:Managing_BlobContainers_CreateBlobContainer
BlobContainerCollection blobContainerCollection = blobService.GetBlobContainers();
string blobContainerName = "myBlobContainer";
BlobContainerData blobContainerData = new BlobContainerData();
ArmOperation<BlobContainerResource> blobContainerCreateOperation = await blobContainerCollection.CreateOrUpdateAsync(WaitUntil.Completed, blobContainerName, blobContainerData);
BlobContainerResource blobContainer = blobContainerCreateOperation.Value;
```

***List all blob containers***

```C# Snippet:Managing_BlobContainers_ListBlobContainers
BlobContainerCollection blobContainerCollection = blobService.GetBlobContainers();
AsyncPageable<BlobContainerResource> response = blobContainerCollection.GetAllAsync();
await foreach (BlobContainerResource blobContainer in response)
{
    Console.WriteLine(blobContainer.Id.Name);
}
```

***Get a blob container***

```C# Snippet:Managing_BlobContainers_GetBlobContainer
BlobContainerCollection blobContainerCollection = blobService.GetBlobContainers();
BlobContainerResource blobContainer = await blobContainerCollection.GetAsync("myBlobContainer");
Console.WriteLine(blobContainer.Id.Name);
```

***Delete a blob container***

```C# Snippet:Managing_BlobContainers_DeleteBlobContainer
BlobContainerCollection blobContainerCollection = blobService.GetBlobContainers();
BlobContainerResource blobContainer = await blobContainerCollection.GetAsync("myBlobContainer");
await blobContainer.DeleteAsync(WaitUntil.Completed);
```

## Next steps

Take a look at the [Managing File Shares](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Azure.ResourceManager.Storage/samples/Sample3_ManagingFileShares.md) samples.
