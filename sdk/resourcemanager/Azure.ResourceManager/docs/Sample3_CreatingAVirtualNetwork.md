Example: Creating a Virtual Network
--------------------------------------

In this example, we'll create a virtual network. Since the SDK follows the resource hierarchy in Azure, we'll need to do this inside of a resource group.

## Import the namespaces
These are the namespaces needed for this project:
```C# Snippet:Creating_A_Virtual_Network_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Resources;
```

## Create a Resource Group
Start by creating a new resource group, like we did above:

```C# Snippet:Creating_A_Virtual_Network_CreateResourceGroup
ArmClient client = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = await client.GetDefaultSubscriptionAsync();
ResourceGroupCollection resourceGroups = subscription.GetResourceGroups();

string resourceGroupName = "myResourceGroup";
ResourceGroupData resourceGroupData = new ResourceGroupData(AzureLocation.WestUS2);
ArmOperation<ResourceGroupResource> operation = await resourceGroups.CreateOrUpdateAsync(WaitUntil.Completed, resourceGroupName, resourceGroupData);
ResourceGroupResource resourceGroup = operation.Value;
```
## Create a Virtual Network
Now that we have a resource group, we'll create our virtual network. To do this, we will create a `VirtualNetworkData` object for the parameters that we want our Virtual Network to have, then we will get the Virtual Network collection and from there we call `CreateOrUpdateAsync()`.

```C# Snippet:Creating_A_Virtual_Network_CreateVirtualNetwork
string vnetName = "myVnetName";
VirtualNetworkData virtualNetworkData = new VirtualNetworkData()
{
    // You can specify many options for the Virtual Network in here
    Location = "WestUS2",
    AddressPrefixes = { "10.0.0.0/16", }
};

ArmOperation<VirtualNetworkResource> armOperation = await resourceGroup.GetVirtualNetworks().CreateOrUpdateAsync(WaitUntil.Completed, vnetName, virtualNetworkData);
VirtualNetworkResource virtualNetworkResource = armOperation.Value;
```

## Create a Subnet 
Now that we have a virtual network, we must create at least one subnet in order to add any virtual machines.
Following the hierarchy in Azure, subnets belong to a virtual network, so that's where we'll get our `SubnetCollection` instance. Before that, a `SubnetData` object must be created to specify the parameters for the Subnet.

```C# Snippet:Creating_A_Virtual_Network_CreateSubnet
string subnetName = $"{vnetName}_Subnet1";
SubnetData subnetData = new SubnetData()
{
    Name = subnetName,
    AddressPrefix = "10.0.1.0/24"
};

ArmOperation<SubnetResource> armOperation = await virtualNetworkResource.GetSubnets().CreateOrUpdateAsync(WaitUntil.Completed, subnetName, subnetData);
SubnetResource subnetResource = armOperation.Value;
```

## Another way to create a Virtual Network with a Subnet
It is possible to define an create a virtual network with its subnets in a single step. This is achieved by defining the subnets in the `VirtualNetworkData` object that is given as a parameter.

```C# Snippet:Creating_A_Virtual_Network_CreateSubnetByAnotherWay
string vnetName = "myVnetName";
string subnet1Name = $"{vnetName}_Subnet1";

VirtualNetworkData virtualNetworkData = new VirtualNetworkData()
{
    Location = "WestUS2",
    AddressPrefixes = { "10.0.0.0/16" },
    Subnets =
    {
        new SubnetData
        {
            Name = subnet1Name,
            AddressPrefix = "10.0.0.0/24"
        }
    }
};

ArmOperation<VirtualNetworkResource> armOperation = await resourceGroup.GetVirtualNetworks().CreateOrUpdateAsync(WaitUntil.Completed, vnetName, virtualNetworkData);
VirtualNetworkResource virtualNetworkResource = armOperation.Value;
```
### Modifying the Subnets of an existing Virtual Network
Using the SubnetCollection it is possible to add a subnet into the virtual network we created above.
```C# Snippet:Creating_A_Virtual_Network_ModifyingSubnetsInVirtualNetwork
string subnet2Name = $"{vnetName}_Subnet2";
SubnetData subnetData = new SubnetData()
{
    Name = subnet2Name,
    AddressPrefix = "10.0.1.0/24"
};

ArmOperation<SubnetResource> armOperation = await virtualNetworkResource.GetSubnets().CreateOrUpdateAsync(WaitUntil.Completed, subnet2Name, subnetData);
SubnetResource subnetResource = armOperation.Value;
```

You can verify that your virtual network now has 2 subnets by doing the following: 
```C# Snippet:Creating_A_Virtual_Network_GetAllSubnetsCount
VirtualNetworkResource virtualNetworkResource = await resourceGroup.GetVirtualNetworks().GetAsync(vnetName);
Console.WriteLine(virtualNetworkResource.Data.Subnets.Count);
```

## Next steps
Take a look at the [Authenticate across tenants](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/docs/Sample4_MultiTenant.md) samples.
