# Example: Managing PtrRecord

--------------------------------------
For this example, you need the following namespaces:

```C# Snippet:Managing_VirtualMachines_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.Compute.Models;
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

Now that we have the resource group created, we can manage the PtrRecord inside this resource group.

Please notice that before we create a PtrRecord, at lease we need to create a DnsZone as prerequisite. Please refer to documentation of `Sample1_ManagingDNSZones` for details of creating a DnsZone.

***Create a PtrRecord***

```C# Snippet:Manage_PtrRecord_CreateOrUpdate
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
// first we need to get the resource group
string rgName = "myRgName";
ResourceGroupResource resourceGroup = await subscription.GetResourceGroups().GetAsync(rgName);
// get a DnsZone
DnsZoneCollection dnsZoneCollection = resourceGroup.GetDnsZones();
string dnsZoneName = "sample.com";
Response<DnsZoneResource> dnsZoneLro = await dnsZoneCollection.GetAsync(dnsZoneName);
DnsZoneResource dnsZone = dnsZoneLro.Value;
// create a PtrRecord
DnsPtrRecordCollection ptrRecordCollection = dnsZone.GetDnsPtrRecords();
string ptrRecordName = "ptr";
string domainNameValue1 = "contoso1.com";
string domainNameValue2 = "contoso2.com";
var ptrRecordData = new DnsPtrRecordData()
{
    TtlInSeconds = 3600,
    DnsPtrRecords =
    {
        new DnsPtrRecordInfo()
        {
            DnsPtrDomainName = domainNameValue1
        },
        new DnsPtrRecordInfo()
        {
            DnsPtrDomainName = domainNameValue2
        },
    }
};
ArmOperation<DnsPtrRecordResource> ptrRecordLro = await ptrRecordCollection.CreateOrUpdateAsync(WaitUntil.Completed, ptrRecordName, ptrRecordData);
DnsPtrRecordResource ptrRecord = ptrRecordLro.Value;
```

***List all PtrRecord***

```C# Snippet:Manage_PtrRecord_List
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
// first we need to get the resource group
string rgName = "myRgName";
ResourceGroupResource resourceGroup = await subscription.GetResourceGroups().GetAsync(rgName);
// get a DnsZone
DnsZoneCollection dnsZoneCollection = resourceGroup.GetDnsZones();
string dnsZoneName = "sample.com";
Response<DnsZoneResource> dnsZoneLro = await dnsZoneCollection.GetAsync(dnsZoneName);
DnsZoneResource dnsZone = dnsZoneLro.Value;
// list all PtrRecord
DnsPtrRecordCollection ptrRecordCollection = dnsZone.GetDnsPtrRecords();
AsyncPageable<DnsPtrRecordResource> response = ptrRecordCollection.GetAllAsync();
await foreach (DnsPtrRecordResource recordSetPtr in response)
{
    Console.WriteLine(recordSetPtr.Data.Name);
}
```

***Delete a PtrRecord***

```C# Snippet:Manage_PtrRecord_Delete
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
// first we need to get the resource group
string rgName = "myRgName";
ResourceGroupResource resourceGroup = await subscription.GetResourceGroups().GetAsync(rgName);
// get a DnsZone
DnsZoneCollection dnsZoneCollection = resourceGroup.GetDnsZones();
string dnsZoneName = "sample.com";
Response<DnsZoneResource> dnsZoneLro = await dnsZoneCollection.GetAsync(dnsZoneName);
DnsZoneResource dnsZone = dnsZoneLro.Value;
// delete a PtrRecord
DnsPtrRecordCollection ptrRecordCollection = dnsZone.GetDnsPtrRecords();
string recordSetPtrName = "ptr";
DnsPtrRecordResource prtRecord = await ptrRecordCollection.GetAsync(recordSetPtrName);
await prtRecord.DeleteAsync(WaitUntil.Completed);
```
