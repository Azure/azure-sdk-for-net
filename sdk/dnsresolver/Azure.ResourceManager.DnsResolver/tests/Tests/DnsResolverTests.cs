// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
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
    }
}
