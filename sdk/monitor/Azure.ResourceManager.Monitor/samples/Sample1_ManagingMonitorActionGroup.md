# Example: Managing the monitor action groups

>Note: Before getting started with the samples, go through the [prerequisites](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/resourcemanager/Azure.ResourceManager#prerequisites).

Namespaces for this example:
```C# Snippet:Manage_ActionGroups_Namespaces
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Monitor.Models;
using Azure.ResourceManager.Monitor.Tests;
using NUnit.Framework;
```

When you first create your ARM client, choose the subscription you're going to work in. There's a convenient `DefaultSubscription` property that returns the default subscription configured for your user:

```C# Snippet:Readme_DefaultSubscription
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
```

This is a scoped operations object, and any operations you perform will be done under that subscription. From this object, you have access to all children via container objects. Or you can access individual children by ID.

```C# Snippet:Readme_GetResourceGroupCollection
ResourceGroupCollection rgCollection = subscription.GetResourceGroups();
// With the collection, we can create a new resource group with a specific name
string rgName = "myRgName";
AzureLocation location = AzureLocation.EastUS2;
ArmOperation<ResourceGroup> lro = await rgCollection.CreateOrUpdateAsync(true, rgName, new ResourceGroupData(location));
ResourceGroup resourceGroup = lro.Value;
```

Now that we have the resource group created, we can manage the monitor action group inside this resource group.

***Create a monitor action group***

```C# Snippet:Managing_ActionGroups_CreateAnActionGroup
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
// first we need to get the resource group
string rgName = "myRgName";
ResourceGroup resourceGroup = await subscription.GetResourceGroups().GetAsync(rgName);
// Now we get the action group collection from the resource group
ActionGroupCollection actionCollection = resourceGroup.GetActionGroups();
// Use the same location as the resource group
string actionGroupName = "myActionGroup";
var input = new ActionGroupData("global")
{
            var data = new ActionGroupData(location)
            {
                EmailReceivers =
                {
                    new EmailReceiver("name", "a@b.c")
                },
                Enabled = true,
                GroupShortName = "name"
            };
};
ArmOperation<ActionGroup> lro = await actionCollection.CreateOrUpdateAsync(true, actionGroupName, input);
Disk disk = lro.Value;
```

***Delete a disk***

```C# Snippet:Managing_ActionGroups_DeleteActionGroup
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
// first we need to get the resource group
string rgName = "myRgName";
ResourceGroup resourceGroup = await subscription.GetResourceGroups().GetAsync(rgName);
// Now we get the actionGroup collection from the resource group
ActionGroupCollection actionGroupCollection = resourceGroup.GetActionGroups();
string actionName = "myActionGroup";
ActionGroup actionGroup = await actionGroupCollection.GetAsync(actionName);
await actionGroup.DeleteAsync(true);
```


## Next steps

Take a look at the [Managing Monitor ActivityLogAlerts](https://github.com/Azure/azure-sdk-for-net/blob/Zihewang_Monitor_Test/sdk/monitor/Azure.ResourceManager.Monitor/samples/Sample1_ManagingMonitorActionGroup.md) samples.