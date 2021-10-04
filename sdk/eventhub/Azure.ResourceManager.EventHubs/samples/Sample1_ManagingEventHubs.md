# Example: Managing the Event Hubs
>Note: Before getting started with the samples, go through the [prerequisites](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/resourcemanager/Azure.ResourceManager#prerequisites).

Namespaces for this example:

```C# Snippet:Managing_Namespaces_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.ResourceManager.EventHubs.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;
```

When you first create your ARM client, choose the subscription you're going to work in. There's a convenient `DefaultSubscription` property that returns the default subscription configured for your user:

```C# Snippet:Managing_EventHubs_DefaultSubscription
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = armClient.DefaultSubscription;
```

This is a scoped operations object, and any operations you perform will be done under that subscription. From this object, you have access to all children via container objects. Or you can access individual children by ID.

```C# Snippet:Managing_EventHubs_CreateResourceGroup
string rgName = "myRgName";
Location location = Location.WestUS2;
ResourceGroupCreateOrUpdateOperation operation = await subscription.GetResourceGroups().CreateOrUpdateAsync(rgName, new ResourceGroupData(location));
ResourceGroup resourceGroup = operation.Value;
```

After we have the resource group created, we can create a namespace

```C# Snippet:Managing_EventHubs_CreateNamespace
string namespaceName = "myNamespace";
EHNamespaceContainer namespaceContainer = resourceGroup.GetEHNamespaces();
EHNamespace eHNamespace = (await namespaceContainer.CreateOrUpdateAsync(namespaceName, new EHNamespaceData(location))).Value;
EventhubContainer eventhubContainer = eHNamespace.GetEventhubs();
```

Now that we have the namespace, we can manage the event hubs inside this namespace.

***Create an event hub***

```C# Snippet:Managing_EventHubs_CreateEventHub
string eventhubName = "myEventhub";
Eventhub eventhub = (await eventhubContainer.CreateOrUpdateAsync(eventhubName, new EventhubData())).Value;
```

***List all event hubs***

```C# Snippet:Managing_EventHubs_ListEventHubs
await foreach (Eventhub eventhub in eventhubContainer.GetAllAsync())
{
    Console.WriteLine(eventhub.Id.Name);
}
```

***Get an event hub***

```C# Snippet:Managing_EventHubs_GetEventHub
Eventhub eventhub = await eventhubContainer.GetAsync("myEventhub");
```

***Try to get an event hub if it exists***

```C# Snippet:Managing_EventHubs_GetEventHubIfExists
Eventhub eventhub = await eventhubContainer.GetIfExistsAsync("foo");
if (eventhub != null)
{
    Console.WriteLine("eventhub 'foo' exists");
}
if (await eventhubContainer.CheckIfExistsAsync("bar"))
{
    Console.WriteLine("eventhub 'bar' exists");
}
```

***Delete an event hub***

```C# Snippet:Managing_EventHubs_DeleteEventHub
Eventhub eventhub = await eventhubContainer.GetAsync("myEventhub");
await eventhub.DeleteAsync();
```

