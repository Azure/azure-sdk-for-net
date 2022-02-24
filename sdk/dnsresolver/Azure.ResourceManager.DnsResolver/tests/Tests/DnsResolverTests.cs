// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using NUnit.Framework;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources.Models;
using Azure.Core;
using Azure.ResourceManager.DnsResolver.Models;
using System.Linq;

namespace Azure.ResourceManager.DnsResolver.Tests
{
    public class DnsResolverTests : DnsResolverTestBase
    {
        private DnsResolverCollection dnsResolverCollection;

        public DnsResolverTests(bool async) : base(async)
        {
        }

        [SetUp]
        public async Task CreateDnsResolverCollectionAsync()
        {
            var subscription = await Client.GetSubscriptions().GetAsync(TestEnvironment.SubscriptionId);
            var resourceGroup = await subscription.Value.GetResourceGroups().GetAsync(TestEnvironment.ResourceGroup);

            this.dnsResolverCollection = resourceGroup.Value.GetDnsResolvers();
        }

        [Test]
        public async Task CreateDnsResolverAsync()
        {
            // ARRANGE
            var dnsResolverName = Recording.GenerateAssetName("dnsResolver-");
            var vnetName = Recording.GenerateAssetName("dnsResolver-");
            var dnsResolverData = new DnsResolverData(this.DefaultLocation);
            var vnetId = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{TestEnvironment.ResourceGroup}/providers/Microsoft.Network/virtualNetworks/{vnetName}";

            if (Mode == RecordedTestMode.Record)
            {
                await CreateVirtualNetworkAsync(vnetName);
            }

            dnsResolverData.VirtualNetwork = new WritableSubResource()
            {
                Id = new ResourceIdentifier(vnetId)
            };

            // ACT
            var dnsResolver = await this.dnsResolverCollection.CreateOrUpdateAsync(true, dnsResolverName, dnsResolverData);

            // ASSERT
            Assert.AreEqual(dnsResolver.Value.Data.ProvisioningState, ProvisioningState.Succeeded);
        }

        [Test]
        public async Task GetDnsResolverAsync()
        {
            // ARRANGE
            var dnsResolverName = Recording.GenerateAssetName("dnsResolver-");
            var vnetName = Recording.GenerateAssetName("dnsResolver-");
            var dnsResolverData = new DnsResolverData(this.DefaultLocation);
            var vnetId = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{TestEnvironment.ResourceGroup}/providers/Microsoft.Network/virtualNetworks/{vnetName}";

            if (Mode == RecordedTestMode.Record)
            {
                await CreateVirtualNetworkAsync(vnetName);
            }

            dnsResolverData.VirtualNetwork = new WritableSubResource()
            {
                Id = new ResourceIdentifier(vnetId)
            };

            await this.dnsResolverCollection.CreateOrUpdateAsync(true, dnsResolverName, dnsResolverData);

            // ACT
            var retrievedDnsResolver = await this.dnsResolverCollection.GetAsync(dnsResolverName);

            // ASSERT
            Assert.AreEqual(retrievedDnsResolver.Value.Data.Name, dnsResolverName);
        }

        [Test]
        public async Task UpdateDnsResolverAsync()
        {
            // ARRANGE
            var dnsResolverName = Recording.GenerateAssetName("dnsResolver-");
            var vnetName = Recording.GenerateAssetName("dnsResolver-");
            var dnsResolverData = new DnsResolverData(this.DefaultLocation);
            var vnetId = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{TestEnvironment.ResourceGroup}/providers/Microsoft.Network/virtualNetworks/{vnetName}";

            if (Mode == RecordedTestMode.Record)
            {
                await CreateVirtualNetworkAsync(vnetName);
            }

            dnsResolverData.VirtualNetwork = new WritableSubResource()
            {
                Id = new ResourceIdentifier(vnetId)
            };

            var createdDnsResolver = await this.dnsResolverCollection.CreateOrUpdateAsync(true, dnsResolverName, dnsResolverData);

            var newTagKey = Recording.GenerateAlphaNumericId("tagKey");
            var newTagValue = Recording.GenerateAlphaNumericId("tagValue");

            var dnsResolverPatch = new DnsResolverPatch();
            dnsResolverPatch.Tags.Add(newTagKey, newTagValue);

            // ACT
            var patchedDnsResolver = await createdDnsResolver.Value.UpdateAsync(true, dnsResolverPatch );

            // ASSERT
            CollectionAssert.AreEquivalent(patchedDnsResolver.Value.Data.Tags, dnsResolverPatch.Tags);
        }

        [Test]
        public async Task RemoveDnsResolverAsync()
        {
            // ARRANGE
            var dnsResolverName = Recording.GenerateAssetName("dnsResolver-");
            var vnetName = Recording.GenerateAssetName("dnsResolver-");
            var dnsResolverData = new DnsResolverData(this.DefaultLocation);
            var vnetId = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{TestEnvironment.ResourceGroup}/providers/Microsoft.Network/virtualNetworks/{vnetName}";

            if (Mode == RecordedTestMode.Record)
            {
                await CreateVirtualNetworkAsync(vnetName);
            }

            dnsResolverData.VirtualNetwork = new WritableSubResource()
            {
                Id = new ResourceIdentifier(vnetId)
            };

            var dnsResolver = await this.dnsResolverCollection.CreateOrUpdateAsync(true, dnsResolverName, dnsResolverData);

            // ACT
            await dnsResolver.Value.DeleteAsync(true);

            // ASSERT
            var getDnsResolverResult = await this.dnsResolverCollection.ExistsAsync(dnsResolverName);
            Assert.AreEqual(getDnsResolverResult.Value, false);
        }
    }
}
