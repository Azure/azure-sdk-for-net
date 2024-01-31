// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Sphere.Tests.Scenario
{
    internal class CatalogTests : SphereManagementTestBase
    {
        private ResourceIdentifier _resourceGroupIdentifier;
        private ResourceGroupResource _resourceGroup;
        public CatalogTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            string rgName = "sdkTestRG";
            var rgLro = await GlobalClient.GetDefaultSubscriptionAsync().Result.GetResourceGroupAsync(rgName);
            _resourceGroupIdentifier = rgLro.Value.Id;
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task TestSetUp()
        {
            _resourceGroup = await Client.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();
        }

        [Test]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string catalogName = Recording.GenerateAssetName("catalog-");
            SphereCatalogData data = new SphereCatalogData("global");
            var catalog = await _resourceGroup.GetSphereCatalogs().CreateOrUpdateAsync(WaitUntil.Completed, catalogName, data);
            Assert.IsNotNull(catalog);
            Assert.AreEqual(catalogName, catalog.Value.Data.Name);

            await catalog.Value.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        [RecordedTest]
        public async Task Exist()
        {
            string catalogName = Recording.GenerateAssetName("catalog-");
            var catalog = await CreateCatalog(_resourceGroup, catalogName);
            bool flag = await _resourceGroup.GetSphereCatalogs().ExistsAsync(catalogName);
            Assert.IsTrue(flag);

            await catalog.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            string catalogName = Recording.GenerateAssetName("catalog-");
            await CreateCatalog(_resourceGroup, catalogName);
            var catalog = await _resourceGroup.GetSphereCatalogs().GetAsync(catalogName);
            Assert.IsNotNull(catalog);
            Assert.AreEqual(catalogName, catalog.Value.Data.Name);

            await catalog.Value.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            string catalogName = Recording.GenerateAssetName("catalog-");
            var catalog = await CreateCatalog(_resourceGroup, catalogName);
            var list = await _resourceGroup.GetSphereCatalogs().GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);

            await catalog.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        [RecordedTest]
        public async Task Delete()
        {
            string catalogName = Recording.GenerateAssetName("catalog-");
            var catalog = await CreateCatalog(_resourceGroup, catalogName);
            bool flag = await _resourceGroup.GetSphereCatalogs().ExistsAsync(catalogName);
            Assert.IsTrue(flag);
            await catalog.DeleteAsync(WaitUntil.Completed);
            flag = await _resourceGroup.GetSphereCatalogs().ExistsAsync(catalogName);
            Assert.IsFalse(flag);
        }
    }
}
