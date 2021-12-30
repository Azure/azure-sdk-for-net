// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Identity;
using Azure.ResourceManager.Dns.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Dns.Tests.Samples
{
    public class Sample2_ManagingDNSRecords
    {
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateDnsRecord()
        {
            #region Snippet:Managing_DNSRecords_CreateADNSRecord
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
            #endregion Snippet:Managing_DNSRecords_CreateADNSRecord
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task UpdateDnsRecord()
        {
            #region Snippet:Managing_DNSRecords_UpdateADNSRecord
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
            #endregion Snippet:Managing_DNSRecords_UpdateADNSRecord
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task DeleteDnsRecord()
        {
            #region Snippet:Managing_DNSRecords_DeleteADNSRecord
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
            #endregion Snippet:Managing_DNSRecords_DeleteADNSRecord
        }
    }
}
