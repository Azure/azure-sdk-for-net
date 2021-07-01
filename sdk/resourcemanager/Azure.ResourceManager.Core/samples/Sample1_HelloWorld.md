# Example: Getting a subscription

>Note: Before getting started with the samples, make sure to go trough the [prerequisites](https://github.com/Azure/azure-sdk-for-net/tree/feature/mgmt-track2/sdk/resourcemanager/Azure.ResourceManager.Core#prerequisites).

The following code shows how to get the default subscription:

```csharp
var armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = armClient.DefaultSubscription;
Console.WriteLine(subscription.Id);
```

It's possible to get a specific subscription as follows:

```csharp
string subscriptionId = "db1ab6f0-4769-4b27-930e-01e2ef9c123c";
var armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = armClient.GetSubscriptions().Get(subscriptionId);
Console.WriteLine("Got subscription: " + subscription.Data.DisplayName);
```

From here, it is possible to get the resource groups from the retrieved subscription:

```csharp
ResourceGroupContainer rgContainer = subscription.GetResourceGroups();
```

## Next stepts
Take a look at the [Managing Resource Groups](https://github.com/Azure/azure-sdk-for-net/blob/feature/mgmt-track2/sdk/resourcemanager/Azure.ResourceManager.Core/samples/Sample2_ManagingResourceGroups.md) samples.
