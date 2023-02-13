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
        private DnsResolverResource _dnsResolver;
        private DnsForwardingRulesetCollection _dnsForwardingRulesetCollection;
        private DnsForwardingRulesetResource _dnsForwardingRuleset;
        private ResourceIdentifier _outboundEndpointId;
        private string _vnetId;
        private string _subnetId;
        private string _dnsForwardingRulesetName;

        public VirtualNetworkLinkTests(bool async) : base(async)
        {
        }

        [SetUp]
        public async Task CreateDnsResolverCollection()
        {
            var dnsResolverName = Recording.GenerateAssetName("dnsResolver-");
            var vnetName = Recording.GenerateAssetName("dnsResolver-");

            _vnetId = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{TestEnvironment.ResourceGroup}/providers/Microsoft.Network/virtualNetworks/{vnetName}";
            _subnetId = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{TestEnvironment.ResourceGroup}/providers/Microsoft.Network/virtualNetworks/{vnetName}/subnets/{SubnetName}";

            var dnsResolverData = new DnsResolverData(this.DefaultLocation, new WritableSubResource
            {
                Id = new ResourceIdentifier(_vnetId)
            });

            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                await CreateVirtualNetworkAsync(vnetName);
            }

            var subscription = await Client.GetSubscriptions().GetAsync(TestEnvironment.SubscriptionId);
            var resourceGroup = await subscription.Value.GetResourceGroups().GetAsync(TestEnvironment.ResourceGroup);

            _dnsResolver = (await resourceGroup.Value.GetDnsResolvers().CreateOrUpdateAsync(WaitUntil.Completed, dnsResolverName, dnsResolverData)).Value;
            _dnsForwardingRulesetCollection = resourceGroup.Value.GetDnsForwardingRulesets();

            var outboundEndpointData = new DnsResolverOutboundEndpointData(this.DefaultLocation, new WritableSubResource
            {
                Id = new ResourceIdentifier(_subnetId),
            });

            var outboundEndpointName = Recording.GenerateAssetName("outboundEndpoint-");
            var outboundEndpoint = await _dnsResolver.GetDnsResolverOutboundEndpoints().CreateOrUpdateAsync(WaitUntil.Completed, outboundEndpointName, outboundEndpointData);

            _outboundEndpointId = outboundEndpoint.Value.Id;

            _dnsForwardingRulesetName = Recording.GenerateAssetName("dnsForwardingRuleset-");
            _dnsForwardingRuleset = await CreateDnsForwardingRuleset(_dnsForwardingRulesetName);
        }

        private async Task<DnsForwardingRulesetResource> CreateDnsForwardingRuleset(string dnsForwardingRulesetName)
        {
            var dnsForwardingRulesetData = new DnsForwardingRulesetData(this.DefaultLocation, new List<WritableSubResource>
            {
                new WritableSubResource
                {
                    Id = _outboundEndpointId,
                }
            });

            return (await _dnsForwardingRulesetCollection.CreateOrUpdateAsync(WaitUntil.Completed, dnsForwardingRulesetName, dnsForwardingRulesetData)).Value;
        }

        [Test]
        [RecordedTest]
        public async Task CreateVirtualNetworkLink()
        {
            // ARRANGE
            var virtualNetworkLinkData = new DnsForwardingRulesetVirtualNetworkLinkData(new WritableSubResource
            {
                Id = new ResourceIdentifier(_vnetId),
            });

            var virtualNetworkLinkName = Recording.GenerateAssetName("virtualNetworkLink-");

            // ACT
            var createdVirtualNetworkLink = await _dnsForwardingRuleset.GetDnsForwardingRulesetVirtualNetworkLinks().CreateOrUpdateAsync(WaitUntil.Completed, virtualNetworkLinkName, virtualNetworkLinkData);

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
                Id = new ResourceIdentifier(_vnetId),
            });

            var virtualNetworkLinkName = Recording.GenerateAssetName("virtualNetworkLink-");
            await _dnsForwardingRuleset.GetDnsForwardingRulesetVirtualNetworkLinks().CreateOrUpdateAsync(WaitUntil.Completed, virtualNetworkLinkName, virtualNetworkLinkData);

            // ACT
            var retrievedVirtualNetworkLink = await _dnsForwardingRuleset.GetDnsForwardingRulesetVirtualNetworkLinks().GetAsync(virtualNetworkLinkName);

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
                Id = new ResourceIdentifier(_vnetId),
            });

            var virtualNetworkLinkName = Recording.GenerateAssetName("virtualNetworkLink-");
            var createdVirtualNetworkLink = await _dnsForwardingRuleset.GetDnsForwardingRulesetVirtualNetworkLinks().CreateOrUpdateAsync(WaitUntil.Completed, virtualNetworkLinkName, virtualNetworkLinkData);

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
                Id = new ResourceIdentifier(_vnetId),
            });

            var virtualNetworkLinkName = Recording.GenerateAssetName("virtualNetworkLink-");
            var createdVirtualNetworkLink = await _dnsForwardingRuleset.GetDnsForwardingRulesetVirtualNetworkLinks().CreateOrUpdateAsync(WaitUntil.Completed, virtualNetworkLinkName, virtualNetworkLinkData);

            // ACT
            await createdVirtualNetworkLink.Value.DeleteAsync(WaitUntil.Completed);

            // ASSERT
            var getVirtualNetworkLink = await _dnsForwardingRuleset.GetDnsForwardingRulesetVirtualNetworkLinks().ExistsAsync(virtualNetworkLinkName);
            Assert.AreEqual(getVirtualNetworkLink.Value, false);
        }
    }
}
