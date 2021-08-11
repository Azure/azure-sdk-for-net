# Example: Managing the disks

>Note: Before getting started with the samples, go through the [prerequisites](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/resourcemanager/Azure.ResourceManager#prerequisites).

Namespaces for this example:
```C# Snippet:Manage_Disks_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
```

When you first create your ARM client, choose the subscription you're going to work in. There's a convenient `DefaultSubscription` property that returns the default subscription configured for your user:

```C# Snippet:Readme_DefaultSubscription
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = armClient.DefaultSubscription;
```

This is a scoped operations object, and any operations you perform will be done under that subscription. From this object, you have access to all children via container objects. Or you can access individual children by ID.

```C# Snippet:Readme_GetResourceGroupContainer
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = armClient.DefaultSubscription;
ResourceGroupContainer rgContainer = subscription.GetResourceGroups();
// With the container, we can create a new resource group with an specific name
string rgName = "myRgName";
Location location = Location.WestUS2;
ResourceGroup resourceGroup = await rgContainer.CreateOrUpdateAsync(rgName, new ResourceGroupData(location));
```

Now that we have the resource group created, we can manage the disks inside this resource group.

***Create a disk***

```C# Snippet:Managing_Disks_CreateADisk
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = armClient.DefaultSubscription;
// first we need to get the resource group
string rgName = "myRgName";
ResourceGroup resourceGroup = await subscription.GetResourceGroups().GetAsync(rgName);
// Now we get the virtual machine container from the resource group
DiskContainer diskContainer = resourceGroup.GetDisks();
// Use the same location as the resource group
string diskName = "myDisk";
var input = new DiskData(resourceGroup.Data.Location)
{
    Sku = new DiskSku()
    {
        Name = DiskStorageAccountTypes.StandardLRS
    },
    CreationData = new CreationData(DiskCreateOption.Empty),
    DiskSizeGB = 1,
};
Disk disk = await diskContainer.CreateOrUpdateAsync(diskName, input);
```

***List all disks***

```C# Snippet:Managing_Disks_ListAllDisks
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = armClient.DefaultSubscription;
// first we need to get the resource group
string rgName = "myRgName";
ResourceGroup resourceGroup = await subscription.GetResourceGroups().GetAsync(rgName);
// Now we get the virtual machine container from the resource group
DiskContainer diskContainer = resourceGroup.GetDisks();
// With ListAsync(), we can get a list of the virtual machines in the container
AsyncPageable<Disk> response = diskContainer.GetAllAsync();
await foreach (Disk disk in response)
{
    Console.WriteLine(disk.Data.Name);
}
```

***Delete a disk***

```C# Snippet:Managing_Disks_DeleteDisk
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = armClient.DefaultSubscription;
// first we need to get the resource group
string rgName = "myRgName";
ResourceGroup resourceGroup = await subscription.GetResourceGroups().GetAsync(rgName);
// Now we get the virtual machine container from the resource group
DiskContainer diskContainer = resourceGroup.GetDisks();
string diskName = "myDisk";
Disk disk = await diskContainer.GetAsync(diskName);
await disk.DeleteAsync();
```


## Next steps
Take a look at the [Managing Virtual Machines](https://github.com/Azure/azure-sdk-for-net/blob/feature/mgmt-track2-compute-2/sdk/compute/Azure.ResourceManager.Compute/samples/Sample2_ManagingVirtualMachines.md) samples.
