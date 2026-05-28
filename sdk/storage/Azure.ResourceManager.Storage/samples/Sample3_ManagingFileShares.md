# Example: Managing the File Shares

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


Then we need to get the file service, which is a singleton resource and the name is "default"

```C# Snippet:Managing_FileShares_GetFileService
FileServiceResource fileService = await storageAccount.GetFileService().GetAsync();
```


Now that we have the file service, we can manage the file shares inside this storage account.

***Create a file share***

```C# Snippet:Managing_FileShares_CreateFileShare
FileShareCollection fileShareCollection = fileService.GetFileShares();
string fileShareName = "myFileShare";
FileShareData fileShareData = new FileShareData();
ArmOperation<FileShareResource> fileShareCreateOperation = await fileShareCollection.CreateOrUpdateAsync(WaitUntil.Started, fileShareName, fileShareData);
FileShareResource fileShare =await fileShareCreateOperation.WaitForCompletionAsync();
```

***List all file shares***

```C# Snippet:Managing_FileShares_ListFileShares
FileShareCollection fileShareCollection = fileService.GetFileShares();
AsyncPageable<FileShareResource> response = fileShareCollection.GetAllAsync();
await foreach (FileShareResource fileShare in response)
{
    Console.WriteLine(fileShare.Id.Name);
}
```

***Get a file share***

```C# Snippet:Managing_FileShares_GetFileShare
FileShareCollection fileShareCollection = fileService.GetFileShares();
FileShareResource fileShare = await fileShareCollection.GetAsync("myFileShare");
Console.WriteLine(fileShare.Id.Name);
```

***Delete a file share***

```C# Snippet:Managing_FileShares_DeleteFileShare
FileShareCollection fileShareCollection = fileService.GetFileShares();
FileShareResource fileShare = await fileShareCollection.GetAsync("myFileShare");
await fileShare.DeleteAsync(WaitUntil.Completed);
```

## Next steps

Take a look at the [Managing Storage Accounts](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Azure.ResourceManager.Storage/samples/Sample1_ManagingStorageAccounts.md) samples.
