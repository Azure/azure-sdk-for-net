// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.AppService.Tests.Helpers;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.AppService.Tests.TestsCase
{
    public class StaticSiteCollectionTests : AppServiceTestBase
    {
        protected AzureLocation StaticSiteLocation => AzureLocation.EastUS2;
        public StaticSiteCollectionTests(bool isAsync)
           : base(isAsync)
        {
        }

        private async Task<StaticSiteCollection> GetStaticSiteCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup.GetStaticSites();
        }

        [TestCase]
        [RecordedTest]
        [Ignore("RepositoryToken is invalid.Please ensure the repository exists and the RepositoryToken is for an admin of the repository.")]
        public async Task CreateOrUpdate()
        {
            var container = await GetStaticSiteCollectionAsync();
            var name = Recording.GenerateAssetName("testStaticSite");
            var input = ResourceDataHelper.GetBasicStaticSiteARMResourceData(StaticSiteLocation);
            var lro = await container.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            var staticSite = lro.Value;
            Assert.AreEqual(name, staticSite.Data.Name);
        }

        [TestCase]
        [RecordedTest]
        [Ignore("RepositoryToken is invalid.Please ensure the repository exists and the RepositoryToken is for an admin of the repository.")]
        public async Task Get()
        {
            var container = await GetStaticSiteCollectionAsync();
            var staticSiteName = Recording.GenerateAssetName("testStaticSite");
            var input = ResourceDataHelper.GetBasicStaticSiteARMResourceData(StaticSiteLocation);
            var lro = await container.CreateOrUpdateAsync(WaitUntil.Completed, staticSiteName, input);
            StaticSiteResource staticSite1 = lro.Value;
            StaticSiteResource staticSite2 = await container.GetAsync(staticSiteName);
            ResourceDataHelper.AssertStaticSiteARMResourceData(staticSite1.Data, staticSite2.Data);
        }

        [TestCase]
        [RecordedTest]
        [Ignore("RepositoryToken is invalid.Please ensure the repository exists and the RepositoryToken is for an admin of the repository.")]
        public async Task GetAll()
        {
            var container = await GetStaticSiteCollectionAsync();
            var input = ResourceDataHelper.GetBasicStaticSiteARMResourceData(StaticSiteLocation);
            _ = await container.CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testStaticSite"), input);
            _ = await container.CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testStaticSite-"), input);
            int count = 0;
            await foreach (var staticSitel in container.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 2);
        }

        [TestCase]
        [RecordedTest]
        [Ignore("RepositoryToken is invalid.Please ensure the repository exists and the RepositoryToken is for an admin of the repository.")]
        public async Task Exists()
        {
            var container = await GetStaticSiteCollectionAsync();
            var staticSiteName = Recording.GenerateAssetName("testStaticSite");
            var input = ResourceDataHelper.GetBasicStaticSiteARMResourceData(StaticSiteLocation);
            var lro = await container.CreateOrUpdateAsync(WaitUntil.Completed, staticSiteName, input);
            StaticSiteResource staticSiteARMResource = lro.Value;
            Assert.IsTrue(await container.ExistsAsync(staticSiteName));
            Assert.IsFalse(await container.ExistsAsync(staticSiteName + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await container.ExistsAsync(null));
        }
    }
}
