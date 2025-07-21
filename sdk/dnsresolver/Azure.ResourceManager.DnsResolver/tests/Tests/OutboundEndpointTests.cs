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

        public OutboundEndpointTests(bool async) : base(async) //RecordedTestMode.Record)
        {
        }

        public async Task CreateDnsResolverCollection()
        {
            var dnsResolverName = Recording.GenerateAssetName("dnsResolver-");
            var vnetName = Recording.GenerateAssetName("vnet-");
            var resourceGroup = await CreateResourceGroupAsync();

            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                await CreateVirtualNetworkAsync();
            }
            //_vnetId = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{TestEnvironment.ResourceGroup}/providers/Microsoft.Network/virtualNetworks/{vnetName}";
            //_subnetId = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{TestEnvironment.ResourceGroup}/providers/Microsoft.Network/virtualNetworks/{vnetName}/subnets/{SubnetName}";

            var dnsResolverData = new DnsResolverData(this.DefaultLocation, new WritableSubResource
            {
                Id = new ResourceIdentifier(DefaultVnetID)
            });

            _dnsResolver = (await resourceGroup.GetDnsResolvers().CreateOrUpdateAsync(WaitUntil.Completed, dnsResolverName, dnsResolverData)).Value;
        }

        [Test]
        [RecordedTest]
        public async Task CreateOutboundEndpoint()
        {
            // ARRANGE
            var outboundEndpointName = Recording.GenerateAssetName("outboundEndpoint-");
            await CreateDnsResolverCollection();
            var outboundEndpointData = new DnsResolverOutboundEndpointData(this.DefaultLocation, new WritableSubResource
            {
                Id = new ResourceIdentifier(DefaultSubnetID),
            });

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
            var outboundEndpointName = Recording.GenerateAssetName("outboundEndpoint-");
            await CreateDnsResolverCollection();
            var outboundEndpointData = new DnsResolverOutboundEndpointData(this.DefaultLocation, new WritableSubResource
            {
                Id = new ResourceIdentifier(DefaultSubnetID),
            });

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
            var outboundEndpointName = Recording.GenerateAssetName("outboundEndpoint-");
            var newTagKey = Recording.GenerateAlphaNumericId("tagKey");
            var newTagValue = Recording.GenerateAlphaNumericId("tagValue");
            await CreateDnsResolverCollection();
            var outboundEndpointData = new DnsResolverOutboundEndpointData(this.DefaultLocation, new WritableSubResource
            {
                Id = new ResourceIdentifier(DefaultSubnetID),
            });

            var createdOutboundEndpoint = await _dnsResolver.GetDnsResolverOutboundEndpoints().CreateOrUpdateAsync(WaitUntil.Completed, outboundEndpointName, outboundEndpointData);

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
            var outboundEndpointName = Recording.GenerateAssetName("outboundEndpoint-");
            await CreateDnsResolverCollection();
            var outboundEndpointData = new DnsResolverOutboundEndpointData(this.DefaultLocation, new WritableSubResource
            {
                Id = new ResourceIdentifier(DefaultSubnetID),
            });

            var createdOutboundEndpoint = await _dnsResolver.GetDnsResolverOutboundEndpoints().CreateOrUpdateAsync(WaitUntil.Completed, outboundEndpointName, outboundEndpointData);

            // ACT
            await createdOutboundEndpoint.Value.DeleteAsync(WaitUntil.Completed);

            // ASSERT
            var getOutboundEndpointResult = await _dnsResolver.GetDnsResolverOutboundEndpoints().ExistsAsync(outboundEndpointName);
            Assert.AreEqual(getOutboundEndpointResult.Value, false);
        }
    }
}
