# Example: Managing the ManagedDatabases

>Note: Before getting started with the samples, go through the [prerequisites](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/resourcemanager/Azure.ResourceManager#prerequisites).

Namespaces for this example:
```C# Snippet:Manage_Databases_Namespaces
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Sql.Models;
using NUnit.Framework;
```

When you first create your ARM client, choose the subscription you're going to work in. You can use the `GetDefaultSubscription`/`GetDefaultSubscriptionAsync` methods to return the default subscription configured for your user:

```C# Snippet:Readme_DefaultSubscription
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = armClient.GetDefaultSubscription();
```

This is a scoped operations object, and any operations you perform will be done under that subscription. From this object, you have access to all children via collection objects. Or you can access individual children by ID.

```C# Snippet:Readme_GetResourceGroupCollection
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
ResourceGroupCollection rgCollection = subscription.GetResourceGroups();
// With the collection, we can create a new resource group with an specific name
string rgName = "myRgName";
Location location = Location.WestUS2;
ResourceGroupCreateOrUpdateOperation lro = await rgCollection.CreateOrUpdateAsync(rgName, new ResourceGroupData(location));
ResourceGroup resourceGroup = lro.Value;
```

Now that we have the resource group created, we can manage the managed instance inside this resource group.

please notice that ManagedDatabases is sub resource of managed instance, before we create a ManagedDatabases, at lease we need to create a managed instance as prerequisite.Please refer to documentation of Azure.ResourceManager.Sql for details of creating a managed instance.

***Create a managed databases***

```C# Snippet:Managing_Sql_CreateAManagedDatabases
ManagedDatabaseCollection managedDatabaseCollection = managedInstance.GetManagedDatabases();

ManagedDatabaseData data = new ManagedDatabaseData(Location.WestUS2)
{
};
string databaseName = "myDatabase";
var managedDatabaseLro = await managedDatabaseCollection.CreateOrUpdateAsync(databaseName, data);
ManagedDatabase managedDatabase = managedDatabaseLro.Value;
```

***List all managed databases***

```C# Snippet:Managing_Sql_ListAllManagedDatabases
ManagedDatabaseCollection managedDatabaseCollection = managedInstance.GetManagedDatabases();

AsyncPageable<ManagedDatabase> response = managedDatabaseCollection.GetAllAsync();
await foreach (ManagedDatabase managedDatabase in response)
{
    Console.WriteLine(managedDatabase.Data.Name);
}
```

***Get a managed databases***

```C# Snippet:Managing_Sql_GetAManagedDatabases
ManagedDatabaseCollection managedDatabaseCollection = managedInstance.GetManagedDatabases();

ManagedDatabase managedDatabase = await managedDatabaseCollection.GetAsync("myManagedDatabase");
Console.WriteLine(managedDatabase.Data.Name);
```

***Try to get a managed databases if it exists***

```C# Snippet:Managing_Sql_GetAManagedDatabasesIfExists
ManagedDatabaseCollection managedDatabaseCollection = managedInstance.GetManagedDatabases();

ManagedDatabase managedDatabase = await managedDatabaseCollection.GetIfExistsAsync("foo");
if (managedInstance != null)
{
    Console.WriteLine(managedDatabase.Data.Name);
}

if (await managedDatabaseCollection.CheckIfExistsAsync("bar"))
{
    Console.WriteLine("Virtual network 'bar' exists.");
}
```

***Delete a managed databases***

```C# Snippet:Managing_Sql_DeleteAManagedDatabases
ManagedDatabaseCollection managedDatabaseCollection = managedInstance.GetManagedDatabases();

ManagedDatabase managedDatabase = await managedDatabaseCollection.GetAsync("myManagedInstance");
await managedDatabase.DeleteAsync();
```
