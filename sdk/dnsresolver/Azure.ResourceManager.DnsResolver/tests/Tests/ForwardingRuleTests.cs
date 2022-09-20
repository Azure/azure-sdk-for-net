// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DnsResolver.Models;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.DnsResolver.Tests
{
    public class ForwardingRuleTests : DnsResolverTestBase
    {
        private DnsResolverResource dnsResolver;
        private DnsForwardingRulesetCollection dnsForwardingRulesetCollection;
        private DnsForwardingRulesetResource dnsForwardingRuleset;
        private ResourceIdentifier outboundEndpointId;
        private string vnetId;
        private string subnetId;
        private string dnsForwardingRulesetName;

        public ForwardingRuleTests(bool async) : base(async)
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
        public async Task CreateForwardingRule()
        {
            // ARRANGE
            var forwardingRuleData = new DnsForwardingRuleData("test.com.", new List<TargetDnsServer>
            {
                new TargetDnsServer(IPAddress.Parse("10.0.0.3"))
            });

            var forwardingRuleName = Recording.GenerateAssetName("forwardingRule-");

            // ACT
            var createdForwardingRule = await dnsForwardingRuleset.GetDnsForwardingRules().CreateOrUpdateAsync(WaitUntil.Completed, forwardingRuleName, forwardingRuleData);

            // ASSERT
            Assert.AreEqual(createdForwardingRule.Value.Data.ProvisioningState, DnsResolverProvisioningState.Succeeded);
        }

        [Test]
        [RecordedTest]
        public async Task GetForwardingRule()
        {
            // ARRANGE
            var forwardingRuleData = new DnsForwardingRuleData("test.com.", new List<TargetDnsServer>
            {
                new TargetDnsServer(IPAddress.Parse("10.0.0.3"))
            });

            var forwardingRuleName = Recording.GenerateAssetName("forwardingRule-");
            await dnsForwardingRuleset.GetDnsForwardingRules().CreateOrUpdateAsync(WaitUntil.Completed, forwardingRuleName, forwardingRuleData);

            // ACT
            var retrievedForwardingRule = await dnsForwardingRuleset.GetDnsForwardingRules().GetAsync(forwardingRuleName);

            // ASSERT
            Assert.AreEqual(retrievedForwardingRule.Value.Data.Name, forwardingRuleName);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateForwardingRule()
        {
            // ARRANGE
            var forwardingRuleData = new DnsForwardingRuleData("test.com.", new List<TargetDnsServer>
            {
                new TargetDnsServer(IPAddress.Parse("10.0.0.3"))
            });

            var forwardingRuleName = Recording.GenerateAssetName("forwardingRule-");
            var createdForwardingRule = await dnsForwardingRuleset.GetDnsForwardingRules().CreateOrUpdateAsync(WaitUntil.Completed, forwardingRuleName, forwardingRuleData);

            var newTagKey = Recording.GenerateAlphaNumericId("tagKey");
            var newTagValue = Recording.GenerateAlphaNumericId("tagValue");

            var patchableForwardingRuleData = new DnsForwardingRulePatch();
            patchableForwardingRuleData.Metadata.Add(newTagKey, newTagValue);

            // ACT
            var patchedForwardingRule = await createdForwardingRule.Value.UpdateAsync(patchableForwardingRuleData);

            // ASSERT
            CollectionAssert.AreEquivalent(patchedForwardingRule.Value.Data.Metadata, patchableForwardingRuleData.Metadata);
        }

        [Test]
        [RecordedTest]
        public async Task RemoveForwardingRule()
        {
            // ARRANGE
            var forwardingRuleData = new DnsForwardingRuleData("test.com.", new List<TargetDnsServer>
            {
                new TargetDnsServer(IPAddress.Parse("10.0.0.3"))
            });

            var forwardingRuleName = Recording.GenerateAssetName("forwardingRule-");
            var createdForwardingRule = await dnsForwardingRuleset.GetDnsForwardingRules().CreateOrUpdateAsync(WaitUntil.Completed, forwardingRuleName, forwardingRuleData);

            // ACT
            await createdForwardingRule.Value.DeleteAsync(WaitUntil.Completed);

            // ASSERT
            var getForwardingRule = await dnsForwardingRuleset.GetDnsForwardingRules().ExistsAsync(forwardingRuleName);
            Assert.AreEqual(getForwardingRule.Value, false);
        }
    }
}
