# Example: Managing the virtual networks

>Note: Before getting started with the samples, go through the [prerequisites](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/resourcemanager/Azure.ResourceManager#prerequisites).

Namespaces for this example:

```C# Snippet:Manage_Networks_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;
```

When you first create your ARM client, choose the subscription you're going to work in. You can use the `GetDefaultSubscription`/`GetDefaultSubscriptionAsync` methods to return the default subscription configured for your user:

```C# Snippet:Readme_DefaultSubscription
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
```

This is a scoped operations object, and any operations you perform will be done under that subscription. From this object, you have access to all children via collection objects. Or you can access individual children by ID.

```C# Snippet:Readme_GetResourceGroupCollection
ResourceGroupCollection rgCollection = subscription.GetResourceGroups();
// With the collection, we can create a new resource group with an specific name
string rgName = "myRgName";
AzureLocation location = AzureLocation.WestUS2;
ResourceGroupResource resourceGroup = await rgCollection.CreateOrUpdate(WaitUntil.Started, rgName, new ResourceGroupData(location)).WaitForCompletionAsync();
```

Now that we have the resource group created, we can manage the virtual networks inside this resource group.

***Create a virtual network***

```C# Snippet:Managing_Networks_CreateAVirtualNetwork
VirtualNetworkCollection virtualNetworkCollection = resourceGroup.GetVirtualNetworks();

string vnetName = "myVnet";

// Use the same location as the resource group
VirtualNetworkData input = new VirtualNetworkData()
{
    Location = resourceGroup.Data.Location,
    AddressPrefixes = { "10.0.0.0/16", },
    DhcpOptionsDnsServers = { "10.1.1.1", "10.1.2.4" },
    Subnets = { new SubnetData() { Name = "mySubnet", AddressPrefix = "10.0.1.0/24", } }
};

VirtualNetworkResource vnet = await virtualNetworkCollection.CreateOrUpdate(WaitUntil.Completed, vnetName, input).WaitForCompletionAsync();
```

***List all virtual networks***

```C# Snippet:Managing_Networks_ListAllVirtualNetworks
VirtualNetworkCollection virtualNetworkCollection = resourceGroup.GetVirtualNetworks();

AsyncPageable<VirtualNetworkResource> response = virtualNetworkCollection.GetAllAsync();
await foreach (VirtualNetworkResource virtualNetwork in response)
{
    Console.WriteLine(virtualNetwork.Data.Name);
}
```

***Get a virtual network***

```C# Snippet:Managing_Networks_GetAVirtualNetwork
VirtualNetworkCollection virtualNetworkCollection = resourceGroup.GetVirtualNetworks();

VirtualNetworkResource virtualNetwork = await virtualNetworkCollection.GetAsync("myVnet");
Console.WriteLine(virtualNetwork.Data.Name);
```

***Delete a virtual network***

```C# Snippet:Managing_Networks_DeleteAVirtualNetwork
VirtualNetworkCollection virtualNetworkCollection = resourceGroup.GetVirtualNetworks();

VirtualNetworkResource virtualNetwork = await virtualNetworkCollection.GetAsync("myVnet");
await virtualNetwork.DeleteAsync(WaitUntil.Completed);
```

## Next steps

Take a look at the [Managing Network Interfaces](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/network/Azure.ResourceManager.Network/samples/Sample2_ManagingNetworkInterfaces.md) samples.
