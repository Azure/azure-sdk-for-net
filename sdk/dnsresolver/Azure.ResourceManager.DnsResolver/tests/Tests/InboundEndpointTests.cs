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
        private DnsResolverResource dnsResolver;
        private string vnetId;
        private string subnetId;

        public InboundEndpointTests(bool async) : base(async)
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
        }

        [Test]
        [RecordedTest]
        public async Task CreateInboundEndpoint()
        {
            // ARRANGE
            var inboundEndpointData = new InboundEndpointData(this.DefaultLocation);

            inboundEndpointData.IPConfigurations.Add(new IPConfiguration()
            {
                PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                Subnet = new WritableSubResource()
                {
                    Id = new ResourceIdentifier(subnetId),
                },
            });

            var inboundEndpointName = Recording.GenerateAssetName("inboundEndpoint-");

            // ACT
            var inboundEndpoint = await dnsResolver.GetInboundEndpoints().CreateOrUpdateAsync(WaitUntil.Completed, inboundEndpointName, inboundEndpointData);

            // ASSERT
            Assert.AreEqual(inboundEndpoint.Value.Data.ProvisioningState, ProvisioningState.Succeeded);
        }

        [Test]
        [RecordedTest]
        public async Task GetInboundEndpoint()
        {
            // ARRANGE
            var inboundEndpointData = new InboundEndpointData(this.DefaultLocation);

            inboundEndpointData.IPConfigurations.Add(new IPConfiguration()
            {
                PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                Subnet = new WritableSubResource()
                {
                    Id = new ResourceIdentifier(subnetId),
                },
            });

            var inboundEndpointName = Recording.GenerateAssetName("inboundEndpoint-");
            await dnsResolver.GetInboundEndpoints().CreateOrUpdateAsync(WaitUntil.Completed, inboundEndpointName, inboundEndpointData);

            // ACT
            var retrievedInboundEndpoint = await dnsResolver.GetInboundEndpoints().GetAsync(inboundEndpointName);

            // ASSERT
            Assert.AreEqual(retrievedInboundEndpoint.Value.Data.Name, inboundEndpointName);
        }

        [Test]
        [RecordedTest]
        [Ignore("Lack of testing resources")]
        public async Task UpdateInboundEndpoint()
        {
            // ARRANGE
            var inboundEndpointData = new InboundEndpointData(this.DefaultLocation);

            inboundEndpointData.IPConfigurations.Add(new IPConfiguration()
            {
                PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                Subnet = new WritableSubResource()
                {
                    Id = new ResourceIdentifier(subnetId),
                },
            });

            var inboundEndpointName = Recording.GenerateAssetName("inboundEndpoint-");
            var createdInboundEndpoint = await dnsResolver.GetInboundEndpoints().CreateOrUpdateAsync(WaitUntil.Completed, inboundEndpointName, inboundEndpointData);

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
            var inboundEndpointData = new InboundEndpointData(this.DefaultLocation);

            inboundEndpointData.IPConfigurations.Add(new IPConfiguration()
            {
                PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                Subnet = new WritableSubResource()
                {
                    Id = new ResourceIdentifier(subnetId),
                },
            });

            var inboundEndpointName = Recording.GenerateAssetName("inboundEndpoint-");
            var createdInboundEndpoint = await dnsResolver.GetInboundEndpoints().CreateOrUpdateAsync(WaitUntil.Completed, inboundEndpointName, inboundEndpointData);

            // ACT
            await createdInboundEndpoint.Value.DeleteAsync(WaitUntil.Completed);

            // ASSERT
            var getInboundEndpointResult = await dnsResolver.GetInboundEndpoints().ExistsAsync(inboundEndpointName);
            Assert.AreEqual(getInboundEndpointResult.Value, false);
        }
    }
}
