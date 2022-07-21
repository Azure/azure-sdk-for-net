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
        private DnsResolverResource dnsResolver;
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

            dnsResolverData.VirtualNetwork = new WritableSubResource()
            {
                Id = new ResourceIdentifier(vnetId)
            };

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
        }

        [Test]
        [RecordedTest]
        public async Task CreateDnsForwardingRuleset()
        {
            // ARRANGE
            var dnsForwardingRulesetData = new DnsForwardingRulesetData(this.DefaultLocation, new List<WritableSubResource>
            {
                new WritableSubResource
                {
                    Id = outboundEndpointId,
                }
            });

            var dnsForwardingRulesetName = Recording.GenerateAssetName("dnsForwardingRuleset-");

            // ACT
            var dnsForwardingRuleset = await dnsForwardingRulesetCollection.CreateOrUpdateAsync(WaitUntil.Completed, dnsForwardingRulesetName, dnsForwardingRulesetData);

            // ASSERT
            Assert.AreEqual(dnsForwardingRuleset.Value.Data.ProvisioningState, DnsResolverProvisioningState.Succeeded);
        }

        [Test]
        [RecordedTest]
        public async Task GetDnsForwardingRuleset()
        {
            // ARRANGE
            var dnsForwardingRulesetData = new DnsForwardingRulesetData(this.DefaultLocation, new List<WritableSubResource>
            {
                new WritableSubResource
                {
                    Id = outboundEndpointId,
                }
            });

            var dnsForwardingRulesetName = Recording.GenerateAssetName("dnsForwardingRuleset-");
            await dnsForwardingRulesetCollection.CreateOrUpdateAsync(WaitUntil.Completed, dnsForwardingRulesetName, dnsForwardingRulesetData);

            // ACT
            var retrievedDnsForwardingRuleset = await dnsForwardingRulesetCollection.GetAsync(dnsForwardingRulesetName);

            // ASSERT
            Assert.AreEqual(retrievedDnsForwardingRuleset.Value.Data.Name, dnsForwardingRulesetName);
        }

        [Test]
        [RecordedTest]
        [Ignore("Lack of testing resources")]
        public async Task UpdateDnsForwardingRuleset()
        {
            // ARRANGE
            var dnsForwardingRulesetData = new DnsForwardingRulesetData(this.DefaultLocation, new List<WritableSubResource>
            {
                new WritableSubResource
                {
                    Id = outboundEndpointId,
                }
            });

            var dnsForwardingRulesetName = Recording.GenerateAssetName("dnsForwardingRuleset-");
            var createdDnsForwardingRuleset = await dnsForwardingRulesetCollection.CreateOrUpdateAsync(WaitUntil.Completed, dnsForwardingRulesetName, dnsForwardingRulesetData);

            var newTagKey = Recording.GenerateAlphaNumericId("tagKey");
            var newTagValue = Recording.GenerateAlphaNumericId("tagValue");

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
            var dnsForwardingRulesetData = new DnsForwardingRulesetData(this.DefaultLocation, new List<WritableSubResource>
            {
                new WritableSubResource
                {
                    Id = outboundEndpointId,
                }
            });

            var dnsForwardingRulesetName = Recording.GenerateAssetName("dnsForwardingRuleset-");
            var createdDnsForwardingRuleset = await dnsForwardingRulesetCollection.CreateOrUpdateAsync(WaitUntil.Completed, dnsForwardingRulesetName, dnsForwardingRulesetData);

            // ACT
            await createdDnsForwardingRuleset.Value.DeleteAsync(WaitUntil.Completed);

            // ASSERT
            var getDnsForwardingRulesetResult = await dnsForwardingRulesetCollection.ExistsAsync(dnsForwardingRulesetName);
            Assert.AreEqual(getDnsForwardingRulesetResult.Value, false);
        }
    }
}
