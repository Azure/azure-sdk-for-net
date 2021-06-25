Example: Managing Resource Groups
--------------------------------------

When you first create your ARM client, choose the subscription you're going to work in. There's a convenient `DefaultSubscription` property that returns the default subscription configured for your user:

```csharp
    ArmClient armClient = new ArmClient(new DefaultAzureCredential());
    Subscription subscription = armClient.DefaultSubscription;
```

This is a scoped operations object, and any operations you perform will be done under that subscription. From this object, you have access to all children via container objects. Or you can access individual children by ID.

```csharp
    ArmClient armClient = new ArmClient(new DefaultAzureCredential());
    Subscription subscription = armClient.DefaultSubscription;
    ResourceGroupContainer rgContainer = subscription.GetResourceGroups();
    ...
    string rgName = "myRgName";
    ResourceGroup resourceGroup = await rgContainer.GetAsync(rgName);
```

Using the container object we can perform collection level operations such as list all of the resource groups or create new ones under our subscription

***Create a resource group***

```csharp
    ArmClient armClient = new ArmClient(new DefaultAzureCredential());
    Subscription subscription = armClient.DefaultSubscription;
    ResourceGroupContainer rgContainer = subscription.GetResourceGroups();
    
    LocationData location = LocationData.WestUS2;
    string rgName = "myRgName";
    ResourceGroup resourceGroup = await rgContainer.Construct(location).CreateAsync(rgName);
```

***List all resource groups***

```csharp
    ArmClient armClient = new ArmClient(new DefaultAzureCredential());
    Subscription subscription = armClient.DefaultSubscription;
    ResourceGroupContainer rgContainer = subscription.GetResourceGroups();
    AsyncPageable<ResourceGroup> response = rgContainer.ListAsync();
    await foreach (ResourceGroup rg in response)
    {
        Console.WriteLine(rg.Data.Name);
    }
```

Using the operation object we can perform entity-level operations, such as updating or deleting existing resource groups.

***Update a resource group***

```csharp
    ArmClient armClient = new ArmClient(new DefaultAzureCredential());
    Subscription subscription = armClient.DefaultSubscription;
    ResourceGroup resourceGroup = await subscription.GetResourceGroups().GetAsync(rgName);
    resourceGroup = await rgOperation.StartAddTag("key", "value").WaitForCompletionAsync();
```

***Delete a resource group***

```csharp
    ArmClient armClient = new ArmClient(new DefaultAzureCredential());
    Subscription subscription = armClient.DefaultSubscription;
    ResourceGroup resourceGroup = await subscription.GetResourceGroups().GetAsync(rgName);
    await resourceGroup.DeleteAsync();
```
