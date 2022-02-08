// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    public class ResourceLinkCollectionTests : ResourceManagerTestBase
    {
        public ResourceLinkCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            Tenant tenant = await Client.GetTenants().GetAllAsync().FirstOrDefaultAsync(_ => true);
            Subscription subscription = await tenant.GetSubscriptions().GetAllAsync().FirstOrDefaultAsync(_ => true);
            string rgName = Recording.GenerateAssetName("testRg-");
            ResourceGroup rg = await CreateResourceGroup(subscription, rgName);
            string vnName1 = Recording.GenerateAssetName("testVn-");
            string vnName2 = Recording.GenerateAssetName("testVn-");
            GenericResource vn1 = await CreateGenericVirtualNetwork(subscription, rg, vnName1);
            GenericResource vn2 = await CreateGenericVirtualNetwork(subscription, rg, vnName2);
            string resourceLinkName = Recording.GenerateAssetName("link-");
            ResourceLink resourceLink = await CreateResourceLink(tenant, vn1, vn2, resourceLinkName);
            Assert.AreEqual(resourceLinkName, resourceLink.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await tenant.GetResourceLinks(null).CreateOrUpdateAsync(true, null));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await tenant.GetResourceLinks(rg.Id).CreateOrUpdateAsync(true, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            Tenant tenant = await Client.GetTenants().GetAllAsync().FirstOrDefaultAsync(_ => true);
            Subscription subscription = await tenant.GetSubscriptions().GetAllAsync().FirstOrDefaultAsync(_ => true);
            string rgName = Recording.GenerateAssetName("testRg-");
            ResourceGroup rg = await CreateResourceGroup(subscription, rgName);
            string vnName1 = Recording.GenerateAssetName("testVn-");
            string vnName2 = Recording.GenerateAssetName("testVn-");
            string vnName3 = Recording.GenerateAssetName("testVn-");
            GenericResource vn1 = await CreateGenericVirtualNetwork(subscription, rg, vnName1);
            GenericResource vn2 = await CreateGenericVirtualNetwork(subscription, rg, vnName2);
            GenericResource vn3 = await CreateGenericVirtualNetwork(subscription, rg, vnName3);
            string resourceLinkName1 = Recording.GenerateAssetName("link-");
            string resourceLinkName2 = Recording.GenerateAssetName("link-");
            _ = await CreateResourceLink(tenant, vn1, vn2, resourceLinkName1);
            _ = await CreateResourceLink(tenant, vn1, vn3, resourceLinkName2);
            int count = 0;
            await foreach (var resourceLink in tenant.GetResourceLinks(vn1.Id).GetAllAsync())
            {
                count++;
            }
            Assert.AreEqual(count, 2);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            Tenant tenant = await Client.GetTenants().GetAllAsync().FirstOrDefaultAsync(_ => true);
            Subscription subscription = await tenant.GetSubscriptions().GetAllAsync().FirstOrDefaultAsync(_ => true);
            string rgName = Recording.GenerateAssetName("testRg-");
            ResourceGroup rg = await CreateResourceGroup(subscription, rgName);
            string vnName1 = Recording.GenerateAssetName("testVn-");
            string vnName2 = Recording.GenerateAssetName("testVn-");
            GenericResource vn1 = await CreateGenericVirtualNetwork(subscription, rg, vnName1);
            GenericResource vn2 = await CreateGenericVirtualNetwork(subscription, rg, vnName2);
            string resourceLinkName = Recording.GenerateAssetName("link-");
            ResourceLink resourceLink = await CreateResourceLink(tenant, vn1, vn2, resourceLinkName);
            ResourceLink getResourceLink = await tenant.GetResourceLinks(resourceLink.Id).GetAsync();
            AssertValidResourceLink(resourceLink, getResourceLink);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await tenant.GetResourceLinks(null).GetAsync());
        }

        private void AssertValidResourceLink(ResourceLink model, ResourceLink getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.Type, getResult.Data.Type);
            if(model.Data.Properties != null || getResult.Data.Properties != null)
            {
                Assert.NotNull(model.Data.Properties);
                Assert.NotNull(getResult.Data.Properties);
                Assert.AreEqual(model.Data.Properties.Notes, getResult.Data.Properties.Notes);
                Assert.AreEqual(model.Data.Properties.SourceId, getResult.Data.Properties.SourceId);
                Assert.AreEqual(model.Data.Properties.TargetId, getResult.Data.Properties.TargetId);
            }
        }
    }
}
