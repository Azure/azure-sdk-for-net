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
    public class OutboundEndpointTests : DnsResolverTestBase
    {
        private DnsResolverResource _dnsResolver;
        private string _vnetId;
        private string _subnetId;

        public OutboundEndpointTests(bool async) : base(async)
        {
        }

        [SetUp]
        public async Task CreateDnsResolverCollection()
        {
            var dnsResolverName = Recording.GenerateAssetName("dnsResolver-");
            var vnetName = Recording.GenerateAssetName("vnet-");

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
        }

        [Test]
        [RecordedTest]
        public async Task CreateOutboundEndpoint()
        {
            // ARRANGE
            var outboundEndpointData = new DnsResolverOutboundEndpointData(this.DefaultLocation, new WritableSubResource
            {
                Id = new ResourceIdentifier(_subnetId),
            });

            var outboundEndpointName = Recording.GenerateAssetName("outboundEndpoint-");

            // ACT
            var outboundEndpoint = await _dnsResolver.GetDnsResolverOutboundEndpoints().CreateOrUpdateAsync(WaitUntil.Completed, outboundEndpointName, outboundEndpointData);

            // ASSERT
            Assert.AreEqual(outboundEndpoint.Value.Data.ProvisioningState, DnsResolverProvisioningState.Succeeded);
        }

        [Test]
        [RecordedTest]
        public async Task GetOutboundEndpoint()
        {
            // ARRANGE
            var outboundEndpointData = new DnsResolverOutboundEndpointData(this.DefaultLocation, new WritableSubResource
            {
                Id = new ResourceIdentifier(_subnetId),
            });

            var outboundEndpointName = Recording.GenerateAssetName("outboundEndpoint-");
            await _dnsResolver.GetDnsResolverOutboundEndpoints().CreateOrUpdateAsync(WaitUntil.Completed, outboundEndpointName, outboundEndpointData);

            // ACT
            var retrievedOutboundEndpoint = await _dnsResolver.GetDnsResolverOutboundEndpoints().GetAsync(outboundEndpointName);

            // ASSERT
            Assert.AreEqual(retrievedOutboundEndpoint.Value.Data.Name, outboundEndpointName);
        }

        [Test]
        [RecordedTest]
        [Ignore("Lack of testing resources")]
        public async Task UpdateOutboundEndpoint()
        {
            // ARRANGE
            var outboundEndpointData = new DnsResolverOutboundEndpointData(this.DefaultLocation, new WritableSubResource
            {
                Id = new ResourceIdentifier(_subnetId),
            });

            var outboundEndpointName = Recording.GenerateAssetName("outboundEndpoint-");
            var createdOutboundEndpoint = await _dnsResolver.GetDnsResolverOutboundEndpoints().CreateOrUpdateAsync(WaitUntil.Completed, outboundEndpointName, outboundEndpointData);

            var newTagKey = Recording.GenerateAlphaNumericId("tagKey");
            var newTagValue = Recording.GenerateAlphaNumericId("tagValue");

            // ACT
            var patchedOutboundEndpoint = await createdOutboundEndpoint.Value.AddTagAsync(newTagKey, newTagValue);

            // ASSERT
            CollectionAssert.AreEquivalent(new Dictionary<string, string> { { newTagKey, newTagValue } }, patchedOutboundEndpoint.Value.Data.Tags);
        }

        [Test]
        [RecordedTest]
        public async Task RemoveOutboundEndpoint()
        {
            // ARRANGE
            var outboundEndpointData = new DnsResolverOutboundEndpointData(this.DefaultLocation, new WritableSubResource
            {
                Id = new ResourceIdentifier(_subnetId),
            });

            var outboundEndpointName = Recording.GenerateAssetName("outboundEndpoint-");
            var createdOutboundEndpoint = await _dnsResolver.GetDnsResolverOutboundEndpoints().CreateOrUpdateAsync(WaitUntil.Completed, outboundEndpointName, outboundEndpointData);

            // ACT
            await createdOutboundEndpoint.Value.DeleteAsync(WaitUntil.Completed);

            // ASSERT
            var getOutboundEndpointResult = await _dnsResolver.GetDnsResolverOutboundEndpoints().ExistsAsync(outboundEndpointName);
            Assert.AreEqual(getOutboundEndpointResult.Value, false);
        }
    }
}
