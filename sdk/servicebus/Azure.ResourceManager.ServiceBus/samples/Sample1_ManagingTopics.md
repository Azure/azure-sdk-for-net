# Example: Managing the Topics

>Note: Before getting started with the samples, go through the [prerequisites](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/resourcemanager/Azure.ResourceManager#prerequisites).

Namespaces for this example:

```C# Snippet:Managing_StorageAccounts_NameSpaces
using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.ResourceManager.Storage.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;
using Sku = Azure.ResourceManager.Storage.Models.Sku;
```

When you first create your ARM client, choose the subscription you're going to work in. There's a `GetDefaultSubscription()` method that returns the default subscription configured for your user:

```C# Snippet:Managing_ServiceBusTopics_DefaultSubscription
```

This is a scoped operations object, and any operations you perform will be done under that subscription. From this object, you have access to all children via collection objects. Or you can access individual children by ID.

```C# Snippet:Managing_ServiceBusTopics_CreateResourceGroup
```

After we have the resource group created, we can create a namespace

```C# Snippet:Managing_ServiceBusTopics_CreateNamespace
```

Now that we have a namespace, we can manage the topics inside this namespace.

***Create a topic***

```C# Snippet:Managing_ServiceBusTopics_CreateTopic
```

***List all topics***

```C# Snippet:Managing_ServiceBusTopics_ListTopics
```

***Get a topic***

```C# Snippet:Managing_ServiceBusTopics_GetTopic
```

***Try to get a topic if it exists***

```C# Snippet:Managing_ServiceBusTopics_GetTopicIfExists
```

***Delete a blob container***

```C# Snippet:Managing_ServiceBusTopics_DeleteTopic
```

## Next steps

Take a look at the [Managing Queues](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Azure.ResourceManager.Storage/samples/Sample2_ManagingFileShares.md) samples.
