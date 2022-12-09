// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources.Models;
using Azure.Core;
using Azure.ResourceManager.DnsResolver.Models;

namespace Azure.ResourceManager.DnsResolver.Tests
{
    public class DnsResolverTests : DnsResolverTestBase
    {
        private DnsResolverCollection _dnsResolverCollection;

        public DnsResolverTests(bool async) : base(async)
        {
        }

        [SetUp]
        public async Task CreateDnsResolverCollectionAsync()
        {
            var subscription = await Client.GetSubscriptions().GetAsync(TestEnvironment.SubscriptionId);
            var resourceGroup = await subscription.Value.GetResourceGroups().GetAsync(TestEnvironment.ResourceGroup);

            _dnsResolverCollection = resourceGroup.Value.GetDnsResolvers();
        }

        [Test]
        [RecordedTest]
        public async Task CreateDnsResolverAsync()
        {
            // ARRANGE
            var dnsResolverName = Recording.GenerateAssetName("dnsResolver-");
            var vnetName = Recording.GenerateAssetName("vnet-");
            var vnetId = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{TestEnvironment.ResourceGroup}/providers/Microsoft.Network/virtualNetworks/{vnetName}";
            var dnsResolverData = new DnsResolverData(this.DefaultLocation, new WritableSubResource
            {
                Id = new ResourceIdentifier(vnetId)
            });

            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                await CreateVirtualNetworkAsync(vnetName);
            }

            // ACT
            var dnsResolver = await _dnsResolverCollection.CreateOrUpdateAsync(WaitUntil.Completed, dnsResolverName, dnsResolverData);

            // ASSERT
            Assert.AreEqual(dnsResolver.Value.Data.ProvisioningState, DnsResolverProvisioningState.Succeeded);
        }

        [Test]
        [RecordedTest]
        public async Task GetDnsResolverAsync()
        {
            // ARRANGE
            var dnsResolverName = Recording.GenerateAssetName("dnsResolver-");
            var vnetName = Recording.GenerateAssetName("vnet-");
            var vnetId = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{TestEnvironment.ResourceGroup}/providers/Microsoft.Network/virtualNetworks/{vnetName}";
            var dnsResolverData = new DnsResolverData(this.DefaultLocation, new WritableSubResource
            {
                Id = new ResourceIdentifier(vnetId)
            });

            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                await CreateVirtualNetworkAsync(vnetName);
            }

            await _dnsResolverCollection.CreateOrUpdateAsync(WaitUntil.Completed, dnsResolverName, dnsResolverData);

            // ACT
            var retrievedDnsResolver = await _dnsResolverCollection.GetAsync(dnsResolverName);

            // ASSERT
            Assert.AreEqual(retrievedDnsResolver.Value.Data.Name, dnsResolverName);
        }

        [Test]
        [RecordedTest]
        [Ignore("Lack of testing resources")]
        public async Task UpdateDnsResolverAsync()
        {
            // ARRANGE
            var dnsResolverName = Recording.GenerateAssetName("dnsResolver-");
            var vnetName = Recording.GenerateAssetName("vnet-");
            var vnetId = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{TestEnvironment.ResourceGroup}/providers/Microsoft.Network/virtualNetworks/{vnetName}";
            var dnsResolverData = new DnsResolverData(this.DefaultLocation, new WritableSubResource
            {
                Id = new ResourceIdentifier(vnetId)
            });

            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                await CreateVirtualNetworkAsync(vnetName);
            }

            var createdDnsResolver = await _dnsResolverCollection.CreateOrUpdateAsync(WaitUntil.Completed, dnsResolverName, dnsResolverData);

            var newTagKey = Recording.GenerateAlphaNumericId("tagKey");
            var newTagValue = Recording.GenerateAlphaNumericId("tagValue");

            // ACT
            var patchedDnsResolver = await createdDnsResolver.Value.AddTagAsync(newTagKey, newTagValue);

            // ASSERT
            CollectionAssert.AreEquivalent(new Dictionary<string, string> { { newTagKey, newTagValue } }, patchedDnsResolver.Value.Data.Tags);
        }

        [Test]
        [RecordedTest]
        public async Task RemoveDnsResolverAsync()
        {
            // ARRANGE
            var dnsResolverName = Recording.GenerateAssetName("dnsResolver-");
            var vnetName = Recording.GenerateAssetName("vnet-");
            var vnetId = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{TestEnvironment.ResourceGroup}/providers/Microsoft.Network/virtualNetworks/{vnetName}";
            var dnsResolverData = new DnsResolverData(this.DefaultLocation, new WritableSubResource
            {
                Id = new ResourceIdentifier(vnetId)
            });

            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                await CreateVirtualNetworkAsync(vnetName);
            }

            var dnsResolver = await _dnsResolverCollection.CreateOrUpdateAsync(WaitUntil.Completed, dnsResolverName, dnsResolverData);

            // ACT
            await dnsResolver.Value.DeleteAsync(WaitUntil.Completed);

            // ASSERT
            var getDnsResolverResult = await _dnsResolverCollection.ExistsAsync(dnsResolverName);
            Assert.AreEqual(getDnsResolverResult.Value, false);
        }
    }
}
