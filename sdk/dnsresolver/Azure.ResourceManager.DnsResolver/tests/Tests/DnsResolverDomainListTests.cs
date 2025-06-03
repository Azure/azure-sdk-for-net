// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources.Models;
using Azure.Core;
using Azure.ResourceManager.DnsResolver.Models;
using System;

namespace Azure.ResourceManager.DnsResolver.Tests
{
    public class DnsResolverDomainListTests : DnsResolverTestBase
    {
        private DnsResolverDomainListCollection _dnsResolverDomainListCollection;

        public DnsResolverDomainListTests(bool async) : base(async)//, RecordedTestMode.Record)
        {
        }

        public async Task CreateDnsResolverDomainListCollectionAsync()
        {
            var subscription = await Client.GetSubscriptions().GetAsync(TestEnvironment.SubscriptionId);
            var resourceGroup = await CreateResourceGroupAsync();

            _dnsResolverDomainListCollection = resourceGroup.GetDnsResolverDomainLists();
        }

        [Test]
        [RecordedTest]
        public async Task CreateDnsResolverDomainListAsync()
        {
            // ARRANGE
            var dnsResolverDomainListName = Recording.GenerateAssetName("dnsResolverDomainList-");
            await CreateDnsResolverDomainListCollectionAsync();
            var dnsResolverDomainListData = new DnsResolverDomainListData(this.DefaultLocation);
            dnsResolverDomainListData.Domains.Add("example.com.");
            dnsResolverDomainListData.Domains.Add("contoso.com.");

            // ACT
            var dnsResolverDomainList = await _dnsResolverDomainListCollection.CreateOrUpdateAsync(WaitUntil.Completed, dnsResolverDomainListName, dnsResolverDomainListData);

            // ASSERT
            Assert.AreEqual(dnsResolverDomainList.Value.Data.ProvisioningState, DnsResolverProvisioningState.Succeeded);
        }

        [Test]
        [RecordedTest]
        public async Task CreateDnsResolverDomainListNoDomainsAsync()
        {
            // ARRANGE
            var dnsResolverDomainListName = Recording.GenerateAssetName("dnsResolverDomainList-");
            await CreateDnsResolverDomainListCollectionAsync();
            var dnsResolverDomainListData = new DnsResolverDomainListData(this.DefaultLocation);

            // ACT
            var dnsResolverDomainList = await _dnsResolverDomainListCollection.CreateOrUpdateAsync(WaitUntil.Completed, dnsResolverDomainListName, dnsResolverDomainListData);

            // ASSERT
            Assert.AreEqual(dnsResolverDomainList.Value.Data.ProvisioningState, DnsResolverProvisioningState.Succeeded);
            Assert.AreEqual(dnsResolverDomainList.Value.Data.Domains.Count, 0);
        }

        [Test]
        [RecordedTest]
        [Ignore("Requires SAS URL which cannot be added to code")]
        public async Task PostDnsResolverDomainListBulkRequestSucceedsAsync()
        {
            // ARRANGE
            var dnsResolverDomainListName = Recording.GenerateAssetName("dnsResolverDomainList-");
            var subscription = await Client.GetSubscriptions().GetAsync(TestEnvironment.SubscriptionId);
            var resourceGroup = await CreateResourceGroupAsync();
            _dnsResolverDomainListCollection = resourceGroup.GetDnsResolverDomainLists();
            var dnsResolverDomainListData = new DnsResolverDomainListData(this.DefaultLocation);

            await _dnsResolverDomainListCollection.CreateOrUpdateAsync(WaitUntil.Completed, dnsResolverDomainListName, dnsResolverDomainListData);
            ResourceIdentifier dnsResolverDomainListResourceId = DnsResolverDomainListResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, resourceGroup.Data.Id, dnsResolverDomainListName);
            DnsResolverDomainListResource dnsResolverDomainList = Client.GetDnsResolverDomainListResource(dnsResolverDomainListResourceId);

            // invoke the operation
            var dnsResolverDomainListBulk = new DnsResolverDomainListBulk(new Uri("ADD_STORAGE_URL_HERE"), DnsResolverDomainListBulkAction.Download);

            // ACT
            var lro = await dnsResolverDomainList.BulkAsync(WaitUntil.Completed, dnsResolverDomainListBulk);

            // ASSERT
            DnsResolverDomainListResource result = lro.Value;
            Assert.AreNotEqual(result.Data.DomainsUri, null);
        }

        [Test]
        [RecordedTest]
        public async Task GetDnsResolverDomainListAsync()
        {
            // ARRANGE
            var dnsResolverDomainListName = Recording.GenerateAssetName("dnsResolverDomainList-");
            await CreateDnsResolverDomainListCollectionAsync();
            var dnsResolverDomainListData = new DnsResolverDomainListData(this.DefaultLocation);
            dnsResolverDomainListData.Domains.Add("example.com.");
            dnsResolverDomainListData.Domains.Add("contoso.com.");

            await _dnsResolverDomainListCollection.CreateOrUpdateAsync(WaitUntil.Completed, dnsResolverDomainListName, dnsResolverDomainListData);

            // ACT
            var retrievedDnsResolverDomainList = await _dnsResolverDomainListCollection.GetAsync(dnsResolverDomainListName);

            // ASSERT
            Assert.AreEqual(retrievedDnsResolverDomainList.Value.Data.Name, dnsResolverDomainListName);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateDnsResolverDomainListAsync()
        {
            // ARRANGE
            var dnsResolverDomainListName = Recording.GenerateAssetName("dnsResolverDomainList-");
            var newTagKey = Recording.GenerateAlphaNumericId("tagKey");
            var newTagValue = Recording.GenerateAlphaNumericId("tagValue");
            await CreateDnsResolverDomainListCollectionAsync();
            var dnsResolverDomainListData = new DnsResolverDomainListData(this.DefaultLocation);
            dnsResolverDomainListData.Domains.Add("example.com.");
            dnsResolverDomainListData.Domains.Add("contoso.com.");

            var createdDnsResolverDomainList = await _dnsResolverDomainListCollection.CreateOrUpdateAsync(WaitUntil.Completed, dnsResolverDomainListName, dnsResolverDomainListData);

            // ACT
            var patchedDnsResolverDomainList = await createdDnsResolverDomainList.Value.AddTagAsync(newTagKey, newTagValue);

            // ASSERT
            CollectionAssert.AreEquivalent(new Dictionary<string, string> { { newTagKey, newTagValue } }, patchedDnsResolverDomainList.Value.Data.Tags);
        }

        [Test]
        [RecordedTest]
        public async Task RemoveDnsResolverDomainListAsync()
        {
            // ARRANGE
            var dnsResolverDomainListName = Recording.GenerateAssetName("dnsResolverDomainList-");
            await CreateDnsResolverDomainListCollectionAsync();
            var dnsResolverDomainListData = new DnsResolverDomainListData(this.DefaultLocation);
            dnsResolverDomainListData.Domains.Add("example.com.");
            dnsResolverDomainListData.Domains.Add("contoso.com.");

            var dnsResolverDomainList = await _dnsResolverDomainListCollection.CreateOrUpdateAsync(WaitUntil.Completed, dnsResolverDomainListName, dnsResolverDomainListData);

            // ACT
            await dnsResolverDomainList.Value.DeleteAsync(WaitUntil.Completed);

            // ASSERT
            var getDnsResolverDomainListResult = await _dnsResolverDomainListCollection.ExistsAsync(dnsResolverDomainListName);
            Assert.AreEqual(getDnsResolverDomainListResult.Value, false);
        }
    }
}
