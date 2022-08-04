# Example: Managing the Topics

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

```C# Snippet:Managing_ServiceBusTopics_DefaultSubscription
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
```

This is a scoped operations object, and any operations you perform will be done under that subscription. From this object, you have access to all children via collection objects. Or you can access individual children by ID.

```C# Snippet:Managing_ServiceBusTopics_CreateResourceGroup
string rgName = "myRgName";
AzureLocation location = AzureLocation.WestUS2;
ArmOperation<ResourceGroupResource> operation = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(location));
ResourceGroupResource resourceGroup = operation.Value;
```

After we have the resource group created, we can create a namespace

```C# Snippet:Managing_ServiceBusTopics_CreateNamespace
string namespaceName = "myNamespace";
ServiceBusNamespaceCollection namespaceCollection = resourceGroup.GetServiceBusNamespaces();
ServiceBusNamespaceResource serviceBusNamespace = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, new ServiceBusNamespaceData(location))).Value;
ServiceBusTopicCollection serviceBusTopicCollection = serviceBusNamespace.GetServiceBusTopics();
```

Now that we have a namespace, we can manage the topics inside this namespace.

***Create a topic***

```C# Snippet:Managing_ServiceBusTopics_CreateTopic
string topicName = "myTopic";
ServiceBusTopicResource serviceBusTopic = (await serviceBusTopicCollection.CreateOrUpdateAsync(WaitUntil.Completed, topicName, new ServiceBusTopicData())).Value;
```

***List all topics***

```C# Snippet:Managing_ServiceBusTopics_ListTopics
await foreach (ServiceBusTopicResource serviceBusTopic in serviceBusTopicCollection.GetAllAsync())
{
    Console.WriteLine(serviceBusTopic.Id.Name);
}
```

***Get a topic***

```C# Snippet:Managing_ServiceBusTopics_GetTopic
ServiceBusTopicResource serviceBusTopic = await serviceBusTopicCollection.GetAsync("myTopic");
```

***Delete a blob container***

```C# Snippet:Managing_ServiceBusTopics_DeleteTopic
ServiceBusTopicResource serviceBusTopic = await serviceBusTopicCollection.GetAsync("myTopic");
await serviceBusTopic.DeleteAsync(WaitUntil.Completed);
```

## Next steps

Take a look at the [Managing Queues](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/servicebus/Azure.ResourceManager.ServiceBus/samples/Sample2_ManagingQueues.md) samples.
