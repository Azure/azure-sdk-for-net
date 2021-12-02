# Example: Managing the network interfaces

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

When you first create your ARM client, choose the subscription you're going to work in. You can use the `GetDefaultSubscription`/`GetDefaultSubscriptionAsync` methods to return the default subscription configured for your user:

```C# Snippet:Readme_DefaultSubscription
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
```

This is a scoped operations object, and any operations you perform will be done under that subscription. From this object, you have access to all children via collection objects. Or you can access individual children by ID.

```C# Snippet:Readme_GetResourceGroupCollection
ResourceGroupCollection rgCollection = subscription.GetResourceGroups();
// With the collection, we can create a new resource group with an specific name
string rgName = "myRgName";
Location location = Location.WestUS2;
ResourceGroup resourceGroup = await rgCollection.CreateOrUpdate(rgName, new ResourceGroupData(location)).WaitForCompletionAsync();
```

Now that we have the resource group created, we can manage the network interfaces inside this resource group.

***Create a network interface***

```C# Snippet:Managing_Networks_CreateANetworkInterface
PublicIPAddressCollection publicIPAddressCollection = resourceGroup.GetPublicIPAddresses();
string publicIPAddressName = "myIPAddress";
PublicIPAddressData publicIPInput = new PublicIPAddressData()
{
    Location = resourceGroup.Data.Location,
    PublicIPAllocationMethod = IPAllocationMethod.Dynamic,
    DnsSettings = new PublicIPAddressDnsSettings()
    {
        DomainNameLabel = "myDomain"
    }
};
PublicIPAddress publicIPAddress = await publicIPAddressCollection.CreateOrUpdate(publicIPAddressName, publicIPInput).WaitForCompletionAsync();

NetworkInterfaceCollection networkInterfaceCollection = resourceGroup.GetNetworkInterfaces();
string networkInterfaceName = "myNetworkInterface";
NetworkInterfaceData networkInterfaceInput = new NetworkInterfaceData()
{
    Location = resourceGroup.Data.Location,
    IpConfigurations = {
        new NetworkInterfaceIPConfigurationData()
        {
            Name = "ipConfig",
            PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
            PublicIPAddress = new PublicIPAddressData()
            {
                Id = publicIPAddress.Id
            },
            Subnet = new SubnetData()
            {
                // use the virtual network just created
                Id = virtualNetwork.Data.Subnets[0].Id
            }
        }
    }
};
NetworkInterface networkInterface = await networkInterfaceCollection.CreateOrUpdate(networkInterfaceName, networkInterfaceInput).WaitForCompletionAsync();
```

***List all network interfaces***

```C# Snippet:Managing_Networks_ListAllNetworkInterfaces
NetworkInterfaceCollection networkInterfaceCollection = resourceGroup.GetNetworkInterfaces();

AsyncPageable<NetworkInterface> response = networkInterfaceCollection.GetAllAsync();
await foreach (NetworkInterface virtualNetwork in response)
{
    Console.WriteLine(virtualNetwork.Data.Name);
}
```

***Get a network interface***

```C# Snippet:Managing_Networks_GetANetworkInterface
NetworkInterfaceCollection networkInterfaceCollection = resourceGroup.GetNetworkInterfaces();

NetworkInterface virtualNetwork = await networkInterfaceCollection.GetAsync("myVnet");
Console.WriteLine(virtualNetwork.Data.Name);
```

***Try to get a network interface if it exists***

```C# Snippet:Managing_Networks_GetANetworkInterfaceIfExists
NetworkInterfaceCollection networkInterfaceCollection = resourceGroup.GetNetworkInterfaces();

NetworkInterface virtualNetwork = await networkInterfaceCollection.GetIfExistsAsync("foo");
if (virtualNetwork != null)
{
    Console.WriteLine(virtualNetwork.Data.Name);
}

if (await networkInterfaceCollection.CheckIfExistsAsync("bar"))
{
    Console.WriteLine("Network interface 'bar' exists.");
}
```

***Delete a network interface***

```C# Snippet:Managing_Networks_DeleteANetworkInterface
NetworkInterfaceCollection networkInterfaceCollection = resourceGroup.GetNetworkInterfaces();

NetworkInterface virtualNetwork = await networkInterfaceCollection.GetAsync("myVnet");
await virtualNetwork.DeleteAsync();
```
