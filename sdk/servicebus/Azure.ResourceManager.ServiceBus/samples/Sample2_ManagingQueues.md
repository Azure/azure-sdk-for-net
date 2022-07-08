# Example: Managing the Queues

>Note: Before getting started with the samples, go through the [prerequisites](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/resourcemanager/Azure.ResourceManager#prerequisites).

Namespaces for this example:

```C# Snippet:Managing_ServiceBusNamespaces_Namespaces
using System;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.ServiceBus;
using Azure.ResourceManager.ServiceBus.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
```

When you first create your ARM client, choose the subscription you're going to work in. There's a `GetDefaultSubscription()` method that returns the default subscription configured for your user:

```C# Snippet:Managing_ServiceBusQueues_DefaultSubscription
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
```

This is a scoped operations object, and any operations you perform will be done under that subscription. From this object, you have access to all children via collection objects. Or you can access individual children by ID.

```C# Snippet:Managing_ServiceBusQueues_CreateResourceGroup
string rgName = "myRgName";
AzureLocation location = AzureLocation.WestUS2;
ArmOperation<ResourceGroupResource> operation = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(location));
ResourceGroupResource resourceGroup = operation.Value;
```

After we have the resource group created, we can create a namespace

```C# Snippet:Managing_ServiceBusQueues_CreateNamespace
string namespaceName = "myNamespace";
ServiceBusNamespaceCollection namespaceCollection = resourceGroup.GetServiceBusNamespaces();
ServiceBusNamespaceResource serviceBusNamespace = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, new ServiceBusNamespaceData(location))).Value;
ServiceBusQueueCollection serviceBusQueueCollection = serviceBusNamespace.GetServiceBusQueues();
```

Now that we have a namespace, we can manage the queues inside this namespace.

***Create a queue***

```C# Snippet:Managing_ServiceBusQueues_CreateQueue
string queueName = "myQueue";
ServiceBusQueueResource serviceBusQueue = (await serviceBusQueueCollection.CreateOrUpdateAsync(WaitUntil.Completed, queueName, new ServiceBusQueueData())).Value;
```

***List all queues***

```C# Snippet:Managing_ServiceBusQueues_ListQueues
await foreach (ServiceBusQueueResource serviceBusQueue in serviceBusQueueCollection.GetAllAsync())
{
    Console.WriteLine(serviceBusQueue.Id.Name);
}
```

***Get a queue***

```C# Snippet:Managing_ServiceBusQueues_GetQueue
ServiceBusQueueResource serviceBusQueue = await serviceBusQueueCollection.GetAsync("myQueue");
```

***Delete a queue***

```C# Snippet:Managing_ServiceBusQueues_DeleteQueue
ServiceBusQueueResource serviceBusQueue = await serviceBusQueueCollection.GetAsync("myQueue");
await serviceBusQueue.DeleteAsync(WaitUntil.Completed);
```

## Next steps

Take a look at the [Managing Topics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/servicebus/Azure.ResourceManager.ServiceBus/samples/Sample1_ManagingTopics.md) samples.
