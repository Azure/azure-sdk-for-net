# Example: Getting a subscription

>Note: Before getting started with the samples, make sure to go trough the [prerequisites](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/resourcemanager/Azure.ResourceManager#prerequisites).

Namespaces for this example:
```C# Snippet:Hello_World_Namespaces
using System;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
```

The following code shows how to get the default subscription:

```C# Snippet:Hello_World_DefaultSubscription
ArmClient client = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = client.GetDefaultSubscription();
Console.WriteLine(subscription.Id);
```

It's possible to get a specific subscription as follows:

```C# Snippet:Hello_World_SpecificSubscription
string subscriptionId = "your-subscription-id";
ArmClient client = new ArmClient(new DefaultAzureCredential());
SubscriptionCollection subscriptions = client.GetSubscriptions();
SubscriptionResource subscription = subscriptions.Get(subscriptionId);
Console.WriteLine($"Got subscription: {subscription.Data.DisplayName}");
```

You can also specify the default subscription when creating the ArmClient:

```C# Snippet:Hello_World_SpecifyDefaultSubscription
string defaultSubscriptionId = "your-subscription-id";
ArmClient client = new ArmClient(new DefaultAzureCredential(), defaultSubscriptionId);
SubscriptionResource subscription = client.GetDefaultSubscription();
Console.WriteLine(subscription.Id);
```

From here, it is possible to get the resource groups from the retrieved subscription:

```C# Snippet:Hello_World_ResourceGroupCollection
ResourceGroupCollection resourceGroups = subscription.GetResourceGroups();
```

## Next stepts
Take a look at the [Managing Resource Groups](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/docs/Sample2_ManagingResourceGroups.md) samples.
