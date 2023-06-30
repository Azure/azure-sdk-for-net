// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.ResourceManager.Models;
using Azure.Core;
using Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models;
using System.Collections.Generic;

namespace Azure.ResourceManager.PaloAltoNetworks.Ngfw.Tests.Scenario
{
    public class FirewallResourceCollectionTests : PaloAltoNetworksNgfwManagementTestBase
    {
        protected ResourceGroupResource ResGroup { get; set; }
        protected ResourceGroupResource DefaultResGroup { get; set; }
        protected FirewallResource DefaultResource1 { get; set; }
        public FirewallResourceCollectionTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        public FirewallResourceCollectionTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                ResGroup = await CreateResourceGroup(DefaultSubscription, ResourceGroupPrefix, Location);
                DefaultResGroup = await DefaultSubscription.GetResourceGroupAsync("dotnetSdkTest-infra-rg");
                DefaultResource1 = await DefaultResGroup.GetFirewallResources().GetAsync("dotnetSdkTest-default-1");
            }
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string resourceName = Recording.GenerateAssetName("dotnetSdkTest-");
            FirewallResourceData data = IsAsync ? GetFirewallResourceData("default", "20.12.91.61", "10.148.0.0/16", "10.148.1.0/26", "10.148.0.0/26") : GetFirewallResourceData("defaultSync", "20.12.90.143", "10.162.0.0/16", "10.162.1.0/26", "10.162.0.0/26");
            var response = await ResGroup.GetFirewallResources().CreateOrUpdateAsync(WaitUntil.Completed, resourceName, data);
            FirewallResource firewall = response.Value;
            Assert.IsTrue(resourceName.Equals(firewall.Data.Name));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = (await ResGroup.GetFirewallResources().CreateOrUpdateAsync(WaitUntil.Completed, resourceName, null)).Value);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            FirewallResourceCollection collection = DefaultResGroup.GetFirewallResources();
            FirewallResource firewallResource = await collection.GetAsync(DefaultResource1.Data.Name);
            Assert.IsNotNull(firewallResource);
            AssertTrackedResource(DefaultResource1.Data, firewallResource.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task Exists()
        {
            FirewallResourceCollection collection = DefaultResGroup.GetFirewallResources();
            Assert.IsTrue(await collection.ExistsAsync(DefaultResource1.Data.Name));
            Assert.IsFalse(await collection.ExistsAsync("invalidResourceName"));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            FirewallResourceCollection collection = DefaultResGroup.GetFirewallResources();
            int count = 0;
            await foreach (FirewallResource firewall in collection.GetAllAsync())
            {
                count++;
            }

            Assert.AreEqual(count, 4);
        }

        private void AssertTrackedResource(TrackedResourceData r1, TrackedResourceData r2)
        {
            Assert.AreEqual(r1.Id, r2.Id);
            Assert.AreEqual(r1.Name, r2.Name);
            Assert.AreEqual(r1.ResourceType, r2.ResourceType);
            Assert.AreEqual(r1.Location, r2.Location);
            Assert.AreEqual(r1.Tags, r2.Tags);
        }

        private FirewallResourceData GetFirewallResourceData(string nameSuffix, string publicIp, string vnetIp, string subnet1_ip, string subnet2_ip)
        {
            IEnumerable<IPAddress> ipAddresses = new IPAddress[] { new IPAddress($"/subscriptions/2bf4a339-294d-4c25-b0b2-ef649e9f5c27/resourceGroups/dotnetSdkTest-infra-rg/providers/Microsoft.Network/publicIPAddresses/dotnetSdkTest-public-ip-{nameSuffix}", publicIp) };

            VnetConfiguration vnetConfiguration = new VnetConfiguration(
                new IPAddressSpace($"/subscriptions/2bf4a339-294d-4c25-b0b2-ef649e9f5c27/resourceGroups/dotnetSdkTest-infra-rg/providers/Microsoft.Network/virtualNetworks/dotnetSdkTest-vnet-{nameSuffix}", vnetIp),
                new IPAddressSpace($"/subscriptions/2bf4a339-294d-4c25-b0b2-ef649e9f5c27/resourceGroups/dotnetSdkTest-infra-rg/providers/Microsoft.Network/virtualNetworks/dotnetSdkTest-vnet-{nameSuffix}/subnets/subnet1", subnet1_ip),
                new IPAddressSpace($"/subscriptions/2bf4a339-294d-4c25-b0b2-ef649e9f5c27/resourceGroups/dotnetSdkTest-infra-rg/providers/Microsoft.Network/virtualNetworks/dotnetSdkTest-vnet-{nameSuffix}/subnets/subnet2", subnet2_ip));
            NetworkProfile np = new NetworkProfile(NetworkType.Vnet, ipAddresses, EgressNat.Disabled);
            np.VnetConfiguration = vnetConfiguration;

            DnsSettings dnsSettings = new DnsSettings();
            dnsSettings.EnableDnsProxy = DnsProxy.Disabled;
            dnsSettings.EnabledDnsType = EnabledDnsType.Custom;

            PlanData planData = new PlanData(BillingCycle.Monthly, "cloud-ngfw-payg-test");
            MarketplaceDetails mpDetails = new MarketplaceDetails("pan_swfw_cloud_ngfw", "paloaltonetworks");
            FirewallResourceData data = new FirewallResourceData(Location, np, dnsSettings, planData, mpDetails);
            data.AssociatedRulestack = new RulestackDetails($"/subscriptions/2bf4a339-294d-4c25-b0b2-ef649e9f5c27/resourceGroups/dotnetSdkTest-infra-rg/providers/PaloAltoNetworks.Cloudngfw/localRulestacks/dotnetSdkTest-lrs-{nameSuffix}", "", AzureLocation.EastUS2);
            return data;
        }
    }
}
