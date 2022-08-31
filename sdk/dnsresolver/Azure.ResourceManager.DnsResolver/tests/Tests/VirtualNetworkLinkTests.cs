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
    public class VirtualNetworkLinkTests : DnsResolverTestBase
    {
        private DnsResolverResource dnsResolver;
        private DnsForwardingRulesetCollection dnsForwardingRulesetCollection;
        private DnsForwardingRulesetResource dnsForwardingRuleset;
        private ResourceIdentifier outboundEndpointId;
        private string vnetId;
        private string subnetId;
        private string dnsForwardingRulesetName;

        public VirtualNetworkLinkTests(bool async) : base(async)
        {
        }

        [SetUp]
        public async Task CreateDnsResolverCollection()
        {
            var dnsResolverName = Recording.GenerateAssetName("dnsResolver-");
            var vnetName = Recording.GenerateAssetName("dnsResolver-");

            vnetId = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{TestEnvironment.ResourceGroup}/providers/Microsoft.Network/virtualNetworks/{vnetName}";
            subnetId = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{TestEnvironment.ResourceGroup}/providers/Microsoft.Network/virtualNetworks/{vnetName}/subnets/snet-sim2";

            var dnsResolverData = new DnsResolverData(this.DefaultLocation, new WritableSubResource
            {
                Id = new ResourceIdentifier(vnetId)
            });

            if (Mode == RecordedTestMode.Record)
            {
                await CreateVirtualNetworkAsync(vnetName);
                await CreateSubnetAsync(vnetName);
            }

            var subscription = await Client.GetSubscriptions().GetAsync(TestEnvironment.SubscriptionId);
            var resourceGroup = await subscription.Value.GetResourceGroups().GetAsync(TestEnvironment.ResourceGroup);

            dnsResolver = (await resourceGroup.Value.GetDnsResolvers().CreateOrUpdateAsync(WaitUntil.Completed, dnsResolverName, dnsResolverData)).Value;
            dnsForwardingRulesetCollection = resourceGroup.Value.GetDnsForwardingRulesets();

            var outboundEndpointData = new DnsResolverOutboundEndpointData(this.DefaultLocation, new WritableSubResource
            {
                Id = new ResourceIdentifier(subnetId),
            });

            var outboundEndpointName = Recording.GenerateAssetName("outboundEndpoint-");
            var outboundEndpoint = await dnsResolver.GetDnsResolverOutboundEndpoints().CreateOrUpdateAsync(WaitUntil.Completed, outboundEndpointName, outboundEndpointData);

            outboundEndpointId = outboundEndpoint.Value.Id;

            dnsForwardingRulesetName = Recording.GenerateAssetName("dnsForwardingRuleset-");
            dnsForwardingRuleset = await CreateDnsForwardingRuleset(dnsForwardingRulesetName);
        }

        private async Task<DnsForwardingRulesetResource> CreateDnsForwardingRuleset(string dnsForwardingRulesetName)
        {
            var dnsForwardingRulesetData = new DnsForwardingRulesetData(this.DefaultLocation, new List<WritableSubResource>
            {
                new WritableSubResource
                {
                    Id = outboundEndpointId,
                }
            });

            return (await dnsForwardingRulesetCollection.CreateOrUpdateAsync(WaitUntil.Completed, dnsForwardingRulesetName, dnsForwardingRulesetData)).Value;
        }

        [Test]
        [RecordedTest]
        public async Task CreateVirtualNetworkLink()
        {
            // ARRANGE
            var virtualNetworkLinkData = new DnsForwardingRulesetVirtualNetworkLinkData(new WritableSubResource
            {
                Id = new ResourceIdentifier(vnetId),
            });

            var virtualNetworkLinkName = Recording.GenerateAssetName("virtualNetworkLink-");

            // ACT
            var createdVirtualNetworkLink = await dnsForwardingRuleset.GetDnsForwardingRulesetVirtualNetworkLinks().CreateOrUpdateAsync(WaitUntil.Completed, virtualNetworkLinkName, virtualNetworkLinkData);

            // ASSERT
            Assert.AreEqual(createdVirtualNetworkLink.Value.Data.ProvisioningState, DnsResolverProvisioningState.Succeeded);
        }

        [Test]
        [RecordedTest]
        public async Task GetVirtualNetworkLink()
        {
            // ARRANGE
            var virtualNetworkLinkData = new DnsForwardingRulesetVirtualNetworkLinkData(new WritableSubResource
            {
                Id = new ResourceIdentifier(vnetId),
            });

            var virtualNetworkLinkName = Recording.GenerateAssetName("virtualNetworkLink-");
            await dnsForwardingRuleset.GetDnsForwardingRulesetVirtualNetworkLinks().CreateOrUpdateAsync(WaitUntil.Completed, virtualNetworkLinkName, virtualNetworkLinkData);

            // ACT
            var retrievedVirtualNetworkLink = await dnsForwardingRuleset.GetDnsForwardingRulesetVirtualNetworkLinks().GetAsync(virtualNetworkLinkName);

            // ASSERT
            Assert.AreEqual(retrievedVirtualNetworkLink.Value.Data.Name, virtualNetworkLinkName);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateVirtualNetworkLink()
        {
            // ARRANGE
            var virtualNetworkLinkData = new DnsForwardingRulesetVirtualNetworkLinkData(new WritableSubResource
            {
                Id = new ResourceIdentifier(vnetId),
            });

            var virtualNetworkLinkName = Recording.GenerateAssetName("virtualNetworkLink-");
            var createdVirtualNetworkLink = await dnsForwardingRuleset.GetDnsForwardingRulesetVirtualNetworkLinks().CreateOrUpdateAsync(WaitUntil.Completed, virtualNetworkLinkName, virtualNetworkLinkData);

            var newTagKey = Recording.GenerateAlphaNumericId("tagKey");
            var newTagValue = Recording.GenerateAlphaNumericId("tagValue");

            var patchableVirtualNetworkLinkData = new DnsForwardingRulesetVirtualNetworkLinkPatch();
            patchableVirtualNetworkLinkData.Metadata.Add(newTagKey, newTagValue);

            // ACT
            var patchedVirtualNetworkLink = await createdVirtualNetworkLink.Value.UpdateAsync(WaitUntil.Completed, patchableVirtualNetworkLinkData);

            // ASSERT
            CollectionAssert.AreEquivalent(patchedVirtualNetworkLink.Value.Data.Metadata, patchableVirtualNetworkLinkData.Metadata);
        }

        [Test]
        [RecordedTest]
        public async Task RemoveVirtualNetworkLink()
        {
            // ARRANGE
            var virtualNetworkLinkData = new DnsForwardingRulesetVirtualNetworkLinkData(new WritableSubResource
            {
                Id = new ResourceIdentifier(vnetId),
            });

            var virtualNetworkLinkName = Recording.GenerateAssetName("virtualNetworkLink-");
            var createdVirtualNetworkLink = await dnsForwardingRuleset.GetDnsForwardingRulesetVirtualNetworkLinks().CreateOrUpdateAsync(WaitUntil.Completed, virtualNetworkLinkName, virtualNetworkLinkData);

            // ACT
            await createdVirtualNetworkLink.Value.DeleteAsync(WaitUntil.Completed);

            // ASSERT
            var getVirtualNetworkLink = await dnsForwardingRuleset.GetDnsForwardingRulesetVirtualNetworkLinks().ExistsAsync(virtualNetworkLinkName);
            Assert.AreEqual(getVirtualNetworkLink.Value, false);
        }
    }
}
