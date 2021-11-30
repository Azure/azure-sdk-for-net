# Example: Managing the device update instances

>Note: Before getting started with the samples, go through the [prerequisites](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/resourcemanager/Azure.ResourceManager#prerequisites).

Namespaces for this example:
```C# Snippet:Manage_Instances_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.DeviceUpdate;
using Azure.ResourceManager.DeviceUpdate.Models;
```

When you first create your ARM client, choose the subscription you're going to work in. You can use the `GetDefaultSubscription`/`GetDefaultSubscriptionAsync` methods to return the default subscription configured for your user:

```C# Snippet:Readme_DefaultSubscription
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
```

This is a scoped operations object, and any operations you perform will be done under that subscription. From this object, you have access to all children via collection objects. Or you can access individual children by ID.

```C# Snippet:Readme_GetResourceGroupCollection
ResourceGroupCollection rgCollection = subscription.GetResourceGroups();
// With the collection, we can create a new resource group with a specific name
string rgName = "myRgName";
Location location = Location.WestUS2;
ResourceGroupCreateOrUpdateOperation lro = await rgCollection.CreateOrUpdateAsync(rgName, new ResourceGroupData(location));
ResourceGroup resourceGroup = lro.Value;
```

Now that we have the resource group created, we can manage the instances inside this resource group.

***Create an instance***

```C# Snippet:Managing_Instances_CreateAnInstance
// Create a new account
string accountName = "myAccount";
DeviceUpdateAccountData input1 = new DeviceUpdateAccountData(Location.WestUS2);
DeviceUpdateAccountCreateOperation lro1 = await resourceGroup.GetDeviceUpdateAccounts().CreateOrUpdateAsync(accountName, input1);
DeviceUpdateAccount account = lro1.Value;
// Get the instance collection from the specific account and create an instance
string instanceName = "myInstance";
DeviceUpdateInstanceData input2 = new DeviceUpdateInstanceData(Location.WestUS2);
input2.IotHubs.Add(new IotHubSettings("/subscriptions/.../resourceGroups/.../providers/Microsoft.Devices/IotHubs/..."));
DeviceUpdateInstanceCreateOperation lro2 = await account.GetDeviceUpdateInstances().CreateOrUpdateAsync(instanceName, input2);
DeviceUpdateInstance instance = lro2.Value;
```

***List all instances***

```C# Snippet:Managing_Instances_ListAllInstances
// First we need to get the instance collection from the specific account
DeviceUpdateAccount account = await resourceGroup.GetDeviceUpdateAccounts().GetAsync("myAccount");
DeviceUpdateInstanceCollection instanceCollection = account.GetDeviceUpdateInstances();
// With GetAllAsync(), we can get a list of the instances in the collection
AsyncPageable<DeviceUpdateInstance> response = instanceCollection.GetAllAsync();
await foreach (DeviceUpdateInstance instance in response)
{
    Console.WriteLine(instance.Data.Name);
}
```

***Update an instance***

```C# Snippet:Managing_Instances_UpdateAnInstance
// First we need to get the instance collection from the specific account
DeviceUpdateAccount account = await resourceGroup.GetDeviceUpdateAccounts().GetAsync("myAccount");
DeviceUpdateInstanceCollection instanceCollection = account.GetDeviceUpdateInstances();
// Now we can get the instance with GetAsync()
DeviceUpdateInstance instance = await instanceCollection.GetAsync("myInstance");
// With UpdateAsync(), we can update the instance
TagUpdateOptions updateOptions = new TagUpdateOptions();
updateOptions.Tags.Add("newTag", "newValue");
instance = await instance.UpdateAsync(updateOptions);
```

***Delete an instance***

```C# Snippet:Managing_Instances_DeleteAnInstance
// First we need to get the instance collection from the specific account
DeviceUpdateAccount account = await resourceGroup.GetDeviceUpdateAccounts().GetAsync("myAccount");
DeviceUpdateInstanceCollection instanceCollection = account.GetDeviceUpdateInstances();
// Now we can get the instance with GetAsync()
DeviceUpdateInstance instance = await instanceCollection.GetAsync("myInstance");
// With DeleteAsync(), we can delete the instance
await instance.DeleteAsync();
```
