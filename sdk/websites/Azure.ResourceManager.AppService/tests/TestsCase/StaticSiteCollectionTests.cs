// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.AppService.Tests.Helpers;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.AppService.Tests.TestsCase
{
    public class StaticSiteCollectionTests : AppServiceTestBase
    {
        protected Location StaticSiteLocation => Location.EastUS2;
        public StaticSiteCollectionTests(bool isAsync)
           : base(isAsync, Azure.Core.TestFramework.RecordedTestMode.Record)
        {
        }

        private async Task<StaticSiteARMResourceCollection> GetStaticSiteCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup.GetStaticSiteARMResources();
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var container = await GetStaticSiteCollectionAsync();
            var name = Recording.GenerateAssetName("testStaticSite");
            var input = ResourceDataHelper.GetBasicStaticSiteARMSourceData(StaticSiteLocation);
            var lro = await container.CreateOrUpdateAsync(name, input);
            var staticSite = lro.Value;
            Assert.AreEqual(name, staticSite.Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var container = await GetStaticSiteCollectionAsync();
            var sourceName = Recording.GenerateAssetName("testStaticSite");
            var input = ResourceDataHelper.GetBasicSiteSourceControlData();
            var lro = await container.CreateOrUpdateAsync(sourceName, input);
            SiteSourceControl sourceControl1 = lro.Value;
            SiteSourceControl sourceControl2 = await container.GetAsync(sourceName);
            ResourceDataHelper.AssertSiteSourceControlData(sourceControl1.Data, sourceControl2.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            var container = await GetStaticSiteCollectionAsync();
            var input = ResourceDataHelper.GetBasicSiteSourceControlData(DefaultLocation);
            _ = await container.CreateOrUpdateAsync(Recording.GenerateAssetName("testStaticSite"), input);
            _ = await container.CreateOrUpdateAsync(Recording.GenerateAssetName("testStaticSite-"), input);
            int count = 0;
            await foreach (var siteSourceControl in container.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 2);
        }

        [TestCase]
        [RecordedTest]
        public async Task CheckIfExistsAsync()
        {
            var container = await GetStaticSiteCollectionAsync();
            var sourceControlName = Recording.GenerateAssetName("testStaticSite");
            var input = ResourceDataHelper.GetBasicAppServicePlanData(DefaultLocation);
            var lro = await container.CreateOrUpdateAsync(sourceControlName, input);
            AppServicePlan plan = lro.Value;
            Assert.IsTrue(await container.CheckIfExistsAsync(sourceControlName));
            Assert.IsFalse(await container.CheckIfExistsAsync(sourceControlName + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await container.CheckIfExistsAsync(null));
        }
    }
}
