// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Manage_RecordSetPtrs_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.ResourceManager.Dns;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
#endregion Snippet:Manage_RecordSetPtrs_Namespaces

namespace Azure.ResourceManager.Dns.Tests.Samples
{
    public class Sample2_ManagingRecordSetPtrs
    {
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateARecordSetPtr()
        {
            #region Snippet:Managing_RecordSetPtrs_CreateARecordSetPtr
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
            #endregion Snippet:Managing_RecordSetPtrs_CreateARecordSetPtr
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task ListRecordSetPtrs()
        {
            #region Snippet:Managing_RecordSetPtrs_ListAllRecordSetPtrs
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
            #endregion Snippet:Managing_RecordSetPtrs_ListAllRecordSetPtrs
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task DeleteRecordSetPtr()
        {
            #region Snippet:Managing_RecordSetPtrs_DeleteRecordSetPtr
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
            #endregion Snippet:Managing_RecordSetPtrs_DeleteRecordSetPtr
        }
    }
}
