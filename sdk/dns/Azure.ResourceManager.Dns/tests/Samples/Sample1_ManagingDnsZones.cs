// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Manage_DnsZones_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.ResourceManager.Dns;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
#endregion Snippet:Manage_DnsZones_Namespaces

namespace Azure.ResourceManager.Dns.Tests.Samples
{
    public class Sample1_ManagingDnsZones
    {
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateADnsZone()
        {
            #region Snippet:Managing_DnsZones_CreateADnsZones
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
            // first we need to get the resource group
            string rgName = "myRgName";
            ResourceGroupResource resourceGroup = await subscription.GetResourceGroups().GetAsync(rgName);
            // Now we get the DnsZone collection from the resource group
            DnsZoneCollection dnsZoneCollection = resourceGroup.GetDnsZones();
            // Use the same location as the resource group
            string dnsZoneName = "sample.com";
            DnsZoneData data = new DnsZoneData("Global")
            {
            };
            ArmOperation<DnsZoneResource> lro = await dnsZoneCollection.CreateOrUpdateAsync(WaitUntil.Completed, dnsZoneName, data);
            DnsZoneResource dnsZone = lro.Value;
            #endregion Snippet:Managing_DnsZones_CreateADnsZones
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task ListDnsZones()
        {
            #region Snippet:Managing_DnsZones_ListAllDnsZones
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
            // first we need to get the resource group
            string rgName = "myRgName";
            ResourceGroupResource resourceGroup = await subscription.GetResourceGroups().GetAsync(rgName);
            // Now we get the DnsZone collection from the resource group
            DnsZoneCollection dnsZoneCollection = resourceGroup.GetDnsZones();
            // With ListAsync(), we can get a list of the DnsZones
            AsyncPageable<DnsZoneResource> response = dnsZoneCollection.GetAllAsync();
            await foreach (DnsZoneResource dnsZone in response)
            {
                Console.WriteLine(dnsZone.Data.Name);
            }
            #endregion Snippet:Managing_DnsZones_ListAllDnsZones
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task DeleteDnsZone()
        {
            #region Snippet:Managing_DnsZones_DeleteDnsZone
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
            // first we need to get the resource group
            string rgName = "myRgName";
            ResourceGroupResource resourceGroup = await subscription.GetResourceGroups().GetAsync(rgName);
            // Now we get the DnsZone collection from the resource group
            DnsZoneCollection dnsZoneCollection = resourceGroup.GetDnsZones();
            string dnsZoneName = "sample.com";
            DnsZoneResource dnsZone = await dnsZoneCollection.GetAsync(dnsZoneName);
            await dnsZone.DeleteAsync(WaitUntil.Completed);
            #endregion Snippet:Managing_DnsZones_DeleteDnsZone
        }
    }
}
