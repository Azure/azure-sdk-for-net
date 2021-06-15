# Differences between current and preview .NET Management SDK

## Structured Resource Identifier
In the past the resource identifier returned by Azure often in a property called Id was returned as a string.
This made it difficult for users to pull out specific pieces of the identifier since they needed
to implement their own parsing logic.  Today instead you can implicitly cast the string into an object
which will do the parsing for you.  There are 3 types of ResourceIdentifiers and they correspond
to which level the resource lives at.  A resource that lives on a tenant will have a **TenantResourceIdentifier**.
A resource that lives under a subscription will have a **SubscriptionResourceIdentifer**.  A resource that lives under
a resource group will have a **ResourceGroupResourceIdentifier**.

You can usually tell by the id string itself which type it is, but if you are unsure you can always cast it onto a **ResourceIdentifier**
and use the Try methods to retrieve the values.

### Casting to a specific type
```csharp
string resourceId = "/subscriptions/aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee/resourceGroups/workshop2021-rg/providers/Microsoft.Network/virtualNetworks/myVnet/subnets/mySubnet";
// We know the subnet is a resource group level identifier since it has a resource group name in its string
ResourceGroupResourceIdentifier id = resourceId;
Console.WriteLine($"Subscription: {id.SubscriptionId}");
Console.WriteLine($"ResourceGroup: {id.ResourceGroupName}");
Console.WriteLine($"Vnet: {id.Parent.Name}");
Console.WriteLine($"Subnet: {id.Name}");
```

### Casting to the base resource identifier
```csharp
string resourceId = "/subscriptions/aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee/resourceGroups/workshop2021-rg/providers/Microsoft.Network/virtualNetworks/myVnet/subnets/mySubnet";
// Assume we don't know what type of resource id we have we can cast to the base type
ResourceIdentifier id = resourceId;
string property;
if(id.TryGetSubscriptionId(out property))
    Console.WriteLine($"Subscription: {property}");
if(id.TryGetResourceGroupName(out property))
    Console.WriteLine($"ResourceGroup: {property}");
Console.WriteLine($"Vnet: {id.Parent.Name}");
Console.WriteLine($"Subnet: {id.Name}");
```

## [Resource]Operations

This represents a service client that is scoped to a particular resource.
You can directly execute all operations on that client without needing to pass in scope
parameters such as subscription id or resource name.

*Old*
```csharp
    ComputeManagementClient computeClient = new ComputeManagementClient(subscriptionId, new DefaultAzureCredential());
    string rgName = "myRgName";
    string vmName = "myVmName";

    // Each method we call needs to have the scope passed in to know which vm to operate on
    await computeClient.StartPowerOff(rgName, vmName).WaitForCompletionAsync();
    await computeClient.StartStart(rgName, vmName).WaitForCompletionAsync();
```

*New*
```csharp
    string rgName = "myRgName";
    string vmName = "myVmName";
    Subscription subscription = armClient.DefaultSubscription;
    ResourceGroup resourceGroup = await subscription.GetResourceGroups().GetAsync(rgName);
    VirtualMachine virtualMachine = await resourceGroup.GetVirtualMachines().GetAsync(vmName);

    // No longer need to pass in scope parameters since the object knows the scope
    await virtualMachine.StartPowerOff().WaitForCompletionAsync();
    await virtualMachine.StartPowerOn().WaitForCompletionAsync();
```

This becomes more pronounced when dealing with list methods and performing operations on the response items.

*Old*
```csharp
    ComputeManagementClient computeClient = new ComputeManagementClient(subscriptionId, new DefaultAzureCredential());
    foreach (VirtualMachine vm in computeClient.VirtualMachines.ListAll())
    {
        VirtualMachineUpdate vmUpdate = new VirtualMachineUpdate();
        vmUpdate.Tags.Add("tagKey", "tagValue");
        // When using a subscription list, I need to parse the resource group from the resource ID in order to execute any operations
        await computeClient.VirtualMachines.StartUpdate(GetResourceGroup(vm.Id), vm.Name, vmUpdate).WaitForCompletionAsync();
    }
```

*New*
```csharp
    Subscription subscription = armClient.DefaultSubscription;

    foreach(VirtualMachine virtualMachine in subscription.ListVirtualMachines())
    {
        // Because each object is already scoped I no longer need to pass in those variables
        await virtualMachine.StartAddTag("tagKey", "tagValue").WaitForCompletionAsync();
    }
```