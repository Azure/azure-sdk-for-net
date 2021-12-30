# Example: Managing DNS records

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

Now that we have the DNS zone created, we can manage the DNS records inside this DNS Zone.

***Create a DNS Record***

```C# Snippet:Managing_DNSRecords_CreateADNSRecord
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
// first we need to get the resource group
string rgName = "myRgName";
ResourceGroup resourceGroup = await subscription.GetResourceGroups().GetAsync(rgName);
// Now we get the zone collection from the resource group
string dnsZoneName = "test.domain";
DnsZoneCollection zoneCollection = resourceGroup.GetDnsZones();
DnsZone dnsZone = await zoneCollection.GetAsync(dnsZoneName);
// Then we need to get the record collection from the DNS zone
RecordSetAaaaCollection recordSetAaaas = dnsZone.GetRecordSetAaaas();
RecordSetData recordSetData = new RecordSetData() { TTL = 600 };
recordSetData.AaaaRecords.Add(new AaaaRecord("::1"));
_ = await recordSetAaaas.CreateOrUpdateAsync("www6", recordSetData);
```

***Update a DNS Record***

```C# Snippet:Managing_DNSRecords_UpdateADNSRecord
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
// first we need to get the resource group
string rgName = "myRgName";
ResourceGroup resourceGroup = await subscription.GetResourceGroups().GetAsync(rgName);
// Now we get the zone collection from the resource group
string dnsZoneName = "test.domain";
DnsZoneCollection zoneCollection = resourceGroup.GetDnsZones();
DnsZone dnsZone = await zoneCollection.GetAsync(dnsZoneName);
// Then we need to get the record collection from the DNS zone
RecordSetAaaaCollection recordSetAaaas = dnsZone.GetRecordSetAaaas();
RecordSetAaaa recordSetAaaa = await recordSetAaaas.GetAsync("www6");
RecordSetData newRecordSetData = new RecordSetData();
newRecordSetData.AaaaRecords.Add(new AaaaRecord(":/ 128"));
RecordSetAaaa newRecordSetAaaa = await recordSetAaaa.UpdateAsync(newRecordSetData);
```

***Delete a DNS Record***

```C# Snippet:Managing_DNSRecords_DeleteADNSRecord
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
// first we need to get the resource group
string rgName = "myRgName";
ResourceGroup resourceGroup = await subscription.GetResourceGroups().GetAsync(rgName);
// Now we get the zone collection from the resource group
string dnsZoneName = "test.domain";
DnsZoneCollection zoneCollection = resourceGroup.GetDnsZones();
DnsZone dnsZone = await zoneCollection.GetAsync(dnsZoneName);
// Then we need to get the record collection from the DNS zone
RecordSetAaaaCollection recordSetAaaas = dnsZone.GetRecordSetAaaas();
RecordSetAaaa recordSetAaaa = await recordSetAaaas.GetAsync("www6");
await recordSetAaaa.DeleteAsync();
```
