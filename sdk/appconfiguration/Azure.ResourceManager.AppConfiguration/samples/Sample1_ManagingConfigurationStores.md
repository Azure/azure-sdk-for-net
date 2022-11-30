# Example: Managing the ConfigurationStores

>Note: Before getting started with the samples, go through the [prerequisites](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/resourcemanager/Azure.ResourceManager#prerequisites).

Namespaces for this example:

```C# Snippet:Manage_ConfigurationStores_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.AppConfiguration;
using Azure.ResourceManager.AppConfiguration.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;
```

When you first create your ARM client, choose the subscription you're going to work in. There's a convenient `DefaultSubscription` property that returns the default subscription configured for your user:

```C# Snippet:Readme_DefaultSubscription
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = armClient.GetDefaultSubscriptionAsync().Result;
```

This is a scoped operations object, and any operations you perform will be done under that subscription. From this object, you have access to all children via Collection objects. Or you can access individual children by ID.

```C# Snippet:Readme_GetResourceGroupCollection
ResourceGroupCollection rgCollection = subscription.GetResourceGroups();
// With the Collection, we can create a new resource group with an specific name
string rgName = "myRgName";
AzureLocation location = AzureLocation.WestUS2;
ResourceGroupResource resourceGroup = (await rgCollection.CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(location))).Value;
```

Now that we have the resource group created, we can manage the ConfigurationStore inside this resource group.

***Create a configurationStore***

```C# Snippet:Managing_ConfigurationStores_CreateAConfigurationStore
string configurationStoreName = ("myApp");
AppConfigurationStoreData configurationStoreData = new AppConfigurationStoreData("westus", new AppConfigurationSku("Standard"))
{
    PublicNetworkAccess = AppConfigurationPublicNetworkAccess.Disabled
};
AppConfigurationStoreResource configurationStore = (await resourceGroup.GetAppConfigurationStores().CreateOrUpdateAsync(WaitUntil.Completed, configurationStoreName, configurationStoreData)).Value;
```

***List all configurationStores***

```C# Snippet:Managing_ConfigurationStores_ListAllConfigurationStores
AsyncPageable<AppConfigurationStoreResource> configurationStores = resourceGroup.GetAppConfigurationStores().GetAllAsync();

await foreach (AppConfigurationStoreResource item in configurationStores)
{
    Console.WriteLine(item.Data.Name);
}
```

***Get a configurationStore***

```C# Snippet:Managing_ConfigurationStores_GetAConfigurationStore
AppConfigurationStoreResource configurationStore = await resourceGroup.GetAppConfigurationStores().GetAsync("myApp");
Console.WriteLine(configurationStore.Data.Name);
```

***Delete a configurationStore***

```C# Snippet:Managing_ConfigurationStores_DeleteAConfigurationStore
AppConfigurationStoreCollection configurationStoreCollection = resourceGroup.GetAppConfigurationStores();

AppConfigurationStoreResource configStore = await configurationStoreCollection.GetAsync("myApp");
await configStore.DeleteAsync(WaitUntil.Completed);
```
