# Example: Managing the device update accounts

>Note: Before getting started with the samples, go through the [prerequisites](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/resourcemanager/Azure.ResourceManager#prerequisites).

Namespaces for this example:
```C# Snippet:Manage_Accounts_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.DeviceUpdate;
using Azure.ResourceManager.DeviceUpdate.Models;
```

When you first create your ARM client, choose the subscription you're going to work in. You can use the `GetDefaultSubscription`/`GetDefaultSubscriptionAsync` methods to return the default subscription configured for your user:

```C# Snippet:Readme_DefaultSubscription
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
```

This is a scoped operations object, and any operations you perform will be done under that subscription. From this object, you have access to all children via collection objects. Or you can access individual children by ID.

```C# Snippet:Readme_GetResourceGroupCollection
ResourceGroupCollection rgCollection = subscription.GetResourceGroups();
// With the collection, we can create a new resource group with a specific name
string rgName = "myRgName";
AzureLocation location = AzureLocation.WestUS2;
ArmOperation<ResourceGroupResource> lro = await rgCollection.CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(location));
ResourceGroupResource resourceGroup = lro.Value;
```

Now that we have the resource group created, we can manage the accounts inside this resource group.

***Create an account***

```C# Snippet:Managing_Accounts_CreateAnAccount
// Get the account collection from the specific resource group and create an account
string accountName = "myAccount";
DeviceUpdateAccountData input = new DeviceUpdateAccountData(AzureLocation.WestUS2);
ArmOperation<DeviceUpdateAccountResource> lro = await resourceGroup.GetDeviceUpdateAccounts().CreateOrUpdateAsync(WaitUntil.Completed, accountName, input);
DeviceUpdateAccountResource account = lro.Value;
```

***List all accounts***

```C# Snippet:Managing_Accounts_ListAllAccounts
// First we need to get the account collection from the specific resource group
DeviceUpdateAccountCollection accountCollection = resourceGroup.GetDeviceUpdateAccounts();
// With GetAllAsync(), we can get a list of the accounts in the collection
AsyncPageable<DeviceUpdateAccountResource> response = accountCollection.GetAllAsync();
await foreach (DeviceUpdateAccountResource account in response)
{
    Console.WriteLine(account.Data.Name);
}
//We can also list all accounts in the subscription
response = subscription.GetDeviceUpdateAccountsAsync();
await foreach (DeviceUpdateAccountResource account in response)
{
    Console.WriteLine(account.Data.Name);
}
```

***Update an account***

```C# Snippet:Managing_Accounts_UpdateAnAccount
// First we need to get the account collection from the specific resource group
DeviceUpdateAccountCollection accountCollection = resourceGroup.GetDeviceUpdateAccounts();
// Now we can get the account with GetAsync()
DeviceUpdateAccountResource account = await accountCollection.GetAsync("myAccount");
// With UpdateAsync(), we can update the account
DeviceUpdateAccountPatch updateOptions = new DeviceUpdateAccountPatch()
{
    Location = AzureLocation.WestUS2,
    Identity = new ManagedServiceIdentity(ResourceManager.Models.ManagedServiceIdentityType.None)
};
ArmOperation<DeviceUpdateAccountResource> lro = await account.UpdateAsync(WaitUntil.Completed, updateOptions);
account = lro.Value;
```

***Delete an account***

```C# Snippet:Managing_Accounts_DeleteAnAccount
// First we need to get the account collection from the specific resource group
DeviceUpdateAccountCollection accountCollection = resourceGroup.GetDeviceUpdateAccounts();
// Now we can get the account with GetAsync()
DeviceUpdateAccountResource account = await accountCollection.GetAsync("myAccount");
// With DeleteAsync(), we can delete the account
await account.DeleteAsync(WaitUntil.Completed);
```


## Next steps
Take a look at the [Managing Device Update Instances](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/deviceupdate/Azure.ResourceManager.DeviceUpdate/samples/Sample2_ManagingDeviceUpdateInstances.md) samples.
