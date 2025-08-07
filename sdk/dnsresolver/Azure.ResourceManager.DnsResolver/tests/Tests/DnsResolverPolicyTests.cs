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
    public class DnsResolverPolicyTests : DnsResolverTestBase
    {
        private DnsResolverPolicyCollection _dnsResolverPolicyCollection;

        public DnsResolverPolicyTests(bool async) : base(async)//, RecordedTestMode.Record)
        {
        }

        public async Task CreateDnsResolverPolicyCollectionAsync()
        {
            var subscription = await Client.GetSubscriptions().GetAsync(TestEnvironment.SubscriptionId);
            var resourceGroup = await CreateResourceGroupAsync();

            _dnsResolverPolicyCollection = resourceGroup.GetDnsResolverPolicies();
        }

        [Test]
        [RecordedTest]
        public async Task CreateDnsResolverPolicyAsync()
        {
            // ARRANGE
            var dnsResolverPolicyName = Recording.GenerateAssetName("dnsResolverPolicy-");
            await CreateDnsResolverPolicyCollectionAsync();
            var dnsResolverPolicyData = new DnsResolverPolicyData(this.DefaultLocation);

            // ACT
            var dnsResolverPolicy = await _dnsResolverPolicyCollection.CreateOrUpdateAsync(WaitUntil.Completed, dnsResolverPolicyName, dnsResolverPolicyData);

            // ASSERT
            Assert.AreEqual(dnsResolverPolicy.Value.Data.ProvisioningState, DnsResolverProvisioningState.Succeeded);
        }

        [Test]
        [RecordedTest]
        public async Task GetDnsResolverPolicyAsync()
        {
            // ARRANGE
            var dnsResolverPolicyName = Recording.GenerateAssetName("dnsResolverPolicy-");
            await CreateDnsResolverPolicyCollectionAsync();
            ;
            var dnsResolverPolicyData = new DnsResolverPolicyData(this.DefaultLocation);

            await _dnsResolverPolicyCollection.CreateOrUpdateAsync(WaitUntil.Completed, dnsResolverPolicyName, dnsResolverPolicyData);

            // ACT
            var retrievedDnsResolverPolicy = await _dnsResolverPolicyCollection.GetAsync(dnsResolverPolicyName);

            // ASSERT
            Assert.AreEqual(retrievedDnsResolverPolicy.Value.Data.Name, dnsResolverPolicyName);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateDnsResolverPolicyAsync()
        {
            // ARRANGE
            var dnsResolverPolicyName = Recording.GenerateAssetName("dnsResolverPolicy-");
            var newTagKey = Recording.GenerateAlphaNumericId("tagKey");
            var newTagValue = Recording.GenerateAlphaNumericId("tagValue");
            await CreateDnsResolverPolicyCollectionAsync();
            var dnsResolverPolicyData = new DnsResolverPolicyData(this.DefaultLocation);

            var createdDnsResolverPolicy = await _dnsResolverPolicyCollection.CreateOrUpdateAsync(WaitUntil.Completed, dnsResolverPolicyName, dnsResolverPolicyData);

            // ACT
            var patchedDnsResolverPolicy = await createdDnsResolverPolicy.Value.AddTagAsync(newTagKey, newTagValue);

            // ASSERT
            CollectionAssert.AreEquivalent(new Dictionary<string, string> { { newTagKey, newTagValue } }, patchedDnsResolverPolicy.Value.Data.Tags);
        }

        [Test]
        [RecordedTest]
        public async Task RemoveDnsResolverPolicyAsync()
        {
            // ARRANGE
            var dnsResolverPolicyName = Recording.GenerateAssetName("dnsResolverPolicy-");
            await CreateDnsResolverPolicyCollectionAsync();
            var dnsResolverPolicyData = new DnsResolverPolicyData(this.DefaultLocation);

            var dnsResolverPolicy = await _dnsResolverPolicyCollection.CreateOrUpdateAsync(WaitUntil.Completed, dnsResolverPolicyName, dnsResolverPolicyData);

            // ACT
            await dnsResolverPolicy.Value.DeleteAsync(WaitUntil.Completed);

            // ASSERT
            var getDnsResolverPolicyResult = await _dnsResolverPolicyCollection.ExistsAsync(dnsResolverPolicyName);
            Assert.AreEqual(getDnsResolverPolicyResult.Value, false);
        }
    }
}
