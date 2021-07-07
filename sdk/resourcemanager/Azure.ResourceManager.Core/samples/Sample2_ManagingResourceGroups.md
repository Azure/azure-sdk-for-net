Example: Managing Resource Groups
--------------------------------------

When you first create your ARM client, choose the subscription you're going to work in. There's a convenient `DefaultSubscription` property that returns the default subscription configured for your user:

```C# Snippet:Managing_Resource_Groups_DefaultSubscription

```

This is a scoped operations object, and any operations you perform will be done under that subscription. From this object, you have access to all children via container objects. Or you can access individual children by ID.

```C# Snippet:Managing_Resource_Groups_GetResourceGroupContainer

```

Using the container object, we can perform collection-level operations such as list all of the resource groups or create new ones under our subscription.

***Create a resource group***

```C# Snippet:Managing_Resource_Groups_CreateAResourceGroup

```

***List all resource groups***

```C# Snippet:Managing_Resource_Groups_ListAllResourceGroup

```

Using the operation object we can perform entity-level operations, such as updating or deleting existing resource groups.

***Update a resource group***

```C# Snippet:Managing_Resource_Groups_UpdateAResourceGroup

```

***Delete a resource group***

```C# Snippet:Managing_Resource_Groups_DeleteResourceGroup

```
