// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources.Models;
using Azure.Core;
using Azure.ResourceManager.DnsResolver.Models;
using System.Linq;
using System.Collections.Generic;

namespace Azure.ResourceManager.DnsResolver.Tests
{
    public class DnsForwardingRulesetTests : DnsResolverTestBase
    {
        private DnsResolver dnsResolver;
        private DnsForwardingRulesetCollection dnsForwardingRulesetCollection;
        private ResourceIdentifier outboundEndpointId;
        private string vnetId;
        private string subnetId;

        public DnsForwardingRulesetTests(bool async) : base(async)
        {
        }

        [SetUp]
        public async Task CreateDnsResolverCollection()
        {
            var dnsResolverName = Recording.GenerateAssetName("dnsResolver-");
            var vnetName = Recording.GenerateAssetName("dnsResolver-");
            var dnsResolverData = new DnsResolverData(this.DefaultLocation);

            vnetId = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{TestEnvironment.ResourceGroup}/providers/Microsoft.Network/virtualNetworks/{vnetName}";
            subnetId = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{TestEnvironment.ResourceGroup}/providers/Microsoft.Network/virtualNetworks/{vnetName}/subnets/snet-sim2";

            if (Mode == RecordedTestMode.Record)
            {
                await CreateVirtualNetworkAsync(vnetName);
                await CreateSubnetAsync(vnetName);
            }

            dnsResolverData.VirtualNetwork = new WritableSubResource()
            {
                Id = new ResourceIdentifier(vnetId)
            };

            var subscription = await Client.GetSubscriptions().GetAsync(TestEnvironment.SubscriptionId);
            var resourceGroup = await subscription.Value.GetResourceGroups().GetAsync(TestEnvironment.ResourceGroup);

            dnsResolver = (await resourceGroup.Value.GetDnsResolvers().CreateOrUpdateAsync(true, dnsResolverName, dnsResolverData)).Value;
            dnsForwardingRulesetCollection = resourceGroup.Value.GetDnsForwardingRulesets();

            var outboundEndpointData = new OutboundEndpointData(this.DefaultLocation);

            outboundEndpointData.Subnet = new WritableSubResource()
            {
                Id = new ResourceIdentifier(subnetId),
            };

            var outboundEndpointName = Recording.GenerateAssetName("outboundEndpoint-");
            var outboundEndpoint = await dnsResolver.GetOutboundEndpoints().CreateOrUpdateAsync(true, outboundEndpointName, outboundEndpointData);

            outboundEndpointId = outboundEndpoint.Value.Id;
        }

        [Test]
        public async Task CreateDnsForwardingRuleset()
        {
            // ARRANGE
            var dnsForwardingRulesetData = new DnsForwardingRulesetData(this.DefaultLocation);

            dnsForwardingRulesetData.DnsResolverOutboundEndpoints.Add(new WritableSubResource()
            {
                Id = outboundEndpointId,
            });

            var dnsForwardingRulesetName = Recording.GenerateAssetName("dnsForwardingRuleset-");

            // ACT
            var dnsForwardingRuleset = await dnsForwardingRulesetCollection.CreateOrUpdateAsync(true, dnsForwardingRulesetName, dnsForwardingRulesetData);

            // ASSERT
            Assert.AreEqual(dnsForwardingRuleset.Value.Data.ProvisioningState, ProvisioningState.Succeeded);
        }

        [Test]
        public async Task GetDnsForwardingRuleset()
        {
            // ARRANGE
            var dnsForwardingRulesetData = new DnsForwardingRulesetData(this.DefaultLocation);

            dnsForwardingRulesetData.DnsResolverOutboundEndpoints.Add(new WritableSubResource()
            {
                Id = outboundEndpointId,
            });

            var dnsForwardingRulesetName = Recording.GenerateAssetName("dnsForwardingRuleset-");
            await dnsForwardingRulesetCollection.CreateOrUpdateAsync(true, dnsForwardingRulesetName, dnsForwardingRulesetData);

            // ACT
            var retrievedDnsForwardingRuleset = await dnsForwardingRulesetCollection.GetAsync(dnsForwardingRulesetName);

            // ASSERT
            Assert.AreEqual(retrievedDnsForwardingRuleset.Value.Data.Name, dnsForwardingRulesetName);
        }

        [Test]
        public async Task UpdateDnsForwardingRuleset()
        {
            // ARRANGE
            var dnsForwardingRulesetData = new DnsForwardingRulesetData(this.DefaultLocation);

            dnsForwardingRulesetData.DnsResolverOutboundEndpoints.Add(new WritableSubResource()
            {
                Id = outboundEndpointId,
            });

            var dnsForwardingRulesetName = Recording.GenerateAssetName("dnsForwardingRuleset-");
            var createdDnsForwardingRuleset = await dnsForwardingRulesetCollection.CreateOrUpdateAsync(true, dnsForwardingRulesetName, dnsForwardingRulesetData);

            var newTagKey = Recording.GenerateAlphaNumericId("tagKey");
            var newTagValue = Recording.GenerateAlphaNumericId("tagValue");

            var dnsForwardingRulesetPatch = new DnsForwardingRulesetPatch();
            dnsForwardingRulesetPatch.Tags.Add(newTagKey, newTagValue);

            // ACT
            var patchedDnsForwardingRuleset = await createdDnsForwardingRuleset.Value.UpdateAsync(true, dnsForwardingRulesetPatch);

            // ASSERT
            CollectionAssert.AreEquivalent(patchedDnsForwardingRuleset.Value.Data.Tags, dnsForwardingRulesetPatch.Tags);
        }

        [Test]
        public async Task RemoveDnsForwardingRuleset()
        {
            // ARRANGE
            var dnsForwardingRulesetData = new DnsForwardingRulesetData(this.DefaultLocation);

            dnsForwardingRulesetData.DnsResolverOutboundEndpoints.Add(new WritableSubResource()
            {
                Id = outboundEndpointId,
            });

            var dnsForwardingRulesetName = Recording.GenerateAssetName("dnsForwardingRuleset-");
            var createdDnsForwardingRuleset = await dnsForwardingRulesetCollection.CreateOrUpdateAsync(true, dnsForwardingRulesetName, dnsForwardingRulesetData);

            // ACT
            await createdDnsForwardingRuleset.Value.DeleteAsync(true);

            // ASSERT
            var getDnsForwardingRulesetResult = await dnsForwardingRulesetCollection.ExistsAsync(dnsForwardingRulesetName);
            Assert.AreEqual(getDnsForwardingRulesetResult.Value, false);
        }
    }
}
