# Example: Managing the ConfigurationStores

>Note: Before getting started with the samples, go through the [prerequisites](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/resourcemanager/Azure.ResourceManager#prerequisites).

Namespaces for this example:

```C# Snippet:Manage_ConfigurationStores_Namespaces
using System;
using System.Threading.Tasks;
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
Subscription subscription = armClient.GetDefaultSubscriptionAsync().Result;
```

This is a scoped operations object, and any operations you perform will be done under that subscription. From this object, you have access to all children via Collection objects. Or you can access individual children by ID.

```C# Snippet:Readme_GetResourceGroupCollection
ResourceGroupCollection rgCollection = subscription.GetResourceGroups();
// With the Collection, we can create a new resource group with an specific name
string rgName = "myRgName";
Location location = Location.WestUS2;
ResourceGroup resourceGroup = await rgCollection.CreateOrUpdate(rgName, new ResourceGroupData(location)).WaitForCompletionAsync();
```

Now that we have the resource group created, we can manage the ConfigurationStore inside this resource group.

***Create a configurationStore***

```C# Snippet:Managing_ConfigurationStores_CreateAConfigurationStore
string configurationStoreName = ("myApp");
ConfigurationStoreData configurationStoreData = new ConfigurationStoreData("westus", new Sku("Standard"))
{
    PublicNetworkAccess = PublicNetworkAccess.Disabled
};
ConfigurationStore configurationStore = await (await resourceGroup.GetConfigurationStores().CreateOrUpdateAsync(configurationStoreName, configurationStoreData)).WaitForCompletionAsync();
```

***List all configurationStores***

```C# Snippet:Managing_ConfigurationStores_ListAllConfigurationStores
AsyncPageable<ConfigurationStore> configurationStores = resourceGroup.GetConfigurationStores().GetAllAsync();

await foreach (ConfigurationStore item in configurationStores)
{
    Console.WriteLine(item.Data.Name);
}
```

***Get a configurationStore***

```C# Snippet:Managing_ConfigurationStores_GetAConfigurationStore
ConfigurationStore configurationStore = await resourceGroup.GetConfigurationStores().GetAsync("myApp");
Console.WriteLine(configurationStore.Data.Name);
```

***Try to get a configurationStore if it exists***

```C# Snippet:Managing_ConfigurationStores_GetAConfigurationStoreIfExists
ConfigurationStoreCollection configurationStoreCollection = resourceGroup.GetConfigurationStores();

ConfigurationStore configurationStore = await configurationStoreCollection.GetIfExistsAsync("foo");
if (configurationStore != null)
{
    Console.WriteLine(configurationStore.Data.Name);
}

if (await configurationStoreCollection.CheckIfExistsAsync("myApp"))
{
    Console.WriteLine("ConfigurationStore 'myApp' exists.");
}
```

***Delete a configurationStore***

```C# Snippet:Managing_ConfigurationStores_DeleteAConfigurationStore
ConfigurationStoreCollection configurationStoreCollection = resourceGroup.GetConfigurationStores();

ConfigurationStore configStore = await configurationStoreCollection.GetAsync("myApp");
await (await configStore.DeleteAsync()).WaitForCompletionResponseAsync();
```
