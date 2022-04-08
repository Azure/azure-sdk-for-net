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

            dnsResolver = (await resourceGroup.Value.GetDnsResolvers().CreateOrUpdateAsync(WaitUntil.Completed, dnsResolverName, dnsResolverData)).Value;
            dnsForwardingRulesetCollection = resourceGroup.Value.GetDnsForwardingRulesets();

            var outboundEndpointData = new OutboundEndpointData(this.DefaultLocation);

            outboundEndpointData.Subnet = new WritableSubResource()
            {
                Id = new ResourceIdentifier(subnetId),
            };

            var outboundEndpointName = Recording.GenerateAssetName("outboundEndpoint-");
            var outboundEndpoint = await dnsResolver.GetOutboundEndpoints().CreateOrUpdateAsync(WaitUntil.Completed, outboundEndpointName, outboundEndpointData);

            outboundEndpointId = outboundEndpoint.Value.Id;

            dnsForwardingRulesetName = Recording.GenerateAssetName("dnsForwardingRuleset-");
            dnsForwardingRuleset = await CreateDnsForwardingRuleset(dnsForwardingRulesetName);
        }

        private async Task<DnsForwardingRulesetResource> CreateDnsForwardingRuleset(string dnsForwardingRulesetName)
        {
            var dnsForwardingRulesetData = new DnsForwardingRulesetData(this.DefaultLocation);

            dnsForwardingRulesetData.DnsResolverOutboundEndpoints.Add(new WritableSubResource()
            {
                Id = outboundEndpointId,
            });

            return (await dnsForwardingRulesetCollection.CreateOrUpdateAsync(WaitUntil.Completed, dnsForwardingRulesetName, dnsForwardingRulesetData)).Value;
        }

        [Test]
        [RecordedTest]
        public async Task CreateForwardingRule()
        {
            // ARRANGE
            var forwardingRuleData = new ForwardingRuleData();

            forwardingRuleData.DomainName = "test.com.";
            forwardingRuleData.TargetDnsServers.Add(new TargetDnsServer()
            {
                IPAddress = "10.0.0.3",
            });

            var forwardingRuleName = Recording.GenerateAssetName("forwardingRule-");

            // ACT
            var createdForwardingRule = await dnsForwardingRuleset.GetForwardingRules().CreateOrUpdateAsync(WaitUntil.Completed, forwardingRuleName, forwardingRuleData);

            // ASSERT
            Assert.AreEqual(createdForwardingRule.Value.Data.ProvisioningState, ProvisioningState.Succeeded);
        }

        [Test]
        [RecordedTest]
        public async Task GetForwardingRule()
        {
            // ARRANGE
            var forwardingRuleData = new ForwardingRuleData();

            forwardingRuleData.DomainName = "test.com.";
            forwardingRuleData.TargetDnsServers.Add(new TargetDnsServer()
            {
                IPAddress = "10.0.0.3",
            });

            var forwardingRuleName = Recording.GenerateAssetName("forwardingRule-");
            await dnsForwardingRuleset.GetForwardingRules().CreateOrUpdateAsync(WaitUntil.Completed, forwardingRuleName, forwardingRuleData);

            // ACT
            var retrievedForwardingRule = await dnsForwardingRuleset.GetForwardingRules().GetAsync(forwardingRuleName);

            // ASSERT
            Assert.AreEqual(retrievedForwardingRule.Value.Data.Name, forwardingRuleName);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateForwardingRule()
        {
            // ARRANGE
            var forwardingRuleData = new ForwardingRuleData();

            forwardingRuleData.DomainName = "test.com.";
            forwardingRuleData.TargetDnsServers.Add(new TargetDnsServer()
            {
                IPAddress = "10.0.0.3",
            });

            var forwardingRuleName = Recording.GenerateAssetName("forwardingRule-");
            var createdForwardingRule = await dnsForwardingRuleset.GetForwardingRules().CreateOrUpdateAsync(WaitUntil.Completed, forwardingRuleName, forwardingRuleData);

            var newTagKey = Recording.GenerateAlphaNumericId("tagKey");
            var newTagValue = Recording.GenerateAlphaNumericId("tagValue");

            var patchableForwardingRuleData = new ForwardingRulePatch();
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
            var forwardingRuleData = new ForwardingRuleData();

            forwardingRuleData.DomainName = "test.com.";
            forwardingRuleData.TargetDnsServers.Add(new TargetDnsServer()
            {
                IPAddress = "10.0.0.3",
            });

            var forwardingRuleName = Recording.GenerateAssetName("forwardingRule-");
            var createdForwardingRule = await dnsForwardingRuleset.GetForwardingRules().CreateOrUpdateAsync(WaitUntil.Completed, forwardingRuleName, forwardingRuleData);

            // ACT
            await createdForwardingRule.Value.DeleteAsync(WaitUntil.Completed);

            // ASSERT
            var getForwardingRule = await dnsForwardingRuleset.GetForwardingRules().ExistsAsync(forwardingRuleName);
            Assert.AreEqual(getForwardingRule.Value, false);
        }
    }
}
