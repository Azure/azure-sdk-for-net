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
        private DnsResolverResource _dnsResolver;
        private DnsForwardingRulesetCollection _dnsForwardingRulesetCollection;
        private ResourceIdentifier _outboundEndpointId;
        //private string _vnetId ;
        //private string _subnetId;

        public DnsForwardingRulesetTests(bool async) : base(async) // RecordedTestMode.Record)
        {
        }

        public async Task CreateDnsResolverCollection()
        {
            var dnsResolverName = Recording.GenerateAssetName("dnsResolver-");
            var resourceGroup = await CreateResourceGroupAsync();
            var outboundEndpointName = Recording.GenerateAssetName("outboundEndpoint-");

            //_vnetId = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{TestEnvironment.ResourceGroup}/providers/Microsoft.Network/virtualNetworks/{vnetName}";
            //_subnetId = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{TestEnvironment.ResourceGroup}/providers/Microsoft.Network/virtualNetworks/{vnetName}/subnets/{SubnetName}";

            (var vnetId, var subnetId) = await CreateVirtualNetworkAsync();
            var dnsResolverData = new DnsResolverData(this.DefaultLocation, new WritableSubResource
            {
                Id = new ResourceIdentifier(vnetId)
            });

            dnsResolverData.VirtualNetwork = new WritableSubResource()
            {
                Id = new ResourceIdentifier(vnetId)
            };

            _dnsResolver = (await resourceGroup.GetDnsResolvers().CreateOrUpdateAsync(WaitUntil.Completed, dnsResolverName, dnsResolverData)).Value;
            _dnsForwardingRulesetCollection = resourceGroup.GetDnsForwardingRulesets();

            var outboundEndpointData = new DnsResolverOutboundEndpointData(this.DefaultLocation, new WritableSubResource
            {
                Id = new ResourceIdentifier(subnetId),
            });

            var outboundEndpoint = await _dnsResolver.GetDnsResolverOutboundEndpoints().CreateOrUpdateAsync(WaitUntil.Completed, outboundEndpointName, outboundEndpointData);

            _outboundEndpointId = outboundEndpoint.Value.Id;
        }

        [Test]
        [RecordedTest]
        public async Task CreateDnsForwardingRuleset()
        {
            // ARRANGE
            var dnsForwardingRulesetName = Recording.GenerateAssetName("dnsForwardingRuleset-");
            await CreateDnsResolverCollection();
            var dnsForwardingRulesetData = new DnsForwardingRulesetData(this.DefaultLocation, new List<WritableSubResource>
            {
                new WritableSubResource
                {
                    Id = _outboundEndpointId,
                }
            });

            // ACT
            var dnsForwardingRuleset = await _dnsForwardingRulesetCollection.CreateOrUpdateAsync(WaitUntil.Completed, dnsForwardingRulesetName, dnsForwardingRulesetData);

            // ASSERT
            Assert.AreEqual(dnsForwardingRuleset.Value.Data.ProvisioningState, DnsResolverProvisioningState.Succeeded);
        }

        [Test]
        [RecordedTest]
        public async Task GetDnsForwardingRuleset()
        {
            // ARRANGE
            var dnsForwardingRulesetName = Recording.GenerateAssetName("dnsForwardingRuleset-");
            await CreateDnsResolverCollection();
            var dnsForwardingRulesetData = new DnsForwardingRulesetData(this.DefaultLocation, new List<WritableSubResource>
            {
                new WritableSubResource
                {
                    Id = _outboundEndpointId,
                }
            });

            await _dnsForwardingRulesetCollection.CreateOrUpdateAsync(WaitUntil.Completed, dnsForwardingRulesetName, dnsForwardingRulesetData);

            // ACT
            var retrievedDnsForwardingRuleset = await _dnsForwardingRulesetCollection.GetAsync(dnsForwardingRulesetName);

            // ASSERT
            Assert.AreEqual(retrievedDnsForwardingRuleset.Value.Data.Name, dnsForwardingRulesetName);
        }

        [Test]
        [RecordedTest]
        [Ignore("Lack of testing resources")]
        public async Task UpdateDnsForwardingRuleset()
        {
            // ARRANGE
            var dnsForwardingRulesetName = Recording.GenerateAssetName("dnsForwardingRuleset-");
            var newTagKey = Recording.GenerateAlphaNumericId("tagKey");
            var newTagValue = Recording.GenerateAlphaNumericId("tagValue");
            await CreateDnsResolverCollection();
            var dnsForwardingRulesetData = new DnsForwardingRulesetData(this.DefaultLocation, new List<WritableSubResource>
            {
                new WritableSubResource
                {
                    Id = _outboundEndpointId,
                }
            });

            var createdDnsForwardingRuleset = await _dnsForwardingRulesetCollection.CreateOrUpdateAsync(WaitUntil.Completed, dnsForwardingRulesetName, dnsForwardingRulesetData);

            // ACT
            var patchedDnsForwardingRuleset = await createdDnsForwardingRuleset.Value.AddTagAsync(newTagKey, newTagValue);

            // ASSERT
            CollectionAssert.AreEquivalent(new Dictionary<string, string> { { newTagKey, newTagValue } }, patchedDnsForwardingRuleset.Value.Data.Tags);
        }

        [Test]
        [RecordedTest]
        public async Task RemoveDnsForwardingRuleset()
        {
            // ARRANGE
            var dnsForwardingRulesetName = Recording.GenerateAssetName("dnsForwardingRuleset-");
            await CreateDnsResolverCollection();
            var dnsForwardingRulesetData = new DnsForwardingRulesetData(this.DefaultLocation, new List<WritableSubResource>
            {
                new WritableSubResource
                {
                    Id = _outboundEndpointId,
                }
            });

            var createdDnsForwardingRuleset = await _dnsForwardingRulesetCollection.CreateOrUpdateAsync(WaitUntil.Completed, dnsForwardingRulesetName, dnsForwardingRulesetData);

            // ACT
            await createdDnsForwardingRuleset.Value.DeleteAsync(WaitUntil.Completed);

            // ASSERT
            var getDnsForwardingRulesetResult = await _dnsForwardingRulesetCollection.ExistsAsync(dnsForwardingRulesetName);
            Assert.AreEqual(getDnsForwardingRulesetResult.Value, false);
        }
    }
}
