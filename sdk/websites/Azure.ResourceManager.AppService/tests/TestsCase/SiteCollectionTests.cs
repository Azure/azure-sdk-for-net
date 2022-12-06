// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.AppService.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.AppService.Tests.TestsCase
{
    public class SiteCollectionTests : AppServiceTestBase
    {
        public SiteCollectionTests(bool isAsync)
           : base(isAsync)
        {
        }

        private async Task<WebSiteCollection> GetSiteCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup.GetWebSites();
        }

        [TestCase]
        [RecordedTest]
        public async Task SiteCreateOrUpdate()
        {
            var container = await GetSiteCollectionAsync();
            var name = Recording.GenerateAssetName("testSite");
            var input = ResourceDataHelper.GetBasicSiteData(DefaultLocation);
            var lro = await container.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            var site = lro.Value;
            Assert.AreEqual(name, site.Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var container = await GetSiteCollectionAsync();
            var siteName = Recording.GenerateAssetName("testSite-");
            var input = ResourceDataHelper.GetBasicSiteData(DefaultLocation);
            var lro = await container.CreateOrUpdateAsync(WaitUntil.Completed, siteName, input);
            WebSiteResource site1 = lro.Value;
            WebSiteResource site2 = await container.GetAsync(siteName);
            ResourceDataHelper.AssertSite(site1.Data, site2.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            var container = await GetSiteCollectionAsync();
            var input = ResourceDataHelper.GetBasicSiteData(DefaultLocation);
            _ = await container.CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testSite-"), input);
            _ = await container.CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testSite-"), input);
            int count = 0;
            await foreach (var site in container.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 2);
        }

        [TestCase]
        [RecordedTest]
        public async Task Exists()
        {
            var container = await GetSiteCollectionAsync();
            var siteName = Recording.GenerateAssetName("testSite-");
            var input = ResourceDataHelper.GetBasicSiteData(DefaultLocation);
            var lro = await container.CreateOrUpdateAsync(WaitUntil.Completed, siteName, input);
            WebSiteResource site = lro.Value;
            Assert.IsTrue(await container.ExistsAsync(siteName));
            Assert.IsFalse(await container.ExistsAsync(siteName + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await container.ExistsAsync(null));
        }
    }
}
