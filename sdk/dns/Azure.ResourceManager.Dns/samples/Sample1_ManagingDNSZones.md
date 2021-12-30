# Example: Managing DNS zones

>Note: Before getting started with the samples, go through the [prerequisites](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/resourcemanager/Azure.ResourceManager#prerequisites).

Namespaces for this example:

```C# Snippet:Managing_DNSZones_Namespaces
using System.Threading.Tasks;
using Azure.Identity;
using Azure.ResourceManager.Dns.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;
```

When you first create your ARM client, choose the subscription you're going to work in. You can use the `GetDefaultSubscription`/`GetDefaultSubscriptionAsync` methods to return the default subscription configured for your user:

```C# Snippet:Readme_DefaultSubscription
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = armClient.GetDefaultSubscription();
```

This is a scoped operations object, and any operations you perform will be done under that subscription. From this object, you have access to all children via collection objects. Or you can access individual children by ID.

```C# Snippet:Readme_CreateResourceGroupCollection
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
ResourceGroupCollection rgCollection = subscription.GetResourceGroups();
// With the collection, we can create a new resource group with an specific name
string rgName = "myRgName";
Location location = Location.WestUS2;
ResourceGroupCreateOrUpdateOperation lro = await rgCollection.CreateOrUpdateAsync(rgName, new ResourceGroupData(location));
ResourceGroup resourceGroup = lro.Value;
```

Now that we have the resource group created, we can manage the DNS Zones inside this resource group.

***Create a DNS Zone***

```C# Snippet:Managing_DNSZones_CreateADNSZone
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
ResourceGroupCollection rgCollection = subscription.GetResourceGroups();

// With the collection, we can create a new resource group with an specific name
string rgName = "myRgName";
Location location = Location.WestUS2;
ResourceGroupCreateOrUpdateOperation lro = await rgCollection.CreateOrUpdateAsync(rgName, new ResourceGroupData(location));
ResourceGroup resourceGroup = lro.Value;
DnsZoneCollection zoneCollection = resourceGroup.GetDnsZones();
string dnsZoneName = "test.domain";
DnsZoneData input = new DnsZoneData("global");
ZoneCreateOrUpdateOperation zlro = await zoneCollection.CreateOrUpdateAsync(dnsZoneName, input);
DnsZone zone = zlro.Value;
```

***Get a DNS Zone***

```C# Snippet:Managing_DNSZones_GetADNSZone
// First, initialize the ArmClient and get the default subscription
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
// Now we get a ResourceGroup collection for that subscription
Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
ResourceGroupCollection rgCollection = subscription.GetResourceGroups();

// With the collection, we can create a new resource group with an specific name
string rgName = "myRgName";
ResourceGroup resourceGroup = await rgCollection.GetAsync(rgName);
DnsZoneCollection zoneCollection = resourceGroup.GetDnsZones();
string dnsZoneName = "test.domain";
DnsZone zone = await zoneCollection.GetAsync(dnsZoneName);
```

***Update a DNS Zone***

```C# Snippet:Managing_DNSZones_UpdateADNSZone
// First, initialize the ArmClient and get the default subscription
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
// Now we get a ResourceGroup collection for that subscription
Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
ResourceGroupCollection rgCollection = subscription.GetResourceGroups();

// With the collection, we can create a new resource group with an specific name
string rgName = "myRgName";
ResourceGroup resourceGroup = await rgCollection.GetAsync(rgName);
DnsZoneCollection zoneCollection = resourceGroup.GetDnsZones();
string dnsZoneName = "test.domain";
DnsZone zone = await zoneCollection.GetAsync(dnsZoneName);
var zoneUpdate = new ZoneUpdateOptions();
zoneUpdate.Tags.Add("tag1", "value1");
DnsZone updatedDnsZone = await zone.UpdateAsync(zoneUpdate);
```

***Delete a DNS Zone***

```C# Snippet:Managing_DNSZones_DeleteADNSZone
// First, initialize the ArmClient and get the default subscription
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
// Now we get a ResourceGroup collection for that subscription
Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
ResourceGroupCollection rgCollection = subscription.GetResourceGroups();

// With the collection, we can create a new resource group with an specific name
string rgName = "myRgName";
ResourceGroup resourceGroup = await rgCollection.GetAsync(rgName);
DnsZoneCollection zoneCollection = resourceGroup.GetDnsZones();
string dnsZoneName = "test.domain";
DnsZone zone = await zoneCollection.GetAsync(dnsZoneName);
await zone.DeleteAsync();
```


## Next steps

Take a look at the [Managing DNS Records](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/dns/Azure.ResourceManager.Dns/samples/Sample2_ManagingDNSRecords.md) samples.
