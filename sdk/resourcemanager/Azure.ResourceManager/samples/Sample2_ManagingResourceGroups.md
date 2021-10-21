Example: Managing Resource Groups
--------------------------------------
For this example, you need the following namespaces:
```C# Snippet:Managing_Resource_Groups_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
```

When you first create your ARM client, choose the subscription you're going to work in. You can use the `GetDefaultSubscription`/`GetDefaultSubscriptionAsync` methods to return the default subscription configured for your user:

```C# Snippet:Managing_Resource_Groups_DefaultSubscription
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
```

This is a scoped operations object, and any operations you perform will be done under that subscription. From this object, you have access to all children via container objects. Or you can access individual children by ID.

```C# Snippet:Managing_Resource_Groups_GetResourceGroupContainer
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
ResourceGroupContainer rgContainer = subscription.GetResourceGroups();

// code omitted for brevity

string rgName = "myRgName";
ResourceGroup resourceGroup = await rgContainer.GetAsync(rgName);
```

Using the container object, we can perform collection-level operations such as list all of the resource groups or create new ones under our subscription.

***Create a resource group***

```C# Snippet:Managing_Resource_Groups_CreateAResourceGroup
// First, initialize the ArmClient and get the default subscription
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
// Now we get a ResourceGroup container for that subscription
Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
ResourceGroupContainer rgContainer = subscription.GetResourceGroups();

// With the container, we can create a new resource group with an specific name
string rgName = "myRgName";
Location location = Location.WestUS2;
ResourceGroupData rgData = new ResourceGroupData(location);
ResourceGroupCreateOrUpdateOperation operation = await rgContainer.CreateOrUpdateAsync(rgName, rgData);
ResourceGroup resourceGroup = operation.Value;
```

***List all resource groups***

```C# Snippet:Managing_Resource_Groups_ListAllResourceGroup
// First, initialize the ArmClient and get the default subscription
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
// Now we get a ResourceGroup container for that subscription
ResourceGroupContainer rgContainer = subscription.GetResourceGroups();
// With GetAllAsync(), we can get a list of the resources in the container
await foreach (ResourceGroup rg in rgContainer.GetAllAsync())
{
    Console.WriteLine(rg.Data.Name);
}
```

Using the operation object we can perform entity-level operations, such as updating or deleting existing resource groups.

***Update a resource group***

```C# Snippet:Managing_Resource_Groups_UpdateAResourceGroup
// Note: Resource group named 'myRgName' should exist for this example to work.
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
string rgName = "myRgName";
ResourceGroup resourceGroup = await subscription.GetResourceGroups().GetAsync(rgName);
resourceGroup = await resourceGroup.AddTagAsync("key", "value");
```

***Delete a resource group***

```C# Snippet:Managing_Resource_Groups_DeleteResourceGroup
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
string rgName = "myRgName";
ResourceGroup resourceGroup = await subscription.GetResourceGroups().GetAsync(rgName);
await resourceGroup.DeleteAsync();
```
