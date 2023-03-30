// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Manage_PtrRecord_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.ResourceManager.Dns;
using Azure.ResourceManager.Dns.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
#endregion Snippet:Manage_PtrRecord_Namespaces

namespace Azure.ResourceManager.Dns.Tests.Samples
{
    public class Sample2_ManagingPtrRecord
    {
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreatePtrRecord()
        {
            #region Snippet:Manage_PtrRecord_CreateOrUpdate
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
            #endregion Snippet:Manage_PtrRecord_CreateOrUpdate
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task ListPtrRecord()
        {
            #region Snippet:Manage_PtrRecord_List
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
            #endregion Snippet:Manage_PtrRecord_List
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task DeletePtrRecord()
        {
            #region Snippet:Manage_PtrRecord_Delete
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
            #endregion Snippet:Manage_PtrRecord_Delete
        }
    }
}
