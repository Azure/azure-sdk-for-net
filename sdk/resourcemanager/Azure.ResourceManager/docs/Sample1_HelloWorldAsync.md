# Example: Getting a subscription

>Note: Before getting started with the samples, go through the [prerequisites](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/resourcemanager/Azure.ResourceManager#prerequisites).

Namespaces for this example:
```C# Snippet:Hello_World_Async_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.ResourceManager.Resources;
```

The following code shows how to get the default subscription:

```C# Snippet:Hello_World_Async_DefaultSubscription
ArmClient client = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = await client.GetDefaultSubscriptionAsync();
Console.WriteLine(subscription.Id);
```

It's possible to get a specific subscription as follows:

```C# Snippet:Hello_World_Async_SpecificSubscription
string subscriptionId = "your-subscription-id";
ArmClient client = new ArmClient(new DefaultAzureCredential());
SubscriptionCollection subscriptions = client.GetSubscriptions();
SubscriptionResource subscription = await subscriptions.GetAsync(subscriptionId);
Console.WriteLine(subscription.Id);
```

You can also specify the default subscription when creating the ArmClient:

```C# Snippet:Hello_World_Async_SpecifyDefaultSubscription
string defaultSubscriptionId = "your-subscription-id";
ArmClient client = new ArmClient(new DefaultAzureCredential(), defaultSubscriptionId);
SubscriptionResource subscription = await client.GetDefaultSubscriptionAsync();
Console.WriteLine(subscription.Id);
```

With the `Async` suffix on methods that perform API calls, it's possible to differentiate the asynchronous and synchronous variants of any method.

From here, it is possible to get the resource groups from the retrieved subscription:

```C# Snippet:Hello_World_Async_ResourceGroupCollection
ResourceGroupCollection resourceGroups = subscription.GetResourceGroups();
```

## Next steps
Take a look at the [Managing Resource Groups](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/docs/Sample2_ManagingResourceGroups.md) samples.
