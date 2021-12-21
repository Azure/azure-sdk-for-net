# Example: Managing the File Shares

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


Then we need to get the file service, which is a singleton resource and the name is "default"

```C# Snippet:Managing_FileShares_GetFileService
FileService fileService = await storageAccount.GetFileService().GetAsync();
```


Now that we have the file service, we can manage the file shares inside this storage account.

***Create a file share***

```C# Snippet:Managing_FileShares_CreateFileShare
FileShareCollection fileShareCollection = fileService.GetFileShares();
string fileShareName = "myFileShare";
FileShareData fileShareData = new FileShareData();
FileShareCreateOperation fileShareCreateOperation = await fileShareCollection.CreateOrUpdateAsync(fileShareName, fileShareData);
FileShare fileShare =await fileShareCreateOperation.WaitForCompletionAsync();
```

***List all file shares***

```C# Snippet:Managing_FileShares_ListFileShares
FileShareCollection fileShareCollection = fileService.GetFileShares();
AsyncPageable<FileShare> response = fileShareCollection.GetAllAsync();
await foreach (FileShare fileShare in response)
{
    Console.WriteLine(fileShare.Id.Name);
}
```

***Get a file share***

```C# Snippet:Managing_FileShares_GetFileShare
FileShareCollection fileShareCollection = fileService.GetFileShares();
FileShare fileShare= await fileShareCollection.GetAsync("myFileShare");
Console.WriteLine(fileShare.Id.Name);
```

***Try to get a file share if it exists***

```C# Snippet:Managing_FileShares_GetFileShareIFExists
FileShareCollection fileShareCollection = fileService.GetFileShares();
FileShare fileShare = await fileShareCollection.GetIfExistsAsync("foo");
if (fileShare != null)
{
    Console.WriteLine(fileShare.Id.Name);
}
if (await fileShareCollection.CheckIfExistsAsync("bar"))
{
    Console.WriteLine("file share 'bar' exists");
}
```

***Delete a file share***

```C# Snippet:Managing_FileShares_DeleteFileShare
FileShareCollection fileShareCollection = fileService.GetFileShares();
FileShare fileShare = await fileShareCollection.GetAsync("myFileShare");
await fileShare.DeleteAsync();
```

## Next steps

Take a look at the [Managing Blob Containers](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Azure.ResourceManager.Storage/samples/Sample1_ManagingBlobContainers.md) samples.
