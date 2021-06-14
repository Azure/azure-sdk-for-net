Example: Creating a Virtual Network
--------------------------------------

In this example we will be create a VirtualNetwork.  Since the SDK follows the resource
hierarchy in Azure, we will need to do this inside of a ResourceGroup.  We will start by creating
a new resource group like we did above

```csharp
    ArmClient armClient = new ArmClient(new DefaultAzureCredential());
    ResourceGroupContainer rgContainer = armClient.DefaultSubscription.GetResourceGroups();
    ResourceGroup resourceGroup = await rgContainer.Construct(LocationData.WestUS2).CreateAsync(rg);
```

Now that we have a ResourceGroup we will now create our VirtualNetwork.  To do this we will use
a helper method on the container object called Construct(...) which will allow us to create the request
object and then send that to the Create(...) method.

```csharp
    VirtualNetworkContainer vnetContainer = resourceGroup.GetVirtualNetworks();
    VirtualNetwork virtualNetwork = await vnetContainer
        .Construct("10.0.0.0/16", location)
        .CreateAsync("myVnetName");
```

Now that we have a VirtualNetwork we must create at least one Subnet in order to add any VirtualMachines.
Again following the hierarchy in Azure Subnets belong to a VirtualNetwork so that is where we will
get our SubnetContainer instance.  After that we will again take advantage of the Construct(...) helper
to create our Subnet.

```csharp
    string subnetName = "mySubnetName";
    SubnetContainer subnetContainer = virtualNetwork.GetSubnets();
    Subnet subnet = await subnetContainer
        .Construct("10.0.0.0/24")
        .CreateAsync(subnetName);
```