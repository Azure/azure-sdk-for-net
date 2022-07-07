# Example: Managing Record Set Ptrs
>Note: Before getting started with the samples, go through the [prerequisites](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/resourcemanager/Azure.ResourceManager#prerequisites).

Namespaces for this example:

```C# Snippet:Manage_RecordSetPtrs_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.ResourceManager.Dns;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
```

When you first create your ARM client, choose the subscription you're going to work in. You can use the `GetDefaultSubscription`/`GetDefaultSubscriptionAsync` methods to return the default subscription configured for your user:

```C# Snippet:Readme_DefaultSubscription
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = armClient.GetDefaultSubscription();
```

This is a scoped operations object, and any operations you perform will be done under that subscription. From this object, you have access to all children via collection objects. Or you can access individual children by ID.

```C# Snippet:Readme_GetResourceGroupCollection
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
ResourceGroupCollection rgCollection = subscription.GetResourceGroups();
// With the collection, we can create a new resource group with an specific name
string rgName = "myRgName";
AzureLocation location = AzureLocation.WestUS2;
ArmOperation<ResourceGroupResource> lro = await rgCollection.CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(location));
ResourceGroupResource resourceGroup = lro.Value;
```

***Create a Record set ptr***

```C# Snippet:Managing_RecordSetPtrs_CreateARecordSetPtr
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
// first we need to get the resource group
string rgName = "myRgName";
ResourceGroupResource resourceGroup = await subscription.GetResourceGroups().GetAsync(rgName);
// create a DnsZone
string dnsZoneName = "sample.com";
DnsZoneCollection dnsZoneCollection = resourceGroup.GetDnsZones();
DnsZoneData data = new DnsZoneData("Global")
{
};
ArmOperation<DnsZoneResource> lro = await dnsZoneCollection.CreateOrUpdateAsync(WaitUntil.Completed, dnsZoneName, data);
DnsZoneResource dnsZone = lro.Value;
// create a ptr record set
RecordSetPtrCollection  recordSetPtrCollection = dnsZone.GetRecordSetPtrs();
string name = "ptr";
ArmOperation<RecordSetPtrResource> recordSetPtrResource = await recordSetPtrCollection.CreateOrUpdateAsync(WaitUntil.Completed, name, new PtrRecordSetData() { });
RecordSetPtrResource recordSetPtr = recordSetPtrResource.Value;
```

***List all Record set ptrs***

```C# Snippet:Managing_RecordSetPtrs_ListAllRecordSetPtrs
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
// first we need to get the resource group
string rgName = "myRgName";
ResourceGroupResource resourceGroup = await subscription.GetResourceGroups().GetAsync(rgName);
// create a DnsZone
string dnsZoneName = "sample.com";
DnsZoneCollection dnsZoneCollection = resourceGroup.GetDnsZones();
DnsZoneData data = new DnsZoneData("Global")
{
};
ArmOperation<DnsZoneResource> lro = await dnsZoneCollection.CreateOrUpdateAsync(WaitUntil.Completed, dnsZoneName, data);
DnsZoneResource dnsZone = lro.Value;
// With ListAsync(), we can get a list of the RecordSetPtrs
RecordSetPtrCollection recordSetPtrCollection = dnsZone.GetRecordSetPtrs();
AsyncPageable<RecordSetPtrResource> response = recordSetPtrCollection.GetAllAsync();
await foreach (RecordSetPtrResource recordSetPtr in response)
{
    Console.WriteLine(recordSetPtr.Data.Name);
}
```

***Delete Record set ptr***

```C# Snippet:Managing_RecordSetPtrs_DeleteRecordSetPtr
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
// first we need to get the resource group
string rgName = "myRgName";
ResourceGroupResource resourceGroup = await subscription.GetResourceGroups().GetAsync(rgName);
// create a DnsZone
string dnsZoneName = "sample.com";
DnsZoneCollection dnsZoneCollection = resourceGroup.GetDnsZones();
DnsZoneData data = new DnsZoneData("Global")
{
};
ArmOperation<DnsZoneResource> lro = await dnsZoneCollection.CreateOrUpdateAsync(WaitUntil.Completed, dnsZoneName, data);
DnsZoneResource dnsZone = lro.Value;
// Now we get the DnsZone collection from the resource group
RecordSetPtrCollection recordSetPtrCollection = dnsZone.GetRecordSetPtrs();
string recordSetPtrName = "ptr";
RecordSetPtrResource recordSetPtr = await recordSetPtrCollection.GetAsync(recordSetPtrName);
await recordSetPtr.DeleteAsync(WaitUntil.Completed);
```
