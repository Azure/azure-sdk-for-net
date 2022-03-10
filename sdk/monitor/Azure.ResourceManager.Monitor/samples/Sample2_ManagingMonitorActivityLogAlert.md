# Example: Managing the monitor activity log alerts

>Note: Before getting started with the samples, go through the [prerequisites](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/resourcemanager/Azure.ResourceManager#prerequisites).

Namespaces for this example:
```C# Snippet:Manage_ActivityLogAlerts_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Cdn.Models;
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

Now that we have the resource group created, we can manage the monitor activity log alert  inside this resource group.

***Create a monitor activity log alert ***

```C# Snippet:Managing_ActivityLogAlerts_CreateAnActivityLogAlert
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
// first we need to get the resource group
string rgName = "myRgName";
ResourceGroup resourceGroup = await subscription.GetResourceGroups().GetAsync(rgName);
// Now we get the activity log alert  collection from the resource group
ActivityLogAlertCollection alertCollection = resourceGroup.GetActivityLogAlerts();
// Use the same location as the resource group
string activityLogAlertName = "myActivityLogAlert";
var input = new ActivityLogAlertData("global")
{
            var data = new ActivityLogAlertData(location)
            {
                EmailReceivers =
                {
                    new EmailReceiver("name", "a@b.c")
                },
                Enabled = true,
                GroupShortName = "name"
            };
};
ArmOperation<ActivityLogAlert> lro = await alertCollection.CreateOrUpdateAsync(true, activityLogAlertName, input);
Disk disk = lro.Value;
```

***Delete a disk***

```C# Snippet:Managing_ActivityLogAlerts_DeleteActivityLogAlert
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
// first we need to get the resource group
string rgName = "myRgName";
ResourceGroup resourceGroup = await subscription.GetResourceGroups().GetAsync(rgName);
// Now we get the activityLogAlert collection from the resource group
ActivityLogAlertCollection ActivityLogAlertCollection = resourceGroup.GetActivityLogAlerts();
string alertName = "myActivityLogAlert";
ActivityLogAlert activityLogAlert = await ActivityLogAlertCollection.GetAsync(alertName);
await activityLogAlert.DeleteAsync(true);
```