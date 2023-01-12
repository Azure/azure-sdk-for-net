# Example: Managing Virtual Machines

--------------------------------------
For this example, you need the following namespaces:

```C# Snippet:Managing_VirtualMachines_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
```

When you first create your ARM client, choose the subscription you're going to work in. You can use the `GetDefaultSubscription`/`GetDefaultSubscriptionAsync` methods to return the default subscription configured for your user:

```C# Snippet:Readme_DefaultSubscription
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = armClient.GetDefaultSubscription();
```

This is a scoped operations object, and any operations you perform will be done under that subscription. From this object, you have access to all children via collection objects. Or you can access individual children by ID.

```C# Snippet:Readme_GetResourceGroupCollection
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
ResourceGroupCollection rgCollection = subscription.GetResourceGroups();
// With the collection, we can create a new resource group with an specific name
string rgName = "myRgName";
AzureLocation location = AzureLocation.WestUS2;
ArmOperation<ResourceGroupResource> lro = await rgCollection.CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(location));
ResourceGroupResource resourceGroup = lro.Value;
```

Now that we have the resource group created, we can manage the virtual machines inside this resource group.

Please notice that before we create a virtual machine, at lease we need to create a Network Interface resource as prerequisite. Please refer to documentation of `Azure.ResourceManager.Network` for details of creating a Network Interface.

***Create a virtual machine***

```C# Snippet:Managing_VirtualMachines_CreateAVirtualMachine
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
// first we need to get the resource group
string rgName = "myRgName";
ResourceGroupResource resourceGroup = await subscription.GetResourceGroups().GetAsync(rgName);
// Now we get the virtual machine collection from the resource group
VirtualMachineCollection vmCollection = resourceGroup.GetVirtualMachines();
// Use the same location as the resource group
string vmName = "myVM";
VirtualMachineData input = new VirtualMachineData(resourceGroup.Data.Location)
{
    HardwareProfile = new VirtualMachineHardwareProfile()
    {
        VmSize = VirtualMachineSizeType.StandardF2
    },
    OSProfile = new VirtualMachineOSProfile()
    {
        AdminUsername = "adminUser",
        ComputerName = "myVM",
        LinuxConfiguration = new LinuxConfiguration()
        {
            DisablePasswordAuthentication = true,
            SshPublicKeys = {
                new SshPublicKeyConfiguration()
                {
                    Path = $"/home/adminUser/.ssh/authorized_keys",
                    KeyData = "<value of the public ssh key>",
                }
            }
        }
    },
    NetworkProfile = new VirtualMachineNetworkProfile()
    {
        NetworkInterfaces =
        {
            new VirtualMachineNetworkInterfaceReference()
            {
                Id = new ResourceIdentifier("/subscriptions/<subscriptionId>/resourceGroups/<rgName>/providers/Microsoft.Network/networkInterfaces/<nicName>"),
                Primary = true,
            }
        }
    },
    StorageProfile = new VirtualMachineStorageProfile()
    {
        OSDisk = new VirtualMachineOSDisk(DiskCreateOptionType.FromImage)
        {
            OSType = SupportedOperatingSystemType.Linux,
            Caching = CachingType.ReadWrite,
            ManagedDisk = new VirtualMachineManagedDisk()
            {
                StorageAccountType = StorageAccountType.StandardLrs
            }
        },
        ImageReference = new ImageReference()
        {
            Publisher = "Canonical",
            Offer = "UbuntuServer",
            Sku = "16.04-LTS",
            Version = "latest",
        }
    }
};
ArmOperation<VirtualMachineResource> lro = await vmCollection.CreateOrUpdateAsync(WaitUntil.Completed, vmName, input);
VirtualMachineResource vm = lro.Value;
```

***List all virtual machines***

```C# Snippet:Managing_VirtualMachines_ListAllVirtualMachines
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
// first we need to get the resource group
string rgName = "myRgName";
ResourceGroupResource resourceGroup = await subscription.GetResourceGroups().GetAsync(rgName);
// Now we get the virtual machine collection from the resource group
VirtualMachineCollection vmCollection = resourceGroup.GetVirtualMachines();
// With ListAsync(), we can get a list of the virtual machines
AsyncPageable<VirtualMachineResource> response = vmCollection.GetAllAsync();
await foreach (VirtualMachineResource vm in response)
{
    Console.WriteLine(vm.Data.Name);
}
```

***Delete a virtual machine***

```C# Snippet:Managing_VirtualMachines_DeleteVirtualMachine
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
// first we need to get the resource group
string rgName = "myRgName";
ResourceGroupResource resourceGroup = await subscription.GetResourceGroups().GetAsync(rgName);
// Now we get the virtual machine collection from the resource group
VirtualMachineCollection vmCollection = resourceGroup.GetVirtualMachines();
string vmName = "myVM";
VirtualMachineResource vm = await vmCollection.GetAsync(vmName);
await vm.DeleteAsync(WaitUntil.Completed);
```
