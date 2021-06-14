# Differences between Old and New .NET Management SDK

> Add introduction here

#### **[Resource]Operations**

This represents a service client that is scoped to a particular resource.
You can directly execute all operations on that client without needing to pass in scope
parameters such as subscription id or resource name.

*Old*
```csharp
    ComputeManagementClient computeClient = new ComputeManagementClient(subscriptionId, new DefaultAzureCredential());
    string rgName = "myRgName";
    string vmName = "myVmName";

    // each method we call needs to have the scope passed in to know which vm to operate on
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

    // no longer need to pass in scope parameters since the object knows the scope
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
        // when using a subscription list, I need to parse the resource group from the resource ID in order to execute any operations
        await computeClient.VirtualMachines.StartUpdate(GetResourceGroup(vm.Id), vm.Name, vmUpdate).WaitForCompletionAsync();
    }
```

*New*
```csharp
    Subscription subscription = armClient.DefaultSubscription;

    foreach(VirtualMachine virtualMachine in subscription.ListVirtualMachines())
    {
        // because each object is already scoped I no longer need to pass in those variables
        await virtualMachine.StartAddTag("tagKey", "tagValue").WaitForCompletionAsync();
    }
```