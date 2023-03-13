# Example: Managing the ManagedInstance

>Note: Before getting started with the samples, go through the [prerequisites](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/resourcemanager/Azure.ResourceManager#prerequisites).

Namespaces for this example:
```C# Snippet:Manage_CommunicationDomain_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.Communication.Models;
using Azure.ResourceManager.Resources;
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

Now that we have the resource group created, we can manage the Email Service inside this resource group.

```C# Snippet:Managing_CommunicationDomain_CreateOrUpdateCommunicationDomain
CommunicationDomainResourceCollection collection = await resourceGroup.GetCommunicationDomainResourcesAsync();
string CommunicationDomainName = "myCommunicationDomain";
CommunicationDomainResourceData data = new CommunicationDomainResourceData("global")
{
    DataLocation = "UnitedStates",
};
ArmOperation<CommunicationDomainResource> CommunicationDomainOp = await collection.CreateOrUpdateAsync(WaitUntil.Completed, CommunicationDomainName, data);
CommunicationDomainResource CommunicationDomainOp = CommunicationDomainOp.Value;
```

***List all COmmunicationDomauin***

```C# Snippet:Managing_CommunicationDomain_ListAllCommunicationDomain
CommunicationDomainResourceCollection collection = await resourceGroup.GetCommunicationDomainResourcesAsync();
string CommunicationDomainName = "myCommunicationDomain";

AsyncPageable<CommunicationDomainResource> list = collection.GetAllAsync();
await foreach (CommunicationDomainResource CommunicationDomain  in list)
{
    Console.WriteLine(CommunicationDomain.Data.Name);
}
```

***Delete a COmmunicationDomauin ***

```C# Snippet:Managing_CommunicationDomain_DeleteAnApplicationDefinition
CommunicationDomainResourceCollection collection = await resourceGroup.GetCommunicationDomainResourcesAsync();
string CommunicationDomainName = "myCommunicationDomain";

CommunicationDomainResource CommunicationDomain = await collection.GetAsync("myCommunicationDomain");
await CommunicationDomain.DeleteAsync(WaitUntil.Completed);
```
