# Example: Getting a subscription

>Note: Before getting started with the samples, make sure to go trough the [prerequisites]<--(./README.md#Prerequisites)-->.

The following code shows how to get the default subscription:

```csharp
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = armClient.DefaultSubscription;
Console.WriteLine(subscription.Id);
```

It is possible to get an specific subscription as it's shown next:

``` csharp
string subscriptionId = "db1ab6f0-4769-4b27-930e-01e2ef9c123c";
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = armClient.GetSubscriptions().Get(subscriptionId);
Console.WriteLine("Got subscription: " + subscription.Data.DisplayName);
```

From here, it is possible to get the resource groups from the retrieved subscription:

```csharp
ResourceGroupContainer rgContainer = subscription.GetResourceGroups();
```

## Next stepts
Take a look at the [Managing Resource Groups]<--(Sample2_ManagingResourceGroups.md)--> samples.