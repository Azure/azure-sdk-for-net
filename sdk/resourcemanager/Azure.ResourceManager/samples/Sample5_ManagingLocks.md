# Example: Managing Locks

--------------------------------------

For this example, you need the following namespaces:

```C# Snippet:Managing_Locks_Namespaces
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Azure;
using Azure.Identity;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
```

When you first create your ARM client, choose the subscription you're going to work in. There's a convenient `DefaultSubscription` property that returns the default subscription configured for your user:

```C# Snippet:Managing_Locks_DefaultSubscription
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = armClient.DefaultSubscription;
```

This is a scoped operations object, and any operations you perform will be done under that subscription. From this object, you have access to all children via container objects.

```C# Snippet:Managing_Locks_GetResourceGroupContainer
ResourceGroupContainer rgContainer = subscription.GetResourceGroups();
// With the container, we can create a new resource group with an specific name
string rgName = "myRgName";
Location location = Location.WestUS2;
ResourceGroup resourceGroup = (await rgContainer.CreateOrUpdateAsync(rgName, new ResourceGroupData(location))).Value;
```

## Create a Management Lock

Now that we have a resource group, we'll create a `CanNotDelete` lock for it.

```C# Snippet:Managing_Locks_CreateLock
ManagementLockObjectContainer lockContainer = resourceGroup.GetManagementLocks();
ManagementLockObjectData mgmtLockObjectData = new ManagementLockObjectData(new LockLevel("CanNotDelete"));
ManagementLockObject mgmtLockObject = (await lockContainer.CreateOrUpdateAsync("myLock", mgmtLockObjectData)).Value;
```

You can also create a lock for any resource. For instance, if you've got a VirtualNetwork myVNet, you can add a lock for it.

```C# Snippet:Managing_Locks_CreateLockForVirtualNetwork
ManagementLockObjectContainer saLockContainer = myVNet.GetManagementLocks();
ManagementLockObjectData mgmtLockObjectData = new ManagementLockObjectData(new LockLevel("CanNotDelete"));
ManagementLockObject mgmtLockObject = (await saLockContainer.CreateOrUpdateAsync("myStorageAccountLock", mgmtLockObjectData)).Value;
```

## List Management Locks

```C# Snippet:Managing_Locks_ListLocks
ManagementLockObjectContainer lockContainer = resourceGroup.GetManagementLocks();
AsyncPageable<ManagementLockObject> locks = lockContainer.GetAllAsync();
await foreach (var myLock in locks)
{
    Console.WriteLine(myLock.Data.Name);
}
```

## Get and Delete a Management Lock

```C# Snippet:Managing_Locks_DeleteLock
ManagementLockObjectContainer lockContainer = resourceGroup.GetManagementLocks();
ManagementLockObject mgmtLockObject = (await lockContainer.GetAsync("myLock")).Value;
await mgmtLockObject.DeleteAsync();
```
