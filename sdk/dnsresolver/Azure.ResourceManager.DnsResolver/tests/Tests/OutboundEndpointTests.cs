﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
        private DnsResolver dnsResolver;
        private string vnetId;
        private string subnetId;

        public OutboundEndpointTests(bool async) : base(async)
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

            dnsResolver = (await resourceGroup.Value.GetDnsResolvers().CreateOrUpdateAsync(true, dnsResolverName, dnsResolverData)).Value;
        }

        [RecordedTest]
        public async Task CreateOutboundEndpoint()
        {
            // ARRANGE
            var outboundEndpointData = new OutboundEndpointData(this.DefaultLocation);

            outboundEndpointData.Subnet = new WritableSubResource()
            {
                Id = new ResourceIdentifier(subnetId),
            };

            var outboundEndpointName = Recording.GenerateAssetName("outboundEndpoint-");

            // ACT
            var outboundEndpoint = await dnsResolver.GetOutboundEndpoints().CreateOrUpdateAsync(true, outboundEndpointName, outboundEndpointData);

            // ASSERT
            Assert.AreEqual(outboundEndpoint.Value.Data.ProvisioningState, ProvisioningState.Succeeded);
        }

        [RecordedTest]
        public async Task GetOutboundEndpoint()
        {
            // ARRANGE
            var outboundEndpointData = new OutboundEndpointData(this.DefaultLocation);

            outboundEndpointData.Subnet = new WritableSubResource()
            {
                Id = new ResourceIdentifier(subnetId),
            };

            var outboundEndpointName = Recording.GenerateAssetName("outboundEndpoint-");
            await dnsResolver.GetOutboundEndpoints().CreateOrUpdateAsync(true, outboundEndpointName, outboundEndpointData);

            // ACT
            var retrievedOutboundEndpoint = await dnsResolver.GetOutboundEndpoints().GetAsync(outboundEndpointName);

            // ASSERT
            Assert.AreEqual(retrievedOutboundEndpoint.Value.Data.Name, outboundEndpointName);
        }

        [RecordedTest]
        public async Task UpdateOutboundEndpoint()
        {
            // ARRANGE
            var outboundEndpointData = new OutboundEndpointData(this.DefaultLocation);

            outboundEndpointData.Subnet = new WritableSubResource()
            {
                Id = new ResourceIdentifier(subnetId),
            };

            var outboundEndpointName = Recording.GenerateAssetName("outboundEndpoint-");
            var createdOutboundEndpoint = await dnsResolver.GetOutboundEndpoints().CreateOrUpdateAsync(true, outboundEndpointName, outboundEndpointData);

            var newTagKey = Recording.GenerateAlphaNumericId("tagKey");
            var newTagValue = Recording.GenerateAlphaNumericId("tagValue");

            var outboundEndpointUpdateOptions = new OutboundEndpointUpdateOptions();
            outboundEndpointUpdateOptions.Tags.Add(newTagKey, newTagValue);

            // ACT
            var patchedOutboundEndpoint = await createdOutboundEndpoint.Value.UpdateAsync(true, outboundEndpointUpdateOptions);

            // ASSERT
            CollectionAssert.AreEquivalent(patchedOutboundEndpoint.Value.Data.Tags, outboundEndpointUpdateOptions.Tags);
        }

        [RecordedTest]
        public async Task RemoveOutboundEndpoint()
        {
            // ARRANGE
            var outboundEndpointData = new OutboundEndpointData(this.DefaultLocation);

            outboundEndpointData.Subnet = new WritableSubResource()
            {
                Id = new ResourceIdentifier(subnetId),
            };

            var outboundEndpointName = Recording.GenerateAssetName("outboundEndpoint-");
            var createdOutboundEndpoint = await dnsResolver.GetOutboundEndpoints().CreateOrUpdateAsync(true, outboundEndpointName, outboundEndpointData);

            // ACT
            await createdOutboundEndpoint.Value.DeleteAsync(true);

            // ASSERT
            var getOutboundEndpointResult = await dnsResolver.GetOutboundEndpoints().ExistsAsync(outboundEndpointName);
            Assert.AreEqual(getOutboundEndpointResult.Value, false);
        }
    }
}
