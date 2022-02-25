Example: Managing Resource Groups
--------------------------------------
For this example, you need the following namespaces:
```C# Snippet:Managing_Resource_Groups_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
```

When you first create your ARM client, choose the subscription you're going to work in. You can use the `GetDefaultSubscription`/`GetDefaultSubscriptionAsync` methods to return the default subscription configured for your user:

```C# Snippet:Managing_Resource_Groups_DefaultSubscription
ArmClient client = new ArmClient(new DefaultAzureCredential());
Subscription subscription = await client.GetDefaultSubscriptionAsync();
```

This is a scoped operations object, and any operations you perform will be done under that subscription. From this object, you have access to all children via collection objects. Or you can access individual children by ID.

```C# Snippet:Managing_Resource_Groups_GetResourceGroupCollection
ArmClient client = new ArmClient(new DefaultAzureCredential());
Subscription subscription = await client.GetDefaultSubscriptionAsync();
ResourceGroupCollection resourceGroups = subscription.GetResourceGroups();

// code omitted for brevity

string resourceGroupName = "myRgName";
ResourceGroup resourceGroup = await resourceGroups.GetAsync(resourceGroupName);
```

Using the collection object, we can perform collection-level operations such as list all of the resource groups or create new ones under our subscription.

***Create a resource group***

```C# Snippet:Managing_Resource_Groups_CreateAResourceGroup
// First, initialize the ArmClient and get the default subscription
ArmClient client = new ArmClient(new DefaultAzureCredential());
// Now we get a ResourceGroup collection for that subscription
Subscription subscription = await client.GetDefaultSubscriptionAsync();
ResourceGroupCollection resourceGroups = subscription.GetResourceGroups();

// With the collection, we can create a new resource group with an specific name
string resourceGroupName = "myRgName";
AzureLocation location = AzureLocation.WestUS2;
ResourceGroupData resourceGroupData = new ResourceGroupData(location);
ArmOperation<ResourceGroup> operation = await resourceGroups.CreateOrUpdateAsync(true, resourceGroupName, resourceGroupData);
ResourceGroup resourceGroup = operation.Value;
```

***List all resource groups***

```C# Snippet:Managing_Resource_Groups_ListAllResourceGroup
// First, initialize the ArmClient and get the default subscription
ArmClient client = new ArmClient(new DefaultAzureCredential());
Subscription subscription = await client.GetDefaultSubscriptionAsync();
// Now we get a ResourceGroup collection for that subscription
ResourceGroupCollection resourceGroups = subscription.GetResourceGroups();
// We can then iterate over this collection to get the resources in the collection
await foreach (ResourceGroup resourceGroup in resourceGroups)
{
    Console.WriteLine(resourceGroup.Data.Name);
}
```

Using the operation object we can perform entity-level operations, such as updating or deleting existing resource groups.

***Update a resource group***

```C# Snippet:Managing_Resource_Groups_UpdateAResourceGroup
// Note: Resource group named 'myRgName' should exist for this example to work.
ArmClient client = new ArmClient(new DefaultAzureCredential());
Subscription subscription = await client.GetDefaultSubscriptionAsync();
ResourceGroupCollection resourceGroups = subscription.GetResourceGroups();
string resourceGroupName = "myRgName";
ResourceGroup resourceGroup = await resourceGroups.GetAsync(resourceGroupName);
resourceGroup = await resourceGroup.AddTagAsync("key", "value");
```

***Delete a resource group***

```C# Snippet:Managing_Resource_Groups_DeleteResourceGroup
ArmClient client = new ArmClient(new DefaultAzureCredential());
Subscription subscription = await client.GetDefaultSubscriptionAsync();
ResourceGroupCollection resourceGroups = subscription.GetResourceGroups();
string resourceGroupName = "myRgName";
ResourceGroup resourceGroup = await resourceGroups.GetAsync(resourceGroupName);
await resourceGroup.DeleteAsync(true);
```
