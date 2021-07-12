Example: Creating a Virtual Network
--------------------------------------

In this example, we'll create a virtual network. Since the SDK follows the resource hierarchy in Azure, we'll need to do this inside of a resource group.

## Import the namespaces
These are the namespaces needed for this project:
```C#
using Azure.Identity;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Network;
using System.Threading.Tasks;
```

In addition, you need to install the `Azure.ResourceManager.Compute` library in your project and import it.

## Create a Resource Group
Start by creating a new resource group, like we did above:

```C# Snippet:Creating_A_Virtual_Network_CreateResourceGroup
var armClient = new ArmClient(new DefaultAzureCredential());
ResourceGroupContainer rgContainer = armClient.DefaultSubscription.GetResourceGroups();
string rgName = "myResourceGroup";
ResourceGroup resourceGroup = await rgContainer.Construct(Location.WestUS2).CreateOrUpdateAsync(rgName);
```
## Create a Virtual Network
Now that we have a resource group, we'll create our virtual network. To do this, we will use a helper method on the container object called `Construct`. The helper method allows us to create the request object and then send that to the `Create` method.

```csharp
VirtualNetworkContainer vnetContainer = resourceGroup.GetVirtualNetworks();
VirtualNetwork virtualNetwork = await vnetContainer
    .Construct("10.0.0.0/16", location)
    .CreateAsync("myVnetName");
```

## Create a Subnet 
Now that we have a virtual network, we must create at least one subnet in order to add any virtual machines.
Following the hierarchy in Azure, subnets belong to a virtual network, so that's where we'll get our `SubnetContainer` instance. After that, we'll again use the `Construct` helper method to create our subnet.

```csharp
string subnetName = "mySubnetName";
SubnetContainer subnetContainer = virtualNetwork.GetSubnets();
Subnet subnet = await subnetContainer
    .Construct("10.0.0.0/24")
    .CreateAsync(subnetName);
```