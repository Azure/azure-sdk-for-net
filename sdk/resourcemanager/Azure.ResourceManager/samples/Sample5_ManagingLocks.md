# Example: Managing Locks

--------------------------------------

For this example, you need the following namespaces:

```C# Snippet:Managing_Policies_Namespaces
using System;
using Azure;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
```

When you first create your ARM client, choose the subscription you're going to work in. There's a convenient `DefaultSubscription` property that returns the default subscription configured for your user:

```C# Snippet:Readme_DefaultSubscription
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = armClient.DefaultSubscription;
```

This is a scoped operations object, and any operations you perform will be done under that subscription. From this object, you have access to all children via container objects.

```C# Snippet:Readme_GetResourceGroupContainer
string rgName = "myRgName";
Location location = Location.WestUS2;
ResourceGroup resourceGroup = await subscription.GetResourceGroups().CreateOrUpdateAsync(rgName, new ResourceGroupData(location));
```

## Create a Management Lock

Now that we have a resource group, we'll create a `CanNotDelete` lock for it.

```C# Snippet:Readme_CreateLock
ManagementLockObjectContainer lockContainer = resourceGroup.GetManagementLocks();
ManagementLockObjectData mgmtLockObjectData = new ManagementLockObjectData(new LockLevel("CanNotDelete"));
ManagementLockObject mgmtLockObject = (await lockContainer.CreateOrUpdateAsync("myLock", mgmtLockObjectData)).Value;
```

You can also create a lock for any resource. For instance, if you've got a StorageAccount myStorageAccount, you can add a lock for it.

```C# Snippet:Readme_CreateLockForStorageAccount
ManagementLockObjectContainer saLockContainer = myStorageAccount.GetManagementLocks();
ManagementLockObjectData mgmtLockObjectData = new ManagementLockObjectData(new LockLevel("CanNotDelete"));
ManagementLockObject mgmtLockObject = (await saLockContainer.CreateOrUpdateAsync("myStorageAccountLock", mgmtLockObjectData)).Value;
```

## List Management Locks

```C# Snippet:Readme_ListLocks
ManagementLockObjectContainer lockContainer = resourceGroup.GetManagementLocks();
AsyncPageable<ManagementLockObject> locks = lockContainer.GetAllAsync();
await foreach (var lock in locks)
{
    Console.WriteLine(lock.Data.Name);
}
```

## Get and Delete a Management Lock

```C# Snippet:Readme_DeleteLock
ManagementLockObjectContainer lockContainer = resourceGroup.GetManagementLocks();
ManagementLockObject mgmtLockObject = (await lockContainer.GetAsync("myLock")).Value;
await mgmtLockObject.DeleteAsync();
```
