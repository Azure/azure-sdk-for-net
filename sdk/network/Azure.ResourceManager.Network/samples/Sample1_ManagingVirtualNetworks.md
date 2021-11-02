# Example: Managing the virtual networks

>Note: Before getting started with the samples, go through the [prerequisites](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/resourcemanager/Azure.ResourceManager#prerequisites).

Namespaces for this example:

```C# Snippet:Manage_Networks_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;
```

When you first create your ARM client, choose the subscription you're going to work in. There's a convenient `DefaultSubscription` property that returns the default subscription configured for your user:

```C# Snippet:Readme_DefaultSubscription
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = armClient.DefaultSubscription;
```

This is a scoped operations object, and any operations you perform will be done under that subscription. From this object, you have access to all children via container objects. Or you can access individual children by ID.

```C# Snippet:Readme_GetResourceGroupContainer
ResourceGroupContainer rgContainer = subscription.GetResourceGroups();
// With the container, we can create a new resource group with an specific name
string rgName = "myRgName";
Location location = Location.WestUS2;
ResourceGroup resourceGroup = await rgContainer.CreateOrUpdate(rgName, new ResourceGroupData(location)).WaitForCompletionAsync();
```

Now that we have the resource group created, we can manage the virtual networks inside this resource group.

***Create a virtual network***

```C# Snippet:Managing_Networks_CreateAVirtualNetwork
VirtualNetworkContainer virtualNetworkContainer = resourceGroup.GetVirtualNetworks();

string vnetName = "myVnet";

// Use the same location as the resource group
VirtualNetworkData input = new VirtualNetworkData()
{
    Location = resourceGroup.Data.Location,
    AddressSpace = new AddressSpace()
    {
        AddressPrefixes = { "10.0.0.0/16", }
    },
    DhcpOptions = new DhcpOptions()
    {
        DnsServers = { "10.1.1.1", "10.1.2.4" }
    },
    Subnets = { new SubnetData() { Name = "mySubnet", AddressPrefix = "10.0.1.0/24", } }
};

VirtualNetwork vnet = await virtualNetworkContainer.CreateOrUpdate(vnetName, input).WaitForCompletionAsync();
```

***List all virtual networks***

```C# Snippet:Managing_Networks_ListAllVirtualNetworks
VirtualNetworkContainer virtualNetworkContainer = resourceGroup.GetVirtualNetworks();

AsyncPageable<VirtualNetwork> response = virtualNetworkContainer.GetAllAsync();
await foreach (VirtualNetwork virtualNetwork in response)
{
    Console.WriteLine(virtualNetwork.Data.Name);
}
```

***Get a virtual network***

```C# Snippet:Managing_Networks_GetAVirtualNetwork
VirtualNetworkContainer virtualNetworkContainer = resourceGroup.GetVirtualNetworks();

VirtualNetwork virtualNetwork = await virtualNetworkContainer.GetAsync("myVnet");
Console.WriteLine(virtualNetwork.Data.Name);
```

***Try to get a virtual network if it exists***

```C# Snippet:Managing_Networks_GetAVirtualNetworkIfExists
VirtualNetworkContainer virtualNetworkContainer = resourceGroup.GetVirtualNetworks();

VirtualNetwork virtualNetwork = await virtualNetworkContainer.GetIfExistsAsync("foo");
if (virtualNetwork != null)
{
    Console.WriteLine(virtualNetwork.Data.Name);
}

if (await virtualNetworkContainer.CheckIfExistsAsync("bar"))
{
    Console.WriteLine("Virtual network 'bar' exists.");
}
```

***Delete a virtual network***

```C# Snippet:Managing_Networks_DeleteAVirtualNetwork
VirtualNetworkContainer virtualNetworkContainer = resourceGroup.GetVirtualNetworks();

VirtualNetwork virtualNetwork = await virtualNetworkContainer.GetAsync("myVnet");
await virtualNetwork.DeleteAsync();
```

## Next steps

Take a look at the [Managing Network Interfaces](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/network/Azure.ResourceManager.Network/samples/Sample2_ManagingNetworkInterfaces.md) samples.
