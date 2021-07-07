Example: Creating a Virtual Network
--------------------------------------

In this example, we'll create a virtual network. Since the SDK follows the resource hierarchy in Azure, we'll need to do this inside of a resource group. Start by creating a new resource group, like we did above:

```C#

```

Now that we have a resource group, we'll create our virtual network. To do this, we will use a helper method on the container object called `Construct`. The helper method allows us to create the request object and then send that to the `Create` method.

```csharp
VirtualNetworkContainer vnetContainer = resourceGroup.GetVirtualNetworks();
VirtualNetwork virtualNetwork = await vnetContainer
    .Construct("10.0.0.0/16", location)
    .CreateAsync("myVnetName");
```

Now that we have a virtual network, we must create at least one subnet in order to add any virtual machines.
Following the hierarchy in Azure, subnets belong to a virtual network, so that's where we'll get our `SubnetContainer` instance. After that, we'll again use the `Construct` helper method to create our subnet.

```csharp
string subnetName = "mySubnetName";
SubnetContainer subnetContainer = virtualNetwork.GetSubnets();
Subnet subnet = await subnetContainer
    .Construct("10.0.0.0/24")
    .CreateAsync(subnetName);
```
