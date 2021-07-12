# Example: Getting a subscription

>Note: Before getting started with the samples, go through the [prerequisites](https://github.com/Azure/azure-sdk-for-net/tree/feature/mgmt-track2/sdk/resourcemanager/Azure.ResourceManager.Core#prerequisites).

Namespaces for this example:
```C# Snippet:Hello_World_Async_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.ResourceManager.Core;
```

The following code shows how to get the default subscription:

```C# Snippet:Hello_World_Async_DefaultSubscription
var armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = armClient.DefaultSubscription;
Console.WriteLine(subscription.Id);
```

It's possible to get a specific subscription as follows:

```C# Snippet:Hello_World_Async_SpecificSubscription
string subscriptionId = "your-subscription-id";
var armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = await armClient.GetSubscriptions().GetAsync(subscriptionId);
Console.WriteLine(subscription.Id);
```

With the `Async` suffix on methods that perform API calls, it's possible to differentiate the asynchronous and synchronous variants of any method.

From here, it is possible to get the resource groups from the retrieved subscription:

```C# Snippet:Hello_World_Async_ResourceGroupContainer
ResourceGroupContainer rgContainer = subscription.GetResourceGroups();
```

## Next stepts
Take a look at the [Managing Resource Groups](https://github.com/Azure/azure-sdk-for-net/blob/feature/mgmt-track2/sdk/resourcemanager/Azure.ResourceManager.Core/samples/Sample2_ManagingResourceGroups.md) samples.
