# Example: Managing the ManagedInstance

>Note: Before getting started with the samples, go through the [prerequisites](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/resourcemanager/Azure.ResourceManager#prerequisites).

Namespaces for this example:
```C# Snippet:Manage_ManagedInstance_Namespaces
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

***Create a managed instance***

```C# Snippet:Managing_Sql_CreateAManagedInstance
//1. create NetworkSecurityGroup
NetworkSecurityGroupData networkSecurityGroupData = new NetworkSecurityGroupData()
{
    Location = Location.WestUS2,
};
string networkSecurityGroupName = "myNetworkSecurityGroup";
var networkSecurityGroup = await resourceGroup.GetNetworkSecurityGroups().CreateOrUpdateAsync(networkSecurityGroupName, networkSecurityGroupData);

//2. create Route table
RouteTableData routeTableData = new RouteTableData()
{
    Location = Location.WestUS2,
};
string routeTableName = "myRouteTable";
var routeTable = await resourceGroup.GetRouteTables().CreateOrUpdateAsync(routeTableName, routeTableData);

//3. create vnet(subnet binding NetworkSecurityGroup and RouteTable)
var vnetData = new VirtualNetworkData()
{
    Location = Location.WestUS2,
    AddressSpace = new AddressSpace()
    {
        AddressPrefixes = { "10.10.0.0/16", }
    },
    Subnets =
    {
        new SubnetData()
        {
            Name = "ManagedInstance",
            AddressPrefix = "10.10.2.0/24",
            Delegations =
            {
                new Delegation() { ServiceName  = "Microsoft.Sql/managedInstances",Name="Microsoft.Sql/managedInstances" ,Type="Microsoft.Sql"}
            },
            RouteTable = new RouteTableData(){ Id = routeTable.Value.Data.Id.ToString() },
            NetworkSecurityGroup = new NetworkSecurityGroupData(){ Id = networkSecurityGroup.Value.Data.Id.ToString() },
        }
    },
};
string vnetName = "myVnet";
var vnet = await resourceGroup.GetVirtualNetworks().CreateOrUpdateAsync(vnetName, vnetData);
string subnetId = $"{vnet.Value.Data.Id}/subnets/ManagedInstance";

//4. create ManagedInstance
ManagedInstanceData data = new ManagedInstanceData(Location.WestUS2)
{
    AdministratorLogin = "myAdministratorLogin",
    AdministratorLoginPassword = "abcdef123456789*",
    SubnetId = subnetId,
    PublicDataEndpointEnabled = false,
    MaintenanceConfigurationId = "/subscriptions/0000-0000-0000-0000/providers/Microsoft.Maintenance/publicMaintenanceConfigurations/SQL_Default",
    ProxyOverride = new ManagedInstanceProxyOverride("Proxy") { },
    TimezoneId = "UTC",
    StorageAccountType = new StorageAccountType("GRS"),
    ZoneRedundant = false,
};
string managedInstanceName = "myManagedInstance";
var managedInstanceLro = await resourceGroup.GetManagedInstances().CreateOrUpdateAsync(managedInstanceName, data);
ManagedInstance managedInstance = managedInstanceLro.Value;
```

***List all managed instance***

```C# Snippet:Managing_Sql_ListAllManagedInstances
ManagedInstanceCollection managedInstanceCollection = resourceGroup.GetManagedInstances();

AsyncPageable<ManagedInstance> response = managedInstanceCollection.GetAllAsync();
await foreach (ManagedInstance managedInstance in response)
{
    Console.WriteLine(managedInstance.Data.Name);
}
```

***Get a managed instance***

```C# Snippet:Managing_Sql_GetAManagedInstance
ManagedInstanceCollection managedInstanceCollection = resourceGroup.GetManagedInstances();

ManagedInstance managedInstance = await managedInstanceCollection.GetAsync("myManagedInstance");
Console.WriteLine(managedInstance.Data.Name);
```

***Try to get a managed instance if it exists***

```C# Snippet:Managing_Sql_GetAManagedInstanceIfExists
ManagedInstanceCollection managedInstanceCollection = resourceGroup.GetManagedInstances();

ManagedInstance managedInstance = await managedInstanceCollection.GetIfExistsAsync("foo");
if (managedInstance != null)
{
    Console.WriteLine(managedInstance.Data.Name);
}

if (await managedInstanceCollection.CheckIfExistsAsync("bar"))
{
    Console.WriteLine("Virtual network 'bar' exists.");
}
```

***Delete a managed instance***

```C# Snippet:Managing_Sql_DeleteAManagedInstance
ManagedInstanceCollection managedInstanceCollection = resourceGroup.GetManagedInstances();

ManagedInstance managedInstance = await managedInstanceCollection.GetAsync("myManagedInstance");
await managedInstance.DeleteAsync();
```

## Next steps

Take a look at the [Managing Managed Databases](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/sqlmanagement/Azure.ResourceManager.Sql/samples/Sample2_ManagingManagedDatabases.md) samples.

