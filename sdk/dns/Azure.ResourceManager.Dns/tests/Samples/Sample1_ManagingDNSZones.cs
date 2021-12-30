// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#region Snippet:Managing_DNSZones_Namespaces
using System.Threading.Tasks;
using Azure.Identity;
using Azure.ResourceManager.Dns.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;
#endregion Snippet:Managing_DNSZones_Namespaces
namespace Azure.ResourceManager.Dns.Tests.Samples
{
    internal class Sample1_ManagingDNSZones
    {
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateADNSZone()
        {
            #region Snippet:Managing_DNSZones_CreateADNSZone
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
            #endregion Snippet:Managing_DNSZones_CreateADNSZone
        }
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task UpdateADNSZone()
        {
            #region Snippet:Managing_DNSZones_UpdateADNSZone
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
            #endregion Snippet:Managing_DNSZones_UpdateADNSZone
        }
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task DeleteADNSZone()
        {
            #region Snippet:Managing_DNSZones_DeleteADNSZone
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
            #endregion Snippet:Managing_DNSZones_DeleteADNSZone
        }
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task GetADNSZone()
        {
            #region Snippet:Managing_DNSZones_GetADNSZone
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
            #endregion Snippet:Managing_DNSZones_GetADNSZone
        }
    }
}
