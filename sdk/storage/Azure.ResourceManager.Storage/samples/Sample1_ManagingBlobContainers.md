# Example: Managing the Blob Containers

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

```C# Snippet:Managing_StorageAccounts_DefaultSubscription
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
```

This is a scoped operations object, and any operations you perform will be done under that subscription. From this object, you have access to all children via collection objects. Or you can access individual children by ID.

```C# Snippet:Managing_StorageAccounts_GetResourceGroupCollection
string rgName = "myRgName";
Location location = Location.WestUS2;
ResourceGroupCreateOrUpdateOperation operation= await subscription.GetResourceGroups().CreateOrUpdateAsync(rgName, new ResourceGroupData(location));
ResourceGroup resourceGroup = operation.Value;
```

After we have the resource group created, we can create a storage account

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


Then we need to get the blob service, which is a singleton resource and the name is "default"

```C# Snippet:Managing_BlobContainers_GetBlobService
BlobService blobService = storageAccount.GetBlobService();
```


Now that we have the blob service, we can manage the blob containers inside this storage account.

***Create a blob container***

```C# Snippet:Managing_BlobContainers_CreateBlobContainer
BlobContainerCollection blobContainerCollection = blobService.GetBlobContainers();
string blobContainerName = "myBlobContainer";
BlobContainerData blobContainerData = new BlobContainerData();
BlobContainerCreateOperation blobContainerCreateOperation = await blobContainerCollection.CreateOrUpdateAsync(blobContainerName, blobContainerData);
BlobContainer blobContainer = blobContainerCreateOperation.Value;
```

***List all blob containers***

```C# Snippet:Managing_BlobContainers_ListBlobContainers
BlobContainerCollection blobContainerCollection = blobService.GetBlobContainers();
AsyncPageable<BlobContainer> response = blobContainerCollection.GetAllAsync();
await foreach (BlobContainer blobContainer in response)
{
    Console.WriteLine(blobContainer.Id.Name);
}
```

***Get a blob container***

```C# Snippet:Managing_BlobContainers_GetBlobContainer
BlobContainerCollection blobContainerCollection = blobService.GetBlobContainers();
BlobContainer blobContainer = await blobContainerCollection.GetAsync("myBlobContainer");
Console.WriteLine(blobContainer.Id.Name);
```

***Try to get a blob container if it exists***

```C# Snippet:Managing_BlobContainers_GetBlobContainerIfExists
BlobContainerCollection blobContainerCollection = blobService.GetBlobContainers();
BlobContainer blobContainer = await blobContainerCollection.GetIfExistsAsync("foo");
if (blobContainer != null)
{
    Console.WriteLine(blobContainer.Id.Name);
}
if (await blobContainerCollection.CheckIfExistsAsync("bar"))
{
    Console.WriteLine("blob container 'bar' exists");
}
```

***Delete a blob container***

```C# Snippet:Managing_BlobContainers_DeleteBlobContainer
BlobContainerCollection blobContainerCollection = blobService.GetBlobContainers();
BlobContainer blobContainer = await blobContainerCollection.GetAsync("myBlobContainer");
await blobContainer.DeleteAsync();
```

## Next steps

Take a look at the [Managing File Shares](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Azure.ResourceManager.Storage/samples/Sample2_ManagingFileShares.md) samples.
