# Example: Managing the ManagedInstance

>Note: Before getting started with the samples, go through the [prerequisites](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/resourcemanager/Azure.ResourceManager#prerequisites).

Namespaces for this example:
```C# Snippet:Manage_CommunicationService_Namespaces
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
Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
```

This is a scoped operations object, and any operations you perform will be done under that subscription. From this object, you have access to all children via collection objects. Or you can access individual children by ID.

```C# Snippet:Readme_GetResourceGroupCollection
ResourceGroupCollection rgCollection = subscription.GetResourceGroups();
// With the collection, we can create a new resource group with an specific name
string rgName = "myRgName";
AzureLocation location = AzureLocation.WestUS2;
ResourceGroupCreateOrUpdateOperation lro = await rgCollection.CreateOrUpdateAsync(true,rgName, new ResourceGroupData(location));
ResourceGroup resourceGroup = lro.Value;
```

Now that we have the resource group created, we can manage the Communication Service inside this resource group.

***Create a Communication Service***

```C# Snippet:Managing_CommunicationService_CreateAnApplicationDefinition
CommunicationServiceCollection collection = resourceGroup.GetCommunicationServices();
string communicationServiceName = "myCommunicationService";
CommunicationServiceData data = new CommunicationServiceData()
{
    Location = "global",
    DataLocation = "UnitedStates",
};
CommunicationServiceCreateOrUpdateOperation communicationServiceLro = await collection.CreateOrUpdateAsync(true, communicationServiceName, data);
CommunicationService communicationService = communicationServiceLro.Value;
```

***List all Communication Service***

```C# Snippet:Managing_CommunicationService_ListAllCommunicationService
CommunicationServiceCollection collection = resourceGroup.GetCommunicationServices();

AsyncPageable<CommunicationService> list = collection.GetAllAsync();
await foreach (CommunicationService communicationService  in list)
{
    Console.WriteLine(communicationService.Data.Name);
}
```

***Delete a Communication Service***

```C# Snippet:Managing_CommunicationService_DeleteAnApplicationDefinition
CommunicationServiceCollection collection = resourceGroup.GetCommunicationServices();

CommunicationService communicationService = await collection.GetAsync("myCommunicationService");
await communicationService.DeleteAsync(true);
```
