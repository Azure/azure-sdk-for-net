# Example: Managing the Event Hubs
>Note: Before getting started with the samples, go through the [prerequisites](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/resourcemanager/Azure.ResourceManager#prerequisites).

Namespaces for this example:

```C# Snippet:Snippet:Managing_Namespaces_Namespaces
```

When you first create your ARM client, choose the subscription you're going to work in. There's a convenient `DefaultSubscription` property that returns the default subscription configured for your user:

```C# Snippet:Managing_EventHubs_DefaultSubscription
```

This is a scoped operations object, and any operations you perform will be done under that subscription. From this object, you have access to all children via container objects. Or you can access individual children by ID.

```C# Snippet:Managing_EventHubs_CreateResourceGroup
```

After we have the resource group created, we can create a namespace

```C# Snippet:Managing_EventHubs_CreateNamespace
```

Now that we have the namespace, we can manage the event hubs inside this namespace.

***Create an event hub***

```C# Snippet:Managing_EventHubs_CreateEventHub
```

***List all event hub***

```C# Snippet:Managing_EventHubs_ListEventHubs
```

***Get an event hub***

```C# Snippet:Managing_EventHubs_GetEventHub
```

***Try to get an event hub if it exists***

```C# Snippet:Managing_EventHubs_GetEventHubIfExists
```

***Delete an event hub***

```C# Snippet:Managing_EventHubs_DeleteEventHub
```

