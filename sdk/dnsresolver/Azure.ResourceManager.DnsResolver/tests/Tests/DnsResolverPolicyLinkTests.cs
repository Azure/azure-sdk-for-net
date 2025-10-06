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
    public class DnsResolverPolicyLinkTests : DnsResolverTestBase
    {
        private DnsResolverPolicyCollection _dnsResolverPolicyCollection;
        private DnsResolverPolicyResource _dnsResolverPolicy;
        private string _dnsResolverPolicyName;

        public DnsResolverPolicyLinkTests(bool async) : base(async)//, RecordedTestMode.Record)
        {
        }

        public async Task CreateDnsResolverCollection()
        {
            var vnetName = Recording.GenerateAssetName("vnet-");
            _dnsResolverPolicyName = Recording.GenerateAssetName("dnsResolverPolicy-");
            var resourceGroup = await CreateResourceGroupAsync();
            _dnsResolverPolicyCollection = resourceGroup.GetDnsResolverPolicies();

            await CreateVirtualNetworkAsync();
            _dnsResolverPolicy = await CreateDnsResolverPolicy(_dnsResolverPolicyName);
        }

        private async Task<DnsResolverPolicyResource> CreateDnsResolverPolicy(string dnsResolverPolicyName)
        {
            var dnsResolverPolicyData = new DnsResolverPolicyData(this.DefaultLocation);

            return (await _dnsResolverPolicyCollection.CreateOrUpdateAsync(WaitUntil.Completed, dnsResolverPolicyName, dnsResolverPolicyData)).Value;
        }

        [Test]
        [RecordedTest]
        public async Task CreateDnsResolverPolicyLink()
        {
            // ARRANGE
            var dnsResolverPolicyLinkName = Recording.GenerateAssetName("dnsResolverPolicyLink-");
            await CreateDnsResolverCollection();
            var dnsResolverPolicyLinkData = new DnsResolverPolicyVirtualNetworkLinkData(this.DefaultLocation, new WritableSubResource
            {
                Id = new ResourceIdentifier(DefaultVnetID),
            });

            // ACT
            var createdDnsResolverPolicyLink = await _dnsResolverPolicy.GetDnsResolverPolicyVirtualNetworkLinks().CreateOrUpdateAsync(WaitUntil.Completed, dnsResolverPolicyLinkName, dnsResolverPolicyLinkData);

            // ASSERT
            Assert.AreEqual(createdDnsResolverPolicyLink.Value.Data.ProvisioningState, DnsResolverProvisioningState.Succeeded);
        }

        [Test]
        [RecordedTest]
        public async Task GetDnsResolverPolicyLink()
        {
            // ARRANGE
            var dnsResolverPolicyLinkName = Recording.GenerateAssetName("dnsResolverPolicyLink-");
            await CreateDnsResolverCollection();
            var dnsResolverPolicyLinkData = new DnsResolverPolicyVirtualNetworkLinkData(this.DefaultLocation, new WritableSubResource
            {
                Id = new ResourceIdentifier(DefaultVnetID),
            });

            await _dnsResolverPolicy.GetDnsResolverPolicyVirtualNetworkLinks().CreateOrUpdateAsync(WaitUntil.Completed, dnsResolverPolicyLinkName, dnsResolverPolicyLinkData);

            // ACT
            var retrievedDnsResolverPolicyLink = await _dnsResolverPolicy.GetDnsResolverPolicyVirtualNetworkLinks().GetAsync(dnsResolverPolicyLinkName);

            // ASSERT
            Assert.AreEqual(retrievedDnsResolverPolicyLink.Value.Data.Name, dnsResolverPolicyLinkName);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateDnsResolverPolicyLink()
        {
            // ARRANGE
            var dnsResolverPolicyLinkName = Recording.GenerateAssetName("dnsResolverPolicyLink-");
            var newTagKey = Recording.GenerateAlphaNumericId("tagKey");
            var newTagValue = Recording.GenerateAlphaNumericId("tagValue");
            await CreateDnsResolverCollection();
            var dnsResolverPolicyLinkData = new DnsResolverPolicyVirtualNetworkLinkData(this.DefaultLocation, new WritableSubResource
            {
                Id = new ResourceIdentifier(DefaultVnetID),
            });

            var createdDnsResolverPolicyLink = await _dnsResolverPolicy.GetDnsResolverPolicyVirtualNetworkLinks().CreateOrUpdateAsync(WaitUntil.Completed, dnsResolverPolicyLinkName, dnsResolverPolicyLinkData);

            var patchableDnsResolverPolicyLinkData = new DnsResolverPolicyVirtualNetworkLinkPatch();
            patchableDnsResolverPolicyLinkData.Tags.Add(newTagKey, newTagValue);

            // ACT
            var patchedDnsResolverPolicyLink = await createdDnsResolverPolicyLink.Value.UpdateAsync(WaitUntil.Completed, patchableDnsResolverPolicyLinkData);

            // ASSERT
            CollectionAssert.AreEquivalent(patchedDnsResolverPolicyLink.Value.Data.Tags, patchableDnsResolverPolicyLinkData.Tags);
        }

        [Test]
        [RecordedTest]
        public async Task RemoveDnsResolverPolicyLink()
        {
            // ARRANGE
            var dnsResolverPolicyLinkName = Recording.GenerateAssetName("dnsResolverPolicyLink-");
            await CreateDnsResolverCollection();
            var dnsResolverPolicyLinkData = new DnsResolverPolicyVirtualNetworkLinkData(this.DefaultLocation, new WritableSubResource
            {
                Id = new ResourceIdentifier(DefaultVnetID),
            });

            var createdDnsResolverPolicyLink = await _dnsResolverPolicy.GetDnsResolverPolicyVirtualNetworkLinks().CreateOrUpdateAsync(WaitUntil.Completed, dnsResolverPolicyLinkName, dnsResolverPolicyLinkData);

            // ACT
            await createdDnsResolverPolicyLink.Value.DeleteAsync(WaitUntil.Completed);

            // ASSERT
            var getDnsResolverPolicyLink = await _dnsResolverPolicy.GetDnsResolverPolicyVirtualNetworkLinks().ExistsAsync(dnsResolverPolicyLinkName);
            Assert.AreEqual(getDnsResolverPolicyLink.Value, false);
        }
    }
}
