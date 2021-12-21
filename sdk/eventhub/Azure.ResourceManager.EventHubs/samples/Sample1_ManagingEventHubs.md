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

When you first create your ARM client, choose the subscription you're going to work in. There's a convenient `GetDefaultSubscription` method that returns the default subscription configured for your user:

```C# Snippet:Managing_EventHubs_DefaultSubscription
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
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
EventHubNamespaceCollection namespaceCollection = resourceGroup.GetEventHubNamespaces();
EventHubNamespace eHNamespace = (await namespaceCollection.CreateOrUpdateAsync(namespaceName, new EventHubNamespaceData(location))).Value;
EventHubCollection eventHubCollection = eHNamespace.GetEventHubs();
```

Now that we have the namespace, we can manage the event hubs inside this namespace.

***Create an eventhub***

```C# Snippet:Managing_EventHubs_CreateEventHub
string eventhubName = "myEventhub";
EventHub eventHub = (await eventHubCollection.CreateOrUpdateAsync(eventhubName, new EventHubData())).Value;
```

***List all eventhubs***

```C# Snippet:Managing_EventHubs_ListEventHubs
await foreach (EventHub eventHub in eventHubCollection.GetAllAsync())
{
    Console.WriteLine(eventHub.Id.Name);
}
```

***Get an eventhub***

```C# Snippet:Managing_EventHubs_GetEventHub
EventHub eventHub = await eventHubCollection.GetAsync("myEventHub");
```

***Try to get an eventhub if it exists***

```C# Snippet:Managing_EventHubs_GetEventHubIfExists
EventHub eventHub = await eventHubCollection.GetIfExistsAsync("foo");
if (eventHub != null)
{
    Console.WriteLine("eventHub 'foo' exists");
}
if (await eventHubCollection.CheckIfExistsAsync("bar"))
{
    Console.WriteLine("eventHub 'bar' exists");
}
```

***Delete an eventhub***

```C# Snippet:Managing_EventHubs_DeleteEventHub
EventHub eventHub = await eventHubCollection.GetAsync("myEventhub");
await eventHub.DeleteAsync();
```

