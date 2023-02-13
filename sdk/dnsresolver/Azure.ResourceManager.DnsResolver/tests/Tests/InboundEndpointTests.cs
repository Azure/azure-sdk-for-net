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
using NUnit.Framework.Internal;

namespace Azure.ResourceManager.DnsResolver.Tests
{
    public class InboundEndpointTests : DnsResolverTestBase
    {
        private DnsResolverResource _dnsResolver;
        private string _vnetId;
        private string _subnetId;

        public InboundEndpointTests(bool async) : base(async)
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
        public async Task CreateInboundEndpoint()
        {
            // ARRANGE
            var inboundEndpointData = new DnsResolverInboundEndpointData(this.DefaultLocation, new List<InboundEndpointIPConfiguration>
            {
                new InboundEndpointIPConfiguration(new WritableSubResource
                {
                    Id = new ResourceIdentifier(_subnetId),
                },
                privateIPAddress: null,
                InboundEndpointIPAllocationMethod.Dynamic)
            });

            var inboundEndpointName = Recording.GenerateAssetName("inboundEndpoint-");

            // ACT
            var inboundEndpoint = await _dnsResolver.GetDnsResolverInboundEndpoints().CreateOrUpdateAsync(WaitUntil.Completed, inboundEndpointName, inboundEndpointData);

            // ASSERT
            Assert.AreEqual(inboundEndpoint.Value.Data.ProvisioningState, DnsResolverProvisioningState.Succeeded);
        }

        [Test]
        [RecordedTest]
        public async Task GetInboundEndpoint()
        {
            // ARRANGE
            var inboundEndpointData = new DnsResolverInboundEndpointData(this.DefaultLocation, new List<InboundEndpointIPConfiguration>
            {
                new InboundEndpointIPConfiguration(new WritableSubResource
                {
                    Id = new ResourceIdentifier(_subnetId),
                },
                privateIPAddress: null,
                InboundEndpointIPAllocationMethod.Dynamic)
            });

            var inboundEndpointName = Recording.GenerateAssetName("inboundEndpoint-");
            await _dnsResolver.GetDnsResolverInboundEndpoints().CreateOrUpdateAsync(WaitUntil.Completed, inboundEndpointName, inboundEndpointData);

            // ACT
            var retrievedInboundEndpoint = await _dnsResolver.GetDnsResolverInboundEndpoints().GetAsync(inboundEndpointName);

            // ASSERT
            Assert.AreEqual(retrievedInboundEndpoint.Value.Data.Name, inboundEndpointName);
        }

        [Test]
        [RecordedTest]
        [Ignore("Lack of testing resources")]
        public async Task UpdateInboundEndpoint()
        {
            // ARRANGE
            var inboundEndpointData = new DnsResolverInboundEndpointData(this.DefaultLocation, new List<InboundEndpointIPConfiguration>
            {
                new InboundEndpointIPConfiguration(new WritableSubResource
                {
                    Id = new ResourceIdentifier(_subnetId),
                },
                privateIPAddress: null,
                InboundEndpointIPAllocationMethod.Dynamic)
            });

            var inboundEndpointName = Recording.GenerateAssetName("inboundEndpoint-");
            var createdInboundEndpoint = await _dnsResolver.GetDnsResolverInboundEndpoints().CreateOrUpdateAsync(WaitUntil.Completed, inboundEndpointName, inboundEndpointData);

            var newTagKey = Recording.GenerateAlphaNumericId("tagKey");
            var newTagValue = Recording.GenerateAlphaNumericId("tagValue");

            // ACT
            var patchedInboundEndpoint = await createdInboundEndpoint.Value.AddTagAsync(newTagKey, newTagValue);

            // ASSERT
            CollectionAssert.AreEquivalent(new Dictionary<string, string> { { newTagKey, newTagValue } }, patchedInboundEndpoint.Value.Data.Tags);
        }

        [Test]
        [RecordedTest]
        public async Task RemoveInboundEndpoint()
        {
            // ARRANGE
            var inboundEndpointData = new DnsResolverInboundEndpointData(this.DefaultLocation, new List<InboundEndpointIPConfiguration>
            {
                new InboundEndpointIPConfiguration(new WritableSubResource
                {
                    Id = new ResourceIdentifier(_subnetId),
                },
                privateIPAddress: null,
                InboundEndpointIPAllocationMethod.Dynamic)
            });

            var inboundEndpointName = Recording.GenerateAssetName("inboundEndpoint-");
            var createdInboundEndpoint = await _dnsResolver.GetDnsResolverInboundEndpoints().CreateOrUpdateAsync(WaitUntil.Completed, inboundEndpointName, inboundEndpointData);

            // ACT
            await createdInboundEndpoint.Value.DeleteAsync(WaitUntil.Completed);

            // ASSERT
            var getInboundEndpointResult = await _dnsResolver.GetDnsResolverInboundEndpoints().ExistsAsync(inboundEndpointName);
            Assert.AreEqual(getInboundEndpointResult.Value, false);
        }
    }
}
