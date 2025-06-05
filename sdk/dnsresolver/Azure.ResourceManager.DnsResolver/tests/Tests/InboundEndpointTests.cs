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

        public InboundEndpointTests(bool async) : base(async)//, RecordedTestMode.Record)
        {
        }

        public async Task CreateDnsResolverCollection()
        {
            var dnsResolverName = Recording.GenerateAssetName("dnsResolver-");
            var resourceGroup = await CreateResourceGroupAsync();
            (var vnetId, var subnetId) = await CreateVirtualNetworkAsync();
            //_vnetId = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{TestEnvironment.ResourceGroup}/providers/Microsoft.Network/virtualNetworks/{vnetName}";
            //_subnetId = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{TestEnvironment.ResourceGroup}/providers/Microsoft.Network/virtualNetworks/{vnetName}/subnets/{SubnetName}";

            var dnsResolverData = new DnsResolverData(this.DefaultLocation, new WritableSubResource
            {
                Id = new ResourceIdentifier(vnetId)
            });

            _dnsResolver = (await resourceGroup.GetDnsResolvers().CreateOrUpdateAsync(WaitUntil.Completed, dnsResolverName, dnsResolverData)).Value;
        }

        [Test]
        [RecordedTest]
        public async Task CreateInboundEndpoint()
        {
            // ARRANGE
            var inboundEndpointName = Recording.GenerateAssetName("inboundEndpoint-");
            await CreateDnsResolverCollection();
            var inboundEndpointData = new DnsResolverInboundEndpointData(this.DefaultLocation, new List<InboundEndpointIPConfiguration>
            {
                new InboundEndpointIPConfiguration(new WritableSubResource
                {
                    Id = new ResourceIdentifier(DefaultSubnetID),
                },
                privateIPAddress: null,
                InboundEndpointIPAllocationMethod.Dynamic, null)
            });

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
            var inboundEndpointName = Recording.GenerateAssetName("inboundEndpoint-");
            await CreateDnsResolverCollection();
            var inboundEndpointData = new DnsResolverInboundEndpointData(this.DefaultLocation, new List<InboundEndpointIPConfiguration>
            {
                new InboundEndpointIPConfiguration(new WritableSubResource
                {
                    Id = new ResourceIdentifier(DefaultSubnetID),
                },
                privateIPAddress: null,
                InboundEndpointIPAllocationMethod.Dynamic, null)
            });

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
            var inboundEndpointName = Recording.GenerateAssetName("inboundEndpoint-");
            await CreateDnsResolverCollection();
            var inboundEndpointData = new DnsResolverInboundEndpointData(this.DefaultLocation, new List<InboundEndpointIPConfiguration>
            {
                new InboundEndpointIPConfiguration(new WritableSubResource
                {
                    Id = new ResourceIdentifier(DefaultSubnetID),
                },
                privateIPAddress: null,
                InboundEndpointIPAllocationMethod.Dynamic, null)
            });

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
            var inboundEndpointName = Recording.GenerateAssetName("inboundEndpoint-");
            await CreateDnsResolverCollection();
            var inboundEndpointData = new DnsResolverInboundEndpointData(this.DefaultLocation, new List<InboundEndpointIPConfiguration>
            {
                new InboundEndpointIPConfiguration(new WritableSubResource
                {
                    Id = new ResourceIdentifier(DefaultSubnetID),
                },
                privateIPAddress: null,
                InboundEndpointIPAllocationMethod.Dynamic, null)
            });

            var createdInboundEndpoint = await _dnsResolver.GetDnsResolverInboundEndpoints().CreateOrUpdateAsync(WaitUntil.Completed, inboundEndpointName, inboundEndpointData);

            // ACT
            await createdInboundEndpoint.Value.DeleteAsync(WaitUntil.Completed);

            // ASSERT
            var getInboundEndpointResult = await _dnsResolver.GetDnsResolverInboundEndpoints().ExistsAsync(inboundEndpointName);
            Assert.AreEqual(getInboundEndpointResult.Value, false);
        }
    }
}
