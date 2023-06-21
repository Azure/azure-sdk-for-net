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
            string rgName = SessionRecording.GenerateAssetName("Sphere-RG-");
            var rgLro = await GlobalClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(AzureLocation.WestUS2));
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
            CatalogData data = new CatalogData(_resourceGroup.Data.Location);
            var catalog = await _resourceGroup.GetCatalogs().CreateOrUpdateAsync(WaitUntil.Completed, catalogName, data);
            Assert.IsNotNull(catalog);
            Assert.AreEqual(catalogName, catalog.Value.Data.Name);
        }
    }
}
