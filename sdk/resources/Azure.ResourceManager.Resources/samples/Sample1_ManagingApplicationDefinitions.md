# Example: Managing the application definitions

>Note: Before getting started with the samples, go through the [prerequisites](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/resourcemanager/Azure.ResourceManager#prerequisites).

Namespaces for this example:
```C# Snippet:Manage_ApplicationDefinitions_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;
```

When you first create your ARM client, choose the subscription you're going to work in. You can use the `GetDefaultSubscription`/`GetDefaultSubscriptionAsync` methods to return the default subscription configured for your user:

```C# Snippet:Readme_DefaultSubscription
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
```

This is a scoped operations object, and any operations you perform will be done under that subscription. From this object, you have access to all children via collection objects. Or you can access individual children by ID.

```C# Snippet:Readme_GetResourceGroupCollection
ResourceGroupCollection rgCollection = subscription.GetResourceGroups();
// With the collection, we can create a new resource group with an specific name
string rgName = "myRgName";
AzureLocation location = AzureLocation.WestUS2;
ArmOperation<ResourceGroupResource> lro = await rgCollection.CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(location));
ResourceGroupResource resourceGroup = lro.Value;
```

Now that we have the resource group created, we can manage the application definitions inside this resource group.

***Create an application definition***

```C# Snippet:Managing_ApplicationDefinitions_CreateAnApplicationDefinition
// First we need to get the application definition collection from the resource group
ArmApplicationDefinitionCollection applicationDefinitionCollection = resourceGroup.GetArmApplicationDefinitions();
// Use the same location as the resource group
string applicationDefinitionName = "myApplicationDefinition";
var input = new ArmApplicationDefinitionData(resourceGroup.Data.Location, ArmApplicationLockLevel.None)
{
    DisplayName = applicationDefinitionName,
    Description = $"{applicationDefinitionName} description",
    PackageFileUri = new Uri("https://raw.githubusercontent.com/Azure/azure-managedapp-samples/master/Managed%20Application%20Sample%20Packages/201-managed-storage-account/managedstorage.zip")
};
ArmOperation<ArmApplicationDefinitionResource> lro = await applicationDefinitionCollection.CreateOrUpdateAsync(WaitUntil.Completed, applicationDefinitionName, input);
ArmApplicationDefinitionResource applicationDefinition = lro.Value;
```

***List all application definitions***

```C# Snippet:Managing_ApplicationDefinitions_ListAllApplicationDefinitions
// First we need to get the application definition collection from the resource group
ArmApplicationDefinitionCollection applicationDefinitionCollection = resourceGroup.GetArmApplicationDefinitions();
// With GetAllAsync(), we can get a list of the application definitions in the collection
AsyncPageable<ArmApplicationDefinitionResource> response = applicationDefinitionCollection.GetAllAsync();
await foreach (ArmApplicationDefinitionResource applicationDefinition in response)
{
    Console.WriteLine(applicationDefinition.Data.Name);
}
```

***Delete an application definition***

```C# Snippet:Managing_ApplicationDefinitions_DeleteAnApplicationDefinition
// First we need to get the application definition collection from the resource group
ArmApplicationDefinitionCollection applicationDefinitionCollection = resourceGroup.GetArmApplicationDefinitions();
// Now we can get the application definition with GetAsync()
ArmApplicationDefinitionResource applicationDefinition = await applicationDefinitionCollection.GetAsync("myApplicationDefinition");
// With DeleteAsync(), we can delete the application definition
await applicationDefinition.DeleteAsync(WaitUntil.Completed);
```


## Next steps
Take a look at the [Managing Deployments](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resources/Azure.ResourceManager.Resources/samples/Sample2_ManagingDeployments.md) samples.
